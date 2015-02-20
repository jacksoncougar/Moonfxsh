using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderPassVertexShaderConstantBlock : ShaderPassVertexShaderConstantBlockBase
    {
        public  ShaderPassVertexShaderConstantBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12)]
    public class ShaderPassVertexShaderConstantBlockBase
    {
        internal Moonfish.Tags.StringID sourceParameter;
        internal ScaleByTextureStage scaleByTextureStage;
        internal RegisterBank registerBank;
        internal short registerIndex;
        internal ComponentMask componentMask;
        internal  ShaderPassVertexShaderConstantBlockBase(BinaryReader binaryReader)
        {
            this.sourceParameter = binaryReader.ReadStringID();
            this.scaleByTextureStage = (ScaleByTextureStage)binaryReader.ReadInt16();
            this.registerBank = (RegisterBank)binaryReader.ReadInt16();
            this.registerIndex = binaryReader.ReadInt16();
            this.componentMask = (ComponentMask)binaryReader.ReadInt16();
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
        internal enum ScaleByTextureStage : short
        
        {
            None = 0,
            Stage0 = 1,
            Stage1 = 2,
            Stage2 = 3,
            Stage3 = 4,
        };
        internal enum RegisterBank : short
        
        {
            Vn015 = 0,
            Cn012 = 1,
        };
        internal enum ComponentMask : short
        
        {
            XValue = 0,
            YValue = 1,
            ZValue = 2,
            WValue = 3,
            XyzRgbColor = 4,
            XUniformScale = 5,
            YUniformScale = 6,
            ZUniformScale = 7,
            WUniformScale = 8,
            Xy2DScale = 9,
            Zw2DScale = 10,
            Xy2DTranslation = 11,
            Zw2DTranslation = 12,
            Xyzw2DSimpleXform = 13,
            XywRow12DAffineXform = 14,
            XywRow22DAffineXform = 15,
            Xyz3DScale = 16,
            Xyz3DTranslation = 17,
            XyzwRow13DAffineXform = 18,
            XyzwRow23DAffineXform = 19,
            XyzwRow33DAffineXform = 20,
        };
    };
}
