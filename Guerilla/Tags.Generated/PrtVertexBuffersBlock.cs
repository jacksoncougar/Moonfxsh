// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class PrtVertexBuffersBlock : PrtVertexBuffersBlockBase
    {
        public  PrtVertexBuffersBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  PrtVertexBuffersBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 32, Alignment = 4)]
    public class PrtVertexBuffersBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.VertexBuffer vertexBuffer;
        
        public override int SerializedSize{get { return 32; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  PrtVertexBuffersBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            vertexBuffer = binaryReader.ReadVertexBuffer();
        }
        public  PrtVertexBuffersBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            vertexBuffer = binaryReader.ReadVertexBuffer();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(vertexBuffer);
                return nextAddress;
            }
        }
    };
}
