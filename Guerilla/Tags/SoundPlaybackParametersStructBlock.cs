using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SoundPlaybackParametersStructBlock : SoundPlaybackParametersStructBlockBase
    {
        public  SoundPlaybackParametersStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 56)]
    public class SoundPlaybackParametersStructBlockBase
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
        internal  SoundPlaybackParametersStructBlockBase(BinaryReader binaryReader)
        {
            this.minimumDistanceWorldUnits = binaryReader.ReadSingle();
            this.maximumDistanceWorldUnits = binaryReader.ReadSingle();
            this.skipFraction = binaryReader.ReadSingle();
            this.maximumBendPerSecondCents = binaryReader.ReadSingle();
            this.gainBaseDB = binaryReader.ReadSingle();
            this.gainVarianceDB = binaryReader.ReadSingle();
            this.randomPitchBoundsCents = binaryReader.ReadInt32();
            this.innerConeAngleDegrees = binaryReader.ReadSingle();
            this.outerConeAngleDegrees = binaryReader.ReadSingle();
            this.outerConeGainDB = binaryReader.ReadSingle();
            this.flags = (Flags)binaryReader.ReadInt32();
            this.azimuth = binaryReader.ReadSingle();
            this.positionalGainDB = binaryReader.ReadSingle();
            this.firstPersonGainDB = binaryReader.ReadSingle();
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
        [FlagsAttribute]
        internal enum Flags : int
        
        {
            OverrideAzimuth = 1,
            Override3DGain = 2,
            OverrideSpeakerGain = 4,
        };
    };
}
