// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class VerticesBlock : VerticesBlockBase
    {
        public  VerticesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 16)]
    public class VerticesBlockBase  : IGuerilla
    {
        internal OpenTK.Vector3 point;
        internal short firstEdge;
        internal byte[] invalidName_;
        internal  VerticesBlockBase(BinaryReader binaryReader)
        {
            point = binaryReader.ReadVector3();
            firstEdge = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(point);
                binaryWriter.Write(firstEdge);
                binaryWriter.Write(invalidName_, 0, 2);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
