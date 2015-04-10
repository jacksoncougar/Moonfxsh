// ReSharper disable All
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
        public  GlobalWaterDefinitionsBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  GlobalWaterDefinitionsBlockBase(System.IO.BinaryReader binaryReader)
        {
            shader = binaryReader.ReadTagReference();
            ReadWaterGeometrySectionBlockArray(binaryReader);
            geometryBlockInfo = new GlobalGeometryBlockInfoStructBlock(binaryReader);
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
        internal  virtual WaterGeometrySectionBlock[] ReadWaterGeometrySectionBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteWaterGeometrySectionBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(shader);
                WriteWaterGeometrySectionBlockArray(binaryWriter);
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
            }
        }
    };
}
