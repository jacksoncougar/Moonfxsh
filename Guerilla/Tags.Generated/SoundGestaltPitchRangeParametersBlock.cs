// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public artial class SoundGestaltPitchRangeParametersBlock : SoundGestaltPitchRangeParametersBlockBase
    {
        public  oundGestaltPitchRangeParametersBlock(B inaryReader binaryReader) :  base(b inaryReader) 
        {
         
    };

    LayoutAttribute(S ize = 10, Alignment = 4) ]
    public class SoundGestaltPitchRangeParametersBlockBase  GuerillaBlock
    {
        internal short naturalPitchCent

          /// <summary>
        /// the range of pitches that will be represented using this sample.
        /// </summary>
        internal int bendBoundsCent

          internal int maxGainPitchBoundsCent

          
       public override int SerializedSize{get {  return 10; }}
         
        internal  SoundGestaltPitchRangeParametersBlockBase(BinaryRe ader binaryReader): base(binaryReader)
        {
             naturalPitchCents = binaryReader.ReadInt16();
             bendBoundsCen

        yReader.ReadInt32 ();
            maxGainPitchBoundsCents = binaryReade r.ReadInt32();
        }
          public override int Write ( System.IO.BinaryWriter binaryWriter, Int32 nextAddres s)
        {
             using(binaryWriter.BaseStream .Pin())
             {
                binaryWriter.W rite(naturalPitchCents) ;
                binaryWriter.Write(bendBoundsCents);
                binyWriter.Write(maxGainPitchBoundsCents);
                return nextAddress;
            }
        }
    };
}
