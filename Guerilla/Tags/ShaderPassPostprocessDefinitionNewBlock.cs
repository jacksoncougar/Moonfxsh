using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderPassPostprocessDefinitionNewBlock : ShaderPassPostprocessDefinitionNewBlockBase
    {
        public  ShaderPassPostprocessDefinitionNewBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 88)]
    public class ShaderPassPostprocessDefinitionNewBlockBase
    {
        internal ShaderPassPostprocessImplementationNewBlock[] implementations;
        internal ShaderPassPostprocessTextureNewBlock[] textures;
        internal RenderStateBlock[] renderStates;
        internal ShaderPassPostprocessTextureStateBlock[] textureStates;
        internal PixelShaderFragmentBlock[] psFragments;
        internal PixelShaderPermutationNewBlock[] psPermutations;
        internal PixelShaderCombinerBlock[] psCombiners;
        internal ShaderPassPostprocessExternNewBlock[] externs;
        internal ShaderPassPostprocessConstantNewBlock[] constants;
        internal ShaderPassPostprocessConstantInfoNewBlock[] constantInfo;
        internal ShaderPassPostprocessImplementationBlock[] oldImplementations;
        internal  ShaderPassPostprocessDefinitionNewBlockBase(BinaryReader binaryReader)
        {
            this.implementations = ReadShaderPassPostprocessImplementationNewBlockArray(binaryReader);
            this.textures = ReadShaderPassPostprocessTextureNewBlockArray(binaryReader);
            this.renderStates = ReadRenderStateBlockArray(binaryReader);
            this.textureStates = ReadShaderPassPostprocessTextureStateBlockArray(binaryReader);
            this.psFragments = ReadPixelShaderFragmentBlockArray(binaryReader);
            this.psPermutations = ReadPixelShaderPermutationNewBlockArray(binaryReader);
            this.psCombiners = ReadPixelShaderCombinerBlockArray(binaryReader);
            this.externs = ReadShaderPassPostprocessExternNewBlockArray(binaryReader);
            this.constants = ReadShaderPassPostprocessConstantNewBlockArray(binaryReader);
            this.constantInfo = ReadShaderPassPostprocessConstantInfoNewBlockArray(binaryReader);
            this.oldImplementations = ReadShaderPassPostprocessImplementationBlockArray(binaryReader);
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
        internal  virtual ShaderPassPostprocessImplementationNewBlock[] ReadShaderPassPostprocessImplementationNewBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderPassPostprocessImplementationNewBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderPassPostprocessImplementationNewBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderPassPostprocessImplementationNewBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ShaderPassPostprocessTextureNewBlock[] ReadShaderPassPostprocessTextureNewBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderPassPostprocessTextureNewBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderPassPostprocessTextureNewBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderPassPostprocessTextureNewBlock(binaryReader);
                }
            }
            return array;
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
        internal  virtual ShaderPassPostprocessTextureStateBlock[] ReadShaderPassPostprocessTextureStateBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderPassPostprocessTextureStateBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderPassPostprocessTextureStateBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderPassPostprocessTextureStateBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PixelShaderFragmentBlock[] ReadPixelShaderFragmentBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PixelShaderFragmentBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PixelShaderFragmentBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PixelShaderFragmentBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PixelShaderPermutationNewBlock[] ReadPixelShaderPermutationNewBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PixelShaderPermutationNewBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PixelShaderPermutationNewBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PixelShaderPermutationNewBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PixelShaderCombinerBlock[] ReadPixelShaderCombinerBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PixelShaderCombinerBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PixelShaderCombinerBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PixelShaderCombinerBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ShaderPassPostprocessExternNewBlock[] ReadShaderPassPostprocessExternNewBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderPassPostprocessExternNewBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderPassPostprocessExternNewBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderPassPostprocessExternNewBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ShaderPassPostprocessConstantNewBlock[] ReadShaderPassPostprocessConstantNewBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderPassPostprocessConstantNewBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderPassPostprocessConstantNewBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderPassPostprocessConstantNewBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ShaderPassPostprocessConstantInfoNewBlock[] ReadShaderPassPostprocessConstantInfoNewBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderPassPostprocessConstantInfoNewBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderPassPostprocessConstantInfoNewBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderPassPostprocessConstantInfoNewBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ShaderPassPostprocessImplementationBlock[] ReadShaderPassPostprocessImplementationBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderPassPostprocessImplementationBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderPassPostprocessImplementationBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderPassPostprocessImplementationBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
