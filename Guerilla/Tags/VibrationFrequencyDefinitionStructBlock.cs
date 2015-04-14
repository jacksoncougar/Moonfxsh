// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class VibrationFrequencyDefinitionStructBlock : VibrationFrequencyDefinitionStructBlockBase
    {
        public  VibrationFrequencyDefinitionStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class VibrationFrequencyDefinitionStructBlockBase  : IGuerilla
    {
        internal float durationSeconds;
        internal MappingFunctionBlock dirtyWhore;
        internal  VibrationFrequencyDefinitionStructBlockBase(BinaryReader binaryReader)
        {
            durationSeconds = binaryReader.ReadSingle();
            dirtyWhore = new MappingFunctionBlock(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(durationSeconds);
                dirtyWhore.Write(binaryWriter);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
