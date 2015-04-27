// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class DecoratorShaderReferenceBlock : DecoratorShaderReferenceBlockBase
    {
        public  DecoratorShaderReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class DecoratorShaderReferenceBlockBase : GuerillaBlock
    {
        [TagReference("shad")]
        internal Moonfish.Tags.TagReference shader;
        
        public override int SerializedSize{get { return 8; }}
        
        internal  DecoratorShaderReferenceBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            shader = binaryReader.ReadTagReference();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(shader);
                return nextAddress;
            }
        }
    };
}
