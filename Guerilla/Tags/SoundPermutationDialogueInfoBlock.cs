using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SoundPermutationDialogueInfoBlock : SoundPermutationDialogueInfoBlockBase
    {
        public  SoundPermutationDialogueInfoBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class SoundPermutationDialogueInfoBlockBase
    {
        internal int mouthDataOffset;
        internal int mouthDataLength;
        internal int lipsyncDataOffset;
        internal int lipsyncDataLength;
        internal  SoundPermutationDialogueInfoBlockBase(BinaryReader binaryReader)
        {
            this.mouthDataOffset = binaryReader.ReadInt32();
            this.mouthDataLength = binaryReader.ReadInt32();
            this.lipsyncDataOffset = binaryReader.ReadInt32();
            this.lipsyncDataLength = binaryReader.ReadInt32();
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
    };
}
