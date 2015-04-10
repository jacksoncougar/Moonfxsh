// ReSharper disable All
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
        public  PlatformSoundEffectTemplateBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 24)]
    public class PlatformSoundEffectTemplateBlockBase
    {
        internal Moonfish.Tags.StringID inputDspEffectName;
        internal byte[] invalidName_;
        internal PlatformSoundEffectTemplateComponentBlock[] components;
        internal  PlatformSoundEffectTemplateBlockBase(System.IO.BinaryReader binaryReader)
        {
            inputDspEffectName = binaryReader.ReadStringID();
            invalidName_ = binaryReader.ReadBytes(12);
            ReadPlatformSoundEffectTemplateComponentBlockArray(binaryReader);
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
        internal  virtual PlatformSoundEffectTemplateComponentBlock[] ReadPlatformSoundEffectTemplateComponentBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PlatformSoundEffectTemplateComponentBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PlatformSoundEffectTemplateComponentBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PlatformSoundEffectTemplateComponentBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WritePlatformSoundEffectTemplateComponentBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(inputDspEffectName);
                binaryWriter.Write(invalidName_, 0, 12);
                WritePlatformSoundEffectTemplateComponentBlockArray(binaryWriter);
            }
        }
    };
}
