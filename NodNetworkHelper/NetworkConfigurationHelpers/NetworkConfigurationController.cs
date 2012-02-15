namespace NodNetworkHelper.NetworkConfigurationHelpers
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Management;
	using System.Threading;
	using System.Xml.Serialization;

	public class NetworkConfigurationController
	{
		#region Constants, Fields and Properties

		public const string APPLICATION_NAME = "NodNetwork Helper";

		/// <summary>
		/// Search Query used to find only the Physical Network Adapter in Windows.
		///		-> Manufacturer != 'Microsoft' will exclude all windows virtual adapters.
		///		-> NOT PNPDeviceID LIKE 'ROOT\\%' will exclude all other third-part manufactorers virtual adapters.
		/// </summary>
		private const string PHYSICAL_NETWORK_ADAPTER_QUERY = @"SELECT * FROM Win32_NetworkAdapter WHERE Manufacturer != 'Microsoft' AND NOT PNPDeviceID LIKE 'ROOT\\%'";
		private const string BACKUP_FILE_NAME = "NodNetworkConfiguration.bkp";

		private readonly NetworkWatcher _networkWatcher;
		private NodNetworkHelperData _nodNetworkHelperData = new NodNetworkHelperData();
		private Action _updateNetworkContextMethod;
		private Action<string> _displayInfoMethod;
		private Action<string> _displayErrorMethod;
		private Action<string> _displayWarningMethod;
		private string _currentWifi;
		private bool _busyWithConfigurationChange;

		public List<NetworkConfiguration> NetworkConfigurationsList
		{
			get { return _nodNetworkHelperData.NetworkConfigurationsList; }
		}

		public bool WifiWatcherEnabled
		{
			get
			{
				return _nodNetworkHelperData.WifiWatcherEnabled;
			}

			set
			{
				_nodNetworkHelperData.WifiWatcherEnabled = value;
			}
		}

		#endregion

		#region Constructor & Destructor

		public NetworkConfigurationController()
		{
			InitializeWithDefaultValues();
			_networkWatcher = new NetworkWatcher(NetworkChangedCallMethod);
			LoadNetworkConfiguration();

			ChangeWifiWatcherStatus();
		}

		~NetworkConfigurationController()
		{
			if (_networkWatcher != null) { _networkWatcher.Dispose(); }
		}

		#endregion

		#region Public Methods

		public static List<string> GetNetworkInterfacesControllerNames()
		{
			ManagementObjectSearcher networkAdapterSearcher = new ManagementObjectSearcher(PHYSICAL_NETWORK_ADAPTER_QUERY);
			var networkAdaptersList = networkAdapterSearcher.Get()
				.Cast<ManagementObject>()
				.OrderBy(p => Convert.ToUInt32(p.Properties["Index"].Value))
				.ToList();
			return networkAdaptersList.Select(networkAdapter => networkAdapter["Caption"].ToString()).ToList();
		}

		public void RemoveNetworkConfiguration(string configurationName)
		{
			var configurationToRemove = NetworkConfigurationsList.Single(x => x.ConfigurationName == configurationName);
			NetworkConfigurationsList.Remove(configurationToRemove);

			if (_updateNetworkContextMethod != null) { _updateNetworkContextMethod(); }
			SaveNetworkConfiguration();
		}

		public void AddNetworkConfiguration(NetworkConfiguration configurationToAdd, NetworkConfiguration oldConfigurationReference)
		{
			if (oldConfigurationReference == null)
			{
				NetworkConfigurationsList.Add(configurationToAdd);
			}
			else
			{
				var configurationToUpdate = NetworkConfigurationsList.Single(x => x.ConfigurationName == oldConfigurationReference.ConfigurationName);
				NetworkConfigurationsList.Remove(configurationToUpdate);
				NetworkConfigurationsList.Add(configurationToAdd);
			}

			if (_updateNetworkContextMethod != null) { _updateNetworkContextMethod(); }
			SaveNetworkConfiguration();
		}

		public void SetNetworkConfiguration(NetworkConfiguration configurationToSet)
		{
			_busyWithConfigurationChange = true;

			try
			{
				if (configurationToSet.UseDHCP)
				{
					SetDHCPtoDesiredNetworkAdapter(configurationToSet.NetworkAdapter);
				}
				else
				{
					SetIPtoDesiredNetworkAdapter(configurationToSet);
				}

				_displayInfoMethod(string.Format(NodNetworkHelperResources.msgConfigurationChangedTo, configurationToSet.ConfigurationName));
			}
			catch (Exception)
			{
				_displayErrorMethod(string.Format(NodNetworkHelperResources.msgFailureConfigurationChangedTo, configurationToSet.ConfigurationName));
			}

			if (_nodNetworkHelperData.WifiWatcherEnabled)
			{
				// Wait for a while to allow the adapter to complete the configuration change and do not trigger another connection change in the WifiWatcher
				Thread.Sleep(5000);
			}

			_busyWithConfigurationChange = false;
		}

		public void InitializeCallbackMethods(Action updateNetworkContextMethod, Action<string> displayInfoMethod,
			Action<string> displayErrorMethod, Action<string> displayWarningMethod)
		{
			_updateNetworkContextMethod = updateNetworkContextMethod;
			_displayInfoMethod = displayInfoMethod;
			_displayErrorMethod = displayErrorMethod;
			_displayWarningMethod = displayWarningMethod;
		}

		public void ChangeWifiWatcherStatus()
		{
			if (_nodNetworkHelperData.WifiWatcherEnabled)
			{
				_networkWatcher.SubscribeToWatchNetworkEvents();
			}
			else
			{
				_networkWatcher.UnsubscribeToWatchNetworkEvents();
			}

			SaveNetworkConfiguration();
		}

		#endregion

		#region Private Methods

		private void SetDHCPtoDesiredNetworkAdapter(string networkAdapterName)
		{
			ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
			var moc = mc.GetInstances();

			foreach (ManagementObject mo in moc)
			{
				if (!mo["Caption"].Equals(networkAdapterName)) { continue; }

				var newDNS = mo.GetMethodParameters("SetDNSServerSearchOrder");
				newDNS["DNSServerSearchOrder"] = null;
				mo.InvokeMethod("EnableDHCP", null, null);
				mo.InvokeMethod("SetDNSServerSearchOrder", newDNS, null);
			}
		}

		private void SetIPtoDesiredNetworkAdapter(NetworkConfiguration configurationToSet)
		{
			ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
			var moc = mc.GetInstances();

			foreach (ManagementObject mo in moc)
			{
				if (!mo["Caption"].Equals(configurationToSet.NetworkAdapter)) { continue; }

				ManagementBaseObject newIP = mo.GetMethodParameters("EnableStatic");
				ManagementBaseObject newGateway = mo.GetMethodParameters("SetGateways");
				ManagementBaseObject newDNS = mo.GetMethodParameters("SetDNSServerSearchOrder");

				newGateway["DefaultIPGateway"] = new[] { configurationToSet.DefaultGateway };
				newGateway["GatewayCostMetric"] = new[] { 1 };

				newIP["IPAddress"] = configurationToSet.IpAddress.Split(',');
				newIP["SubnetMask"] = new[] { configurationToSet.SubNetworkMask };

				var dnsIPs = string.Format("{0},{1}", configurationToSet.PreferentialDNS, configurationToSet.AlternativeDNS);
				newDNS["DNSServerSearchOrder"] = dnsIPs.Split(',');

				mo.InvokeMethod("EnableStatic", newIP, null);
				mo.InvokeMethod("SetGateways", newGateway, null);
				mo.InvokeMethod("SetDNSServerSearchOrder", newDNS, null);

				break;
			}
		}

		private void SaveNetworkConfiguration()
		{
			CheckForBackupFile();

			XmlSerializer backupSerializer = new XmlSerializer(_nodNetworkHelperData.GetType());
			StreamWriter backupFileWriter = new StreamWriter(BACKUP_FILE_NAME);
			backupSerializer.Serialize(backupFileWriter, _nodNetworkHelperData);
			backupFileWriter.Close();
			backupFileWriter.Dispose();
		}

		private void LoadNetworkConfiguration()
		{
			CheckForBackupFile();

			XmlSerializer backupSerializer = new XmlSerializer(_nodNetworkHelperData.GetType());
			StreamReader backupFileReader = new StreamReader(BACKUP_FILE_NAME);
			try
			{
				_nodNetworkHelperData = (NodNetworkHelperData)backupSerializer.Deserialize(backupFileReader);
			}
			catch (Exception)
			{
				return;
			}
			finally
			{
				backupFileReader.Close();
				backupFileReader.Dispose();
			}
		}

		private void CheckForBackupFile()
		{
			if (File.Exists(BACKUP_FILE_NAME)) { return; }
			var createdFile = File.Create(BACKUP_FILE_NAME);
			createdFile.Close();
			createdFile.Dispose();
		}

		private void NetworkChangedCallMethod(string newNetworkName)
		{
			if (_busyWithConfigurationChange) { return; }
			if (newNetworkName.Trim().Equals(_currentWifi)) { return; }

			_currentWifi = newNetworkName;
			var configurationToActive = _nodNetworkHelperData.NetworkConfigurationsList.FirstOrDefault(x => x.WifiNameToWatch == newNetworkName);
			if (configurationToActive != null)
			{
				SetNetworkConfiguration(configurationToActive);
			}
			else
			{
				_displayWarningMethod(NodNetworkHelperResources.msgWifiChangedNoConfigurationFound);
			}
		}

		private void InitializeWithDefaultValues()
		{
			_nodNetworkHelperData.WifiWatcherEnabled = false;
			_nodNetworkHelperData.NetworkConfigurationsList = new List<NetworkConfiguration>();
		}

		#endregion
	}
}