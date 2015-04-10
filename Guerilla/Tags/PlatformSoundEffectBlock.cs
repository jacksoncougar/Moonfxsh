using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class PlatformSoundEffectBlock : PlatformSoundEffectBlockBase
    {
        public  PlatformSoundEffectBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 28)]
    public class PlatformSoundEffectBlockBase
    {
        internal PlatformSoundEffectFunctionBlock[] functionInputs;
        internal PlatformSoundEffectConstantBlock[] constantInputs;
        internal PlatformSoundEffectOverrideDescriptorBlock[] templateOverrideDescriptors;
        internal int inputOverrides;
        internal  PlatformSoundEffectBlockBase(BinaryReader binaryReader)
        {
            this.functionInputs = ReadPlatformSoundEffectFunctionBlockArray(binaryReader);
            this.constantInputs = ReadPlatformSoundEffectConstantBlockArray(binaryReader);
            this.templateOverrideDescriptors = ReadPlatformSoundEffectOverrideDescriptorBlockArray(binaryReader);
            this.inputOverrides = binaryReader.ReadInt32();
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
        internal  virtual PlatformSoundEffectFunctionBlock[] ReadPlatformSoundEffectFunctionBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PlatformSoundEffectFunctionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PlatformSoundEffectFunctionBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PlatformSoundEffectFunctionBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PlatformSoundEffectConstantBlock[] ReadPlatformSoundEffectConstantBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PlatformSoundEffectConstantBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PlatformSoundEffectConstantBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PlatformSoundEffectConstantBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PlatformSoundEffectOverrideDescriptorBlock[] ReadPlatformSoundEffectOverrideDescriptorBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PlatformSoundEffectOverrideDescriptorBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PlatformSoundEffectOverrideDescriptorBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PlatformSoundEffectOverrideDescriptorBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
