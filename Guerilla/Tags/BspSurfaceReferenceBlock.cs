// ReSharper disable All
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
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class BspSurfaceReferenceBlockBase  : IGuerilla
    {
        internal short stripIndex;
        internal short lightmapTriangleIndex;
        internal int bspNodeIndex;
        internal  BspSurfaceReferenceBlockBase(BinaryReader binaryReader)
        {
            stripIndex = binaryReader.ReadInt16();
            lightmapTriangleIndex = binaryReader.ReadInt16();
            bspNodeIndex = binaryReader.ReadInt32();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(stripIndex);
                binaryWriter.Write(lightmapTriangleIndex);
                binaryWriter.Write(bspNodeIndex);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
