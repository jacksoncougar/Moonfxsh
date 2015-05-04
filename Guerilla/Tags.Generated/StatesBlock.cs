// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class StatesBlock : StatesBlockBase
    {
        public StatesBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 96, Alignment = 4)]
    public class StatesBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.String32 name;
        internal Moonfish.Tags.ColourR8G8B8 color;
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

        public override int SerializedSize
        {
            get { return 96; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public StatesBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            name = binaryReader.ReadString32();
            color = binaryReader.ReadColorR8G8B8();
            countsAsNeighbors = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            initialPlacementWeight = binaryReader.ReadSingle();
            invalidName_0 = binaryReader.ReadBytes(24);
            zero = binaryReader.ReadShortBlockIndex1();
            one = binaryReader.ReadShortBlockIndex1();
            two = binaryReader.ReadShortBlockIndex1();
            three = binaryReader.ReadShortBlockIndex1();
            four = binaryReader.ReadShortBlockIndex1();
            five = binaryReader.ReadShortBlockIndex1();
            six = binaryReader.ReadShortBlockIndex1();
            seven = binaryReader.ReadShortBlockIndex1();
            eight = binaryReader.ReadShortBlockIndex1();
            invalidName_1 = binaryReader.ReadBytes(2);
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write(color);
                binaryWriter.Write(countsAsNeighbors);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(initialPlacementWeight);
                binaryWriter.Write(invalidName_0, 0, 24);
                binaryWriter.Write(zero);
                binaryWriter.Write(one);
                binaryWriter.Write(two);
                binaryWriter.Write(three);
                binaryWriter.Write(four);
                binaryWriter.Write(five);
                binaryWriter.Write(six);
                binaryWriter.Write(seven);
                binaryWriter.Write(eight);
                binaryWriter.Write(invalidName_1, 0, 2);
                return nextAddress;
            }
        }
    };
}