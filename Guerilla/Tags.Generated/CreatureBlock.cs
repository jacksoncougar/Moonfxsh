// ReSharper disable All

using Moonfish.Model;

using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Crea = (TagClass) "crea";
    };
} ;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("crea")]
    public partial class CreatureBlock : CreatureBlockBase
    {
        public CreatureBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 196, Alignment = 4)]
    public class CreatureBlockBase : ObjectBlock
    {
        internal Flags flags;
        internal DefaultTeam defaultTeam;
        internal MotionSensorBlipSize motionSensorBlipSize;
        internal float turningVelocityMaximumDegreesPerSecond;
        internal float turningAccelerationMaximumDegreesPerSecondSquared;
        internal float casualTurningModifier01;
        internal float autoaimWidthWorldUnits;
        internal CharacterPhysicsStructBlock physics;
        [TagReference("jpt!")] internal Moonfish.Tags.TagReference impactDamage;

        /// <summary>
        /// if not specified, uses 'impact damage'
        /// </summary>
        [TagReference("jpt!")] internal Moonfish.Tags.TagReference impactShieldDamage;

        /// <summary>
        /// if non-zero, the creature will destroy itself upon death after this much time
        /// </summary>
        internal Moonfish.Model.Range destroyAfterDeathTimeSeconds;

        public override int SerializedSize
        {
            get { return 384; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public CreatureBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            flags = (Flags) binaryReader.ReadInt32();
            defaultTeam = (DefaultTeam) binaryReader.ReadInt16();
            motionSensorBlipSize = (MotionSensorBlipSize) binaryReader.ReadInt16();
            turningVelocityMaximumDegreesPerSecond = binaryReader.ReadSingle();
            turningAccelerationMaximumDegreesPerSecondSquared = binaryReader.ReadSingle();
            casualTurningModifier01 = binaryReader.ReadSingle();
            autoaimWidthWorldUnits = binaryReader.ReadSingle();
            physics = new CharacterPhysicsStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(physics.ReadFields(binaryReader)));
            impactDamage = binaryReader.ReadTagReference();
            impactShieldDamage = binaryReader.ReadTagReference();
            destroyAfterDeathTimeSeconds = binaryReader.ReadRange();
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            physics.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32) flags);
                binaryWriter.Write((Int16) defaultTeam);
                binaryWriter.Write((Int16) motionSensorBlipSize);
                binaryWriter.Write(turningVelocityMaximumDegreesPerSecond);
                binaryWriter.Write(turningAccelerationMaximumDegreesPerSecondSquared);
                binaryWriter.Write(casualTurningModifier01);
                binaryWriter.Write(autoaimWidthWorldUnits);
                physics.Write(binaryWriter);
                binaryWriter.Write(impactDamage);
                binaryWriter.Write(impactShieldDamage);
                binaryWriter.Write(destroyAfterDeathTimeSeconds);
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum Flags : int
        {
            Unused = 1,
            InfectionForm = 2,
            ImmuneToFallingDamage = 4,
            RotateWhileAirborne = 8,
            ZappedByShields = 16,
            AttachUponImpact = 32,
            NotOnMotionSensor = 64,
        };

        internal enum DefaultTeam : short
        {
            Default = 0,
            Player = 1,
            Human = 2,
            Covenant = 3,
            Flood = 4,
            Sentinel = 5,
            Heretic = 6,
            Prophet = 7,
            Unused8 = 8,
            Unused9 = 9,
            Unused10 = 10,
            Unused11 = 11,
            Unused12 = 12,
            Unused13 = 13,
            Unused14 = 14,
            Unused15 = 15,
        };

        internal enum MotionSensorBlipSize : short
        {
            Medium = 0,
            Small = 1,
            Large = 2,
        };
    };
}