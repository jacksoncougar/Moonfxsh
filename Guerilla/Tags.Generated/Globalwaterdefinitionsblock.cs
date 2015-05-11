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
    public partial class GlobalWaterDefinitionsBlock : GlobalWaterDefinitionsBlockBase
    {
        public GlobalWaterDefinitionsBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 172, Alignment = 4)]
    public class GlobalWaterDefinitionsBlockBase : GuerillaBlock
    {
        [TagReference("shad")] internal Moonfish.Tags.TagReference shader;
        internal WaterGeometrySectionBlock[] section;
        internal GlobalGeometryBlockInfoStructBlock geometryBlockInfo;
        internal Moonfish.Tags.ColourR8G8B8 sunSpotColor;
        internal Moonfish.Tags.ColourR8G8B8 reflectionTint;
        internal Moonfish.Tags.ColourR8G8B8 refractionTint;
        internal Moonfish.Tags.ColourR8G8B8 horizonColor;
        internal float sunSpecularPower;
        internal float reflectionBumpScale;
        internal float refractionBumpScale;
        internal float fresnelScale;
        internal float sunDirHeading;
        internal float sunDirPitch;
        internal float fOV;
        internal float aspect;
        internal float height;
        internal float farz;
        internal float rotateOffset;
        internal OpenTK.Vector2 center;
        internal OpenTK.Vector2 extents;
        internal float fogNear;
        internal float fogFar;
        internal float dynamicHeightBias;

        public override int SerializedSize
        {
            get { return 172; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public GlobalWaterDefinitionsBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            shader = binaryReader.ReadTagReference();
            blamPointers.Enqueue(ReadBlockArrayPointer<WaterGeometrySectionBlock>(binaryReader));
            geometryBlockInfo = new GlobalGeometryBlockInfoStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(geometryBlockInfo.ReadFields(binaryReader)));
            sunSpotColor = binaryReader.ReadColorR8G8B8();
            reflectionTint = binaryReader.ReadColorR8G8B8();
            refractionTint = binaryReader.ReadColorR8G8B8();
            horizonColor = binaryReader.ReadColorR8G8B8();
            sunSpecularPower = binaryReader.ReadSingle();
            reflectionBumpScale = binaryReader.ReadSingle();
            refractionBumpScale = binaryReader.ReadSingle();
            fresnelScale = binaryReader.ReadSingle();
            sunDirHeading = binaryReader.ReadSingle();
            sunDirPitch = binaryReader.ReadSingle();
            fOV = binaryReader.ReadSingle();
            aspect = binaryReader.ReadSingle();
            height = binaryReader.ReadSingle();
            farz = binaryReader.ReadSingle();
            rotateOffset = binaryReader.ReadSingle();
            center = binaryReader.ReadVector2();
            extents = binaryReader.ReadVector2();
            fogNear = binaryReader.ReadSingle();
            fogFar = binaryReader.ReadSingle();
            dynamicHeightBias = binaryReader.ReadSingle();
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            section = ReadBlockArrayData<WaterGeometrySectionBlock>(binaryReader, blamPointers.Dequeue());
            geometryBlockInfo.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(shader);
                nextAddress = Guerilla.WriteBlockArray<WaterGeometrySectionBlock>(binaryWriter, section, nextAddress);
                geometryBlockInfo.Write(binaryWriter);
                binaryWriter.Write(sunSpotColor);
                binaryWriter.Write(reflectionTint);
                binaryWriter.Write(refractionTint);
                binaryWriter.Write(horizonColor);
                binaryWriter.Write(sunSpecularPower);
                binaryWriter.Write(reflectionBumpScale);
                binaryWriter.Write(refractionBumpScale);
                binaryWriter.Write(fresnelScale);
                binaryWriter.Write(sunDirHeading);
                binaryWriter.Write(sunDirPitch);
                binaryWriter.Write(fOV);
                binaryWriter.Write(aspect);
                binaryWriter.Write(height);
                binaryWriter.Write(farz);
                binaryWriter.Write(rotateOffset);
                binaryWriter.Write(center);
                binaryWriter.Write(extents);
                binaryWriter.Write(fogNear);
                binaryWriter.Write(fogFar);
                binaryWriter.Write(dynamicHeightBias);
                return nextAddress;
            }
        }
    };
}