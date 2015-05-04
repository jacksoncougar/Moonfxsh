// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class SoundGestaltPermutationsBlock : SoundGestaltPermutationsBlockBase
    {
        public SoundGestaltPermutationsBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class SoundGestaltPermutationsBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.ShortBlockIndex1 name;
        internal short encodedSkipFraction;
        internal byte encodedGainDB;
        internal byte permutationInfoIndex;
        internal short languageNeutralTimeMs;
        internal int sampleSize;
        internal Moonfish.Tags.ShortBlockIndex1 firstChunk;
        internal short chunkCount;
        public override int SerializedSize { get { return 16; } }
        public override int Alignment { get { return 4; } }
        public SoundGestaltPermutationsBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            name = binaryReader.ReadShortBlockIndex1();
            encodedSkipFraction = binaryReader.ReadInt16();
            encodedGainDB = binaryReader.ReadByte();
            permutationInfoIndex = binaryReader.ReadByte();
            languageNeutralTimeMs = binaryReader.ReadInt16();
            sampleSize = binaryReader.ReadInt32();
            firstChunk = binaryReader.ReadShortBlockIndex1();
            chunkCount = binaryReader.ReadInt16();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write(encodedSkipFraction);
                binaryWriter.Write(encodedGainDB);
                binaryWriter.Write(permutationInfoIndex);
                binaryWriter.Write(languageNeutralTimeMs);
                binaryWriter.Write(sampleSize);
                binaryWriter.Write(firstChunk);
                binaryWriter.Write(chunkCount);
                return nextAddress;
            }
        }
    };
}
