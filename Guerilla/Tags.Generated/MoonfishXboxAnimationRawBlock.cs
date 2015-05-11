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
    public partial class MoonfishXboxAnimationRawBlock : MoonfishXboxAnimationRawBlockBase
    {
        public MoonfishXboxAnimationRawBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class MoonfishXboxAnimationRawBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.TagIdent ownerTag;
        internal int blockSize;
        internal int blockLength;
        internal int unknown;
        internal int unknown1;

        public override int SerializedSize
        {
            get { return 20; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public MoonfishXboxAnimationRawBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            ownerTag = binaryReader.ReadTagIdent();
            blockSize = binaryReader.ReadInt32();
            blockLength = binaryReader.ReadInt32();
            unknown = binaryReader.ReadInt32();
            unknown1 = binaryReader.ReadInt32();
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
                binaryWriter.Write(ownerTag);
                binaryWriter.Write(blockSize);
                binaryWriter.Write(blockLength);
                binaryWriter.Write(unknown);
                binaryWriter.Write(unknown1);
                return nextAddress;
            }
        }
    };
}