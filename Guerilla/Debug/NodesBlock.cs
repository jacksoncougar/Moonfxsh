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
        public  NodesBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  NodesBlockBase(System.IO.BinaryReader binaryReader)
        {
            name = binaryReader.ReadStringID();
            flags = (Flags)binaryReader.ReadInt16();
            parent = binaryReader.ReadShortBlockIndex1();
            sibling = binaryReader.ReadShortBlockIndex1();
            child = binaryReader.ReadShortBlockIndex1();
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(parent);
                binaryWriter.Write(sibling);
                binaryWriter.Write(child);
            }
        }
        [FlagsAttribute]
        internal enum Flags : short
        
        {
            DoesNotAnimate = 1,
        };
    };
}
