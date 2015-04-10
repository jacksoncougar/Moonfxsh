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
        public  SoundEffectTemplateBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  SoundEffectTemplateBlockBase(BinaryReader binaryReader)
        {
            this.templateCollection = ReadSoundEffectTemplatesBlockArray(binaryReader);
            this.inputEffectName = binaryReader.ReadStringID();
            this.additionalSoundInputs = ReadSoundEffectTemplateAdditionalSoundInputBlockArray(binaryReader);
            this.platformSoundEffectTemplateCollectionBlock = ReadPlatformSoundEffectTemplateCollectionBlockArray(binaryReader);
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
        internal  virtual SoundEffectTemplatesBlock[] ReadSoundEffectTemplatesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SoundEffectTemplatesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SoundEffectTemplatesBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SoundEffectTemplatesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SoundEffectTemplateAdditionalSoundInputBlock[] ReadSoundEffectTemplateAdditionalSoundInputBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SoundEffectTemplateAdditionalSoundInputBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SoundEffectTemplateAdditionalSoundInputBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SoundEffectTemplateAdditionalSoundInputBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PlatformSoundEffectTemplateCollectionBlock[] ReadPlatformSoundEffectTemplateCollectionBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PlatformSoundEffectTemplateCollectionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PlatformSoundEffectTemplateCollectionBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PlatformSoundEffectTemplateCollectionBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
