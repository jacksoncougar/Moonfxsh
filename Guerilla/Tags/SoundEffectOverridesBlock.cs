using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SoundEffectOverridesBlock : SoundEffectOverridesBlockBase
    {
        public  SoundEffectOverridesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12)]
    public class SoundEffectOverridesBlockBase
    {
        internal Moonfish.Tags.StringID name;
        internal SoundEffectOverrideParametersBlock[] overrides;
        internal  SoundEffectOverridesBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.overrides = ReadSoundEffectOverrideParametersBlockArray(binaryReader);
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
        internal  virtual SoundEffectOverrideParametersBlock[] ReadSoundEffectOverrideParametersBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SoundEffectOverrideParametersBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SoundEffectOverrideParametersBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SoundEffectOverrideParametersBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
