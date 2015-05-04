// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class VehiclePhantomShapeBlock : VehiclePhantomShapeBlockBase
    {
        public VehiclePhantomShapeBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 672, Alignment = 16)]
    public class VehiclePhantomShapeBlockBase : GuerillaBlock
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

        public override int SerializedSize
        {
            get { return 672; }
        }

        public override int Alignment
        {
            get { return 16; }
        }

        public VehiclePhantomShapeBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            invalidName_ = binaryReader.ReadBytes(4);
            size = binaryReader.ReadInt16();
            count = binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(4);
            invalidName_1 = binaryReader.ReadBytes(4);
            childShapesSize = binaryReader.ReadInt32();
            childShapesCapacity = binaryReader.ReadInt32();
            childShapesStorage = new[]
            {new ChildShapesStorage(), new ChildShapesStorage(), new ChildShapesStorage(), new ChildShapesStorage()};
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(childShapesStorage[0].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(childShapesStorage[1].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(childShapesStorage[2].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(childShapesStorage[3].ReadFields(binaryReader)));
            multisphereCount = binaryReader.ReadInt32();
            flags = (Flags) binaryReader.ReadInt32();
            invalidName_2 = binaryReader.ReadBytes(8);
            x0 = binaryReader.ReadSingle();
            x1 = binaryReader.ReadSingle();
            y0 = binaryReader.ReadSingle();
            y1 = binaryReader.ReadSingle();
            z0 = binaryReader.ReadSingle();
            z1 = binaryReader.ReadSingle();
            multispheres = new[] {new Multispheres(), new Multispheres(), new Multispheres(), new Multispheres()};
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(multispheres[0].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(multispheres[1].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(multispheres[2].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(multispheres[3].ReadFields(binaryReader)));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            childShapesStorage[0].ReadPointers(binaryReader, blamPointers);
            childShapesStorage[1].ReadPointers(binaryReader, blamPointers);
            childShapesStorage[2].ReadPointers(binaryReader, blamPointers);
            childShapesStorage[3].ReadPointers(binaryReader, blamPointers);
            multispheres[0].ReadPointers(binaryReader, blamPointers);
            multispheres[1].ReadPointers(binaryReader, blamPointers);
            multispheres[2].ReadPointers(binaryReader, blamPointers);
            multispheres[3].ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
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
                binaryWriter.Write((Int32) flags);
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

        [LayoutAttribute(Size = 8, Alignment = 1)]
        public class ChildShapesStorage : GuerillaBlock
        {
            internal ShapeType shapeType;
            internal Moonfish.Tags.ShortBlockIndex2 shape;
            internal int collisionFilter;

            public override int SerializedSize
            {
                get { return 8; }
            }

            public override int Alignment
            {
                get { return 1; }
            }

            public ChildShapesStorage() : base()
            {
            }

            public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
            {
                var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
                shapeType = (ShapeType) binaryReader.ReadInt16();
                shape = binaryReader.ReadShortBlockIndex2();
                collisionFilter = binaryReader.ReadInt32();
                return blamPointers;
            }

            public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
            {
                base.ReadPointers(binaryReader, blamPointers);
            }

            public override int Write(BinaryWriter binaryWriter, int nextAddress)
            {
                base.Write(binaryWriter, nextAddress);
                using (binaryWriter.BaseStream.Pin())
                {
                    binaryWriter.Write((Int16) shapeType);
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

        [LayoutAttribute(Size = 144, Alignment = 1)]
        public class Multispheres : GuerillaBlock
        {
            internal byte[] invalidName_;
            internal short size;
            internal short count;
            internal byte[] invalidName_0;
            internal int numSpheres;
            internal FourVectorsStorage[] fourVectorsStorage;

            public override int SerializedSize
            {
                get { return 144; }
            }

            public override int Alignment
            {
                get { return 1; }
            }

            public Multispheres() : base()
            {
            }

            public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
            {
                var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
                invalidName_ = binaryReader.ReadBytes(4);
                size = binaryReader.ReadInt16();
                count = binaryReader.ReadInt16();
                invalidName_0 = binaryReader.ReadBytes(4);
                numSpheres = binaryReader.ReadInt32();
                fourVectorsStorage = new[]
                {
                    new FourVectorsStorage(), new FourVectorsStorage(), new FourVectorsStorage(), new FourVectorsStorage(),
                    new FourVectorsStorage(), new FourVectorsStorage(), new FourVectorsStorage(),
                    new FourVectorsStorage()
                };
                blamPointers =
                    new Queue<BlamPointer>(blamPointers.Concat(fourVectorsStorage[0].ReadFields(binaryReader)));
                blamPointers =
                    new Queue<BlamPointer>(blamPointers.Concat(fourVectorsStorage[1].ReadFields(binaryReader)));
                blamPointers =
                    new Queue<BlamPointer>(blamPointers.Concat(fourVectorsStorage[2].ReadFields(binaryReader)));
                blamPointers =
                    new Queue<BlamPointer>(blamPointers.Concat(fourVectorsStorage[3].ReadFields(binaryReader)));
                blamPointers =
                    new Queue<BlamPointer>(blamPointers.Concat(fourVectorsStorage[4].ReadFields(binaryReader)));
                blamPointers =
                    new Queue<BlamPointer>(blamPointers.Concat(fourVectorsStorage[5].ReadFields(binaryReader)));
                blamPointers =
                    new Queue<BlamPointer>(blamPointers.Concat(fourVectorsStorage[6].ReadFields(binaryReader)));
                blamPointers =
                    new Queue<BlamPointer>(blamPointers.Concat(fourVectorsStorage[7].ReadFields(binaryReader)));
                return blamPointers;
            }

            public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
            {
                base.ReadPointers(binaryReader, blamPointers);
                fourVectorsStorage[0].ReadPointers(binaryReader, blamPointers);
                fourVectorsStorage[1].ReadPointers(binaryReader, blamPointers);
                fourVectorsStorage[2].ReadPointers(binaryReader, blamPointers);
                fourVectorsStorage[3].ReadPointers(binaryReader, blamPointers);
                fourVectorsStorage[4].ReadPointers(binaryReader, blamPointers);
                fourVectorsStorage[5].ReadPointers(binaryReader, blamPointers);
                fourVectorsStorage[6].ReadPointers(binaryReader, blamPointers);
                fourVectorsStorage[7].ReadPointers(binaryReader, blamPointers);
            }

            public override int Write(BinaryWriter binaryWriter, int nextAddress)
            {
                base.Write(binaryWriter, nextAddress);
                using (binaryWriter.BaseStream.Pin())
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

            [LayoutAttribute(Size = 16, Alignment = 1)]
            public class FourVectorsStorage : GuerillaBlock
            {
                internal OpenTK.Vector3 sphere;
                internal byte[] invalidName_;

                public override int SerializedSize
                {
                    get { return 16; }
                }

                public override int Alignment
                {
                    get { return 1; }
                }

                public FourVectorsStorage() : base()
                {
                }

                public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
                {
                    var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
                    sphere = binaryReader.ReadVector3();
                    invalidName_ = binaryReader.ReadBytes(4);
                    return blamPointers;
                }

                public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
                {
                    base.ReadPointers(binaryReader, blamPointers);
                }

                public override int Write(BinaryWriter binaryWriter, int nextAddress)
                {
                    base.Write(binaryWriter, nextAddress);
                    using (binaryWriter.BaseStream.Pin())
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