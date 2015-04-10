// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderPostprocessImplementationNewBlock : ShaderPostprocessImplementationNewBlockBase
    {
        public  ShaderPostprocessImplementationNewBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 10)]
    public class ShaderPostprocessImplementationNewBlockBase
    {
        internal TagBlockIndexStructBlock bitmapTransforms;
        internal TagBlockIndexStructBlock renderStates;
        internal TagBlockIndexStructBlock textureStates;
        internal TagBlockIndexStructBlock pixelConstants;
        internal TagBlockIndexStructBlock vertexConstants;
        internal  ShaderPostprocessImplementationNewBlockBase(System.IO.BinaryReader binaryReader)
        {
            bitmapTransforms = new TagBlockIndexStructBlock(binaryReader);
            renderStates = new TagBlockIndexStructBlock(binaryReader);
            textureStates = new TagBlockIndexStructBlock(binaryReader);
            pixelConstants = new TagBlockIndexStructBlock(binaryReader);
            vertexConstants = new TagBlockIndexStructBlock(binaryReader);
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
                bitmapTransforms.Write(binaryWriter);
                renderStates.Write(binaryWriter);
                textureStates.Write(binaryWriter);
                pixelConstants.Write(binaryWriter);
                vertexConstants.Write(binaryWriter);
            }
        }
    };
}
