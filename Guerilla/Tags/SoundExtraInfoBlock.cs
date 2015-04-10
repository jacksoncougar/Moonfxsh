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
        public  SoundExtraInfoBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 52)]
    public class SoundExtraInfoBlockBase
    {
        internal SoundDefinitionLanguagePermutationInfoBlock[] languagePermutationInfo;
        internal SoundEncodedDialogueSectionBlock[] encodedPermutationSection;
        internal GlobalGeometryBlockInfoStructBlock geometryBlockInfo;
        internal  SoundExtraInfoBlockBase(BinaryReader binaryReader)
        {
            this.languagePermutationInfo = ReadSoundDefinitionLanguagePermutationInfoBlockArray(binaryReader);
            this.encodedPermutationSection = ReadSoundEncodedDialogueSectionBlockArray(binaryReader);
            this.geometryBlockInfo = new GlobalGeometryBlockInfoStructBlock(binaryReader);
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
        internal  virtual SoundDefinitionLanguagePermutationInfoBlock[] ReadSoundDefinitionLanguagePermutationInfoBlockArray(BinaryReader binaryReader)
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
        internal  virtual SoundEncodedDialogueSectionBlock[] ReadSoundEncodedDialogueSectionBlockArray(BinaryReader binaryReader)
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
    };
}
