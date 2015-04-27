// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class SoundPermutationChunkBlock : SoundPermutationChunkBlockBase
    {
        public  SoundPermutationChunkBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  SoundPermutationChunkBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class SoundPermutationChunkBlockBase : GuerillaBlock
    {
        internal int fileOffset;
        internal int invalidName_;
        internal int invalidName_0;
        
        public override int SerializedSize{get { return 12; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  SoundPermutationChunkBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            fileOffset = binaryReader.ReadInt32();
            invalidName_ = binaryReader.ReadInt32();
            invalidName_0 = binaryReader.ReadInt32();
        }
        public  SoundPermutationChunkBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(fileOffset);
                binaryWriter.Write(invalidName_);
                binaryWriter.Write(invalidName_0);
                return nextAddress;
            }
        }
    };
}
