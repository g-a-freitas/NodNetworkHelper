namespace NodNetworkHelper.NetworkConfigurationHelpers
{
	using System;
	using System.Runtime.InteropServices;
	using System.Runtime.InteropServices.ComTypes;
	using NETWORKLIST;

	public sealed class NetworkWatcher : INetworkEvents, IDisposable
	{
		#region Fields, Constants and Properties

		private readonly INetworkListManager _networkListManager;
		private readonly Action<string> _networkChangedCall;
		private int _networkCookie;
		private IConnectionPoint _networkConnectionPoint;

		#endregion

		#region Constructor and Destructors

		public NetworkWatcher(Action<string> networkChangedCall)
		{
			_networkListManager = new NetworkListManager();
			_networkChangedCall = networkChangedCall;
		}

		~NetworkWatcher()
		{
			Dispose(false);
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		#endregion

		#region Implementation of INetworkEvents

		public void NetworkAdded(Guid networkId)
		{
			// No actions needed on this event.
			return;
		}

		public void NetworkDeleted(Guid networkId)
		{
			// No actions needed on this event.
			return;
		}

		public void NetworkConnectivityChanged(Guid networkId, NLM_CONNECTIVITY newConnectivity)
		{
			// Event is only important in this case when the Name of the Network has changed and it is connected to a new Network
			if (((int)newConnectivity & (int)NLM_CONNECTIVITY.NLM_CONNECTIVITY_IPV4_INTERNET) == 0) { return; }

			var newNetworkName = _networkListManager.GetNetwork(networkId).GetName();
			if (_networkChangedCall != null && !string.IsNullOrEmpty(newNetworkName))
			{
				_networkChangedCall(newNetworkName);
			}
		}

		public void NetworkPropertyChanged(Guid networkId, NLM_NETWORK_PROPERTY_CHANGE flags)
		{
			// No actions needed on this event.
			return;
		}

		#endregion

		#region Public Methods

		public void SubscribeToWatchNetworkEvents()
		{
			var tempGuid = typeof(INetworkEvents).GUID;
			IConnectionPointContainer networkListManagerConnectionPoint = (IConnectionPointContainer)_networkListManager;
			networkListManagerConnectionPoint.FindConnectionPoint(ref tempGuid, out _networkConnectionPoint);
			_networkConnectionPoint.Advise(this, out _networkCookie);
		}

		public void UnsubscribeToWatchNetworkEvents()
		{
			if (_networkCookie != 0)
			{
				_networkConnectionPoint.Unadvise(_networkCookie);
			}

			_networkCookie = 0;
		}

		#endregion

		#region Protected Methods

		private void Dispose(bool disposing)
		{
			if (!disposing) { return; }
			UnsubscribeToWatchNetworkEvents();
			Marshal.FinalReleaseComObject(_networkListManager);
		}

		#endregion
	}
}