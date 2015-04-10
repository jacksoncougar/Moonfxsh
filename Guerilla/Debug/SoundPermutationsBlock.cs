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
        public  SoundPermutationsBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  SoundPermutationsBlockBase(System.IO.BinaryReader binaryReader)
        {
            name = binaryReader.ReadStringID();
            skipFraction = binaryReader.ReadSingle();
            gainDB = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadInt32();
            invalidName_0 = binaryReader.ReadShortBlockIndex2();
            invalidName_1 = binaryReader.ReadInt16();
            ReadSoundPermutationChunkBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
        internal  virtual SoundPermutationChunkBlock[] ReadSoundPermutationChunkBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SoundPermutationChunkBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SoundPermutationChunkBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SoundPermutationChunkBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteSoundPermutationChunkBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write(skipFraction);
                binaryWriter.Write(gainDB);
                binaryWriter.Write(invalidName_);
                binaryWriter.Write(invalidName_0);
                binaryWriter.Write(invalidName_1);
                WriteSoundPermutationChunkBlockArray(binaryWriter);
            }
        }
    };
}
