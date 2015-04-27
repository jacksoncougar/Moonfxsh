// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ShaderPostprocessDefinitionNewBlock : ShaderPostprocessDefinitionNewBlockBase
    {
        public  ShaderPostprocessDefinitionNewBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ShaderPostprocessDefinitionNewBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 124, Alignment = 4)]
    public class ShaderPostprocessDefinitionNewBlockBase : GuerillaBlock
    {
        internal int shaderTemplateIndex;
        internal ShaderPostprocessBitmapNewBlock[] bitmaps;
        internal Pixel32Block[] pixelConstants;
        internal RealVector4dBlock[] vertexConstants;
        internal ShaderPostprocessLevelOfDetailNewBlock[] levelsOfDetail;
        internal TagBlockIndexBlock[] layers;
        internal TagBlockIndexBlock[] passes;
        internal ShaderPostprocessImplementationNewBlock[] implementations;
        internal ShaderPostprocessOverlayNewBlock[] overlays;
        internal ShaderPostprocessOverlayReferenceNewBlock[] overlayReferences;
        internal ShaderPostprocessAnimatedParameterNewBlock[] animatedParameters;
        internal ShaderPostprocessAnimatedParameterReferenceNewBlock[] animatedParameterReferences;
        internal ShaderPostprocessBitmapPropertyBlock[] bitmapProperties;
        internal ShaderPostprocessColorPropertyBlock[] colorProperties;
        internal ShaderPostprocessValuePropertyBlock[] valueProperties;
        internal ShaderPostprocessLevelOfDetailBlock[] oldLevelsOfDetail;
        
        public override int SerializedSize{get { return 124; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ShaderPostprocessDefinitionNewBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            shaderTemplateIndex = binaryReader.ReadInt32();
            bitmaps = Guerilla.ReadBlockArray<ShaderPostprocessBitmapNewBlock>(binaryReader);
            pixelConstants = Guerilla.ReadBlockArray<Pixel32Block>(binaryReader);
            vertexConstants = Guerilla.ReadBlockArray<RealVector4dBlock>(binaryReader);
            levelsOfDetail = Guerilla.ReadBlockArray<ShaderPostprocessLevelOfDetailNewBlock>(binaryReader);
            layers = Guerilla.ReadBlockArray<TagBlockIndexBlock>(binaryReader);
            passes = Guerilla.ReadBlockArray<TagBlockIndexBlock>(binaryReader);
            implementations = Guerilla.ReadBlockArray<ShaderPostprocessImplementationNewBlock>(binaryReader);
            overlays = Guerilla.ReadBlockArray<ShaderPostprocessOverlayNewBlock>(binaryReader);
            overlayReferences = Guerilla.ReadBlockArray<ShaderPostprocessOverlayReferenceNewBlock>(binaryReader);
            animatedParameters = Guerilla.ReadBlockArray<ShaderPostprocessAnimatedParameterNewBlock>(binaryReader);
            animatedParameterReferences = Guerilla.ReadBlockArray<ShaderPostprocessAnimatedParameterReferenceNewBlock>(binaryReader);
            bitmapProperties = Guerilla.ReadBlockArray<ShaderPostprocessBitmapPropertyBlock>(binaryReader);
            colorProperties = Guerilla.ReadBlockArray<ShaderPostprocessColorPropertyBlock>(binaryReader);
            valueProperties = Guerilla.ReadBlockArray<ShaderPostprocessValuePropertyBlock>(binaryReader);
            oldLevelsOfDetail = Guerilla.ReadBlockArray<ShaderPostprocessLevelOfDetailBlock>(binaryReader);
        }
        public  ShaderPostprocessDefinitionNewBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            shaderTemplateIndex = binaryReader.ReadInt32();
            bitmaps = Guerilla.ReadBlockArray<ShaderPostprocessBitmapNewBlock>(binaryReader);
            pixelConstants = Guerilla.ReadBlockArray<Pixel32Block>(binaryReader);
            vertexConstants = Guerilla.ReadBlockArray<RealVector4dBlock>(binaryReader);
            levelsOfDetail = Guerilla.ReadBlockArray<ShaderPostprocessLevelOfDetailNewBlock>(binaryReader);
            layers = Guerilla.ReadBlockArray<TagBlockIndexBlock>(binaryReader);
            passes = Guerilla.ReadBlockArray<TagBlockIndexBlock>(binaryReader);
            implementations = Guerilla.ReadBlockArray<ShaderPostprocessImplementationNewBlock>(binaryReader);
            overlays = Guerilla.ReadBlockArray<ShaderPostprocessOverlayNewBlock>(binaryReader);
            overlayReferences = Guerilla.ReadBlockArray<ShaderPostprocessOverlayReferenceNewBlock>(binaryReader);
            animatedParameters = Guerilla.ReadBlockArray<ShaderPostprocessAnimatedParameterNewBlock>(binaryReader);
            animatedParameterReferences = Guerilla.ReadBlockArray<ShaderPostprocessAnimatedParameterReferenceNewBlock>(binaryReader);
            bitmapProperties = Guerilla.ReadBlockArray<ShaderPostprocessBitmapPropertyBlock>(binaryReader);
            colorProperties = Guerilla.ReadBlockArray<ShaderPostprocessColorPropertyBlock>(binaryReader);
            valueProperties = Guerilla.ReadBlockArray<ShaderPostprocessValuePropertyBlock>(binaryReader);
            oldLevelsOfDetail = Guerilla.ReadBlockArray<ShaderPostprocessLevelOfDetailBlock>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(shaderTemplateIndex);
                nextAddress = Guerilla.WriteBlockArray<ShaderPostprocessBitmapNewBlock>(binaryWriter, bitmaps, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<Pixel32Block>(binaryWriter, pixelConstants, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<RealVector4dBlock>(binaryWriter, vertexConstants, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ShaderPostprocessLevelOfDetailNewBlock>(binaryWriter, levelsOfDetail, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<TagBlockIndexBlock>(binaryWriter, layers, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<TagBlockIndexBlock>(binaryWriter, passes, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ShaderPostprocessImplementationNewBlock>(binaryWriter, implementations, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ShaderPostprocessOverlayNewBlock>(binaryWriter, overlays, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ShaderPostprocessOverlayReferenceNewBlock>(binaryWriter, overlayReferences, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ShaderPostprocessAnimatedParameterNewBlock>(binaryWriter, animatedParameters, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ShaderPostprocessAnimatedParameterReferenceNewBlock>(binaryWriter, animatedParameterReferences, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ShaderPostprocessBitmapPropertyBlock>(binaryWriter, bitmapProperties, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ShaderPostprocessColorPropertyBlock>(binaryWriter, colorProperties, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ShaderPostprocessValuePropertyBlock>(binaryWriter, valueProperties, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ShaderPostprocessLevelOfDetailBlock>(binaryWriter, oldLevelsOfDetail, nextAddress);
                return nextAddress;
            }
        }
    };
}
