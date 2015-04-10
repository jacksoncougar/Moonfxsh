// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class PixelShaderCombinerBlock : PixelShaderCombinerBlockBase
    {
        public  PixelShaderCombinerBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 32)]
    public class PixelShaderCombinerBlockBase
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
        internal  PixelShaderCombinerBlockBase(System.IO.BinaryReader binaryReader)
        {
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
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
            }
        }
    };
}
