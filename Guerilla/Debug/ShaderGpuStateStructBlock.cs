// ReSharper disable All
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
        public  ShaderGpuStateStructBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  ShaderGpuStateStructBlockBase(System.IO.BinaryReader binaryReader)
        {
            ReadRenderStateBlockArray(binaryReader);
            ReadTextureStageStateBlockArray(binaryReader);
            ReadRenderStateParameterBlockArray(binaryReader);
            ReadTextureStageStateParameterBlockArray(binaryReader);
            ReadTextureBlockArray(binaryReader);
            ReadVertexShaderConstantBlockArray(binaryReader);
            ReadVertexShaderConstantBlockArray(binaryReader);
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
        internal  virtual RenderStateBlock[] ReadRenderStateBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual TextureStageStateBlock[] ReadTextureStageStateBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual RenderStateParameterBlock[] ReadRenderStateParameterBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual TextureStageStateParameterBlock[] ReadTextureStageStateParameterBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual TextureBlock[] ReadTextureBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual VertexShaderConstantBlock[] ReadVertexShaderConstantBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteRenderStateBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteTextureStageStateBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteRenderStateParameterBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteTextureStageStateParameterBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteTextureBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteVertexShaderConstantBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                WriteRenderStateBlockArray(binaryWriter);
                WriteTextureStageStateBlockArray(binaryWriter);
                WriteRenderStateParameterBlockArray(binaryWriter);
                WriteTextureStageStateParameterBlockArray(binaryWriter);
                WriteTextureBlockArray(binaryWriter);
                WriteVertexShaderConstantBlockArray(binaryWriter);
                WriteVertexShaderConstantBlockArray(binaryWriter);
            }
        }
    };
}
