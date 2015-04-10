using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SoundPermutationRawInfoBlock : SoundPermutationRawInfoBlockBase
    {
        public  SoundPermutationRawInfoBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 40)]
    public class SoundPermutationRawInfoBlockBase
    {
        internal Moonfish.Tags.StringID skipFractionName;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;
        internal SoundPermutationMarkerBlock[] soundPermutationMarkerBlock;
        internal Compression compression;
        internal Language language;
        internal byte[] invalidName_2;
        internal  SoundPermutationRawInfoBlockBase(BinaryReader binaryReader)
        {
            this.skipFractionName = binaryReader.ReadStringID();
            this.invalidName_ = ReadData(binaryReader);
            this.invalidName_0 = ReadData(binaryReader);
            this.invalidName_1 = ReadData(binaryReader);
            this.soundPermutationMarkerBlock = ReadSoundPermutationMarkerBlockArray(binaryReader);
            this.compression = (Compression)binaryReader.ReadInt16();
            this.language = (Language)binaryReader.ReadByte();
            this.invalidName_2 = binaryReader.ReadBytes(1);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
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
        internal  virtual SoundPermutationMarkerBlock[] ReadSoundPermutationMarkerBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SoundPermutationMarkerBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SoundPermutationMarkerBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SoundPermutationMarkerBlock(binaryReader);
                }
            }
            return array;
        }
        internal enum Compression : short
        
        {
            NoneBigEndian = 0,
            XboxAdpcm = 1,
            ImaAdpcm = 2,
            NoneLittleEndian = 3,
            Wma = 4,
        };
        internal enum Language : byte
        
        {
            English = 0,
            Japanese = 1,
            German = 2,
            French = 3,
            Spanish = 4,
            Italian = 5,
            Korean = 6,
            Chinese = 7,
            Portuguese = 8,
        };
    };
}
