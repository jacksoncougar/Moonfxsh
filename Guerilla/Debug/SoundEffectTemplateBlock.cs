// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("<fx>")]
    public  partial class SoundEffectTemplateBlock : SoundEffectTemplateBlockBase
    {
        public  SoundEffectTemplateBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 28)]
    public class SoundEffectTemplateBlockBase
    {
        internal SoundEffectTemplatesBlock[] templateCollection;
        internal Moonfish.Tags.StringID inputEffectName;
        internal SoundEffectTemplateAdditionalSoundInputBlock[] additionalSoundInputs;
        internal PlatformSoundEffectTemplateCollectionBlock[] platformSoundEffectTemplateCollectionBlock;
        internal  SoundEffectTemplateBlockBase(System.IO.BinaryReader binaryReader)
        {
            ReadSoundEffectTemplatesBlockArray(binaryReader);
            inputEffectName = binaryReader.ReadStringID();
            ReadSoundEffectTemplateAdditionalSoundInputBlockArray(binaryReader);
            ReadPlatformSoundEffectTemplateCollectionBlockArray(binaryReader);
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
        internal  virtual SoundEffectTemplatesBlock[] ReadSoundEffectTemplatesBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SoundEffectTemplatesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SoundEffectTemplatesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SoundEffectTemplatesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SoundEffectTemplateAdditionalSoundInputBlock[] ReadSoundEffectTemplateAdditionalSoundInputBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SoundEffectTemplateAdditionalSoundInputBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SoundEffectTemplateAdditionalSoundInputBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SoundEffectTemplateAdditionalSoundInputBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PlatformSoundEffectTemplateCollectionBlock[] ReadPlatformSoundEffectTemplateCollectionBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PlatformSoundEffectTemplateCollectionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PlatformSoundEffectTemplateCollectionBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PlatformSoundEffectTemplateCollectionBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteSoundEffectTemplatesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteSoundEffectTemplateAdditionalSoundInputBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WritePlatformSoundEffectTemplateCollectionBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                WriteSoundEffectTemplatesBlockArray(binaryWriter);
                binaryWriter.Write(inputEffectName);
                WriteSoundEffectTemplateAdditionalSoundInputBlockArray(binaryWriter);
                WritePlatformSoundEffectTemplateCollectionBlockArray(binaryWriter);
            }
        }
    };
}
