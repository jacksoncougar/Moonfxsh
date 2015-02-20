using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class PillsBlock : PillsBlockBase
    {
        public  PillsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 80)]
    public class PillsBlockBase
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
        internal OpenTK.Vector3 bottom;
        internal byte[] invalidName_2;
        internal OpenTK.Vector3 top;
        internal byte[] invalidName_3;
        internal  PillsBlockBase(BinaryReader binaryReader)
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
            this.bottom = binaryReader.ReadVector3();
            this.invalidName_2 = binaryReader.ReadBytes(4);
            this.top = binaryReader.ReadVector3();
            this.invalidName_3 = binaryReader.ReadBytes(4);
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
        internal enum Flags : short
        {
            Unused = 1,
        };
    };
}
