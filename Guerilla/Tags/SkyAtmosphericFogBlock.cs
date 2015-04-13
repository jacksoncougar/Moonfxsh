// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SkyAtmosphericFogBlock : SkyAtmosphericFogBlockBase
    {
        public  SkyAtmosphericFogBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class SkyAtmosphericFogBlockBase  : IGuerilla
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
        internal  SkyAtmosphericFogBlockBase(BinaryReader binaryReader)
        {
            color = binaryReader.ReadColorR8G8B8();
            maximumDensity01 = binaryReader.ReadSingle();
            startDistanceWorldUnits = binaryReader.ReadSingle();
            opaqueDistanceWorldUnits = binaryReader.ReadSingle();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(color);
                binaryWriter.Write(maximumDensity01);
                binaryWriter.Write(startDistanceWorldUnits);
                binaryWriter.Write(opaqueDistanceWorldUnits);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
