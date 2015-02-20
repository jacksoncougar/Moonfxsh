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
    [LayoutAttribute(Size = 224)]
    public class VehiclePhantomShapeBlockBase
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
            this.invalidName_ = binaryReader.ReadBytes(4);
            this.size = binaryReader.ReadInt16();
            this.count = binaryReader.ReadInt16();
            this.invalidName_0 = binaryReader.ReadBytes(4);
            this.invalidName_1 = binaryReader.ReadBytes(4);
            this.childShapesSize = binaryReader.ReadInt32();
            this.childShapesCapacity = binaryReader.ReadInt32();
            this.childShapesStorage = new []{ new ChildShapesStorage(binaryReader), new ChildShapesStorage(binaryReader), new ChildShapesStorage(binaryReader), new ChildShapesStorage(binaryReader),  };
            this.multisphereCount = binaryReader.ReadInt32();
            this.flags = (Flags)binaryReader.ReadInt32();
            this.invalidName_2 = binaryReader.ReadBytes(8);
            this.x0 = binaryReader.ReadSingle();
            this.x1 = binaryReader.ReadSingle();
            this.y0 = binaryReader.ReadSingle();
            this.y1 = binaryReader.ReadSingle();
            this.z0 = binaryReader.ReadSingle();
            this.z1 = binaryReader.ReadSingle();
            this.multispheres = new []{ new Multispheres(binaryReader), new Multispheres(binaryReader), new Multispheres(binaryReader), new Multispheres(binaryReader),  };
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
        internal enum Flags : int
        {
            HasAabbPhantom = 1,
            InvalidName = 2,
        };
        public class ChildShapesStorage
        {
            internal ShapeType shapeType;
            internal Moonfish.Tags.ShortBlockIndex2 shape;
            internal int collisionFilter;
            internal  ChildShapesStorage(BinaryReader binaryReader)
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
        public class Multispheres
        {
            internal byte[] invalidName_;
            internal short size;
            internal short count;
            internal byte[] invalidName_0;
            internal int numSpheres;
            internal FourVectorsStorage[] fourVectorsStorage;
            internal  Multispheres(BinaryReader binaryReader)
            {
                this.invalidName_ = binaryReader.ReadBytes(4);
                this.size = binaryReader.ReadInt16();
                this.count = binaryReader.ReadInt16();
                this.invalidName_0 = binaryReader.ReadBytes(4);
                this.numSpheres = binaryReader.ReadInt32();
                this.fourVectorsStorage = new []{ new FourVectorsStorage(binaryReader), new FourVectorsStorage(binaryReader), new FourVectorsStorage(binaryReader), new FourVectorsStorage(binaryReader), new FourVectorsStorage(binaryReader), new FourVectorsStorage(binaryReader), new FourVectorsStorage(binaryReader), new FourVectorsStorage(binaryReader),  };
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
            public class FourVectorsStorage
            {
                internal OpenTK.Vector3 sphere;
                internal byte[] invalidName_;
                internal  FourVectorsStorage(BinaryReader binaryReader)
                {
                    this.sphere = binaryReader.ReadVector3();
                    this.invalidName_ = binaryReader.ReadBytes(4);
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
        };
    };
}
