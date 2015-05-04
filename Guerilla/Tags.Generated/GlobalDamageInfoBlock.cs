// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class GlobalDamageInfoBlock : GlobalDamageInfoBlockBase
    {
        public GlobalDamageInfoBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 248, Alignment = 4)]
    public class GlobalDamageInfoBlockBase : GuerillaBlock
    {
        internal Flags flags;
        /// <summary>
        /// absorbes AOE or child damage
        /// </summary>
        internal Moonfish.Tags.StringIdent globalIndirectMaterialName;
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
        internal Moonfish.Tags.StringIdent globalShieldMaterialName;
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
        public override int SerializedSize { get { return 248; } }
        public override int Alignment { get { return 4; } }
        public GlobalDamageInfoBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
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
            blamPointers.Enqueue(ReadBlockArrayPointer<GlobalDamageSectionBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<GlobalDamageNodesBlock>(binaryReader));
            invalidName_4 = binaryReader.ReadBytes(2);
            invalidName_5 = binaryReader.ReadBytes(2);
            invalidName_6 = binaryReader.ReadBytes(4);
            invalidName_7 = binaryReader.ReadBytes(4);
            blamPointers.Enqueue(ReadBlockArrayPointer<DamageSeatInfoBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<DamageConstraintInfoBlock>(binaryReader));
            overshieldFirstPersonShader = binaryReader.ReadTagReference();
            overshieldShader = binaryReader.ReadTagReference();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
            invalidName_[1].ReadPointers(binaryReader, blamPointers);
            invalidName_0[0].ReadPointers(binaryReader, blamPointers);
            invalidName_0[1].ReadPointers(binaryReader, blamPointers);
            invalidName_0[2].ReadPointers(binaryReader, blamPointers);
            invalidName_0[3].ReadPointers(binaryReader, blamPointers);
            invalidName_1[0].ReadPointers(binaryReader, blamPointers);
            invalidName_1[1].ReadPointers(binaryReader, blamPointers);
            invalidName_2[0].ReadPointers(binaryReader, blamPointers);
            invalidName_2[1].ReadPointers(binaryReader, blamPointers);
            invalidName_2[2].ReadPointers(binaryReader, blamPointers);
            invalidName_2[3].ReadPointers(binaryReader, blamPointers);
            invalidName_2[4].ReadPointers(binaryReader, blamPointers);
            invalidName_2[5].ReadPointers(binaryReader, blamPointers);
            invalidName_2[6].ReadPointers(binaryReader, blamPointers);
            invalidName_2[7].ReadPointers(binaryReader, blamPointers);
            invalidName_2[8].ReadPointers(binaryReader, blamPointers);
            invalidName_2[9].ReadPointers(binaryReader, blamPointers);
            invalidName_2[10].ReadPointers(binaryReader, blamPointers);
            invalidName_2[11].ReadPointers(binaryReader, blamPointers);
            invalidName_2[12].ReadPointers(binaryReader, blamPointers);
            invalidName_2[13].ReadPointers(binaryReader, blamPointers);
            invalidName_2[14].ReadPointers(binaryReader, blamPointers);
            invalidName_2[15].ReadPointers(binaryReader, blamPointers);
            invalidName_2[16].ReadPointers(binaryReader, blamPointers);
            invalidName_2[17].ReadPointers(binaryReader, blamPointers);
            invalidName_2[18].ReadPointers(binaryReader, blamPointers);
            invalidName_2[19].ReadPointers(binaryReader, blamPointers);
            invalidName_3[0].ReadPointers(binaryReader, blamPointers);
            invalidName_3[1].ReadPointers(binaryReader, blamPointers);
            invalidName_3[2].ReadPointers(binaryReader, blamPointers);
            invalidName_3[3].ReadPointers(binaryReader, blamPointers);
            invalidName_3[4].ReadPointers(binaryReader, blamPointers);
            invalidName_3[5].ReadPointers(binaryReader, blamPointers);
            invalidName_3[6].ReadPointers(binaryReader, blamPointers);
            invalidName_3[7].ReadPointers(binaryReader, blamPointers);
            invalidName_3[8].ReadPointers(binaryReader, blamPointers);
            invalidName_3[9].ReadPointers(binaryReader, blamPointers);
            invalidName_3[10].ReadPointers(binaryReader, blamPointers);
            invalidName_3[11].ReadPointers(binaryReader, blamPointers);
            invalidName_3[12].ReadPointers(binaryReader, blamPointers);
            invalidName_3[13].ReadPointers(binaryReader, blamPointers);
            invalidName_3[14].ReadPointers(binaryReader, blamPointers);
            invalidName_3[15].ReadPointers(binaryReader, blamPointers);
            invalidName_3[16].ReadPointers(binaryReader, blamPointers);
            invalidName_3[17].ReadPointers(binaryReader, blamPointers);
            invalidName_3[18].ReadPointers(binaryReader, blamPointers);
            invalidName_3[19].ReadPointers(binaryReader, blamPointers);
            invalidName_3[20].ReadPointers(binaryReader, blamPointers);
            invalidName_3[21].ReadPointers(binaryReader, blamPointers);
            invalidName_3[22].ReadPointers(binaryReader, blamPointers);
            invalidName_3[23].ReadPointers(binaryReader, blamPointers);
            invalidName_3[24].ReadPointers(binaryReader, blamPointers);
            invalidName_3[25].ReadPointers(binaryReader, blamPointers);
            invalidName_3[26].ReadPointers(binaryReader, blamPointers);
            invalidName_3[27].ReadPointers(binaryReader, blamPointers);
            invalidName_3[28].ReadPointers(binaryReader, blamPointers);
            invalidName_3[29].ReadPointers(binaryReader, blamPointers);
            invalidName_3[30].ReadPointers(binaryReader, blamPointers);
            invalidName_3[31].ReadPointers(binaryReader, blamPointers);
            invalidName_3[32].ReadPointers(binaryReader, blamPointers);
            invalidName_3[33].ReadPointers(binaryReader, blamPointers);
            invalidName_3[34].ReadPointers(binaryReader, blamPointers);
            invalidName_3[35].ReadPointers(binaryReader, blamPointers);
            invalidName_3[36].ReadPointers(binaryReader, blamPointers);
            invalidName_3[37].ReadPointers(binaryReader, blamPointers);
            invalidName_3[38].ReadPointers(binaryReader, blamPointers);
            invalidName_3[39].ReadPointers(binaryReader, blamPointers);
            invalidName_3[40].ReadPointers(binaryReader, blamPointers);
            invalidName_3[41].ReadPointers(binaryReader, blamPointers);
            invalidName_3[42].ReadPointers(binaryReader, blamPointers);
            invalidName_3[43].ReadPointers(binaryReader, blamPointers);
            invalidName_3[44].ReadPointers(binaryReader, blamPointers);
            invalidName_3[45].ReadPointers(binaryReader, blamPointers);
            invalidName_3[46].ReadPointers(binaryReader, blamPointers);
            invalidName_3[47].ReadPointers(binaryReader, blamPointers);
            invalidName_3[48].ReadPointers(binaryReader, blamPointers);
            invalidName_3[49].ReadPointers(binaryReader, blamPointers);
            invalidName_3[50].ReadPointers(binaryReader, blamPointers);
            invalidName_3[51].ReadPointers(binaryReader, blamPointers);
            invalidName_3[52].ReadPointers(binaryReader, blamPointers);
            invalidName_3[53].ReadPointers(binaryReader, blamPointers);
            invalidName_3[54].ReadPointers(binaryReader, blamPointers);
            invalidName_3[55].ReadPointers(binaryReader, blamPointers);
            invalidName_3[56].ReadPointers(binaryReader, blamPointers);
            invalidName_3[57].ReadPointers(binaryReader, blamPointers);
            invalidName_3[58].ReadPointers(binaryReader, blamPointers);
            invalidName_3[59].ReadPointers(binaryReader, blamPointers);
            invalidName_3[60].ReadPointers(binaryReader, blamPointers);
            invalidName_3[61].ReadPointers(binaryReader, blamPointers);
            invalidName_3[62].ReadPointers(binaryReader, blamPointers);
            invalidName_3[63].ReadPointers(binaryReader, blamPointers);
            damageSections = ReadBlockArrayData<GlobalDamageSectionBlock>(binaryReader, blamPointers.Dequeue());
            nodes = ReadBlockArrayData<GlobalDamageNodesBlock>(binaryReader, blamPointers.Dequeue());
            invalidName_4[0].ReadPointers(binaryReader, blamPointers);
            invalidName_4[1].ReadPointers(binaryReader, blamPointers);
            invalidName_5[0].ReadPointers(binaryReader, blamPointers);
            invalidName_5[1].ReadPointers(binaryReader, blamPointers);
            invalidName_6[0].ReadPointers(binaryReader, blamPointers);
            invalidName_6[1].ReadPointers(binaryReader, blamPointers);
            invalidName_6[2].ReadPointers(binaryReader, blamPointers);
            invalidName_6[3].ReadPointers(binaryReader, blamPointers);
            invalidName_7[0].ReadPointers(binaryReader, blamPointers);
            invalidName_7[1].ReadPointers(binaryReader, blamPointers);
            invalidName_7[2].ReadPointers(binaryReader, blamPointers);
            invalidName_7[3].ReadPointers(binaryReader, blamPointers);
            damageSeats = ReadBlockArrayData<DamageSeatInfoBlock>(binaryReader, blamPointers.Dequeue());
            damageConstraints = ReadBlockArrayData<DamageConstraintInfoBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
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
                nextAddress = Guerilla.WriteBlockArray<GlobalDamageSectionBlock>(binaryWriter, damageSections, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GlobalDamageNodesBlock>(binaryWriter, nodes, nextAddress);
                binaryWriter.Write(invalidName_4, 0, 2);
                binaryWriter.Write(invalidName_5, 0, 2);
                binaryWriter.Write(invalidName_6, 0, 4);
                binaryWriter.Write(invalidName_7, 0, 4);
                nextAddress = Guerilla.WriteBlockArray<DamageSeatInfoBlock>(binaryWriter, damageSeats, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<DamageConstraintInfoBlock>(binaryWriter, damageConstraints, nextAddress);
                binaryWriter.Write(overshieldFirstPersonShader);
                binaryWriter.Write(overshieldShader);
                return nextAddress;
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
