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
        public  DecoratorCellCollectionBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  DecoratorCellCollectionBlockBase(BinaryReader binaryReader)
        {
            this.childIndices = new []{ new ChildIndices(binaryReader), new ChildIndices(binaryReader), new ChildIndices(binaryReader), new ChildIndices(binaryReader), new ChildIndices(binaryReader), new ChildIndices(binaryReader), new ChildIndices(binaryReader), new ChildIndices(binaryReader),  };
            this.cacheBlockIndex = binaryReader.ReadShortBlockIndex1();
            this.groupCount = binaryReader.ReadInt16();
            this.groupStartIndex = binaryReader.ReadInt32();
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
        public class ChildIndices
        {
            internal short childIndex;
            internal  ChildIndices(BinaryReader binaryReader)
            {
                this.childIndex = binaryReader.ReadInt16();
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
}
