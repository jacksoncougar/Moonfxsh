// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class CharacterFiringPatternPropertiesBlock : CharacterFiringPatternPropertiesBlockBase
    {
        public  CharacterFiringPatternPropertiesBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class CharacterFiringPatternPropertiesBlockBase
    {
        [TagReference("weap")]
        internal Moonfish.Tags.TagReference weapon;
        internal CharacterFiringPatternBlock[] firingPatterns;
        internal  CharacterFiringPatternPropertiesBlockBase(System.IO.BinaryReader binaryReader)
        {
            weapon = binaryReader.ReadTagReference();
            ReadCharacterFiringPatternBlockArray(binaryReader);
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
        internal  virtual CharacterFiringPatternBlock[] ReadCharacterFiringPatternBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CharacterFiringPatternBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CharacterFiringPatternBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CharacterFiringPatternBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteCharacterFiringPatternBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(weapon);
                WriteCharacterFiringPatternBlockArray(binaryWriter);
            }
        }
    };
}
