// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderPostprocessLevelOfDetailBlock : ShaderPostprocessLevelOfDetailBlockBase
    {
        public  ShaderPostprocessLevelOfDetailBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 152, Alignment = 4)]
    public class ShaderPostprocessLevelOfDetailBlockBase  : IGuerilla
    {
        internal float projectedHeightPercentage;
        internal int availableLayers;
        internal ShaderPostprocessLayerBlock[] layers;
        internal ShaderPostprocessPassBlock[] passes;
        internal ShaderPostprocessImplementationBlock[] implementations;
        internal ShaderPostprocessBitmapBlock[] bitmaps;
        internal ShaderPostprocessBitmapTransformBlock[] bitmapTransforms;
        internal ShaderPostprocessValueBlock[] values;
        internal ShaderPostprocessColorBlock[] colors;
        internal ShaderPostprocessBitmapTransformOverlayBlock[] bitmapTransformOverlays;
        internal ShaderPostprocessValueOverlayBlock[] valueOverlays;
        internal ShaderPostprocessColorOverlayBlock[] colorOverlays;
        internal ShaderPostprocessVertexShaderConstantBlock[] vertexShaderConstants;
        internal ShaderGpuStateStructBlock gPUState;
        internal  ShaderPostprocessLevelOfDetailBlockBase(BinaryReader binaryReader)
        {
            projectedHeightPercentage = binaryReader.ReadSingle();
            availableLayers = binaryReader.ReadInt32();
            layers = Guerilla.ReadBlockArray<ShaderPostprocessLayerBlock>(binaryReader);
            passes = Guerilla.ReadBlockArray<ShaderPostprocessPassBlock>(binaryReader);
            implementations = Guerilla.ReadBlockArray<ShaderPostprocessImplementationBlock>(binaryReader);
            bitmaps = Guerilla.ReadBlockArray<ShaderPostprocessBitmapBlock>(binaryReader);
            bitmapTransforms = Guerilla.ReadBlockArray<ShaderPostprocessBitmapTransformBlock>(binaryReader);
            values = Guerilla.ReadBlockArray<ShaderPostprocessValueBlock>(binaryReader);
            colors = Guerilla.ReadBlockArray<ShaderPostprocessColorBlock>(binaryReader);
            bitmapTransformOverlays = Guerilla.ReadBlockArray<ShaderPostprocessBitmapTransformOverlayBlock>(binaryReader);
            valueOverlays = Guerilla.ReadBlockArray<ShaderPostprocessValueOverlayBlock>(binaryReader);
            colorOverlays = Guerilla.ReadBlockArray<ShaderPostprocessColorOverlayBlock>(binaryReader);
            vertexShaderConstants = Guerilla.ReadBlockArray<ShaderPostprocessVertexShaderConstantBlock>(binaryReader);
            gPUState = new ShaderGpuStateStructBlock(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(projectedHeightPercentage);
                binaryWriter.Write(availableLayers);
                Guerilla.WriteBlockArray<ShaderPostprocessLayerBlock>(binaryWriter, layers, nextAddress);
                Guerilla.WriteBlockArray<ShaderPostprocessPassBlock>(binaryWriter, passes, nextAddress);
                Guerilla.WriteBlockArray<ShaderPostprocessImplementationBlock>(binaryWriter, implementations, nextAddress);
                Guerilla.WriteBlockArray<ShaderPostprocessBitmapBlock>(binaryWriter, bitmaps, nextAddress);
                Guerilla.WriteBlockArray<ShaderPostprocessBitmapTransformBlock>(binaryWriter, bitmapTransforms, nextAddress);
                Guerilla.WriteBlockArray<ShaderPostprocessValueBlock>(binaryWriter, values, nextAddress);
                Guerilla.WriteBlockArray<ShaderPostprocessColorBlock>(binaryWriter, colors, nextAddress);
                Guerilla.WriteBlockArray<ShaderPostprocessBitmapTransformOverlayBlock>(binaryWriter, bitmapTransformOverlays, nextAddress);
                Guerilla.WriteBlockArray<ShaderPostprocessValueOverlayBlock>(binaryWriter, valueOverlays, nextAddress);
                Guerilla.WriteBlockArray<ShaderPostprocessColorOverlayBlock>(binaryWriter, colorOverlays, nextAddress);
                Guerilla.WriteBlockArray<ShaderPostprocessVertexShaderConstantBlock>(binaryWriter, vertexShaderConstants, nextAddress);
                gPUState.Write(binaryWriter);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
