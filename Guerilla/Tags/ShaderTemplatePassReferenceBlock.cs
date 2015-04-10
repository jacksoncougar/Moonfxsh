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
    [LayoutAttribute(Size = 24)]
    public class ShaderTemplatePassReferenceBlockBase
    {
        internal Layer layer;
        internal byte[] invalidName_;
        [TagReference("spas")]
        internal Moonfish.Tags.TagReference pass;
        internal byte[] invalidName_0;
        internal  ShaderTemplatePassReferenceBlockBase(BinaryReader binaryReader)
        {
            this.layer = (Layer)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.pass = binaryReader.ReadTagReference();
            this.invalidName_0 = binaryReader.ReadBytes(12);
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
