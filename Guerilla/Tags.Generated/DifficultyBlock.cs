// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class DifficultyBlock : DifficultyBlockBase
    {
        public DifficultyBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 644, Alignment = 4 )]
    public class DifficultyBlockBase : IGuerilla
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

        internal DifficultyBlockBase( BinaryReader binaryReader )
        {
            easyEnemyDamage = binaryReader.ReadSingle( );
            normalEnemyDamage = binaryReader.ReadSingle( );
            hardEnemyDamage = binaryReader.ReadSingle( );
            impossEnemyDamage = binaryReader.ReadSingle( );
            easyEnemyVitality = binaryReader.ReadSingle( );
            normalEnemyVitality = binaryReader.ReadSingle( );
            hardEnemyVitality = binaryReader.ReadSingle( );
            impossEnemyVitality = binaryReader.ReadSingle( );
            easyEnemyShield = binaryReader.ReadSingle( );
            normalEnemyShield = binaryReader.ReadSingle( );
            hardEnemyShield = binaryReader.ReadSingle( );
            impossEnemyShield = binaryReader.ReadSingle( );
            easyEnemyRecharge = binaryReader.ReadSingle( );
            normalEnemyRecharge = binaryReader.ReadSingle( );
            hardEnemyRecharge = binaryReader.ReadSingle( );
            impossEnemyRecharge = binaryReader.ReadSingle( );
            easyFriendDamage = binaryReader.ReadSingle( );
            normalFriendDamage = binaryReader.ReadSingle( );
            hardFriendDamage = binaryReader.ReadSingle( );
            impossFriendDamage = binaryReader.ReadSingle( );
            easyFriendVitality = binaryReader.ReadSingle( );
            normalFriendVitality = binaryReader.ReadSingle( );
            hardFriendVitality = binaryReader.ReadSingle( );
            impossFriendVitality = binaryReader.ReadSingle( );
            easyFriendShield = binaryReader.ReadSingle( );
            normalFriendShield = binaryReader.ReadSingle( );
            hardFriendShield = binaryReader.ReadSingle( );
            impossFriendShield = binaryReader.ReadSingle( );
            easyFriendRecharge = binaryReader.ReadSingle( );
            normalFriendRecharge = binaryReader.ReadSingle( );
            hardFriendRecharge = binaryReader.ReadSingle( );
            impossFriendRecharge = binaryReader.ReadSingle( );
            easyInfectionForms = binaryReader.ReadSingle( );
            normalInfectionForms = binaryReader.ReadSingle( );
            hardInfectionForms = binaryReader.ReadSingle( );
            impossInfectionForms = binaryReader.ReadSingle( );
            invalidName_ = binaryReader.ReadBytes( 16 );
            easyRateOfFire = binaryReader.ReadSingle( );
            normalRateOfFire = binaryReader.ReadSingle( );
            hardRateOfFire = binaryReader.ReadSingle( );
            impossRateOfFire = binaryReader.ReadSingle( );
            easyProjectileError = binaryReader.ReadSingle( );
            normalProjectileError = binaryReader.ReadSingle( );
            hardProjectileError = binaryReader.ReadSingle( );
            impossProjectileError = binaryReader.ReadSingle( );
            easyBurstError = binaryReader.ReadSingle( );
            normalBurstError = binaryReader.ReadSingle( );
            hardBurstError = binaryReader.ReadSingle( );
            impossBurstError = binaryReader.ReadSingle( );
            easyNewTargetDelay = binaryReader.ReadSingle( );
            normalNewTargetDelay = binaryReader.ReadSingle( );
            hardNewTargetDelay = binaryReader.ReadSingle( );
            impossNewTargetDelay = binaryReader.ReadSingle( );
            easyBurstSeparation = binaryReader.ReadSingle( );
            normalBurstSeparation = binaryReader.ReadSingle( );
            hardBurstSeparation = binaryReader.ReadSingle( );
            impossBurstSeparation = binaryReader.ReadSingle( );
            easyTargetTracking = binaryReader.ReadSingle( );
            normalTargetTracking = binaryReader.ReadSingle( );
            hardTargetTracking = binaryReader.ReadSingle( );
            impossTargetTracking = binaryReader.ReadSingle( );
            easyTargetLeading = binaryReader.ReadSingle( );
            normalTargetLeading = binaryReader.ReadSingle( );
            hardTargetLeading = binaryReader.ReadSingle( );
            impossTargetLeading = binaryReader.ReadSingle( );
            easyOverchargeChance = binaryReader.ReadSingle( );
            normalOverchargeChance = binaryReader.ReadSingle( );
            hardOverchargeChance = binaryReader.ReadSingle( );
            impossOverchargeChance = binaryReader.ReadSingle( );
            easySpecialFireDelay = binaryReader.ReadSingle( );
            normalSpecialFireDelay = binaryReader.ReadSingle( );
            hardSpecialFireDelay = binaryReader.ReadSingle( );
            impossSpecialFireDelay = binaryReader.ReadSingle( );
            easyGuidanceVsPlayer = binaryReader.ReadSingle( );
            normalGuidanceVsPlayer = binaryReader.ReadSingle( );
            hardGuidanceVsPlayer = binaryReader.ReadSingle( );
            impossGuidanceVsPlayer = binaryReader.ReadSingle( );
            easyMeleeDelayBase = binaryReader.ReadSingle( );
            normalMeleeDelayBase = binaryReader.ReadSingle( );
            hardMeleeDelayBase = binaryReader.ReadSingle( );
            impossMeleeDelayBase = binaryReader.ReadSingle( );
            easyMeleeDelayScale = binaryReader.ReadSingle( );
            normalMeleeDelayScale = binaryReader.ReadSingle( );
            hardMeleeDelayScale = binaryReader.ReadSingle( );
            impossMeleeDelayScale = binaryReader.ReadSingle( );
            invalidName_0 = binaryReader.ReadBytes( 16 );
            easyGrenadeChanceScale = binaryReader.ReadSingle( );
            normalGrenadeChanceScale = binaryReader.ReadSingle( );
            hardGrenadeChanceScale = binaryReader.ReadSingle( );
            impossGrenadeChanceScale = binaryReader.ReadSingle( );
            easyGrenadeTimerScale = binaryReader.ReadSingle( );
            normalGrenadeTimerScale = binaryReader.ReadSingle( );
            hardGrenadeTimerScale = binaryReader.ReadSingle( );
            impossGrenadeTimerScale = binaryReader.ReadSingle( );
            invalidName_1 = binaryReader.ReadBytes( 16 );
            invalidName_2 = binaryReader.ReadBytes( 16 );
            invalidName_3 = binaryReader.ReadBytes( 16 );
            easyMajorUpgradeNormal = binaryReader.ReadSingle( );
            normalMajorUpgradeNormal = binaryReader.ReadSingle( );
            hardMajorUpgradeNormal = binaryReader.ReadSingle( );
            impossMajorUpgradeNormal = binaryReader.ReadSingle( );
            easyMajorUpgradeFew = binaryReader.ReadSingle( );
            normalMajorUpgradeFew = binaryReader.ReadSingle( );
            hardMajorUpgradeFew = binaryReader.ReadSingle( );
            impossMajorUpgradeFew = binaryReader.ReadSingle( );
            easyMajorUpgradeMany = binaryReader.ReadSingle( );
            normalMajorUpgradeMany = binaryReader.ReadSingle( );
            hardMajorUpgradeMany = binaryReader.ReadSingle( );
            impossMajorUpgradeMany = binaryReader.ReadSingle( );
            easyPlayerVehicleRamChance = binaryReader.ReadSingle( );
            normalPlayerVehicleRamChance = binaryReader.ReadSingle( );
            hardPlayerVehicleRamChance = binaryReader.ReadSingle( );
            impossPlayerVehicleRamChance = binaryReader.ReadSingle( );
            invalidName_4 = binaryReader.ReadBytes( 16 );
            invalidName_5 = binaryReader.ReadBytes( 16 );
            invalidName_6 = binaryReader.ReadBytes( 16 );
            invalidName_7 = binaryReader.ReadBytes( 84 );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( easyEnemyDamage );
                binaryWriter.Write( normalEnemyDamage );
                binaryWriter.Write( hardEnemyDamage );
                binaryWriter.Write( impossEnemyDamage );
                binaryWriter.Write( easyEnemyVitality );
                binaryWriter.Write( normalEnemyVitality );
                binaryWriter.Write( hardEnemyVitality );
                binaryWriter.Write( impossEnemyVitality );
                binaryWriter.Write( easyEnemyShield );
                binaryWriter.Write( normalEnemyShield );
                binaryWriter.Write( hardEnemyShield );
                binaryWriter.Write( impossEnemyShield );
                binaryWriter.Write( easyEnemyRecharge );
                binaryWriter.Write( normalEnemyRecharge );
                binaryWriter.Write( hardEnemyRecharge );
                binaryWriter.Write( impossEnemyRecharge );
                binaryWriter.Write( easyFriendDamage );
                binaryWriter.Write( normalFriendDamage );
                binaryWriter.Write( hardFriendDamage );
                binaryWriter.Write( impossFriendDamage );
                binaryWriter.Write( easyFriendVitality );
                binaryWriter.Write( normalFriendVitality );
                binaryWriter.Write( hardFriendVitality );
                binaryWriter.Write( impossFriendVitality );
                binaryWriter.Write( easyFriendShield );
                binaryWriter.Write( normalFriendShield );
                binaryWriter.Write( hardFriendShield );
                binaryWriter.Write( impossFriendShield );
                binaryWriter.Write( easyFriendRecharge );
                binaryWriter.Write( normalFriendRecharge );
                binaryWriter.Write( hardFriendRecharge );
                binaryWriter.Write( impossFriendRecharge );
                binaryWriter.Write( easyInfectionForms );
                binaryWriter.Write( normalInfectionForms );
                binaryWriter.Write( hardInfectionForms );
                binaryWriter.Write( impossInfectionForms );
                binaryWriter.Write( invalidName_, 0, 16 );
                binaryWriter.Write( easyRateOfFire );
                binaryWriter.Write( normalRateOfFire );
                binaryWriter.Write( hardRateOfFire );
                binaryWriter.Write( impossRateOfFire );
                binaryWriter.Write( easyProjectileError );
                binaryWriter.Write( normalProjectileError );
                binaryWriter.Write( hardProjectileError );
                binaryWriter.Write( impossProjectileError );
                binaryWriter.Write( easyBurstError );
                binaryWriter.Write( normalBurstError );
                binaryWriter.Write( hardBurstError );
                binaryWriter.Write( impossBurstError );
                binaryWriter.Write( easyNewTargetDelay );
                binaryWriter.Write( normalNewTargetDelay );
                binaryWriter.Write( hardNewTargetDelay );
                binaryWriter.Write( impossNewTargetDelay );
                binaryWriter.Write( easyBurstSeparation );
                binaryWriter.Write( normalBurstSeparation );
                binaryWriter.Write( hardBurstSeparation );
                binaryWriter.Write( impossBurstSeparation );
                binaryWriter.Write( easyTargetTracking );
                binaryWriter.Write( normalTargetTracking );
                binaryWriter.Write( hardTargetTracking );
                binaryWriter.Write( impossTargetTracking );
                binaryWriter.Write( easyTargetLeading );
                binaryWriter.Write( normalTargetLeading );
                binaryWriter.Write( hardTargetLeading );
                binaryWriter.Write( impossTargetLeading );
                binaryWriter.Write( easyOverchargeChance );
                binaryWriter.Write( normalOverchargeChance );
                binaryWriter.Write( hardOverchargeChance );
                binaryWriter.Write( impossOverchargeChance );
                binaryWriter.Write( easySpecialFireDelay );
                binaryWriter.Write( normalSpecialFireDelay );
                binaryWriter.Write( hardSpecialFireDelay );
                binaryWriter.Write( impossSpecialFireDelay );
                binaryWriter.Write( easyGuidanceVsPlayer );
                binaryWriter.Write( normalGuidanceVsPlayer );
                binaryWriter.Write( hardGuidanceVsPlayer );
                binaryWriter.Write( impossGuidanceVsPlayer );
                binaryWriter.Write( easyMeleeDelayBase );
                binaryWriter.Write( normalMeleeDelayBase );
                binaryWriter.Write( hardMeleeDelayBase );
                binaryWriter.Write( impossMeleeDelayBase );
                binaryWriter.Write( easyMeleeDelayScale );
                binaryWriter.Write( normalMeleeDelayScale );
                binaryWriter.Write( hardMeleeDelayScale );
                binaryWriter.Write( impossMeleeDelayScale );
                binaryWriter.Write( invalidName_0, 0, 16 );
                binaryWriter.Write( easyGrenadeChanceScale );
                binaryWriter.Write( normalGrenadeChanceScale );
                binaryWriter.Write( hardGrenadeChanceScale );
                binaryWriter.Write( impossGrenadeChanceScale );
                binaryWriter.Write( easyGrenadeTimerScale );
                binaryWriter.Write( normalGrenadeTimerScale );
                binaryWriter.Write( hardGrenadeTimerScale );
                binaryWriter.Write( impossGrenadeTimerScale );
                binaryWriter.Write( invalidName_1, 0, 16 );
                binaryWriter.Write( invalidName_2, 0, 16 );
                binaryWriter.Write( invalidName_3, 0, 16 );
                binaryWriter.Write( easyMajorUpgradeNormal );
                binaryWriter.Write( normalMajorUpgradeNormal );
                binaryWriter.Write( hardMajorUpgradeNormal );
                binaryWriter.Write( impossMajorUpgradeNormal );
                binaryWriter.Write( easyMajorUpgradeFew );
                binaryWriter.Write( normalMajorUpgradeFew );
                binaryWriter.Write( hardMajorUpgradeFew );
                binaryWriter.Write( impossMajorUpgradeFew );
                binaryWriter.Write( easyMajorUpgradeMany );
                binaryWriter.Write( normalMajorUpgradeMany );
                binaryWriter.Write( hardMajorUpgradeMany );
                binaryWriter.Write( impossMajorUpgradeMany );
                binaryWriter.Write( easyPlayerVehicleRamChance );
                binaryWriter.Write( normalPlayerVehicleRamChance );
                binaryWriter.Write( hardPlayerVehicleRamChance );
                binaryWriter.Write( impossPlayerVehicleRamChance );
                binaryWriter.Write( invalidName_4, 0, 16 );
                binaryWriter.Write( invalidName_5, 0, 16 );
                binaryWriter.Write( invalidName_6, 0, 16 );
                binaryWriter.Write( invalidName_7, 0, 84 );
                return nextAddress;
            }
        }
    };
}