using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class DifficultyBlock : DifficultyBlockBase
    {
        public  DifficultyBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 644)]
    public class DifficultyBlockBase
    {
        /// <summary>
        /// enemy damage multiplier on easy difficulty
        /// </summary>
        internal float easyEnemyDamage;
        /// <summary>
        /// enemy damage multiplier on normal difficulty
        /// </summary>
        internal float normalEnemyDamage;
        /// <summary>
        /// enemy damage multiplier on hard difficulty
        /// </summary>
        internal float hardEnemyDamage;
        /// <summary>
        /// enemy damage multiplier on impossible difficulty
        /// </summary>
        internal float impossEnemyDamage;
        /// <summary>
        /// enemy maximum body vitality scale on easy difficulty
        /// </summary>
        internal float easyEnemyVitality;
        /// <summary>
        /// enemy maximum body vitality scale on normal difficulty
        /// </summary>
        internal float normalEnemyVitality;
        /// <summary>
        /// enemy maximum body vitality scale on hard difficulty
        /// </summary>
        internal float hardEnemyVitality;
        /// <summary>
        /// enemy maximum body vitality scale on impossible difficulty
        /// </summary>
        internal float impossEnemyVitality;
        /// <summary>
        /// enemy maximum shield vitality scale on easy difficulty
        /// </summary>
        internal float easyEnemyShield;
        /// <summary>
        /// enemy maximum shield vitality scale on normal difficulty
        /// </summary>
        internal float normalEnemyShield;
        /// <summary>
        /// enemy maximum shield vitality scale on hard difficulty
        /// </summary>
        internal float hardEnemyShield;
        /// <summary>
        /// enemy maximum shield vitality scale on impossible difficulty
        /// </summary>
        internal float impossEnemyShield;
        /// <summary>
        /// enemy shield recharge scale on easy difficulty
        /// </summary>
        internal float easyEnemyRecharge;
        /// <summary>
        /// enemy shield recharge scale on normal difficulty
        /// </summary>
        internal float normalEnemyRecharge;
        /// <summary>
        /// enemy shield recharge scale on hard difficulty
        /// </summary>
        internal float hardEnemyRecharge;
        /// <summary>
        /// enemy shield recharge scale on impossible difficulty
        /// </summary>
        internal float impossEnemyRecharge;
        /// <summary>
        /// friend damage multiplier on easy difficulty
        /// </summary>
        internal float easyFriendDamage;
        /// <summary>
        /// friend damage multiplier on normal difficulty
        /// </summary>
        internal float normalFriendDamage;
        /// <summary>
        /// friend damage multiplier on hard difficulty
        /// </summary>
        internal float hardFriendDamage;
        /// <summary>
        /// friend damage multiplier on impossible difficulty
        /// </summary>
        internal float impossFriendDamage;
        /// <summary>
        /// friend maximum body vitality scale on easy difficulty
        /// </summary>
        internal float easyFriendVitality;
        /// <summary>
        /// friend maximum body vitality scale on normal difficulty
        /// </summary>
        internal float normalFriendVitality;
        /// <summary>
        /// friend maximum body vitality scale on hard difficulty
        /// </summary>
        internal float hardFriendVitality;
        /// <summary>
        /// friend maximum body vitality scale on impossible difficulty
        /// </summary>
        internal float impossFriendVitality;
        /// <summary>
        /// friend maximum shield vitality scale on easy difficulty
        /// </summary>
        internal float easyFriendShield;
        /// <summary>
        /// friend maximum shield vitality scale on normal difficulty
        /// </summary>
        internal float normalFriendShield;
        /// <summary>
        /// friend maximum shield vitality scale on hard difficulty
        /// </summary>
        internal float hardFriendShield;
        /// <summary>
        /// friend maximum shield vitality scale on impossible difficulty
        /// </summary>
        internal float impossFriendShield;
        /// <summary>
        /// friend shield recharge scale on easy difficulty
        /// </summary>
        internal float easyFriendRecharge;
        /// <summary>
        /// friend shield recharge scale on normal difficulty
        /// </summary>
        internal float normalFriendRecharge;
        /// <summary>
        /// friend shield recharge scale on hard difficulty
        /// </summary>
        internal float hardFriendRecharge;
        /// <summary>
        /// friend shield recharge scale on impossible difficulty
        /// </summary>
        internal float impossFriendRecharge;
        /// <summary>
        /// toughness of infection forms (may be negative) on easy difficulty
        /// </summary>
        internal float easyInfectionForms;
        /// <summary>
        /// toughness of infection forms (may be negative) on normal difficulty
        /// </summary>
        internal float normalInfectionForms;
        /// <summary>
        /// toughness of infection forms (may be negative) on hard difficulty
        /// </summary>
        internal float hardInfectionForms;
        /// <summary>
        /// toughness of infection forms (may be negative) on impossible difficulty
        /// </summary>
        internal float impossInfectionForms;
        internal byte[] invalidName_;
        /// <summary>
        /// enemy rate of fire scale on easy difficulty
        /// </summary>
        internal float easyRateOfFire;
        /// <summary>
        /// enemy rate of fire scale on normal difficulty
        /// </summary>
        internal float normalRateOfFire;
        /// <summary>
        /// enemy rate of fire scale on hard difficulty
        /// </summary>
        internal float hardRateOfFire;
        /// <summary>
        /// enemy rate of fire scale on impossible difficulty
        /// </summary>
        internal float impossRateOfFire;
        /// <summary>
        /// enemy projectile error scale, as a fraction of their base firing error. on easy difficulty
        /// </summary>
        internal float easyProjectileError;
        /// <summary>
        /// enemy projectile error scale, as a fraction of their base firing error. on normal difficulty
        /// </summary>
        internal float normalProjectileError;
        /// <summary>
        /// enemy projectile error scale, as a fraction of their base firing error. on hard difficulty
        /// </summary>
        internal float hardProjectileError;
        /// <summary>
        /// enemy projectile error scale, as a fraction of their base firing error. on impossible difficulty
        /// </summary>
        internal float impossProjectileError;
        /// <summary>
        /// enemy burst error scale; reduces intra-burst shot distance. on easy difficulty
        /// </summary>
        internal float easyBurstError;
        /// <summary>
        /// enemy burst error scale; reduces intra-burst shot distance. on normal difficulty
        /// </summary>
        internal float normalBurstError;
        /// <summary>
        /// enemy burst error scale; reduces intra-burst shot distance. on hard difficulty
        /// </summary>
        internal float hardBurstError;
        /// <summary>
        /// enemy burst error scale; reduces intra-burst shot distance. on impossible difficulty
        /// </summary>
        internal float impossBurstError;
        /// <summary>
        /// enemy new-target delay scale factor. on easy difficulty
        /// </summary>
        internal float easyNewTargetDelay;
        /// <summary>
        /// enemy new-target delay scale factor. on normal difficulty
        /// </summary>
        internal float normalNewTargetDelay;
        /// <summary>
        /// enemy new-target delay scale factor. on hard difficulty
        /// </summary>
        internal float hardNewTargetDelay;
        /// <summary>
        /// enemy new-target delay scale factor. on impossible difficulty
        /// </summary>
        internal float impossNewTargetDelay;
        /// <summary>
        /// delay time between bursts scale factor for enemies. on easy difficulty
        /// </summary>
        internal float easyBurstSeparation;
        /// <summary>
        /// delay time between bursts scale factor for enemies. on normal difficulty
        /// </summary>
        internal float normalBurstSeparation;
        /// <summary>
        /// delay time between bursts scale factor for enemies. on hard difficulty
        /// </summary>
        internal float hardBurstSeparation;
        /// <summary>
        /// delay time between bursts scale factor for enemies. on impossible difficulty
        /// </summary>
        internal float impossBurstSeparation;
        /// <summary>
        /// additional target tracking fraction for enemies. on easy difficulty
        /// </summary>
        internal float easyTargetTracking;
        /// <summary>
        /// additional target tracking fraction for enemies. on normal difficulty
        /// </summary>
        internal float normalTargetTracking;
        /// <summary>
        /// additional target tracking fraction for enemies. on hard difficulty
        /// </summary>
        internal float hardTargetTracking;
        /// <summary>
        /// additional target tracking fraction for enemies. on impossible difficulty
        /// </summary>
        internal float impossTargetTracking;
        /// <summary>
        /// additional target leading fraction for enemies. on easy difficulty
        /// </summary>
        internal float easyTargetLeading;
        /// <summary>
        /// additional target leading fraction for enemies. on normal difficulty
        /// </summary>
        internal float normalTargetLeading;
        /// <summary>
        /// additional target leading fraction for enemies. on hard difficulty
        /// </summary>
        internal float hardTargetLeading;
        /// <summary>
        /// additional target leading fraction for enemies. on impossible difficulty
        /// </summary>
        internal float impossTargetLeading;
        /// <summary>
        /// overcharge chance scale factor for enemies. on easy difficulty
        /// </summary>
        internal float easyOverchargeChance;
        /// <summary>
        /// overcharge chance scale factor for enemies. on normal difficulty
        /// </summary>
        internal float normalOverchargeChance;
        /// <summary>
        /// overcharge chance scale factor for enemies. on hard difficulty
        /// </summary>
        internal float hardOverchargeChance;
        /// <summary>
        /// overcharge chance scale factor for enemies. on impossible difficulty
        /// </summary>
        internal float impossOverchargeChance;
        /// <summary>
        /// delay between special-fire shots (overcharge, banshee bombs) scale factor for enemies. on easy difficulty
        /// </summary>
        internal float easySpecialFireDelay;
        /// <summary>
        /// delay between special-fire shots (overcharge, banshee bombs) scale factor for enemies. on normal difficulty
        /// </summary>
        internal float normalSpecialFireDelay;
        /// <summary>
        /// delay between special-fire shots (overcharge, banshee bombs) scale factor for enemies. on hard difficulty
        /// </summary>
        internal float hardSpecialFireDelay;
        /// <summary>
        /// delay between special-fire shots (overcharge, banshee bombs) scale factor for enemies. on impossible difficulty
        /// </summary>
        internal float impossSpecialFireDelay;
        /// <summary>
        /// guidance velocity scale factor for all projectiles targeted on a player. on easy difficulty
        /// </summary>
        internal float easyGuidanceVsPlayer;
        /// <summary>
        /// guidance velocity scale factor for all projectiles targeted on a player. on normal difficulty
        /// </summary>
        internal float normalGuidanceVsPlayer;
        /// <summary>
        /// guidance velocity scale factor for all projectiles targeted on a player. on hard difficulty
        /// </summary>
        internal float hardGuidanceVsPlayer;
        /// <summary>
        /// guidance velocity scale factor for all projectiles targeted on a player. on impossible difficulty
        /// </summary>
        internal float impossGuidanceVsPlayer;
        /// <summary>
        /// delay period added to all melee attacks, even when berserk. on easy difficulty
        /// </summary>
        internal float easyMeleeDelayBase;
        /// <summary>
        /// delay period added to all melee attacks, even when berserk. on normal difficulty
        /// </summary>
        internal float normalMeleeDelayBase;
        /// <summary>
        /// delay period added to all melee attacks, even when berserk. on hard difficulty
        /// </summary>
        internal float hardMeleeDelayBase;
        /// <summary>
        /// delay period added to all melee attacks, even when berserk. on impossible difficulty
        /// </summary>
        internal float impossMeleeDelayBase;
        /// <summary>
        /// multiplier for all existing non-berserk melee delay times. on easy difficulty
        /// </summary>
        internal float easyMeleeDelayScale;
        /// <summary>
        /// multiplier for all existing non-berserk melee delay times. on normal difficulty
        /// </summary>
        internal float normalMeleeDelayScale;
        /// <summary>
        /// multiplier for all existing non-berserk melee delay times. on hard difficulty
        /// </summary>
        internal float hardMeleeDelayScale;
        /// <summary>
        /// multiplier for all existing non-berserk melee delay times. on impossible difficulty
        /// </summary>
        internal float impossMeleeDelayScale;
        internal byte[] invalidName_0;
        /// <summary>
        /// scale factor affecting the desicions to throw a grenade. on easy difficulty
        /// </summary>
        internal float easyGrenadeChanceScale;
        /// <summary>
        /// scale factor affecting the desicions to throw a grenade. on normal difficulty
        /// </summary>
        internal float normalGrenadeChanceScale;
        /// <summary>
        /// scale factor affecting the desicions to throw a grenade. on hard difficulty
        /// </summary>
        internal float hardGrenadeChanceScale;
        /// <summary>
        /// scale factor affecting the desicions to throw a grenade. on impossible difficulty
        /// </summary>
        internal float impossGrenadeChanceScale;
        /// <summary>
        /// scale factor affecting the delay period between grenades thrown from the same encounter (lower is more often). on easy difficulty
        /// </summary>
        internal float easyGrenadeTimerScale;
        /// <summary>
        /// scale factor affecting the delay period between grenades thrown from the same encounter (lower is more often). on normal difficulty
        /// </summary>
        internal float normalGrenadeTimerScale;
        /// <summary>
        /// scale factor affecting the delay period between grenades thrown from the same encounter (lower is more often). on hard difficulty
        /// </summary>
        internal float hardGrenadeTimerScale;
        /// <summary>
        /// scale factor affecting the delay period between grenades thrown from the same encounter (lower is more often). on impossible difficulty
        /// </summary>
        internal float impossGrenadeTimerScale;
        internal byte[] invalidName_1;
        internal byte[] invalidName_2;
        internal byte[] invalidName_3;
        /// <summary>
        /// fraction of actors upgraded to their major variant. on easy difficulty
        /// </summary>
        internal float easyMajorUpgradeNormal;
        /// <summary>
        /// fraction of actors upgraded to their major variant. on normal difficulty
        /// </summary>
        internal float normalMajorUpgradeNormal;
        /// <summary>
        /// fraction of actors upgraded to their major variant. on hard difficulty
        /// </summary>
        internal float hardMajorUpgradeNormal;
        /// <summary>
        /// fraction of actors upgraded to their major variant. on impossible difficulty
        /// </summary>
        internal float impossMajorUpgradeNormal;
        /// <summary>
        /// fraction of actors upgraded to their major variant when mix = normal. on easy difficulty
        /// </summary>
        internal float easyMajorUpgradeFew;
        /// <summary>
        /// fraction of actors upgraded to their major variant when mix = normal. on normal difficulty
        /// </summary>
        internal float normalMajorUpgradeFew;
        /// <summary>
        /// fraction of actors upgraded to their major variant when mix = normal. on hard difficulty
        /// </summary>
        internal float hardMajorUpgradeFew;
        /// <summary>
        /// fraction of actors upgraded to their major variant when mix = normal. on impossible difficulty
        /// </summary>
        internal float impossMajorUpgradeFew;
        /// <summary>
        /// fraction of actors upgraded to their major variant when mix = many. on easy difficulty
        /// </summary>
        internal float easyMajorUpgradeMany;
        /// <summary>
        /// fraction of actors upgraded to their major variant when mix = many. on normal difficulty
        /// </summary>
        internal float normalMajorUpgradeMany;
        /// <summary>
        /// fraction of actors upgraded to their major variant when mix = many. on hard difficulty
        /// </summary>
        internal float hardMajorUpgradeMany;
        /// <summary>
        /// fraction of actors upgraded to their major variant when mix = many. on impossible difficulty
        /// </summary>
        internal float impossMajorUpgradeMany;
        /// <summary>
        /// Chance of deciding to ram the player in a vehicle on easy difficulty
        /// </summary>
        internal float easyPlayerVehicleRamChance;
        /// <summary>
        /// Chance of deciding to ram the player in a vehicle on normal difficulty
        /// </summary>
        internal float normalPlayerVehicleRamChance;
        /// <summary>
        /// Chance of deciding to ram the player in a vehicle on hard difficulty
        /// </summary>
        internal float hardPlayerVehicleRamChance;
        /// <summary>
        /// Chance of deciding to ram the player in a vehicle on impossible difficulty
        /// </summary>
        internal float impossPlayerVehicleRamChance;
        internal byte[] invalidName_4;
        internal byte[] invalidName_5;
        internal byte[] invalidName_6;
        internal byte[] invalidName_7;
        internal  DifficultyBlockBase(BinaryReader binaryReader)
        {
            this.easyEnemyDamage = binaryReader.ReadSingle();
            this.normalEnemyDamage = binaryReader.ReadSingle();
            this.hardEnemyDamage = binaryReader.ReadSingle();
            this.impossEnemyDamage = binaryReader.ReadSingle();
            this.easyEnemyVitality = binaryReader.ReadSingle();
            this.normalEnemyVitality = binaryReader.ReadSingle();
            this.hardEnemyVitality = binaryReader.ReadSingle();
            this.impossEnemyVitality = binaryReader.ReadSingle();
            this.easyEnemyShield = binaryReader.ReadSingle();
            this.normalEnemyShield = binaryReader.ReadSingle();
            this.hardEnemyShield = binaryReader.ReadSingle();
            this.impossEnemyShield = binaryReader.ReadSingle();
            this.easyEnemyRecharge = binaryReader.ReadSingle();
            this.normalEnemyRecharge = binaryReader.ReadSingle();
            this.hardEnemyRecharge = binaryReader.ReadSingle();
            this.impossEnemyRecharge = binaryReader.ReadSingle();
            this.easyFriendDamage = binaryReader.ReadSingle();
            this.normalFriendDamage = binaryReader.ReadSingle();
            this.hardFriendDamage = binaryReader.ReadSingle();
            this.impossFriendDamage = binaryReader.ReadSingle();
            this.easyFriendVitality = binaryReader.ReadSingle();
            this.normalFriendVitality = binaryReader.ReadSingle();
            this.hardFriendVitality = binaryReader.ReadSingle();
            this.impossFriendVitality = binaryReader.ReadSingle();
            this.easyFriendShield = binaryReader.ReadSingle();
            this.normalFriendShield = binaryReader.ReadSingle();
            this.hardFriendShield = binaryReader.ReadSingle();
            this.impossFriendShield = binaryReader.ReadSingle();
            this.easyFriendRecharge = binaryReader.ReadSingle();
            this.normalFriendRecharge = binaryReader.ReadSingle();
            this.hardFriendRecharge = binaryReader.ReadSingle();
            this.impossFriendRecharge = binaryReader.ReadSingle();
            this.easyInfectionForms = binaryReader.ReadSingle();
            this.normalInfectionForms = binaryReader.ReadSingle();
            this.hardInfectionForms = binaryReader.ReadSingle();
            this.impossInfectionForms = binaryReader.ReadSingle();
            this.invalidName_ = binaryReader.ReadBytes(16);
            this.easyRateOfFire = binaryReader.ReadSingle();
            this.normalRateOfFire = binaryReader.ReadSingle();
            this.hardRateOfFire = binaryReader.ReadSingle();
            this.impossRateOfFire = binaryReader.ReadSingle();
            this.easyProjectileError = binaryReader.ReadSingle();
            this.normalProjectileError = binaryReader.ReadSingle();
            this.hardProjectileError = binaryReader.ReadSingle();
            this.impossProjectileError = binaryReader.ReadSingle();
            this.easyBurstError = binaryReader.ReadSingle();
            this.normalBurstError = binaryReader.ReadSingle();
            this.hardBurstError = binaryReader.ReadSingle();
            this.impossBurstError = binaryReader.ReadSingle();
            this.easyNewTargetDelay = binaryReader.ReadSingle();
            this.normalNewTargetDelay = binaryReader.ReadSingle();
            this.hardNewTargetDelay = binaryReader.ReadSingle();
            this.impossNewTargetDelay = binaryReader.ReadSingle();
            this.easyBurstSeparation = binaryReader.ReadSingle();
            this.normalBurstSeparation = binaryReader.ReadSingle();
            this.hardBurstSeparation = binaryReader.ReadSingle();
            this.impossBurstSeparation = binaryReader.ReadSingle();
            this.easyTargetTracking = binaryReader.ReadSingle();
            this.normalTargetTracking = binaryReader.ReadSingle();
            this.hardTargetTracking = binaryReader.ReadSingle();
            this.impossTargetTracking = binaryReader.ReadSingle();
            this.easyTargetLeading = binaryReader.ReadSingle();
            this.normalTargetLeading = binaryReader.ReadSingle();
            this.hardTargetLeading = binaryReader.ReadSingle();
            this.impossTargetLeading = binaryReader.ReadSingle();
            this.easyOverchargeChance = binaryReader.ReadSingle();
            this.normalOverchargeChance = binaryReader.ReadSingle();
            this.hardOverchargeChance = binaryReader.ReadSingle();
            this.impossOverchargeChance = binaryReader.ReadSingle();
            this.easySpecialFireDelay = binaryReader.ReadSingle();
            this.normalSpecialFireDelay = binaryReader.ReadSingle();
            this.hardSpecialFireDelay = binaryReader.ReadSingle();
            this.impossSpecialFireDelay = binaryReader.ReadSingle();
            this.easyGuidanceVsPlayer = binaryReader.ReadSingle();
            this.normalGuidanceVsPlayer = binaryReader.ReadSingle();
            this.hardGuidanceVsPlayer = binaryReader.ReadSingle();
            this.impossGuidanceVsPlayer = binaryReader.ReadSingle();
            this.easyMeleeDelayBase = binaryReader.ReadSingle();
            this.normalMeleeDelayBase = binaryReader.ReadSingle();
            this.hardMeleeDelayBase = binaryReader.ReadSingle();
            this.impossMeleeDelayBase = binaryReader.ReadSingle();
            this.easyMeleeDelayScale = binaryReader.ReadSingle();
            this.normalMeleeDelayScale = binaryReader.ReadSingle();
            this.hardMeleeDelayScale = binaryReader.ReadSingle();
            this.impossMeleeDelayScale = binaryReader.ReadSingle();
            this.invalidName_0 = binaryReader.ReadBytes(16);
            this.easyGrenadeChanceScale = binaryReader.ReadSingle();
            this.normalGrenadeChanceScale = binaryReader.ReadSingle();
            this.hardGrenadeChanceScale = binaryReader.ReadSingle();
            this.impossGrenadeChanceScale = binaryReader.ReadSingle();
            this.easyGrenadeTimerScale = binaryReader.ReadSingle();
            this.normalGrenadeTimerScale = binaryReader.ReadSingle();
            this.hardGrenadeTimerScale = binaryReader.ReadSingle();
            this.impossGrenadeTimerScale = binaryReader.ReadSingle();
            this.invalidName_1 = binaryReader.ReadBytes(16);
            this.invalidName_2 = binaryReader.ReadBytes(16);
            this.invalidName_3 = binaryReader.ReadBytes(16);
            this.easyMajorUpgradeNormal = binaryReader.ReadSingle();
            this.normalMajorUpgradeNormal = binaryReader.ReadSingle();
            this.hardMajorUpgradeNormal = binaryReader.ReadSingle();
            this.impossMajorUpgradeNormal = binaryReader.ReadSingle();
            this.easyMajorUpgradeFew = binaryReader.ReadSingle();
            this.normalMajorUpgradeFew = binaryReader.ReadSingle();
            this.hardMajorUpgradeFew = binaryReader.ReadSingle();
            this.impossMajorUpgradeFew = binaryReader.ReadSingle();
            this.easyMajorUpgradeMany = binaryReader.ReadSingle();
            this.normalMajorUpgradeMany = binaryReader.ReadSingle();
            this.hardMajorUpgradeMany = binaryReader.ReadSingle();
            this.impossMajorUpgradeMany = binaryReader.ReadSingle();
            this.easyPlayerVehicleRamChance = binaryReader.ReadSingle();
            this.normalPlayerVehicleRamChance = binaryReader.ReadSingle();
            this.hardPlayerVehicleRamChance = binaryReader.ReadSingle();
            this.impossPlayerVehicleRamChance = binaryReader.ReadSingle();
            this.invalidName_4 = binaryReader.ReadBytes(16);
            this.invalidName_5 = binaryReader.ReadBytes(16);
            this.invalidName_6 = binaryReader.ReadBytes(16);
            this.invalidName_7 = binaryReader.ReadBytes(84);
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
    };
}
