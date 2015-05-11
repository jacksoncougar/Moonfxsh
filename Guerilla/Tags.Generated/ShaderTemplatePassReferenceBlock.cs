// ReSharper disable All

using Moonfish.Model;

using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class ShaderTemplatePassReferenceBlock : ShaderTemplatePassReferenceBlockBase
    {
        public ShaderTemplatePassReferenceBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class ShaderTemplatePassReferenceBlockBase : GuerillaBlock
    {
        internal Layer layer;
        internal byte[] invalidName_;
        [TagReference("spas")] internal Moonfish.Tags.TagReference pass;
        internal byte[] invalidName_0;

        public override int SerializedSize
        {
            get { return 24; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ShaderTemplatePassReferenceBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            layer = (Layer) binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            pass = binaryReader.ReadTagReference();
            invalidName_0 = binaryReader.ReadBytes(12);
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16) layer);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(pass);
                binaryWriter.Write(invalidName_0, 0, 12);
                return nextAddress;
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