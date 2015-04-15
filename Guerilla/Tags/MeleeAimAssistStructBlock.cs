// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class MeleeAimAssistStructBlock : MeleeAimAssistStructBlockBase
    {
        public  MeleeAimAssistStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class MeleeAimAssistStructBlockBase  : IGuerilla
    {
        /// <summary>
        /// the maximum angle that magnetism works at full strength
        /// </summary>
        internal float magnetismAngleDegrees;
        /// <summary>
        /// the maximum distance that magnetism works at full strength
        /// </summary>
        internal float magnetismRangeWorldUnits;
        internal float throttleMagnitude;
        internal float throttleMinimumDistance;
        internal float throttleMaximumAdjustmentAngleDegrees;
        internal  MeleeAimAssistStructBlockBase(BinaryReader binaryReader)
        {
            magnetismAngleDegrees = binaryReader.ReadSingle();
            magnetismRangeWorldUnits = binaryReader.ReadSingle();
            throttleMagnitude = binaryReader.ReadSingle();
            throttleMinimumDistance = binaryReader.ReadSingle();
            throttleMaximumAdjustmentAngleDegrees = binaryReader.ReadSingle();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(magnetismAngleDegrees);
                binaryWriter.Write(magnetismRangeWorldUnits);
                binaryWriter.Write(throttleMagnitude);
                binaryWriter.Write(throttleMinimumDistance);
                binaryWriter.Write(throttleMaximumAdjustmentAngleDegrees);
                return nextAddress;
            }
        }
    };
}
