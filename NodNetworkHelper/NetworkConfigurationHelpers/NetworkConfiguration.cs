namespace NodNetworkHelper.NetworkConfigurationHelpers
{
	public class NetworkConfiguration
	{
		public string ConfigurationName { get; set; }

		public string NetworkAdapter { get; set; }

		public bool UseDHCP { get; set; }
		public string IpAddress { get; set; }
		public string SubNetworkMask { get; set; }
		public string DefaultGateway { get; set; }

		public string PreferentialDNS { get; set; }
		public string AlternativeDNS { get; set; }

		public bool UseProxy { get; set; }
		public bool BypassForLocalAddress { get; set; }
		public string Proxy { get; set; }

		public string WifiNameToWatch { get; set; }
	}
}