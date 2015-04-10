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
        public  ScenarioLightStructBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  ScenarioLightStructBlockBase(BinaryReader binaryReader)
        {
            this.type = (Type)binaryReader.ReadInt16();
            this.flags = (Flags)binaryReader.ReadInt16();
            this.lightmapType = (LightmapType)binaryReader.ReadInt16();
            this.lightmapFlags = (LightmapFlags)binaryReader.ReadInt16();
            this.lightmapHalfLife = binaryReader.ReadSingle();
            this.lightmapLightScale = binaryReader.ReadSingle();
            this.targetPoint = binaryReader.ReadVector3();
            this.widthWorldUnits = binaryReader.ReadSingle();
            this.heightScaleWorldUnits = binaryReader.ReadSingle();
            this.fieldOfViewDegrees = binaryReader.ReadSingle();
            this.falloffDistanceWorldUnits = binaryReader.ReadSingle();
            this.cutoffDistanceWorldUnitsFromFarPlane = binaryReader.ReadSingle();
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
