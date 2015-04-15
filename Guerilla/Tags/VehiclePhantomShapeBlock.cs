// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class VehiclePhantomShapeBlock : VehiclePhantomShapeBlockBase
    {
        public  VehiclePhantomShapeBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 224, Alignment = 16)]
    public class VehiclePhantomShapeBlockBase  : IGuerilla
    {
        internal byte[] invalidName_;
        internal short size;
        internal short count;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;
        internal int childShapesSize;
        internal int childShapesCapacity;
        internal ChildShapesStorage[] childShapesStorage;
        internal int multisphereCount;
        internal Flags flags;
        internal byte[] invalidName_2;
        internal float x0;
        internal float x1;
        internal float y0;
        internal float y1;
        internal float z0;
        internal float z1;
        internal Multispheres[] multispheres;
        internal  VehiclePhantomShapeBlockBase(BinaryReader binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(4);
            size = binaryReader.ReadInt16();
            count = binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(4);
            invalidName_1 = binaryReader.ReadBytes(4);
            childShapesSize = binaryReader.ReadInt32();
            childShapesCapacity = binaryReader.ReadInt32();
            childShapesStorage = new []{ new ChildShapesStorage(binaryReader), new ChildShapesStorage(binaryReader), new ChildShapesStorage(binaryReader), new ChildShapesStorage(binaryReader),  };
            multisphereCount = binaryReader.ReadInt32();
            flags = (Flags)binaryReader.ReadInt32();
            invalidName_2 = binaryReader.ReadBytes(8);
            x0 = binaryReader.ReadSingle();
            x1 = binaryReader.ReadSingle();
            y0 = binaryReader.ReadSingle();
            y1 = binaryReader.ReadSingle();
            z0 = binaryReader.ReadSingle();
            z1 = binaryReader.ReadSingle();
            multispheres = new []{ new Multispheres(binaryReader), new Multispheres(binaryReader), new Multispheres(binaryReader), new Multispheres(binaryReader),  };
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(size);
                binaryWriter.Write(count);
                binaryWriter.Write(invalidName_0, 0, 4);
                binaryWriter.Write(invalidName_1, 0, 4);
                binaryWriter.Write(childShapesSize);
                binaryWriter.Write(childShapesCapacity);
                childShapesStorage[0].Write(binaryWriter);
                childShapesStorage[1].Write(binaryWriter);
                childShapesStorage[2].Write(binaryWriter);
                childShapesStorage[3].Write(binaryWriter);
                binaryWriter.Write(multisphereCount);
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write(invalidName_2, 0, 8);
                binaryWriter.Write(x0);
                binaryWriter.Write(x1);
                binaryWriter.Write(y0);
                binaryWriter.Write(y1);
                binaryWriter.Write(z0);
                binaryWriter.Write(z1);
                multispheres[0].Write(binaryWriter);
                multispheres[1].Write(binaryWriter);
                multispheres[2].Write(binaryWriter);
                multispheres[3].Write(binaryWriter);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        {
            HasAabbPhantom = 1,
            InvalidName = 2,
        };
        public class ChildShapesStorage  : IGuerilla
        {
            internal ShapeType shapeType;
            internal Moonfish.Tags.ShortBlockIndex2 shape;
            internal int collisionFilter;
            internal  ChildShapesStorage(BinaryReader binaryReader)
            {
                shapeType = (ShapeType)binaryReader.ReadInt16();
                shape = binaryReader.ReadShortBlockIndex2();
                collisionFilter = binaryReader.ReadInt32();
            }
            public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
            {
                using(binaryWriter.BaseStream.Pin())
                {
                    binaryWriter.Write((Int16)shapeType);
                    binaryWriter.Write(shape);
                    binaryWriter.Write(collisionFilter);
                    return nextAddress;
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
        public class Multispheres  : IGuerilla
        {
            internal byte[] invalidName_;
            internal short size;
            internal short count;
            internal byte[] invalidName_0;
            internal int numSpheres;
            internal FourVectorsStorage[] fourVectorsStorage;
            internal  Multispheres(BinaryReader binaryReader)
            {
                invalidName_ = binaryReader.ReadBytes(4);
                size = binaryReader.ReadInt16();
                count = binaryReader.ReadInt16();
                invalidName_0 = binaryReader.ReadBytes(4);
                numSpheres = binaryReader.ReadInt32();
                fourVectorsStorage = new []{ new FourVectorsStorage(binaryReader), new FourVectorsStorage(binaryReader), new FourVectorsStorage(binaryReader), new FourVectorsStorage(binaryReader), new FourVectorsStorage(binaryReader), new FourVectorsStorage(binaryReader), new FourVectorsStorage(binaryReader), new FourVectorsStorage(binaryReader),  };
            }
            public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
            {
                using(binaryWriter.BaseStream.Pin())
                {
                    binaryWriter.Write(invalidName_, 0, 4);
                    binaryWriter.Write(size);
                    binaryWriter.Write(count);
                    binaryWriter.Write(invalidName_0, 0, 4);
                    binaryWriter.Write(numSpheres);
                    fourVectorsStorage[0].Write(binaryWriter);
                    fourVectorsStorage[1].Write(binaryWriter);
                    fourVectorsStorage[2].Write(binaryWriter);
                    fourVectorsStorage[3].Write(binaryWriter);
                    fourVectorsStorage[4].Write(binaryWriter);
                    fourVectorsStorage[5].Write(binaryWriter);
                    fourVectorsStorage[6].Write(binaryWriter);
                    fourVectorsStorage[7].Write(binaryWriter);
                    return nextAddress;
                }
            }
            public class FourVectorsStorage  : IGuerilla
            {
                internal OpenTK.Vector3 sphere;
                internal byte[] invalidName_;
                internal  FourVectorsStorage(BinaryReader binaryReader)
                {
                    sphere = binaryReader.ReadVector3();
                    invalidName_ = binaryReader.ReadBytes(4);
                }
                public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
                {
                    using(binaryWriter.BaseStream.Pin())
                    {
                        binaryWriter.Write(sphere);
                        binaryWriter.Write(invalidName_, 0, 4);
                        return nextAddress;
                    }
                }
            };
        };
    };
}
