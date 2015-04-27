// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class VertexShaderReferenceBlock : VertexShaderReferenceBlockBase
    {
        public  VertexShaderReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  VertexShaderReferenceBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class VertexShaderReferenceBlockBase : GuerillaBlock
    {
        [TagReference("vrtx")]
        internal Moonfish.Tags.TagReference vertexShader;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  VertexShaderReferenceBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            vertexShader = binaryReader.ReadTagReference();
        }
        public  VertexShaderReferenceBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(vertexShader);
                return nextAddress;
            }
        }
    };
}
