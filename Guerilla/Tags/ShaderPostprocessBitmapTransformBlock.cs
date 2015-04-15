// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderPostprocessBitmapTransformBlock : ShaderPostprocessBitmapTransformBlockBase
    {
        public  ShaderPostprocessBitmapTransformBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 6, Alignment = 4)]
    public class ShaderPostprocessBitmapTransformBlockBase  : IGuerilla
    {
        internal byte parameterIndex;
        internal byte bitmapTransformIndex;
        internal float value;
        internal  ShaderPostprocessBitmapTransformBlockBase(BinaryReader binaryReader)
        {
            parameterIndex = binaryReader.ReadByte();
            bitmapTransformIndex = binaryReader.ReadByte();
            value = binaryReader.ReadSingle();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(parameterIndex);
                binaryWriter.Write(bitmapTransformIndex);
                binaryWriter.Write(value);
                return nextAddress;
            }
        }
    };
}
