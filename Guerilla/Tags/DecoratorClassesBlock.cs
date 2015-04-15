// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class DecoratorClassesBlock : DecoratorClassesBlockBase
    {
        public  DecoratorClassesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class DecoratorClassesBlockBase  : IGuerilla
    {
        internal Moonfish.Tags.StringID name;
        internal Type type;
        internal byte[] invalidName_;
        internal float scale;
        internal DecoratorPermutationsBlock[] permutations;
        internal  DecoratorClassesBlockBase(BinaryReader binaryReader)
        {
            name = binaryReader.ReadStringID();
            type = (Type)binaryReader.ReadByte();
            invalidName_ = binaryReader.ReadBytes(3);
            scale = binaryReader.ReadSingle();
            permutations = Guerilla.ReadBlockArray<DecoratorPermutationsBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
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
