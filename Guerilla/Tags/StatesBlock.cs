using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class StatesBlock : StatesBlockBase
    {
        public  StatesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 96)]
    public class StatesBlockBase
    {
        internal Moonfish.Tags.String32 name;
        internal Moonfish.Tags.ColorR8G8B8 color;
        internal short countsAsNeighbors;
        internal byte[] invalidName_;
        internal float initialPlacementWeight;
        internal byte[] invalidName_0;
        internal Moonfish.Tags.ShortBlockIndex1 zero;
        internal Moonfish.Tags.ShortBlockIndex1 one;
        internal Moonfish.Tags.ShortBlockIndex1 two;
        internal Moonfish.Tags.ShortBlockIndex1 three;
        internal Moonfish.Tags.ShortBlockIndex1 four;
        internal Moonfish.Tags.ShortBlockIndex1 five;
        internal Moonfish.Tags.ShortBlockIndex1 six;
        internal Moonfish.Tags.ShortBlockIndex1 seven;
        internal Moonfish.Tags.ShortBlockIndex1 eight;
        internal byte[] invalidName_1;
        internal  StatesBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadString32();
            this.color = binaryReader.ReadColorR8G8B8();
            this.countsAsNeighbors = binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.initialPlacementWeight = binaryReader.ReadSingle();
            this.invalidName_0 = binaryReader.ReadBytes(24);
            this.zero = binaryReader.ReadShortBlockIndex1();
            this.one = binaryReader.ReadShortBlockIndex1();
            this.two = binaryReader.ReadShortBlockIndex1();
            this.three = binaryReader.ReadShortBlockIndex1();
            this.four = binaryReader.ReadShortBlockIndex1();
            this.five = binaryReader.ReadShortBlockIndex1();
            this.six = binaryReader.ReadShortBlockIndex1();
            this.seven = binaryReader.ReadShortBlockIndex1();
            this.eight = binaryReader.ReadShortBlockIndex1();
            this.invalidName_1 = binaryReader.ReadBytes(2);
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
    };
}
