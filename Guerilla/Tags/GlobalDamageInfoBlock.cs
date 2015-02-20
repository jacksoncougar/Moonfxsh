using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [LayoutAttribute(Size = 248)]
    public  partial class GlobalDamageInfoBlock : GlobalDamageInfoBlockBase
    {
        public  GlobalDamageInfoBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 248)]
    public class GlobalDamageInfoBlockBase
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
            this.flags = (Flags)binaryReader.ReadInt32();
            this.globalIndirectMaterialName = binaryReader.ReadStringID();
            this.indirectDamageSection = binaryReader.ReadShortBlockIndex2();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.invalidName_0 = binaryReader.ReadBytes(4);
            this.collisionDamageReportingType = (CollisionDamageReportingType)binaryReader.ReadByte();
            this.responseDamageReportingType = (ResponseDamageReportingType)binaryReader.ReadByte();
            this.invalidName_1 = binaryReader.ReadBytes(2);
            this.invalidName_2 = binaryReader.ReadBytes(20);
            this.maximumVitality = binaryReader.ReadSingle();
            this.minimumStunDamage = binaryReader.ReadSingle();
            this.stunTimeSeconds = binaryReader.ReadSingle();
            this.rechargeTimeSeconds = binaryReader.ReadSingle();
            this.rechargeFraction = binaryReader.ReadSingle();
            this.invalidName_3 = binaryReader.ReadBytes(64);
            this.shieldDamagedFirstPersonShader = binaryReader.ReadTagReference();
            this.shieldDamagedShader = binaryReader.ReadTagReference();
            this.maximumShieldVitality = binaryReader.ReadSingle();
            this.globalShieldMaterialName = binaryReader.ReadStringID();
            this.minimumStunDamage0 = binaryReader.ReadSingle();
            this.stunTimeSeconds0 = binaryReader.ReadSingle();
            this.rechargeTimeSeconds0 = binaryReader.ReadSingle();
            this.shieldDamagedThreshold = binaryReader.ReadSingle();
            this.shieldDamagedEffect = binaryReader.ReadTagReference();
            this.shieldDepletedEffect = binaryReader.ReadTagReference();
            this.shieldRechargingEffect = binaryReader.ReadTagReference();
            this.damageSections = ReadGlobalDamageSectionBlockArray(binaryReader);
            this.nodes = ReadGlobalDamageNodesBlockArray(binaryReader);
            this.invalidName_4 = binaryReader.ReadBytes(2);
            this.invalidName_5 = binaryReader.ReadBytes(2);
            this.invalidName_6 = binaryReader.ReadBytes(4);
            this.invalidName_7 = binaryReader.ReadBytes(4);
            this.damageSeats = ReadDamageSeatInfoBlockArray(binaryReader);
            this.damageConstraints = ReadDamageConstraintInfoBlockArray(binaryReader);
            this.overshieldFirstPersonShader = binaryReader.ReadTagReference();
            this.overshieldShader = binaryReader.ReadTagReference();
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
        internal  virtual GlobalDamageSectionBlock[] ReadGlobalDamageSectionBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalDamageSectionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalDamageSectionBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalDamageSectionBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GlobalDamageNodesBlock[] ReadGlobalDamageNodesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalDamageNodesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalDamageNodesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalDamageNodesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual DamageSeatInfoBlock[] ReadDamageSeatInfoBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(DamageSeatInfoBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new DamageSeatInfoBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new DamageSeatInfoBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual DamageConstraintInfoBlock[] ReadDamageConstraintInfoBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(DamageConstraintInfoBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new DamageConstraintInfoBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new DamageConstraintInfoBlock(binaryReader);
                }
            }
            return array;
        }
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
