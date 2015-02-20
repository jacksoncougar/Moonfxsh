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
    [LayoutAttribute(Size = 4)]
    public class ShaderPassPostprocessTextureNewBlockBase
    {
        internal byte bitmapParameterIndex;
        internal byte bitmapExternIndex;
        internal byte textureStageIndex;
        internal byte flags;
        internal  ShaderPassPostprocessTextureNewBlockBase(BinaryReader binaryReader)
        {
            this.bitmapParameterIndex = binaryReader.ReadByte();
            this.bitmapExternIndex = binaryReader.ReadByte();
            this.textureStageIndex = binaryReader.ReadByte();
            this.flags = binaryReader.ReadByte();
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
