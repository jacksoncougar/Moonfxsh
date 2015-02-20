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
        public  ShaderPostprocessImplementationNewBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  ShaderPostprocessImplementationNewBlockBase(BinaryReader binaryReader)
        {
            this.bitmapTransforms = new TagBlockIndexStructBlock(binaryReader);
            this.renderStates = new TagBlockIndexStructBlock(binaryReader);
            this.textureStates = new TagBlockIndexStructBlock(binaryReader);
            this.pixelConstants = new TagBlockIndexStructBlock(binaryReader);
            this.vertexConstants = new TagBlockIndexStructBlock(binaryReader);
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
