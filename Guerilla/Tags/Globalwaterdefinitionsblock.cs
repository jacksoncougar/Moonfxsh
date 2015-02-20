using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GlobalWaterDefinitionsBlock : GlobalWaterDefinitionsBlockBase
    {
        public  GlobalWaterDefinitionsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 172)]
    public class GlobalWaterDefinitionsBlockBase
    {
        [TagReference("shad")]
        internal Moonfish.Tags.TagReference shader;
        internal WaterGeometrySectionBlock[] section;
        internal GlobalGeometryBlockInfoStructBlock geometryBlockInfo;
        internal Moonfish.Tags.ColorR8G8B8 sunSpotColor;
        internal Moonfish.Tags.ColorR8G8B8 reflectionTint;
        internal Moonfish.Tags.ColorR8G8B8 refractionTint;
        internal Moonfish.Tags.ColorR8G8B8 horizonColor;
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
        internal  GlobalWaterDefinitionsBlockBase(BinaryReader binaryReader)
        {
            this.shader = binaryReader.ReadTagReference();
            this.section = ReadWaterGeometrySectionBlockArray(binaryReader);
            this.geometryBlockInfo = new GlobalGeometryBlockInfoStructBlock(binaryReader);
            this.sunSpotColor = binaryReader.ReadColorR8G8B8();
            this.reflectionTint = binaryReader.ReadColorR8G8B8();
            this.refractionTint = binaryReader.ReadColorR8G8B8();
            this.horizonColor = binaryReader.ReadColorR8G8B8();
            this.sunSpecularPower = binaryReader.ReadSingle();
            this.reflectionBumpScale = binaryReader.ReadSingle();
            this.refractionBumpScale = binaryReader.ReadSingle();
            this.fresnelScale = binaryReader.ReadSingle();
            this.sunDirHeading = binaryReader.ReadSingle();
            this.sunDirPitch = binaryReader.ReadSingle();
            this.fOV = binaryReader.ReadSingle();
            this.aspect = binaryReader.ReadSingle();
            this.height = binaryReader.ReadSingle();
            this.farz = binaryReader.ReadSingle();
            this.rotateOffset = binaryReader.ReadSingle();
            this.center = binaryReader.ReadVector2();
            this.extents = binaryReader.ReadVector2();
            this.fogNear = binaryReader.ReadSingle();
            this.fogFar = binaryReader.ReadSingle();
            this.dynamicHeightBias = binaryReader.ReadSingle();
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
        internal  virtual WaterGeometrySectionBlock[] ReadWaterGeometrySectionBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(WaterGeometrySectionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new WaterGeometrySectionBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new WaterGeometrySectionBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
