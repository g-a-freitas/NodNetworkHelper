namespace NodNetworkHelper
{
	using System.Linq;
	using System.Net;
	using System.Windows.Forms;
	using NodNetworkHelper.NetworkConfigurationHelpers;

	public partial class ConfigForm : Form
	{
		#region Fields and Properties

		private readonly NetworkConfigurationController _networkConfigurationController;
		private NetworkConfiguration _currentNetworkConfigurationBackup;

		#endregion

		#region Constructor

		public ConfigForm(NetworkConfigurationController networkConfigurationController)
		{
			_networkConfigurationController = networkConfigurationController;
			InitializeComponent();
		}

		#endregion

		#region Private Events

		private void ConfigFormLoad(object sender, System.EventArgs e)
		{
			LoadNetworkAdaptersList();
			LoadConfigurationsList();
			ClearAllFields();
			DisableAllEdit();
		}

		private void BtnSaveClick(object sender, System.EventArgs e)
		{
			if (CheckForDuplicatedConfigurationName(txtConfigAlias.Text.Trim()) && _currentNetworkConfigurationBackup == null)
			{
				MessageBox.Show(NodNetworkHelperResources.msgConfigurationNameAlreadyExist, NetworkConfigurationController.APPLICATION_NAME,
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else
			{
				if (ValidateConfigurationToSave())
				{
					var configurationToSave = new NetworkConfiguration
					{
						ConfigurationName = txtConfigAlias.Text.Trim(),
						UseDHCP = chkDHCP.Checked,
						UseProxy = chkUseProxy.Checked,
						BypassForLocalAddress = chkByPassForLocal.Checked,
						IpAddress = txtIP.Text.Trim(),
						SubNetworkMask = txtSubnetMask.Text.Trim(),
						DefaultGateway = txtGateway.Text.Trim(),
						PreferentialDNS = txtDNS1.Text.Trim(),
						AlternativeDNS = txtDNS2.Text.Trim(),
						Proxy = txtProxy.Text.Trim(),
						WifiNameToWatch = txtWifiAssociated.Text.Trim(),
						NetworkAdapter = cmbNetworkAdapter.SelectedItem.ToString()
					};

					_networkConfigurationController.AddNetworkConfiguration(configurationToSave, _currentNetworkConfigurationBackup);
					LoadConfigurationsList();
					ClearAllFields();
					_currentNetworkConfigurationBackup = null;
					DisableAllEdit();
				}
			}
		}

		private void BtnUndoClick(object sender, System.EventArgs e)
		{
			if (_currentNetworkConfigurationBackup == null || string.IsNullOrEmpty(_currentNetworkConfigurationBackup.ConfigurationName))
			{
				_currentNetworkConfigurationBackup = null;
				ClearAllFields();
			}
			else
			{
				LoadConfigurationDetails(_currentNetworkConfigurationBackup);
			}
		}

		private void CmbConfigurationSelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (cmbConfiguration.SelectedItem == null)
			{
				_currentNetworkConfigurationBackup = null;
			}
			else
			{
				_currentNetworkConfigurationBackup = _networkConfigurationController.NetworkConfigurationsList.FirstOrDefault(x =>
					x.ConfigurationName == cmbConfiguration.SelectedItem.ToString());
			}

			if (_currentNetworkConfigurationBackup == null || string.IsNullOrEmpty(_currentNetworkConfigurationBackup.ConfigurationName))
			{
				ClearAllFields();
			}
			else
			{
				EnableAllEdit();
				LoadConfigurationDetails(_currentNetworkConfigurationBackup);
			}
		}

		private void BtnNewClick(object sender, System.EventArgs e)
		{
			ClearAllFields();
			_currentNetworkConfigurationBackup = null;
			EnableAllEdit();
			cmbConfiguration.SelectedIndex = -1;
		}

		private void BtnDelClick(object sender, System.EventArgs e)
		{
			if (cmbConfiguration.SelectedItem == null) { return; }
			if (DialogResult.Yes != MessageBox.Show(NodNetworkHelperResources.msgDeleteConfiguration, NetworkConfigurationController.APPLICATION_NAME, MessageBoxButtons.YesNo,
				MessageBoxIcon.Question)) { return; }

			_currentNetworkConfigurationBackup = null;
			_networkConfigurationController.RemoveNetworkConfiguration(cmbConfiguration.SelectedItem.ToString());
			ClearAllFields();
			LoadConfigurationsList();
			DisableAllEdit();
		}

		private void ChkDHCPCheckedChanged(object sender, System.EventArgs e)
		{
			txtIP.Enabled = !chkDHCP.Checked;
			txtSubnetMask.Enabled = !chkDHCP.Checked;
			txtGateway.Enabled = !chkDHCP.Checked;
			txtDNS1.Enabled = !chkDHCP.Checked;
			txtDNS2.Enabled = !chkDHCP.Checked;
		}

		private void ChkUseProxyCheckedChanged(object sender, System.EventArgs e)
		{
			txtProxy.Enabled = chkUseProxy.Checked;
			chkByPassForLocal.Enabled = chkUseProxy.Checked;
		}

		#endregion

		#region Private Methods

		private bool ValidateConfigurationToSave()
		{
			if (string.IsNullOrEmpty(txtConfigAlias.Text))
			{
				MessageBox.Show(NodNetworkHelperResources.msgConfigurationNameInvalid, NetworkConfigurationController.APPLICATION_NAME,
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}

			if (cmbNetworkAdapter.SelectedItem == null || string.IsNullOrEmpty(cmbNetworkAdapter.SelectedItem.ToString()))
			{
				MessageBox.Show(NodNetworkHelperResources.msgNetworkAdapterInvalid, NetworkConfigurationController.APPLICATION_NAME,
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}

			if (!chkDHCP.Checked)
			{
				if (string.IsNullOrEmpty(txtIP.Text))
				{
					MessageBox.Show(NodNetworkHelperResources.msgIpAddressInvalid, NetworkConfigurationController.APPLICATION_NAME,
						MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return false;
				}

				IPAddress valideIPAddress;
				if (!IPAddress.TryParse(txtIP.Text, out valideIPAddress))
				{
					MessageBox.Show(NodNetworkHelperResources.msgIpAddressInvalid, NetworkConfigurationController.APPLICATION_NAME,
						MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return false;
				}

				if (string.IsNullOrEmpty(txtGateway.Text))
				{
					MessageBox.Show(NodNetworkHelperResources.msgGatewayInvalid, NetworkConfigurationController.APPLICATION_NAME,
						MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return false;
				}

				IPAddress valideGateway;
				if (!IPAddress.TryParse(txtGateway.Text, out valideGateway))
				{
					MessageBox.Show(NodNetworkHelperResources.msgGatewayInvalid, NetworkConfigurationController.APPLICATION_NAME,
						MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return false;
				}

				if (string.IsNullOrEmpty(txtSubnetMask.Text))
				{
					MessageBox.Show(NodNetworkHelperResources.msgSubNetworkMaskInvalid, NetworkConfigurationController.APPLICATION_NAME,
						MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return false;
				}

				IPAddress valideMask;
				if (!IPAddress.TryParse(txtSubnetMask.Text, out valideMask))
				{
					MessageBox.Show(NodNetworkHelperResources.msgSubNetworkMaskInvalid, NetworkConfigurationController.APPLICATION_NAME,
						MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return false;
				}

				if (string.IsNullOrEmpty(txtDNS1.Text))
				{
					MessageBox.Show(NodNetworkHelperResources.msgPreferentialDNSAddressInvalid, NetworkConfigurationController.APPLICATION_NAME,
						MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return false;
				}

				IPAddress validPrimaryDNS;
				if (!IPAddress.TryParse(txtDNS1.Text, out validPrimaryDNS))
				{
					MessageBox.Show(NodNetworkHelperResources.msgPreferentialDNSAddressInvalid, NetworkConfigurationController.APPLICATION_NAME,
						MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return false;
				}

				if (!string.IsNullOrEmpty(txtDNS2.Text))
				{
					IPAddress validAlternativeDNS;
					if (!IPAddress.TryParse(txtDNS2.Text, out validAlternativeDNS))
					{
						MessageBox.Show(NodNetworkHelperResources.msgAlternativeDNSAddressInvalid, NetworkConfigurationController.APPLICATION_NAME,
							MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return false;
					}
				}

				if (chkUseProxy.Checked)
				{
					if (string.IsNullOrEmpty(txtProxy.Text))
					{
						MessageBox.Show(NodNetworkHelperResources.msgProxyAddressInvalid, NetworkConfigurationController.APPLICATION_NAME,
							MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return false;
					}
				}
			}

			if (!string.IsNullOrEmpty(txtWifiAssociated.Text) && _networkConfigurationController.NetworkConfigurationsList != null)
			{
				bool alreadyExistConfigurationWatchingThisWifi;

				if (_currentNetworkConfigurationBackup != null && _currentNetworkConfigurationBackup.ConfigurationName != txtConfigAlias.Text)
				{
					alreadyExistConfigurationWatchingThisWifi = CheckForDuplicatedNetworkToWatchConfiguration(_currentNetworkConfigurationBackup.ConfigurationName);
				}
				else
				{
					alreadyExistConfigurationWatchingThisWifi = CheckForDuplicatedNetworkToWatchConfiguration(txtConfigAlias.Text);
				}

				if (alreadyExistConfigurationWatchingThisWifi)
				{
					MessageBox.Show(NodNetworkHelperResources.msgAlreadyExistsConfigurationAssociatedWithThisWifi,
						NetworkConfigurationController.APPLICATION_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return false;
				}
			}

			return true;
		}

		private bool CheckForDuplicatedNetworkToWatchConfiguration(string configurationName)
		{
			return _networkConfigurationController.NetworkConfigurationsList.Exists(x =>
				x.WifiNameToWatch == txtWifiAssociated.Text && x.ConfigurationName != configurationName);
		}

		private bool CheckForDuplicatedConfigurationName(string configurationName)
		{
			return
				_networkConfigurationController.NetworkConfigurationsList != null
				&& _networkConfigurationController.NetworkConfigurationsList.Exists(x => x.ConfigurationName == configurationName);
		}

		private void EnableAllEdit()
		{
			chkDHCP.Enabled = true;
			chkUseProxy.Enabled = true;
			txtConfigAlias.Enabled = true;
			txtIP.Enabled = true;
			txtSubnetMask.Enabled = true;
			txtGateway.Enabled = true;
			txtDNS1.Enabled = true;
			txtDNS2.Enabled = true;
			chkByPassForLocal.Enabled = false;
			txtProxy.Enabled = false;
			cmbNetworkAdapter.Enabled = true;
			txtWifiAssociated.Enabled = true;
			btnSave.Enabled = true;
			btnUndo.Enabled = true;
		}

		private void DisableAllEdit()
		{
			chkDHCP.Enabled = false;
			chkUseProxy.Enabled = false;
			txtConfigAlias.Enabled = false;
			txtIP.Enabled = false;
			txtSubnetMask.Enabled = false;
			txtGateway.Enabled = false;
			txtDNS1.Enabled = false;
			txtDNS2.Enabled = false;
			chkByPassForLocal.Enabled = false;
			txtProxy.Enabled = false;
			cmbNetworkAdapter.Enabled = false;
			txtWifiAssociated.Enabled = false;
			btnSave.Enabled = false;
			btnUndo.Enabled = false;
		}

		private void ClearAllFields()
		{
			cmbNetworkAdapter.SelectedIndex = -1;
			txtConfigAlias.Text = string.Empty;
			txtDNS1.Text = string.Empty;
			txtDNS2.Text = string.Empty;
			txtGateway.Text = string.Empty;
			txtIP.Text = string.Empty;
			txtProxy.Text = string.Empty;
			txtSubnetMask.Text = string.Empty;
			chkByPassForLocal.Checked = false;
			chkUseProxy.Checked = false;
			chkDHCP.Checked = false;
			txtProxy.Enabled = false;
			chkByPassForLocal.Enabled = false;
			txtWifiAssociated.Text = string.Empty;
		}

		private void LoadConfigurationDetails(NetworkConfiguration netConfig)
		{
			chkDHCP.Checked = netConfig.UseDHCP;
			chkUseProxy.Checked = netConfig.UseProxy;
			chkByPassForLocal.Checked = netConfig.BypassForLocalAddress;

			txtConfigAlias.Text = netConfig.ConfigurationName;
			txtIP.Text = netConfig.IpAddress;
			txtSubnetMask.Text = netConfig.SubNetworkMask;
			txtGateway.Text = netConfig.DefaultGateway;
			txtDNS1.Text = netConfig.PreferentialDNS;
			txtDNS2.Text = netConfig.AlternativeDNS;
			txtProxy.Text = netConfig.Proxy;
			txtWifiAssociated.Text = netConfig.WifiNameToWatch;

			cmbNetworkAdapter.SelectedIndex = cmbNetworkAdapter.Items.IndexOf(netConfig.NetworkAdapter);

			if (netConfig.UseDHCP)
			{
				DisableAllEdit();
				txtConfigAlias.Enabled = true;
				chkDHCP.Enabled = true;
				cmbNetworkAdapter.Enabled = true;
				txtWifiAssociated.Enabled = true;
				btnSave.Enabled = true;
				btnUndo.Enabled = true;
			}
			else if (!netConfig.UseProxy)
			{
				txtProxy.Enabled = false;
				chkByPassForLocal.Enabled = false;
			}
		}

		private void LoadConfigurationsList()
		{
			cmbConfiguration.Items.Clear();
			cmbConfiguration.Items.AddRange(_networkConfigurationController.NetworkConfigurationsList
				.OrderBy(x => x.ConfigurationName)
				.Select(x => x.ConfigurationName).ToArray());

			cmbConfiguration.SelectedIndex = -1;
			cmbConfiguration.SelectedText = string.Empty;
		}

		private void LoadNetworkAdaptersList()
		{
			cmbNetworkAdapter.Items.Clear();
			cmbNetworkAdapter.Items.AddRange(NetworkConfigurationController.GetNetworkInterfacesControllerNames().ToArray());
		}

		#endregion
	}
}