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
        public  DecoratorClassesBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  DecoratorClassesBlockBase(System.IO.BinaryReader binaryReader)
        {
            name = binaryReader.ReadStringID();
            type = (Type)binaryReader.ReadByte();
            invalidName_ = binaryReader.ReadBytes(3);
            scale = binaryReader.ReadSingle();
            ReadDecoratorPermutationsBlockArray(binaryReader);
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
        internal  virtual DecoratorPermutationsBlock[] ReadDecoratorPermutationsBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteDecoratorPermutationsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write((Byte)type);
                binaryWriter.Write(invalidName_, 0, 3);
                binaryWriter.Write(scale);
                WriteDecoratorPermutationsBlockArray(binaryWriter);
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
