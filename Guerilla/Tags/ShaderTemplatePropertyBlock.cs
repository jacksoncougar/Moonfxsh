// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderTemplatePropertyBlock : ShaderTemplatePropertyBlockBase
    {
        public  ShaderTemplatePropertyBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class ShaderTemplatePropertyBlockBase  : IGuerilla
    {
        internal Property property;
        internal byte[] invalidName_;
        internal Moonfish.Tags.StringID parameterName;
        internal  ShaderTemplatePropertyBlockBase(BinaryReader binaryReader)
        {
            property = (Property)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            parameterName = binaryReader.ReadStringID();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)property);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(parameterName);
                return nextAddress;
            }
        }
        internal enum Property : short
        {
            Unused = 0,
            DiffuseMap = 1,
            LightmapEmissiveMap = 2,
            LightmapEmissiveColor = 3,
            LightmapEmissivePower = 4,
            LightmapResolutionScale = 5,
            LightmapHalfLife = 6,
            LightmapDiffuseScale = 7,
            LightmapAlphaTestMap = 8,
            LightmapTranslucentMap = 9,
            LightmapTranslucentColor = 10,
            LightmapTranslucentAlpha = 11,
            ActiveCamoMap = 12,
            LightmapFoliageScale = 13,
        };
    };
}
