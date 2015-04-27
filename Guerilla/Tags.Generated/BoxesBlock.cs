// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class BoxesBlock : BoxesBlockBase
    {
        public  BoxesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  BoxesBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 144, Alignment = 16)]
    public class BoxesBlockBase : GuerillaBlock
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
        internal OpenTK.Vector3 halfExtents;
        internal byte[] invalidName_2;
        internal byte[] invalidName_3;
        internal short size0;
        internal short count0;
        internal byte[] invalidName_4;
        internal byte[] invalidName_5;
        internal OpenTK.Vector3 rotationI;
        internal byte[] invalidName_6;
        internal OpenTK.Vector3 rotationJ;
        internal byte[] invalidName_7;
        internal OpenTK.Vector3 rotationK;
        internal byte[] invalidName_8;
        internal OpenTK.Vector3 translation;
        internal byte[] invalidName_9;
        
        public override int SerializedSize{get { return 144; }}
        
        
        public override int Alignment{get { return 16; }}
        
        public  BoxesBlockBase(BinaryReader binaryReader): base(binaryReader)
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
            halfExtents = binaryReader.ReadVector3();
            invalidName_2 = binaryReader.ReadBytes(4);
            invalidName_3 = binaryReader.ReadBytes(4);
            size0 = binaryReader.ReadInt16();
            count0 = binaryReader.ReadInt16();
            invalidName_4 = binaryReader.ReadBytes(4);
            invalidName_5 = binaryReader.ReadBytes(4);
            rotationI = binaryReader.ReadVector3();
            invalidName_6 = binaryReader.ReadBytes(4);
            rotationJ = binaryReader.ReadVector3();
            invalidName_7 = binaryReader.ReadBytes(4);
            rotationK = binaryReader.ReadVector3();
            invalidName_8 = binaryReader.ReadBytes(4);
            translation = binaryReader.ReadVector3();
            invalidName_9 = binaryReader.ReadBytes(4);
        }
        public  BoxesBlockBase(): base()
        {
            
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
                binaryWriter.Write(halfExtents);
                binaryWriter.Write(invalidName_2, 0, 4);
                binaryWriter.Write(invalidName_3, 0, 4);
                binaryWriter.Write(size0);
                binaryWriter.Write(count0);
                binaryWriter.Write(invalidName_4, 0, 4);
                binaryWriter.Write(invalidName_5, 0, 4);
                binaryWriter.Write(rotationI);
                binaryWriter.Write(invalidName_6, 0, 4);
                binaryWriter.Write(rotationJ);
                binaryWriter.Write(invalidName_7, 0, 4);
                binaryWriter.Write(rotationK);
                binaryWriter.Write(invalidName_8, 0, 4);
                binaryWriter.Write(translation);
                binaryWriter.Write(invalidName_9, 0, 4);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : short
        {
            Unused = 1,
        };
    };
}
