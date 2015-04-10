using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderTextureStateConstantBlock : ShaderTextureStateConstantBlockBase
    {
        public  ShaderTextureStateConstantBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8)]
    public class ShaderTextureStateConstantBlockBase
    {
        internal Moonfish.Tags.StringID sourceParameter;
        internal byte[] invalidName_;
        internal Constant constant;
        internal  ShaderTextureStateConstantBlockBase(BinaryReader binaryReader)
        {
            this.sourceParameter = binaryReader.ReadStringID();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.constant = (Constant)binaryReader.ReadInt16();
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
        internal enum Constant : short
        
        {
            MipmapBiasValue = 0,
            ColorkeyColor = 1,
            BorderColor = 2,
            BorderAlphaValue = 3,
            BumpenvMat00 = 4,
            BumpenvMat01 = 5,
            BumpenvMat10 = 6,
            BumpenvMat11 = 7,
            BumpenvLumScaleValue = 8,
            BumpenvLumOffsetValue = 9,
        };
    };
}
