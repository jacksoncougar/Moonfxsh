using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class PlatformSoundEffectCollectionBlock : PlatformSoundEffectCollectionBlockBase
    {
        public  PlatformSoundEffectCollectionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20)]
    public class PlatformSoundEffectCollectionBlockBase
    {
        internal PlatformSoundEffectBlock[] soundEffects;
        internal PlatformSoundEffectFunctionBlock[] lowFrequencyInput;
        internal int soundEffectOverrides;
        internal  PlatformSoundEffectCollectionBlockBase(BinaryReader binaryReader)
        {
            this.soundEffects = ReadPlatformSoundEffectBlockArray(binaryReader);
            this.lowFrequencyInput = ReadPlatformSoundEffectFunctionBlockArray(binaryReader);
            this.soundEffectOverrides = binaryReader.ReadInt32();
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
        internal  virtual PlatformSoundEffectBlock[] ReadPlatformSoundEffectBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PlatformSoundEffectBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PlatformSoundEffectBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PlatformSoundEffectBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PlatformSoundEffectFunctionBlock[] ReadPlatformSoundEffectFunctionBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PlatformSoundEffectFunctionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PlatformSoundEffectFunctionBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PlatformSoundEffectFunctionBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
