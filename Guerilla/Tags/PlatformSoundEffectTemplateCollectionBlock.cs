using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class PlatformSoundEffectTemplateCollectionBlock : PlatformSoundEffectTemplateCollectionBlockBase
    {
        public  PlatformSoundEffectTemplateCollectionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12)]
    public class PlatformSoundEffectTemplateCollectionBlockBase
    {
        internal PlatformSoundEffectTemplateBlock[] platformEffectTemplates;
        internal Moonfish.Tags.StringID inputDspEffectName;
        internal  PlatformSoundEffectTemplateCollectionBlockBase(BinaryReader binaryReader)
        {
            this.platformEffectTemplates = ReadPlatformSoundEffectTemplateBlockArray(binaryReader);
            this.inputDspEffectName = binaryReader.ReadStringID();
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
        internal  virtual PlatformSoundEffectTemplateBlock[] ReadPlatformSoundEffectTemplateBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PlatformSoundEffectTemplateBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PlatformSoundEffectTemplateBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PlatformSoundEffectTemplateBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
