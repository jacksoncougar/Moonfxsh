// ReSharper disable All
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
        public  PlatformSoundEffectBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  PlatformSoundEffectBlockBase(System.IO.BinaryReader binaryReader)
        {
            ReadPlatformSoundEffectFunctionBlockArray(binaryReader);
            ReadPlatformSoundEffectConstantBlockArray(binaryReader);
            ReadPlatformSoundEffectOverrideDescriptorBlockArray(binaryReader);
            inputOverrides = binaryReader.ReadInt32();
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
        internal  virtual PlatformSoundEffectFunctionBlock[] ReadPlatformSoundEffectFunctionBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual PlatformSoundEffectConstantBlock[] ReadPlatformSoundEffectConstantBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PlatformSoundEffectConstantBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PlatformSoundEffectConstantBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PlatformSoundEffectConstantBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PlatformSoundEffectOverrideDescriptorBlock[] ReadPlatformSoundEffectOverrideDescriptorBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PlatformSoundEffectOverrideDescriptorBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PlatformSoundEffectOverrideDescriptorBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PlatformSoundEffectOverrideDescriptorBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WritePlatformSoundEffectFunctionBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WritePlatformSoundEffectConstantBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WritePlatformSoundEffectOverrideDescriptorBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                WritePlatformSoundEffectFunctionBlockArray(binaryWriter);
                WritePlatformSoundEffectConstantBlockArray(binaryWriter);
                WritePlatformSoundEffectOverrideDescriptorBlockArray(binaryWriter);
                binaryWriter.Write(inputOverrides);
            }
        }
    };
}
