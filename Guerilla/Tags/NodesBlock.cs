using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class NodesBlock : NodesBlockBase
    {
        public  NodesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12)]
    public class NodesBlockBase
    {
        internal Moonfish.Tags.StringID name;
        internal Flags flags;
        internal Moonfish.Tags.ShortBlockIndex1 parent;
        internal Moonfish.Tags.ShortBlockIndex1 sibling;
        internal Moonfish.Tags.ShortBlockIndex1 child;
        internal  NodesBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.flags = (Flags)binaryReader.ReadInt16();
            this.parent = binaryReader.ReadShortBlockIndex1();
            this.sibling = binaryReader.ReadShortBlockIndex1();
            this.child = binaryReader.ReadShortBlockIndex1();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
        }
        [FlagsAttribute]
        internal enum Flags : short
        
        {
            DoesNotAnimate = 1,
        };
    };
}
