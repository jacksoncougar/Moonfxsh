// ReSharper disable All
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
    [LayoutAttribute(Size = 88, Alignment = 4)]
    public class ShaderPassPostprocessDefinitionNewBlockBase  : IGuerilla
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
            implementations = Guerilla.ReadBlockArray<ShaderPassPostprocessImplementationNewBlock>(binaryReader);
            textures = Guerilla.ReadBlockArray<ShaderPassPostprocessTextureNewBlock>(binaryReader);
            renderStates = Guerilla.ReadBlockArray<RenderStateBlock>(binaryReader);
            textureStates = Guerilla.ReadBlockArray<ShaderPassPostprocessTextureStateBlock>(binaryReader);
            psFragments = Guerilla.ReadBlockArray<PixelShaderFragmentBlock>(binaryReader);
            psPermutations = Guerilla.ReadBlockArray<PixelShaderPermutationNewBlock>(binaryReader);
            psCombiners = Guerilla.ReadBlockArray<PixelShaderCombinerBlock>(binaryReader);
            externs = Guerilla.ReadBlockArray<ShaderPassPostprocessExternNewBlock>(binaryReader);
            constants = Guerilla.ReadBlockArray<ShaderPassPostprocessConstantNewBlock>(binaryReader);
            constantInfo = Guerilla.ReadBlockArray<ShaderPassPostprocessConstantInfoNewBlock>(binaryReader);
            oldImplementations = Guerilla.ReadBlockArray<ShaderPassPostprocessImplementationBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                Guerilla.WriteBlockArray<ShaderPassPostprocessImplementationNewBlock>(binaryWriter, implementations, nextAddress);
                Guerilla.WriteBlockArray<ShaderPassPostprocessTextureNewBlock>(binaryWriter, textures, nextAddress);
                Guerilla.WriteBlockArray<RenderStateBlock>(binaryWriter, renderStates, nextAddress);
                Guerilla.WriteBlockArray<ShaderPassPostprocessTextureStateBlock>(binaryWriter, textureStates, nextAddress);
                Guerilla.WriteBlockArray<PixelShaderFragmentBlock>(binaryWriter, psFragments, nextAddress);
                Guerilla.WriteBlockArray<PixelShaderPermutationNewBlock>(binaryWriter, psPermutations, nextAddress);
                Guerilla.WriteBlockArray<PixelShaderCombinerBlock>(binaryWriter, psCombiners, nextAddress);
                Guerilla.WriteBlockArray<ShaderPassPostprocessExternNewBlock>(binaryWriter, externs, nextAddress);
                Guerilla.WriteBlockArray<ShaderPassPostprocessConstantNewBlock>(binaryWriter, constants, nextAddress);
                Guerilla.WriteBlockArray<ShaderPassPostprocessConstantInfoNewBlock>(binaryWriter, constantInfo, nextAddress);
                Guerilla.WriteBlockArray<ShaderPassPostprocessImplementationBlock>(binaryWriter, oldImplementations, nextAddress);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
