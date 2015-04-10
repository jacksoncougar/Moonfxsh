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
        public  SoundPermutationDialogueInfoBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  SoundPermutationDialogueInfoBlockBase(System.IO.BinaryReader binaryReader)
        {
            mouthDataOffset = binaryReader.ReadInt32();
            mouthDataLength = binaryReader.ReadInt32();
            lipsyncDataOffset = binaryReader.ReadInt32();
            lipsyncDataLength = binaryReader.ReadInt32();
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(mouthDataOffset);
                binaryWriter.Write(mouthDataLength);
                binaryWriter.Write(lipsyncDataOffset);
                binaryWriter.Write(lipsyncDataLength);
            }
        }
    };
}
