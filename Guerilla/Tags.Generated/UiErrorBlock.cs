// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class UiErrorBlock : UiErrorBlockBase
    {
        public  UiErrorBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class UiErrorBlockBase : GuerillaBlock
    {
        internal Error error;
        internal Flags flags;
        internal DefaultButton defaultButton;
        internal byte[] invalidName_;
        internal Moonfish.Tags.StringID title;
        internal Moonfish.Tags.StringID message;
        internal Moonfish.Tags.StringID ok;
        internal Moonfish.Tags.StringID cancel;
        
        public override int SerializedSize{get { return 24; }}
        
        internal  UiErrorBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            error = (Error)binaryReader.ReadInt32();
            flags = (Flags)binaryReader.ReadInt16();
            defaultButton = (DefaultButton)binaryReader.ReadByte();
            invalidName_ = binaryReader.ReadBytes(1);
            title = binaryReader.ReadStringID();
            message = binaryReader.ReadStringID();
            ok = binaryReader.ReadStringID();
            cancel = binaryReader.ReadStringID();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)error);
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write((Byte)defaultButton);
                binaryWriter.Write(invalidName_, 0, 1);
                binaryWriter.Write(title);
                binaryWriter.Write(message);
                binaryWriter.Write(ok);
                binaryWriter.Write(cancel);
                return nextAddress;
            }
        }
        internal enum Error : int
        {
            ErrorUnknown = 0,
            ErrorGeneric = 1,
            ErrorGenericNetworking = 2,
            ErrorSystemLinkGenericJoinFailure = 3,
            ErrorSystemLinkNoNetworkConnection = 4,
            ErrorSystemLinkConnectionLost = 5,
            ErrorNetworkGameOos = 6,
            ErrorXboxLiveSignOutConfirmation = 7,
            ErrorConfirmRevertToLastSave = 8,
            ErrorConfirmQuitWithoutSave = 9,
            ErrorConfirmDeletePlayerProfile = 10,
            ErrorConfirmDeleteVariantFile = 11,
            ErrorPlayerProfileCreationFailed = 12,
            ErrorVariantProfileCreationFailed = 13,
            ErrorPlaylistCreationFailed = 14,
            ErrorCoreFileLoadFailed = 15,
            ErrorMuRemovedDuringPlayerProfileSave = 16,
            ErrorMuRemovedDuringVariantSave = 17,
            ErrorMuRemovedDuringPlaylistSave = 18,
            ErrorMessageSavingToMu = 19,
            ErrorMessageSavingFile = 20,
            ErrorMessageCreatingPlayerProfile = 21,
            ErrorMessageCreatingVariantProfile = 22,
            ErrorMessageSavingCheckpoint = 23,
            ErrorFailedToLoadPlayerProfile = 24,
            ErrorFailedToLoadVariant = 25,
            ErrorFailedToLoadPlaylist = 26,
            ErrorFailedToLoadSaveGame = 27,
            ErrorController1Removed = 28,
            ErrorController2Removed = 29,
            ErrorController3Removed = 30,
            ErrorController4Removed = 31,
            ErrorNeedMoreFreeBlocksToSave = 32,
            ErrorMaximumSavedGameFilesAlreadyExist = 33,
            ErrorDirtyDisk = 34,
            ErrorXbliveCannotAccessService = 35,
            ErrorXbliveTitleUpdateRequired = 36,
            ErrorXbliveServersTooBusy = 37,
            ErrorXbliveDuplicateLogon = 38,
            ErrorXbliveAccountManagementRequired = 39,
            ErrorWarningXbliveRecommendedMessagesAvailable = 40,
            ErrorXbliveInvalidMatchSession = 41,
            ErrorWarningXblivePoorNetworkPerformance = 42,
            ErrorNotEnoughOpenSlotsToJoinMatchSession = 43,
            ErrorXbliveCorruptDownloadContent = 44,
            ErrorConfirmXbliveCorruptSavedGameFileRemoval = 45,
            ErrorXbliveInvalidUserAccount = 46,
            ErrorConfirmBootClanMember = 47,
            ErrorConfirmControllerSignOut = 48,
            ErrorBetaXbliveServiceQosReport = 49,
            ErrorBetaFeatureDisabled = 50,
            ErrorBetaNetworkConnectionRequired = 51,
            ErrorConfirmFriendRemoval = 52,
            ErrorConfirmBootToDash = 53,
            ErrorConfirmLaunchXdemos = 54,
            ErrorConfirmExitGameSession = 55,
            ErrorXbliveConnectionToXboxLiveLost = 56,
            ErrorXbliveMessageSendFailure = 57,
            ErrorNetworkLinkLost = 58,
            ErrorNetworkLinkRequired = 59,
            ErrorXbliveInvalidPasscode = 60,
            ErrorJoinAborted = 61,
            ErrorJoinSessionNotFound = 62,
            ErrorJoinQosFailure = 63,
            ErrorJoinDataDecodeFailure = 64,
            ErrorJoinGameFull = 65,
            ErrorJoinGameClosed = 66,
            ErrorJoinVersionMismatch = 67,
            ErrorJoinFailedUnknownReason = 68,
            ErrorJoinFailedFriendInMatchmadeGame = 69,
            ErrorPlayerProfileNameMustBeUnique = 70,
            ErrorVariantNameMustBeUnique = 71,
            ErrorPlaylistNameMustBeUnique = 72,
            ErrorSavedFilmNameMustBeUnique = 73,
            ErrorNoFreeSlotsPlayerProfile = 74,
            ErrorNoFreeSlotsVariant = 75,
            ErrorNoFreeSlotsPlaylist = 76,
            ErrorNoFreeSlotsSavedFilm = 77,
            ErrorNeedMoreSpaceForPlayerProfile = 78,
            ErrorNeedMoreSpaceForVariant = 79,
            ErrorNeedMoreSpaceForPlaylist = 80,
            ErrorNeedMoreSpaceForSavedFilm = 81,
            ErrorCannotSetPrivilegesOnMemberWhoseDataNotKnown = 82,
            ErrorCantDeleteDefaultProfile = 83,
            ErrorCantDeleteDefaultVariant = 84,
            ErrorCantDeleteDefaultPlaylist = 85,
            ErrorCantDeleteDefaultSavedFilm = 86,
            ErrorCantDeleteProfileInUse = 87,
            ErrorPlayerProfileNameMustHaveAlphanumericCharacters = 88,
            ErrorVariantNameMustHaveAlphanumericCharacters = 89,
            ErrorPlaylistNameMustHaveAlphanumericCharacters = 90,
            ErrorSavedFilmNameMustHaveAlphanumericCharacters = 91,
            ErrorTeamsNotAMember = 92,
            ErrorTeamsInsufficientPrivileges = 93,
            ErrorTeamsServerBusy = 94,
            ErrorTeamsTeamFull = 95,
            ErrorTeamsMemberPending = 96,
            ErrorTeamsTooManyRequests = 97,
            ErrorTeamsUserAlreadyExists = 98,
            ErrorTeamsUserNotFound = 99,
            ErrorTeamsUserTeamsFull = 100,
            ErrorTeamsNoTask = 101,
            ErrorTeamsTooManyTeams = 102,
            ErrorTeamsTeamAlreadyExists = 103,
            ErrorTeamsTeamNotFound = 104,
            ErrorTeamsNameContainsBadWords = 105,
            ErrorTeamsDescriptionContainsBadWords = 106,
            ErrorTeamsMottoContainsBadWords = 107,
            ErrorTeamsUrlContainsBadWords = 108,
            ErrorTeamsNoAdmin = 109,
            ErrorTeamsCannotSetPrivilegesOnMemberWhoseDataNotKnown = 110,
            ErrorLiveUnknown = 111,
            ErrorConfirmDeleteProfile = 112,
            ErrorConfirmDeletePlaylist = 113,
            ErrorConfirmDeleteSavedFilm = 114,
            ErrorConfirmLiveSignOut = 115,
            ErrorConfirmConfirmFriendRemoval = 116,
            ErrorConfirmPromotionToSuperuser = 117,
            ErrorWarnNoMoreClanSuperusers = 118,
            ErrorConfirmCorruptProfile = 119,
            ErrorConfirmXboxLiveSignOut = 120,
            ErrorConfirmCorruptGameVariant = 121,
            ErrorConfirmLeaveClan = 122,
            ErrorConfirmCorruptPlaylist = 123,
            ErrorCantJoinGameinviteWithoutSignon = 124,
            ErrorConfirmProceedToCrossgameInvite = 125,
            ErrorConfirmDeclineCrossgameInvite = 126,
            ErrorWarnInsertCdForCrossgameInvite = 127,
            ErrorNeedMoreSpaceForSavedGame = 128,
            ErrorSavedGameCannotBeLoaded = 129,
            ErrorConfirmControllerSignoutWithGuests = 130,
            ErrorWarningPartyClosed = 131,
            ErrorWarningPartyRequired = 132,
            ErrorWarningPartyFull = 133,
            ErrorWarningPlayerInMmGame = 134,
            ErrorXbliveFailedToSignIn = 135,
            ErrorCantSignOutMasterWithGuests = 136,
            ErrorObsoleteDotCommand = 137,
            ErrorNotUnlocked = 138,
            ConfirmLeaveLobby = 139,
            ErrorConfirmPartyLeaderLeaveMatchmaking = 140,
            ErrorConfirmSingleBoxLeaveMatchmaking = 141,
            ErrorInvalidClanName = 142,
            ErrorPlayerListFull = 143,
            ErrorBlockedByPlayer = 144,
            ErrorFriendPending = 145,
            ErrorTooManyRequests = 146,
            ErrorPlayerAlreadyInList = 147,
            ErrorGamertagNotFound = 148,
            ErrorCannotMessageSelf = 149,
            ErrorWarningLastOverlordCantLeaveClan = 150,
            ErrorConfirmBootPlayer = 151,
            ErrorConfirmPartyMemberLeavePcr = 152,
            ErrorCannotSignInDuringCountdown = 153,
            ErrorXblInvalidUser = 154,
            ErrorXblUserNotAuthorized = 155,
            OBSOLETE = 156,
            OBSOLETE2 = 157,
            ErrorXblBannedXbox = 158,
            ErrorXblBannedUser = 159,
            ErrorXblBannedTitle = 160,
            ErrorConfirmExitGameSessionLeader = 161,
            ErrorMessageObjectionableContent = 162,
            ErrorConfirmEnterDownloader = 163,
            ErrorConfirmBlockUser = 164,
            ErrorConfirmNegativeFeedback = 165,
            ErrorConfirmChangeClanMemberLevel = 166,
            ErrorBlankGamertag = 167,
            ConfirmSaveQuitGame = 168,
            ErrorCantJoinDuringMatchmaking = 169,
            ErrorConfirmRestartLevel = 170,
            MatchmakingFailureGeneric = 171,
            MatchmakingFailureMissingContent = 172,
            MatchmakingFailureAborted = 173,
            MatchmakingFailureMembershipChanged = 174,
            ConfirmEndGameSession = 175,
            ConfirmExitGameSessionOnlyPlayer = 176,
            ConfirmExitGameSessionXboxLiveRankedLeader = 177,
            ConfirmExitGameSessionXboxLiveRanked = 178,
            ConfirmExitGameSessionXboxLiveLeader = 179,
            ConfirmExitGameSessionXboxLiveOnlyPlayer = 180,
            ConfirmExitGameSessionXboxLive = 181,
            RecipientsListFull = 182,
            ConfirmQuitCampaignNoSave = 183,
            XbliveConnectionToXboxLiveLostSaveAndQuit = 184,
            BootedFromSession = 185,
            ConfirmExitGameSessionXboxLiveGuest = 186,
            ConfirmExitGameSessionXboxLiveRankedOnlyPlayer = 187,
            ConfirmExitGameSessionXboxLiveUnrankedOnlyPlayer = 188,
            ConfirmExitGameSessionXboxLiveUnrankedLeader = 189,
            ConfirmExitGameSessionXboxLiveUnranked = 190,
            CantJoinFriendWhileInMatchmadeGame = 191,
            MapLoadFailure = 192,
            ErrorAchievementsInterrupted = 193,
            ConfirmLoseProgress = 194,
            ErrorBetaAchievementsDisabled = 195,
            ErrorCannotConnectVersionsWrong = 196,
            ConfirmBootedFromSession = 197,
            ConfirmBootPlayerFromSquad = 198,
            ConfirmLeaveSystemLinkLobby = 199,
            ConfirmPartyMemberLeaveMatchmaking = 200,
            ConfirmQuitSinglePlayer = 201,
            ErrorControllerRemoved = 202,
            ErrorDownloadInProgress = 203,
            ErrorDownloadFail = 204,
            ErrorFailedToLoadMap = 205,
            ErrorFeatureRequiresGold = 206,
            ErrorKeyboardMapping = 207,
            ErrorKeyboardRemoved = 208,
            ErrorLiveGameUnavailable = 209,
            ErrorMapMissing = 210,
            ErrorMatchmakingFailedGeneric = 211,
            ErrorMatchmakingFailedMissingContent = 212,
            ErrorMouseRemoved = 213,
            ErrorPartyNotAllOnLive = 214,
            ErrorPartySubnetNotShared = 215,
            ErrorRequiredGameUpdate = 216,
            ErrorSavedGameCannotBeSaved = 217,
            ErrorSoundMicrophoneNotSupported = 218,
            ErrorSystemLinkDirectIP = 219,
            ErrorTextChatMuted = 220,
            ErrorTextChatParentalControls = 221,
            ErrorUpdateStart = 222,
            ErrorUpdateFail = 223,
            ErrorUpdateFailBlocks = 224,
            ErrorUpdateExists = 225,
            ErrorInsertOriginal = 226,
            ErrorUpdateFailNetworkLost = 227,
            ErrorUpdateMpOutOfSync = 228,
            ErrorUpdateMustUpgrade = 229,
            ErrorVoiceGoldRequired = 230,
            ErrorVoiceParentalControls = 231,
            ErrorWarningXblivePoorNetworkPerofrmance = 232,
            ErrorYouMissingMap = 233,
            ErrorSomeoneMissingMap = 234,
            ErrorTnpNoSource = 235,
            ErrorTnpDiskRead = 236,
            ErrorTnpNoEngineRunning = 237,
            ErrorTnpSignatureVerification = 238,
            ErrorTnpDriveRemoved = 239,
            ErrorTnpDiskFull = 240,
            ErrorTnpPermissions = 241,
            ErrorTnpUnknown = 242,
            ContinueInstall = 243,
            CancelInstall = 244,
            ErrorConfirmUpsellGold = 245,
            ErrorAddToFavorites = 246,
            ErrorRemoveFromFavorites = 247,
            ErrorUpdatingFavorites = 248,
            ChooseExistingCheckpointLocation = 249,
            ChooseNewCheckpointLocationCheckpointsExistOnLiveAndLocal = 250,
            ChooseNewCheckpointLocationCheckpointsExistOnLive = 251,
            ChooseNewCheckpointLocationCheckpointsExistLocally = 252,
            Xxx = 253,
        };
        [FlagsAttribute]
        internal enum Flags : short
        {
            UseLargeDialog = 1,
        };
        internal enum DefaultButton : byte
        {
            NoDefault = 0,
            DefaultOk = 1,
            DefaultCancel = 2,
        };
    };
}
