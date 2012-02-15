namespace NodNetworkHelper
{
	using System.Collections.Generic;
	using System.Drawing;
	using System.Linq;
	using System.Windows.Forms;
	using NodNetworkHelper.NetworkConfigurationHelpers;

	public class NotifyIconController
	{
		#region Fields and Properties

		private const int DURATION_OF_TIP_BALLOON_IN_MILISECONDS = 3000;
		private readonly ConfigForm _defaultConfigurationForm;
		private readonly NetworkConfigurationController _networkConfigurationController;

		private System.ComponentModel.Container _components;
		private NotifyIcon _notifyIcon;
		private ContextMenuStrip _notifyContextMenu;

		#endregion

		#region Constructor

		public NotifyIconController(ConfigForm defaultConfigurationForm, NetworkConfigurationController networkConfigurationController)
		{
			_defaultConfigurationForm = defaultConfigurationForm;
			_networkConfigurationController = networkConfigurationController;
			_networkConfigurationController.InitializeCallbackMethods(ConfigureNotifyIconMenu, DisplayInfo, DisplayError, DisplayWarning);

			InitializeNotifyIcon();
			ConfigureNotifyIconMenu();
		}

		#endregion

		#region Private Events

		private void NotifyContextMenuCloseItemOnClick(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		private void NotifyContextMenuOpenConfigItemOnClick(object sender, System.EventArgs e)
		{
			_defaultConfigurationForm.ShowDialog();
		}

		private void NotifyIconMouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Right) { return; }
			_notifyContextMenu.Show();
		}

		private void NotifyContextMenuSetNetworkItemOnClick(object sender, System.EventArgs e)
		{
			var item = (ToolStripMenuItem)sender;
			var configuration = _networkConfigurationController.NetworkConfigurationsList.Single(x => x.ConfigurationName == item.Text);
			_networkConfigurationController.SetNetworkConfiguration(configuration);
		}

		private void NotifyContextMenuEnableDisableWifiWatcherItemOnClick(object sender, System.EventArgs e)
		{
			_networkConfigurationController.WifiWatcherEnabled = !_networkConfigurationController.WifiWatcherEnabled;
			_networkConfigurationController.ChangeWifiWatcherStatus();
			ConfigureNotifyIconMenu();
		}

		#endregion

		#region Private Methods

		private void InitializeNotifyIcon()
		{
			_components = new System.ComponentModel.Container();

			_notifyIcon = new NotifyIcon(_components)
			{
				Visible = true,
				Icon = NodNetworkHelperResources.Network16,
				Text = NodNetworkHelperResources.lblAppName
			};

			_notifyIcon.MouseClick += NotifyIconMouseClick;
		}

		private void ConfigureNotifyIconMenu()
		{
			if (_notifyIcon == null) { InitializeNotifyIcon(); }

			// Create the menu and add the initilized items
			_notifyContextMenu = new ContextMenuStrip
			{
				ShowImageMargin = false,
				BackColor = Color.White
			};
			_notifyContextMenu.Items.Clear();

			var networkConfigurationItems = CreateNetworkConfigurationItems();
			if (networkConfigurationItems != null)
			{
				_notifyContextMenu.Items.AddRange(networkConfigurationItems.ToArray());
			}

			_notifyContextMenu.Items.Add(new ToolStripSeparator());
			_notifyContextMenu.Items.Add(CreateEnableDisableWifiWatcherButtonMenuItem());
			_notifyContextMenu.Items.Add(new ToolStripSeparator());
			_notifyContextMenu.Items.Add(CreateOpenConfigurationMenuItem());
			_notifyContextMenu.Items.Add(CreateCloseApplicationMenuItem());

			// Bind the menu to the current NotifyIcon
			if (_notifyIcon != null) { _notifyIcon.ContextMenuStrip = _notifyContextMenu; }
		}

		private ToolStripMenuItem CreateEnableDisableWifiWatcherButtonMenuItem()
		{
			ToolStripMenuItem enableDisableWifiWatcherMenuItem;

			if (_networkConfigurationController.WifiWatcherEnabled)
			{
				enableDisableWifiWatcherMenuItem = new ToolStripMenuItem(NodNetworkHelperResources.lblDisableWifiWatcher,
				null, NotifyContextMenuEnableDisableWifiWatcherItemOnClick, (Keys.Control | Keys.W));
			}
			else
			{
				enableDisableWifiWatcherMenuItem = new ToolStripMenuItem(NodNetworkHelperResources.lblEnableWifiWatcher,
				null, NotifyContextMenuEnableDisableWifiWatcherItemOnClick, (Keys.Control | Keys.W));
			}

			return enableDisableWifiWatcherMenuItem;
		}

		private ToolStripMenuItem CreateCloseApplicationMenuItem()
		{
			ToolStripMenuItem closeApplicationMenuItem = new ToolStripMenuItem(NodNetworkHelperResources.lblCloseApplication,
				null, NotifyContextMenuCloseItemOnClick, (Keys.Control | Keys.C))
			{
				ShowShortcutKeys = true
			};

			return closeApplicationMenuItem;
		}

		private ToolStripMenuItem CreateOpenConfigurationMenuItem()
		{
			ToolStripMenuItem openConfigMenuItem = new ToolStripMenuItem(NodNetworkHelperResources.lblOpenConfiguration,
				null, NotifyContextMenuOpenConfigItemOnClick,
				(Keys.Control | Keys.O))
			{
				ShowShortcutKeys = true
			};

			return openConfigMenuItem;
		}

		private List<ToolStripMenuItem> CreateNetworkConfigurationItems()
		{
			if (_networkConfigurationController.NetworkConfigurationsList == null) { return null; }
			var networkConfigurations = _networkConfigurationController.NetworkConfigurationsList.OrderBy(x => x.ConfigurationName);
			return networkConfigurations.Select(networkConfiguration =>
				new ToolStripMenuItem(networkConfiguration.ConfigurationName, null, NotifyContextMenuSetNetworkItemOnClick)).ToList();
		}

		private void DisplayInfo(string infoMessage)
		{
			_notifyIcon.ShowBalloonTip(DURATION_OF_TIP_BALLOON_IN_MILISECONDS, NodNetworkHelperResources.lblToolTipBalloonTitle_Info,
				infoMessage, ToolTipIcon.Info);
		}

		private void DisplayError(string errorMessage)
		{
			_notifyIcon.ShowBalloonTip(DURATION_OF_TIP_BALLOON_IN_MILISECONDS, NodNetworkHelperResources.lblToolTipBalloonTitle_Error,
				errorMessage, ToolTipIcon.Error);
		}

		private void DisplayWarning(string warningMessage)
		{
			_notifyIcon.ShowBalloonTip(DURATION_OF_TIP_BALLOON_IN_MILISECONDS, NodNetworkHelperResources.lblToolTipBalloonTitle_Warning,
				warningMessage, ToolTipIcon.Warning);
		}

		#endregion
	}
}