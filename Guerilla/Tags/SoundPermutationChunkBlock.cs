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
    [LayoutAttribute(Size = 12)]
    public class SoundPermutationChunkBlockBase
    {
        internal int fileOffset;
        internal int invalidName_;
        internal int invalidName_0;
        internal  SoundPermutationChunkBlockBase(BinaryReader binaryReader)
        {
            this.fileOffset = binaryReader.ReadInt32();
            this.invalidName_ = binaryReader.ReadInt32();
            this.invalidName_0 = binaryReader.ReadInt32();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
        }
    };
}
