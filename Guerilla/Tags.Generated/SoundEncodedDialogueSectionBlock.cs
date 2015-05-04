// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class SoundEncodedDialogueSectionBlock : SoundEncodedDialogueSectionBlockBase
    {
        public  SoundEncodedDialogueSectionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  SoundEncodedDialogueSectionBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class SoundEncodedDialogueSectionBlockBase : GuerillaBlock
    {
        internal byte[] encodedData;
        internal SoundPermutationDialogueInfoBlock[] soundDialogueInfo;
        
        public override int SerializedSize{get { return 16; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  SoundEncodedDialogueSectionBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            encodedData = Guerilla.ReadData(binaryReader);
            soundDialogueInfo = Guerilla.ReadBlockArray<SoundPermutationDialogueInfoBlock>(binaryReader);
        }
        public  SoundEncodedDialogueSectionBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            encodedData = Guerilla.ReadData(binaryReader);
            soundDialogueInfo = Guerilla.ReadBlockArray<SoundPermutationDialogueInfoBlock>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteData(binaryWriter, encodedData, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<SoundPermutationDialogueInfoBlock>(binaryWriter, soundDialogueInfo, nextAddress);
                return nextAddress;
            }
        }
    };
}
