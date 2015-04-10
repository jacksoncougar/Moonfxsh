// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class StructureBspLeafBlock : StructureBspLeafBlockBase
    {
        public  StructureBspLeafBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8)]
    public class StructureBspLeafBlockBase
    {
        internal short cluster;
        internal short surfaceReferenceCount;
        internal int firstSurfaceReferenceIndex;
        internal  StructureBspLeafBlockBase(System.IO.BinaryReader binaryReader)
        {
            cluster = binaryReader.ReadInt16();
            surfaceReferenceCount = binaryReader.ReadInt16();
            firstSurfaceReferenceIndex = binaryReader.ReadInt32();
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
                binaryWriter.Write(cluster);
                binaryWriter.Write(surfaceReferenceCount);
                binaryWriter.Write(firstSurfaceReferenceIndex);
            }
        }
    };
}
