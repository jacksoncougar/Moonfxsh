// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SoundDefinitionLanguagePermutationInfoBlock : SoundDefinitionLanguagePermutationInfoBlockBase
    {
        public  SoundDefinitionLanguagePermutationInfoBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class SoundDefinitionLanguagePermutationInfoBlockBase  : IGuerilla
    {
        internal SoundPermutationRawInfoBlock[] rawInfoBlock;
        internal  SoundDefinitionLanguagePermutationInfoBlockBase(BinaryReader binaryReader)
        {
            rawInfoBlock = Guerilla.ReadBlockArray<SoundPermutationRawInfoBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                Guerilla.WriteBlockArray<SoundPermutationRawInfoBlock>(binaryWriter, rawInfoBlock, nextAddress);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
