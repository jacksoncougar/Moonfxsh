using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderTemplatePostprocessLevelOfDetailNewBlock : ShaderTemplatePostprocessLevelOfDetailNewBlockBase
    {
        public  ShaderTemplatePostprocessLevelOfDetailNewBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 10)]
    public class ShaderTemplatePostprocessLevelOfDetailNewBlockBase
    {
        internal TagBlockIndexStructBlock layers;
        internal int availableLayers;
        internal float projectedHeightPercentage;
        internal  ShaderTemplatePostprocessLevelOfDetailNewBlockBase(BinaryReader binaryReader)
        {
            this.layers = new TagBlockIndexStructBlock(binaryReader);
            this.availableLayers = binaryReader.ReadInt32();
            this.projectedHeightPercentage = binaryReader.ReadSingle();
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
