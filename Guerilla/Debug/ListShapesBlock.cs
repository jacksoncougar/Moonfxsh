// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ListShapesBlock : ListShapesBlockBase
    {
        public  ListShapesBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8)]
    public class ListShapesBlockBase
    {
        internal ShapeType shapeType;
        internal Moonfish.Tags.ShortBlockIndex2 shape;
        internal int collisionFilter;
        internal  ListShapesBlockBase(System.IO.BinaryReader binaryReader)
        {
            shapeType = (ShapeType)binaryReader.ReadInt16();
            shape = binaryReader.ReadShortBlockIndex2();
            collisionFilter = binaryReader.ReadInt32();
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
                binaryWriter.Write((Int16)shapeType);
                binaryWriter.Write(shape);
                binaryWriter.Write(collisionFilter);
            }
        }
        internal enum ShapeType : short
        
        {
            Sphere = 0,
            Pill = 1,
            Box = 2,
            Triangle = 3,
            Polyhedron = 4,
            MultiSphere = 5,
            Unused0 = 6,
            Unused1 = 7,
            Unused2 = 8,
            Unused3 = 9,
            Unused4 = 10,
            Unused5 = 11,
            Unused6 = 12,
            Unused7 = 13,
            List = 14,
            Mopp = 15,
        };
    };
}
