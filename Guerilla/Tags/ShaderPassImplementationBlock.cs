using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderPassImplementationBlock : ShaderPassImplementationBlockBase
    {
        public  ShaderPassImplementationBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 116)]
    public class ShaderPassImplementationBlockBase
    {
        internal Flags flags;
        internal byte[] invalidName_;
        internal ShaderPassTextureBlock[] textures;
        [TagReference("vrtx")]
        internal Moonfish.Tags.TagReference vertexShader;
        internal ShaderPassVertexShaderConstantBlock[] vsConstants;
        internal byte[] pixelShaderCodeNOLONGERUSED;
        internal Channels channels;
        internal AlphaBlend alphaBlend;
        internal Depth depth;
        internal byte[] invalidName_0;
        internal ShaderStateChannelsStateBlock[] channelState;
        internal ShaderStateAlphaBlendStateBlock[] alphaBlendState;
        internal ShaderStateAlphaTestStateBlock[] alphaTestState;
        internal ShaderStateDepthStateBlock[] depthState;
        internal ShaderStateCullStateBlock[] cullState;
        internal ShaderStateFillStateBlock[] fillState;
        internal ShaderStateMiscStateBlock[] miscState;
        internal ShaderStateConstantBlock[] constants;
        [TagReference("pixl")]
        internal Moonfish.Tags.TagReference pixelShader;
        internal  ShaderPassImplementationBlockBase(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.textures = ReadShaderPassTextureBlockArray(binaryReader);
            this.vertexShader = binaryReader.ReadTagReference();
            this.vsConstants = ReadShaderPassVertexShaderConstantBlockArray(binaryReader);
            this.pixelShaderCodeNOLONGERUSED = ReadData(binaryReader);
            this.channels = (Channels)binaryReader.ReadInt16();
            this.alphaBlend = (AlphaBlend)binaryReader.ReadInt16();
            this.depth = (Depth)binaryReader.ReadInt16();
            this.invalidName_0 = binaryReader.ReadBytes(2);
            this.channelState = ReadShaderStateChannelsStateBlockArray(binaryReader);
            this.alphaBlendState = ReadShaderStateAlphaBlendStateBlockArray(binaryReader);
            this.alphaTestState = ReadShaderStateAlphaTestStateBlockArray(binaryReader);
            this.depthState = ReadShaderStateDepthStateBlockArray(binaryReader);
            this.cullState = ReadShaderStateCullStateBlockArray(binaryReader);
            this.fillState = ReadShaderStateFillStateBlockArray(binaryReader);
            this.miscState = ReadShaderStateMiscStateBlockArray(binaryReader);
            this.constants = ReadShaderStateConstantBlockArray(binaryReader);
            this.pixelShader = binaryReader.ReadTagReference();
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
        internal  virtual ShaderPassTextureBlock[] ReadShaderPassTextureBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderPassTextureBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderPassTextureBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderPassTextureBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ShaderPassVertexShaderConstantBlock[] ReadShaderPassVertexShaderConstantBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderPassVertexShaderConstantBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderPassVertexShaderConstantBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderPassVertexShaderConstantBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ShaderStateChannelsStateBlock[] ReadShaderStateChannelsStateBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderStateChannelsStateBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderStateChannelsStateBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderStateChannelsStateBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ShaderStateAlphaBlendStateBlock[] ReadShaderStateAlphaBlendStateBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderStateAlphaBlendStateBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderStateAlphaBlendStateBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderStateAlphaBlendStateBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ShaderStateAlphaTestStateBlock[] ReadShaderStateAlphaTestStateBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderStateAlphaTestStateBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderStateAlphaTestStateBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderStateAlphaTestStateBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ShaderStateDepthStateBlock[] ReadShaderStateDepthStateBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderStateDepthStateBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderStateDepthStateBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderStateDepthStateBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ShaderStateCullStateBlock[] ReadShaderStateCullStateBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderStateCullStateBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderStateCullStateBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderStateCullStateBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ShaderStateFillStateBlock[] ReadShaderStateFillStateBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderStateFillStateBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderStateFillStateBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderStateFillStateBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ShaderStateMiscStateBlock[] ReadShaderStateMiscStateBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderStateMiscStateBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderStateMiscStateBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderStateMiscStateBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ShaderStateConstantBlock[] ReadShaderStateConstantBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderStateConstantBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderStateConstantBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderStateConstantBlock(binaryReader);
                }
            }
            return array;
        }
        [FlagsAttribute]
        internal enum Flags : short
        
        {
            DeleteFromCacheFile = 1,
            Critical = 2,
        };
        internal enum Channels : short
        
        {
            All = 0,
            ColorOnly = 1,
            AlphaOnly = 2,
            Custom = 3,
        };
        internal enum AlphaBlend : short
        
        {
            Disabled = 0,
            Add = 1,
            Multiply = 2,
            AddSrcTimesDstalpha = 3,
            AddSrcTimesSrcalpha = 4,
            AddDstTimesSrcalphaInverse = 5,
            AlphaBlend = 6,
            Custom = 7,
        };
        internal enum Depth : short
        
        {
            Disabled = 0,
            DefaultOpaque = 1,
            DefaultOpaqueWrite = 2,
            DefaultTransparent = 3,
            Custom = 4,
        };
    };
}
