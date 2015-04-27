// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ShaderTemplatePostprocessRemappingNewBlock : ShaderTemplatePostprocessRemappingNewBlockBase
    {
        public  ShaderTemplatePostprocessRemappingNewBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class ShaderTemplatePostprocessRemappingNewBlockBase : GuerillaBlock
    {
        internal byte[] invalidName_;
        internal byte sourceIndex;
        
        public override int SerializedSize{get { return 4; }}
        
        internal  ShaderTemplatePostprocessRemappingNewBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(3);
            sourceIndex = binaryReader.ReadByte();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 3);
                binaryWriter.Write(sourceIndex);
                return nextAddress;
            }
        }
    };
}
