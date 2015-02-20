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
        public  PixelShaderCombinerBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  PixelShaderCombinerBlockBase(BinaryReader binaryReader)
        {
            this.invalidName_ = binaryReader.ReadBytes(16);
            this.constantColor0 = binaryReader.ReadColourA1R1G1B1();
            this.constantColor1 = binaryReader.ReadColourA1R1G1B1();
            this.colorARegisterPtrIndex = binaryReader.ReadByte();
            this.colorBRegisterPtrIndex = binaryReader.ReadByte();
            this.colorCRegisterPtrIndex = binaryReader.ReadByte();
            this.colorDRegisterPtrIndex = binaryReader.ReadByte();
            this.alphaARegisterPtrIndex = binaryReader.ReadByte();
            this.alphaBRegisterPtrIndex = binaryReader.ReadByte();
            this.alphaCRegisterPtrIndex = binaryReader.ReadByte();
            this.alphaDRegisterPtrIndex = binaryReader.ReadByte();
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
    };
}
