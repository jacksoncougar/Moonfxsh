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
    public partial class MeleeAimAssistStructBlock : MeleeAimAssistStructBlockBase
    {
        public MeleeAimAssistStructBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class MeleeAimAssistStructBlockBase : GuerillaBlock
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
        public override int SerializedSize { get { return 20; } }
        public override int Alignment { get { return 4; } }
        public MeleeAimAssistStructBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            magnetismAngleDegrees = binaryReader.ReadSingle();
            magnetismRangeWorldUnits = binaryReader.ReadSingle();
            throttleMagnitude = binaryReader.ReadSingle();
            throttleMinimumDistance = binaryReader.ReadSingle();
            throttleMaximumAdjustmentAngleDegrees = binaryReader.ReadSingle();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
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
