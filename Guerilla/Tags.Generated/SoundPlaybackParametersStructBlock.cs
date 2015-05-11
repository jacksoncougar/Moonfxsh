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
    public partial class SoundPlaybackParametersStructBlock : SoundPlaybackParametersStructBlockBase
    {
        public SoundPlaybackParametersStructBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 56, Alignment = 4)]
    public class SoundPlaybackParametersStructBlockBase : GuerillaBlock
    {
        /// <summary>
        /// the distance below which this sound no longer gets louder
        /// </summary>
        internal float minimumDistanceWorldUnits;

        /// <summary>
        /// the distance beyond which this sound is no longer audible
        /// </summary>
        internal float maximumDistanceWorldUnits;

        /// <summary>
        /// fraction of requests to play this sound that will be ignored (0 means always play.)
        /// </summary>
        internal float skipFraction;

        internal float maximumBendPerSecondCents;

        /// <summary>
        /// sound's random gain will start here
        /// </summary>
        internal float gainBaseDB;

        /// <summary>
        /// sound's gain will be randomly modulated within this range
        /// </summary>
        internal float gainVarianceDB;

        /// <summary>
        /// the sound's pitch will be modulated randomly within this range.
        /// </summary>
        internal int randomPitchBoundsCents;

        /// <summary>
        /// within the cone defined by this angle and the sound's direction, the sound plays with a gain of 1.0.
        /// </summary>
        internal float innerConeAngleDegrees;

        /// <summary>
        /// outside the cone defined by this angle and the sound's direction, the sound plays with a gain of OUTER CONE GAIN. (0 means the sound does not attenuate with direction.)
        /// </summary>
        internal float outerConeAngleDegrees;

        /// <summary>
        /// the gain to use when the sound is directed away from the listener
        /// </summary>
        internal float outerConeGainDB;

        internal Flags flags;
        internal float azimuth;
        internal float positionalGainDB;
        internal float firstPersonGainDB;

        public override int SerializedSize
        {
            get { return 56; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public SoundPlaybackParametersStructBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            minimumDistanceWorldUnits = binaryReader.ReadSingle();
            maximumDistanceWorldUnits = binaryReader.ReadSingle();
            skipFraction = binaryReader.ReadSingle();
            maximumBendPerSecondCents = binaryReader.ReadSingle();
            gainBaseDB = binaryReader.ReadSingle();
            gainVarianceDB = binaryReader.ReadSingle();
            randomPitchBoundsCents = binaryReader.ReadInt32();
            innerConeAngleDegrees = binaryReader.ReadSingle();
            outerConeAngleDegrees = binaryReader.ReadSingle();
            outerConeGainDB = binaryReader.ReadSingle();
            flags = (Flags) binaryReader.ReadInt32();
            azimuth = binaryReader.ReadSingle();
            positionalGainDB = binaryReader.ReadSingle();
            firstPersonGainDB = binaryReader.ReadSingle();
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
                binaryWriter.Write(minimumDistanceWorldUnits);
                binaryWriter.Write(maximumDistanceWorldUnits);
                binaryWriter.Write(skipFraction);
                binaryWriter.Write(maximumBendPerSecondCents);
                binaryWriter.Write(gainBaseDB);
                binaryWriter.Write(gainVarianceDB);
                binaryWriter.Write(randomPitchBoundsCents);
                binaryWriter.Write(innerConeAngleDegrees);
                binaryWriter.Write(outerConeAngleDegrees);
                binaryWriter.Write(outerConeGainDB);
                binaryWriter.Write((Int32) flags);
                binaryWriter.Write(azimuth);
                binaryWriter.Write(positionalGainDB);
                binaryWriter.Write(firstPersonGainDB);
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum Flags : int
        {
            OverrideAzimuth = 1,
            Override3DGain = 2,
            OverrideSpeakerGain = 4,
        };
    };
}