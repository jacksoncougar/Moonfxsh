using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("crea")]
    public  partial class CreatureBlock : CreatureBlockBase
    {
        public  CreatureBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 196)]
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
        [TagReference("jpt!")]
        internal Moonfish.Tags.TagReference impactDamage;
        /// <summary>
        /// if not specified, uses 'impact damage'
        /// </summary>
        [TagReference("jpt!")]
        internal Moonfish.Tags.TagReference impactShieldDamage;
        /// <summary>
        /// if non-zero, the creature will destroy itself upon death after this much time
        /// </summary>
        internal Moonfish.Model.Range destroyAfterDeathTimeSeconds;
        internal  CreatureBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt32();
            this.defaultTeam = (DefaultTeam)binaryReader.ReadInt16();
            this.motionSensorBlipSize = (MotionSensorBlipSize)binaryReader.ReadInt16();
            this.turningVelocityMaximumDegreesPerSecond = binaryReader.ReadSingle();
            this.turningAccelerationMaximumDegreesPerSecondSquared = binaryReader.ReadSingle();
            this.casualTurningModifier01 = binaryReader.ReadSingle();
            this.autoaimWidthWorldUnits = binaryReader.ReadSingle();
            this.physics = new CharacterPhysicsStructBlock(binaryReader);
            this.impactDamage = binaryReader.ReadTagReference();
            this.impactShieldDamage = binaryReader.ReadTagReference();
            this.destroyAfterDeathTimeSeconds = binaryReader.ReadRange();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
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
