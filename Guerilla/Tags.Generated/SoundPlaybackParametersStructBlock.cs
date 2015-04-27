// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public artial class SoundPlaybackParametersStructBlock : SoundPlaybackParametersStructBlockBase
    {
        public  oundPlaybackParametersStructBlock(B inaryReader binaryReader) :  base(b inaryReader) 
        {
         
    };

    LayoutAttribute(S ize = 56, Alignment = 4) ]
    public class SoundPlaybackParametersStructBlockBase  GuerillaBlock
    {
        /// <summary>
        /// the distance below which this sound no longer gets louder
        /// </summary>
        internal float minimumDistanceWorldUnit

          /// <summary>
        /// the distance beyond which this sound is no longer audible
        /// </summary>
        internal float maximumDistanceWorldUnit

          /// <summary>
        /// fraction of requests to play this sound that will be ignored (0 means always play.)
        /// </summary>
        internal float skipFractio

          internal float maximumBendPerSecondCent

          /// <summary>
        /// sound's random gain will start here
        /// </summary>
        internal float gainBaseD

          /// <summary>
        /// sound's gain will be randomly modulated within this range
        /// </summary>
        internal float gainVarianceD

          /// <summary>
        /// the sound's pitch will be modulated randomly within this range.
        /// </summary>
        internal int randomPitchBoundsCent

          /// <summary>
        /// within the cone defined by this angle and the sound's direction, the sound plays with a gain of 1.0.
        /// </summary>
        internal float innerConeAngleDegree

          /// <summary>
        /// outside the cone defined by this angle and the sound's direction, the sound plays with a gain of OUTER CONE GAIN. (0 means the sound does not attenuate with direction.)
        /// </summary>
        internal float outerConeAngleDegree

          /// <summary>
        /// the gain to use when the sound is directed away from the listener
        /// </summary>
        internal float outerConeGainD

          internal Flags flags;
        internal float azimuth;
        internal float positionalGainDB;
        internal float firstPersonGainD

          
       public override int SerializedSize{ge t { return 56; }}
         
        internal  SoundPlaybackParametersStructBlockBase(BinaryReader bina ryReader): base(binaryReader)
        {
            minimumDistanc eWorldUnits = binaryReader.ReadSingle();
            m aximumDistanceWorldUnits = binaryReader.ReadSingle();
            s kipFraction = binaryReader.ReadSingle();
             maximumBendPerSecondCents = binaryReader.ReadSingle();
             gainBaseDB = binaryReader.ReadSingle();
             gainVarianceDB = binaryReader.ReadSingle();
            random PitchBoundsCents = binaryReader.ReadInt32();
            innerC oneAngleDegrees = binaryReader.ReadSingle();
             outerConeAngleDegrees = b inary R eader.ReadSingle();
             outerConeGainDB = binaryReader.ReadSingl e();
            flags = (Flags)binaryReader.ReadInt32(); 
            azimuth = binaryReader.ReadSingle();
             positional

        inaryReader.ReadS ingle();
            firstPersonGainDB = binaryReader .ReadSingle();
        }
          public override int Write ( System.IO.BinaryWriter binaryWriter, Int32 nextAddres s)
        {
             using(binaryWriter.BaseStream.Pin()) 
            {
                 binaryWriter.Write(minimumDistan ceWorldUnits );
                binaryWriter.Write( maximumDistanceWorldUnits );
                binaryWriter.Write( skipFracti on);
                binaryWriter.Writ e(maximumBendP erSecondCents);
                binary Writer.Write(gainBaseD B);
                binaryWriter.Write (gainVarianceDB);
                 binaryWriter.Write(random PitchBoundsCents);
                 binaryWriter.Write(inner ConeAngleDegree s);
                binaryWriter.Write ( outer C oneAn gleDegrees);
                binaryWri ter.Wri te(outerConeGainDB);
                b inaryWriter.Writ e((Int32)flags);
                binar yWriter.Write(azi muth);
                binaryWriter.Write(positionalGainDB);
  

            binaryWriter.Write(firstPersonGainDB);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        {
           verrideAzimuth = 1,
            Override3DGain = 2,
            OverrideSpeakerGain = 4,
        };
    };
}
