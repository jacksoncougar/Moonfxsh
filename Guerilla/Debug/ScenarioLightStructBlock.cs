// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ScenarioLightStructBlock : ScenarioLightStructBlockBase
    {
        public  ScenarioLightStructBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 48)]
    public class ScenarioLightStructBlockBase
    {
        internal Type type;
        internal Flags flags;
        internal LightmapType lightmapType;
        internal LightmapFlags lightmapFlags;
        internal float lightmapHalfLife;
        internal float lightmapLightScale;
        internal OpenTK.Vector3 targetPoint;
        internal float widthWorldUnits;
        internal float heightScaleWorldUnits;
        internal float fieldOfViewDegrees;
        internal float falloffDistanceWorldUnits;
        internal float cutoffDistanceWorldUnitsFromFarPlane;
        internal  ScenarioLightStructBlockBase(System.IO.BinaryReader binaryReader)
        {
            type = (Type)binaryReader.ReadInt16();
            flags = (Flags)binaryReader.ReadInt16();
            lightmapType = (LightmapType)binaryReader.ReadInt16();
            lightmapFlags = (LightmapFlags)binaryReader.ReadInt16();
            lightmapHalfLife = binaryReader.ReadSingle();
            lightmapLightScale = binaryReader.ReadSingle();
            targetPoint = binaryReader.ReadVector3();
            widthWorldUnits = binaryReader.ReadSingle();
            heightScaleWorldUnits = binaryReader.ReadSingle();
            fieldOfViewDegrees = binaryReader.ReadSingle();
            falloffDistanceWorldUnits = binaryReader.ReadSingle();
            cutoffDistanceWorldUnitsFromFarPlane = binaryReader.ReadSingle();
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
                binaryWriter.Write((Int16)type);
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write((Int16)lightmapType);
                binaryWriter.Write((Int16)lightmapFlags);
                binaryWriter.Write(lightmapHalfLife);
                binaryWriter.Write(lightmapLightScale);
                binaryWriter.Write(targetPoint);
                binaryWriter.Write(widthWorldUnits);
                binaryWriter.Write(heightScaleWorldUnits);
                binaryWriter.Write(fieldOfViewDegrees);
                binaryWriter.Write(falloffDistanceWorldUnits);
                binaryWriter.Write(cutoffDistanceWorldUnitsFromFarPlane);
            }
        }
        internal enum Type : short
        
        {
            Sphere = 0,
            Orthogonal = 1,
            Projective = 2,
            Pyramid = 3,
        };
        [FlagsAttribute]
        internal enum Flags : short
        
        {
            CustomGeometry = 1,
            Unused = 2,
            CinematicOnly = 4,
        };
        internal enum LightmapType : short
        
        {
            UseLightTagSetting = 0,
            DynamicOnly = 1,
            DynamicWithLightmaps = 2,
            LightmapsOnly = 3,
        };
        [FlagsAttribute]
        internal enum LightmapFlags : short
        
        {
            Unused = 1,
        };
    };
}
