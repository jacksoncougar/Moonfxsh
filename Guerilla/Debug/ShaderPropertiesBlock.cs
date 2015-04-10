// ReSharper disable All
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
        public  ShaderPropertiesBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  ShaderPropertiesBlockBase(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
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
            }
        }
    };
}
