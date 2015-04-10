using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GDefaultVariantSettingsBlock : GDefaultVariantSettingsBlockBase
    {
        public  GDefaultVariantSettingsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8)]
    public class GDefaultVariantSettingsBlockBase
    {
        internal SettingCategory settingCategory;
        internal int value;
        internal  GDefaultVariantSettingsBlockBase(BinaryReader binaryReader)
        {
            this.settingCategory = (SettingCategory)binaryReader.ReadInt32();
            this.value = binaryReader.ReadInt32();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
        internal enum SettingCategory : int
        
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
