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
        internal  MeleeAimAssistStructBlockBase(BinaryReader binaryReader)
        {
            this.magnetismAngleDegrees = binaryReader.ReadSingle();
            this.magnetismRangeWorldUnits = binaryReader.ReadSingle();
            this.throttleMagnitude = binaryReader.ReadSingle();
            this.throttleMinimumDistance = binaryReader.ReadSingle();
            this.throttleMaximumAdjustmentAngleDegrees = binaryReader.ReadSingle();
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
