// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderPassPostprocessTextureNewBlock : ShaderPassPostprocessTextureNewBlockBase
    {
        public  ShaderPassPostprocessTextureNewBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class ShaderPassPostprocessTextureNewBlockBase  : IGuerilla
    {
        internal byte bitmapParameterIndex;
        internal byte bitmapExternIndex;
        internal byte textureStageIndex;
        internal byte flags;
        internal  ShaderPassPostprocessTextureNewBlockBase(BinaryReader binaryReader)
        {
            bitmapParameterIndex = binaryReader.ReadByte();
            bitmapExternIndex = binaryReader.ReadByte();
            textureStageIndex = binaryReader.ReadByte();
            flags = binaryReader.ReadByte();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(bitmapParameterIndex);
                binaryWriter.Write(bitmapExternIndex);
                binaryWriter.Write(textureStageIndex);
                binaryWriter.Write(flags);
                return nextAddress;
            }
        }
    };
}
