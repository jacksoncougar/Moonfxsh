// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SoundPermutationsBlock : SoundPermutationsBlockBase
    {
        public  SoundPermutationsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 28, Alignment = 4)]
    public class SoundPermutationsBlockBase  : IGuerilla
    {
        /// <summary>
        /// name of the file from which this sample was imported
        /// </summary>
        internal Moonfish.Tags.StringID name;
        /// <summary>
        /// fraction of requests to play this permutation that are ignored (a different permutation is selected.)
        /// </summary>
        internal float skipFraction;
        /// <summary>
        /// additional attenuation when played
        /// </summary>
        internal float gainDB;
        internal int invalidName_;
        internal Moonfish.Tags.ShortBlockIndex2 invalidName_0;
        internal short invalidName_1;
        internal SoundPermutationChunkBlock[] soundPermutationChunkBlock;
        internal  SoundPermutationsBlockBase(BinaryReader binaryReader)
        {
            name = binaryReader.ReadStringID();
            skipFraction = binaryReader.ReadSingle();
            gainDB = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadInt32();
            invalidName_0 = binaryReader.ReadShortBlockIndex2();
            invalidName_1 = binaryReader.ReadInt16();
            soundPermutationChunkBlock = Guerilla.ReadBlockArray<SoundPermutationChunkBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write(skipFraction);
                binaryWriter.Write(gainDB);
                binaryWriter.Write(invalidName_);
                binaryWriter.Write(invalidName_0);
                binaryWriter.Write(invalidName_1);
                Guerilla.WriteBlockArray<SoundPermutationChunkBlock>(binaryWriter, soundPermutationChunkBlock, nextAddress);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
