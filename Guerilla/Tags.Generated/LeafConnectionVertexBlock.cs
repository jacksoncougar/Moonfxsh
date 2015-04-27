// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class LeafConnectionVertexBlock : LeafConnectionVertexBlockBase
    {
        public  LeafConnectionVertexBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  LeafConnectionVertexBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class LeafConnectionVertexBlockBase : GuerillaBlock
    {
        internal OpenTK.Vector3 vertex;
        
        public override int SerializedSize{get { return 12; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  LeafConnectionVertexBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            vertex = binaryReader.ReadVector3();
        }
        public  LeafConnectionVertexBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            vertex = binaryReader.ReadVector3();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(vertex);
                return nextAddress;
            }
        }
    };
}
