using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class PixelShaderConstantBlock : PixelShaderConstantBlockBase
    {
        public  PixelShaderConstantBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 6)]
    public class PixelShaderConstantBlockBase
    {
        internal ParameterType parameterType;
        internal byte combinerIndex;
        internal byte registerIndex;
        internal ComponentMask componentMask;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal  PixelShaderConstantBlockBase(BinaryReader binaryReader)
        {
            this.parameterType = (ParameterType)binaryReader.ReadByte();
            this.combinerIndex = binaryReader.ReadByte();
            this.registerIndex = binaryReader.ReadByte();
            this.componentMask = (ComponentMask)binaryReader.ReadByte();
            this.invalidName_ = binaryReader.ReadBytes(1);
            this.invalidName_0 = binaryReader.ReadBytes(1);
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
        internal enum ParameterType : byte
        
        {
            Bitmap = 0,
            Value = 1,
            Color = 2,
            Switch = 3,
        };
        internal enum ComponentMask : byte
        
        {
            XValue = 0,
            YValue = 1,
            ZValue = 2,
            WValue = 3,
            XyzRgbColor = 4,
        };
    };
}
