// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class VibrationDefinitionStructBlock : VibrationDefinitionStructBlockBase
    {
        public  VibrationDefinitionStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class VibrationDefinitionStructBlockBase  : IGuerilla
    {
        internal VibrationFrequencyDefinitionStructBlock lowFrequencyVibration;
        internal VibrationFrequencyDefinitionStructBlock highFrequencyVibration;
        internal  VibrationDefinitionStructBlockBase(BinaryReader binaryReader)
        {
            lowFrequencyVibration = new VibrationFrequencyDefinitionStructBlock(binaryReader);
            highFrequencyVibration = new VibrationFrequencyDefinitionStructBlock(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                lowFrequencyVibration.Write(binaryWriter);
                highFrequencyVibration.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
