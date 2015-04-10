// ReSharper disable All
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
        public  CharacterPhysicsFlyingStructBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  CharacterPhysicsFlyingStructBlockBase(System.IO.BinaryReader binaryReader)
        {
            bankAngleDegrees = binaryReader.ReadSingle();
            bankApplyTimeSeconds = binaryReader.ReadSingle();
            bankDecayTimeSeconds = binaryReader.ReadSingle();
            pitchRatio = binaryReader.ReadSingle();
            maxVelocityWorldUnitsPerSecond = binaryReader.ReadSingle();
            maxSidestepVelocityWorldUnitsPerSecond = binaryReader.ReadSingle();
            accelerationWorldUnitsPerSecondSquared = binaryReader.ReadSingle();
            decelerationWorldUnitsPerSecondSquared = binaryReader.ReadSingle();
            angularVelocityMaximumDegreesPerSecond = binaryReader.ReadSingle();
            angularAccelerationMaximumDegreesPerSecondSquared = binaryReader.ReadSingle();
            crouchVelocityModifier01 = binaryReader.ReadSingle();
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(bankAngleDegrees);
                binaryWriter.Write(bankApplyTimeSeconds);
                binaryWriter.Write(bankDecayTimeSeconds);
                binaryWriter.Write(pitchRatio);
                binaryWriter.Write(maxVelocityWorldUnitsPerSecond);
                binaryWriter.Write(maxSidestepVelocityWorldUnitsPerSecond);
                binaryWriter.Write(accelerationWorldUnitsPerSecondSquared);
                binaryWriter.Write(decelerationWorldUnitsPerSecondSquared);
                binaryWriter.Write(angularVelocityMaximumDegreesPerSecond);
                binaryWriter.Write(angularAccelerationMaximumDegreesPerSecondSquared);
                binaryWriter.Write(crouchVelocityModifier01);
            }
        }
    };
}
