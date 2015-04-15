// ReSharper disable All
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
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class NodesBlockBase  : IGuerilla
    {
        internal Moonfish.Tags.StringID name;
        internal Flags flags;
        internal Moonfish.Tags.ShortBlockIndex1 parent;
        internal Moonfish.Tags.ShortBlockIndex1 sibling;
        internal Moonfish.Tags.ShortBlockIndex1 child;
        internal  NodesBlockBase(BinaryReader binaryReader)
        {
            name = binaryReader.ReadStringID();
            flags = (Flags)binaryReader.ReadInt16();
            parent = binaryReader.ReadShortBlockIndex1();
            sibling = binaryReader.ReadShortBlockIndex1();
            child = binaryReader.ReadShortBlockIndex1();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(parent);
                binaryWriter.Write(sibling);
                binaryWriter.Write(child);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : short
        {
            DoesNotAnimate = 1,
        };
    };
}
