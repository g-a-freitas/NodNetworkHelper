namespace NodNetworkHelper
{
	using System;
	using System.Windows.Forms;
	using NodNetworkHelper.NetworkConfigurationHelpers;

	public static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		public static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			var networkConfigurationController = new NetworkConfigurationController();
			NotifyIconController notifyIconController = new NotifyIconController(new ConfigForm(networkConfigurationController), networkConfigurationController);
			
			Application.Run();
		}
	}
}
