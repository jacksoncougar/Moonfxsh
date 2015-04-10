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
        public  ListShapesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8)]
    public class ListShapesBlockBase
    {
        internal ShapeType shapeType;
        internal Moonfish.Tags.ShortBlockIndex2 shape;
        internal int collisionFilter;
        internal  ListShapesBlockBase(BinaryReader binaryReader)
        {
            this.shapeType = (ShapeType)binaryReader.ReadInt16();
            this.shape = binaryReader.ReadShortBlockIndex2();
            this.collisionFilter = binaryReader.ReadInt32();
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
