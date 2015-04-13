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
        public  ShaderPassImplementationBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 116, Alignment = 4)]
    public class ShaderPassImplementationBlockBase  : IGuerilla
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
            flags = (Flags)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            textures = Guerilla.ReadBlockArray<ShaderPassTextureBlock>(binaryReader);
            vertexShader = binaryReader.ReadTagReference();
            vsConstants = Guerilla.ReadBlockArray<ShaderPassVertexShaderConstantBlock>(binaryReader);
            pixelShaderCodeNOLONGERUSED = Guerilla.ReadData(binaryReader);
            channels = (Channels)binaryReader.ReadInt16();
            alphaBlend = (AlphaBlend)binaryReader.ReadInt16();
            depth = (Depth)binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(2);
            channelState = Guerilla.ReadBlockArray<ShaderStateChannelsStateBlock>(binaryReader);
            alphaBlendState = Guerilla.ReadBlockArray<ShaderStateAlphaBlendStateBlock>(binaryReader);
            alphaTestState = Guerilla.ReadBlockArray<ShaderStateAlphaTestStateBlock>(binaryReader);
            depthState = Guerilla.ReadBlockArray<ShaderStateDepthStateBlock>(binaryReader);
            cullState = Guerilla.ReadBlockArray<ShaderStateCullStateBlock>(binaryReader);
            fillState = Guerilla.ReadBlockArray<ShaderStateFillStateBlock>(binaryReader);
            miscState = Guerilla.ReadBlockArray<ShaderStateMiscStateBlock>(binaryReader);
            constants = Guerilla.ReadBlockArray<ShaderStateConstantBlock>(binaryReader);
            pixelShader = binaryReader.ReadTagReference();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(invalidName_, 0, 2);
                Guerilla.WriteBlockArray<ShaderPassTextureBlock>(binaryWriter, textures, nextAddress);
                binaryWriter.Write(vertexShader);
                Guerilla.WriteBlockArray<ShaderPassVertexShaderConstantBlock>(binaryWriter, vsConstants, nextAddress);
                Guerilla.WriteData(binaryWriter);
                binaryWriter.Write((Int16)channels);
                binaryWriter.Write((Int16)alphaBlend);
                binaryWriter.Write((Int16)depth);
                binaryWriter.Write(invalidName_0, 0, 2);
                Guerilla.WriteBlockArray<ShaderStateChannelsStateBlock>(binaryWriter, channelState, nextAddress);
                Guerilla.WriteBlockArray<ShaderStateAlphaBlendStateBlock>(binaryWriter, alphaBlendState, nextAddress);
                Guerilla.WriteBlockArray<ShaderStateAlphaTestStateBlock>(binaryWriter, alphaTestState, nextAddress);
                Guerilla.WriteBlockArray<ShaderStateDepthStateBlock>(binaryWriter, depthState, nextAddress);
                Guerilla.WriteBlockArray<ShaderStateCullStateBlock>(binaryWriter, cullState, nextAddress);
                Guerilla.WriteBlockArray<ShaderStateFillStateBlock>(binaryWriter, fillState, nextAddress);
                Guerilla.WriteBlockArray<ShaderStateMiscStateBlock>(binaryWriter, miscState, nextAddress);
                Guerilla.WriteBlockArray<ShaderStateConstantBlock>(binaryWriter, constants, nextAddress);
                binaryWriter.Write(pixelShader);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
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
