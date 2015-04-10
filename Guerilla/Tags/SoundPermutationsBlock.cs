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
    [LayoutAttribute(Size = 28)]
    public class SoundPermutationsBlockBase
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
            this.name = binaryReader.ReadStringID();
            this.skipFraction = binaryReader.ReadSingle();
            this.gainDB = binaryReader.ReadSingle();
            this.invalidName_ = binaryReader.ReadInt32();
            this.invalidName_0 = binaryReader.ReadShortBlockIndex2();
            this.invalidName_1 = binaryReader.ReadInt16();
            this.soundPermutationChunkBlock = ReadSoundPermutationChunkBlockArray(binaryReader);
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
        internal  virtual SoundPermutationChunkBlock[] ReadSoundPermutationChunkBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SoundPermutationChunkBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SoundPermutationChunkBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SoundPermutationChunkBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
