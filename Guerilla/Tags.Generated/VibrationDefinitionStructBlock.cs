// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class VibrationDefinitionStructBlock : VibrationDefinitionStructBlockBase
    {
        public  VibrationDefinitionStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  VibrationDefinitionStructBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class VibrationDefinitionStructBlockBase : GuerillaBlock
    {
        internal VibrationFrequencyDefinitionStructBlock lowFrequencyVibration;
        internal VibrationFrequencyDefinitionStructBlock highFrequencyVibration;
        
        public override int SerializedSize{get { return 24; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  VibrationDefinitionStructBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            lowFrequencyVibration = new VibrationFrequencyDefinitionStructBlock(binaryReader);
            highFrequencyVibration = new VibrationFrequencyDefinitionStructBlock(binaryReader);
        }
        public  VibrationDefinitionStructBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            lowFrequencyVibration = new VibrationFrequencyDefinitionStructBlock(binaryReader);
            highFrequencyVibration = new VibrationFrequencyDefinitionStructBlock(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
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
