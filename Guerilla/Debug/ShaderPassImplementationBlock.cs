// ReSharper disable All
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
        public  ShaderPassImplementationBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  ShaderPassImplementationBlockBase(System.IO.BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            ReadShaderPassTextureBlockArray(binaryReader);
            vertexShader = binaryReader.ReadTagReference();
            ReadShaderPassVertexShaderConstantBlockArray(binaryReader);
            pixelShaderCodeNOLONGERUSED = ReadData(binaryReader);
            channels = (Channels)binaryReader.ReadInt16();
            alphaBlend = (AlphaBlend)binaryReader.ReadInt16();
            depth = (Depth)binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(2);
            ReadShaderStateChannelsStateBlockArray(binaryReader);
            ReadShaderStateAlphaBlendStateBlockArray(binaryReader);
            ReadShaderStateAlphaTestStateBlockArray(binaryReader);
            ReadShaderStateDepthStateBlockArray(binaryReader);
            ReadShaderStateCullStateBlockArray(binaryReader);
            ReadShaderStateFillStateBlockArray(binaryReader);
            ReadShaderStateMiscStateBlockArray(binaryReader);
            ReadShaderStateConstantBlockArray(binaryReader);
            pixelShader = binaryReader.ReadTagReference();
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
        internal  virtual ShaderPassTextureBlock[] ReadShaderPassTextureBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual ShaderPassVertexShaderConstantBlock[] ReadShaderPassVertexShaderConstantBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual ShaderStateChannelsStateBlock[] ReadShaderStateChannelsStateBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual ShaderStateAlphaBlendStateBlock[] ReadShaderStateAlphaBlendStateBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual ShaderStateAlphaTestStateBlock[] ReadShaderStateAlphaTestStateBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual ShaderStateDepthStateBlock[] ReadShaderStateDepthStateBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual ShaderStateCullStateBlock[] ReadShaderStateCullStateBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual ShaderStateFillStateBlock[] ReadShaderStateFillStateBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual ShaderStateMiscStateBlock[] ReadShaderStateMiscStateBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual ShaderStateConstantBlock[] ReadShaderStateConstantBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteShaderPassTextureBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteShaderPassVertexShaderConstantBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteShaderStateChannelsStateBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteShaderStateAlphaBlendStateBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteShaderStateAlphaTestStateBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteShaderStateDepthStateBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteShaderStateCullStateBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteShaderStateFillStateBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteShaderStateMiscStateBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteShaderStateConstantBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(invalidName_, 0, 2);
                WriteShaderPassTextureBlockArray(binaryWriter);
                binaryWriter.Write(vertexShader);
                WriteShaderPassVertexShaderConstantBlockArray(binaryWriter);
                WriteData(binaryWriter);
                binaryWriter.Write((Int16)channels);
                binaryWriter.Write((Int16)alphaBlend);
                binaryWriter.Write((Int16)depth);
                binaryWriter.Write(invalidName_0, 0, 2);
                WriteShaderStateChannelsStateBlockArray(binaryWriter);
                WriteShaderStateAlphaBlendStateBlockArray(binaryWriter);
                WriteShaderStateAlphaTestStateBlockArray(binaryWriter);
                WriteShaderStateDepthStateBlockArray(binaryWriter);
                WriteShaderStateCullStateBlockArray(binaryWriter);
                WriteShaderStateFillStateBlockArray(binaryWriter);
                WriteShaderStateMiscStateBlockArray(binaryWriter);
                WriteShaderStateConstantBlockArray(binaryWriter);
                binaryWriter.Write(pixelShader);
            }
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
