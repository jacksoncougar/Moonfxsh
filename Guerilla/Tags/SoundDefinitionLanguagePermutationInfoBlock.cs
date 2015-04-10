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
    [LayoutAttribute(Size = 8)]
    public class SoundDefinitionLanguagePermutationInfoBlockBase
    {
        internal SoundPermutationRawInfoBlock[] rawInfoBlock;
        internal  SoundDefinitionLanguagePermutationInfoBlockBase(BinaryReader binaryReader)
        {
            this.rawInfoBlock = ReadSoundPermutationRawInfoBlockArray(binaryReader);
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
        internal  virtual SoundPermutationRawInfoBlock[] ReadSoundPermutationRawInfoBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SoundPermutationRawInfoBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SoundPermutationRawInfoBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SoundPermutationRawInfoBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
