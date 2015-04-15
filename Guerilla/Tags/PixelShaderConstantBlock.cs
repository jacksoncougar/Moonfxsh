// ReSharper disable All
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
    [LayoutAttribute(Size = 6, Alignment = 4)]
    public class PixelShaderConstantBlockBase  : IGuerilla
    {
        internal ParameterType parameterType;
        internal byte combinerIndex;
        internal byte registerIndex;
        internal ComponentMask componentMask;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal  PixelShaderConstantBlockBase(BinaryReader binaryReader)
        {
            parameterType = (ParameterType)binaryReader.ReadByte();
            combinerIndex = binaryReader.ReadByte();
            registerIndex = binaryReader.ReadByte();
            componentMask = (ComponentMask)binaryReader.ReadByte();
            invalidName_ = binaryReader.ReadBytes(1);
            invalidName_0 = binaryReader.ReadBytes(1);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Byte)parameterType);
                binaryWriter.Write(combinerIndex);
                binaryWriter.Write(registerIndex);
                binaryWriter.Write((Byte)componentMask);
                binaryWriter.Write(invalidName_, 0, 1);
                binaryWriter.Write(invalidName_0, 0, 1);
                return nextAddress;
            }
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
