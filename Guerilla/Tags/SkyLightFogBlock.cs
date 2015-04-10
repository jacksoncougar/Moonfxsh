using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SkyLightFogBlock : SkyLightFogBlockBase
    {
        public  SkyLightFogBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 44)]
    public class SkyLightFogBlockBase
    {
        internal Moonfish.Tags.ColorR8G8B8 color;
        /// <summary>
        /// Fog density is clamped to this value.
        /// </summary>
        internal float maximumDensity01;
        /// <summary>
        /// Before this distance there is no fog.
        /// </summary>
        internal float startDistanceWorldUnits;
        /// <summary>
        /// Fog becomes opaque (maximum density) at this distance from the viewer.
        /// </summary>
        internal float opaqueDistanceWorldUnits;
        internal Moonfish.Model.Range coneDegrees;
        internal float atmosphericFogInfluence01;
        internal float secondaryFogInfluence01;
        internal float skyFogInfluence01;
        internal  SkyLightFogBlockBase(BinaryReader binaryReader)
        {
            this.color = binaryReader.ReadColorR8G8B8();
            this.maximumDensity01 = binaryReader.ReadSingle();
            this.startDistanceWorldUnits = binaryReader.ReadSingle();
            this.opaqueDistanceWorldUnits = binaryReader.ReadSingle();
            this.coneDegrees = binaryReader.ReadRange();
            this.atmosphericFogInfluence01 = binaryReader.ReadSingle();
            this.secondaryFogInfluence01 = binaryReader.ReadSingle();
            this.skyFogInfluence01 = binaryReader.ReadSingle();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
        }
    };
}
