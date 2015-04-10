// ReSharper disable All
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
        public  SkyLightFogBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  SkyLightFogBlockBase(System.IO.BinaryReader binaryReader)
        {
            color = binaryReader.ReadColorR8G8B8();
            maximumDensity01 = binaryReader.ReadSingle();
            startDistanceWorldUnits = binaryReader.ReadSingle();
            opaqueDistanceWorldUnits = binaryReader.ReadSingle();
            coneDegrees = binaryReader.ReadRange();
            atmosphericFogInfluence01 = binaryReader.ReadSingle();
            secondaryFogInfluence01 = binaryReader.ReadSingle();
            skyFogInfluence01 = binaryReader.ReadSingle();
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
                binaryWriter.Write(color);
                binaryWriter.Write(maximumDensity01);
                binaryWriter.Write(startDistanceWorldUnits);
                binaryWriter.Write(opaqueDistanceWorldUnits);
                binaryWriter.Write(coneDegrees);
                binaryWriter.Write(atmosphericFogInfluence01);
                binaryWriter.Write(secondaryFogInfluence01);
                binaryWriter.Write(skyFogInfluence01);
            }
        }
    };
}
