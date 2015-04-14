// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SoundPermutationChunkBlock : SoundPermutationChunkBlockBase
    {
        public  SoundPermutationChunkBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class SoundPermutationChunkBlockBase  : IGuerilla
    {
        internal int fileOffset;
        internal int invalidName_;
        internal int invalidName_0;
        internal  SoundPermutationChunkBlockBase(BinaryReader binaryReader)
        {
            fileOffset = binaryReader.ReadInt32();
            invalidName_ = binaryReader.ReadInt32();
            invalidName_0 = binaryReader.ReadInt32();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(fileOffset);
                binaryWriter.Write(invalidName_);
                binaryWriter.Write(invalidName_0);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
