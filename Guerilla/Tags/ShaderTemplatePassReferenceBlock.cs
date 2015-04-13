// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderTemplatePassReferenceBlock : ShaderTemplatePassReferenceBlockBase
    {
        public  ShaderTemplatePassReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class ShaderTemplatePassReferenceBlockBase  : IGuerilla
    {
        internal Layer layer;
        internal byte[] invalidName_;
        [TagReference("spas")]
        internal Moonfish.Tags.TagReference pass;
        internal byte[] invalidName_0;
        internal  ShaderTemplatePassReferenceBlockBase(BinaryReader binaryReader)
        {
            layer = (Layer)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            pass = binaryReader.ReadTagReference();
            invalidName_0 = binaryReader.ReadBytes(12);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)layer);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(pass);
                binaryWriter.Write(invalidName_0, 0, 12);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
        internal enum Layer : short
        {
            Texaccum = 0,
            EnvironmentMap = 1,
            SelfIllumination = 2,
            Overlay = 3,
            Transparent = 4,
            LightmapIndirect = 5,
            Diffuse = 6,
            Specular = 7,
            ShadowGenerate = 8,
            ShadowApply = 9,
            Boom = 10,
            Fog = 11,
            ShPrt = 12,
            ActiveCamo = 13,
            WaterEdgeBlend = 14,
            Decal = 15,
            ActiveCamoStencilModulate = 16,
            Hologram = 17,
            LightAlbedo = 18,
        };
    };
}
