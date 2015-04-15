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
        public  SoundExtraInfoBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 52, Alignment = 4)]
    public class SoundExtraInfoBlockBase  : IGuerilla
    {
        internal SoundDefinitionLanguagePermutationInfoBlock[] languagePermutationInfo;
        internal SoundEncodedDialogueSectionBlock[] encodedPermutationSection;
        internal GlobalGeometryBlockInfoStructBlock geometryBlockInfo;
        internal  SoundExtraInfoBlockBase(BinaryReader binaryReader)
        {
            languagePermutationInfo = Guerilla.ReadBlockArray<SoundDefinitionLanguagePermutationInfoBlock>(binaryReader);
            encodedPermutationSection = Guerilla.ReadBlockArray<SoundEncodedDialogueSectionBlock>(binaryReader);
            geometryBlockInfo = new GlobalGeometryBlockInfoStructBlock(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<SoundDefinitionLanguagePermutationInfoBlock>(binaryWriter, languagePermutationInfo, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<SoundEncodedDialogueSectionBlock>(binaryWriter, encodedPermutationSection, nextAddress);
                geometryBlockInfo.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
