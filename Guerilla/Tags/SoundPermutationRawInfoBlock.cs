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
        public  SoundPermutationRawInfoBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 40, Alignment = 4)]
    public class SoundPermutationRawInfoBlockBase  : IGuerilla
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
            skipFractionName = binaryReader.ReadStringID();
            invalidName_ = Guerilla.ReadData(binaryReader);
            invalidName_0 = Guerilla.ReadData(binaryReader);
            invalidName_1 = Guerilla.ReadData(binaryReader);
            soundPermutationMarkerBlock = Guerilla.ReadBlockArray<SoundPermutationMarkerBlock>(binaryReader);
            compression = (Compression)binaryReader.ReadInt16();
            language = (Language)binaryReader.ReadByte();
            invalidName_2 = binaryReader.ReadBytes(1);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(skipFractionName);
                nextAddress = Guerilla.WriteData(binaryWriter, invalidName_, nextAddress);
                nextAddress = Guerilla.WriteData(binaryWriter, invalidName_0, nextAddress);
                nextAddress = Guerilla.WriteData(binaryWriter, invalidName_1, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<SoundPermutationMarkerBlock>(binaryWriter, soundPermutationMarkerBlock, nextAddress);
                binaryWriter.Write((Int16)compression);
                binaryWriter.Write((Byte)language);
                binaryWriter.Write(invalidName_2, 0, 1);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
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
