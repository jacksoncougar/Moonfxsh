using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class PolyhedraBlock : PolyhedraBlockBase
    {
        public  PolyhedraBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 256)]
    public class PolyhedraBlockBase
    {
        internal Moonfish.Tags.StringID name;
        internal Moonfish.Tags.ShortBlockIndex1 material;
        internal Flags flags;
        internal float relativeMassScale;
        internal float friction;
        internal float restitution;
        internal float volume;
        internal float mass;
        internal byte[] invalidName_;
        internal Moonfish.Tags.ShortBlockIndex1 phantom;
        internal byte[] invalidName_0;
        internal short size;
        internal short count;
        internal byte[] invalidName_1;
        internal float radius;
        internal OpenTK.Vector3 aabbHalfExtents;
        internal byte[] invalidName_2;
        internal OpenTK.Vector3 aabbCenter;
        internal byte[] invalidName_3;
        internal byte[] invalidName_4;
        internal int fourVectorsSize;
        internal int fourVectorsCapacity;
        internal int numVertices;
        internal FourVectorsStorage[] fourVectorsStorage;
        internal byte[] invalidName_5;
        internal int planeEquationsSize;
        internal int planeEquationsCapacity;
        internal byte[] invalidName_6;
        internal  PolyhedraBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.material = binaryReader.ReadShortBlockIndex1();
            this.flags = (Flags)binaryReader.ReadInt16();
            this.relativeMassScale = binaryReader.ReadSingle();
            this.friction = binaryReader.ReadSingle();
            this.restitution = binaryReader.ReadSingle();
            this.volume = binaryReader.ReadSingle();
            this.mass = binaryReader.ReadSingle();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.phantom = binaryReader.ReadShortBlockIndex1();
            this.invalidName_0 = binaryReader.ReadBytes(4);
            this.size = binaryReader.ReadInt16();
            this.count = binaryReader.ReadInt16();
            this.invalidName_1 = binaryReader.ReadBytes(4);
            this.radius = binaryReader.ReadSingle();
            this.aabbHalfExtents = binaryReader.ReadVector3();
            this.invalidName_2 = binaryReader.ReadBytes(4);
            this.aabbCenter = binaryReader.ReadVector3();
            this.invalidName_3 = binaryReader.ReadBytes(4);
            this.invalidName_4 = binaryReader.ReadBytes(4);
            this.fourVectorsSize = binaryReader.ReadInt32();
            this.fourVectorsCapacity = binaryReader.ReadInt32();
            this.numVertices = binaryReader.ReadInt32();
            this.fourVectorsStorage = new []{ new FourVectorsStorage(binaryReader), new FourVectorsStorage(binaryReader), new FourVectorsStorage(binaryReader),  };
            this.invalidName_5 = binaryReader.ReadBytes(4);
            this.planeEquationsSize = binaryReader.ReadInt32();
            this.planeEquationsCapacity = binaryReader.ReadInt32();
            this.invalidName_6 = binaryReader.ReadBytes(4);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
        }
        [FlagsAttribute]
        internal enum Flags : short
        
        {
            Unused = 1,
        };
        public class FourVectorsStorage
        {
            internal OpenTK.Vector3 fourVectorsX;
            internal byte[] invalidName_;
            internal OpenTK.Vector3 fourVectorsY;
            internal byte[] invalidName_0;
            internal OpenTK.Vector3 fourVectorsZ;
            internal byte[] invalidName_1;
            internal  FourVectorsStorage(BinaryReader binaryReader)
            {
                this.fourVectorsX = binaryReader.ReadVector3();
                this.invalidName_ = binaryReader.ReadBytes(4);
                this.fourVectorsY = binaryReader.ReadVector3();
                this.invalidName_0 = binaryReader.ReadBytes(4);
                this.fourVectorsZ = binaryReader.ReadVector3();
                this.invalidName_1 = binaryReader.ReadBytes(4);
            }
            internal  virtual byte[] ReadData(BinaryReader binaryReader)
            {
                var blamPointer = binaryReader.ReadBlamPointer(1);
                var data = new byte[blamPointer.elementCount];
                if(blamPointer.elementCount > 0)
                {
                    using (binaryReader.BaseStream.Pin())
                    {
                        binaryReader.BaseStream.Position = blamPointer[0];
                        data = binaryReader.ReadBytes(blamPointer.elementCount);
                    }
                }
                return data;
            }
        };
    };
}
