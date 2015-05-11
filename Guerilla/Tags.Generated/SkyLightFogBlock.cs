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
    public partial class SkyLightFogBlock : SkyLightFogBlockBase
    {
        public SkyLightFogBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 44, Alignment = 4)]
    public class SkyLightFogBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.ColourR8G8B8 color;

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

        public override int SerializedSize
        {
            get { return 44; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public SkyLightFogBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            color = binaryReader.ReadColorR8G8B8();
            maximumDensity01 = binaryReader.ReadSingle();
            startDistanceWorldUnits = binaryReader.ReadSingle();
            opaqueDistanceWorldUnits = binaryReader.ReadSingle();
            coneDegrees = binaryReader.ReadRange();
            atmosphericFogInfluence01 = binaryReader.ReadSingle();
            secondaryFogInfluence01 = binaryReader.ReadSingle();
            skyFogInfluence01 = binaryReader.ReadSingle();
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
                binaryWriter.Write(color);
                binaryWriter.Write(maximumDensity01);
                binaryWriter.Write(startDistanceWorldUnits);
                binaryWriter.Write(opaqueDistanceWorldUnits);
                binaryWriter.Write(coneDegrees);
                binaryWriter.Write(atmosphericFogInfluence01);
                binaryWriter.Write(secondaryFogInfluence01);
                binaryWriter.Write(skyFogInfluence01);
                return nextAddress;
            }
        }
    };
}