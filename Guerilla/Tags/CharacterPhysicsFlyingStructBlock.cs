using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class CharacterPhysicsFlyingStructBlock : CharacterPhysicsFlyingStructBlockBase
    {
        public  CharacterPhysicsFlyingStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 44)]
    public class CharacterPhysicsFlyingStructBlockBase
    {
        /// <summary>
        /// angle at which we bank left/right when sidestepping or turning while moving forwards
        /// </summary>
        internal float bankAngleDegrees;
        /// <summary>
        /// time it takes us to apply a bank
        /// </summary>
        internal float bankApplyTimeSeconds;
        /// <summary>
        /// time it takes us to recover from a bank
        /// </summary>
        internal float bankDecayTimeSeconds;
        /// <summary>
        /// amount that we pitch up/down when moving up or down
        /// </summary>
        internal float pitchRatio;
        /// <summary>
        /// max velocity when not crouching
        /// </summary>
        internal float maxVelocityWorldUnitsPerSecond;
        /// <summary>
        /// max sideways or up/down velocity when not crouching
        /// </summary>
        internal float maxSidestepVelocityWorldUnitsPerSecond;
        internal float accelerationWorldUnitsPerSecondSquared;
        internal float decelerationWorldUnitsPerSecondSquared;
        /// <summary>
        /// turn rate
        /// </summary>
        internal float angularVelocityMaximumDegreesPerSecond;
        /// <summary>
        /// turn acceleration rate
        /// </summary>
        internal float angularAccelerationMaximumDegreesPerSecondSquared;
        /// <summary>
        /// how much slower we fly if crouching (zero = same speed)
        /// </summary>
        internal float crouchVelocityModifier01;
        internal  CharacterPhysicsFlyingStructBlockBase(BinaryReader binaryReader)
        {
            this.bankAngleDegrees = binaryReader.ReadSingle();
            this.bankApplyTimeSeconds = binaryReader.ReadSingle();
            this.bankDecayTimeSeconds = binaryReader.ReadSingle();
            this.pitchRatio = binaryReader.ReadSingle();
            this.maxVelocityWorldUnitsPerSecond = binaryReader.ReadSingle();
            this.maxSidestepVelocityWorldUnitsPerSecond = binaryReader.ReadSingle();
            this.accelerationWorldUnitsPerSecondSquared = binaryReader.ReadSingle();
            this.decelerationWorldUnitsPerSecondSquared = binaryReader.ReadSingle();
            this.angularVelocityMaximumDegreesPerSecond = binaryReader.ReadSingle();
            this.angularAccelerationMaximumDegreesPerSecondSquared = binaryReader.ReadSingle();
            this.crouchVelocityModifier01 = binaryReader.ReadSingle();
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
