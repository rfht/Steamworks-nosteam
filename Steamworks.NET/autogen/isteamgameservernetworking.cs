// This file is provided under The MIT License as part of Steamworks.NET-nosteam.
// Copyright (c) 2013-2019 Riley Labrecque
// Copyright (c) 2019      Thomas Frohwein
// Please see the included LICENSE.txt for additional information.

using System.Runtime.InteropServices;
using IntPtr = System.IntPtr;

namespace Steamworks {
	public static class SteamGameServerNetworking {
		///  UDP-style (connectionless) networking interface.  These functions send messages using
		///  an API organized around the destination.  Reliable and unreliable messages are supported.
		///  For a more TCP-style interface (meaning you have a connection handle), see the functions below.
		///  Both interface styles can send both reliable and unreliable messages.
		///  Automatically establishes NAT-traversing or Relay server connections
		///  Sends a P2P packet to the specified user
		///  UDP-like, unreliable and a max packet size of 1200 bytes
		///  the first packet send may be delayed as the NAT-traversal code runs
		///  if we can't get through to the user, an error will be posted via the callback P2PSessionConnectFail_t
		///  see EP2PSend enum above for the descriptions of the different ways of sending packets
		///  nChannel is a routing number you can use to help route message to different systems 	- you'll have to call ReadP2PPacket()
		///  with the same channel number in order to retrieve the data on the other end
		///  using different channels to talk to the same user will still use the same underlying p2p connection, saving on resources
		public static bool SendP2PPacket(CSteamID steamIDRemote, byte[] pubData, uint cubData, EP2PSend eP2PSendType, int nChannel = 0) {
			return false;
		}

		///  returns true if any data is available for read, and the amount of data that will need to be read
		public static bool IsP2PPacketAvailable(out uint pcubMsgSize, int nChannel = 0) {
			pcubMsgSize = (uint) 0;
			return false;
		}

		///  reads in a packet that has been sent from another user via SendP2PPacket()
		///  returns the size of the message and the steamID of the user who sent it in the last two parameters
		///  if the buffer passed in is too small, the message will be truncated
		///  this call is not blocking, and will return false if no data is available
		public static bool ReadP2PPacket(byte[] pubDest, uint cubDest, out uint pcubMsgSize, out CSteamID psteamIDRemote, int nChannel = 0) {
			cubDest = (uint) 0;
			pcubMsgSize = (uint) 0;
			psteamIDRemote = (CSteamID) 0;
			return false;
		}

		///  AcceptP2PSessionWithUser() should only be called in response to a P2PSessionRequest_t callback
		///  P2PSessionRequest_t will be posted if another user tries to send you a packet that you haven't talked to yet
		///  if you don't want to talk to the user, just ignore the request
		///  if the user continues to send you packets, another P2PSessionRequest_t will be posted periodically
		///  this may be called multiple times for a single user
		///  (if you've called SendP2PPacket() on the other user, this implicitly accepts the session request)
		public static bool AcceptP2PSessionWithUser(CSteamID steamIDRemote) {
			return false;
		}

		///  call CloseP2PSessionWithUser() when you're done talking to a user, will free up resources under-the-hood
		///  if the remote user tries to send data to you again, another P2PSessionRequest_t callback will be posted
		public static bool CloseP2PSessionWithUser(CSteamID steamIDRemote) {
			return false;
		}

		///  call CloseP2PChannelWithUser() when you're done talking to a user on a specific channel. Once all channels
		///  open channels to a user have been closed, the open session to the user will be closed and new data from this
		///  user will trigger a P2PSessionRequest_t callback
		public static bool CloseP2PChannelWithUser(CSteamID steamIDRemote, int nChannel) {
			return false;
		}

		///  fills out P2PSessionState_t structure with details about the underlying connection to the user
		///  should only needed for debugging purposes
		///  returns false if no connection exists to the specified user
		public static bool GetP2PSessionState(CSteamID steamIDRemote, out P2PSessionState_t pConnectionState) {
			pConnectionState = new P2PSessionState_t();
			return false;
		}

		///  Allow P2P connections to fall back to being relayed through the Steam servers if a direct connection
		///  or NAT-traversal cannot be established. Only applies to connections created after setting this value,
		///  or to existing connections that need to automatically reconnect after this value is set.
		///  P2P packet relay is allowed by default
		public static bool AllowP2PPacketRelay(bool bAllow) { return false; }

		///  LISTEN / CONNECT connection-oriented interface functions
		///  These functions are more like a client-server TCP API.  One side is the "server"
		///  and "listens" for incoming connections, which then must be "accepted."  The "client"
		///  initiates a connection by "connecting."  Sending and receiving is done through a
		///  connection handle.
		///  For a more UDP-style interface, where you do not track connection handles but
		///  simply send messages to a SteamID, use the UDP-style functions above.
		///  Both methods can send both reliable and unreliable methods.
		///  creates a socket and listens others to connect
		///  will trigger a SocketStatusCallback_t callback on another client connecting
		///  nVirtualP2PPort is the unique ID that the client will connect to, in case you have multiple ports
		/// 		this can usually just be 0 unless you want multiple sets of connections
		///  unIP is the local IP address to bind to
		/// 		pass in 0 if you just want the default local IP
		///  unPort is the port to use
		/// 		pass in 0 if you don't want users to be able to connect via IP/Port, but expect to be always peer-to-peer connections only
		public static SNetListenSocket_t CreateListenSocket(int nVirtualP2PPort, uint nIP, ushort nPort, bool bAllowUseOfPacketRelay) {
			return (SNetListenSocket_t) 0;
		}

		///  creates a socket and begin connection to a remote destination
		///  can connect via a known steamID (client or game server), or directly to an IP
		///  on success will trigger a SocketStatusCallback_t callback
		///  on failure or timeout will trigger a SocketStatusCallback_t callback with a failure code in m_eSNetSocketState
		public static SNetSocket_t CreateP2PConnectionSocket(CSteamID steamIDTarget, int nVirtualPort, int nTimeoutSec, bool bAllowUseOfPacketRelay) {
			return (SNetSocket_t) 0;
		}

		public static SNetSocket_t CreateConnectionSocket(uint nIP, ushort nPort, int nTimeoutSec) {
			return (SNetSocket_t) 0;
		}

		///  disconnects the connection to the socket, if any, and invalidates the handle
		///  any unread data on the socket will be thrown away
		///  if bNotifyRemoteEnd is set, socket will not be completely destroyed until the remote end acknowledges the disconnect
		public static bool DestroySocket(SNetSocket_t hSocket, bool bNotifyRemoteEnd) {
			return false;
		}

		///  destroying a listen socket will automatically kill all the regular sockets generated from it
		public static bool DestroyListenSocket(SNetListenSocket_t hSocket, bool bNotifyRemoteEnd) {
			return false;
		}

		///  sending data
		///  must be a handle to a connected socket
		///  data is all sent via UDP, and thus send sizes are limited to 1200 bytes; after this, many routers will start dropping packets
		///  use the reliable flag with caution; although the resend rate is pretty aggressive,
		///  it can still cause stalls in receiving data (like TCP)
		public static bool SendDataOnSocket(SNetSocket_t hSocket, byte[] pubData, uint cubData, bool bReliable) {
			return false;
		}

		///  receiving data
		///  returns false if there is no data remaining
		///  fills out *pcubMsgSize with the size of the next message, in bytes
		public static bool IsDataAvailableOnSocket(SNetSocket_t hSocket, out uint pcubMsgSize) {
			pcubMsgSize = (uint) 0;
			return false;
		}

		///  fills in pubDest with the contents of the message
		///  messages are always complete, of the same size as was sent (i.e. packetized, not streaming)
		///  if *pcubMsgSize &lt; cubDest, only partial data is written
		///  returns false if no data is available
		public static bool RetrieveDataFromSocket(SNetSocket_t hSocket, byte[] pubDest, uint cubDest, out uint pcubMsgSize) {
			pcubMsgSize = (uint) 0;
			return false;
		}

		///  checks for data from any socket that has been connected off this listen socket
		///  returns false if there is no data remaining
		///  fills out *pcubMsgSize with the size of the next message, in bytes
		///  fills out *phSocket with the socket that data is available on
		public static bool IsDataAvailable(SNetListenSocket_t hListenSocket, out uint pcubMsgSize, out SNetSocket_t phSocket) {
			pcubMsgSize = (uint) 0;
			phSocket = (SNetSocket_t) 0;
			return false;
		}

		///  retrieves data from any socket that has been connected off this listen socket
		///  fills in pubDest with the contents of the message
		///  messages are always complete, of the same size as was sent (i.e. packetized, not streaming)
		///  if *pcubMsgSize &lt; cubDest, only partial data is written
		///  returns false if no data is available
		///  fills out *phSocket with the socket that data is available on
		public static bool RetrieveData(SNetListenSocket_t hListenSocket, byte[] pubDest, uint cubDest, out uint pcubMsgSize, out SNetSocket_t phSocket) {
			pcubMsgSize = (uint) 0;
			phSocket = (SNetSocket_t) 0;
			return false;
		}

		///  returns information about the specified socket, filling out the contents of the pointers
		public static bool GetSocketInfo(SNetSocket_t hSocket, out CSteamID pSteamIDRemote, out int peSocketStatus, out uint punIPRemote, out ushort punPortRemote) {
			pSteamIDRemote = (CSteamID) 0;
			peSocketStatus = 0;
			punIPRemote = (uint) 0;
			punPortRemote = (ushort) 0;
			return false;
		}

		///  returns which local port the listen socket is bound to
		///  *pnIP and *pnPort will be 0 if the socket is set to listen for P2P connections only
		public static bool GetListenSocketInfo(SNetListenSocket_t hListenSocket, out uint pnIP, out ushort pnPort) {
			pnIP = (uint) 0;
			pnPort = (ushort) 0;
			return false;
		}

		///  returns true to describe how the socket ended up connecting
		public static ESNetSocketConnectionType GetSocketConnectionType(SNetSocket_t hSocket) {
			return (ESNetSocketConnectionType) 0;
		}

		/// max packet size, in bytes
		public static int GetMaxPacketSize(SNetSocket_t hSocket) {
			return 0;
		}
	}
}
