// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class VerticesBlock : VerticesBlockBase
    {
        public  VerticesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  VerticesBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 16)]
    public class VerticesBlockBase : GuerillaBlock
    {
        internal OpenTK.Vector3 point;
        internal short firstEdge;
        internal byte[] invalidName_;
        
        public override int SerializedSize{get { return 16; }}
        
        
        public override int Alignment{get { return 16; }}
        
        public  VerticesBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            point = binaryReader.ReadVector3();
            firstEdge = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
        }
        public  VerticesBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            point = binaryReader.ReadVector3();
            firstEdge = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(point);
                binaryWriter.Write(firstEdge);
                binaryWriter.Write(invalidName_, 0, 2);
                return nextAddress;
            }
        }
    };
}
