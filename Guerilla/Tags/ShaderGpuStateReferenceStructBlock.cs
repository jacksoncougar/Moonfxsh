using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderGpuStateReferenceStructBlock : ShaderGpuStateReferenceStructBlockBase
    {
        public  ShaderGpuStateReferenceStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 14)]
    public class ShaderGpuStateReferenceStructBlockBase
    {
        internal TagBlockIndexStructBlock renderStates;
        internal TagBlockIndexStructBlock textureStageStates;
        internal TagBlockIndexStructBlock renderStateParameters;
        internal TagBlockIndexStructBlock textureStageParameters;
        internal TagBlockIndexStructBlock textures;
        internal TagBlockIndexStructBlock vnConstants;
        internal TagBlockIndexStructBlock cnConstants;
        internal  ShaderGpuStateReferenceStructBlockBase(BinaryReader binaryReader)
        {
            this.renderStates = new TagBlockIndexStructBlock(binaryReader);
            this.textureStageStates = new TagBlockIndexStructBlock(binaryReader);
            this.renderStateParameters = new TagBlockIndexStructBlock(binaryReader);
            this.textureStageParameters = new TagBlockIndexStructBlock(binaryReader);
            this.textures = new TagBlockIndexStructBlock(binaryReader);
            this.vnConstants = new TagBlockIndexStructBlock(binaryReader);
            this.cnConstants = new TagBlockIndexStructBlock(binaryReader);
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
