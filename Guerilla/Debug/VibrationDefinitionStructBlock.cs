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
        public  VibrationDefinitionStructBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 24)]
    public class VibrationDefinitionStructBlockBase
    {
        internal VibrationFrequencyDefinitionStructBlock lowFrequencyVibration;
        internal VibrationFrequencyDefinitionStructBlock highFrequencyVibration;
        internal  VibrationDefinitionStructBlockBase(System.IO.BinaryReader binaryReader)
        {
            lowFrequencyVibration = new VibrationFrequencyDefinitionStructBlock(binaryReader);
            highFrequencyVibration = new VibrationFrequencyDefinitionStructBlock(binaryReader);
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
                lowFrequencyVibration.Write(binaryWriter);
                highFrequencyVibration.Write(binaryWriter);
            }
        }
    };
}
