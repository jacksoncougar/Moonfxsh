// ReSharper disable All
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
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class SoundPermutationDialogueInfoBlockBase  : IGuerilla
    {
        internal int mouthDataOffset;
        internal int mouthDataLength;
        internal int lipsyncDataOffset;
        internal int lipsyncDataLength;
        internal  SoundPermutationDialogueInfoBlockBase(BinaryReader binaryReader)
        {
            mouthDataOffset = binaryReader.ReadInt32();
            mouthDataLength = binaryReader.ReadInt32();
            lipsyncDataOffset = binaryReader.ReadInt32();
            lipsyncDataLength = binaryReader.ReadInt32();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(mouthDataOffset);
                binaryWriter.Write(mouthDataLength);
                binaryWriter.Write(lipsyncDataOffset);
                binaryWriter.Write(lipsyncDataLength);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
