// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class SkyRadiosityLightBlock : SkyRadiosityLightBlockBase
    {
        public SkyRadiosityLightBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 40, Alignment = 4)]
    public class SkyRadiosityLightBlockBase : GuerillaBlock
    {
        internal Flags flags;
        /// <summary>
        /// Light color.
        /// </summary>
        internal Moonfish.Tags.ColourR8G8B8 color;
        /// <summary>
        /// Light power from 0 to infinity.
        /// </summary>
        internal float power0Inf;
        /// <summary>
        /// Length of the ray for shadow testing.
        /// </summary>
        internal float testDistanceWorldUnits;
        internal byte[] invalidName_;
        /// <summary>
        /// Angular diameter of the light source in the sky.
        /// </summary>
        internal float diameterDegrees;
        public override int SerializedSize { get { return 40; } }
        public override int Alignment { get { return 4; } }
        public SkyRadiosityLightBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            flags = (Flags)binaryReader.ReadInt32();
            color = binaryReader.ReadColorR8G8B8();
            power0Inf = binaryReader.ReadSingle();
            testDistanceWorldUnits = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(12);
            diameterDegrees = binaryReader.ReadSingle();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write(color);
                binaryWriter.Write(power0Inf);
                binaryWriter.Write(testDistanceWorldUnits);
                binaryWriter.Write(invalidName_, 0, 12);
                binaryWriter.Write(diameterDegrees);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        {
            AffectsExteriors = 1,
            AffectsInteriors = 2,
            DirectIlluminationInLightmaps = 4,
            IndirectIlluminationInLightmaps = 8,
        };
    };
}
