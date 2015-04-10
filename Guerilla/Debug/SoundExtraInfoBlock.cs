// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SoundExtraInfoBlock : SoundExtraInfoBlockBase
    {
        public  SoundExtraInfoBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 52)]
    public class SoundExtraInfoBlockBase
    {
        internal SoundDefinitionLanguagePermutationInfoBlock[] languagePermutationInfo;
        internal SoundEncodedDialogueSectionBlock[] encodedPermutationSection;
        internal GlobalGeometryBlockInfoStructBlock geometryBlockInfo;
        internal  SoundExtraInfoBlockBase(System.IO.BinaryReader binaryReader)
        {
            ReadSoundDefinitionLanguagePermutationInfoBlockArray(binaryReader);
            ReadSoundEncodedDialogueSectionBlockArray(binaryReader);
            geometryBlockInfo = new GlobalGeometryBlockInfoStructBlock(binaryReader);
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
        internal  virtual SoundDefinitionLanguagePermutationInfoBlock[] ReadSoundDefinitionLanguagePermutationInfoBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SoundDefinitionLanguagePermutationInfoBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SoundDefinitionLanguagePermutationInfoBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SoundDefinitionLanguagePermutationInfoBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SoundEncodedDialogueSectionBlock[] ReadSoundEncodedDialogueSectionBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SoundEncodedDialogueSectionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SoundEncodedDialogueSectionBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SoundEncodedDialogueSectionBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteSoundDefinitionLanguagePermutationInfoBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteSoundEncodedDialogueSectionBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                WriteSoundDefinitionLanguagePermutationInfoBlockArray(binaryWriter);
                WriteSoundEncodedDialogueSectionBlockArray(binaryWriter);
                geometryBlockInfo.Write(binaryWriter);
            }
        }
    };
}
