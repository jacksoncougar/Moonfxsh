// ReSharper disable All

using Moonfish.Model;

using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class SoundPermutationChunkBlock : SoundPermutationChunkBlockBase
    {
        public SoundPermutationChunkBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class SoundPermutationChunkBlockBase : GuerillaBlock
    {
        internal int fileOffset;
        internal int invalidName_;
        internal int invalidName_0;

        public override int SerializedSize
        {
            get { return 12; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public SoundPermutationChunkBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            fileOffset = binaryReader.ReadInt32();
            invalidName_ = binaryReader.ReadInt32();
            invalidName_0 = binaryReader.ReadInt32();
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(fileOffset);
                binaryWriter.Write(invalidName_);
                binaryWriter.Write(invalidName_0);
                return nextAddress;
            }
        }
    };
}