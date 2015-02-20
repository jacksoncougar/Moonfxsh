using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderPropertiesBlock : ShaderPropertiesBlockBase
    {
        public  ShaderPropertiesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 80)]
    public class ShaderPropertiesBlockBase
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
        internal  ShaderPropertiesBlockBase(BinaryReader binaryReader)
        {
            this.diffuseMap = binaryReader.ReadTagReference();
            this.lightmapEmissiveMap = binaryReader.ReadTagReference();
            this.lightmapEmissiveColor = binaryReader.ReadColorR8G8B8();
            this.lightmapEmissivePower = binaryReader.ReadSingle();
            this.lightmapResolutionScale = binaryReader.ReadSingle();
            this.lightmapHalfLife = binaryReader.ReadSingle();
            this.lightmapDiffuseScale = binaryReader.ReadSingle();
            this.alphaTestMap = binaryReader.ReadTagReference();
            this.translucentMap = binaryReader.ReadTagReference();
            this.lightmapTransparentColor = binaryReader.ReadColorR8G8B8();
            this.lightmapTransparentAlpha = binaryReader.ReadSingle();
            this.lightmapFoliageScale = binaryReader.ReadSingle();
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
    };
}
