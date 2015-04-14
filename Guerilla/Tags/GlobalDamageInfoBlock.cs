// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GlobalDamageInfoBlock : GlobalDamageInfoBlockBase
    {
        public  GlobalDamageInfoBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 248, Alignment = 4)]
    public class GlobalDamageInfoBlockBase  : IGuerilla
    {
        internal Flags flags;
        /// <summary>
        /// absorbes AOE or child damage
        /// </summary>
        internal Moonfish.Tags.StringID globalIndirectMaterialName;
        /// <summary>
        /// absorbes AOE or child damage
        /// </summary>
        internal Moonfish.Tags.ShortBlockIndex2 indirectDamageSection;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal CollisionDamageReportingType collisionDamageReportingType;
        internal ResponseDamageReportingType responseDamageReportingType;
        internal byte[] invalidName_1;
        internal byte[] invalidName_2;
        internal float maximumVitality;
        /// <summary>
        /// the minimum damage required to stun this object's health
        /// </summary>
        internal float minimumStunDamage;
        /// <summary>
        /// the length of time the health stay stunned (do not recharge) after taking damage
        /// </summary>
        internal float stunTimeSeconds;
        /// <summary>
        /// the length of time it would take for the shields to fully recharge after being completely depleted
        /// </summary>
        internal float rechargeTimeSeconds;
        /// <summary>
        /// 0 defaults to 1 - to what maximum level the body health will be allowed to recharge
        /// </summary>
        internal float rechargeFraction;
        internal byte[] invalidName_3;
        [TagReference("shad")]
        internal Moonfish.Tags.TagReference shieldDamagedFirstPersonShader;
        [TagReference("shad")]
        internal Moonfish.Tags.TagReference shieldDamagedShader;
        /// <summary>
        /// the default initial and maximumShieldVitality of this object
        /// </summary>
        internal float maximumShieldVitality;
        internal Moonfish.Tags.StringID globalShieldMaterialName;
        /// <summary>
        /// the minimum damage required to stun this object's shields
        /// </summary>
        internal float minimumStunDamage0;
        /// <summary>
        /// the length of time the shields stay stunned (do not recharge) after taking damage
        /// </summary>
        internal float stunTimeSeconds0;
        /// <summary>
        /// the length of time it would take for the shields to fully recharge after being completely depleted
        /// </summary>
        internal float rechargeTimeSeconds0;
        internal float shieldDamagedThreshold;
        [TagReference("effe")]
        internal Moonfish.Tags.TagReference shieldDamagedEffect;
        [TagReference("effe")]
        internal Moonfish.Tags.TagReference shieldDepletedEffect;
        [TagReference("effe")]
        internal Moonfish.Tags.TagReference shieldRechargingEffect;
        internal GlobalDamageSectionBlock[] damageSections;
        internal GlobalDamageNodesBlock[] nodes;
        internal byte[] invalidName_4;
        internal byte[] invalidName_5;
        internal byte[] invalidName_6;
        internal byte[] invalidName_7;
        internal DamageSeatInfoBlock[] damageSeats;
        internal DamageConstraintInfoBlock[] damageConstraints;
        [TagReference("shad")]
        internal Moonfish.Tags.TagReference overshieldFirstPersonShader;
        [TagReference("shad")]
        internal Moonfish.Tags.TagReference overshieldShader;
        internal  GlobalDamageInfoBlockBase(BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt32();
            globalIndirectMaterialName = binaryReader.ReadStringID();
            indirectDamageSection = binaryReader.ReadShortBlockIndex2();
            invalidName_ = binaryReader.ReadBytes(2);
            invalidName_0 = binaryReader.ReadBytes(4);
            collisionDamageReportingType = (CollisionDamageReportingType)binaryReader.ReadByte();
            responseDamageReportingType = (ResponseDamageReportingType)binaryReader.ReadByte();
            invalidName_1 = binaryReader.ReadBytes(2);
            invalidName_2 = binaryReader.ReadBytes(20);
            maximumVitality = binaryReader.ReadSingle();
            minimumStunDamage = binaryReader.ReadSingle();
            stunTimeSeconds = binaryReader.ReadSingle();
            rechargeTimeSeconds = binaryReader.ReadSingle();
            rechargeFraction = binaryReader.ReadSingle();
            invalidName_3 = binaryReader.ReadBytes(64);
            shieldDamagedFirstPersonShader = binaryReader.ReadTagReference();
            shieldDamagedShader = binaryReader.ReadTagReference();
            maximumShieldVitality = binaryReader.ReadSingle();
            globalShieldMaterialName = binaryReader.ReadStringID();
            minimumStunDamage0 = binaryReader.ReadSingle();
            stunTimeSeconds0 = binaryReader.ReadSingle();
            rechargeTimeSeconds0 = binaryReader.ReadSingle();
            shieldDamagedThreshold = binaryReader.ReadSingle();
            shieldDamagedEffect = binaryReader.ReadTagReference();
            shieldDepletedEffect = binaryReader.ReadTagReference();
            shieldRechargingEffect = binaryReader.ReadTagReference();
            damageSections = Guerilla.ReadBlockArray<GlobalDamageSectionBlock>(binaryReader);
            nodes = Guerilla.ReadBlockArray<GlobalDamageNodesBlock>(binaryReader);
            invalidName_4 = binaryReader.ReadBytes(2);
            invalidName_5 = binaryReader.ReadBytes(2);
            invalidName_6 = binaryReader.ReadBytes(4);
            invalidName_7 = binaryReader.ReadBytes(4);
            damageSeats = Guerilla.ReadBlockArray<DamageSeatInfoBlock>(binaryReader);
            damageConstraints = Guerilla.ReadBlockArray<DamageConstraintInfoBlock>(binaryReader);
            overshieldFirstPersonShader = binaryReader.ReadTagReference();
            overshieldShader = binaryReader.ReadTagReference();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write(globalIndirectMaterialName);
                binaryWriter.Write(indirectDamageSection);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(invalidName_0, 0, 4);
                binaryWriter.Write((Byte)collisionDamageReportingType);
                binaryWriter.Write((Byte)responseDamageReportingType);
                binaryWriter.Write(invalidName_1, 0, 2);
                binaryWriter.Write(invalidName_2, 0, 20);
                binaryWriter.Write(maximumVitality);
                binaryWriter.Write(minimumStunDamage);
                binaryWriter.Write(stunTimeSeconds);
                binaryWriter.Write(rechargeTimeSeconds);
                binaryWriter.Write(rechargeFraction);
                binaryWriter.Write(invalidName_3, 0, 64);
                binaryWriter.Write(shieldDamagedFirstPersonShader);
                binaryWriter.Write(shieldDamagedShader);
                binaryWriter.Write(maximumShieldVitality);
                binaryWriter.Write(globalShieldMaterialName);
                binaryWriter.Write(minimumStunDamage0);
                binaryWriter.Write(stunTimeSeconds0);
                binaryWriter.Write(rechargeTimeSeconds0);
                binaryWriter.Write(shieldDamagedThreshold);
                binaryWriter.Write(shieldDamagedEffect);
                binaryWriter.Write(shieldDepletedEffect);
                binaryWriter.Write(shieldRechargingEffect);
                Guerilla.WriteBlockArray<GlobalDamageSectionBlock>(binaryWriter, damageSections, nextAddress);
                Guerilla.WriteBlockArray<GlobalDamageNodesBlock>(binaryWriter, nodes, nextAddress);
                binaryWriter.Write(invalidName_4, 0, 2);
                binaryWriter.Write(invalidName_5, 0, 2);
                binaryWriter.Write(invalidName_6, 0, 4);
                binaryWriter.Write(invalidName_7, 0, 4);
                Guerilla.WriteBlockArray<DamageSeatInfoBlock>(binaryWriter, damageSeats, nextAddress);
                Guerilla.WriteBlockArray<DamageConstraintInfoBlock>(binaryWriter, damageConstraints, nextAddress);
                binaryWriter.Write(overshieldFirstPersonShader);
                binaryWriter.Write(overshieldShader);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        {
            TakesShieldDamageForChildren = 1,
            TakesBodyDamageForChildren = 2,
            AlwaysShieldsFriendlyDamage = 4,
            PassesAreaDamageToChildren = 8,
            ParentNeverTakesBodyDamageForUs = 16,
            OnlyDamagedByExplosives = 32,
            ParentNeverTakesShieldDamageForUs = 64,
            CannotDieFromDamage = 128,
            PassesAttachedDamageToRiders = 256,
        };
        internal enum CollisionDamageReportingType : byte
        {
            TehGuardians11 = 0,
            FallingDamage = 1,
            GenericCollisionDamage = 2,
            GenericMeleeDamage = 3,
            GenericExplosion = 4,
            MagnumPistol = 5,
            PlasmaPistol = 6,
            Needler = 7,
            Smg = 8,
            PlasmaRifle = 9,
            BattleRifle = 10,
            Carbine = 11,
            Shotgun = 12,
            SniperRifle = 13,
            BeamRifle = 14,
            RocketLauncher = 15,
            FlakCannon = 16,
            BruteShot = 17,
            Disintegrator = 18,
            BrutePlasmaRifle = 19,
            EnergySword = 20,
            FragGrenade = 21,
            PlasmaGrenade = 22,
            FlagMeleeDamage = 23,
            BombMeleeDamage = 24,
            BombExplosionDamage = 25,
            BallMeleeDamage = 26,
            HumanTurret = 27,
            PlasmaTurret = 28,
            Banshee = 29,
            Ghost = 30,
            Mongoose = 31,
            Scorpion = 32,
            SpectreDriver = 33,
            SpectreGunner = 34,
            WarthogDriver = 35,
            WarthogGunner = 36,
            Wraith = 37,
            Tank = 38,
            SentinelBeam = 39,
            SentinelRpg = 40,
            Teleporter = 41,
        };
        internal enum ResponseDamageReportingType : byte
        {
            TehGuardians11 = 0,
            FallingDamage = 1,
            GenericCollisionDamage = 2,
            GenericMeleeDamage = 3,
            GenericExplosion = 4,
            MagnumPistol = 5,
            PlasmaPistol = 6,
            Needler = 7,
            Smg = 8,
            PlasmaRifle = 9,
            BattleRifle = 10,
            Carbine = 11,
            Shotgun = 12,
            SniperRifle = 13,
            BeamRifle = 14,
            RocketLauncher = 15,
            FlakCannon = 16,
            BruteShot = 17,
            Disintegrator = 18,
            BrutePlasmaRifle = 19,
            EnergySword = 20,
            FragGrenade = 21,
            PlasmaGrenade = 22,
            FlagMeleeDamage = 23,
            BombMeleeDamage = 24,
            BombExplosionDamage = 25,
            BallMeleeDamage = 26,
            HumanTurret = 27,
            PlasmaTurret = 28,
            Banshee = 29,
            Ghost = 30,
            Mongoose = 31,
            Scorpion = 32,
            SpectreDriver = 33,
            SpectreGunner = 34,
            WarthogDriver = 35,
            WarthogGunner = 36,
            Wraith = 37,
            Tank = 38,
            SentinelBeam = 39,
            SentinelRpg = 40,
            Teleporter = 41,
        };
    };
}
