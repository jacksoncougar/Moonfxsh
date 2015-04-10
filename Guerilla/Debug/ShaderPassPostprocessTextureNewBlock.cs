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
        public  ShaderPassPostprocessTextureNewBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  ShaderPassPostprocessTextureNewBlockBase(System.IO.BinaryReader binaryReader)
        {
            bitmapParameterIndex = binaryReader.ReadByte();
            bitmapExternIndex = binaryReader.ReadByte();
            textureStageIndex = binaryReader.ReadByte();
            flags = binaryReader.ReadByte();
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
                binaryWriter.Write(bitmapParameterIndex);
                binaryWriter.Write(bitmapExternIndex);
                binaryWriter.Write(textureStageIndex);
                binaryWriter.Write(flags);
            }
        }
    };
}
