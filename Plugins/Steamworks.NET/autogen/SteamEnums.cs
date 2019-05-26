// This file is provided under The MIT License as part of Steamworks.NET-nosteam.
// Copyright (c) 2013-2019 Riley Labrecque
// Copyright (c) 2019      Thomas Frohwein
// Please see the included LICENSE.txt for additional information.

using System.Runtime.InteropServices;
using IntPtr = System.IntPtr;

using Flags = System.FlagsAttribute;

namespace Steamworks {
	//-----------------------------------------------------------------------------
	// Purpose: possible results when registering an activation code
	//-----------------------------------------------------------------------------
	public enum ERegisterActivationCodeResult : int {
		k_ERegisterActivationCodeResultOK = 0,
		k_ERegisterActivationCodeResultFail = 1,
		k_ERegisterActivationCodeResultAlreadyRegistered = 2,
		k_ERegisterActivationCodeResultTimeout = 3,
		k_ERegisterActivationCodeAlreadyOwned = 4,
	}

	public enum EControllerSource : int {
		k_EControllerSource_None,
		k_EControllerSource_LeftTrackpad,
		k_EControllerSource_RightTrackpad,
		k_EControllerSource_Joystick,
		k_EControllerSource_ABXY,
		k_EControllerSource_Switch,
		k_EControllerSource_LeftTrigger,
		k_EControllerSource_RightTrigger,
		k_EControllerSource_LeftBumper,
		k_EControllerSource_RightBumper,
		k_EControllerSource_Gyro,
		k_EControllerSource_CenterTrackpad,		// PS4
		k_EControllerSource_RightJoystick,		// Traditional Controllers
		k_EControllerSource_DPad,				// Traditional Controllers
		k_EControllerSource_Key,                // Keyboards with scan codes - Unused
		k_EControllerSource_Mouse,              // Traditional mouse - Unused
		k_EControllerSource_LeftGyro,			// Secondary Gyro - Switch - Unused
		k_EControllerSource_Count
	}

	public enum EControllerSourceMode : int {
		k_EControllerSourceMode_None,
		k_EControllerSourceMode_Dpad,
		k_EControllerSourceMode_Buttons,
		k_EControllerSourceMode_FourButtons,
		k_EControllerSourceMode_AbsoluteMouse,
		k_EControllerSourceMode_RelativeMouse,
		k_EControllerSourceMode_JoystickMove,
		k_EControllerSourceMode_JoystickMouse,
		k_EControllerSourceMode_JoystickCamera,
		k_EControllerSourceMode_ScrollWheel,
		k_EControllerSourceMode_Trigger,
		k_EControllerSourceMode_TouchMenu,
		k_EControllerSourceMode_MouseJoystick,
		k_EControllerSourceMode_MouseRegion,
		k_EControllerSourceMode_RadialMenu,
		k_EControllerSourceMode_SingleButton,
		k_EControllerSourceMode_Switches
	}

	// Note: Please do not use action origins as a way to identify controller types. There is no
	// guarantee that they will be added in a contiguous manner - use GetInputTypeForHandle instead
	// Versions of Steam that add new controller types in the future will extend this enum if you're
	// using a lookup table please check the bounds of any origins returned by Steam.
	public enum EControllerActionOrigin : int {
		// Steam Controller
		k_EControllerActionOrigin_None,
		k_EControllerActionOrigin_A,
		k_EControllerActionOrigin_B,
		k_EControllerActionOrigin_X,
		k_EControllerActionOrigin_Y,
		k_EControllerActionOrigin_LeftBumper,
		k_EControllerActionOrigin_RightBumper,
		k_EControllerActionOrigin_LeftGrip,
		k_EControllerActionOrigin_RightGrip,
		k_EControllerActionOrigin_Start,
		k_EControllerActionOrigin_Back,
		k_EControllerActionOrigin_LeftPad_Touch,
		k_EControllerActionOrigin_LeftPad_Swipe,
		k_EControllerActionOrigin_LeftPad_Click,
		k_EControllerActionOrigin_LeftPad_DPadNorth,
		k_EControllerActionOrigin_LeftPad_DPadSouth,
		k_EControllerActionOrigin_LeftPad_DPadWest,
		k_EControllerActionOrigin_LeftPad_DPadEast,
		k_EControllerActionOrigin_RightPad_Touch,
		k_EControllerActionOrigin_RightPad_Swipe,
		k_EControllerActionOrigin_RightPad_Click,
		k_EControllerActionOrigin_RightPad_DPadNorth,
		k_EControllerActionOrigin_RightPad_DPadSouth,
		k_EControllerActionOrigin_RightPad_DPadWest,
		k_EControllerActionOrigin_RightPad_DPadEast,
		k_EControllerActionOrigin_LeftTrigger_Pull,
		k_EControllerActionOrigin_LeftTrigger_Click,
		k_EControllerActionOrigin_RightTrigger_Pull,
		k_EControllerActionOrigin_RightTrigger_Click,
		k_EControllerActionOrigin_LeftStick_Move,
		k_EControllerActionOrigin_LeftStick_Click,
		k_EControllerActionOrigin_LeftStick_DPadNorth,
		k_EControllerActionOrigin_LeftStick_DPadSouth,
		k_EControllerActionOrigin_LeftStick_DPadWest,
		k_EControllerActionOrigin_LeftStick_DPadEast,
		k_EControllerActionOrigin_Gyro_Move,
		k_EControllerActionOrigin_Gyro_Pitch,
		k_EControllerActionOrigin_Gyro_Yaw,
		k_EControllerActionOrigin_Gyro_Roll,

		// PS4 Dual Shock
		k_EControllerActionOrigin_PS4_X,
		k_EControllerActionOrigin_PS4_Circle,
		k_EControllerActionOrigin_PS4_Triangle,
		k_EControllerActionOrigin_PS4_Square,
		k_EControllerActionOrigin_PS4_LeftBumper,
		k_EControllerActionOrigin_PS4_RightBumper,
		k_EControllerActionOrigin_PS4_Options,  //Start
		k_EControllerActionOrigin_PS4_Share,	//Back
		k_EControllerActionOrigin_PS4_LeftPad_Touch,
		k_EControllerActionOrigin_PS4_LeftPad_Swipe,
		k_EControllerActionOrigin_PS4_LeftPad_Click,
		k_EControllerActionOrigin_PS4_LeftPad_DPadNorth,
		k_EControllerActionOrigin_PS4_LeftPad_DPadSouth,
		k_EControllerActionOrigin_PS4_LeftPad_DPadWest,
		k_EControllerActionOrigin_PS4_LeftPad_DPadEast,
		k_EControllerActionOrigin_PS4_RightPad_Touch,
		k_EControllerActionOrigin_PS4_RightPad_Swipe,
		k_EControllerActionOrigin_PS4_RightPad_Click,
		k_EControllerActionOrigin_PS4_RightPad_DPadNorth,
		k_EControllerActionOrigin_PS4_RightPad_DPadSouth,
		k_EControllerActionOrigin_PS4_RightPad_DPadWest,
		k_EControllerActionOrigin_PS4_RightPad_DPadEast,
		k_EControllerActionOrigin_PS4_CenterPad_Touch,
		k_EControllerActionOrigin_PS4_CenterPad_Swipe,
		k_EControllerActionOrigin_PS4_CenterPad_Click,
		k_EControllerActionOrigin_PS4_CenterPad_DPadNorth,
		k_EControllerActionOrigin_PS4_CenterPad_DPadSouth,
		k_EControllerActionOrigin_PS4_CenterPad_DPadWest,
		k_EControllerActionOrigin_PS4_CenterPad_DPadEast,
		k_EControllerActionOrigin_PS4_LeftTrigger_Pull,
		k_EControllerActionOrigin_PS4_LeftTrigger_Click,
		k_EControllerActionOrigin_PS4_RightTrigger_Pull,
		k_EControllerActionOrigin_PS4_RightTrigger_Click,
		k_EControllerActionOrigin_PS4_LeftStick_Move,
		k_EControllerActionOrigin_PS4_LeftStick_Click,
		k_EControllerActionOrigin_PS4_LeftStick_DPadNorth,
		k_EControllerActionOrigin_PS4_LeftStick_DPadSouth,
		k_EControllerActionOrigin_PS4_LeftStick_DPadWest,
		k_EControllerActionOrigin_PS4_LeftStick_DPadEast,
		k_EControllerActionOrigin_PS4_RightStick_Move,
		k_EControllerActionOrigin_PS4_RightStick_Click,
		k_EControllerActionOrigin_PS4_RightStick_DPadNorth,
		k_EControllerActionOrigin_PS4_RightStick_DPadSouth,
		k_EControllerActionOrigin_PS4_RightStick_DPadWest,
		k_EControllerActionOrigin_PS4_RightStick_DPadEast,
		k_EControllerActionOrigin_PS4_DPad_North,
		k_EControllerActionOrigin_PS4_DPad_South,
		k_EControllerActionOrigin_PS4_DPad_West,
		k_EControllerActionOrigin_PS4_DPad_East,
		k_EControllerActionOrigin_PS4_Gyro_Move,
		k_EControllerActionOrigin_PS4_Gyro_Pitch,
		k_EControllerActionOrigin_PS4_Gyro_Yaw,
		k_EControllerActionOrigin_PS4_Gyro_Roll,

		// XBox One
		k_EControllerActionOrigin_XBoxOne_A,
		k_EControllerActionOrigin_XBoxOne_B,
		k_EControllerActionOrigin_XBoxOne_X,
		k_EControllerActionOrigin_XBoxOne_Y,
		k_EControllerActionOrigin_XBoxOne_LeftBumper,
		k_EControllerActionOrigin_XBoxOne_RightBumper,
		k_EControllerActionOrigin_XBoxOne_Menu,  //Start
		k_EControllerActionOrigin_XBoxOne_View,  //Back
		k_EControllerActionOrigin_XBoxOne_LeftTrigger_Pull,
		k_EControllerActionOrigin_XBoxOne_LeftTrigger_Click,
		k_EControllerActionOrigin_XBoxOne_RightTrigger_Pull,
		k_EControllerActionOrigin_XBoxOne_RightTrigger_Click,
		k_EControllerActionOrigin_XBoxOne_LeftStick_Move,
		k_EControllerActionOrigin_XBoxOne_LeftStick_Click,
		k_EControllerActionOrigin_XBoxOne_LeftStick_DPadNorth,
		k_EControllerActionOrigin_XBoxOne_LeftStick_DPadSouth,
		k_EControllerActionOrigin_XBoxOne_LeftStick_DPadWest,
		k_EControllerActionOrigin_XBoxOne_LeftStick_DPadEast,
		k_EControllerActionOrigin_XBoxOne_RightStick_Move,
		k_EControllerActionOrigin_XBoxOne_RightStick_Click,
		k_EControllerActionOrigin_XBoxOne_RightStick_DPadNorth,
		k_EControllerActionOrigin_XBoxOne_RightStick_DPadSouth,
		k_EControllerActionOrigin_XBoxOne_RightStick_DPadWest,
		k_EControllerActionOrigin_XBoxOne_RightStick_DPadEast,
		k_EControllerActionOrigin_XBoxOne_DPad_North,
		k_EControllerActionOrigin_XBoxOne_DPad_South,
		k_EControllerActionOrigin_XBoxOne_DPad_West,
		k_EControllerActionOrigin_XBoxOne_DPad_East,

		// XBox 360
		k_EControllerActionOrigin_XBox360_A,
		k_EControllerActionOrigin_XBox360_B,
		k_EControllerActionOrigin_XBox360_X,
		k_EControllerActionOrigin_XBox360_Y,
		k_EControllerActionOrigin_XBox360_LeftBumper,
		k_EControllerActionOrigin_XBox360_RightBumper,
		k_EControllerActionOrigin_XBox360_Start,  //Start
		k_EControllerActionOrigin_XBox360_Back,  //Back
		k_EControllerActionOrigin_XBox360_LeftTrigger_Pull,
		k_EControllerActionOrigin_XBox360_LeftTrigger_Click,
		k_EControllerActionOrigin_XBox360_RightTrigger_Pull,
		k_EControllerActionOrigin_XBox360_RightTrigger_Click,
		k_EControllerActionOrigin_XBox360_LeftStick_Move,
		k_EControllerActionOrigin_XBox360_LeftStick_Click,
		k_EControllerActionOrigin_XBox360_LeftStick_DPadNorth,
		k_EControllerActionOrigin_XBox360_LeftStick_DPadSouth,
		k_EControllerActionOrigin_XBox360_LeftStick_DPadWest,
		k_EControllerActionOrigin_XBox360_LeftStick_DPadEast,
		k_EControllerActionOrigin_XBox360_RightStick_Move,
		k_EControllerActionOrigin_XBox360_RightStick_Click,
		k_EControllerActionOrigin_XBox360_RightStick_DPadNorth,
		k_EControllerActionOrigin_XBox360_RightStick_DPadSouth,
		k_EControllerActionOrigin_XBox360_RightStick_DPadWest,
		k_EControllerActionOrigin_XBox360_RightStick_DPadEast,
		k_EControllerActionOrigin_XBox360_DPad_North,
		k_EControllerActionOrigin_XBox360_DPad_South,
		k_EControllerActionOrigin_XBox360_DPad_West,
		k_EControllerActionOrigin_XBox360_DPad_East,

		// SteamController V2
		k_EControllerActionOrigin_SteamV2_A,
		k_EControllerActionOrigin_SteamV2_B,
		k_EControllerActionOrigin_SteamV2_X,
		k_EControllerActionOrigin_SteamV2_Y,
		k_EControllerActionOrigin_SteamV2_LeftBumper,
		k_EControllerActionOrigin_SteamV2_RightBumper,
		k_EControllerActionOrigin_SteamV2_LeftGrip_Lower,
		k_EControllerActionOrigin_SteamV2_LeftGrip_Upper,
		k_EControllerActionOrigin_SteamV2_RightGrip_Lower,
		k_EControllerActionOrigin_SteamV2_RightGrip_Upper,
		k_EControllerActionOrigin_SteamV2_LeftBumper_Pressure,
		k_EControllerActionOrigin_SteamV2_RightBumper_Pressure,
		k_EControllerActionOrigin_SteamV2_LeftGrip_Pressure,
		k_EControllerActionOrigin_SteamV2_RightGrip_Pressure,
		k_EControllerActionOrigin_SteamV2_LeftGrip_Upper_Pressure,
		k_EControllerActionOrigin_SteamV2_RightGrip_Upper_Pressure,
		k_EControllerActionOrigin_SteamV2_Start,
		k_EControllerActionOrigin_SteamV2_Back,
		k_EControllerActionOrigin_SteamV2_LeftPad_Touch,
		k_EControllerActionOrigin_SteamV2_LeftPad_Swipe,
		k_EControllerActionOrigin_SteamV2_LeftPad_Click,
		k_EControllerActionOrigin_SteamV2_LeftPad_Pressure,
		k_EControllerActionOrigin_SteamV2_LeftPad_DPadNorth,
		k_EControllerActionOrigin_SteamV2_LeftPad_DPadSouth,
		k_EControllerActionOrigin_SteamV2_LeftPad_DPadWest,
		k_EControllerActionOrigin_SteamV2_LeftPad_DPadEast,
		k_EControllerActionOrigin_SteamV2_RightPad_Touch,
		k_EControllerActionOrigin_SteamV2_RightPad_Swipe,
		k_EControllerActionOrigin_SteamV2_RightPad_Click,
		k_EControllerActionOrigin_SteamV2_RightPad_Pressure,
		k_EControllerActionOrigin_SteamV2_RightPad_DPadNorth,
		k_EControllerActionOrigin_SteamV2_RightPad_DPadSouth,
		k_EControllerActionOrigin_SteamV2_RightPad_DPadWest,
		k_EControllerActionOrigin_SteamV2_RightPad_DPadEast,
		k_EControllerActionOrigin_SteamV2_LeftTrigger_Pull,
		k_EControllerActionOrigin_SteamV2_LeftTrigger_Click,
		k_EControllerActionOrigin_SteamV2_RightTrigger_Pull,
		k_EControllerActionOrigin_SteamV2_RightTrigger_Click,
		k_EControllerActionOrigin_SteamV2_LeftStick_Move,
		k_EControllerActionOrigin_SteamV2_LeftStick_Click,
		k_EControllerActionOrigin_SteamV2_LeftStick_DPadNorth,
		k_EControllerActionOrigin_SteamV2_LeftStick_DPadSouth,
		k_EControllerActionOrigin_SteamV2_LeftStick_DPadWest,
		k_EControllerActionOrigin_SteamV2_LeftStick_DPadEast,
		k_EControllerActionOrigin_SteamV2_Gyro_Move,
		k_EControllerActionOrigin_SteamV2_Gyro_Pitch,
		k_EControllerActionOrigin_SteamV2_Gyro_Yaw,
		k_EControllerActionOrigin_SteamV2_Gyro_Roll,

		// Switch - Pro or Joycons used as a single input device.
		// This does not apply to a single joycon
		k_EControllerActionOrigin_Switch_A,
		k_EControllerActionOrigin_Switch_B,
		k_EControllerActionOrigin_Switch_X,
		k_EControllerActionOrigin_Switch_Y,
		k_EControllerActionOrigin_Switch_LeftBumper,
		k_EControllerActionOrigin_Switch_RightBumper,
		k_EControllerActionOrigin_Switch_Plus,  //Start
		k_EControllerActionOrigin_Switch_Minus,	//Back
		k_EControllerActionOrigin_Switch_Capture,
		k_EControllerActionOrigin_Switch_LeftTrigger_Pull,
		k_EControllerActionOrigin_Switch_LeftTrigger_Click,
		k_EControllerActionOrigin_Switch_RightTrigger_Pull,
		k_EControllerActionOrigin_Switch_RightTrigger_Click,
		k_EControllerActionOrigin_Switch_LeftStick_Move,
		k_EControllerActionOrigin_Switch_LeftStick_Click,
		k_EControllerActionOrigin_Switch_LeftStick_DPadNorth,
		k_EControllerActionOrigin_Switch_LeftStick_DPadSouth,
		k_EControllerActionOrigin_Switch_LeftStick_DPadWest,
		k_EControllerActionOrigin_Switch_LeftStick_DPadEast,
		k_EControllerActionOrigin_Switch_RightStick_Move,
		k_EControllerActionOrigin_Switch_RightStick_Click,
		k_EControllerActionOrigin_Switch_RightStick_DPadNorth,
		k_EControllerActionOrigin_Switch_RightStick_DPadSouth,
		k_EControllerActionOrigin_Switch_RightStick_DPadWest,
		k_EControllerActionOrigin_Switch_RightStick_DPadEast,
		k_EControllerActionOrigin_Switch_DPad_North,
		k_EControllerActionOrigin_Switch_DPad_South,
		k_EControllerActionOrigin_Switch_DPad_West,
		k_EControllerActionOrigin_Switch_DPad_East,
		k_EControllerActionOrigin_Switch_ProGyro_Move,  // Primary Gyro in Pro Controller, or Right JoyCon
		k_EControllerActionOrigin_Switch_ProGyro_Pitch,  // Primary Gyro in Pro Controller, or Right JoyCon
		k_EControllerActionOrigin_Switch_ProGyro_Yaw,  // Primary Gyro in Pro Controller, or Right JoyCon
		k_EControllerActionOrigin_Switch_ProGyro_Roll,  // Primary Gyro in Pro Controller, or Right JoyCon
		// Switch JoyCon Specific
		k_EControllerActionOrigin_Switch_RightGyro_Move,  // Right JoyCon Gyro generally should correspond to Pro's single gyro
		k_EControllerActionOrigin_Switch_RightGyro_Pitch,  // Right JoyCon Gyro generally should correspond to Pro's single gyro
		k_EControllerActionOrigin_Switch_RightGyro_Yaw,  // Right JoyCon Gyro generally should correspond to Pro's single gyro
		k_EControllerActionOrigin_Switch_RightGyro_Roll,  // Right JoyCon Gyro generally should correspond to Pro's single gyro
		k_EControllerActionOrigin_Switch_LeftGyro_Move,
		k_EControllerActionOrigin_Switch_LeftGyro_Pitch,
		k_EControllerActionOrigin_Switch_LeftGyro_Yaw,
		k_EControllerActionOrigin_Switch_LeftGyro_Roll,
		k_EControllerActionOrigin_Switch_LeftGrip_Lower, // Left JoyCon SR Button
		k_EControllerActionOrigin_Switch_LeftGrip_Upper, // Left JoyCon SL Button
		k_EControllerActionOrigin_Switch_RightGrip_Lower,  // Right JoyCon SL Button
		k_EControllerActionOrigin_Switch_RightGrip_Upper,  // Right JoyCon SR Button

		k_EControllerActionOrigin_Count, // If Steam has added support for new controllers origins will go here.
		k_EControllerActionOrigin_MaximumPossibleValue = 32767, // Origins are currently a maximum of 16 bits.
	}

	public enum ESteamControllerLEDFlag : int {
		k_ESteamControllerLEDFlag_SetColor,
		k_ESteamControllerLEDFlag_RestoreUserDefault
	}

	//-----------------------------------------------------------------------------
	// Purpose: set of relationships to other users
	//-----------------------------------------------------------------------------
	public enum EFriendRelationship : int {
		k_EFriendRelationshipNone = 0,
		k_EFriendRelationshipBlocked = 1,			// this doesn't get stored; the user has just done an Ignore on an friendship invite
		k_EFriendRelationshipRequestRecipient = 2,
		k_EFriendRelationshipFriend = 3,
		k_EFriendRelationshipRequestInitiator = 4,
		k_EFriendRelationshipIgnored = 5,			// this is stored; the user has explicit blocked this other user from comments/chat/etc
		k_EFriendRelationshipIgnoredFriend = 6,
		k_EFriendRelationshipSuggested_DEPRECATED = 7,		// was used by the original implementation of the facebook linking feature, but now unused.

		// keep this updated
		k_EFriendRelationshipMax = 8,
	}

	//-----------------------------------------------------------------------------
	// Purpose: list of states a friend can be in
	//-----------------------------------------------------------------------------
	public enum EPersonaState : int {
		k_EPersonaStateOffline = 0,			// friend is not currently logged on
		k_EPersonaStateOnline = 1,			// friend is logged on
		k_EPersonaStateBusy = 2,			// user is on, but busy
		k_EPersonaStateAway = 3,			// auto-away feature
		k_EPersonaStateSnooze = 4,			// auto-away for a long time
		k_EPersonaStateLookingToTrade = 5,	// Online, trading
		k_EPersonaStateLookingToPlay = 6,	// Online, wanting to play
		k_EPersonaStateInvisible = 7,		// Online, but appears offline to friends.  This status is never published to clients.
		k_EPersonaStateMax,
	}

	//-----------------------------------------------------------------------------
	// Purpose: flags for enumerating friends list, or quickly checking a the relationship between users
	//-----------------------------------------------------------------------------
	[Flags]
	public enum EFriendFlags : int {
		k_EFriendFlagNone			= 0x00,
		k_EFriendFlagBlocked		= 0x01,
		k_EFriendFlagFriendshipRequested	= 0x02,
		k_EFriendFlagImmediate		= 0x04,			// "regular" friend
		k_EFriendFlagClanMember		= 0x08,
		k_EFriendFlagOnGameServer	= 0x10,
		// k_EFriendFlagHasPlayedWith	= 0x20,	// not currently used
		// k_EFriendFlagFriendOfFriend	= 0x40, // not currently used
		k_EFriendFlagRequestingFriendship = 0x80,
		k_EFriendFlagRequestingInfo = 0x100,
		k_EFriendFlagIgnored		= 0x200,
		k_EFriendFlagIgnoredFriend	= 0x400,
		// k_EFriendFlagSuggested		= 0x800,	// not used
		k_EFriendFlagChatMember		= 0x1000,
		k_EFriendFlagAll			= 0xFFFF,
	}

	//-----------------------------------------------------------------------------
	// Purpose: user restriction flags
	//-----------------------------------------------------------------------------
	public enum EUserRestriction : int {
		k_nUserRestrictionNone		= 0,	// no known chat/content restriction
		k_nUserRestrictionUnknown	= 1,	// we don't know yet (user offline)
		k_nUserRestrictionAnyChat	= 2,	// user is not allowed to (or can't) send/recv any chat
		k_nUserRestrictionVoiceChat	= 4,	// user is not allowed to (or can't) send/recv voice chat
		k_nUserRestrictionGroupChat	= 8,	// user is not allowed to (or can't) send/recv group chat
		k_nUserRestrictionRating	= 16,	// user is too young according to rating in current region
		k_nUserRestrictionGameInvites	= 32,	// user cannot send or recv game invites (e.g. mobile)
		k_nUserRestrictionTrading	= 64,	// user cannot participate in trading (console, mobile)
	}

	// These values are passed as parameters to the store
	public enum EOverlayToStoreFlag : int {
		k_EOverlayToStoreFlag_None = 0,
		k_EOverlayToStoreFlag_AddToCart = 1,
		k_EOverlayToStoreFlag_AddToCartAndShow = 2,
	}

	//-----------------------------------------------------------------------------
	// Purpose: Tells Steam where to place the browser window inside the overlay
	//-----------------------------------------------------------------------------
	public enum EActivateGameOverlayToWebPageMode : int {
		k_EActivateGameOverlayToWebPageMode_Default = 0,		// Browser will open next to all other windows that the user has open in the overlay.
																// The window will remain open, even if the user closes then re-opens the overlay.

		k_EActivateGameOverlayToWebPageMode_Modal = 1			// Browser will be opened in a special overlay configuration which hides all other windows
																// that the user has open in the overlay. When the user closes the overlay, the browser window
																// will also close. When the user closes the browser window, the overlay will automatically close.
	}

	// used in PersonaStateChange_t::m_nChangeFlags to describe what's changed about a user
	// these flags describe what the client has learned has changed recently, so on startup you'll see a name, avatar & relationship change for every friend
	[Flags]
	public enum EPersonaChange : int {
		k_EPersonaChangeName		= 0x0001,
		k_EPersonaChangeStatus		= 0x0002,
		k_EPersonaChangeComeOnline	= 0x0004,
		k_EPersonaChangeGoneOffline	= 0x0008,
		k_EPersonaChangeGamePlayed	= 0x0010,
		k_EPersonaChangeGameServer	= 0x0020,
		k_EPersonaChangeAvatar		= 0x0040,
		k_EPersonaChangeJoinedSource= 0x0080,
		k_EPersonaChangeLeftSource	= 0x0100,
		k_EPersonaChangeRelationshipChanged = 0x0200,
		k_EPersonaChangeNameFirstSet = 0x0400,
		k_EPersonaChangeBroadcast = 0x0800,
		k_EPersonaChangeNickname =	0x1000,
		k_EPersonaChangeSteamLevel = 0x2000,
		k_EPersonaChangeRichPresence = 0x4000,
	}

	// list of possible return values from the ISteamGameCoordinator API
	public enum EGCResults : int {
		k_EGCResultOK = 0,
		k_EGCResultNoMessage = 1,			// There is no message in the queue
		k_EGCResultBufferTooSmall = 2,		// The buffer is too small for the requested message
		k_EGCResultNotLoggedOn = 3,			// The client is not logged onto Steam
		k_EGCResultInvalidMessage = 4,		// Something was wrong with the message being sent with SendMessage
	}

	public enum EHTMLMouseButton : int {
		eHTMLMouseButton_Left = 0,
		eHTMLMouseButton_Right = 1,
		eHTMLMouseButton_Middle = 2,
	}

	public enum EMouseCursor : int {
		dc_user = 0,
		dc_none,
		dc_arrow,
		dc_ibeam,
		dc_hourglass,
		dc_waitarrow,
		dc_crosshair,
		dc_up,
		dc_sizenw,
		dc_sizese,
		dc_sizene,
		dc_sizesw,
		dc_sizew,
		dc_sizee,
		dc_sizen,
		dc_sizes,
		dc_sizewe,
		dc_sizens,
		dc_sizeall,
		dc_no,
		dc_hand,
		dc_blank, // don't show any custom cursor, just use your default
		dc_middle_pan,
		dc_north_pan,
		dc_north_east_pan,
		dc_east_pan,
		dc_south_east_pan,
		dc_south_pan,
		dc_south_west_pan,
		dc_west_pan,
		dc_north_west_pan,
		dc_alias,
		dc_cell,
		dc_colresize,
		dc_copycur,
		dc_verticaltext,
		dc_rowresize,
		dc_zoomin,
		dc_zoomout,
		dc_help,
		dc_custom,

		dc_last, // custom cursors start from this value and up
	}

	[Flags]
	public enum EHTMLKeyModifiers : int {
		k_eHTMLKeyModifier_None = 0,
		k_eHTMLKeyModifier_AltDown = 1 << 0,
		k_eHTMLKeyModifier_CtrlDown = 1 << 1,
		k_eHTMLKeyModifier_ShiftDown = 1 << 2,
	}

	public enum EInputSource : int {
		k_EInputSource_None,
		k_EInputSource_LeftTrackpad,
		k_EInputSource_RightTrackpad,
		k_EInputSource_Joystick,
		k_EInputSource_ABXY,
		k_EInputSource_Switch,
		k_EInputSource_LeftTrigger,
		k_EInputSource_RightTrigger,
		k_EInputSource_LeftBumper,
		k_EInputSource_RightBumper,
		k_EInputSource_Gyro,
		k_EInputSource_CenterTrackpad,		// PS4
		k_EInputSource_RightJoystick,		// Traditional Controllers
		k_EInputSource_DPad,				// Traditional Controllers
		k_EInputSource_Key,                 // Keyboards with scan codes - Unused
		k_EInputSource_Mouse,               // Traditional mouse - Unused
		k_EInputSource_LeftGyro,			// Secondary Gyro - Switch - Unused
		k_EInputSource_Count
	}

	public enum EInputSourceMode : int {
		k_EInputSourceMode_None,
		k_EInputSourceMode_Dpad,
		k_EInputSourceMode_Buttons,
		k_EInputSourceMode_FourButtons,
		k_EInputSourceMode_AbsoluteMouse,
		k_EInputSourceMode_RelativeMouse,
		k_EInputSourceMode_JoystickMove,
		k_EInputSourceMode_JoystickMouse,
		k_EInputSourceMode_JoystickCamera,
		k_EInputSourceMode_ScrollWheel,
		k_EInputSourceMode_Trigger,
		k_EInputSourceMode_TouchMenu,
		k_EInputSourceMode_MouseJoystick,
		k_EInputSourceMode_MouseRegion,
		k_EInputSourceMode_RadialMenu,
		k_EInputSourceMode_SingleButton,
		k_EInputSourceMode_Switches
	}

	// Note: Please do not use action origins as a way to identify controller types. There is no
	// guarantee that they will be added in a contiguous manner - use GetInputTypeForHandle instead.
	// Versions of Steam that add new controller types in the future will extend this enum so if you're
	// using a lookup table please check the bounds of any origins returned by Steam.
	public enum EInputActionOrigin : int {
		// Steam Controller
		k_EInputActionOrigin_None,
		k_EInputActionOrigin_SteamController_A,
		k_EInputActionOrigin_SteamController_B,
		k_EInputActionOrigin_SteamController_X,
		k_EInputActionOrigin_SteamController_Y,
		k_EInputActionOrigin_SteamController_LeftBumper,
		k_EInputActionOrigin_SteamController_RightBumper,
		k_EInputActionOrigin_SteamController_LeftGrip,
		k_EInputActionOrigin_SteamController_RightGrip,
		k_EInputActionOrigin_SteamController_Start,
		k_EInputActionOrigin_SteamController_Back,
		k_EInputActionOrigin_SteamController_LeftPad_Touch,
		k_EInputActionOrigin_SteamController_LeftPad_Swipe,
		k_EInputActionOrigin_SteamController_LeftPad_Click,
		k_EInputActionOrigin_SteamController_LeftPad_DPadNorth,
		k_EInputActionOrigin_SteamController_LeftPad_DPadSouth,
		k_EInputActionOrigin_SteamController_LeftPad_DPadWest,
		k_EInputActionOrigin_SteamController_LeftPad_DPadEast,
		k_EInputActionOrigin_SteamController_RightPad_Touch,
		k_EInputActionOrigin_SteamController_RightPad_Swipe,
		k_EInputActionOrigin_SteamController_RightPad_Click,
		k_EInputActionOrigin_SteamController_RightPad_DPadNorth,
		k_EInputActionOrigin_SteamController_RightPad_DPadSouth,
		k_EInputActionOrigin_SteamController_RightPad_DPadWest,
		k_EInputActionOrigin_SteamController_RightPad_DPadEast,
		k_EInputActionOrigin_SteamController_LeftTrigger_Pull,
		k_EInputActionOrigin_SteamController_LeftTrigger_Click,
		k_EInputActionOrigin_SteamController_RightTrigger_Pull,
		k_EInputActionOrigin_SteamController_RightTrigger_Click,
		k_EInputActionOrigin_SteamController_LeftStick_Move,
		k_EInputActionOrigin_SteamController_LeftStick_Click,
		k_EInputActionOrigin_SteamController_LeftStick_DPadNorth,
		k_EInputActionOrigin_SteamController_LeftStick_DPadSouth,
		k_EInputActionOrigin_SteamController_LeftStick_DPadWest,
		k_EInputActionOrigin_SteamController_LeftStick_DPadEast,
		k_EInputActionOrigin_SteamController_Gyro_Move,
		k_EInputActionOrigin_SteamController_Gyro_Pitch,
		k_EInputActionOrigin_SteamController_Gyro_Yaw,
		k_EInputActionOrigin_SteamController_Gyro_Roll,
		k_EInputActionOrigin_SteamController_Reserved0,
		k_EInputActionOrigin_SteamController_Reserved1,
		k_EInputActionOrigin_SteamController_Reserved2,
		k_EInputActionOrigin_SteamController_Reserved3,
		k_EInputActionOrigin_SteamController_Reserved4,
		k_EInputActionOrigin_SteamController_Reserved5,
		k_EInputActionOrigin_SteamController_Reserved6,
		k_EInputActionOrigin_SteamController_Reserved7,
		k_EInputActionOrigin_SteamController_Reserved8,
		k_EInputActionOrigin_SteamController_Reserved9,
		k_EInputActionOrigin_SteamController_Reserved10,

		// PS4 Dual Shock
		k_EInputActionOrigin_PS4_X,
		k_EInputActionOrigin_PS4_Circle,
		k_EInputActionOrigin_PS4_Triangle,
		k_EInputActionOrigin_PS4_Square,
		k_EInputActionOrigin_PS4_LeftBumper,
		k_EInputActionOrigin_PS4_RightBumper,
		k_EInputActionOrigin_PS4_Options,	//Start
		k_EInputActionOrigin_PS4_Share,		//Back
		k_EInputActionOrigin_PS4_LeftPad_Touch,
		k_EInputActionOrigin_PS4_LeftPad_Swipe,
		k_EInputActionOrigin_PS4_LeftPad_Click,
		k_EInputActionOrigin_PS4_LeftPad_DPadNorth,
		k_EInputActionOrigin_PS4_LeftPad_DPadSouth,
		k_EInputActionOrigin_PS4_LeftPad_DPadWest,
		k_EInputActionOrigin_PS4_LeftPad_DPadEast,
		k_EInputActionOrigin_PS4_RightPad_Touch,
		k_EInputActionOrigin_PS4_RightPad_Swipe,
		k_EInputActionOrigin_PS4_RightPad_Click,
		k_EInputActionOrigin_PS4_RightPad_DPadNorth,
		k_EInputActionOrigin_PS4_RightPad_DPadSouth,
		k_EInputActionOrigin_PS4_RightPad_DPadWest,
		k_EInputActionOrigin_PS4_RightPad_DPadEast,
		k_EInputActionOrigin_PS4_CenterPad_Touch,
		k_EInputActionOrigin_PS4_CenterPad_Swipe,
		k_EInputActionOrigin_PS4_CenterPad_Click,
		k_EInputActionOrigin_PS4_CenterPad_DPadNorth,
		k_EInputActionOrigin_PS4_CenterPad_DPadSouth,
		k_EInputActionOrigin_PS4_CenterPad_DPadWest,
		k_EInputActionOrigin_PS4_CenterPad_DPadEast,
		k_EInputActionOrigin_PS4_LeftTrigger_Pull,
		k_EInputActionOrigin_PS4_LeftTrigger_Click,
		k_EInputActionOrigin_PS4_RightTrigger_Pull,
		k_EInputActionOrigin_PS4_RightTrigger_Click,
		k_EInputActionOrigin_PS4_LeftStick_Move,
		k_EInputActionOrigin_PS4_LeftStick_Click,
		k_EInputActionOrigin_PS4_LeftStick_DPadNorth,
		k_EInputActionOrigin_PS4_LeftStick_DPadSouth,
		k_EInputActionOrigin_PS4_LeftStick_DPadWest,
		k_EInputActionOrigin_PS4_LeftStick_DPadEast,
		k_EInputActionOrigin_PS4_RightStick_Move,
		k_EInputActionOrigin_PS4_RightStick_Click,
		k_EInputActionOrigin_PS4_RightStick_DPadNorth,
		k_EInputActionOrigin_PS4_RightStick_DPadSouth,
		k_EInputActionOrigin_PS4_RightStick_DPadWest,
		k_EInputActionOrigin_PS4_RightStick_DPadEast,
		k_EInputActionOrigin_PS4_DPad_North,
		k_EInputActionOrigin_PS4_DPad_South,
		k_EInputActionOrigin_PS4_DPad_West,
		k_EInputActionOrigin_PS4_DPad_East,
		k_EInputActionOrigin_PS4_Gyro_Move,
		k_EInputActionOrigin_PS4_Gyro_Pitch,
		k_EInputActionOrigin_PS4_Gyro_Yaw,
		k_EInputActionOrigin_PS4_Gyro_Roll,
		k_EInputActionOrigin_PS4_Reserved0,
		k_EInputActionOrigin_PS4_Reserved1,
		k_EInputActionOrigin_PS4_Reserved2,
		k_EInputActionOrigin_PS4_Reserved3,
		k_EInputActionOrigin_PS4_Reserved4,
		k_EInputActionOrigin_PS4_Reserved5,
		k_EInputActionOrigin_PS4_Reserved6,
		k_EInputActionOrigin_PS4_Reserved7,
		k_EInputActionOrigin_PS4_Reserved8,
		k_EInputActionOrigin_PS4_Reserved9,
		k_EInputActionOrigin_PS4_Reserved10,

		// XBox One
		k_EInputActionOrigin_XBoxOne_A,
		k_EInputActionOrigin_XBoxOne_B,
		k_EInputActionOrigin_XBoxOne_X,
		k_EInputActionOrigin_XBoxOne_Y,
		k_EInputActionOrigin_XBoxOne_LeftBumper,
		k_EInputActionOrigin_XBoxOne_RightBumper,
		k_EInputActionOrigin_XBoxOne_Menu,  //Start
		k_EInputActionOrigin_XBoxOne_View,  //Back
		k_EInputActionOrigin_XBoxOne_LeftTrigger_Pull,
		k_EInputActionOrigin_XBoxOne_LeftTrigger_Click,
		k_EInputActionOrigin_XBoxOne_RightTrigger_Pull,
		k_EInputActionOrigin_XBoxOne_RightTrigger_Click,
		k_EInputActionOrigin_XBoxOne_LeftStick_Move,
		k_EInputActionOrigin_XBoxOne_LeftStick_Click,
		k_EInputActionOrigin_XBoxOne_LeftStick_DPadNorth,
		k_EInputActionOrigin_XBoxOne_LeftStick_DPadSouth,
		k_EInputActionOrigin_XBoxOne_LeftStick_DPadWest,
		k_EInputActionOrigin_XBoxOne_LeftStick_DPadEast,
		k_EInputActionOrigin_XBoxOne_RightStick_Move,
		k_EInputActionOrigin_XBoxOne_RightStick_Click,
		k_EInputActionOrigin_XBoxOne_RightStick_DPadNorth,
		k_EInputActionOrigin_XBoxOne_RightStick_DPadSouth,
		k_EInputActionOrigin_XBoxOne_RightStick_DPadWest,
		k_EInputActionOrigin_XBoxOne_RightStick_DPadEast,
		k_EInputActionOrigin_XBoxOne_DPad_North,
		k_EInputActionOrigin_XBoxOne_DPad_South,
		k_EInputActionOrigin_XBoxOne_DPad_West,
		k_EInputActionOrigin_XBoxOne_DPad_East,
		k_EInputActionOrigin_XBoxOne_Reserved0,
		k_EInputActionOrigin_XBoxOne_Reserved1,
		k_EInputActionOrigin_XBoxOne_Reserved2,
		k_EInputActionOrigin_XBoxOne_Reserved3,
		k_EInputActionOrigin_XBoxOne_Reserved4,
		k_EInputActionOrigin_XBoxOne_Reserved5,
		k_EInputActionOrigin_XBoxOne_Reserved6,
		k_EInputActionOrigin_XBoxOne_Reserved7,
		k_EInputActionOrigin_XBoxOne_Reserved8,
		k_EInputActionOrigin_XBoxOne_Reserved9,
		k_EInputActionOrigin_XBoxOne_Reserved10,

		// XBox 360
		k_EInputActionOrigin_XBox360_A,
		k_EInputActionOrigin_XBox360_B,
		k_EInputActionOrigin_XBox360_X,
		k_EInputActionOrigin_XBox360_Y,
		k_EInputActionOrigin_XBox360_LeftBumper,
		k_EInputActionOrigin_XBox360_RightBumper,
		k_EInputActionOrigin_XBox360_Start,		//Start
		k_EInputActionOrigin_XBox360_Back,		//Back
		k_EInputActionOrigin_XBox360_LeftTrigger_Pull,
		k_EInputActionOrigin_XBox360_LeftTrigger_Click,
		k_EInputActionOrigin_XBox360_RightTrigger_Pull,
		k_EInputActionOrigin_XBox360_RightTrigger_Click,
		k_EInputActionOrigin_XBox360_LeftStick_Move,
		k_EInputActionOrigin_XBox360_LeftStick_Click,
		k_EInputActionOrigin_XBox360_LeftStick_DPadNorth,
		k_EInputActionOrigin_XBox360_LeftStick_DPadSouth,
		k_EInputActionOrigin_XBox360_LeftStick_DPadWest,
		k_EInputActionOrigin_XBox360_LeftStick_DPadEast,
		k_EInputActionOrigin_XBox360_RightStick_Move,
		k_EInputActionOrigin_XBox360_RightStick_Click,
		k_EInputActionOrigin_XBox360_RightStick_DPadNorth,
		k_EInputActionOrigin_XBox360_RightStick_DPadSouth,
		k_EInputActionOrigin_XBox360_RightStick_DPadWest,
		k_EInputActionOrigin_XBox360_RightStick_DPadEast,
		k_EInputActionOrigin_XBox360_DPad_North,
		k_EInputActionOrigin_XBox360_DPad_South,
		k_EInputActionOrigin_XBox360_DPad_West,
		k_EInputActionOrigin_XBox360_DPad_East,
		k_EInputActionOrigin_XBox360_Reserved0,
		k_EInputActionOrigin_XBox360_Reserved1,
		k_EInputActionOrigin_XBox360_Reserved2,
		k_EInputActionOrigin_XBox360_Reserved3,
		k_EInputActionOrigin_XBox360_Reserved4,
		k_EInputActionOrigin_XBox360_Reserved5,
		k_EInputActionOrigin_XBox360_Reserved6,
		k_EInputActionOrigin_XBox360_Reserved7,
		k_EInputActionOrigin_XBox360_Reserved8,
		k_EInputActionOrigin_XBox360_Reserved9,
		k_EInputActionOrigin_XBox360_Reserved10,


		// Switch - Pro or Joycons used as a single input device.
		// This does not apply to a single joycon
		k_EInputActionOrigin_Switch_A,
		k_EInputActionOrigin_Switch_B,
		k_EInputActionOrigin_Switch_X,
		k_EInputActionOrigin_Switch_Y,
		k_EInputActionOrigin_Switch_LeftBumper,
		k_EInputActionOrigin_Switch_RightBumper,
		k_EInputActionOrigin_Switch_Plus,	//Start
		k_EInputActionOrigin_Switch_Minus,	//Back
		k_EInputActionOrigin_Switch_Capture,
		k_EInputActionOrigin_Switch_LeftTrigger_Pull,
		k_EInputActionOrigin_Switch_LeftTrigger_Click,
		k_EInputActionOrigin_Switch_RightTrigger_Pull,
		k_EInputActionOrigin_Switch_RightTrigger_Click,
		k_EInputActionOrigin_Switch_LeftStick_Move,
		k_EInputActionOrigin_Switch_LeftStick_Click,
		k_EInputActionOrigin_Switch_LeftStick_DPadNorth,
		k_EInputActionOrigin_Switch_LeftStick_DPadSouth,
		k_EInputActionOrigin_Switch_LeftStick_DPadWest,
		k_EInputActionOrigin_Switch_LeftStick_DPadEast,
		k_EInputActionOrigin_Switch_RightStick_Move,
		k_EInputActionOrigin_Switch_RightStick_Click,
		k_EInputActionOrigin_Switch_RightStick_DPadNorth,
		k_EInputActionOrigin_Switch_RightStick_DPadSouth,
		k_EInputActionOrigin_Switch_RightStick_DPadWest,
		k_EInputActionOrigin_Switch_RightStick_DPadEast,
		k_EInputActionOrigin_Switch_DPad_North,
		k_EInputActionOrigin_Switch_DPad_South,
		k_EInputActionOrigin_Switch_DPad_West,
		k_EInputActionOrigin_Switch_DPad_East,
		k_EInputActionOrigin_Switch_ProGyro_Move,  // Primary Gyro in Pro Controller, or Right JoyCon
		k_EInputActionOrigin_Switch_ProGyro_Pitch,  // Primary Gyro in Pro Controller, or Right JoyCon
		k_EInputActionOrigin_Switch_ProGyro_Yaw,  // Primary Gyro in Pro Controller, or Right JoyCon
		k_EInputActionOrigin_Switch_ProGyro_Roll,  // Primary Gyro in Pro Controller, or Right JoyCon
		k_EInputActionOrigin_Switch_Reserved0,
		k_EInputActionOrigin_Switch_Reserved1,
		k_EInputActionOrigin_Switch_Reserved2,
		k_EInputActionOrigin_Switch_Reserved3,
		k_EInputActionOrigin_Switch_Reserved4,
		k_EInputActionOrigin_Switch_Reserved5,
		k_EInputActionOrigin_Switch_Reserved6,
		k_EInputActionOrigin_Switch_Reserved7,
		k_EInputActionOrigin_Switch_Reserved8,
		k_EInputActionOrigin_Switch_Reserved9,
		k_EInputActionOrigin_Switch_Reserved10,

		// Switch JoyCon Specific
		k_EInputActionOrigin_Switch_RightGyro_Move,  // Right JoyCon Gyro generally should correspond to Pro's single gyro
		k_EInputActionOrigin_Switch_RightGyro_Pitch,  // Right JoyCon Gyro generally should correspond to Pro's single gyro
		k_EInputActionOrigin_Switch_RightGyro_Yaw,  // Right JoyCon Gyro generally should correspond to Pro's single gyro
		k_EInputActionOrigin_Switch_RightGyro_Roll,  // Right JoyCon Gyro generally should correspond to Pro's single gyro
		k_EInputActionOrigin_Switch_LeftGyro_Move,
		k_EInputActionOrigin_Switch_LeftGyro_Pitch,
		k_EInputActionOrigin_Switch_LeftGyro_Yaw,
		k_EInputActionOrigin_Switch_LeftGyro_Roll,
		k_EInputActionOrigin_Switch_LeftGrip_Lower, // Left JoyCon SR Button
		k_EInputActionOrigin_Switch_LeftGrip_Upper, // Left JoyCon SL Button
		k_EInputActionOrigin_Switch_RightGrip_Lower,  // Right JoyCon SL Button
		k_EInputActionOrigin_Switch_RightGrip_Upper,  // Right JoyCon SR Button
		k_EInputActionOrigin_Switch_Reserved11,
		k_EInputActionOrigin_Switch_Reserved12,
		k_EInputActionOrigin_Switch_Reserved13,
		k_EInputActionOrigin_Switch_Reserved14,
		k_EInputActionOrigin_Switch_Reserved15,
		k_EInputActionOrigin_Switch_Reserved16,
		k_EInputActionOrigin_Switch_Reserved17,
		k_EInputActionOrigin_Switch_Reserved18,
		k_EInputActionOrigin_Switch_Reserved19,
		k_EInputActionOrigin_Switch_Reserved20,

		k_EInputActionOrigin_Count, // If Steam has added support for new controllers origins will go here.
		k_EInputActionOrigin_MaximumPossibleValue = 32767, // Origins are currently a maximum of 16 bits.
	}

	public enum EXboxOrigin : int {
		k_EXboxOrigin_A,
		k_EXboxOrigin_B,
		k_EXboxOrigin_X,
		k_EXboxOrigin_Y,
		k_EXboxOrigin_LeftBumper,
		k_EXboxOrigin_RightBumper,
		k_EXboxOrigin_Menu,  //Start
		k_EXboxOrigin_View,  //Back
		k_EXboxOrigin_LeftTrigger_Pull,
		k_EXboxOrigin_LeftTrigger_Click,
		k_EXboxOrigin_RightTrigger_Pull,
		k_EXboxOrigin_RightTrigger_Click,
		k_EXboxOrigin_LeftStick_Move,
		k_EXboxOrigin_LeftStick_Click,
		k_EXboxOrigin_LeftStick_DPadNorth,
		k_EXboxOrigin_LeftStick_DPadSouth,
		k_EXboxOrigin_LeftStick_DPadWest,
		k_EXboxOrigin_LeftStick_DPadEast,
		k_EXboxOrigin_RightStick_Move,
		k_EXboxOrigin_RightStick_Click,
		k_EXboxOrigin_RightStick_DPadNorth,
		k_EXboxOrigin_RightStick_DPadSouth,
		k_EXboxOrigin_RightStick_DPadWest,
		k_EXboxOrigin_RightStick_DPadEast,
		k_EXboxOrigin_DPad_North,
		k_EXboxOrigin_DPad_South,
		k_EXboxOrigin_DPad_West,
		k_EXboxOrigin_DPad_East,
		k_EXboxOrigin_Count,
	}

	public enum ESteamControllerPad : int {
		k_ESteamControllerPad_Left,
		k_ESteamControllerPad_Right
	}

	public enum ESteamInputType : int {
		k_ESteamInputType_Unknown,
		k_ESteamInputType_SteamController,
		k_ESteamInputType_XBox360Controller,
		k_ESteamInputType_XBoxOneController,
		k_ESteamInputType_GenericGamepad,		// DirectInput controllers
		k_ESteamInputType_PS4Controller,
		k_ESteamInputType_AppleMFiController,	// Unused
		k_ESteamInputType_AndroidController,	// Unused
		k_ESteamInputType_SwitchJoyConPair,		// Unused
		k_ESteamInputType_SwitchJoyConSingle,	// Unused
		k_ESteamInputType_SwitchProController,
		k_ESteamInputType_MobileTouch,			// Steam Link App On-screen Virtual Controller
		k_ESteamInputType_PS3Controller,		// Currently uses PS4 Origins
		k_ESteamInputType_Count,
		k_ESteamInputType_MaximumPossibleValue = 255,
	}

	// These values are passed into SetLEDColor
	public enum ESteamInputLEDFlag : int {
		k_ESteamInputLEDFlag_SetColor,
		// Restore the LED color to the user's preference setting as set in the controller personalization menu.
		// This also happens automatically on exit of your game.
		k_ESteamInputLEDFlag_RestoreUserDefault
	}

	[Flags]
	public enum ESteamItemFlags : int {
		// Item status flags - these flags are permanently attached to specific item instances
		k_ESteamItemNoTrade = 1 << 0, // This item is account-locked and cannot be traded or given away.

		// Action confirmation flags - these flags are set one time only, as part of a result set
		k_ESteamItemRemoved = 1 << 8,	// The item has been destroyed, traded away, expired, or otherwise invalidated
		k_ESteamItemConsumed = 1 << 9,	// The item quantity has been decreased by 1 via ConsumeItem API.

		// All other flag bits are currently reserved for internal Steam use at this time.
		// Do not assume anything about the state of other flags which are not defined here.
	}

	// lobby type description
	public enum ELobbyType : int {
		k_ELobbyTypePrivate = 0,		// only way to join the lobby is to invite to someone else
		k_ELobbyTypeFriendsOnly = 1,	// shows for friends or invitees, but not in lobby list
		k_ELobbyTypePublic = 2,			// visible for friends and in lobby list
		k_ELobbyTypeInvisible = 3,		// returned by search, but not visible to other friends
										//    useful if you want a user in two lobbies, for example matching groups together
										//	  a user can be in only one regular lobby, and up to two invisible lobbies
	}

	// lobby search filter tools
	public enum ELobbyComparison : int {
		k_ELobbyComparisonEqualToOrLessThan = -2,
		k_ELobbyComparisonLessThan = -1,
		k_ELobbyComparisonEqual = 0,
		k_ELobbyComparisonGreaterThan = 1,
		k_ELobbyComparisonEqualToOrGreaterThan = 2,
		k_ELobbyComparisonNotEqual = 3,
	}

	// lobby search distance. Lobby results are sorted from closest to farthest.
	public enum ELobbyDistanceFilter : int {
		k_ELobbyDistanceFilterClose,		// only lobbies in the same immediate region will be returned
		k_ELobbyDistanceFilterDefault,		// only lobbies in the same region or near by regions
		k_ELobbyDistanceFilterFar,			// for games that don't have many latency requirements, will return lobbies about half-way around the globe
		k_ELobbyDistanceFilterWorldwide,	// no filtering, will match lobbies as far as India to NY (not recommended, expect multiple seconds of latency between the clients)
	}

	//-----------------------------------------------------------------------------
	// Purpose: Used in ChatInfo messages - fields specific to a chat member - must fit in a uint32
	//-----------------------------------------------------------------------------
	[Flags]
	public enum EChatMemberStateChange : int {
		// Specific to joining / leaving the chatroom
		k_EChatMemberStateChangeEntered			= 0x0001,		// This user has joined or is joining the chat room
		k_EChatMemberStateChangeLeft			= 0x0002,		// This user has left or is leaving the chat room
		k_EChatMemberStateChangeDisconnected	= 0x0004,		// User disconnected without leaving the chat first
		k_EChatMemberStateChangeKicked			= 0x0008,		// User kicked
		k_EChatMemberStateChangeBanned			= 0x0010,		// User kicked and banned
	}

	//-----------------------------------------------------------------------------
	// Purpose: Functions for quickly creating a Party with friends or acquaintances,
	//			EG from chat rooms.
	//-----------------------------------------------------------------------------
	public enum ESteamPartyBeaconLocationType : int {
		k_ESteamPartyBeaconLocationType_Invalid = 0,
		k_ESteamPartyBeaconLocationType_ChatGroup = 1,

		k_ESteamPartyBeaconLocationType_Max,
	}

	public enum ESteamPartyBeaconLocationData : int {
		k_ESteamPartyBeaconLocationDataInvalid = 0,
		k_ESteamPartyBeaconLocationDataName = 1,
		k_ESteamPartyBeaconLocationDataIconURLSmall = 2,
		k_ESteamPartyBeaconLocationDataIconURLMedium = 3,
		k_ESteamPartyBeaconLocationDataIconURLLarge = 4,
	}

	public enum PlayerAcceptState_t : int {
		k_EStateUnknown = 0,
		k_EStatePlayerAccepted = 1,
		k_EStatePlayerDeclined = 2,
	}

	//-----------------------------------------------------------------------------
	// Purpose:
	//-----------------------------------------------------------------------------
	public enum AudioPlayback_Status : int {
		AudioPlayback_Undefined = 0,
		AudioPlayback_Playing = 1,
		AudioPlayback_Paused = 2,
		AudioPlayback_Idle = 3
	}

	// list of possible errors returned by SendP2PPacket() API
	// these will be posted in the P2PSessionConnectFail_t callback
	public enum EP2PSessionError : int {
		k_EP2PSessionErrorNone = 0,
		k_EP2PSessionErrorNotRunningApp = 1,			// target is not running the same game
		k_EP2PSessionErrorNoRightsToApp = 2,			// local user doesn't own the app that is running
		k_EP2PSessionErrorDestinationNotLoggedIn = 3,	// target user isn't connected to Steam
		k_EP2PSessionErrorTimeout = 4,					// target isn't responding, perhaps not calling AcceptP2PSessionWithUser()
														// corporate firewalls can also block this (NAT traversal is not firewall traversal)
														// make sure that UDP ports 3478, 4379, and 4380 are open in an outbound direction
		k_EP2PSessionErrorMax = 5
	}

	// SendP2PPacket() send types
	// Typically k_EP2PSendUnreliable is what you want for UDP-like packets, k_EP2PSendReliable for TCP-like packets
	public enum EP2PSend : int {
		// Basic UDP send. Packets can't be bigger than 1200 bytes (your typical MTU size). Can be lost, or arrive out of order (rare).
		// The sending API does have some knowledge of the underlying connection, so if there is no NAT-traversal accomplished or
		// there is a recognized adjustment happening on the connection, the packet will be batched until the connection is open again.
		k_EP2PSendUnreliable = 0,

		// As above, but if the underlying p2p connection isn't yet established the packet will just be thrown away. Using this on the first
		// packet sent to a remote host almost guarantees the packet will be dropped.
		// This is only really useful for kinds of data that should never buffer up, i.e. voice payload packets
		k_EP2PSendUnreliableNoDelay = 1,

		// Reliable message send. Can send up to 1MB of data in a single message.
		// Does fragmentation/re-assembly of messages under the hood, as well as a sliding window for efficient sends of large chunks of data.
		k_EP2PSendReliable = 2,

		// As above, but applies the Nagle algorithm to the send - sends will accumulate
		// until the current MTU size (typically ~1200 bytes, but can change) or ~200ms has passed (Nagle algorithm).
		// Useful if you want to send a set of smaller messages but have the coalesced into a single packet
		// Since the reliable stream is all ordered, you can do several small message sends with k_EP2PSendReliableWithBuffering and then
		// do a normal k_EP2PSendReliable to force all the buffered data to be sent.
		k_EP2PSendReliableWithBuffering = 3,

	}

	// connection progress indicators, used by CreateP2PConnectionSocket()
	public enum ESNetSocketState : int {
		k_ESNetSocketStateInvalid = 0,

		// communication is valid
		k_ESNetSocketStateConnected = 1,

		// states while establishing a connection
		k_ESNetSocketStateInitiated = 10,				// the connection state machine has started

		// p2p connections
		k_ESNetSocketStateLocalCandidatesFound = 11,	// we've found our local IP info
		k_ESNetSocketStateReceivedRemoteCandidates = 12,// we've received information from the remote machine, via the Steam back-end, about their IP info

		// direct connections
		k_ESNetSocketStateChallengeHandshake = 15,		// we've received a challenge packet from the server

		// failure states
		k_ESNetSocketStateDisconnecting = 21,			// the API shut it down, and we're in the process of telling the other end
		k_ESNetSocketStateLocalDisconnect = 22,			// the API shut it down, and we've completed shutdown
		k_ESNetSocketStateTimeoutDuringConnect = 23,	// we timed out while trying to creating the connection
		k_ESNetSocketStateRemoteEndDisconnected = 24,	// the remote end has disconnected from us
		k_ESNetSocketStateConnectionBroken = 25,		// connection has been broken; either the other end has disappeared or our local network connection has broke

	}

	// describes how the socket is currently connected
	public enum ESNetSocketConnectionType : int {
		k_ESNetSocketConnectionTypeNotConnected = 0,
		k_ESNetSocketConnectionTypeUDP = 1,
		k_ESNetSocketConnectionTypeUDPRelay = 2,
	}

	// Feature types for parental settings
	public enum EParentalFeature : int {
		k_EFeatureInvalid = 0,
		k_EFeatureStore = 1,
		k_EFeatureCommunity = 2,
		k_EFeatureProfile = 3,
		k_EFeatureFriends = 4,
		k_EFeatureNews = 5,
		k_EFeatureTrading = 6,
		k_EFeatureSettings = 7,
		k_EFeatureConsole = 8,
		k_EFeatureBrowser = 9,
		k_EFeatureParentalSetup = 10,
		k_EFeatureLibrary = 11,
		k_EFeatureTest = 12,
		k_EFeatureMax
	}

	[Flags]
	public enum ERemoteStoragePlatform : int {
		k_ERemoteStoragePlatformNone		= 0,
		k_ERemoteStoragePlatformWindows		= (1 << 0),
		k_ERemoteStoragePlatformOSX			= (1 << 1),
		k_ERemoteStoragePlatformPS3			= (1 << 2),
		k_ERemoteStoragePlatformLinux		= (1 << 3),
		k_ERemoteStoragePlatformReserved2	= (1 << 4),
		k_ERemoteStoragePlatformAndroid		= (1 << 5),

		k_ERemoteStoragePlatformAll = -1
	}

	public enum ERemoteStoragePublishedFileVisibility : int {
		k_ERemoteStoragePublishedFileVisibilityPublic = 0,
		k_ERemoteStoragePublishedFileVisibilityFriendsOnly = 1,
		k_ERemoteStoragePublishedFileVisibilityPrivate = 2,
	}

	public enum EWorkshopFileType : int {
		k_EWorkshopFileTypeFirst = 0,

		k_EWorkshopFileTypeCommunity			  = 0,		// normal Workshop item that can be subscribed to
		k_EWorkshopFileTypeMicrotransaction		  = 1,		// Workshop item that is meant to be voted on for the purpose of selling in-game
		k_EWorkshopFileTypeCollection			  = 2,		// a collection of Workshop or Greenlight items
		k_EWorkshopFileTypeArt					  = 3,		// artwork
		k_EWorkshopFileTypeVideo				  = 4,		// external video
		k_EWorkshopFileTypeScreenshot			  = 5,		// screenshot
		k_EWorkshopFileTypeGame					  = 6,		// Greenlight game entry
		k_EWorkshopFileTypeSoftware				  = 7,		// Greenlight software entry
		k_EWorkshopFileTypeConcept				  = 8,		// Greenlight concept
		k_EWorkshopFileTypeWebGuide				  = 9,		// Steam web guide
		k_EWorkshopFileTypeIntegratedGuide		  = 10,		// application integrated guide
		k_EWorkshopFileTypeMerch				  = 11,		// Workshop merchandise meant to be voted on for the purpose of being sold
		k_EWorkshopFileTypeControllerBinding	  = 12,		// Steam Controller bindings
		k_EWorkshopFileTypeSteamworksAccessInvite = 13,		// internal
		k_EWorkshopFileTypeSteamVideo			  = 14,		// Steam video
		k_EWorkshopFileTypeGameManagedItem		  = 15,		// managed completely by the game, not the user, and not shown on the web

		// Update k_EWorkshopFileTypeMax if you add values.
		k_EWorkshopFileTypeMax = 16

	}

	public enum EWorkshopVote : int {
		k_EWorkshopVoteUnvoted = 0,
		k_EWorkshopVoteFor = 1,
		k_EWorkshopVoteAgainst = 2,
		k_EWorkshopVoteLater = 3,
	}

	public enum EWorkshopFileAction : int {
		k_EWorkshopFileActionPlayed = 0,
		k_EWorkshopFileActionCompleted = 1,
	}

	public enum EWorkshopEnumerationType : int {
		k_EWorkshopEnumerationTypeRankedByVote = 0,
		k_EWorkshopEnumerationTypeRecent = 1,
		k_EWorkshopEnumerationTypeTrending = 2,
		k_EWorkshopEnumerationTypeFavoritesOfFriends = 3,
		k_EWorkshopEnumerationTypeVotedByFriends = 4,
		k_EWorkshopEnumerationTypeContentByFriends = 5,
		k_EWorkshopEnumerationTypeRecentFromFollowedUsers = 6,
	}

	public enum EWorkshopVideoProvider : int {
		k_EWorkshopVideoProviderNone = 0,
		k_EWorkshopVideoProviderYoutube = 1
	}

	public enum EUGCReadAction : int {
		// Keeps the file handle open unless the last byte is read.  You can use this when reading large files (over 100MB) in sequential chunks.
		// If the last byte is read, this will behave the same as k_EUGCRead_Close.  Otherwise, it behaves the same as k_EUGCRead_ContinueReading.
		// This value maintains the same behavior as before the EUGCReadAction parameter was introduced.
		k_EUGCRead_ContinueReadingUntilFinished = 0,

		// Keeps the file handle open.  Use this when using UGCRead to seek to different parts of the file.
		// When you are done seeking around the file, make a final call with k_EUGCRead_Close to close it.
		k_EUGCRead_ContinueReading = 1,

		// Frees the file handle.  Use this when you're done reading the content.
		// To read the file from Steam again you will need to call UGCDownload again.
		k_EUGCRead_Close = 2,
	}

	public enum EVRScreenshotType : int {
		k_EVRScreenshotType_None			= 0,
		k_EVRScreenshotType_Mono			= 1,
		k_EVRScreenshotType_Stereo			= 2,
		k_EVRScreenshotType_MonoCubemap		= 3,
		k_EVRScreenshotType_MonoPanorama	= 4,
		k_EVRScreenshotType_StereoPanorama	= 5
	}

	// Matching UGC types for queries
	public enum EUGCMatchingUGCType : int {
		k_EUGCMatchingUGCType_Items				 = 0,		// both mtx items and ready-to-use items
		k_EUGCMatchingUGCType_Items_Mtx			 = 1,
		k_EUGCMatchingUGCType_Items_ReadyToUse	 = 2,
		k_EUGCMatchingUGCType_Collections		 = 3,
		k_EUGCMatchingUGCType_Artwork			 = 4,
		k_EUGCMatchingUGCType_Videos			 = 5,
		k_EUGCMatchingUGCType_Screenshots		 = 6,
		k_EUGCMatchingUGCType_AllGuides			 = 7,		// both web guides and integrated guides
		k_EUGCMatchingUGCType_WebGuides			 = 8,
		k_EUGCMatchingUGCType_IntegratedGuides	 = 9,
		k_EUGCMatchingUGCType_UsableInGame		 = 10,		// ready-to-use items and integrated guides
		k_EUGCMatchingUGCType_ControllerBindings = 11,
		k_EUGCMatchingUGCType_GameManagedItems	 = 12,		// game managed items (not managed by users)
		k_EUGCMatchingUGCType_All				 = ~0,		// return everything
	}

	// Different lists of published UGC for a user.
	// If the current logged in user is different than the specified user, then some options may not be allowed.
	public enum EUserUGCList : int {
		k_EUserUGCList_Published,
		k_EUserUGCList_VotedOn,
		k_EUserUGCList_VotedUp,
		k_EUserUGCList_VotedDown,
		k_EUserUGCList_WillVoteLater,
		k_EUserUGCList_Favorited,
		k_EUserUGCList_Subscribed,
		k_EUserUGCList_UsedOrPlayed,
		k_EUserUGCList_Followed,
	}

	// Sort order for user published UGC lists (defaults to creation order descending)
	public enum EUserUGCListSortOrder : int {
		k_EUserUGCListSortOrder_CreationOrderDesc,
		k_EUserUGCListSortOrder_CreationOrderAsc,
		k_EUserUGCListSortOrder_TitleAsc,
		k_EUserUGCListSortOrder_LastUpdatedDesc,
		k_EUserUGCListSortOrder_SubscriptionDateDesc,
		k_EUserUGCListSortOrder_VoteScoreDesc,
		k_EUserUGCListSortOrder_ForModeration,
	}

	// Combination of sorting and filtering for queries across all UGC
	public enum EUGCQuery : int {
		k_EUGCQuery_RankedByVote								  = 0,
		k_EUGCQuery_RankedByPublicationDate						  = 1,
		k_EUGCQuery_AcceptedForGameRankedByAcceptanceDate		  = 2,
		k_EUGCQuery_RankedByTrend								  = 3,
		k_EUGCQuery_FavoritedByFriendsRankedByPublicationDate	  = 4,
		k_EUGCQuery_CreatedByFriendsRankedByPublicationDate		  = 5,
		k_EUGCQuery_RankedByNumTimesReported					  = 6,
		k_EUGCQuery_CreatedByFollowedUsersRankedByPublicationDate = 7,
		k_EUGCQuery_NotYetRated									  = 8,
		k_EUGCQuery_RankedByTotalVotesAsc						  = 9,
		k_EUGCQuery_RankedByVotesUp								  = 10,
		k_EUGCQuery_RankedByTextSearch							  = 11,
		k_EUGCQuery_RankedByTotalUniqueSubscriptions			  = 12,
		k_EUGCQuery_RankedByPlaytimeTrend						  = 13,
		k_EUGCQuery_RankedByTotalPlaytime						  = 14,
		k_EUGCQuery_RankedByAveragePlaytimeTrend				  = 15,
		k_EUGCQuery_RankedByLifetimeAveragePlaytime				  = 16,
		k_EUGCQuery_RankedByPlaytimeSessionsTrend				  = 17,
		k_EUGCQuery_RankedByLifetimePlaytimeSessions			  = 18,
	}

	public enum EItemUpdateStatus : int {
		k_EItemUpdateStatusInvalid 				= 0, // The item update handle was invalid, job might be finished, listen too SubmitItemUpdateResult_t
		k_EItemUpdateStatusPreparingConfig 		= 1, // The item update is processing configuration data
		k_EItemUpdateStatusPreparingContent		= 2, // The item update is reading and processing content files
		k_EItemUpdateStatusUploadingContent		= 3, // The item update is uploading content changes to Steam
		k_EItemUpdateStatusUploadingPreviewFile	= 4, // The item update is uploading new preview file image
		k_EItemUpdateStatusCommittingChanges	= 5  // The item update is committing all changes
	}

	[Flags]
	public enum EItemState : int {
		k_EItemStateNone			= 0,	// item not tracked on client
		k_EItemStateSubscribed		= 1,	// current user is subscribed to this item. Not just cached.
		k_EItemStateLegacyItem		= 2,	// item was created with ISteamRemoteStorage
		k_EItemStateInstalled		= 4,	// item is installed and usable (but maybe out of date)
		k_EItemStateNeedsUpdate		= 8,	// items needs an update. Either because it's not installed yet or creator updated content
		k_EItemStateDownloading		= 16,	// item update is currently downloading
		k_EItemStateDownloadPending	= 32,	// DownloadItem() was called for this item, content isn't available until DownloadItemResult_t is fired
	}

	public enum EItemStatistic : int {
		k_EItemStatistic_NumSubscriptions					 = 0,
		k_EItemStatistic_NumFavorites						 = 1,
		k_EItemStatistic_NumFollowers						 = 2,
		k_EItemStatistic_NumUniqueSubscriptions				 = 3,
		k_EItemStatistic_NumUniqueFavorites					 = 4,
		k_EItemStatistic_NumUniqueFollowers					 = 5,
		k_EItemStatistic_NumUniqueWebsiteViews				 = 6,
		k_EItemStatistic_ReportScore						 = 7,
		k_EItemStatistic_NumSecondsPlayed					 = 8,
		k_EItemStatistic_NumPlaytimeSessions				 = 9,
		k_EItemStatistic_NumComments						 = 10,
		k_EItemStatistic_NumSecondsPlayedDuringTimePeriod	 = 11,
		k_EItemStatistic_NumPlaytimeSessionsDuringTimePeriod = 12,
	}

	public enum EItemPreviewType : int {
		k_EItemPreviewType_Image							= 0,	// standard image file expected (e.g. jpg, png, gif, etc.)
		k_EItemPreviewType_YouTubeVideo						= 1,	// video id is stored
		k_EItemPreviewType_Sketchfab						= 2,	// model id is stored
		k_EItemPreviewType_EnvironmentMap_HorizontalCross	= 3,	// standard image file expected - cube map in the layout
																	// +---+---+-------+
																	// |   |Up |       |
																	// +---+---+---+---+
																	// | L | F | R | B |
																	// +---+---+---+---+
																	// |   |Dn |       |
																	// +---+---+---+---+
		k_EItemPreviewType_EnvironmentMap_LatLong			= 4,	// standard image file expected
		k_EItemPreviewType_ReservedMax						= 255,	// you can specify your own types above this value
	}

	public enum EFailureType : int {
		k_EFailureFlushedCallbackQueue,
		k_EFailurePipeFail,
	}

	// type of data request, when downloading leaderboard entries
	public enum ELeaderboardDataRequest : int {
		k_ELeaderboardDataRequestGlobal = 0,
		k_ELeaderboardDataRequestGlobalAroundUser = 1,
		k_ELeaderboardDataRequestFriends = 2,
		k_ELeaderboardDataRequestUsers = 3
	}

	// the sort order of a leaderboard
	public enum ELeaderboardSortMethod : int {
		k_ELeaderboardSortMethodNone = 0,
		k_ELeaderboardSortMethodAscending = 1,	// top-score is lowest number
		k_ELeaderboardSortMethodDescending = 2,	// top-score is highest number
	}

	// the display type (used by the Steam Community web site) for a leaderboard
	public enum ELeaderboardDisplayType : int {
		k_ELeaderboardDisplayTypeNone = 0,
		k_ELeaderboardDisplayTypeNumeric = 1,			// simple numerical score
		k_ELeaderboardDisplayTypeTimeSeconds = 2,		// the score represents a time, in seconds
		k_ELeaderboardDisplayTypeTimeMilliSeconds = 3,	// the score represents a time, in milliseconds
	}

	public enum ELeaderboardUploadScoreMethod : int {
		k_ELeaderboardUploadScoreMethodNone = 0,
		k_ELeaderboardUploadScoreMethodKeepBest = 1,	// Leaderboard will keep user's best score
		k_ELeaderboardUploadScoreMethodForceUpdate = 2,	// Leaderboard will always replace score with specified
	}

	// Steam API call failure results
	public enum ESteamAPICallFailure : int {
		k_ESteamAPICallFailureNone = -1,			// no failure
		k_ESteamAPICallFailureSteamGone = 0,		// the local Steam process has gone away
		k_ESteamAPICallFailureNetworkFailure = 1,	// the network connection to Steam has been broken, or was already broken
		// SteamServersDisconnected_t callback will be sent around the same time
		// SteamServersConnected_t will be sent when the client is able to talk to the Steam servers again
		k_ESteamAPICallFailureInvalidHandle = 2,	// the SteamAPICall_t handle passed in no longer exists
		k_ESteamAPICallFailureMismatchedCallback = 3,// GetAPICallResult() was called with the wrong callback type for this API call
	}

	// Input modes for the Big Picture gamepad text entry
	public enum EGamepadTextInputMode : int {
		k_EGamepadTextInputModeNormal = 0,
		k_EGamepadTextInputModePassword = 1
	}

	// Controls number of allowed lines for the Big Picture gamepad text entry
	public enum EGamepadTextInputLineMode : int {
		k_EGamepadTextInputLineModeSingleLine = 0,
		k_EGamepadTextInputLineModeMultipleLines = 1
	}

	//-----------------------------------------------------------------------------
	// results for CheckFileSignature
	//-----------------------------------------------------------------------------
	public enum ECheckFileSignature : int {
		k_ECheckFileSignatureInvalidSignature = 0,
		k_ECheckFileSignatureValidSignature = 1,
		k_ECheckFileSignatureFileNotFound = 2,
		k_ECheckFileSignatureNoSignaturesFoundForThisApp = 3,
		k_ECheckFileSignatureNoSignaturesFoundForThisFile = 4,
	}

	public enum EMatchMakingServerResponse : int {
		eServerResponded = 0,
		eServerFailedToRespond,
		eNoServersListedOnMasterServer // for the Internet query type, returned in response callback if no servers of this type match
	}

	public enum EServerMode : int {
		eServerModeInvalid = 0, // DO NOT USE
		eServerModeNoAuthentication = 1, // Don't authenticate user logins and don't list on the server list
		eServerModeAuthentication = 2, // Authenticate users, list on the server list, don't run VAC on clients that connect
		eServerModeAuthenticationAndSecure = 3, // Authenticate users, list on the server list and VAC protect clients
	}

	// General result codes
	public enum EResult : int {
		k_EResultOK	= 1,							// success
		k_EResultFail = 2,							// generic failure
		k_EResultNoConnection = 3,					// no/failed network connection
	//	k_EResultNoConnectionRetry = 4,				// OBSOLETE - removed
		k_EResultInvalidPassword = 5,				// password/ticket is invalid
		k_EResultLoggedInElsewhere = 6,				// same user logged in elsewhere
		k_EResultInvalidProtocolVer = 7,			// protocol version is incorrect
		k_EResultInvalidParam = 8,					// a parameter is incorrect
		k_EResultFileNotFound = 9,					// file was not found
		k_EResultBusy = 10,							// called method busy - action not taken
		k_EResultInvalidState = 11,					// called object was in an invalid state
		k_EResultInvalidName = 12,					// name is invalid
		k_EResultInvalidEmail = 13,					// email is invalid
		k_EResultDuplicateName = 14,				// name is not unique
		k_EResultAccessDenied = 15,					// access is denied
		k_EResultTimeout = 16,						// operation timed out
		k_EResultBanned = 17,						// VAC2 banned
		k_EResultAccountNotFound = 18,				// account not found
		k_EResultInvalidSteamID = 19,				// steamID is invalid
		k_EResultServiceUnavailable = 20,			// The requested service is currently unavailable
		k_EResultNotLoggedOn = 21,					// The user is not logged on
		k_EResultPending = 22,						// Request is pending (may be in process, or waiting on third party)
		k_EResultEncryptionFailure = 23,			// Encryption or Decryption failed
		k_EResultInsufficientPrivilege = 24,		// Insufficient privilege
		k_EResultLimitExceeded = 25,				// Too much of a good thing
		k_EResultRevoked = 26,						// Access has been revoked (used for revoked guest passes)
		k_EResultExpired = 27,						// License/Guest pass the user is trying to access is expired
		k_EResultAlreadyRedeemed = 28,				// Guest pass has already been redeemed by account, cannot be acked again
		k_EResultDuplicateRequest = 29,				// The request is a duplicate and the action has already occurred in the past, ignored this time
		k_EResultAlreadyOwned = 30,					// All the games in this guest pass redemption request are already owned by the user
		k_EResultIPNotFound = 31,					// IP address not found
		k_EResultPersistFailed = 32,				// failed to write change to the data store
		k_EResultLockingFailed = 33,				// failed to acquire access lock for this operation
		k_EResultLogonSessionReplaced = 34,
		k_EResultConnectFailed = 35,
		k_EResultHandshakeFailed = 36,
		k_EResultIOFailure = 37,
		k_EResultRemoteDisconnect = 38,
		k_EResultShoppingCartNotFound = 39,			// failed to find the shopping cart requested
		k_EResultBlocked = 40,						// a user didn't allow it
		k_EResultIgnored = 41,						// target is ignoring sender
		k_EResultNoMatch = 42,						// nothing matching the request found
		k_EResultAccountDisabled = 43,
		k_EResultServiceReadOnly = 44,				// this service is not accepting content changes right now
		k_EResultAccountNotFeatured = 45,			// account doesn't have value, so this feature isn't available
		k_EResultAdministratorOK = 46,				// allowed to take this action, but only because requester is admin
		k_EResultContentVersion = 47,				// A Version mismatch in content transmitted within the Steam protocol.
		k_EResultTryAnotherCM = 48,					// The current CM can't service the user making a request, user should try another.
		k_EResultPasswordRequiredToKickSession = 49,// You are already logged in elsewhere, this cached credential login has failed.
		k_EResultAlreadyLoggedInElsewhere = 50,		// You are already logged in elsewhere, you must wait
		k_EResultSuspended = 51,					// Long running operation (content download) suspended/paused
		k_EResultCancelled = 52,					// Operation canceled (typically by user: content download)
		k_EResultDataCorruption = 53,				// Operation canceled because data is ill formed or unrecoverable
		k_EResultDiskFull = 54,						// Operation canceled - not enough disk space.
		k_EResultRemoteCallFailed = 55,				// an remote call or IPC call failed
		k_EResultPasswordUnset = 56,				// Password could not be verified as it's unset server side
		k_EResultExternalAccountUnlinked = 57,		// External account (PSN, Facebook...) is not linked to a Steam account
		k_EResultPSNTicketInvalid = 58,				// PSN ticket was invalid
		k_EResultExternalAccountAlreadyLinked = 59,	// External account (PSN, Facebook...) is already linked to some other account, must explicitly request to replace/delete the link first
		k_EResultRemoteFileConflict = 60,			// The sync cannot resume due to a conflict between the local and remote files
		k_EResultIllegalPassword = 61,				// The requested new password is not legal
		k_EResultSameAsPreviousValue = 62,			// new value is the same as the old one ( secret question and answer )
		k_EResultAccountLogonDenied = 63,			// account login denied due to 2nd factor authentication failure
		k_EResultCannotUseOldPassword = 64,			// The requested new password is not legal
		k_EResultInvalidLoginAuthCode = 65,			// account login denied due to auth code invalid
		k_EResultAccountLogonDeniedNoMail = 66,		// account login denied due to 2nd factor auth failure - and no mail has been sent
		k_EResultHardwareNotCapableOfIPT = 67,		//
		k_EResultIPTInitError = 68,					//
		k_EResultParentalControlRestricted = 69,	// operation failed due to parental control restrictions for current user
		k_EResultFacebookQueryError = 70,			// Facebook query returned an error
		k_EResultExpiredLoginAuthCode = 71,			// account login denied due to auth code expired
		k_EResultIPLoginRestrictionFailed = 72,
		k_EResultAccountLockedDown = 73,
		k_EResultAccountLogonDeniedVerifiedEmailRequired = 74,
		k_EResultNoMatchingURL = 75,
		k_EResultBadResponse = 76,					// parse failure, missing field, etc.
		k_EResultRequirePasswordReEntry = 77,		// The user cannot complete the action until they re-enter their password
		k_EResultValueOutOfRange = 78,				// the value entered is outside the acceptable range
		k_EResultUnexpectedError = 79,				// something happened that we didn't expect to ever happen
		k_EResultDisabled = 80,						// The requested service has been configured to be unavailable
		k_EResultInvalidCEGSubmission = 81,			// The set of files submitted to the CEG server are not valid !
		k_EResultRestrictedDevice = 82,				// The device being used is not allowed to perform this action
		k_EResultRegionLocked = 83,					// The action could not be complete because it is region restricted
		k_EResultRateLimitExceeded = 84,			// Temporary rate limit exceeded, try again later, different from k_EResultLimitExceeded which may be permanent
		k_EResultAccountLoginDeniedNeedTwoFactor = 85,	// Need two-factor code to login
		k_EResultItemDeleted = 86,					// The thing we're trying to access has been deleted
		k_EResultAccountLoginDeniedThrottle = 87,	// login attempt failed, try to throttle response to possible attacker
		k_EResultTwoFactorCodeMismatch = 88,		// two factor code mismatch
		k_EResultTwoFactorActivationCodeMismatch = 89,	// activation code for two-factor didn't match
		k_EResultAccountAssociatedToMultiplePartners = 90,	// account has been associated with multiple partners
		k_EResultNotModified = 91,					// data not modified
		k_EResultNoMobileDevice = 92,				// the account does not have a mobile device associated with it
		k_EResultTimeNotSynced = 93,				// the time presented is out of range or tolerance
		k_EResultSmsCodeFailed = 94,				// SMS code failure (no match, none pending, etc.)
		k_EResultAccountLimitExceeded = 95,			// Too many accounts access this resource
		k_EResultAccountActivityLimitExceeded = 96,	// Too many changes to this account
		k_EResultPhoneActivityLimitExceeded = 97,	// Too many changes to this phone
		k_EResultRefundToWallet = 98,				// Cannot refund to payment method, must use wallet
		k_EResultEmailSendFailure = 99,				// Cannot send an email
		k_EResultNotSettled = 100,					// Can't perform operation till payment has settled
		k_EResultNeedCaptcha = 101,					// Needs to provide a valid captcha
		k_EResultGSLTDenied = 102,					// a game server login token owned by this token's owner has been banned
		k_EResultGSOwnerDenied = 103,				// game server owner is denied for other reason (account lock, community ban, vac ban, missing phone)
		k_EResultInvalidItemType = 104,				// the type of thing we were requested to act on is invalid
		k_EResultIPBanned = 105,					// the ip address has been banned from taking this action
		k_EResultGSLTExpired = 106,					// this token has expired from disuse; can be reset for use
		k_EResultInsufficientFunds = 107,			// user doesn't have enough wallet funds to complete the action
		k_EResultTooManyPending = 108,				// There are too many of this thing pending already
		k_EResultNoSiteLicensesFound = 109,			// No site licenses found
		k_EResultWGNetworkSendExceeded = 110,		// the WG couldn't send a response because we exceeded max network send size
		k_EResultAccountNotFriends = 111,			// the user is not mutually friends
		k_EResultLimitedUserAccount = 112,			// the user is limited
		k_EResultCantRemoveItem = 113,				// item can't be removed
	}

	// Error codes for use with the voice functions
	public enum EVoiceResult : int {
		k_EVoiceResultOK = 0,
		k_EVoiceResultNotInitialized = 1,
		k_EVoiceResultNotRecording = 2,
		k_EVoiceResultNoData = 3,
		k_EVoiceResultBufferTooSmall = 4,
		k_EVoiceResultDataCorrupted = 5,
		k_EVoiceResultRestricted = 6,
		k_EVoiceResultUnsupportedCodec = 7,
		k_EVoiceResultReceiverOutOfDate = 8,
		k_EVoiceResultReceiverDidNotAnswer = 9,

	}

	// Result codes to GSHandleClientDeny/Kick
	public enum EDenyReason : int {
		k_EDenyInvalid = 0,
		k_EDenyInvalidVersion = 1,
		k_EDenyGeneric = 2,
		k_EDenyNotLoggedOn = 3,
		k_EDenyNoLicense = 4,
		k_EDenyCheater = 5,
		k_EDenyLoggedInElseWhere = 6,
		k_EDenyUnknownText = 7,
		k_EDenyIncompatibleAnticheat = 8,
		k_EDenyMemoryCorruption = 9,
		k_EDenyIncompatibleSoftware = 10,
		k_EDenySteamConnectionLost = 11,
		k_EDenySteamConnectionError = 12,
		k_EDenySteamResponseTimedOut = 13,
		k_EDenySteamValidationStalled = 14,
		k_EDenySteamOwnerLeftGuestUser = 15,
	}

	// results from BeginAuthSession
	public enum EBeginAuthSessionResult : int {
		k_EBeginAuthSessionResultOK = 0,						// Ticket is valid for this game and this steamID.
		k_EBeginAuthSessionResultInvalidTicket = 1,				// Ticket is not valid.
		k_EBeginAuthSessionResultDuplicateRequest = 2,			// A ticket has already been submitted for this steamID
		k_EBeginAuthSessionResultInvalidVersion = 3,			// Ticket is from an incompatible interface version
		k_EBeginAuthSessionResultGameMismatch = 4,				// Ticket is not for this game
		k_EBeginAuthSessionResultExpiredTicket = 5,				// Ticket has expired
	}

	// Callback values for callback ValidateAuthTicketResponse_t which is a response to BeginAuthSession
	public enum EAuthSessionResponse : int {
		k_EAuthSessionResponseOK = 0,							// Steam has verified the user is online, the ticket is valid and ticket has not been reused.
		k_EAuthSessionResponseUserNotConnectedToSteam = 1,		// The user in question is not connected to steam
		k_EAuthSessionResponseNoLicenseOrExpired = 2,			// The license has expired.
		k_EAuthSessionResponseVACBanned = 3,					// The user is VAC banned for this game.
		k_EAuthSessionResponseLoggedInElseWhere = 4,			// The user account has logged in elsewhere and the session containing the game instance has been disconnected.
		k_EAuthSessionResponseVACCheckTimedOut = 5,				// VAC has been unable to perform anti-cheat checks on this user
		k_EAuthSessionResponseAuthTicketCanceled = 6,			// The ticket has been canceled by the issuer
		k_EAuthSessionResponseAuthTicketInvalidAlreadyUsed = 7,	// This ticket has already been used, it is not valid.
		k_EAuthSessionResponseAuthTicketInvalid = 8,			// This ticket is not from a user instance currently connected to steam.
		k_EAuthSessionResponsePublisherIssuedBan = 9,			// The user is banned for this game. The ban came via the web api and not VAC
	}

	// results from UserHasLicenseForApp
	public enum EUserHasLicenseForAppResult : int {
		k_EUserHasLicenseResultHasLicense = 0,					// User has a license for specified app
		k_EUserHasLicenseResultDoesNotHaveLicense = 1,			// User does not have a license for the specified app
		k_EUserHasLicenseResultNoAuth = 2,						// User has not been authenticated
	}

	// Steam account types
	public enum EAccountType : int {
		k_EAccountTypeInvalid = 0,
		k_EAccountTypeIndividual = 1,		// single user account
		k_EAccountTypeMultiseat = 2,		// multiseat (e.g. cybercafe) account
		k_EAccountTypeGameServer = 3,		// game server account
		k_EAccountTypeAnonGameServer = 4,	// anonymous game server account
		k_EAccountTypePending = 5,			// pending
		k_EAccountTypeContentServer = 6,	// content server
		k_EAccountTypeClan = 7,
		k_EAccountTypeChat = 8,
		k_EAccountTypeConsoleUser = 9,		// Fake SteamID for local PSN account on PS3 or Live account on 360, etc.
		k_EAccountTypeAnonUser = 10,

		// Max of 16 items in this field
		k_EAccountTypeMax
	}

	//-----------------------------------------------------------------------------
	// Purpose:
	//-----------------------------------------------------------------------------
	public enum EAppReleaseState : int {
		k_EAppReleaseState_Unknown			= 0,	// unknown, required appinfo or license info is missing
		k_EAppReleaseState_Unavailable		= 1,	// even if user 'just' owns it, can see game at all
		k_EAppReleaseState_Prerelease		= 2,	// can be purchased and is visible in games list, nothing else. Common appInfo section released
		k_EAppReleaseState_PreloadOnly		= 3,	// owners can preload app, not play it. AppInfo fully released.
		k_EAppReleaseState_Released			= 4,	// owners can download and play app.
	}

	//-----------------------------------------------------------------------------
	// Purpose:
	//-----------------------------------------------------------------------------
	[Flags]
	public enum EAppOwnershipFlags : int {
		k_EAppOwnershipFlags_None				= 0x0000,	// unknown
		k_EAppOwnershipFlags_OwnsLicense		= 0x0001,	// owns license for this game
		k_EAppOwnershipFlags_FreeLicense		= 0x0002,	// not paid for game
		k_EAppOwnershipFlags_RegionRestricted	= 0x0004,	// owns app, but not allowed to play in current region
		k_EAppOwnershipFlags_LowViolence		= 0x0008,	// only low violence version
		k_EAppOwnershipFlags_InvalidPlatform	= 0x0010,	// app not supported on current platform
		k_EAppOwnershipFlags_SharedLicense		= 0x0020,	// license was granted by authorized local device
		k_EAppOwnershipFlags_FreeWeekend		= 0x0040,	// owned by a free weekend licenses
		k_EAppOwnershipFlags_RetailLicense		= 0x0080,	// has a retail license for game, (CD-Key etc)
		k_EAppOwnershipFlags_LicenseLocked		= 0x0100,	// shared license is locked (in use) by other user
		k_EAppOwnershipFlags_LicensePending		= 0x0200,	// owns app, but transaction is still pending. Can't install or play
		k_EAppOwnershipFlags_LicenseExpired		= 0x0400,	// doesn't own app anymore since license expired
		k_EAppOwnershipFlags_LicensePermanent	= 0x0800,	// permanent license, not borrowed, or guest or freeweekend etc
		k_EAppOwnershipFlags_LicenseRecurring	= 0x1000,	// Recurring license, user is charged periodically
		k_EAppOwnershipFlags_LicenseCanceled	= 0x2000,	// Mark as canceled, but might be still active if recurring
		k_EAppOwnershipFlags_AutoGrant			= 0x4000,	// Ownership is based on any kind of autogrant license
		k_EAppOwnershipFlags_PendingGift		= 0x8000,	// user has pending gift to redeem
		k_EAppOwnershipFlags_RentalNotActivated	= 0x10000,	// Rental hasn't been activated yet
		k_EAppOwnershipFlags_Rental				= 0x20000,	// Is a rental
		k_EAppOwnershipFlags_SiteLicense		= 0x40000,	// Is from a site license
	}

	//-----------------------------------------------------------------------------
	// Purpose: designed as flags to allow filters masks
	// NOTE: If you add to this, please update PackageAppType (SteamConfig) as well as populatePackageAppType
	//-----------------------------------------------------------------------------
	[Flags]
	public enum EAppType : int {
		k_EAppType_Invalid				= 0x000,	// unknown / invalid
		k_EAppType_Game					= 0x001,	// playable game, default type
		k_EAppType_Application			= 0x002,	// software application
		k_EAppType_Tool					= 0x004,	// SDKs, editors & dedicated servers
		k_EAppType_Demo					= 0x008,	// game demo
		k_EAppType_Media_DEPRECATED		= 0x010,	// legacy - was used for game trailers, which are now just videos on the web
		k_EAppType_DLC					= 0x020,	// down loadable content
		k_EAppType_Guide				= 0x040,	// game guide, PDF etc
		k_EAppType_Driver				= 0x080,	// hardware driver updater (ATI, Razor etc)
		k_EAppType_Config				= 0x100,	// hidden app used to config Steam features (backpack, sales, etc)
		k_EAppType_Hardware				= 0x200,	// a hardware device (Steam Machine, Steam Controller, Steam Link, etc.)
		k_EAppType_Franchise			= 0x400,	// A hub for collections of multiple apps, eg films, series, games
		k_EAppType_Video				= 0x800,	// A video component of either a Film or TVSeries (may be the feature, an episode, preview, making-of, etc)
		k_EAppType_Plugin				= 0x1000,	// Plug-in types for other Apps
		k_EAppType_Music				= 0x2000,	// Music files
		k_EAppType_Series				= 0x4000,	// Container app for video series
		k_EAppType_Comic				= 0x8000,	// Comic Book

		k_EAppType_Shortcut				= 0x40000000,	// just a shortcut, client side only
		k_EAppType_DepotOnly			= -2147483647,	// placeholder since depots and apps share the same namespace
	}

	//-----------------------------------------------------------------------------
	// types of user game stats fields
	// WARNING: DO NOT RENUMBER EXISTING VALUES - STORED IN DATABASE
	//-----------------------------------------------------------------------------
	public enum ESteamUserStatType : int {
		k_ESteamUserStatTypeINVALID = 0,
		k_ESteamUserStatTypeINT = 1,
		k_ESteamUserStatTypeFLOAT = 2,
		// Read as FLOAT, set with count / session length
		k_ESteamUserStatTypeAVGRATE = 3,
		k_ESteamUserStatTypeACHIEVEMENTS = 4,
		k_ESteamUserStatTypeGROUPACHIEVEMENTS = 5,

		// max, for sanity checks
		k_ESteamUserStatTypeMAX
	}

	//-----------------------------------------------------------------------------
	// Purpose: Chat Entry Types (previously was only friend-to-friend message types)
	//-----------------------------------------------------------------------------
	public enum EChatEntryType : int {
		k_EChatEntryTypeInvalid = 0,
		k_EChatEntryTypeChatMsg = 1,		// Normal text message from another user
		k_EChatEntryTypeTyping = 2,			// Another user is typing (not used in multi-user chat)
		k_EChatEntryTypeInviteGame = 3,		// Invite from other user into that users current game
		k_EChatEntryTypeEmote = 4,			// text emote message (deprecated, should be treated as ChatMsg)
		//k_EChatEntryTypeLobbyGameStart = 5,	// lobby game is starting (dead - listen for LobbyGameCreated_t callback instead)
		k_EChatEntryTypeLeftConversation = 6, // user has left the conversation ( closed chat window )
		// Above are previous FriendMsgType entries, now merged into more generic chat entry types
		k_EChatEntryTypeEntered = 7,		// user has entered the conversation (used in multi-user chat and group chat)
		k_EChatEntryTypeWasKicked = 8,		// user was kicked (data: 64-bit steamid of actor performing the kick)
		k_EChatEntryTypeWasBanned = 9,		// user was banned (data: 64-bit steamid of actor performing the ban)
		k_EChatEntryTypeDisconnected = 10,	// user disconnected
		k_EChatEntryTypeHistoricalChat = 11,	// a chat message from user's chat history or offilne message
		//k_EChatEntryTypeReserved1 = 12, // No longer used
		//k_EChatEntryTypeReserved2 = 13, // No longer used
		k_EChatEntryTypeLinkBlocked = 14, // a link was removed by the chat filter.
	}

	//-----------------------------------------------------------------------------
	// Purpose: Chat Room Enter Responses
	//-----------------------------------------------------------------------------
	public enum EChatRoomEnterResponse : int {
		k_EChatRoomEnterResponseSuccess = 1,		// Success
		k_EChatRoomEnterResponseDoesntExist = 2,	// Chat doesn't exist (probably closed)
		k_EChatRoomEnterResponseNotAllowed = 3,		// General Denied - You don't have the permissions needed to join the chat
		k_EChatRoomEnterResponseFull = 4,			// Chat room has reached its maximum size
		k_EChatRoomEnterResponseError = 5,			// Unexpected Error
		k_EChatRoomEnterResponseBanned = 6,			// You are banned from this chat room and may not join
		k_EChatRoomEnterResponseLimited = 7,		// Joining this chat is not allowed because you are a limited user (no value on account)
		k_EChatRoomEnterResponseClanDisabled = 8,	// Attempt to join a clan chat when the clan is locked or disabled
		k_EChatRoomEnterResponseCommunityBan = 9,	// Attempt to join a chat when the user has a community lock on their account
		k_EChatRoomEnterResponseMemberBlockedYou = 10, // Join failed - some member in the chat has blocked you from joining
		k_EChatRoomEnterResponseYouBlockedMember = 11, // Join failed - you have blocked some member already in the chat
		// k_EChatRoomEnterResponseNoRankingDataLobby = 12,  // No longer used
		// k_EChatRoomEnterResponseNoRankingDataUser = 13,  //  No longer used
		// k_EChatRoomEnterResponseRankOutOfRange = 14, //  No longer used
		k_EChatRoomEnterResponseRatelimitExceeded = 15, // Join failed - to many join attempts in a very short period of time
	}

	// Special flags for Chat accounts - they go in the top 8 bits
	// of the steam ID's "instance", leaving 12 for the actual instances
	[Flags]
	public enum EChatSteamIDInstanceFlags : int {
		k_EChatAccountInstanceMask = 0x00000FFF, // top 8 bits are flags

		k_EChatInstanceFlagClan = ( Constants.k_unSteamAccountInstanceMask + 1 ) >> 1,	// top bit
		k_EChatInstanceFlagLobby = ( Constants.k_unSteamAccountInstanceMask + 1 ) >> 2,	// next one down, etc
		k_EChatInstanceFlagMMSLobby = ( Constants.k_unSteamAccountInstanceMask + 1 ) >> 3,	// next one down, etc

		// Max of 8 flags
	}

	//-----------------------------------------------------------------------------
	// Purpose: Marketing message flags that change how a client should handle them
	//-----------------------------------------------------------------------------
	[Flags]
	public enum EMarketingMessageFlags : int {
		k_EMarketingMessageFlagsNone = 0,
		k_EMarketingMessageFlagsHighPriority = 1 << 0,
		k_EMarketingMessageFlagsPlatformWindows = 1 << 1,
		k_EMarketingMessageFlagsPlatformMac = 1 << 2,
		k_EMarketingMessageFlagsPlatformLinux = 1 << 3,

		//aggregate flags
		k_EMarketingMessageFlagsPlatformRestrictions =
		k_EMarketingMessageFlagsPlatformWindows |
		k_EMarketingMessageFlagsPlatformMac |
		k_EMarketingMessageFlagsPlatformLinux,
	}

	//-----------------------------------------------------------------------------
	// Purpose: Possible positions to tell the overlay to show notifications in
	//-----------------------------------------------------------------------------
	public enum ENotificationPosition : int {
		k_EPositionTopLeft = 0,
		k_EPositionTopRight = 1,
		k_EPositionBottomLeft = 2,
		k_EPositionBottomRight = 3,
	}

	//-----------------------------------------------------------------------------
	// Purpose: Broadcast upload result details
	//-----------------------------------------------------------------------------
	public enum EBroadcastUploadResult : int {
		k_EBroadcastUploadResultNone = 0,	// broadcast state unknown
		k_EBroadcastUploadResultOK = 1,		// broadcast was good, no problems
		k_EBroadcastUploadResultInitFailed = 2,	// broadcast init failed
		k_EBroadcastUploadResultFrameFailed = 3,	// broadcast frame upload failed
		k_EBroadcastUploadResultTimeout = 4,	// broadcast upload timed out
		k_EBroadcastUploadResultBandwidthExceeded = 5,	// broadcast send too much data
		k_EBroadcastUploadResultLowFPS = 6,	// broadcast FPS too low
		k_EBroadcastUploadResultMissingKeyFrames = 7,	// broadcast sending not enough key frames
		k_EBroadcastUploadResultNoConnection = 8,	// broadcast client failed to connect to relay
		k_EBroadcastUploadResultRelayFailed = 9,	// relay dropped the upload
		k_EBroadcastUploadResultSettingsChanged = 10,	// the client changed broadcast settings
		k_EBroadcastUploadResultMissingAudio = 11,	// client failed to send audio data
		k_EBroadcastUploadResultTooFarBehind = 12,	// clients was too slow uploading
		k_EBroadcastUploadResultTranscodeBehind = 13,	// server failed to keep up with transcode
		k_EBroadcastUploadResultNotAllowedToPlay = 14, // Broadcast does not have permissions to play game
		k_EBroadcastUploadResultBusy = 15, // RTMP host to busy to take new broadcast stream, choose another
		k_EBroadcastUploadResultBanned = 16, // Account banned from community broadcast
		k_EBroadcastUploadResultAlreadyActive = 17, // We already already have an stream running.
		k_EBroadcastUploadResultForcedOff = 18, // We explicitly shutting down a broadcast
		k_EBroadcastUploadResultAudioBehind = 19, // Audio stream was too far behind video
		k_EBroadcastUploadResultShutdown = 20,	// Broadcast Server was shut down
		k_EBroadcastUploadResultDisconnect = 21,	// broadcast uploader TCP disconnected
		k_EBroadcastUploadResultVideoInitFailed = 22,	// invalid video settings
		k_EBroadcastUploadResultAudioInitFailed = 23,	// invalid audio settings
	}

	//-----------------------------------------------------------------------------
	// Purpose: codes for well defined launch options
	//-----------------------------------------------------------------------------
	public enum ELaunchOptionType : int {
		k_ELaunchOptionType_None		= 0,	// unknown what launch option does
		k_ELaunchOptionType_Default		= 1,	// runs the game, app, whatever in default mode
		k_ELaunchOptionType_SafeMode	= 2,	// runs the game in safe mode
		k_ELaunchOptionType_Multiplayer = 3,	// runs the game in multiplayer mode
		k_ELaunchOptionType_Config		= 4,	// runs config tool for this game
		k_ELaunchOptionType_OpenVR		= 5,	// runs game in VR mode using OpenVR
		k_ELaunchOptionType_Server		= 6,	// runs dedicated server for this game
		k_ELaunchOptionType_Editor		= 7,	// runs game editor
		k_ELaunchOptionType_Manual		= 8,	// shows game manual
		k_ELaunchOptionType_Benchmark	= 9,	// runs game benchmark
		k_ELaunchOptionType_Option1		= 10,	// generic run option, uses description field for game name
		k_ELaunchOptionType_Option2		= 11,	// generic run option, uses description field for game name
		k_ELaunchOptionType_Option3     = 12,	// generic run option, uses description field for game name
		k_ELaunchOptionType_OculusVR	= 13,	// runs game in VR mode using the Oculus SDK
		k_ELaunchOptionType_OpenVROverlay = 14,	// runs an OpenVR dashboard overlay
		k_ELaunchOptionType_OSVR		= 15,	// runs game in VR mode using the OSVR SDK


		k_ELaunchOptionType_Dialog 		= 1000, // show launch options dialog
	}

	//-----------------------------------------------------------------------------
	// Purpose: code points for VR HMD vendors and models
	// WARNING: DO NOT RENUMBER EXISTING VALUES - STORED IN A DATABASE
	//-----------------------------------------------------------------------------
	public enum EVRHMDType : int {
		k_eEVRHMDType_None = -1, // unknown vendor and model

		k_eEVRHMDType_Unknown = 0, // unknown vendor and model

		k_eEVRHMDType_HTC_Dev = 1,	// original HTC dev kits
		k_eEVRHMDType_HTC_VivePre = 2,	// htc vive pre
		k_eEVRHMDType_HTC_Vive = 3,	// htc vive consumer release
		k_eEVRHMDType_HTC_VivePro = 4,	// htc vive pro release

		k_eEVRHMDType_HTC_Unknown = 20, // unknown htc hmd

		k_eEVRHMDType_Oculus_DK1 = 21, // Oculus DK1
		k_eEVRHMDType_Oculus_DK2 = 22, // Oculus DK2
		k_eEVRHMDType_Oculus_Rift = 23, // Oculus rift

		k_eEVRHMDType_Oculus_Unknown = 40, // // Oculus unknown HMD

		k_eEVRHMDType_Acer_Unknown = 50, // Acer unknown HMD
		k_eEVRHMDType_Acer_WindowsMR = 51, // Acer QHMD Windows MR headset

		k_eEVRHMDType_Dell_Unknown = 60, // Dell unknown HMD
		k_eEVRHMDType_Dell_Visor = 61, // Dell Visor Windows MR headset

		k_eEVRHMDType_Lenovo_Unknown = 70, // Lenovo unknown HMD
		k_eEVRHMDType_Lenovo_Explorer = 71, // Lenovo Explorer Windows MR headset

		k_eEVRHMDType_HP_Unknown = 80, // HP unknown HMD
		k_eEVRHMDType_HP_WindowsMR = 81, // HP Windows MR headset

		k_eEVRHMDType_Samsung_Unknown = 90, // Samsung unknown HMD
		k_eEVRHMDType_Samsung_Odyssey = 91, // Samsung Odyssey Windows MR headset

		k_eEVRHMDType_Unannounced_Unknown = 100, // Unannounced unknown HMD
		k_eEVRHMDType_Unannounced_WindowsMR = 101, // Unannounced Windows MR headset

		k_eEVRHMDType_vridge = 110, // VRIDGE tool

		k_eEVRHMDType_Huawei_Unknown = 120, // Huawei unknown HMD
		k_eEVRHMDType_Huawei_VR2 = 121, // Huawei VR2 3DOF headset
		k_eEVRHMDType_Huawei_EndOfRange = 129, // end of Huawei HMD range

	}

	//-----------------------------------------------------------------------------
	// Purpose: Reasons a user may not use the Community Market.
	//          Used in MarketEligibilityResponse_t.
	//-----------------------------------------------------------------------------
	[Flags]
	public enum EMarketNotAllowedReasonFlags : int {
		k_EMarketNotAllowedReason_None = 0,

		// A back-end call failed or something that might work again on retry
		k_EMarketNotAllowedReason_TemporaryFailure = (1 << 0),

		// Disabled account
		k_EMarketNotAllowedReason_AccountDisabled = (1 << 1),

		// Locked account
		k_EMarketNotAllowedReason_AccountLockedDown = (1 << 2),

		// Limited account (no purchases)
		k_EMarketNotAllowedReason_AccountLimited = (1 << 3),

		// The account is banned from trading items
		k_EMarketNotAllowedReason_TradeBanned = (1 << 4),

		// Wallet funds aren't tradable because the user has had no purchase
		// activity in the last year or has had no purchases prior to last month
		k_EMarketNotAllowedReason_AccountNotTrusted = (1 << 5),

		// The user doesn't have Steam Guard enabled
		k_EMarketNotAllowedReason_SteamGuardNotEnabled = (1 << 6),

		// The user has Steam Guard, but it hasn't been enabled for the required
		// number of days
		k_EMarketNotAllowedReason_SteamGuardOnlyRecentlyEnabled = (1 << 7),

		// The user has recently forgotten their password and reset it
		k_EMarketNotAllowedReason_RecentPasswordReset = (1 << 8),

		// The user has recently funded his or her wallet with a new payment method
		k_EMarketNotAllowedReason_NewPaymentMethod = (1 << 9),

		// An invalid cookie was sent by the user
		k_EMarketNotAllowedReason_InvalidCookie = (1 << 10),

		// The user has Steam Guard, but is using a new computer or web browser
		k_EMarketNotAllowedReason_UsingNewDevice = (1 << 11),

		// The user has recently refunded a store purchase by his or herself
		k_EMarketNotAllowedReason_RecentSelfRefund = (1 << 12),

		// The user has recently funded his or her wallet with a new payment method that cannot be verified
		k_EMarketNotAllowedReason_NewPaymentMethodCannotBeVerified = (1 << 13),

		// Not only is the account not trusted, but they have no recent purchases at all
		k_EMarketNotAllowedReason_NoRecentPurchases = (1 << 14),

		// User accepted a wallet gift that was recently purchased
		k_EMarketNotAllowedReason_AcceptedWalletGift = (1 << 15),
	}

	public enum EGameSearchErrorCode_t : int {
		k_EGameSearchErrorCode_OK = 1,
		k_EGameSearchErrorCode_Failed_Search_Already_In_Progress = 2,
		k_EGameSearchErrorCode_Failed_No_Search_In_Progress = 3,
		k_EGameSearchErrorCode_Failed_Not_Lobby_Leader = 4, // if not the lobby leader can not call SearchForGameWithLobby
		k_EGameSearchErrorCode_Failed_No_Host_Available = 5, // no host is available that matches those search params
		k_EGameSearchErrorCode_Failed_Search_Params_Invalid = 6, // search params are invalid
		k_EGameSearchErrorCode_Failed_Offline = 7, // offline, could not communicate with server
		k_EGameSearchErrorCode_Failed_NotAuthorized = 8, // either the user or the application does not have priveledges to do this
		k_EGameSearchErrorCode_Failed_Unknown_Error = 9, // unknown error
	}

	public enum EPlayerResult_t : int {
		k_EPlayerResultFailedToConnect = 1, // failed to connect after confirming
		k_EPlayerResultAbandoned = 2,		// quit game without completing it
		k_EPlayerResultKicked = 3,			// kicked by other players/moderator/server rules
		k_EPlayerResultIncomplete = 4,		// player stayed to end but game did not conclude successfully ( nofault to player )
		k_EPlayerResultCompleted = 5,		// player completed game
	}

	// HTTP related types
	// This enum is used in client API methods, do not re-number existing values.
	public enum EHTTPMethod : int {
		k_EHTTPMethodInvalid = 0,
		k_EHTTPMethodGET,
		k_EHTTPMethodHEAD,
		k_EHTTPMethodPOST,
		k_EHTTPMethodPUT,
		k_EHTTPMethodDELETE,
		k_EHTTPMethodOPTIONS,
		k_EHTTPMethodPATCH,

		// The remaining HTTP methods are not yet supported, per rfc2616 section 5.1.1 only GET and HEAD are required for
		// a compliant general purpose server.  We'll likely add more as we find uses for them.

		// k_EHTTPMethodTRACE,
		// k_EHTTPMethodCONNECT
	}

	// HTTP Status codes that the server can send in response to a request, see rfc2616 section 10.3 for descriptions
	// of each of these.
	public enum EHTTPStatusCode : int {
		// Invalid status code (this isn't defined in HTTP, used to indicate unset in our code)
		k_EHTTPStatusCodeInvalid =					0,

		// Informational codes
		k_EHTTPStatusCode100Continue =				100,
		k_EHTTPStatusCode101SwitchingProtocols =	101,

		// Success codes
		k_EHTTPStatusCode200OK =					200,
		k_EHTTPStatusCode201Created =				201,
		k_EHTTPStatusCode202Accepted =				202,
		k_EHTTPStatusCode203NonAuthoritative =		203,
		k_EHTTPStatusCode204NoContent =				204,
		k_EHTTPStatusCode205ResetContent =			205,
		k_EHTTPStatusCode206PartialContent =		206,

		// Redirection codes
		k_EHTTPStatusCode300MultipleChoices =		300,
		k_EHTTPStatusCode301MovedPermanently =		301,
		k_EHTTPStatusCode302Found =					302,
		k_EHTTPStatusCode303SeeOther =				303,
		k_EHTTPStatusCode304NotModified =			304,
		k_EHTTPStatusCode305UseProxy =				305,
		//k_EHTTPStatusCode306Unused =				306, (used in old HTTP spec, now unused in 1.1)
		k_EHTTPStatusCode307TemporaryRedirect =		307,

		// Error codes
		k_EHTTPStatusCode400BadRequest =			400,
		k_EHTTPStatusCode401Unauthorized =			401, // You probably want 403 or something else. 401 implies you're sending a WWW-Authenticate header and the client can sent an Authorization header in response.
		k_EHTTPStatusCode402PaymentRequired =		402, // This is reserved for future HTTP specs, not really supported by clients
		k_EHTTPStatusCode403Forbidden =				403,
		k_EHTTPStatusCode404NotFound =				404,
		k_EHTTPStatusCode405MethodNotAllowed =		405,
		k_EHTTPStatusCode406NotAcceptable =			406,
		k_EHTTPStatusCode407ProxyAuthRequired =		407,
		k_EHTTPStatusCode408RequestTimeout =		408,
		k_EHTTPStatusCode409Conflict =				409,
		k_EHTTPStatusCode410Gone =					410,
		k_EHTTPStatusCode411LengthRequired =		411,
		k_EHTTPStatusCode412PreconditionFailed =	412,
		k_EHTTPStatusCode413RequestEntityTooLarge =	413,
		k_EHTTPStatusCode414RequestURITooLong =		414,
		k_EHTTPStatusCode415UnsupportedMediaType =	415,
		k_EHTTPStatusCode416RequestedRangeNotSatisfiable = 416,
		k_EHTTPStatusCode417ExpectationFailed =		417,
		k_EHTTPStatusCode4xxUnknown = 				418, // 418 is reserved, so we'll use it to mean unknown
		k_EHTTPStatusCode429TooManyRequests	=		429,

		// Server error codes
		k_EHTTPStatusCode500InternalServerError =	500,
		k_EHTTPStatusCode501NotImplemented =		501,
		k_EHTTPStatusCode502BadGateway =			502,
		k_EHTTPStatusCode503ServiceUnavailable =	503,
		k_EHTTPStatusCode504GatewayTimeout =		504,
		k_EHTTPStatusCode505HTTPVersionNotSupported = 505,
		k_EHTTPStatusCode5xxUnknown =				599,
	}

	// Steam universes.  Each universe is a self-contained Steam instance.
	public enum EUniverse : int {
		k_EUniverseInvalid = 0,
		k_EUniversePublic = 1,
		k_EUniverseBeta = 2,
		k_EUniverseInternal = 3,
		k_EUniverseDev = 4,
		// k_EUniverseRC = 5,				// no such universe anymore
		k_EUniverseMax
	}

}
