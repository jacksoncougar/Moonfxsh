using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SoundEffectStructDefinitionBlock : SoundEffectStructDefinitionBlockBase
    {
        public  SoundEffectStructDefinitionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 40)]
    public class SoundEffectStructDefinitionBlockBase
    {
        [TagReference("<fx>")]
        internal Moonfish.Tags.TagReference invalidName_;
        internal SoundEffectComponentBlock[] components;
        internal SoundEffectOverridesBlock[] soundEffectOverridesBlock;
        internal byte[] invalidName_0;
        internal PlatformSoundEffectCollectionBlock[] platformSoundEffectCollectionBlock;
        internal  SoundEffectStructDefinitionBlockBase(BinaryReader binaryReader)
        {
            this.invalidName_ = binaryReader.ReadTagReference();
            this.components = ReadSoundEffectComponentBlockArray(binaryReader);
            this.soundEffectOverridesBlock = ReadSoundEffectOverridesBlockArray(binaryReader);
            this.invalidName_0 = ReadData(binaryReader);
            this.platformSoundEffectCollectionBlock = ReadPlatformSoundEffectCollectionBlockArray(binaryReader);
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
        internal  virtual SoundEffectComponentBlock[] ReadSoundEffectComponentBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SoundEffectComponentBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SoundEffectComponentBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SoundEffectComponentBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SoundEffectOverridesBlock[] ReadSoundEffectOverridesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SoundEffectOverridesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SoundEffectOverridesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SoundEffectOverridesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PlatformSoundEffectCollectionBlock[] ReadPlatformSoundEffectCollectionBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PlatformSoundEffectCollectionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PlatformSoundEffectCollectionBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PlatformSoundEffectCollectionBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
