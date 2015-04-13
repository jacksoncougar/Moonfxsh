using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SoundGestaltPermutationsBlock : SoundGestaltPermutationsBlockBase
    {
        public  SoundGestaltPermutationsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class SoundGestaltPermutationsBlockBase
    {
        internal Moonfish.Tags.ShortBlockIndex1 name;
        internal short encodedSkipFraction;
        internal byte encodedGainDB;
        internal byte permutationInfoIndex;
        internal short languageNeutralTimeMs;
        internal int sampleSize;
        internal Moonfish.Tags.ShortBlockIndex1 firstChunk;
        internal short chunkCount;
        internal  SoundGestaltPermutationsBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadShortBlockIndex1();
            this.encodedSkipFraction = binaryReader.ReadInt16();
            this.encodedGainDB = binaryReader.ReadByte();
            this.permutationInfoIndex = binaryReader.ReadByte();
            this.languageNeutralTimeMs = binaryReader.ReadInt16();
            this.sampleSize = binaryReader.ReadInt32();
            this.firstChunk = binaryReader.ReadShortBlockIndex1();
            this.chunkCount = binaryReader.ReadInt16();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
        }
    };
}
