using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderGpuStateStructBlock : ShaderGpuStateStructBlockBase
    {
        public  ShaderGpuStateStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 56)]
    public class ShaderGpuStateStructBlockBase
    {
        internal RenderStateBlock[] renderStates;
        internal TextureStageStateBlock[] textureStageStates;
        internal RenderStateParameterBlock[] renderStateParameters;
        internal TextureStageStateParameterBlock[] textureStageParameters;
        internal TextureBlock[] textures;
        internal VertexShaderConstantBlock[] vnConstants;
        internal VertexShaderConstantBlock[] cnConstants;
        internal  ShaderGpuStateStructBlockBase(BinaryReader binaryReader)
        {
            this.renderStates = ReadRenderStateBlockArray(binaryReader);
            this.textureStageStates = ReadTextureStageStateBlockArray(binaryReader);
            this.renderStateParameters = ReadRenderStateParameterBlockArray(binaryReader);
            this.textureStageParameters = ReadTextureStageStateParameterBlockArray(binaryReader);
            this.textures = ReadTextureBlockArray(binaryReader);
            this.vnConstants = ReadVertexShaderConstantBlockArray(binaryReader);
            this.cnConstants = ReadVertexShaderConstantBlockArray(binaryReader);
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
        internal  virtual RenderStateBlock[] ReadRenderStateBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(RenderStateBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new RenderStateBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new RenderStateBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual TextureStageStateBlock[] ReadTextureStageStateBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(TextureStageStateBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new TextureStageStateBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new TextureStageStateBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual RenderStateParameterBlock[] ReadRenderStateParameterBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(RenderStateParameterBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new RenderStateParameterBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new RenderStateParameterBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual TextureStageStateParameterBlock[] ReadTextureStageStateParameterBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(TextureStageStateParameterBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new TextureStageStateParameterBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new TextureStageStateParameterBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual TextureBlock[] ReadTextureBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(TextureBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new TextureBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new TextureBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual VertexShaderConstantBlock[] ReadVertexShaderConstantBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(VertexShaderConstantBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new VertexShaderConstantBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new VertexShaderConstantBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
