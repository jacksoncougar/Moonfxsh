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
        public  MeleeAimAssistStructBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20)]
    public class MeleeAimAssistStructBlockBase
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
        internal  MeleeAimAssistStructBlockBase(System.IO.BinaryReader binaryReader)
        {
            magnetismAngleDegrees = binaryReader.ReadSingle();
            magnetismRangeWorldUnits = binaryReader.ReadSingle();
            throttleMagnitude = binaryReader.ReadSingle();
            throttleMinimumDistance = binaryReader.ReadSingle();
            throttleMaximumAdjustmentAngleDegrees = binaryReader.ReadSingle();
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
                binaryWriter.Write(magnetismAngleDegrees);
                binaryWriter.Write(magnetismRangeWorldUnits);
                binaryWriter.Write(throttleMagnitude);
                binaryWriter.Write(throttleMinimumDistance);
                binaryWriter.Write(throttleMaximumAdjustmentAngleDegrees);
            }
        }
    };
}
