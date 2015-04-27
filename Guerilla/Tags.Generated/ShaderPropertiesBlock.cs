// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ShaderPropertiesBlock : ShaderPropertiesBlockBase
    {
        public  ShaderPropertiesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ShaderPropertiesBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 80, Alignment = 4)]
    public class ShaderPropertiesBlockBase : GuerillaBlock
    {
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference diffuseMap;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference lightmapEmissiveMap;
        internal Moonfish.Tags.ColorR8G8B8 lightmapEmissiveColor;
        internal float lightmapEmissivePower;
        internal float lightmapResolutionScale;
        internal float lightmapHalfLife;
        internal float lightmapDiffuseScale;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference alphaTestMap;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference translucentMap;
        internal Moonfish.Tags.ColorR8G8B8 lightmapTransparentColor;
        internal float lightmapTransparentAlpha;
        internal float lightmapFoliageScale;
        
        public override int SerializedSize{get { return 80; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ShaderPropertiesBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            diffuseMap = binaryReader.ReadTagReference();
            lightmapEmissiveMap = binaryReader.ReadTagReference();
            lightmapEmissiveColor = binaryReader.ReadColorR8G8B8();
            lightmapEmissivePower = binaryReader.ReadSingle();
            lightmapResolutionScale = binaryReader.ReadSingle();
            lightmapHalfLife = binaryReader.ReadSingle();
            lightmapDiffuseScale = binaryReader.ReadSingle();
            alphaTestMap = binaryReader.ReadTagReference();
            translucentMap = binaryReader.ReadTagReference();
            lightmapTransparentColor = binaryReader.ReadColorR8G8B8();
            lightmapTransparentAlpha = binaryReader.ReadSingle();
            lightmapFoliageScale = binaryReader.ReadSingle();
        }
        public  ShaderPropertiesBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(diffuseMap);
                binaryWriter.Write(lightmapEmissiveMap);
                binaryWriter.Write(lightmapEmissiveColor);
                binaryWriter.Write(lightmapEmissivePower);
                binaryWriter.Write(lightmapResolutionScale);
                binaryWriter.Write(lightmapHalfLife);
                binaryWriter.Write(lightmapDiffuseScale);
                binaryWriter.Write(alphaTestMap);
                binaryWriter.Write(translucentMap);
                binaryWriter.Write(lightmapTransparentColor);
                binaryWriter.Write(lightmapTransparentAlpha);
                binaryWriter.Write(lightmapFoliageScale);
                return nextAddress;
            }
        }
    };
}
