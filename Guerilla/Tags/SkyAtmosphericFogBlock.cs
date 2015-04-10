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
    [LayoutAttribute(Size = 24)]
    public class SkyAtmosphericFogBlockBase
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
            this.color = binaryReader.ReadColorR8G8B8();
            this.maximumDensity01 = binaryReader.ReadSingle();
            this.startDistanceWorldUnits = binaryReader.ReadSingle();
            this.opaqueDistanceWorldUnits = binaryReader.ReadSingle();
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
    };
}
