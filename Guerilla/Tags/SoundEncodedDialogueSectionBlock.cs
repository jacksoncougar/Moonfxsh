using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SoundEncodedDialogueSectionBlock : SoundEncodedDialogueSectionBlockBase
    {
        public  SoundEncodedDialogueSectionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class SoundEncodedDialogueSectionBlockBase
    {
        internal byte[] encodedData;
        internal SoundPermutationDialogueInfoBlock[] soundDialogueInfo;
        internal  SoundEncodedDialogueSectionBlockBase(BinaryReader binaryReader)
        {
            this.encodedData = ReadData(binaryReader);
            this.soundDialogueInfo = ReadSoundPermutationDialogueInfoBlockArray(binaryReader);
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
        internal  virtual SoundPermutationDialogueInfoBlock[] ReadSoundPermutationDialogueInfoBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SoundPermutationDialogueInfoBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SoundPermutationDialogueInfoBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SoundPermutationDialogueInfoBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
