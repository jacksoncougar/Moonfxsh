// ReSharper disable All
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
        public  SoundPermutationRawInfoBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  SoundPermutationRawInfoBlockBase(System.IO.BinaryReader binaryReader)
        {
            skipFractionName = binaryReader.ReadStringID();
            invalidName_ = ReadData(binaryReader);
            invalidName_0 = ReadData(binaryReader);
            invalidName_1 = ReadData(binaryReader);
            ReadSoundPermutationMarkerBlockArray(binaryReader);
            compression = (Compression)binaryReader.ReadInt16();
            language = (Language)binaryReader.ReadByte();
            invalidName_2 = binaryReader.ReadBytes(1);
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
        internal  virtual SoundPermutationMarkerBlock[] ReadSoundPermutationMarkerBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteSoundPermutationMarkerBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(skipFractionName);
                WriteData(binaryWriter);
                WriteData(binaryWriter);
                WriteData(binaryWriter);
                WriteSoundPermutationMarkerBlockArray(binaryWriter);
                binaryWriter.Write((Int16)compression);
                binaryWriter.Write((Byte)language);
                binaryWriter.Write(invalidName_2, 0, 1);
            }
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
