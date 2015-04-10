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
    [LayoutAttribute(Size = 20)]
    public class DecoratorClassesBlockBase
    {
        internal Moonfish.Tags.StringID name;
        internal Type type;
        internal byte[] invalidName_;
        internal float scale;
        internal DecoratorPermutationsBlock[] permutations;
        internal  DecoratorClassesBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.type = (Type)binaryReader.ReadByte();
            this.invalidName_ = binaryReader.ReadBytes(3);
            this.scale = binaryReader.ReadSingle();
            this.permutations = ReadDecoratorPermutationsBlockArray(binaryReader);
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
        internal  virtual DecoratorPermutationsBlock[] ReadDecoratorPermutationsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(DecoratorPermutationsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new DecoratorPermutationsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new DecoratorPermutationsBlock(binaryReader);
                }
            }
            return array;
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
