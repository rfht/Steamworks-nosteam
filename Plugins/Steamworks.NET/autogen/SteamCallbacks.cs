// This file is provided under The MIT License as part of Steamworks.NET-nosteam.
// Copyright (c) 2013-2019 Riley Labrecque
// Copyright (c) 2019      Thomas Frohwein
// Please see the included LICENSE.txt for additional information.

using System.Runtime.InteropServices;
using IntPtr = System.IntPtr;

namespace Steamworks {
	// callbacks
	//---------------------------------------------------------------------------------
	// Purpose: Sent when a new app is installed
	//---------------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamAppListCallbacks + 1)]
	public struct SteamAppInstalled_t {
		public const int k_iCallback = Constants.k_iSteamAppListCallbacks + 1;
		public AppId_t m_nAppID;			// ID of the app that installs
	}

	//---------------------------------------------------------------------------------
	// Purpose: Sent when an app is uninstalled
	//---------------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamAppListCallbacks + 2)]
	public struct SteamAppUninstalled_t {
		public const int k_iCallback = Constants.k_iSteamAppListCallbacks + 2;
		public AppId_t m_nAppID;			// ID of the app that installs
	}

	// callbacks
	//-----------------------------------------------------------------------------
	// Purpose: posted after the user gains ownership of DLC & that DLC is installed
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamAppsCallbacks + 5)]
	public struct DlcInstalled_t {
		public const int k_iCallback = Constants.k_iSteamAppsCallbacks + 5;
		public AppId_t m_nAppID;		// AppID of the DLC
	}

	//-----------------------------------------------------------------------------
	// Purpose: response to RegisterActivationCode()
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamAppsCallbacks + 8)]
	public struct RegisterActivationCodeResponse_t {
		public const int k_iCallback = Constants.k_iSteamAppsCallbacks + 8;
		public ERegisterActivationCodeResult m_eResult;
		public uint m_unPackageRegistered;						// package that was registered. Only set on success
	}

	//---------------------------------------------------------------------------------
	// Purpose: posted after the user gains executes a Steam URL with command line or query parameters
	// such as steam://run/<appid>//-commandline/?param1=value1&param2=value2&param3=value3 etc
	// while the game is already running.  The new params can be queried
	// with GetLaunchQueryParam and GetLaunchCommandLine
	//---------------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value, Size = 1)]
	[CallbackIdentity(Constants.k_iSteamAppsCallbacks + 14)]
	public struct NewUrlLaunchParameters_t {
		public const int k_iCallback = Constants.k_iSteamAppsCallbacks + 14;
	}

	//-----------------------------------------------------------------------------
	// Purpose: response to RequestAppProofOfPurchaseKey/RequestAllProofOfPurchaseKeys
	// for supporting third-party CD keys, or other proof-of-purchase systems.
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamAppsCallbacks + 21)]
	public struct AppProofOfPurchaseKeyResponse_t {
		public const int k_iCallback = Constants.k_iSteamAppsCallbacks + 21;
		public EResult m_eResult;
		public uint m_nAppID;
		public uint m_cchKeyLength;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.k_cubAppProofOfPurchaseKeyMax)]
		public string m_rgchKey;
	}

	//-----------------------------------------------------------------------------
	// Purpose: response to GetFileDetails
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamAppsCallbacks + 23)]
	public struct FileDetailsResult_t {
		public const int k_iCallback = Constants.k_iSteamAppsCallbacks + 23;
		public EResult m_eResult;
		public ulong m_ulFileSize;	// original file size in bytes
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
		public byte[] m_FileSHA;	// original file SHA1 hash
		public uint m_unFlags;		//
	}

	// callbacks
	//-----------------------------------------------------------------------------
	// Purpose: called when a friends' status changes
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamFriendsCallbacks + 4)]
	public struct PersonaStateChange_t {
		public const int k_iCallback = Constants.k_iSteamFriendsCallbacks + 4;
		
		public ulong m_ulSteamID;		// steamID of the friend who changed
		public EPersonaChange m_nChangeFlags;		// what's changed
	}

	//-----------------------------------------------------------------------------
	// Purpose: posted when game overlay activates or deactivates
	//			the game can use this to be pause or resume single player games
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamFriendsCallbacks + 31)]
	public struct GameOverlayActivated_t {
		public const int k_iCallback = Constants.k_iSteamFriendsCallbacks + 31;
		public byte m_bActive;	// true if it's just been activated, false otherwise
	}

	//-----------------------------------------------------------------------------
	// Purpose: called when the user tries to join a different game server from their friends list
	//			game client should attempt to connect to specified server when this is received
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamFriendsCallbacks + 32)]
	public struct GameServerChangeRequested_t {
		public const int k_iCallback = Constants.k_iSteamFriendsCallbacks + 32;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
		public string m_rgchServer;		// server address ("127.0.0.1:27015", "tf2.valvesoftware.com")
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
		public string m_rgchPassword;	// server password, if any
	}

	//-----------------------------------------------------------------------------
	// Purpose: called when the user tries to join a lobby from their friends list
	//			game client should attempt to connect to specified lobby when this is received
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamFriendsCallbacks + 33)]
	public struct GameLobbyJoinRequested_t {
		public const int k_iCallback = Constants.k_iSteamFriendsCallbacks + 33;
		public CSteamID m_steamIDLobby;
		
		// The friend they did the join via (will be invalid if not directly via a friend)
		//
		// On PS3, the friend will be invalid if this was triggered by a PSN invite via the XMB, but
		// the account type will be console user so you can tell at least that this was from a PSN friend
		// rather than a Steam friend.
		public CSteamID m_steamIDFriend;
	}

	//-----------------------------------------------------------------------------
	// Purpose: called when an avatar is loaded in from a previous GetLargeFriendAvatar() call
	//			if the image wasn't already available
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	[CallbackIdentity(Constants.k_iSteamFriendsCallbacks + 34)]
	public struct AvatarImageLoaded_t {
		public const int k_iCallback = Constants.k_iSteamFriendsCallbacks + 34;
		public CSteamID m_steamID; // steamid the avatar has been loaded for
		public int m_iImage; // the image index of the now loaded image
		public int m_iWide; // width of the loaded image
		public int m_iTall; // height of the loaded image
	}

	//-----------------------------------------------------------------------------
	// Purpose: marks the return of a request officer list call
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamFriendsCallbacks + 35)]
	public struct ClanOfficerListResponse_t {
		public const int k_iCallback = Constants.k_iSteamFriendsCallbacks + 35;
		public CSteamID m_steamIDClan;
		public int m_cOfficers;
		public byte m_bSuccess;
	}

	//-----------------------------------------------------------------------------
	// Purpose: callback indicating updated data about friends rich presence information
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	[CallbackIdentity(Constants.k_iSteamFriendsCallbacks + 36)]
	public struct FriendRichPresenceUpdate_t {
		public const int k_iCallback = Constants.k_iSteamFriendsCallbacks + 36;
		public CSteamID m_steamIDFriend;	// friend who's rich presence has changed
		public AppId_t m_nAppID;			// the appID of the game (should always be the current game)
	}

	//-----------------------------------------------------------------------------
	// Purpose: called when the user tries to join a game from their friends list
	//			rich presence will have been set with the "connect" key which is set here
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamFriendsCallbacks + 37)]
	public struct GameRichPresenceJoinRequested_t {
		public const int k_iCallback = Constants.k_iSteamFriendsCallbacks + 37;
		public CSteamID m_steamIDFriend;		// the friend they did the join via (will be invalid if not directly via a friend)
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.k_cchMaxRichPresenceValueLength)]
		public string m_rgchConnect;
	}

	//-----------------------------------------------------------------------------
	// Purpose: a chat message has been received for a clan chat the game has joined
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	[CallbackIdentity(Constants.k_iSteamFriendsCallbacks + 38)]
	public struct GameConnectedClanChatMsg_t {
		public const int k_iCallback = Constants.k_iSteamFriendsCallbacks + 38;
		public CSteamID m_steamIDClanChat;
		public CSteamID m_steamIDUser;
		public int m_iMessageID;
	}

	//-----------------------------------------------------------------------------
	// Purpose: a user has joined a clan chat
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamFriendsCallbacks + 39)]
	public struct GameConnectedChatJoin_t {
		public const int k_iCallback = Constants.k_iSteamFriendsCallbacks + 39;
		public CSteamID m_steamIDClanChat;
		public CSteamID m_steamIDUser;
	}

	//-----------------------------------------------------------------------------
	// Purpose: a user has left the chat we're in
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	[CallbackIdentity(Constants.k_iSteamFriendsCallbacks + 40)]
	public struct GameConnectedChatLeave_t {
		public const int k_iCallback = Constants.k_iSteamFriendsCallbacks + 40;
		public CSteamID m_steamIDClanChat;
		public CSteamID m_steamIDUser;
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bKicked;		// true if admin kicked
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bDropped;	// true if Steam connection dropped
	}

	//-----------------------------------------------------------------------------
	// Purpose: a DownloadClanActivityCounts() call has finished
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamFriendsCallbacks + 41)]
	public struct DownloadClanActivityCountsResult_t {
		public const int k_iCallback = Constants.k_iSteamFriendsCallbacks + 41;
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bSuccess;
	}

	//-----------------------------------------------------------------------------
	// Purpose: a JoinClanChatRoom() call has finished
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	[CallbackIdentity(Constants.k_iSteamFriendsCallbacks + 42)]
	public struct JoinClanChatRoomCompletionResult_t {
		public const int k_iCallback = Constants.k_iSteamFriendsCallbacks + 42;
		public CSteamID m_steamIDClanChat;
		public EChatRoomEnterResponse m_eChatRoomEnterResponse;
	}

	//-----------------------------------------------------------------------------
	// Purpose: a chat message has been received from a user
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	[CallbackIdentity(Constants.k_iSteamFriendsCallbacks + 43)]
	public struct GameConnectedFriendChatMsg_t {
		public const int k_iCallback = Constants.k_iSteamFriendsCallbacks + 43;
		public CSteamID m_steamIDUser;
		public int m_iMessageID;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	[CallbackIdentity(Constants.k_iSteamFriendsCallbacks + 44)]
	public struct FriendsGetFollowerCount_t {
		public const int k_iCallback = Constants.k_iSteamFriendsCallbacks + 44;
		public EResult m_eResult;
		public CSteamID m_steamID;
		public int m_nCount;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	[CallbackIdentity(Constants.k_iSteamFriendsCallbacks + 45)]
	public struct FriendsIsFollowing_t {
		public const int k_iCallback = Constants.k_iSteamFriendsCallbacks + 45;
		public EResult m_eResult;
		public CSteamID m_steamID;
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bIsFollowing;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	[CallbackIdentity(Constants.k_iSteamFriendsCallbacks + 46)]
	public struct FriendsEnumerateFollowingList_t {
		public const int k_iCallback = Constants.k_iSteamFriendsCallbacks + 46;
		public EResult m_eResult;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = Constants.k_cEnumerateFollowersMax)]
		public CSteamID[] m_rgSteamID;
		public int m_nResultsReturned;
		public int m_nTotalResultCount;
	}

	//-----------------------------------------------------------------------------
	// Purpose: reports the result of an attempt to change the user's persona name
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamFriendsCallbacks + 47)]
	public struct SetPersonaNameResponse_t {
		public const int k_iCallback = Constants.k_iSteamFriendsCallbacks + 47;
		
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bSuccess; // true if name change succeeded completely.
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bLocalSuccess; // true if name change was retained locally.  (We might not have been able to communicate with Steam)
		public EResult m_result; // detailed result code
	}

	//-----------------------------------------------------------------------------
	// Purpose: Invoked when the status of unread messages changes
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value, Size = 1)]
	[CallbackIdentity(Constants.k_iSteamFriendsCallbacks + 48)]
	public struct UnreadChatMessagesChanged_t {
		public const int k_iCallback = Constants.k_iSteamFriendsCallbacks + 48;
	}

	// callbacks
	// callback notification - A new message is available for reading from the message queue
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamGameCoordinatorCallbacks + 1)]
	public struct GCMessageAvailable_t {
		public const int k_iCallback = Constants.k_iSteamGameCoordinatorCallbacks + 1;
		public uint m_nMessageSize;
	}

	// callback notification - A message failed to make it to the GC. It may be down temporarily
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value, Size = 1)]
	[CallbackIdentity(Constants.k_iSteamGameCoordinatorCallbacks + 2)]
	public struct GCMessageFailed_t {
		public const int k_iCallback = Constants.k_iSteamGameCoordinatorCallbacks + 2;
	}

														// won't enforce authentication of users that connect to the server.
														// Useful when you run a server where the clients may not
														// be connected to the internet but you want them to play (i.e LANs)
	// callbacks
	// client has been approved to connect to this game server
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamGameServerCallbacks + 1)]
	public struct GSClientApprove_t {
		public const int k_iCallback = Constants.k_iSteamGameServerCallbacks + 1;
		public CSteamID m_SteamID;			// SteamID of approved player
		public CSteamID m_OwnerSteamID;	// SteamID of original owner for game license
	}

	// client has been denied to connection to this game server
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	[CallbackIdentity(Constants.k_iSteamGameServerCallbacks + 2)]
	public struct GSClientDeny_t {
		public const int k_iCallback = Constants.k_iSteamGameServerCallbacks + 2;
		public CSteamID m_SteamID;
		public EDenyReason m_eDenyReason;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
		public string m_rgchOptionalText;
	}

	// request the game server should kick the user
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	[CallbackIdentity(Constants.k_iSteamGameServerCallbacks + 3)]
	public struct GSClientKick_t {
		public const int k_iCallback = Constants.k_iSteamGameServerCallbacks + 3;
		public CSteamID m_SteamID;
		public EDenyReason m_eDenyReason;
	}

	// NOTE: callback values 4 and 5 are skipped because they are used for old deprecated callbacks,
	// do not reuse them here.
	// client achievement info
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamGameServerCallbacks + 6)]
	public struct GSClientAchievementStatus_t {
		public const int k_iCallback = Constants.k_iSteamGameServerCallbacks + 6;
		public ulong m_SteamID;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
		public string m_pchAchievement;
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bUnlocked;
	}

	// received when the game server requests to be displayed as secure (VAC protected)
	// m_bSecure is true if the game server should display itself as secure to users, false otherwise
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamUserCallbacks + 15)]
	public struct GSPolicyResponse_t {
		public const int k_iCallback = Constants.k_iSteamUserCallbacks + 15;
		public byte m_bSecure;
	}

	// GS gameplay stats info
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamGameServerCallbacks + 7)]
	public struct GSGameplayStats_t {
		public const int k_iCallback = Constants.k_iSteamGameServerCallbacks + 7;
		public EResult m_eResult;					// Result of the call
		public int m_nRank;					// Overall rank of the server (0-based)
		public uint m_unTotalConnects;			// Total number of clients who have ever connected to the server
		public uint m_unTotalMinutesPlayed;		// Total number of minutes ever played on the server
	}

	// send as a reply to RequestUserGroupStatus()
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	[CallbackIdentity(Constants.k_iSteamGameServerCallbacks + 8)]
	public struct GSClientGroupStatus_t {
		public const int k_iCallback = Constants.k_iSteamGameServerCallbacks + 8;
		public CSteamID m_SteamIDUser;
		public CSteamID m_SteamIDGroup;
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bMember;
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bOfficer;
	}

	// Sent as a reply to GetServerReputation()
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamGameServerCallbacks + 9)]
	public struct GSReputation_t {
		public const int k_iCallback = Constants.k_iSteamGameServerCallbacks + 9;
		public EResult m_eResult;				// Result of the call;
		public uint m_unReputationScore;	// The reputation score for the game server
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bBanned;				// True if the server is banned from the Steam
										// master servers
		
		// The following members are only filled out if m_bBanned is true. They will all
		// be set to zero otherwise. Master server bans are by IP so it is possible to be
		// banned even when the score is good high if there is a bad server on another port.
		// This information can be used to determine which server is bad.
		
		public uint m_unBannedIP;		// The IP of the banned server
		public ushort m_usBannedPort;		// The port of the banned server
		public ulong m_ulBannedGameID;	// The game ID the banned server is serving
		public uint m_unBanExpires;		// Time the ban expires, expressed in the Unix epoch (seconds since 1/1/1970)
	}

	// Sent as a reply to AssociateWithClan()
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamGameServerCallbacks + 10)]
	public struct AssociateWithClanResult_t {
		public const int k_iCallback = Constants.k_iSteamGameServerCallbacks + 10;
		public EResult m_eResult;				// Result of the call;
	}

	// Sent as a reply to ComputeNewPlayerCompatibility()
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamGameServerCallbacks + 11)]
	public struct ComputeNewPlayerCompatibilityResult_t {
		public const int k_iCallback = Constants.k_iSteamGameServerCallbacks + 11;
		public EResult m_eResult;				// Result of the call;
		public int m_cPlayersThatDontLikeCandidate;
		public int m_cPlayersThatCandidateDoesntLike;
		public int m_cClanPlayersThatDontLikeCandidate;
		public CSteamID m_SteamIDCandidate;
	}

	// callbacks
	//-----------------------------------------------------------------------------
	// Purpose: called when the latests stats and achievements have been received
	//			from the server
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	[CallbackIdentity(Constants.k_iSteamGameServerStatsCallbacks)]
	public struct GSStatsReceived_t {
		public const int k_iCallback = Constants.k_iSteamGameServerStatsCallbacks;
		public EResult m_eResult;		// Success / error fetching the stats
		public CSteamID m_steamIDUser;	// The user for whom the stats are retrieved for
	}

	//-----------------------------------------------------------------------------
	// Purpose: result of a request to store the user stats for a game
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	[CallbackIdentity(Constants.k_iSteamGameServerStatsCallbacks + 1)]
	public struct GSStatsStored_t {
		public const int k_iCallback = Constants.k_iSteamGameServerStatsCallbacks + 1;
		public EResult m_eResult;		// success / error
		public CSteamID m_steamIDUser;	// The user for whom the stats were stored
	}

	//-----------------------------------------------------------------------------
	// Purpose: Callback indicating that a user's stats have been unloaded.
	//  Call RequestUserStats again to access stats for this user
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamUserStatsCallbacks + 8)]
	public struct GSStatsUnloaded_t {
		public const int k_iCallback = Constants.k_iSteamUserStatsCallbacks + 8;
		public CSteamID m_steamIDUser;	// User whose stats have been unloaded
	}

	// callbacks
	//-----------------------------------------------------------------------------
	// Purpose: The browser is ready for use
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamHTMLSurfaceCallbacks + 1)]
	public struct HTML_BrowserReady_t {
		public const int k_iCallback = Constants.k_iSteamHTMLSurfaceCallbacks + 1;
		public HHTMLBrowser unBrowserHandle; // this browser is now fully created and ready to navigate to pages
	}

	//-----------------------------------------------------------------------------
	// Purpose: the browser has a pending paint
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamHTMLSurfaceCallbacks + 2)]
	public struct HTML_NeedsPaint_t {
		public const int k_iCallback = Constants.k_iSteamHTMLSurfaceCallbacks + 2;
		public HHTMLBrowser unBrowserHandle; // the browser that needs the paint
		public IntPtr pBGRA; // a pointer to the B8G8R8A8 data for this surface, valid until SteamAPI_RunCallbacks is next called
		public uint unWide; // the total width of the pBGRA texture
		public uint unTall; // the total height of the pBGRA texture
		public uint unUpdateX; // the offset in X for the damage rect for this update
		public uint unUpdateY; // the offset in Y for the damage rect for this update
		public uint unUpdateWide; // the width of the damage rect for this update
		public uint unUpdateTall; // the height of the damage rect for this update
		public uint unScrollX; // the page scroll the browser was at when this texture was rendered
		public uint unScrollY; // the page scroll the browser was at when this texture was rendered
		public float flPageScale; // the page scale factor on this page when rendered
		public uint unPageSerial; // incremented on each new page load, you can use this to reject draws while navigating to new pages
	}

	//-----------------------------------------------------------------------------
	// Purpose: The browser wanted to navigate to a new page
	//   NOTE - you MUST call AllowStartRequest in response to this callback
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamHTMLSurfaceCallbacks + 3)]
	public struct HTML_StartRequest_t {
		public const int k_iCallback = Constants.k_iSteamHTMLSurfaceCallbacks + 3;
		public HHTMLBrowser unBrowserHandle; // the handle of the surface navigating
		public string pchURL; // the url they wish to navigate to
		public string pchTarget; // the html link target type  (i.e _blank, _self, _parent, _top )
		public string pchPostData; // any posted data for the request
		[MarshalAs(UnmanagedType.I1)]
		public bool bIsRedirect; // true if this was a http/html redirect from the last load request
	}

	//-----------------------------------------------------------------------------
	// Purpose: The browser has been requested to close due to user interaction (usually from a javascript window.close() call)
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamHTMLSurfaceCallbacks + 4)]
	public struct HTML_CloseBrowser_t {
		public const int k_iCallback = Constants.k_iSteamHTMLSurfaceCallbacks + 4;
		public HHTMLBrowser unBrowserHandle; // the handle of the surface
	}

	//-----------------------------------------------------------------------------
	// Purpose: the browser is navigating to a new url
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamHTMLSurfaceCallbacks + 5)]
	public struct HTML_URLChanged_t {
		public const int k_iCallback = Constants.k_iSteamHTMLSurfaceCallbacks + 5;
		public HHTMLBrowser unBrowserHandle; // the handle of the surface navigating
		public string pchURL; // the url they wish to navigate to
		public string pchPostData; // any posted data for the request
		[MarshalAs(UnmanagedType.I1)]
		public bool bIsRedirect; // true if this was a http/html redirect from the last load request
		public string pchPageTitle; // the title of the page
		[MarshalAs(UnmanagedType.I1)]
		public bool bNewNavigation; // true if this was from a fresh tab and not a click on an existing page
	}

	//-----------------------------------------------------------------------------
	// Purpose: A page is finished loading
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamHTMLSurfaceCallbacks + 6)]
	public struct HTML_FinishedRequest_t {
		public const int k_iCallback = Constants.k_iSteamHTMLSurfaceCallbacks + 6;
		public HHTMLBrowser unBrowserHandle; // the handle of the surface
		public string pchURL; //
		public string pchPageTitle; //
	}

	//-----------------------------------------------------------------------------
	// Purpose: a request to load this url in a new tab
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamHTMLSurfaceCallbacks + 7)]
	public struct HTML_OpenLinkInNewTab_t {
		public const int k_iCallback = Constants.k_iSteamHTMLSurfaceCallbacks + 7;
		public HHTMLBrowser unBrowserHandle; // the handle of the surface
		public string pchURL; //
	}

	//-----------------------------------------------------------------------------
	// Purpose: the page has a new title now
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamHTMLSurfaceCallbacks + 8)]
	public struct HTML_ChangedTitle_t {
		public const int k_iCallback = Constants.k_iSteamHTMLSurfaceCallbacks + 8;
		public HHTMLBrowser unBrowserHandle; // the handle of the surface
		public string pchTitle; //
	}

	//-----------------------------------------------------------------------------
	// Purpose: results from a search
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamHTMLSurfaceCallbacks + 9)]
	public struct HTML_SearchResults_t {
		public const int k_iCallback = Constants.k_iSteamHTMLSurfaceCallbacks + 9;
		public HHTMLBrowser unBrowserHandle; // the handle of the surface
		public uint unResults; //
		public uint unCurrentMatch; //
	}

	//-----------------------------------------------------------------------------
	// Purpose: page history status changed on the ability to go backwards and forward
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamHTMLSurfaceCallbacks + 10)]
	public struct HTML_CanGoBackAndForward_t {
		public const int k_iCallback = Constants.k_iSteamHTMLSurfaceCallbacks + 10;
		public HHTMLBrowser unBrowserHandle; // the handle of the surface
		[MarshalAs(UnmanagedType.I1)]
		public bool bCanGoBack; //
		[MarshalAs(UnmanagedType.I1)]
		public bool bCanGoForward; //
	}

	//-----------------------------------------------------------------------------
	// Purpose: details on the visibility and size of the horizontal scrollbar
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamHTMLSurfaceCallbacks + 11)]
	public struct HTML_HorizontalScroll_t {
		public const int k_iCallback = Constants.k_iSteamHTMLSurfaceCallbacks + 11;
		public HHTMLBrowser unBrowserHandle; // the handle of the surface
		public uint unScrollMax; //
		public uint unScrollCurrent; //
		public float flPageScale; //
		[MarshalAs(UnmanagedType.I1)]
		public bool bVisible; //
		public uint unPageSize; //
	}

	//-----------------------------------------------------------------------------
	// Purpose: details on the visibility and size of the vertical scrollbar
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamHTMLSurfaceCallbacks + 12)]
	public struct HTML_VerticalScroll_t {
		public const int k_iCallback = Constants.k_iSteamHTMLSurfaceCallbacks + 12;
		public HHTMLBrowser unBrowserHandle; // the handle of the surface
		public uint unScrollMax; //
		public uint unScrollCurrent; //
		public float flPageScale; //
		[MarshalAs(UnmanagedType.I1)]
		public bool bVisible; //
		public uint unPageSize; //
	}

	//-----------------------------------------------------------------------------
	// Purpose: response to GetLinkAtPosition call
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamHTMLSurfaceCallbacks + 13)]
	public struct HTML_LinkAtPosition_t {
		public const int k_iCallback = Constants.k_iSteamHTMLSurfaceCallbacks + 13;
		public HHTMLBrowser unBrowserHandle; // the handle of the surface
		public uint x; // NOTE - Not currently set
		public uint y; // NOTE - Not currently set
		public string pchURL; //
		[MarshalAs(UnmanagedType.I1)]
		public bool bInput; //
		[MarshalAs(UnmanagedType.I1)]
		public bool bLiveLink; //
	}

	//-----------------------------------------------------------------------------
	// Purpose: show a Javascript alert dialog, call JSDialogResponse
	//   when the user dismisses this dialog (or right away to ignore it)
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamHTMLSurfaceCallbacks + 14)]
	public struct HTML_JSAlert_t {
		public const int k_iCallback = Constants.k_iSteamHTMLSurfaceCallbacks + 14;
		public HHTMLBrowser unBrowserHandle; // the handle of the surface
		public string pchMessage; //
	}

	//-----------------------------------------------------------------------------
	// Purpose: show a Javascript confirmation dialog, call JSDialogResponse
	//   when the user dismisses this dialog (or right away to ignore it)
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamHTMLSurfaceCallbacks + 15)]
	public struct HTML_JSConfirm_t {
		public const int k_iCallback = Constants.k_iSteamHTMLSurfaceCallbacks + 15;
		public HHTMLBrowser unBrowserHandle; // the handle of the surface
		public string pchMessage; //
	}

	//-----------------------------------------------------------------------------
	// Purpose: when received show a file open dialog
	//   then call FileLoadDialogResponse with the file(s) the user selected.
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamHTMLSurfaceCallbacks + 16)]
	public struct HTML_FileOpenDialog_t {
		public const int k_iCallback = Constants.k_iSteamHTMLSurfaceCallbacks + 16;
		public HHTMLBrowser unBrowserHandle; // the handle of the surface
		public string pchTitle; //
		public string pchInitialFile; //
	}

	//-----------------------------------------------------------------------------
	// Purpose: a new html window is being created.
	//
	// IMPORTANT NOTE: at this time, the API does not allow you to acknowledge or
	// render the contents of this new window, so the new window is always destroyed
	// immediately. The URL and other parameters of the new window are passed here
	// to give your application the opportunity to call CreateBrowser and set up
	// a new browser in response to the attempted popup, if you wish to do so.
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamHTMLSurfaceCallbacks + 21)]
	public struct HTML_NewWindow_t {
		public const int k_iCallback = Constants.k_iSteamHTMLSurfaceCallbacks + 21;
		public HHTMLBrowser unBrowserHandle; // the handle of the current surface
		public string pchURL; // the page to load
		public uint unX; // the x pos into the page to display the popup
		public uint unY; // the y pos into the page to display the popup
		public uint unWide; // the total width of the pBGRA texture
		public uint unTall; // the total height of the pBGRA texture
		public HHTMLBrowser unNewWindow_BrowserHandle_IGNORE;
	}

	//-----------------------------------------------------------------------------
	// Purpose: change the cursor to display
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamHTMLSurfaceCallbacks + 22)]
	public struct HTML_SetCursor_t {
		public const int k_iCallback = Constants.k_iSteamHTMLSurfaceCallbacks + 22;
		public HHTMLBrowser unBrowserHandle; // the handle of the surface
		public uint eMouseCursor; // the EMouseCursor to display
	}

	//-----------------------------------------------------------------------------
	// Purpose: informational message from the browser
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamHTMLSurfaceCallbacks + 23)]
	public struct HTML_StatusText_t {
		public const int k_iCallback = Constants.k_iSteamHTMLSurfaceCallbacks + 23;
		public HHTMLBrowser unBrowserHandle; // the handle of the surface
		public string pchMsg; // the EMouseCursor to display
	}

	//-----------------------------------------------------------------------------
	// Purpose: show a tooltip
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamHTMLSurfaceCallbacks + 24)]
	public struct HTML_ShowToolTip_t {
		public const int k_iCallback = Constants.k_iSteamHTMLSurfaceCallbacks + 24;
		public HHTMLBrowser unBrowserHandle; // the handle of the surface
		public string pchMsg; // the EMouseCursor to display
	}

	//-----------------------------------------------------------------------------
	// Purpose: update the text of an existing tooltip
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamHTMLSurfaceCallbacks + 25)]
	public struct HTML_UpdateToolTip_t {
		public const int k_iCallback = Constants.k_iSteamHTMLSurfaceCallbacks + 25;
		public HHTMLBrowser unBrowserHandle; // the handle of the surface
		public string pchMsg; // the EMouseCursor to display
	}

	//-----------------------------------------------------------------------------
	// Purpose: hide the tooltip you are showing
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamHTMLSurfaceCallbacks + 26)]
	public struct HTML_HideToolTip_t {
		public const int k_iCallback = Constants.k_iSteamHTMLSurfaceCallbacks + 26;
		public HHTMLBrowser unBrowserHandle; // the handle of the surface
	}

	//-----------------------------------------------------------------------------
	// Purpose: The browser has restarted due to an internal failure, use this new handle value
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamHTMLSurfaceCallbacks + 27)]
	public struct HTML_BrowserRestarted_t {
		public const int k_iCallback = Constants.k_iSteamHTMLSurfaceCallbacks + 27;
		public HHTMLBrowser unBrowserHandle; // this is the new browser handle after the restart
		public HHTMLBrowser unOldBrowserHandle; // the handle for the browser before the restart, if your handle was this then switch to using unBrowserHandle for API calls
	}

	// callbacks
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iClientHTTPCallbacks + 1)]
	public struct HTTPRequestCompleted_t {
		public const int k_iCallback = Constants.k_iClientHTTPCallbacks + 1;
		
		// Handle value for the request that has completed.
		public HTTPRequestHandle m_hRequest;
		
		// Context value that the user defined on the request that this callback is associated with, 0 if
		// no context value was set.
		public ulong m_ulContextValue;
		
		// This will be true if we actually got any sort of response from the server (even an error).
		// It will be false if we failed due to an internal error or client side network failure.
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bRequestSuccessful;
		
		// Will be the HTTP status code value returned by the server, k_EHTTPStatusCode200OK is the normal
		// OK response, if you get something else you probably need to treat it as a failure.
		public EHTTPStatusCode m_eStatusCode;
		
		public uint m_unBodySize; // Same as GetHTTPResponseBodySize()
	}

	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iClientHTTPCallbacks + 2)]
	public struct HTTPRequestHeadersReceived_t {
		public const int k_iCallback = Constants.k_iClientHTTPCallbacks + 2;
		
		// Handle value for the request that has received headers.
		public HTTPRequestHandle m_hRequest;
		
		// Context value that the user defined on the request that this callback is associated with, 0 if
		// no context value was set.
		public ulong m_ulContextValue;
	}

	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iClientHTTPCallbacks + 3)]
	public struct HTTPRequestDataReceived_t {
		public const int k_iCallback = Constants.k_iClientHTTPCallbacks + 3;
		
		// Handle value for the request that has received data.
		public HTTPRequestHandle m_hRequest;
		
		// Context value that the user defined on the request that this callback is associated with, 0 if
		// no context value was set.
		public ulong m_ulContextValue;
		
		
		// Offset to provide to GetHTTPStreamingResponseBodyData to get this chunk of data
		public uint m_cOffset;
		
		// Size to provide to GetHTTPStreamingResponseBodyData to get this chunk of data
		public uint m_cBytesReceived;
	}

	// SteamInventoryResultReady_t callbacks are fired whenever asynchronous
	// results transition from "Pending" to "OK" or an error state. There will
	// always be exactly one callback per handle.
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iClientInventoryCallbacks + 0)]
	public struct SteamInventoryResultReady_t {
		public const int k_iCallback = Constants.k_iClientInventoryCallbacks + 0;
		public SteamInventoryResult_t m_handle;
		public EResult m_result;
	}

	// SteamInventoryFullUpdate_t callbacks are triggered when GetAllItems
	// successfully returns a result which is newer / fresher than the last
	// known result. (It will not trigger if the inventory hasn't changed,
	// or if results from two overlapping calls are reversed in flight and
	// the earlier result is already known to be stale/out-of-date.)
	// The normal ResultReady callback will still be triggered immediately
	// afterwards; this is an additional notification for your convenience.
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iClientInventoryCallbacks + 1)]
	public struct SteamInventoryFullUpdate_t {
		public const int k_iCallback = Constants.k_iClientInventoryCallbacks + 1;
		public SteamInventoryResult_t m_handle;
	}

	// A SteamInventoryDefinitionUpdate_t callback is triggered whenever
	// item definitions have been updated, which could be in response to
	// LoadItemDefinitions() or any other async request which required
	// a definition update in order to process results from the server.
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value, Size = 1)]
	[CallbackIdentity(Constants.k_iClientInventoryCallbacks + 2)]
	public struct SteamInventoryDefinitionUpdate_t {
		public const int k_iCallback = Constants.k_iClientInventoryCallbacks + 2;
	}

	// Returned
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iClientInventoryCallbacks + 3)]
	public struct SteamInventoryEligiblePromoItemDefIDs_t {
		public const int k_iCallback = Constants.k_iClientInventoryCallbacks + 3;
		public EResult m_result;
		public CSteamID m_steamID;
		public int m_numEligiblePromoItemDefs;
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bCachedData;	// indicates that the data was retrieved from the cache and not the server
	}

	// Triggered from StartPurchase call
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iClientInventoryCallbacks + 4)]
	public struct SteamInventoryStartPurchaseResult_t {
		public const int k_iCallback = Constants.k_iClientInventoryCallbacks + 4;
		public EResult m_result;
		public ulong m_ulOrderID;
		public ulong m_ulTransID;
	}

	// Triggered from RequestPrices
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iClientInventoryCallbacks + 5)]
	public struct SteamInventoryRequestPricesResult_t {
		public const int k_iCallback = Constants.k_iClientInventoryCallbacks + 5;
		public EResult m_result;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
		public string m_rgchCurrency;
	}

	//-----------------------------------------------------------------------------
	// Callbacks for ISteamMatchmaking (which go through the regular Steam callback registration system)
	//-----------------------------------------------------------------------------
	// Purpose: a server was added/removed from the favorites list, you should refresh now
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamMatchmakingCallbacks + 2)]
	public struct FavoritesListChanged_t {
		public const int k_iCallback = Constants.k_iSteamMatchmakingCallbacks + 2;
		public uint m_nIP; // an IP of 0 means reload the whole list, any other value means just one server
		public uint m_nQueryPort;
		public uint m_nConnPort;
		public uint m_nAppID;
		public uint m_nFlags;
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bAdd; // true if this is adding the entry, otherwise it is a remove
		public AccountID_t m_unAccountId;
	}

	//-----------------------------------------------------------------------------
	// Purpose: Someone has invited you to join a Lobby
	//			normally you don't need to do anything with this, since
	//			the Steam UI will also display a '<user> has invited you to the lobby, join?' dialog
	//
	//			if the user outside a game chooses to join, your game will be launched with the parameter "+connect_lobby <64-bit lobby id>",
	//			or with the callback GameLobbyJoinRequested_t if they're already in-game
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamMatchmakingCallbacks + 3)]
	public struct LobbyInvite_t {
		public const int k_iCallback = Constants.k_iSteamMatchmakingCallbacks + 3;
		
		public ulong m_ulSteamIDUser;		// Steam ID of the person making the invite
		public ulong m_ulSteamIDLobby;	// Steam ID of the Lobby
		public ulong m_ulGameID;			// GameID of the Lobby
	}

	//-----------------------------------------------------------------------------
	// Purpose: Sent on entering a lobby, or on failing to enter
	//			m_EChatRoomEnterResponse will be set to k_EChatRoomEnterResponseSuccess on success,
	//			or a higher value on failure (see enum EChatRoomEnterResponse)
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamMatchmakingCallbacks + 4)]
	public struct LobbyEnter_t {
		public const int k_iCallback = Constants.k_iSteamMatchmakingCallbacks + 4;
		
		public ulong m_ulSteamIDLobby;							// SteamID of the Lobby you have entered
		public uint m_rgfChatPermissions;						// Permissions of the current user
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bLocked;										// If true, then only invited users may join
		public uint m_EChatRoomEnterResponse;	// EChatRoomEnterResponse
	}

	//-----------------------------------------------------------------------------
	// Purpose: The lobby metadata has changed
	//			if m_ulSteamIDMember is the steamID of a lobby member, use GetLobbyMemberData() to access per-user details
	//			if m_ulSteamIDMember == m_ulSteamIDLobby, use GetLobbyData() to access lobby metadata
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamMatchmakingCallbacks + 5)]
	public struct LobbyDataUpdate_t {
		public const int k_iCallback = Constants.k_iSteamMatchmakingCallbacks + 5;
		
		public ulong m_ulSteamIDLobby;		// steamID of the Lobby
		public ulong m_ulSteamIDMember;		// steamID of the member whose data changed, or the room itself
		public byte m_bSuccess;				// true if we lobby data was successfully changed;
										// will only be false if RequestLobbyData() was called on a lobby that no longer exists
	}

	//-----------------------------------------------------------------------------
	// Purpose: The lobby chat room state has changed
	//			this is usually sent when a user has joined or left the lobby
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamMatchmakingCallbacks + 6)]
	public struct LobbyChatUpdate_t {
		public const int k_iCallback = Constants.k_iSteamMatchmakingCallbacks + 6;
		
		public ulong m_ulSteamIDLobby;			// Lobby ID
		public ulong m_ulSteamIDUserChanged;		// user who's status in the lobby just changed - can be recipient
		public ulong m_ulSteamIDMakingChange;		// Chat member who made the change (different from SteamIDUserChange if kicking, muting, etc.)
											// for example, if one user kicks another from the lobby, this will be set to the id of the user who initiated the kick
		public uint m_rgfChatMemberStateChange;	// bitfield of EChatMemberStateChange values
	}

	//-----------------------------------------------------------------------------
	// Purpose: A chat message for this lobby has been sent
	//			use GetLobbyChatEntry( m_iChatID ) to retrieve the contents of this message
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamMatchmakingCallbacks + 7)]
	public struct LobbyChatMsg_t {
		public const int k_iCallback = Constants.k_iSteamMatchmakingCallbacks + 7;
		
		public ulong m_ulSteamIDLobby;			// the lobby id this is in
		public ulong m_ulSteamIDUser;			// steamID of the user who has sent this message
		public byte m_eChatEntryType;			// type of message
		public uint m_iChatID;				// index of the chat entry to lookup
	}

	//-----------------------------------------------------------------------------
	// Purpose: A game created a game for all the members of the lobby to join,
	//			as triggered by a SetLobbyGameServer()
	//			it's up to the individual clients to take action on this; the usual
	//			game behavior is to leave the lobby and connect to the specified game server
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamMatchmakingCallbacks + 9)]
	public struct LobbyGameCreated_t {
		public const int k_iCallback = Constants.k_iSteamMatchmakingCallbacks + 9;
		
		public ulong m_ulSteamIDLobby;		// the lobby we were in
		public ulong m_ulSteamIDGameServer;	// the new game server that has been created or found for the lobby members
		public uint m_unIP;					// IP & Port of the game server (if any)
		public ushort m_usPort;
	}

	//-----------------------------------------------------------------------------
	// Purpose: Number of matching lobbies found
	//			iterate the returned lobbies with GetLobbyByIndex(), from values 0 to m_nLobbiesMatching-1
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamMatchmakingCallbacks + 10)]
	public struct LobbyMatchList_t {
		public const int k_iCallback = Constants.k_iSteamMatchmakingCallbacks + 10;
		public uint m_nLobbiesMatching;		// Number of lobbies that matched search criteria and we have SteamIDs for
	}

	//-----------------------------------------------------------------------------
	// Purpose: posted if a user is forcefully removed from a lobby
	//			can occur if a user loses connection to Steam
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamMatchmakingCallbacks + 12)]
	public struct LobbyKicked_t {
		public const int k_iCallback = Constants.k_iSteamMatchmakingCallbacks + 12;
		public ulong m_ulSteamIDLobby;			// Lobby
		public ulong m_ulSteamIDAdmin;			// User who kicked you - possibly the ID of the lobby itself
		public byte m_bKickedDueToDisconnect;		// true if you were kicked from the lobby due to the user losing connection to Steam (currently always true)
	}

	//-----------------------------------------------------------------------------
	// Purpose: Result of our request to create a Lobby
	//			m_eResult == k_EResultOK on success
	//			at this point, the lobby has been joined and is ready for use
	//			a LobbyEnter_t callback will also be received (since the local user is joining their own lobby)
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamMatchmakingCallbacks + 13)]
	public struct LobbyCreated_t {
		public const int k_iCallback = Constants.k_iSteamMatchmakingCallbacks + 13;
		
		public EResult m_eResult;		// k_EResultOK - the lobby was successfully created
								// k_EResultNoConnection - your Steam client doesn't have a connection to the back-end
								// k_EResultTimeout - you the message to the Steam servers, but it didn't respond
								// k_EResultFail - the server responded, but with an unknown internal error
								// k_EResultAccessDenied - your game isn't set to allow lobbies, or your client does haven't rights to play the game
								// k_EResultLimitExceeded - your game client has created too many lobbies
		
		public ulong m_ulSteamIDLobby;		// chat room, zero if failed
	}

	//-----------------------------------------------------------------------------
	// Purpose: Result of our request to create a Lobby
	//			m_eResult == k_EResultOK on success
	//			at this point, the lobby has been joined and is ready for use
	//			a LobbyEnter_t callback will also be received (since the local user is joining their own lobby)
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamMatchmakingCallbacks + 16)]
	public struct FavoritesListAccountsUpdated_t {
		public const int k_iCallback = Constants.k_iSteamMatchmakingCallbacks + 16;
		
		public EResult m_eResult;
	}

	//-----------------------------------------------------------------------------
	// Callbacks for ISteamGameSearch (which go through the regular Steam callback registration system)
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamGameSearchCallbacks + 1)]
	public struct SearchForGameProgressCallback_t {
		public const int k_iCallback = Constants.k_iSteamGameSearchCallbacks + 1;
		
		public ulong m_ullSearchID;	// all future callbacks referencing this search will include this Search ID
		
		public EResult m_eResult; // if search has started this result will be k_EResultOK, any other value indicates search has failed to start or has terminated
		public CSteamID m_lobbyID; // lobby ID if lobby search, invalid steamID otherwise
		public CSteamID m_steamIDEndedSearch; // if search was terminated, steamID that terminated search
		
		public int m_nSecondsRemainingEstimate;
		public int m_cPlayersSearching;
	}

	// notification to all players searching that a game has been found
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamGameSearchCallbacks + 2)]
	public struct SearchForGameResultCallback_t {
		public const int k_iCallback = Constants.k_iSteamGameSearchCallbacks + 2;
		
		public ulong m_ullSearchID;
		
		public EResult m_eResult; // if game/host was lost this will be an error value
		
		// if m_bGameFound is true the following are non-zero
		public int m_nCountPlayersInGame;
		public int m_nCountAcceptedGame;
		// if m_steamIDHost is valid the host has started the game
		public CSteamID m_steamIDHost;
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bFinalCallback;
	}

	//-----------------------------------------------------------------------------
	// ISteamGameSearch : Game Host API callbacks
	// callback from RequestPlayersForGame when the matchmaking service has started or ended search
	// callback will also follow a call from CancelRequestPlayersForGame - m_bSearchInProgress will be false
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamGameSearchCallbacks + 11)]
	public struct RequestPlayersForGameProgressCallback_t {
		public const int k_iCallback = Constants.k_iSteamGameSearchCallbacks + 11;
		
		public EResult m_eResult;		// m_ullSearchID will be non-zero if this is k_EResultOK
		public ulong m_ullSearchID; 	// all future callbacks referencing this search will include this Search ID
	}

	// callback from RequestPlayersForGame
	// one of these will be sent per player
	// followed by additional callbacks when players accept or decline the game
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamGameSearchCallbacks + 12)]
	public struct RequestPlayersForGameResultCallback_t {
		public const int k_iCallback = Constants.k_iSteamGameSearchCallbacks + 12;
		
		public EResult m_eResult;		// m_ullSearchID will be non-zero if this is k_EResultOK
		public ulong m_ullSearchID;
		
		public CSteamID m_SteamIDPlayerFound; // player steamID
		public CSteamID m_SteamIDLobby;	// if the player is in a lobby, the lobby ID
		public PlayerAcceptState_t m_ePlayerAcceptState;
		public int m_nPlayerIndex;
		public int m_nTotalPlayersFound;		// expect this many callbacks at minimum
		public int m_nTotalPlayersAcceptedGame;
		public int m_nSuggestedTeamIndex;
		public ulong m_ullUniqueGameID;
	}

	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamGameSearchCallbacks + 13)]
	public struct RequestPlayersForGameFinalResultCallback_t {
		public const int k_iCallback = Constants.k_iSteamGameSearchCallbacks + 13;
		
		public EResult m_eResult;
		public ulong m_ullSearchID;
		public ulong m_ullUniqueGameID;
	}

	// this callback confirms that results were received by the matchmaking service for this player
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamGameSearchCallbacks + 14)]
	public struct SubmitPlayerResultResultCallback_t {
		public const int k_iCallback = Constants.k_iSteamGameSearchCallbacks + 14;
		
		public EResult m_eResult;
		public ulong ullUniqueGameID;
		public CSteamID steamIDPlayer;
	}

	// this callback confirms that the game is recorded as complete on the matchmaking service
	// the next call to RequestPlayersForGame will generate a new unique game ID
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamGameSearchCallbacks + 15)]
	public struct EndGameResultCallback_t {
		public const int k_iCallback = Constants.k_iSteamGameSearchCallbacks + 15;
		
		public EResult m_eResult;
		public ulong ullUniqueGameID;
	}

	// Steam has responded to the user request to join a party via the given Beacon ID.
	// If successful, the connect string contains game-specific instructions to connect
	// to the game with that party.
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamPartiesCallbacks + 1)]
	public struct JoinPartyCallback_t {
		public const int k_iCallback = Constants.k_iSteamPartiesCallbacks + 1;
		
		public EResult m_eResult;
		public PartyBeaconID_t m_ulBeaconID;
		public CSteamID m_SteamIDBeaconOwner;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
		public string m_rgchConnectString;
	}

	// Response to CreateBeacon request. If successful, the beacon ID is provided.
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamPartiesCallbacks + 2)]
	public struct CreateBeaconCallback_t {
		public const int k_iCallback = Constants.k_iSteamPartiesCallbacks + 2;
		
		public EResult m_eResult;
		public PartyBeaconID_t m_ulBeaconID;
	}

	// Someone has used the beacon to join your party - they are in-flight now
	// and we've reserved one of the open slots for them.
	// You should confirm when they join your party by calling OnReservationCompleted().
	// Otherwise, Steam may timeout their reservation eventually.
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamPartiesCallbacks + 3)]
	public struct ReservationNotificationCallback_t {
		public const int k_iCallback = Constants.k_iSteamPartiesCallbacks + 3;
		
		public PartyBeaconID_t m_ulBeaconID;
		public CSteamID m_steamIDJoiner;
	}

	// Response to ChangeNumOpenSlots call
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamPartiesCallbacks + 4)]
	public struct ChangeNumOpenSlotsCallback_t {
		public const int k_iCallback = Constants.k_iSteamPartiesCallbacks + 4;
		
		public EResult m_eResult;
	}

	// The list of possible Party beacon locations has changed
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value, Size = 1)]
	[CallbackIdentity(Constants.k_iSteamPartiesCallbacks + 5)]
	public struct AvailableBeaconLocationsUpdated_t {
		public const int k_iCallback = Constants.k_iSteamPartiesCallbacks + 5;
	}

	// The list of active beacons may have changed
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value, Size = 1)]
	[CallbackIdentity(Constants.k_iSteamPartiesCallbacks + 6)]
	public struct ActiveBeaconsUpdated_t {
		public const int k_iCallback = Constants.k_iSteamPartiesCallbacks + 6;
	}

	// callbacks
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value, Size = 1)]
	[CallbackIdentity(Constants.k_iSteamMusicCallbacks + 1)]
	public struct PlaybackStatusHasChanged_t {
		public const int k_iCallback = Constants.k_iSteamMusicCallbacks + 1;
	}

	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamMusicCallbacks + 2)]
	public struct VolumeHasChanged_t {
		public const int k_iCallback = Constants.k_iSteamMusicCallbacks + 2;
		public float m_flNewVolume;
	}

	// callbacks
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value, Size = 1)]
	[CallbackIdentity(Constants.k_iSteamMusicRemoteCallbacks + 1)]
	public struct MusicPlayerRemoteWillActivate_t {
		public const int k_iCallback = Constants.k_iSteamMusicRemoteCallbacks + 1;
	}

	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value, Size = 1)]
	[CallbackIdentity(Constants.k_iSteamMusicRemoteCallbacks + 2)]
	public struct MusicPlayerRemoteWillDeactivate_t {
		public const int k_iCallback = Constants.k_iSteamMusicRemoteCallbacks + 2;
	}

	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value, Size = 1)]
	[CallbackIdentity(Constants.k_iSteamMusicRemoteCallbacks + 3)]
	public struct MusicPlayerRemoteToFront_t {
		public const int k_iCallback = Constants.k_iSteamMusicRemoteCallbacks + 3;
	}

	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value, Size = 1)]
	[CallbackIdentity(Constants.k_iSteamMusicRemoteCallbacks + 4)]
	public struct MusicPlayerWillQuit_t {
		public const int k_iCallback = Constants.k_iSteamMusicRemoteCallbacks + 4;
	}

	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value, Size = 1)]
	[CallbackIdentity(Constants.k_iSteamMusicRemoteCallbacks + 5)]
	public struct MusicPlayerWantsPlay_t {
		public const int k_iCallback = Constants.k_iSteamMusicRemoteCallbacks + 5;
	}

	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value, Size = 1)]
	[CallbackIdentity(Constants.k_iSteamMusicRemoteCallbacks + 6)]
	public struct MusicPlayerWantsPause_t {
		public const int k_iCallback = Constants.k_iSteamMusicRemoteCallbacks + 6;
	}

	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value, Size = 1)]
	[CallbackIdentity(Constants.k_iSteamMusicRemoteCallbacks + 7)]
	public struct MusicPlayerWantsPlayPrevious_t {
		public const int k_iCallback = Constants.k_iSteamMusicRemoteCallbacks + 7;
	}

	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value, Size = 1)]
	[CallbackIdentity(Constants.k_iSteamMusicRemoteCallbacks + 8)]
	public struct MusicPlayerWantsPlayNext_t {
		public const int k_iCallback = Constants.k_iSteamMusicRemoteCallbacks + 8;
	}

	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamMusicRemoteCallbacks + 9)]
	public struct MusicPlayerWantsShuffled_t {
		public const int k_iCallback = Constants.k_iSteamMusicRemoteCallbacks + 9;
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bShuffled;
	}

	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamMusicRemoteCallbacks + 10)]
	public struct MusicPlayerWantsLooped_t {
		public const int k_iCallback = Constants.k_iSteamMusicRemoteCallbacks + 10;
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bLooped;
	}

	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamMusicCallbacks + 11)]
	public struct MusicPlayerWantsVolume_t {
		public const int k_iCallback = Constants.k_iSteamMusicCallbacks + 11;
		public float m_flNewVolume;
	}

	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamMusicCallbacks + 12)]
	public struct MusicPlayerSelectsQueueEntry_t {
		public const int k_iCallback = Constants.k_iSteamMusicCallbacks + 12;
		public int nID;
	}

	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamMusicCallbacks + 13)]
	public struct MusicPlayerSelectsPlaylistEntry_t {
		public const int k_iCallback = Constants.k_iSteamMusicCallbacks + 13;
		public int nID;
	}

	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamMusicRemoteCallbacks + 14)]
	public struct MusicPlayerWantsPlayingRepeatStatus_t {
		public const int k_iCallback = Constants.k_iSteamMusicRemoteCallbacks + 14;
		public int m_nPlayingRepeatStatus;
	}

	// callbacks
	// callback notification - a user wants to talk to us over the P2P channel via the SendP2PPacket() API
	// in response, a call to AcceptP2PPacketsFromUser() needs to be made, if you want to talk with them
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamNetworkingCallbacks + 2)]
	public struct P2PSessionRequest_t {
		public const int k_iCallback = Constants.k_iSteamNetworkingCallbacks + 2;
		public CSteamID m_steamIDRemote;			// user who wants to talk to us
	}

	// callback notification - packets can't get through to the specified user via the SendP2PPacket() API
	// all packets queued packets unsent at this point will be dropped
	// further attempts to send will retry making the connection (but will be dropped if we fail again)
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	[CallbackIdentity(Constants.k_iSteamNetworkingCallbacks + 3)]
	public struct P2PSessionConnectFail_t {
		public const int k_iCallback = Constants.k_iSteamNetworkingCallbacks + 3;
		public CSteamID m_steamIDRemote;			// user we were sending packets to
		public byte m_eP2PSessionError;			// EP2PSessionError indicating why we're having trouble
	}

	// callback notification - status of a socket has changed
	// used as part of the CreateListenSocket() / CreateP2PConnectionSocket()
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	[CallbackIdentity(Constants.k_iSteamNetworkingCallbacks + 1)]
	public struct SocketStatusCallback_t {
		public const int k_iCallback = Constants.k_iSteamNetworkingCallbacks + 1;
		public SNetSocket_t m_hSocket;				// the socket used to send/receive data to the remote host
		public SNetListenSocket_t m_hListenSocket;	// this is the server socket that we were listening on; NULL if this was an outgoing connection
		public CSteamID m_steamIDRemote;			// remote steamID we have connected to, if it has one
		public int m_eSNetSocketState;				// socket state, ESNetSocketState
	}

	//-----------------------------------------------------------------------------
	// Purpose: Callback for querying UGC
	//-----------------------------------------------------------------------------
	[CallbackIdentity(Constants.k_ISteamParentalSettingsCallbacks + 1)]
	public struct SteamParentalSettingsChanged_t {
		public const int k_iCallback = Constants.k_ISteamParentalSettingsCallbacks + 1;
	}

	// callbacks
	//-----------------------------------------------------------------------------
	// Purpose: sent when the local file cache is fully synced with the server for an app
	//          That means that an application can be started and has all latest files
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iClientRemoteStorageCallbacks + 1)]
	public struct RemoteStorageAppSyncedClient_t {
		public const int k_iCallback = Constants.k_iClientRemoteStorageCallbacks + 1;
		public AppId_t m_nAppID;
		public EResult m_eResult;
		public int m_unNumDownloads;
	}

	//-----------------------------------------------------------------------------
	// Purpose: sent when the server is fully synced with the local file cache for an app
	//          That means that we can shutdown Steam and our data is stored on the server
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iClientRemoteStorageCallbacks + 2)]
	public struct RemoteStorageAppSyncedServer_t {
		public const int k_iCallback = Constants.k_iClientRemoteStorageCallbacks + 2;
		public AppId_t m_nAppID;
		public EResult m_eResult;
		public int m_unNumUploads;
	}

	//-----------------------------------------------------------------------------
	// Purpose: Status of up and downloads during a sync session
	//
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iClientRemoteStorageCallbacks + 3)]
	public struct RemoteStorageAppSyncProgress_t {
		public const int k_iCallback = Constants.k_iClientRemoteStorageCallbacks + 3;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.k_cchFilenameMax)]
		public string m_rgchCurrentFile;				// Current file being transferred
		public AppId_t m_nAppID;							// App this info relates to
		public uint m_uBytesTransferredThisChunk;		// Bytes transferred this chunk
		public double m_dAppPercentComplete;				// Percent complete that this app's transfers are
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bUploading;							// if false, downloading
	}

	//
	// IMPORTANT! k_iClientRemoteStorageCallbacks + 4 is used, see iclientremotestorage.h
	//
	//-----------------------------------------------------------------------------
	// Purpose: Sent after we've determined the list of files that are out of sync
	//          with the server.
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iClientRemoteStorageCallbacks + 5)]
	public struct RemoteStorageAppSyncStatusCheck_t {
		public const int k_iCallback = Constants.k_iClientRemoteStorageCallbacks + 5;
		public AppId_t m_nAppID;
		public EResult m_eResult;
	}

	//-----------------------------------------------------------------------------
	// Purpose: The result of a call to FileShare()
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iClientRemoteStorageCallbacks + 7)]
	public struct RemoteStorageFileShareResult_t {
		public const int k_iCallback = Constants.k_iClientRemoteStorageCallbacks + 7;
		public EResult m_eResult;			// The result of the operation
		public UGCHandle_t m_hFile;		// The handle that can be shared with users and features
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.k_cchFilenameMax)]
		public string m_rgchFilename; // The name of the file that was shared
	}

	// k_iClientRemoteStorageCallbacks + 8 is deprecated! Do not reuse
	//-----------------------------------------------------------------------------
	// Purpose: The result of a call to PublishFile()
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iClientRemoteStorageCallbacks + 9)]
	public struct RemoteStoragePublishFileResult_t {
		public const int k_iCallback = Constants.k_iClientRemoteStorageCallbacks + 9;
		public EResult m_eResult;				// The result of the operation.
		public PublishedFileId_t m_nPublishedFileId;
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bUserNeedsToAcceptWorkshopLegalAgreement;
	}

	//-----------------------------------------------------------------------------
	// Purpose: The result of a call to DeletePublishedFile()
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iClientRemoteStorageCallbacks + 11)]
	public struct RemoteStorageDeletePublishedFileResult_t {
		public const int k_iCallback = Constants.k_iClientRemoteStorageCallbacks + 11;
		public EResult m_eResult;				// The result of the operation.
		public PublishedFileId_t m_nPublishedFileId;
	}

	//-----------------------------------------------------------------------------
	// Purpose: The result of a call to EnumerateUserPublishedFiles()
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iClientRemoteStorageCallbacks + 12)]
	public struct RemoteStorageEnumerateUserPublishedFilesResult_t {
		public const int k_iCallback = Constants.k_iClientRemoteStorageCallbacks + 12;
		public EResult m_eResult;				// The result of the operation.
		public int m_nResultsReturned;
		public int m_nTotalResultCount;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = Constants.k_unEnumeratePublishedFilesMaxResults)]
		public PublishedFileId_t[] m_rgPublishedFileId;
	}

	//-----------------------------------------------------------------------------
	// Purpose: The result of a call to SubscribePublishedFile()
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iClientRemoteStorageCallbacks + 13)]
	public struct RemoteStorageSubscribePublishedFileResult_t {
		public const int k_iCallback = Constants.k_iClientRemoteStorageCallbacks + 13;
		public EResult m_eResult;				// The result of the operation.
		public PublishedFileId_t m_nPublishedFileId;
	}

	//-----------------------------------------------------------------------------
	// Purpose: The result of a call to EnumerateSubscribePublishedFiles()
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iClientRemoteStorageCallbacks + 14)]
	public struct RemoteStorageEnumerateUserSubscribedFilesResult_t {
		public const int k_iCallback = Constants.k_iClientRemoteStorageCallbacks + 14;
		public EResult m_eResult;				// The result of the operation.
		public int m_nResultsReturned;
		public int m_nTotalResultCount;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = Constants.k_unEnumeratePublishedFilesMaxResults)]
		public PublishedFileId_t[] m_rgPublishedFileId;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = Constants.k_unEnumeratePublishedFilesMaxResults)]
		public uint[] m_rgRTimeSubscribed;
	}

	//-----------------------------------------------------------------------------
	// Purpose: The result of a call to UnsubscribePublishedFile()
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iClientRemoteStorageCallbacks + 15)]
	public struct RemoteStorageUnsubscribePublishedFileResult_t {
		public const int k_iCallback = Constants.k_iClientRemoteStorageCallbacks + 15;
		public EResult m_eResult;				// The result of the operation.
		public PublishedFileId_t m_nPublishedFileId;
	}

	//-----------------------------------------------------------------------------
	// Purpose: The result of a call to CommitPublishedFileUpdate()
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iClientRemoteStorageCallbacks + 16)]
	public struct RemoteStorageUpdatePublishedFileResult_t {
		public const int k_iCallback = Constants.k_iClientRemoteStorageCallbacks + 16;
		public EResult m_eResult;				// The result of the operation.
		public PublishedFileId_t m_nPublishedFileId;
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bUserNeedsToAcceptWorkshopLegalAgreement;
	}

	//-----------------------------------------------------------------------------
	// Purpose: The result of a call to UGCDownload()
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iClientRemoteStorageCallbacks + 17)]
	public struct RemoteStorageDownloadUGCResult_t {
		public const int k_iCallback = Constants.k_iClientRemoteStorageCallbacks + 17;
		public EResult m_eResult;				// The result of the operation.
		public UGCHandle_t m_hFile;			// The handle to the file that was attempted to be downloaded.
		public AppId_t m_nAppID;				// ID of the app that created this file.
		public int m_nSizeInBytes;			// The size of the file that was downloaded, in bytes.
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.k_cchFilenameMax)]
		public string m_pchFileName;		// The name of the file that was downloaded.
		public ulong m_ulSteamIDOwner;		// Steam ID of the user who created this content.
	}

	//-----------------------------------------------------------------------------
	// Purpose: The result of a call to GetPublishedFileDetails()
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iClientRemoteStorageCallbacks + 18)]
	public struct RemoteStorageGetPublishedFileDetailsResult_t {
		public const int k_iCallback = Constants.k_iClientRemoteStorageCallbacks + 18;
		public EResult m_eResult;				// The result of the operation.
		public PublishedFileId_t m_nPublishedFileId;
		public AppId_t m_nCreatorAppID;		// ID of the app that created this file.
		public AppId_t m_nConsumerAppID;		// ID of the app that will consume this file.
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.k_cchPublishedDocumentTitleMax)]
		public string m_rgchTitle;		// title of document
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.k_cchPublishedDocumentDescriptionMax)]
		public string m_rgchDescription;	// description of document
		public UGCHandle_t m_hFile;			// The handle of the primary file
		public UGCHandle_t m_hPreviewFile;		// The handle of the preview file
		public ulong m_ulSteamIDOwner;		// Steam ID of the user who created this content.
		public uint m_rtimeCreated;			// time when the published file was created
		public uint m_rtimeUpdated;			// time when the published file was last updated
		public ERemoteStoragePublishedFileVisibility m_eVisibility;
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bBanned;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.k_cchTagListMax)]
		public string m_rgchTags;	// comma separated list of all tags associated with this file
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bTagsTruncated;			// whether the list of tags was too long to be returned in the provided buffer
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.k_cchFilenameMax)]
		public string m_pchFileName;		// The name of the primary file
		public int m_nFileSize;				// Size of the primary file
		public int m_nPreviewFileSize;		// Size of the preview file
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.k_cchPublishedFileURLMax)]
		public string m_rgchURL;	// URL (for a video or a website)
		public EWorkshopFileType m_eFileType;	// Type of the file
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bAcceptedForUse;			// developer has specifically flagged this item as accepted in the Workshop
	}

	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iClientRemoteStorageCallbacks + 19)]
	public struct RemoteStorageEnumerateWorkshopFilesResult_t {
		public const int k_iCallback = Constants.k_iClientRemoteStorageCallbacks + 19;
		public EResult m_eResult;
		public int m_nResultsReturned;
		public int m_nTotalResultCount;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = Constants.k_unEnumeratePublishedFilesMaxResults)]
		public PublishedFileId_t[] m_rgPublishedFileId;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = Constants.k_unEnumeratePublishedFilesMaxResults)]
		public float[] m_rgScore;
		public AppId_t m_nAppId;
		public uint m_unStartIndex;
	}

	//-----------------------------------------------------------------------------
	// Purpose: The result of GetPublishedItemVoteDetails
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iClientRemoteStorageCallbacks + 20)]
	public struct RemoteStorageGetPublishedItemVoteDetailsResult_t {
		public const int k_iCallback = Constants.k_iClientRemoteStorageCallbacks + 20;
		public EResult m_eResult;
		public PublishedFileId_t m_unPublishedFileId;
		public int m_nVotesFor;
		public int m_nVotesAgainst;
		public int m_nReports;
		public float m_fScore;
	}

	//-----------------------------------------------------------------------------
	// Purpose: User subscribed to a file for the app (from within the app or on the web)
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iClientRemoteStorageCallbacks + 21)]
	public struct RemoteStoragePublishedFileSubscribed_t {
		public const int k_iCallback = Constants.k_iClientRemoteStorageCallbacks + 21;
		public PublishedFileId_t m_nPublishedFileId;	// The published file id
		public AppId_t m_nAppID;						// ID of the app that will consume this file.
	}

	//-----------------------------------------------------------------------------
	// Purpose: User unsubscribed from a file for the app (from within the app or on the web)
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iClientRemoteStorageCallbacks + 22)]
	public struct RemoteStoragePublishedFileUnsubscribed_t {
		public const int k_iCallback = Constants.k_iClientRemoteStorageCallbacks + 22;
		public PublishedFileId_t m_nPublishedFileId;	// The published file id
		public AppId_t m_nAppID;						// ID of the app that will consume this file.
	}

	//-----------------------------------------------------------------------------
	// Purpose: Published file that a user owns was deleted (from within the app or the web)
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iClientRemoteStorageCallbacks + 23)]
	public struct RemoteStoragePublishedFileDeleted_t {
		public const int k_iCallback = Constants.k_iClientRemoteStorageCallbacks + 23;
		public PublishedFileId_t m_nPublishedFileId;	// The published file id
		public AppId_t m_nAppID;						// ID of the app that will consume this file.
	}

	//-----------------------------------------------------------------------------
	// Purpose: The result of a call to UpdateUserPublishedItemVote()
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iClientRemoteStorageCallbacks + 24)]
	public struct RemoteStorageUpdateUserPublishedItemVoteResult_t {
		public const int k_iCallback = Constants.k_iClientRemoteStorageCallbacks + 24;
		public EResult m_eResult;				// The result of the operation.
		public PublishedFileId_t m_nPublishedFileId;	// The published file id
	}

	//-----------------------------------------------------------------------------
	// Purpose: The result of a call to GetUserPublishedItemVoteDetails()
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iClientRemoteStorageCallbacks + 25)]
	public struct RemoteStorageUserVoteDetails_t {
		public const int k_iCallback = Constants.k_iClientRemoteStorageCallbacks + 25;
		public EResult m_eResult;				// The result of the operation.
		public PublishedFileId_t m_nPublishedFileId;	// The published file id
		public EWorkshopVote m_eVote;			// what the user voted
	}

	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iClientRemoteStorageCallbacks + 26)]
	public struct RemoteStorageEnumerateUserSharedWorkshopFilesResult_t {
		public const int k_iCallback = Constants.k_iClientRemoteStorageCallbacks + 26;
		public EResult m_eResult;				// The result of the operation.
		public int m_nResultsReturned;
		public int m_nTotalResultCount;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = Constants.k_unEnumeratePublishedFilesMaxResults)]
		public PublishedFileId_t[] m_rgPublishedFileId;
	}

	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iClientRemoteStorageCallbacks + 27)]
	public struct RemoteStorageSetUserPublishedFileActionResult_t {
		public const int k_iCallback = Constants.k_iClientRemoteStorageCallbacks + 27;
		public EResult m_eResult;				// The result of the operation.
		public PublishedFileId_t m_nPublishedFileId;	// The published file id
		public EWorkshopFileAction m_eAction;	// the action that was attempted
	}

	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iClientRemoteStorageCallbacks + 28)]
	public struct RemoteStorageEnumeratePublishedFilesByUserActionResult_t {
		public const int k_iCallback = Constants.k_iClientRemoteStorageCallbacks + 28;
		public EResult m_eResult;				// The result of the operation.
		public EWorkshopFileAction m_eAction;	// the action that was filtered on
		public int m_nResultsReturned;
		public int m_nTotalResultCount;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = Constants.k_unEnumeratePublishedFilesMaxResults)]
		public PublishedFileId_t[] m_rgPublishedFileId;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = Constants.k_unEnumeratePublishedFilesMaxResults)]
		public uint[] m_rgRTimeUpdated;
	}

	//-----------------------------------------------------------------------------
	// Purpose: Called periodically while a PublishWorkshopFile is in progress
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iClientRemoteStorageCallbacks + 29)]
	public struct RemoteStoragePublishFileProgress_t {
		public const int k_iCallback = Constants.k_iClientRemoteStorageCallbacks + 29;
		public double m_dPercentFile;
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bPreview;
	}

	//-----------------------------------------------------------------------------
	// Purpose: Called when the content for a published file is updated
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iClientRemoteStorageCallbacks + 30)]
	public struct RemoteStoragePublishedFileUpdated_t {
		public const int k_iCallback = Constants.k_iClientRemoteStorageCallbacks + 30;
		public PublishedFileId_t m_nPublishedFileId;	// The published file id
		public AppId_t m_nAppID;						// ID of the app that will consume this file.
		public ulong m_ulUnused;						// not used anymore
	}

	//-----------------------------------------------------------------------------
	// Purpose: Called when a FileWriteAsync completes
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iClientRemoteStorageCallbacks + 31)]
	public struct RemoteStorageFileWriteAsyncComplete_t {
		public const int k_iCallback = Constants.k_iClientRemoteStorageCallbacks + 31;
		public EResult m_eResult;						// result
	}

	//-----------------------------------------------------------------------------
	// Purpose: Called when a FileReadAsync completes
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iClientRemoteStorageCallbacks + 32)]
	public struct RemoteStorageFileReadAsyncComplete_t {
		public const int k_iCallback = Constants.k_iClientRemoteStorageCallbacks + 32;
		public SteamAPICall_t m_hFileReadAsync;		// call handle of the async read which was made
		public EResult m_eResult;						// result
		public uint m_nOffset;						// offset in the file this read was at
		public uint m_cubRead;						// amount read - will the <= the amount requested
	}

	// callbacks
	//-----------------------------------------------------------------------------
	// Purpose: Screenshot successfully written or otherwise added to the library
	// and can now be tagged
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamScreenshotsCallbacks + 1)]
	public struct ScreenshotReady_t {
		public const int k_iCallback = Constants.k_iSteamScreenshotsCallbacks + 1;
		public ScreenshotHandle m_hLocal;
		public EResult m_eResult;
	}

	//-----------------------------------------------------------------------------
	// Purpose: Screenshot has been requested by the user.  Only sent if
	// HookScreenshots() has been called, in which case Steam will not take
	// the screenshot itself.
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value, Size = 1)]
	[CallbackIdentity(Constants.k_iSteamScreenshotsCallbacks + 2)]
	public struct ScreenshotRequested_t {
		public const int k_iCallback = Constants.k_iSteamScreenshotsCallbacks + 2;
	}

	//-----------------------------------------------------------------------------
	// Purpose: Callback for querying UGC
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iClientUGCCallbacks + 1)]
	public struct SteamUGCQueryCompleted_t {
		public const int k_iCallback = Constants.k_iClientUGCCallbacks + 1;
		public UGCQueryHandle_t m_handle;
		public EResult m_eResult;
		public uint m_unNumResultsReturned;
		public uint m_unTotalMatchingResults;
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bCachedData;	// indicates whether this data was retrieved from the local on-disk cache
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.k_cchPublishedFileURLMax)]
		public string m_rgchNextCursor; // If a paging cursor was used, then this will be the next cursor to get the next result set.
	}

	//-----------------------------------------------------------------------------
	// Purpose: Callback for requesting details on one piece of UGC
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iClientUGCCallbacks + 2)]
	public struct SteamUGCRequestUGCDetailsResult_t {
		public const int k_iCallback = Constants.k_iClientUGCCallbacks + 2;
		public SteamUGCDetails_t m_details;
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bCachedData; // indicates whether this data was retrieved from the local on-disk cache
	}

	//-----------------------------------------------------------------------------
	// Purpose: result for ISteamUGC::CreateItem()
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iClientUGCCallbacks + 3)]
	public struct CreateItemResult_t {
		public const int k_iCallback = Constants.k_iClientUGCCallbacks + 3;
		public EResult m_eResult;
		public PublishedFileId_t m_nPublishedFileId; // new item got this UGC PublishFileID
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bUserNeedsToAcceptWorkshopLegalAgreement;
	}

	//-----------------------------------------------------------------------------
	// Purpose: result for ISteamUGC::SubmitItemUpdate()
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iClientUGCCallbacks + 4)]
	public struct SubmitItemUpdateResult_t {
		public const int k_iCallback = Constants.k_iClientUGCCallbacks + 4;
		public EResult m_eResult;
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bUserNeedsToAcceptWorkshopLegalAgreement;
		public PublishedFileId_t m_nPublishedFileId;
	}

	//-----------------------------------------------------------------------------
	// Purpose: a Workshop item has been installed or updated
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iClientUGCCallbacks + 5)]
	public struct ItemInstalled_t {
		public const int k_iCallback = Constants.k_iClientUGCCallbacks + 5;
		public AppId_t m_unAppID;
		public PublishedFileId_t m_nPublishedFileId;
	}

	//-----------------------------------------------------------------------------
	// Purpose: result of DownloadItem(), existing item files can be accessed again
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iClientUGCCallbacks + 6)]
	public struct DownloadItemResult_t {
		public const int k_iCallback = Constants.k_iClientUGCCallbacks + 6;
		public AppId_t m_unAppID;
		public PublishedFileId_t m_nPublishedFileId;
		public EResult m_eResult;
	}

	//-----------------------------------------------------------------------------
	// Purpose: result of AddItemToFavorites() or RemoveItemFromFavorites()
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iClientUGCCallbacks + 7)]
	public struct UserFavoriteItemsListChanged_t {
		public const int k_iCallback = Constants.k_iClientUGCCallbacks + 7;
		public PublishedFileId_t m_nPublishedFileId;
		public EResult m_eResult;
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bWasAddRequest;
	}

	//-----------------------------------------------------------------------------
	// Purpose: The result of a call to SetUserItemVote()
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iClientUGCCallbacks + 8)]
	public struct SetUserItemVoteResult_t {
		public const int k_iCallback = Constants.k_iClientUGCCallbacks + 8;
		public PublishedFileId_t m_nPublishedFileId;
		public EResult m_eResult;
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bVoteUp;
	}

	//-----------------------------------------------------------------------------
	// Purpose: The result of a call to GetUserItemVote()
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iClientUGCCallbacks + 9)]
	public struct GetUserItemVoteResult_t {
		public const int k_iCallback = Constants.k_iClientUGCCallbacks + 9;
		public PublishedFileId_t m_nPublishedFileId;
		public EResult m_eResult;
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bVotedUp;
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bVotedDown;
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bVoteSkipped;
	}

	//-----------------------------------------------------------------------------
	// Purpose: The result of a call to StartPlaytimeTracking()
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iClientUGCCallbacks + 10)]
	public struct StartPlaytimeTrackingResult_t {
		public const int k_iCallback = Constants.k_iClientUGCCallbacks + 10;
		public EResult m_eResult;
	}

	//-----------------------------------------------------------------------------
	// Purpose: The result of a call to StopPlaytimeTracking()
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iClientUGCCallbacks + 11)]
	public struct StopPlaytimeTrackingResult_t {
		public const int k_iCallback = Constants.k_iClientUGCCallbacks + 11;
		public EResult m_eResult;
	}

	//-----------------------------------------------------------------------------
	// Purpose: The result of a call to AddDependency
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iClientUGCCallbacks + 12)]
	public struct AddUGCDependencyResult_t {
		public const int k_iCallback = Constants.k_iClientUGCCallbacks + 12;
		public EResult m_eResult;
		public PublishedFileId_t m_nPublishedFileId;
		public PublishedFileId_t m_nChildPublishedFileId;
	}

	//-----------------------------------------------------------------------------
	// Purpose: The result of a call to RemoveDependency
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iClientUGCCallbacks + 13)]
	public struct RemoveUGCDependencyResult_t {
		public const int k_iCallback = Constants.k_iClientUGCCallbacks + 13;
		public EResult m_eResult;
		public PublishedFileId_t m_nPublishedFileId;
		public PublishedFileId_t m_nChildPublishedFileId;
	}

	//-----------------------------------------------------------------------------
	// Purpose: The result of a call to AddAppDependency
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iClientUGCCallbacks + 14)]
	public struct AddAppDependencyResult_t {
		public const int k_iCallback = Constants.k_iClientUGCCallbacks + 14;
		public EResult m_eResult;
		public PublishedFileId_t m_nPublishedFileId;
		public AppId_t m_nAppID;
	}

	//-----------------------------------------------------------------------------
	// Purpose: The result of a call to RemoveAppDependency
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iClientUGCCallbacks + 15)]
	public struct RemoveAppDependencyResult_t {
		public const int k_iCallback = Constants.k_iClientUGCCallbacks + 15;
		public EResult m_eResult;
		public PublishedFileId_t m_nPublishedFileId;
		public AppId_t m_nAppID;
	}

	//-----------------------------------------------------------------------------
	// Purpose: The result of a call to GetAppDependencies.  Callback may be called
	//			multiple times until all app dependencies have been returned.
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iClientUGCCallbacks + 16)]
	public struct GetAppDependenciesResult_t {
		public const int k_iCallback = Constants.k_iClientUGCCallbacks + 16;
		public EResult m_eResult;
		public PublishedFileId_t m_nPublishedFileId;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
		public AppId_t[] m_rgAppIDs;
		public uint m_nNumAppDependencies;		// number returned in this struct
		public uint m_nTotalNumAppDependencies;	// total found
	}

	//-----------------------------------------------------------------------------
	// Purpose: The result of a call to DeleteItem
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iClientUGCCallbacks + 17)]
	public struct DeleteItemResult_t {
		public const int k_iCallback = Constants.k_iClientUGCCallbacks + 17;
		public EResult m_eResult;
		public PublishedFileId_t m_nPublishedFileId;
	}

	// callbacks
	//-----------------------------------------------------------------------------
	// Purpose: called when a connections to the Steam back-end has been established
	//			this means the Steam client now has a working connection to the Steam servers
	//			usually this will have occurred before the game has launched, and should
	//			only be seen if the user has dropped connection due to a networking issue
	//			or a Steam server update
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value, Size = 1)]
	[CallbackIdentity(Constants.k_iSteamUserCallbacks + 1)]
	public struct SteamServersConnected_t {
		public const int k_iCallback = Constants.k_iSteamUserCallbacks + 1;
	}

	//-----------------------------------------------------------------------------
	// Purpose: called when a connection attempt has failed
	//			this will occur periodically if the Steam client is not connected,
	//			and has failed in it's retry to establish a connection
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamUserCallbacks + 2)]
	public struct SteamServerConnectFailure_t {
		public const int k_iCallback = Constants.k_iSteamUserCallbacks + 2;
		public EResult m_eResult;
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bStillRetrying;
	}

	//-----------------------------------------------------------------------------
	// Purpose: called if the client has lost connection to the Steam servers
	//			real-time services will be disabled until a matching SteamServersConnected_t has been posted
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamUserCallbacks + 3)]
	public struct SteamServersDisconnected_t {
		public const int k_iCallback = Constants.k_iSteamUserCallbacks + 3;
		public EResult m_eResult;
	}

	//-----------------------------------------------------------------------------
	// Purpose: Sent by the Steam server to the client telling it to disconnect from the specified game server,
	//			which it may be in the process of or already connected to.
	//			The game client should immediately disconnect upon receiving this message.
	//			This can usually occur if the user doesn't have rights to play on the game server.
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamUserCallbacks + 13)]
	public struct ClientGameServerDeny_t {
		public const int k_iCallback = Constants.k_iSteamUserCallbacks + 13;
		
		public uint m_uAppID;
		public uint m_unGameServerIP;
		public ushort m_usGameServerPort;
		public ushort m_bSecure;
		public uint m_uReason;
	}

	//-----------------------------------------------------------------------------
	// Purpose: called when the callback system for this client is in an error state (and has flushed pending callbacks)
	//			When getting this message the client should disconnect from Steam, reset any stored Steam state and reconnect.
	//			This usually occurs in the rare event the Steam client has some kind of fatal error.
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamUserCallbacks + 17)]
	public struct IPCFailure_t {
		public const int k_iCallback = Constants.k_iSteamUserCallbacks + 17;
		public byte m_eFailureType;
	}

	//-----------------------------------------------------------------------------
	// Purpose: Signaled whenever licenses change
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value, Size = 1)]
	[CallbackIdentity(Constants.k_iSteamUserCallbacks + 25)]
	public struct LicensesUpdated_t {
		public const int k_iCallback = Constants.k_iSteamUserCallbacks + 25;
	}

	//-----------------------------------------------------------------------------
	// callback for BeginAuthSession
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	[CallbackIdentity(Constants.k_iSteamUserCallbacks + 43)]
	public struct ValidateAuthTicketResponse_t {
		public const int k_iCallback = Constants.k_iSteamUserCallbacks + 43;
		public CSteamID m_SteamID;
		public EAuthSessionResponse m_eAuthSessionResponse;
		public CSteamID m_OwnerSteamID; // different from m_SteamID if borrowed
	}

	//-----------------------------------------------------------------------------
	// Purpose: called when a user has responded to a microtransaction authorization request
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamUserCallbacks + 52)]
	public struct MicroTxnAuthorizationResponse_t {
		public const int k_iCallback = Constants.k_iSteamUserCallbacks + 52;
		
		public uint m_unAppID;			// AppID for this microtransaction
		public ulong m_ulOrderID;			// OrderID provided for the microtransaction
		public byte m_bAuthorized;		// if user authorized transaction
	}

	//-----------------------------------------------------------------------------
	// Purpose: Result from RequestEncryptedAppTicket
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamUserCallbacks + 54)]
	public struct EncryptedAppTicketResponse_t {
		public const int k_iCallback = Constants.k_iSteamUserCallbacks + 54;
		
		public EResult m_eResult;
	}

	//-----------------------------------------------------------------------------
	// callback for GetAuthSessionTicket
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamUserCallbacks + 63)]
	public struct GetAuthSessionTicketResponse_t {
		public const int k_iCallback = Constants.k_iSteamUserCallbacks + 63;
		public HAuthTicket m_hAuthTicket;
		public EResult m_eResult;
	}

	//-----------------------------------------------------------------------------
	// Purpose: sent to your game in response to a steam://gamewebcallback/ command
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamUserCallbacks + 64)]
	public struct GameWebCallback_t {
		public const int k_iCallback = Constants.k_iSteamUserCallbacks + 64;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
		public string m_szURL;
	}

	//-----------------------------------------------------------------------------
	// Purpose: sent to your game in response to ISteamUser::RequestStoreAuthURL
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamUserCallbacks + 65)]
	public struct StoreAuthURLResponse_t {
		public const int k_iCallback = Constants.k_iSteamUserCallbacks + 65;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
		public string m_szURL;
	}

	//-----------------------------------------------------------------------------
	// Purpose: sent in response to ISteamUser::GetMarketEligibility
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamUserCallbacks + 66)]
	public struct MarketEligibilityResponse_t {
		public const int k_iCallback = Constants.k_iSteamUserCallbacks + 66;
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bAllowed;
		public EMarketNotAllowedReasonFlags m_eNotAllowedReason;
		public RTime32 m_rtAllowedAtTime;
		
		public int m_cdaySteamGuardRequiredDays; // The number of days any user is required to have had Steam Guard before they can use the market
		public int m_cdayNewDeviceCooldown; // The number of days after initial device authorization a user must wait before using the market on that device
	}

	// callbacks
	//-----------------------------------------------------------------------------
	// Purpose: called when the latests stats and achievements have been received
	//			from the server
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Explicit, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamUserStatsCallbacks + 1)]
	public struct UserStatsReceived_t {
		public const int k_iCallback = Constants.k_iSteamUserStatsCallbacks + 1;
		[FieldOffset(0)]
		public ulong m_nGameID;		// Game these stats are for
		[FieldOffset(8)]
		public EResult m_eResult;		// Success / error fetching the stats
		[FieldOffset(12)]
		public CSteamID m_steamIDUser;	// The user for whom the stats are retrieved for
	}

	//-----------------------------------------------------------------------------
	// Purpose: result of a request to store the user stats for a game
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamUserStatsCallbacks + 2)]
	public struct UserStatsStored_t {
		public const int k_iCallback = Constants.k_iSteamUserStatsCallbacks + 2;
		public ulong m_nGameID;		// Game these stats are for
		public EResult m_eResult;		// success / error
	}

	//-----------------------------------------------------------------------------
	// Purpose: result of a request to store the achievements for a game, or an
	//			"indicate progress" call. If both m_nCurProgress and m_nMaxProgress
	//			are zero, that means the achievement has been fully unlocked.
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamUserStatsCallbacks + 3)]
	public struct UserAchievementStored_t {
		public const int k_iCallback = Constants.k_iSteamUserStatsCallbacks + 3;
		
		public ulong m_nGameID;				// Game this is for
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bGroupAchievement;	// if this is a "group" achievement
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.k_cchStatNameMax)]
		public string m_rgchAchievementName;		// name of the achievement
		public uint m_nCurProgress;			// current progress towards the achievement
		public uint m_nMaxProgress;			// "out of" this many
	}

	//-----------------------------------------------------------------------------
	// Purpose: call result for finding a leaderboard, returned as a result of FindOrCreateLeaderboard() or FindLeaderboard()
	//			use CCallResult<> to map this async result to a member function
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamUserStatsCallbacks + 4)]
	public struct LeaderboardFindResult_t {
		public const int k_iCallback = Constants.k_iSteamUserStatsCallbacks + 4;
		public SteamLeaderboard_t m_hSteamLeaderboard;	// handle to the leaderboard serarched for, 0 if no leaderboard found
		public byte m_bLeaderboardFound;				// 0 if no leaderboard found
	}

	//-----------------------------------------------------------------------------
	// Purpose: call result indicating scores for a leaderboard have been downloaded and are ready to be retrieved, returned as a result of DownloadLeaderboardEntries()
	//			use CCallResult<> to map this async result to a member function
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamUserStatsCallbacks + 5)]
	public struct LeaderboardScoresDownloaded_t {
		public const int k_iCallback = Constants.k_iSteamUserStatsCallbacks + 5;
		public SteamLeaderboard_t m_hSteamLeaderboard;
		public SteamLeaderboardEntries_t m_hSteamLeaderboardEntries;	// the handle to pass into GetDownloadedLeaderboardEntries()
		public int m_cEntryCount; // the number of entries downloaded
	}

	//-----------------------------------------------------------------------------
	// Purpose: call result indicating scores has been uploaded, returned as a result of UploadLeaderboardScore()
	//			use CCallResult<> to map this async result to a member function
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamUserStatsCallbacks + 6)]
	public struct LeaderboardScoreUploaded_t {
		public const int k_iCallback = Constants.k_iSteamUserStatsCallbacks + 6;
		public byte m_bSuccess;			// 1 if the call was successful
		public SteamLeaderboard_t m_hSteamLeaderboard;	// the leaderboard handle that was
		public int m_nScore;				// the score that was attempted to set
		public byte m_bScoreChanged;		// true if the score in the leaderboard change, false if the existing score was better
		public int m_nGlobalRankNew;		// the new global rank of the user in this leaderboard
		public int m_nGlobalRankPrevious;	// the previous global rank of the user in this leaderboard; 0 if the user had no existing entry in the leaderboard
	}

	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamUserStatsCallbacks + 7)]
	public struct NumberOfCurrentPlayers_t {
		public const int k_iCallback = Constants.k_iSteamUserStatsCallbacks + 7;
		public byte m_bSuccess;			// 1 if the call was successful
		public int m_cPlayers;			// Number of players currently playing
	}

	//-----------------------------------------------------------------------------
	// Purpose: Callback indicating that a user's stats have been unloaded.
	//  Call RequestUserStats again to access stats for this user
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamUserStatsCallbacks + 8)]
	public struct UserStatsUnloaded_t {
		public const int k_iCallback = Constants.k_iSteamUserStatsCallbacks + 8;
		public CSteamID m_steamIDUser;	// User whose stats have been unloaded
	}

	//-----------------------------------------------------------------------------
	// Purpose: Callback indicating that an achievement icon has been fetched
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamUserStatsCallbacks + 9)]
	public struct UserAchievementIconFetched_t {
		public const int k_iCallback = Constants.k_iSteamUserStatsCallbacks + 9;
		
		public CGameID m_nGameID;				// Game this is for
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.k_cchStatNameMax)]
		public string m_rgchAchievementName;		// name of the achievement
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bAchieved;		// Is the icon for the achieved or not achieved version?
		public int m_nIconHandle;		// Handle to the image, which can be used in SteamUtils()->GetImageRGBA(), 0 means no image is set for the achievement
	}

	//-----------------------------------------------------------------------------
	// Purpose: Callback indicating that global achievement percentages are fetched
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamUserStatsCallbacks + 10)]
	public struct GlobalAchievementPercentagesReady_t {
		public const int k_iCallback = Constants.k_iSteamUserStatsCallbacks + 10;
		
		public ulong m_nGameID;				// Game this is for
		public EResult m_eResult;				// Result of the operation
	}

	//-----------------------------------------------------------------------------
	// Purpose: call result indicating UGC has been uploaded, returned as a result of SetLeaderboardUGC()
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamUserStatsCallbacks + 11)]
	public struct LeaderboardUGCSet_t {
		public const int k_iCallback = Constants.k_iSteamUserStatsCallbacks + 11;
		public EResult m_eResult;				// The result of the operation
		public SteamLeaderboard_t m_hSteamLeaderboard;	// the leaderboard handle that was
	}

	//-----------------------------------------------------------------------------
	// Purpose: callback indicating global stats have been received.
	//	Returned as a result of RequestGlobalStats()
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamUserStatsCallbacks + 12)]
	public struct GlobalStatsReceived_t {
		public const int k_iCallback = Constants.k_iSteamUserStatsCallbacks + 12;
		public ulong m_nGameID;				// Game global stats were requested for
		public EResult m_eResult;				// The result of the request
	}

	// callbacks
	//-----------------------------------------------------------------------------
	// Purpose: The country of the user changed
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value, Size = 1)]
	[CallbackIdentity(Constants.k_iSteamUtilsCallbacks + 1)]
	public struct IPCountry_t {
		public const int k_iCallback = Constants.k_iSteamUtilsCallbacks + 1;
	}

	//-----------------------------------------------------------------------------
	// Purpose: Fired when running on a laptop and less than 10 minutes of battery is left, fires then every minute
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamUtilsCallbacks + 2)]
	public struct LowBatteryPower_t {
		public const int k_iCallback = Constants.k_iSteamUtilsCallbacks + 2;
		public byte m_nMinutesBatteryLeft;
	}

	//-----------------------------------------------------------------------------
	// Purpose: called when a SteamAsyncCall_t has completed (or failed)
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamUtilsCallbacks + 3)]
	public struct SteamAPICallCompleted_t {
		public const int k_iCallback = Constants.k_iSteamUtilsCallbacks + 3;
		public SteamAPICall_t m_hAsyncCall;
		public int m_iCallback;
		public uint m_cubParam;
	}

	//-----------------------------------------------------------------------------
	// called when Steam wants to shutdown
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value, Size = 1)]
	[CallbackIdentity(Constants.k_iSteamUtilsCallbacks + 4)]
	public struct SteamShutdown_t {
		public const int k_iCallback = Constants.k_iSteamUtilsCallbacks + 4;
	}

	//-----------------------------------------------------------------------------
	// callback for CheckFileSignature
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamUtilsCallbacks + 5)]
	public struct CheckFileSignature_t {
		public const int k_iCallback = Constants.k_iSteamUtilsCallbacks + 5;
		public ECheckFileSignature m_eCheckFileSignature;
	}

	// k_iSteamUtilsCallbacks + 13 is taken
	//-----------------------------------------------------------------------------
	// Big Picture gamepad text input has been closed
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iSteamUtilsCallbacks + 14)]
	public struct GamepadTextInputDismissed_t {
		public const int k_iCallback = Constants.k_iSteamUtilsCallbacks + 14;
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bSubmitted;										// true if user entered & accepted text (Call ISteamUtils::GetEnteredGamepadTextInput() for text), false if canceled input
		public uint m_unSubmittedText;
	}

	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value, Size = 1)]
	[CallbackIdentity(Constants.k_iClientVideoCallbacks + 4)]
	public struct BroadcastUploadStart_t {
		public const int k_iCallback = Constants.k_iClientVideoCallbacks + 4;
	}

	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iClientVideoCallbacks + 5)]
	public struct BroadcastUploadStop_t {
		public const int k_iCallback = Constants.k_iClientVideoCallbacks + 5;
		public EBroadcastUploadResult m_eResult;
	}

	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iClientVideoCallbacks + 11)]
	public struct GetVideoURLResult_t {
		public const int k_iCallback = Constants.k_iClientVideoCallbacks + 11;
		public EResult m_eResult;
		public AppId_t m_unVideoAppID;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
		public string m_rgchURL;
	}

	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	[CallbackIdentity(Constants.k_iClientVideoCallbacks + 24)]
	public struct GetOPFSettingsResult_t {
		public const int k_iCallback = Constants.k_iClientVideoCallbacks + 24;
		public EResult m_eResult;
		public AppId_t m_unVideoAppID;
	}

}
