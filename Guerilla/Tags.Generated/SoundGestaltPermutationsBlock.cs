// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public artial class SoundGestaltPermutationsBlock : SoundGestaltPermutationsBlockBase
    {
        public  oundGestaltPermutationsBlock(B inaryReader binaryReader) :  base(b inaryReader) 
        {
         
    };

    LayoutAttribute(S ize = 16, Alignment = 4) ]
    public class SoundGestaltPermutationsBlockBase  GuerillaBlock
    {
        internal Moonfish.Tags.ShortBlockIndex1 name;
        internal short encodedSkipFraction;
        internal byte encodedGainDB;
        internal byte permutationInfoIndex;
        internal short languageNeutralTimeMs;
        internal int sampleSize;
        internal Moonfish.Tags.ShortBlockIndex1 firstChunk;
        internal short chunkCoun

          
       public override int SerializedSi ze{get { return 16; }}
         
        internal  SoundGestaltPermutationsBlockBase(Binary Reader binaryReader): base(binaryReader)
        {
             name = binaryReader.ReadShortBlockIndex1();
             encodedSkipFraction = binaryReader.ReadInt16();
             encodedGainDB = binaryReader.ReadByte();
            pe rmutationInfoIndex = binaryReader.ReadByte();
             languageNeutralTimeMs = binaryReader.ReadInt16();
             sampleSize = binaryReader.ReadInt32();
             firstC

        aryReader.ReadSho rtBlockIndex1();
            chunkCount = binaryReade r.ReadInt16();
        }
          public override int Write ( System.IO.BinaryWriter binaryWriter, Int32 nextAddres s)
         {
            using(binaryWrit er.BaseStream.Pin() )
            {
                binar yWriter.Write (name);
                binaryWriter.W rite(encodedSkipFrac tion);
                binaryWriter.Wr ite(encodedGainDB);
                 binaryWriter.Write(perm utationInf oIndex);
                binaryWriter. Write(lang uageNeutralTimeMs);
                bi naryWriter .Write(sampleSize);
                binaryWriter.Write(firstChunk);
              binaryWriter.Write(chunkCount);
                return nextAddress;
            }
        }
    };
}
