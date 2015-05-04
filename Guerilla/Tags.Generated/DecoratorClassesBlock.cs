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
    public partial class DecoratorClassesBlock : DecoratorClassesBlockBase
    {
        public DecoratorClassesBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class DecoratorClassesBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent name;
        internal Type type;
        internal byte[] invalidName_;
        internal float scale;
        internal DecoratorPermutationsBlock[] permutations;
        public override int SerializedSize { get { return 20; } }
        public override int Alignment { get { return 4; } }
        public DecoratorClassesBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            name = binaryReader.ReadStringID();
            type = (Type)binaryReader.ReadByte();
            invalidName_ = binaryReader.ReadBytes(3);
            scale = binaryReader.ReadSingle();
            blamPointers.Enqueue(ReadBlockArrayPointer<DecoratorPermutationsBlock>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
            invalidName_[1].ReadPointers(binaryReader, blamPointers);
            invalidName_[2].ReadPointers(binaryReader, blamPointers);
            permutations = ReadBlockArrayData<DecoratorPermutationsBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write((Byte)type);
                binaryWriter.Write(invalidName_, 0, 3);
                binaryWriter.Write(scale);
                nextAddress = Guerilla.WriteBlockArray<DecoratorPermutationsBlock>(binaryWriter, permutations, nextAddress);
                return nextAddress;
            }
        }
        internal enum Type : byte
        {
            Model = 0,
            FloatingDecal = 1,
            ProjectedDecal = 2,
            ScreenFacingQuad = 3,
            AxisRotatingQuad = 4,
            CrossQuad = 5,
        };
    };
}
