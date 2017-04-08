//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Moonfish.Guerilla.Tags
{
    using Moonfish.Tags;
    using Moonfish.Model;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    
    [TagClassAttribute("wgit")]
    public partial class UserInterfaceScreenWidgetDefinitionBlock : GuerillaBlock, IWriteQueueable
    {
        public Flags UserInterfaceScreenWidgetDefinitionFlags;
        public ScreenIDEnum ScreenID;
        public ButtonKeyTypeEnum ButtonKeyType;
        /// <summary>
        /// Any ui elements that don't explicitly set a text color will use this color
        /// </summary>
        public OpenTK.Vector4 TextColor;
        /// <summary>
        /// All text specific to this screen
        /// </summary>
        [Moonfish.Tags.TagReferenceAttribute("unic")]
        public Moonfish.Tags.TagReference StringListTag;
        public WindowPaneReferenceBlock[] Panes = new WindowPaneReferenceBlock[0];
        public ShapeGroupEnum ShapeGroup;
        private byte[] fieldpad = new byte[2];
        /// <summary>
        /// These are down here because they got added on later. Have a nice day.
        /// </summary>
        public Moonfish.Tags.StringIdent HeaderStringId;
        public LocalStringIdListSectionReferenceBlock[] LocalStrings = new LocalStringIdListSectionReferenceBlock[0];
        public LocalBitmapReferenceBlock[] LocalBitmaps = new LocalBitmapReferenceBlock[0];
        /// <summary>
        /// These are used only for level load progress bitmaps
        /// </summary>
        public Moonfish.Tags.ColourR8G8B8 SourceColor;
        public Moonfish.Tags.ColourR8G8B8 DestinationColor;
        public float AccumulateZoomScaleX;
        public float AccumulateZoomScaleY;
        public float RefractionScaleX;
        public float RefractionScaleY;
        public override int SerializedSize
        {
            get
            {
                return 104;
            }
        }
        public override int Alignment
        {
            get
            {
                return 4;
            }
        }
        public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(System.IO.BinaryReader binaryReader)
        {
            System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
            this.UserInterfaceScreenWidgetDefinitionFlags = ((Flags)(binaryReader.ReadInt32()));
            this.ScreenID = ((ScreenIDEnum)(binaryReader.ReadInt16()));
            this.ButtonKeyType = ((ButtonKeyTypeEnum)(binaryReader.ReadInt16()));
            this.TextColor = binaryReader.ReadVector4();
            this.StringListTag = binaryReader.ReadTagReference();
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(76));
            this.ShapeGroup = ((ShapeGroupEnum)(binaryReader.ReadInt16()));
            this.fieldpad = binaryReader.ReadBytes(2);
            this.HeaderStringId = binaryReader.ReadStringIdent();
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(12));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(8));
            this.SourceColor = binaryReader.ReadColorR8G8B8();
            this.DestinationColor = binaryReader.ReadColorR8G8B8();
            this.AccumulateZoomScaleX = binaryReader.ReadSingle();
            this.AccumulateZoomScaleY = binaryReader.ReadSingle();
            this.RefractionScaleX = binaryReader.ReadSingle();
            this.RefractionScaleY = binaryReader.ReadSingle();
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.Panes = base.ReadBlockArrayData<WindowPaneReferenceBlock>(binaryReader, pointerQueue.Dequeue());
            this.LocalStrings = base.ReadBlockArrayData<LocalStringIdListSectionReferenceBlock>(binaryReader, pointerQueue.Dequeue());
            this.LocalBitmaps = base.ReadBlockArrayData<LocalBitmapReferenceBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            queueableBinaryWriter.QueueWrite(this.Panes);
            queueableBinaryWriter.QueueWrite(this.LocalStrings);
            queueableBinaryWriter.QueueWrite(this.LocalBitmaps);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(((int)(this.UserInterfaceScreenWidgetDefinitionFlags)));
            queueableBinaryWriter.Write(((short)(this.ScreenID)));
            queueableBinaryWriter.Write(((short)(this.ButtonKeyType)));
            queueableBinaryWriter.Write(this.TextColor);
            queueableBinaryWriter.Write(this.StringListTag);
            queueableBinaryWriter.WritePointer(this.Panes);
            queueableBinaryWriter.Write(((short)(this.ShapeGroup)));
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.Write(this.HeaderStringId);
            queueableBinaryWriter.WritePointer(this.LocalStrings);
            queueableBinaryWriter.WritePointer(this.LocalBitmaps);
            queueableBinaryWriter.Write(this.SourceColor);
            queueableBinaryWriter.Write(this.DestinationColor);
            queueableBinaryWriter.Write(this.AccumulateZoomScaleX);
            queueableBinaryWriter.Write(this.AccumulateZoomScaleY);
            queueableBinaryWriter.Write(this.RefractionScaleX);
            queueableBinaryWriter.Write(this.RefractionScaleY);
        }
        /// <summary>
        /// Set misc. screen behavior here
        /// </summary>
        [System.FlagsAttribute()]
        public enum Flags : int
        {
            None = 0,
            _14ScreenDialog = 1,
            MultiplePanesAreForListFlavorItems = 2,
            NoHeaderText = 4,
            _12ScreenDialog = 8,
            LargeDialog = 16,
            DisableOverlayEffect = 32,
        }
        public enum ScreenIDEnum : short
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
            _4wayJoinScreen = 30,
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
            FadeinFromBlack = 212,
            LivePlayerProfile = 213,
            LiveClanProfile = 214,
            LiveMessageSend = 215,
            FriendsOptionsDialog = 216,
            ClanOptionsDialog = 217,
            CampaignOptionsDialog = 218,
            OptimatchHoppersFullscreen = 219,
            PlaylistListdialog = 220,
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
        }
        /// <summary>
        /// The labels here are just a guide; the actual string used comes from the Nth position
        ///of this button key entry as found in the ui globals button key string list tag
        /// </summary>
        public enum ButtonKeyTypeEnum : short
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
        }
        /// <summary>
        /// If the screen is to have a shape group, specify it here (references group in user interface globals tag)
        /// </summary>
        public enum ShapeGroupEnum : short
        {
            NONE = 0,
            _00 = 1,
            _01 = 2,
            _02 = 3,
            _03 = 4,
            _04 = 5,
            _05 = 6,
            _06 = 7,
            _07 = 8,
            _08 = 9,
            _09 = 10,
            _10 = 11,
            _11 = 12,
            _12 = 13,
            _13 = 14,
            _14 = 15,
            _15 = 16,
            _16 = 17,
            _17 = 18,
            _18 = 19,
            _19 = 20,
            _20 = 21,
            _21 = 22,
            _22 = 23,
            _23 = 24,
            _24 = 25,
            _25 = 26,
            _26 = 27,
            _27 = 28,
            _28 = 29,
            _29 = 30,
            _30 = 31,
            _31 = 32,
        }
    }
}
namespace Moonfish.Tags
{
    
    public partial struct TagClass
    {
        public static TagClass Wgit = ((TagClass)("wgit"));
    }
}
