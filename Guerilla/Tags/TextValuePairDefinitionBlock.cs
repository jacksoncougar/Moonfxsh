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
        public static readonly TagClass SilyClass = (TagClass)"sily";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("sily")]
    public  partial class TextValuePairDefinitionBlock : TextValuePairDefinitionBlockBase
    {
        public  TextValuePairDefinitionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 36, Alignment = 4)]
    public class TextValuePairDefinitionBlockBase  : IGuerilla
    {
        internal Parameter parameter;
        internal byte[] invalidName_;
        [TagReference("unic")]
        internal Moonfish.Tags.TagReference stringList;
        internal Moonfish.Tags.StringID titleText;
        internal Moonfish.Tags.StringID headerText;
        internal Moonfish.Tags.StringID descriptionText;
        internal TextValuePairReferenceBlock[] textValuePairs;
        internal  TextValuePairDefinitionBlockBase(BinaryReader binaryReader)
        {
            parameter = (Parameter)binaryReader.ReadInt32();
            invalidName_ = binaryReader.ReadBytes(4);
            stringList = binaryReader.ReadTagReference();
            titleText = binaryReader.ReadStringID();
            headerText = binaryReader.ReadStringID();
            descriptionText = binaryReader.ReadStringID();
            textValuePairs = Guerilla.ReadBlockArray<TextValuePairReferenceBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)parameter);
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(stringList);
                binaryWriter.Write(titleText);
                binaryWriter.Write(headerText);
                binaryWriter.Write(descriptionText);
                nextAddress = Guerilla.WriteBlockArray<TextValuePairReferenceBlock>(binaryWriter, textValuePairs, nextAddress);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
        internal enum Parameter : int
        {
            MatchRoundSetting = 0,
            MatchCtfScoreToWin = 1,
            MatchSlayerScoreToWinRound = 2,
            MatchOddballScoreToWinRound = 3,
            MatchKingScoreToWinRound = 4,
            MatchRaceScoreToWinRound = 5,
            MatchHeadhunterScoreToWinRound = 6,
            MatchJuggernautScoreToWinRound = 7,
            MatchTerritoriesScoreToWinRound = 8,
            MatchAssaultScoreToWinRound = 9,
            MatchRoundTimeLimit = 10,
            MatchRoundsResetMap = 11,
            MatchTieResolution = 12,
            MatchObservers = 13,
            MatchJoinInProgress = 14,
            MaximumPlayers = 15,
            LivesPerRound = 16,
            RespawnTime = 17,
            SuicidePenalty = 18,
            Shields = 19,
            MotionSensor = 20,
            Invisibility = 21,
            TeamChanging = 22,
            TeamScoring = 23,
            FriendlyFire = 24,
            TeamRespawnSetting = 25,
            BetrayalRespawnPenalty = 26,
            TeamKillerManagement = 27,
            SlayerBonusPoints = 28,
            SlayerSuicidePointLoss = 29,
            SlayerDeathPointLoss = 30,
            HeadhunterMovingHeadBin = 31,
            HeadhunterPointMultiplier = 32,
            HeadhunterSuicidePointLoss = 33,
            HeadhunterDeathPointLoss = 34,
            HeadhunterUncontestedBin = 35,
            HeadhunterSpeedWithHeads = 36,
            HeadhunterMaxHeadsCarried = 37,
            KingUncontestedHill = 38,
            KingTeamTimeMultiplier = 39,
            KingMovingHill = 40,
            KingExtraDamageOnHill = 41,
            KingDmgResistanceOnHill = 42,
            OddballBallSpawnCount = 43,
            OddballBallHitDamage = 44,
            OddballSpeedWithBall = 45,
            OddballDrivingGunningWithBall = 46,
            OddballWaypointToBall = 47,
            RaceRandomTrack = 48,
            RaceUncontestedFlag = 49,
            CtfGameType = 50,
            CtfSuddenDeath = 51,
            CtfFlagMayBeReturned = 52,
            CtfFlagAtHomeToScore = 53,
            CtfFlagResetTime = 54,
            CtfSpeedWithFlag = 55,
            CtfFlagHitDamage = 56,
            CtfDrivingGunningWithFlag = 57,
            CtfWaypointToOwnFlag = 58,
            AssaultGameType = 59,
            AssaultSuddenDeath = 60,
            AssaultDetonationTime = 61,
            AssaultBombAtHomeToScore = 62,
            AssaultArmingTime = 63,
            AssaultSpeedWithBomb = 64,
            AssaultBombHitDamage = 65,
            AssaultDrivingGunningWithBomb = 66,
            AssaultWaypointToOwnBomb = 67,
            JuggernautBetrayalPointLoss = 68,
            JuggernautJuggyExtraDamage = 69,
            JuggernautJuggyInfiniteAmmo = 70,
            JuggernautJuggyOvershields = 71,
            JuggernautJuggyActiveCamo = 72,
            JuggernautJuggyMotionSensor = 73,
            TerritoriesTerritoryCount = 74,
            VehRespawn = 75,
            VehPrimaryLightLand = 76,
            VehSecondaryLightLand = 77,
            VehPrimaryHeavyLand = 78,
            VehPrimaryFlying = 79,
            VehSecondaryHeavyLand = 80,
            VehPrimaryTurret = 81,
            VehSecondaryTurret = 82,
            EquipWeaponsOnMap = 83,
            EquipOvershieldsOnMap = 84,
            EquipActiveCamoOnMap = 85,
            EquipGrenadesOnMap = 86,
            EquipWeaponRespawnTimes = 87,
            EquipStartingGrenades = 88,
            EquipPrimaryStartingEquipment = 89,
            UNSMaxLivingPlayers = 90,
            UNSTeamsEnabled = 91,
            UNSAssaultBombMayBeReturned = 92,
            UNSMaxTeams = 93,
            UNSEquipSecondaryStartingEquipment = 94,
            UNSAssaultFuseTime = 95,
            UNSJuggyMovement = 96,
            UNSStickyFuse = 97,
            UNSTerrContestTime = 98,
            UNSTerrControlTime = 99,
            UNSOddbCarrInvis = 100,
            UNSKingInvisInHill = 101,
            UNSBallCarrDmgResis = 102,
            UNSKingDmgResInHill = 103,
            UNSPlayersExDmg = 104,
            UNSPlayersDmgResis = 105,
            UNSCtfCarrDmgResis = 106,
            UNSCtfCarrInvis = 107,
            UNSJuggyDmgResis = 108,
            UNSBombCarrDmgResis = 109,
            UNSBombCarrInvis = 110,
            UNSForceEvenTeams = 111,
        };
    };
}
