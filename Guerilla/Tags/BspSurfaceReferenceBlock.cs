using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class BspSurfaceReferenceBlock : BspSurfaceReferenceBlockBase
    {
        public  BspSurfaceReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8)]
    public class BspSurfaceReferenceBlockBase
    {
        internal short stripIndex;
        internal short lightmapTriangleIndex;
        internal int bspNodeIndex;
        internal  BspSurfaceReferenceBlockBase(BinaryReader binaryReader)
        {
            this.stripIndex = binaryReader.ReadInt16();
            this.lightmapTriangleIndex = binaryReader.ReadInt16();
            this.bspNodeIndex = binaryReader.ReadInt32();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
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
    };
}
