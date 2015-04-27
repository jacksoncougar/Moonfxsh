// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ShaderPassPostprocessTextureNewBlock : ShaderPassPostprocessTextureNewBlockBase
    {
        public  ShaderPassPostprocessTextureNewBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ShaderPassPostprocessTextureNewBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class ShaderPassPostprocessTextureNewBlockBase : GuerillaBlock
    {
        internal byte bitmapParameterIndex;
        internal byte bitmapExternIndex;
        internal byte textureStageIndex;
        internal byte flags;
        
        public override int SerializedSize{get { return 4; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ShaderPassPostprocessTextureNewBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            bitmapParameterIndex = binaryReader.ReadByte();
            bitmapExternIndex = binaryReader.ReadByte();
            textureStageIndex = binaryReader.ReadByte();
            flags = binaryReader.ReadByte();
        }
        public  ShaderPassPostprocessTextureNewBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
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
