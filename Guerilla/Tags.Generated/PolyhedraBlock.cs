// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class PolyhedraBlock : PolyhedraBlockBase
    {
        public  PolyhedraBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  PolyhedraBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 256, Alignment = 16)]
    public class PolyhedraBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent name;
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
        
        public override int SerializedSize{get { return 256; }}
        
        
        public override int Alignment{get { return 16; }}
        
        public  PolyhedraBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            name = binaryReader.ReadStringID();
            material = binaryReader.ReadShortBlockIndex1();
            flags = (Flags)binaryReader.ReadInt16();
            relativeMassScale = binaryReader.ReadSingle();
            friction = binaryReader.ReadSingle();
            restitution = binaryReader.ReadSingle();
            volume = binaryReader.ReadSingle();
            mass = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(2);
            phantom = binaryReader.ReadShortBlockIndex1();
            invalidName_0 = binaryReader.ReadBytes(4);
            size = binaryReader.ReadInt16();
            count = binaryReader.ReadInt16();
            invalidName_1 = binaryReader.ReadBytes(4);
            radius = binaryReader.ReadSingle();
            aabbHalfExtents = binaryReader.ReadVector3();
            invalidName_2 = binaryReader.ReadBytes(4);
            aabbCenter = binaryReader.ReadVector3();
            invalidName_3 = binaryReader.ReadBytes(4);
            invalidName_4 = binaryReader.ReadBytes(4);
            fourVectorsSize = binaryReader.ReadInt32();
            fourVectorsCapacity = binaryReader.ReadInt32();
            numVertices = binaryReader.ReadInt32();
            fourVectorsStorage = new []{ new FourVectorsStorage(binaryReader), new FourVectorsStorage(binaryReader), new FourVectorsStorage(binaryReader),  };
            invalidName_5 = binaryReader.ReadBytes(4);
            planeEquationsSize = binaryReader.ReadInt32();
            planeEquationsCapacity = binaryReader.ReadInt32();
            invalidName_6 = binaryReader.ReadBytes(4);
        }
        public  PolyhedraBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            name = binaryReader.ReadStringID();
            material = binaryReader.ReadShortBlockIndex1();
            flags = (Flags)binaryReader.ReadInt16();
            relativeMassScale = binaryReader.ReadSingle();
            friction = binaryReader.ReadSingle();
            restitution = binaryReader.ReadSingle();
            volume = binaryReader.ReadSingle();
            mass = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(2);
            phantom = binaryReader.ReadShortBlockIndex1();
            invalidName_0 = binaryReader.ReadBytes(4);
            size = binaryReader.ReadInt16();
            count = binaryReader.ReadInt16();
            invalidName_1 = binaryReader.ReadBytes(4);
            radius = binaryReader.ReadSingle();
            aabbHalfExtents = binaryReader.ReadVector3();
            invalidName_2 = binaryReader.ReadBytes(4);
            aabbCenter = binaryReader.ReadVector3();
            invalidName_3 = binaryReader.ReadBytes(4);
            invalidName_4 = binaryReader.ReadBytes(4);
            fourVectorsSize = binaryReader.ReadInt32();
            fourVectorsCapacity = binaryReader.ReadInt32();
            numVertices = binaryReader.ReadInt32();
            fourVectorsStorage = new []{ new FourVectorsStorage(binaryReader), new FourVectorsStorage(binaryReader), new FourVectorsStorage(binaryReader),  };
            invalidName_5 = binaryReader.ReadBytes(4);
            planeEquationsSize = binaryReader.ReadInt32();
            planeEquationsCapacity = binaryReader.ReadInt32();
            invalidName_6 = binaryReader.ReadBytes(4);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write(material);
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(relativeMassScale);
                binaryWriter.Write(friction);
                binaryWriter.Write(restitution);
                binaryWriter.Write(volume);
                binaryWriter.Write(mass);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(phantom);
                binaryWriter.Write(invalidName_0, 0, 4);
                binaryWriter.Write(size);
                binaryWriter.Write(count);
                binaryWriter.Write(invalidName_1, 0, 4);
                binaryWriter.Write(radius);
                binaryWriter.Write(aabbHalfExtents);
                binaryWriter.Write(invalidName_2, 0, 4);
                binaryWriter.Write(aabbCenter);
                binaryWriter.Write(invalidName_3, 0, 4);
                binaryWriter.Write(invalidName_4, 0, 4);
                binaryWriter.Write(fourVectorsSize);
                binaryWriter.Write(fourVectorsCapacity);
                binaryWriter.Write(numVertices);
                fourVectorsStorage[0].Write(binaryWriter);
                fourVectorsStorage[1].Write(binaryWriter);
                fourVectorsStorage[2].Write(binaryWriter);
                binaryWriter.Write(invalidName_5, 0, 4);
                binaryWriter.Write(planeEquationsSize);
                binaryWriter.Write(planeEquationsCapacity);
                binaryWriter.Write(invalidName_6, 0, 4);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : short
        {
            Unused = 1,
        };
        [LayoutAttribute(Size = 48, Alignment = 1)]
        public class FourVectorsStorage : GuerillaBlock
        {
            internal OpenTK.Vector3 fourVectorsX;
            internal byte[] invalidName_;
            internal OpenTK.Vector3 fourVectorsY;
            internal byte[] invalidName_0;
            internal OpenTK.Vector3 fourVectorsZ;
            internal byte[] invalidName_1;
            
            public override int SerializedSize{get { return 48; }}
            
            
            public override int Alignment{get { return 1; }}
            
            public  FourVectorsStorage(BinaryReader binaryReader): base(binaryReader)
            {
                fourVectorsX = binaryReader.ReadVector3();
                invalidName_ = binaryReader.ReadBytes(4);
                fourVectorsY = binaryReader.ReadVector3();
                invalidName_0 = binaryReader.ReadBytes(4);
                fourVectorsZ = binaryReader.ReadVector3();
                invalidName_1 = binaryReader.ReadBytes(4);
            }
            public  FourVectorsStorage(): base()
            {
                
            }
            public override void Read(BinaryReader binaryReader)
            {
                fourVectorsX = binaryReader.ReadVector3();
                invalidName_ = binaryReader.ReadBytes(4);
                fourVectorsY = binaryReader.ReadVector3();
                invalidName_0 = binaryReader.ReadBytes(4);
                fourVectorsZ = binaryReader.ReadVector3();
                invalidName_1 = binaryReader.ReadBytes(4);
            }
            public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
            {
                using(binaryWriter.BaseStream.Pin())
                {
                    binaryWriter.Write(fourVectorsX);
                    binaryWriter.Write(invalidName_, 0, 4);
                    binaryWriter.Write(fourVectorsY);
                    binaryWriter.Write(invalidName_0, 0, 4);
                    binaryWriter.Write(fourVectorsZ);
                    binaryWriter.Write(invalidName_1, 0, 4);
                    return nextAddress;
                }
            }
        };
    };
}
