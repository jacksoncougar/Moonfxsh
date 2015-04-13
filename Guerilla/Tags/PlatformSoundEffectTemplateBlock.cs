using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class PlatformSoundEffectTemplateBlock : PlatformSoundEffectTemplateBlockBase
    {
        public  PlatformSoundEffectTemplateBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 24)]
    public class PlatformSoundEffectTemplateBlockBase
    {
        internal Moonfish.Tags.StringID inputDspEffectName;
        internal byte[] invalidName_;
        internal PlatformSoundEffectTemplateComponentBlock[] components;
        internal  PlatformSoundEffectTemplateBlockBase(BinaryReader binaryReader)
        {
            this.inputDspEffectName = binaryReader.ReadStringID();
            this.invalidName_ = binaryReader.ReadBytes(12);
            this.components = ReadPlatformSoundEffectTemplateComponentBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
        }
        internal  virtual PlatformSoundEffectTemplateComponentBlock[] ReadPlatformSoundEffectTemplateComponentBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PlatformSoundEffectTemplateComponentBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PlatformSoundEffectTemplateComponentBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PlatformSoundEffectTemplateComponentBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
