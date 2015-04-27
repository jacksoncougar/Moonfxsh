// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class VibrationFrequencyDefinitionStructBlock : VibrationFrequencyDefinitionStructBlockBase
    {
        public  VibrationFrequencyDefinitionStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class VibrationFrequencyDefinitionStructBlockBase : GuerillaBlock
    {
        internal float durationSeconds;
        internal MappingFunctionBlock dirtyWhore;
        
        public override int SerializedSize{get { return 12; }}
        
        internal  VibrationFrequencyDefinitionStructBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            durationSeconds = binaryReader.ReadSingle();
            dirtyWhore = new MappingFunctionBlock(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(durationSeconds);
                dirtyWhore.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
