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
    public partial class PixelShaderCombinerBlock : PixelShaderCombinerBlockBase
    {
        public PixelShaderCombinerBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 32, Alignment = 4)]
    public class PixelShaderCombinerBlockBase : GuerillaBlock
    {
        internal byte[] invalidName_;
        internal Moonfish.Tags.ColourA1R1G1B1 constantColor0;
        internal Moonfish.Tags.ColourA1R1G1B1 constantColor1;
        internal byte colorARegisterPtrIndex;
        internal byte colorBRegisterPtrIndex;
        internal byte colorCRegisterPtrIndex;
        internal byte colorDRegisterPtrIndex;
        internal byte alphaARegisterPtrIndex;
        internal byte alphaBRegisterPtrIndex;
        internal byte alphaCRegisterPtrIndex;
        internal byte alphaDRegisterPtrIndex;
        public override int SerializedSize { get { return 32; } }
        public override int Alignment { get { return 4; } }
        public PixelShaderCombinerBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            invalidName_ = binaryReader.ReadBytes(16);
            constantColor0 = binaryReader.ReadColourA1R1G1B1();
            constantColor1 = binaryReader.ReadColourA1R1G1B1();
            colorARegisterPtrIndex = binaryReader.ReadByte();
            colorBRegisterPtrIndex = binaryReader.ReadByte();
            colorCRegisterPtrIndex = binaryReader.ReadByte();
            colorDRegisterPtrIndex = binaryReader.ReadByte();
            alphaARegisterPtrIndex = binaryReader.ReadByte();
            alphaBRegisterPtrIndex = binaryReader.ReadByte();
            alphaCRegisterPtrIndex = binaryReader.ReadByte();
            alphaDRegisterPtrIndex = binaryReader.ReadByte();
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
                binaryWriter.Write(invalidName_, 0, 16);
                binaryWriter.Write(constantColor0);
                binaryWriter.Write(constantColor1);
                binaryWriter.Write(colorARegisterPtrIndex);
                binaryWriter.Write(colorBRegisterPtrIndex);
                binaryWriter.Write(colorCRegisterPtrIndex);
                binaryWriter.Write(colorDRegisterPtrIndex);
                binaryWriter.Write(alphaARegisterPtrIndex);
                binaryWriter.Write(alphaBRegisterPtrIndex);
                binaryWriter.Write(alphaCRegisterPtrIndex);
                binaryWriter.Write(alphaDRegisterPtrIndex);
                return nextAddress;
            }
        }
    };
}
