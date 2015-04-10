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
        public  BspSurfaceReferenceBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8)]
    public class BspSurfaceReferenceBlockBase
    {
        internal short stripIndex;
        internal short lightmapTriangleIndex;
        internal int bspNodeIndex;
        internal  BspSurfaceReferenceBlockBase(System.IO.BinaryReader binaryReader)
        {
            stripIndex = binaryReader.ReadInt16();
            lightmapTriangleIndex = binaryReader.ReadInt16();
            bspNodeIndex = binaryReader.ReadInt32();
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(stripIndex);
                binaryWriter.Write(lightmapTriangleIndex);
                binaryWriter.Write(bspNodeIndex);
            }
        }
    };
}
