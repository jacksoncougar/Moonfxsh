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
        public  CharacterFiringPatternPropertiesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class CharacterFiringPatternPropertiesBlockBase
    {
        [TagReference("weap")]
        internal Moonfish.Tags.TagReference weapon;
        internal CharacterFiringPatternBlock[] firingPatterns;
        internal  CharacterFiringPatternPropertiesBlockBase(BinaryReader binaryReader)
        {
            this.weapon = binaryReader.ReadTagReference();
            this.firingPatterns = ReadCharacterFiringPatternBlockArray(binaryReader);
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
        internal  virtual CharacterFiringPatternBlock[] ReadCharacterFiringPatternBlockArray(BinaryReader binaryReader)
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
    };
}
