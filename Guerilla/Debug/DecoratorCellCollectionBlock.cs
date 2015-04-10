// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class DecoratorCellCollectionBlock : DecoratorCellCollectionBlockBase
    {
        public  DecoratorCellCollectionBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 24)]
    public class DecoratorCellCollectionBlockBase
    {
        internal ChildIndices[] childIndices;
        internal Moonfish.Tags.ShortBlockIndex1 cacheBlockIndex;
        internal short groupCount;
        internal int groupStartIndex;
        internal  DecoratorCellCollectionBlockBase(System.IO.BinaryReader binaryReader)
        {
            childIndices = new []{ new ChildIndices(binaryReader), new ChildIndices(binaryReader), new ChildIndices(binaryReader), new ChildIndices(binaryReader), new ChildIndices(binaryReader), new ChildIndices(binaryReader), new ChildIndices(binaryReader), new ChildIndices(binaryReader),  };
            cacheBlockIndex = binaryReader.ReadShortBlockIndex1();
            groupCount = binaryReader.ReadInt16();
            groupStartIndex = binaryReader.ReadInt32();
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
                childIndices[0].Write(binaryWriter);
                childIndices[1].Write(binaryWriter);
                childIndices[2].Write(binaryWriter);
                childIndices[3].Write(binaryWriter);
                childIndices[4].Write(binaryWriter);
                childIndices[5].Write(binaryWriter);
                childIndices[6].Write(binaryWriter);
                childIndices[7].Write(binaryWriter);
                binaryWriter.Write(cacheBlockIndex);
                binaryWriter.Write(groupCount);
                binaryWriter.Write(groupStartIndex);
            }
        }
        public class ChildIndices
        {
            internal short childIndex;
            internal  ChildIndices(System.IO.BinaryReader binaryReader)
            {
                childIndex = binaryReader.ReadInt16();
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
                    binaryWriter.Write(childIndex);
                }
            }
        };
    };
}
