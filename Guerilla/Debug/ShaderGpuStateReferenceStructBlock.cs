// ReSharper disable All
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
        public  ShaderGpuStateReferenceStructBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  ShaderGpuStateReferenceStructBlockBase(System.IO.BinaryReader binaryReader)
        {
            renderStates = new TagBlockIndexStructBlock(binaryReader);
            textureStageStates = new TagBlockIndexStructBlock(binaryReader);
            renderStateParameters = new TagBlockIndexStructBlock(binaryReader);
            textureStageParameters = new TagBlockIndexStructBlock(binaryReader);
            textures = new TagBlockIndexStructBlock(binaryReader);
            vnConstants = new TagBlockIndexStructBlock(binaryReader);
            cnConstants = new TagBlockIndexStructBlock(binaryReader);
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
                renderStates.Write(binaryWriter);
                textureStageStates.Write(binaryWriter);
                renderStateParameters.Write(binaryWriter);
                textureStageParameters.Write(binaryWriter);
                textures.Write(binaryWriter);
                vnConstants.Write(binaryWriter);
                cnConstants.Write(binaryWriter);
            }
        }
    };
}
