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
    public partial class VibrationDefinitionStructBlock : VibrationDefinitionStructBlockBase
    {
        public VibrationDefinitionStructBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class VibrationDefinitionStructBlockBase : GuerillaBlock
    {
        internal VibrationFrequencyDefinitionStructBlock lowFrequencyVibration;
        internal VibrationFrequencyDefinitionStructBlock highFrequencyVibration;
        public override int SerializedSize { get { return 24; } }
        public override int Alignment { get { return 4; } }
        public VibrationDefinitionStructBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            lowFrequencyVibration = new VibrationFrequencyDefinitionStructBlock();
            blamPointers.Concat(lowFrequencyVibration.ReadFields(binaryReader));
            highFrequencyVibration = new VibrationFrequencyDefinitionStructBlock();
            blamPointers.Concat(highFrequencyVibration.ReadFields(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            lowFrequencyVibration.ReadPointers(binaryReader, blamPointers);
            highFrequencyVibration.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                lowFrequencyVibration.Write(binaryWriter);
                highFrequencyVibration.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
