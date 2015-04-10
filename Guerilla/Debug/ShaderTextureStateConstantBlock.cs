// ReSharper disable All
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
        public  ShaderTextureStateConstantBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8)]
    public class ShaderTextureStateConstantBlockBase
    {
        internal Moonfish.Tags.StringID sourceParameter;
        internal byte[] invalidName_;
        internal Constant constant;
        internal  ShaderTextureStateConstantBlockBase(System.IO.BinaryReader binaryReader)
        {
            sourceParameter = binaryReader.ReadStringID();
            invalidName_ = binaryReader.ReadBytes(2);
            constant = (Constant)binaryReader.ReadInt16();
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
                binaryWriter.Write(sourceParameter);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write((Int16)constant);
            }
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
