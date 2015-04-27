// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class SoundPermutationDialogueInfoBlock : SoundPermutationDialogueInfoBlockBase
    {
        public  SoundPermutationDialogueInfoBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  SoundPermutationDialogueInfoBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class SoundPermutationDialogueInfoBlockBase : GuerillaBlock
    {
        internal int mouthDataOffset;
        internal int mouthDataLength;
        internal int lipsyncDataOffset;
        internal int lipsyncDataLength;
        
        public override int SerializedSize{get { return 16; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  SoundPermutationDialogueInfoBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            mouthDataOffset = binaryReader.ReadInt32();
            mouthDataLength = binaryReader.ReadInt32();
            lipsyncDataOffset = binaryReader.ReadInt32();
            lipsyncDataLength = binaryReader.ReadInt32();
        }
        public  SoundPermutationDialogueInfoBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            mouthDataOffset = binaryReader.ReadInt32();
            mouthDataLength = binaryReader.ReadInt32();
            lipsyncDataOffset = binaryReader.ReadInt32();
            lipsyncDataLength = binaryReader.ReadInt32();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(mouthDataOffset);
                binaryWriter.Write(mouthDataLength);
                binaryWriter.Write(lipsyncDataOffset);
                binaryWriter.Write(lipsyncDataLength);
                return nextAddress;
            }
        }
    };
}
