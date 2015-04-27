// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Wgit = (TagClass)"wgit";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("wgit")]
    public partial class UserInterfaceScreenWidgetDefinitionBlock : UserInterfaceScreenWidgetDefinitionBlockBase
    {
        public  UserInterfaceScreenWidgetDefinitionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  UserInterfaceScreenWidgetDefinitionBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 104, Alignment = 4)]
    public class UserInterfaceScreenWidgetDefinitionBlockBase : GuerillaBlock
    {
        internal Flags flags;
        internal ScreenID screenID;
        internal ButtonKeyType buttonKeyType;
        internal OpenTK.Vector4 textColor;
        [TagReference("unic")]
        internal Moonfish.Tags.TagReference stringListTag;
        internal WindowPaneReferenceBlock[] panes;
        internal ShapeGroup shapeGroup;
        internal byte[] invalidName_;
        internal Moonfish.Tags.StringID headerStringId;
        internal LocalStringIdListSectionReferenceBlock[] localStrings;
        internal LocalBitmapReferenceBlock[] localBitmaps;
        internal Moonfish.Tags.ColorR8G8B8 sourceColor;
        internal Moonfish.Tags.ColorR8G8B8 destinationColor;
        internal float accumulateZoomScaleX;
        internal float accumulateZoomScaleY;
        internal float refractionScaleX;
        internal float refractionScaleY;
        
        public override int SerializedSize{get { return 104; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  UserInterfaceScreenWidgetDefinitionBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt32();
            screenID = (ScreenID)binaryReader.ReadInt16();
            buttonKeyType = (ButtonKeyType)binaryReader.ReadInt16();
            textColor = binaryReader.ReadVector4();
            stringListTag = binaryReader.ReadTagReference();
            panes = Guerilla.ReadBlockArray<WindowPaneReferenceBlock>(binaryReader);
            shapeGroup = (ShapeGroup)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            headerStringId = binaryReader.ReadStringID();
            localStrings = Guerilla.ReadBlockArray<LocalStringIdListSectionReferenceBlock>(binaryReader);
            localBitmaps = Guerilla.ReadBlockArray<LocalBitmapReferenceBlock>(binaryReader);
            sourceColor = binaryReader.ReadColorR8G8B8();
            destinationColor = binaryReader.ReadColorR8G8B8();
            accumulateZoomScaleX = binaryReader.ReadSingle();
            accumulateZoomScaleY = binaryReader.ReadSingle();
            refractionScaleX = binaryReader.ReadSingle();
            refractionScaleY = binaryReader.ReadSingle();
        }
        public  UserInterfaceScreenWidgetDefinitionBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt32();
            screenID = (ScreenID)binaryReader.ReadInt16();
            buttonKeyType = (ButtonKeyType)binaryReader.ReadInt16();
            textColor = binaryReader.ReadVector4();
            stringListTag = binaryReader.ReadTagReference();
            panes = Guerilla.ReadBlockArray<WindowPaneReferenceBlock>(binaryReader);
            shapeGroup = (ShapeGroup)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            headerStringId = binaryReader.ReadStringID();
            localStrings = Guerilla.ReadBlockArray<LocalStringIdListSectionReferenceBlock>(binaryReader);
            localBitmaps = Guerilla.ReadBlockArray<LocalBitmapReferenceBlock>(binaryReader);
            sourceColor = binaryReader.ReadColorR8G8B8();
            destinationColor = binaryReader.ReadColorR8G8B8();
            accumulateZoomScaleX = binaryReader.ReadSingle();
            accumulateZoomScaleY = binaryReader.ReadSingle();
            refractionScaleX = binaryReader.ReadSingle();
            refractionScaleY = binaryReader.ReadSingle();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write((Int16)screenID);
                binaryWriter.Write((Int16)buttonKeyType);
                binaryWriter.Write(textColor);
                binaryWriter.Write(stringListTag);
                nextAddress = Guerilla.WriteBlockArray<WindowPaneReferenceBlock>(binaryWriter, panes, nextAddress);
                binaryWriter.Write((Int16)shapeGroup);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(headerStringId);
                nextAddress = Guerilla.WriteBlockArray<LocalStringIdListSectionReferenceBlock>(binaryWriter, localStrings, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<LocalBitmapReferenceBlock>(binaryWriter, localBitmaps, nextAddress);
                binaryWriter.Write(sourceColor);
                binaryWriter.Write(destinationColor);
                binaryWriter.Write(accumulateZoomScaleX);
                binaryWriter.Write(accumulateZoomScaleY);
                binaryWriter.Write(refractionScaleX);
                binaryWriter.Write(refractionScaleY);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        {
            InvalidName14ScreenDialog = 1,
            MultiplePanesAreForListFlavorItems = 2,
            NoHeaderText = 4,
            InvalidName12ScreenDialog = 8,
            LargeDialog = 16,
            DisableOverlayEffect = 32,
        };
        internal enum ScreenID : short
        {
            Test1 = 0,
            Test2 = 1,
            Test3 = 2,
            Test4 = 3,
            Test5 = 4,
            GameShellBackground = 5,
            MainMenu = 6,
            ErrorDialogOKCancel = 7,
            ErrorDialogOK = 8,
            PressStartIntro = 9,
            PlayerProfileSelect = 10,
            SPLevelSelect = 11,
            SPDifficultySelect = 12,
            NetworkSquadBrowser = 13,
            MPPregameLobby = 14,
            CustomGameMenu = 15,
            PostgameStats = 16,
            MPMapSelect = 17,
            SPPauseGame = 18,
            Settings = 19,
            GamertagSelect = 20,
            GamertagPasscodeEntry = 21,
            MultiplayerProtocol = 22,
            SquadSettings = 23,
            SquadGameSettings = 24,
            SquadPrivacySettings = 25,
            YMenuGameshell = 26,
            YMenuGameshellCollapsed = 27,
            YMenuInGame = 28,
            YMenuInGameCollapsed = 29,
            InvalidName4WayJoinScreen = 30,
            YMenuPlayerSelectedOptions = 31,
            PlayerSelectedOptions = 32,
            ConfirmationDialog = 33,
            LiveFeedbackMenuDialog = 34,
            LiveMessageTypeDialog = 35,
            VoiceMsgDialog = 36,
            StereoFaceplate = 37,
            PlayerProfileEditMenu = 38,
            PPControllerSettings = 39,
            PPButtonSettings = 40,
            PPThumbstickSettings = 41,
            PPLookSensitivitySettings = 42,
            PPInvertLookSettings = 43,
            PPAutolevelSettings = 44,
            PPHandicapSettings = 45,
            PPHighScoreRecSettings = 46,
            PPMultiplayerSettingsMenu = 47,
            PPProfileDeleteConfirmationDlg = 48,
            PPChooseForegroundEmblem = 49,
            PPChoosePrimaryColor = 50,
            PPChooseSecondaryColor = 51,
            PPChooseModel = 52,
            PPVoiceSettingsMenu = 53,
            PPChooseVoiceMask = 54,
            PPVoiceThruTV = 55,
            PPEditRotationList = 56,
            PPXBLStatusMenu = 57,
            PPAppearOffline = 58,
            PPAutoOffline = 59,
            GameEngineCategoryListing = 60,
            EditSlayerMenu = 61,
            EditKOTHMenu = 62,
            EditRaceMenu = 63,
            EditOddballMenu = 64,
            EditJuggernautMenu = 65,
            EditHeadhunterMenu = 66,
            EditCTFMenu = 67,
            EditAssaultMenu = 68,
            EditSlayerScoreToWin = 69,
            EditSlayerTimeLimit = 70,
            EditSlayerTeams = 71,
            EditSlayerScore4Killing = 72,
            EditSlayerKillInOrder = 73,
            EditSlayerDeathPtLoss = 74,
            EditSlayerSuicidePtLoss = 75,
            EditSlayerDmgAfterKill = 76,
            EditSlayerDmgAfterDeath = 77,
            EditSlayerSpeedAfterKill = 78,
            EditSlayerSpeedAfterDeath = 79,
            EditKOTHScoreToWin = 80,
            EditKOTHTimeLimit = 81,
            EditKOTHTeams = 82,
            EditKOTHMovingHills = 83,
            EditKOTHUncontesedControl = 84,
            EditKOTHXtraDmg = 85,
            EditRaceLapsToWin = 86,
            EditRaceTimeLimit = 87,
            EditRaceTeams = 88,
            EditRaceTeamScoring = 89,
            EditRaceType = 90,
            EditRaceFlagOrder = 91,
            EditRaceGameEndCondition = 92,
            EditRaceDmgWithLaps = 93,
            EditRaceSpeedWithLaps = 94,
            EditOddballTimeToWin = 95,
            EditOddballTimeLimit = 96,
            EditOddballTeams = 97,
            EditOddballBallSpawnCount = 98,
            EditOddballBallWaypoints = 99,
            EditOddballDamageWithBall = 100,
            EditOddballSpeedWithBall = 101,
            EditOddballInvisibilityWithBall = 102,
            EditJugScoreToWin = 103,
            EditJugTimeLimit = 104,
            EditJugPtsForKillingJugger = 105,
            EditJugCount = 106,
            EditJugSpecies = 107,
            EditJugStartingEquip = 108,
            EditJugDamage = 109,
            EditJugHealth = 110,
            EditJugSpeed = 111,
            EditJugRegeneration = 112,
            EditJugWaypoints = 113,
            EditHHScoreToWin = 114,
            EditHHTimeLimit = 115,
            EditHHTeams = 116,
            EditHHDeathPtLoss = 117,
            EditHHSuicidePtLoss = 118,
            EditHHSpeedWithToken = 119,
            EditHHDroppedTokenLifetime = 120,
            EditHHScoreMultiplier = 121,
            EditCTFScoreToWin = 122,
            EditCTFTimeLimit = 123,
            EditCTFTieResolution = 124,
            EditCTFSingleFlag = 125,
            EditCTFRoleSwapping = 126,
            EditCTFFlagAtHomeToScore = 127,
            EditCTFFlagMustReset = 128,
            EditCTFDmgWithFlag = 129,
            EditCTFSpeedWithFlag = 130,
            EditAssaultScoreToWin = 131,
            EditAssaultTimeLimit = 132,
            EditAssaultTieResolution = 133,
            EditAssaultSingleFlag = 134,
            EditAssaultRoleSwapping = 135,
            EditAssaultEnemyFlagAtHomeToScore = 136,
            EditAssaultFlagMustReset = 137,
            EditAssaultDmgWithFlag = 138,
            EditAssaultSpeedWithFlag = 139,
            EditPlayerNumberOfLives = 140,
            EditPlayerMaxHealth = 141,
            EditPlayerShields = 142,
            EditPlayerRespawnTime = 143,
            EditPlayerCount = 144,
            EditPlayerInvisibility = 145,
            EditPlayerSuicidePenalty = 146,
            EditPlayerFriendlyFire = 147,
            EditItemRespawnGrenades = 148,
            EditItemPowerups = 149,
            EditItemWeaponSet = 150,
            EditItemStartingEquipment = 151,
            EditItemWarthogs = 152,
            EditItemGhosts = 153,
            EditItemScorpions = 154,
            EditItemBanshees = 155,
            EditItemMongeese = 156,
            EditItemShadows = 157,
            EditItemWraiths = 158,
            EditIndicatorObjectives = 159,
            EditIndicatorPlayersOnMotionSensor = 160,
            EditIndicatorInvisiblePlayersOnMotionSensor = 161,
            EditIndicatorFriends = 162,
            EditIndicatorEnemies = 163,
            EditPlayerOptions = 164,
            EditItemOptions = 165,
            EditIndicatorOptions = 166,
            VirtualKeyboard = 167,
            CustomGameMenu0 = 168,
            SlayerQuickOptions = 169,
            KOTHQuickOptions = 170,
            RaceQuickOptions = 171,
            OddballQuickOptions = 172,
            JuggerQuickOptions = 173,
            HHQuickOptions = 174,
            CTFQuickOptions = 175,
            AssaultQuickOptions = 176,
            PickNewSquadLeader = 177,
            VariantEditingOptionsMenu = 178,
            PlaylistListSettings = 179,
            PlaylistContents = 180,
            PlaylistSelectedOptions = 181,
            XboxLiveTaskProgress = 182,
            PPVibrationSettings = 183,
            BootPlayerDialog = 184,
            PostgameStatsLobby = 185,
            XBoxLiveMainMenu = 186,
            EditTerriesMenu = 187,
            EditTerriesScoreToWin = 188,
            EditTerriesTimeLimit = 189,
            EditTerriesTeams = 190,
            TerriesQuickOptions = 191,
            XBoxLiveNotificationBeeper = 192,
            PlayerProfileSelectFancy = 193,
            SavedGameFileActionsDialog = 194,
            MPStartMenu = 195,
            MPStartPlayerSettings = 196,
            MPStartHandicapSettings = 197,
            MPStartChangeTeams = 198,
            MPStartAdminSettings = 199,
            MPStartControllerSettings = 200,
            MPStartVoiceSettings = 201,
            MPStartOnlineStatus = 202,
            MPAlphaLegalWarning = 203,
            SquadJoinProgressDialog = 204,
            MPAlphaPostgameLegalWarning = 205,
            MPMapSelectLobby = 206,
            MPVariantTypeLobby = 207,
            MPVariantListLobby = 208,
            LoadingProgress = 209,
            MatchmakingProgress = 210,
            LiveMessageDisplay = 211,
            FadeInFromBlack = 212,
            LivePlayerProfile = 213,
            LiveClanProfile = 214,
            LiveMessageSend = 215,
            FriendsOptionsDialog = 216,
            ClanOptionsDialog = 217,
            CampaignOptionsDialog = 218,
            OptimatchHoppersFullscreen = 219,
            PlaylistListDialog = 220,
            VariantEditingFormat = 221,
            VariantQuickOptionsFormat = 222,
            VariantParamSettingFormat = 223,
            VehicleOptions = 224,
            MatchOptions = 225,
            PlayerOptions = 226,
            TeamOptions = 227,
            GameOptions = 228,
            EquipmentOptions = 229,
            MultipleChoiceDialog = 230,
            NetworkTransitionProgress = 231,
            XboxLiveStats = 232,
            PPChooseBackgroundEmblem = 233,
            PPButtonsQtr = 234,
            PPStixQtr = 235,
            ClanMemberPrivs = 236,
            OptimatchHoppersLobby = 237,
            SavedGameFileDialog = 238,
            XYZZY = 239,
            ErrorOKCancelLarge = 240,
            YZZYX = 241,
            SubtitleDisplay = 242,
            PPKeyboardSettings = 243,
            PPKeyboardSettingsQtr = 244,
            PPInvertDualWield = 245,
            SystemSettings = 246,
            BungieNews = 247,
            FilterSelect = 248,
            LiveGameBrowser = 249,
            GameDetails = 250,
            MPCustomMapSelect = 251,
            MPAllMapsSelect = 252,
            PPAdvancedKeyboardSettings = 253,
            PPAdvancedKeyboardSettingsQtr = 254,
            NetworkAdapterSettings = 255,
        };
        internal enum ButtonKeyType : short
        {
            NONE = 0,
            ASELECTBBACK = 1,
            ASELECTBCANCEL = 2,
            AENTERBCANCEL = 3,
            YXBOXLIVEPLAYERS = 4,
            XFRIENDSOPTIONS = 5,
            XCLANOPTIONS = 6,
            XRECENTPLAYERSOPTIONS = 7,
            XOPTIONS = 8,
            ASELECT = 9,
            XSETTINGSASELECTBBACK = 10,
            XDELETEASELECTBDONE = 11,
            AACCEPT = 12,
            BCANCEL = 13,
            YXBOXLIVEPLAYERSASELECTBBACK = 14,
            YXBOXLIVEPLAYERSASELECTBCANCEL = 15,
            YXBOXLIVEPLAYERSAENTERBCANCEL = 16,
            YXBOXLIVEPLAYERSASELECT = 17,
            YXBOXLIVEPLAYERSASELECTBDONE = 18,
            YXBOXLIVEPLAYERSAACCEPT = 19,
            YXBOXLIVEPLAYERSBCANCEL = 20,
            XDELETEASELECTBBACK = 21,
            AOK = 22,
        };
        internal enum ShapeGroup : short
        {
            NONE = 0,
            InvalidName00 = 1,
            InvalidName01 = 2,
            InvalidName02 = 3,
            InvalidName03 = 4,
            InvalidName04 = 5,
            InvalidName05 = 6,
            InvalidName06 = 7,
            InvalidName07 = 8,
            InvalidName08 = 9,
            InvalidName09 = 10,
            InvalidName10 = 11,
            InvalidName11 = 12,
            InvalidName12 = 13,
            InvalidName13 = 14,
            InvalidName14 = 15,
            InvalidName15 = 16,
            InvalidName16 = 17,
            InvalidName17 = 18,
            InvalidName18 = 19,
            InvalidName19 = 20,
            InvalidName20 = 21,
            InvalidName21 = 22,
            InvalidName22 = 23,
            InvalidName23 = 24,
            InvalidName24 = 25,
            InvalidName25 = 26,
            InvalidName26 = 27,
            InvalidName27 = 28,
            InvalidName28 = 29,
            InvalidName29 = 30,
            InvalidName30 = 31,
            InvalidName31 = 32,
        };
    };
}
