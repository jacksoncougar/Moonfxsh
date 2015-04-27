// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class SoundGestaltPitchRangeParametersBlock : SoundGestaltPitchRangeParametersBlockBase
    {
        public  SoundGestaltPitchRangeParametersBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  SoundGestaltPitchRangeParametersBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 10, Alignment = 4)]
    public class SoundGestaltPitchRangeParametersBlockBase : GuerillaBlock
    {
        internal short naturalPitchCents;
        /// <summary>
        /// the range of pitches that will be represented using this sample.
        /// </summary>
        internal int bendBoundsCents;
        internal int maxGainPitchBoundsCents;
        
        public override int SerializedSize{get { return 10; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  SoundGestaltPitchRangeParametersBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            naturalPitchCents = binaryReader.ReadInt16();
            bendBoundsCents = binaryReader.ReadInt32();
            maxGainPitchBoundsCents = binaryReader.ReadInt32();
        }
        public  SoundGestaltPitchRangeParametersBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(naturalPitchCents);
                binaryWriter.Write(bendBoundsCents);
                binaryWriter.Write(maxGainPitchBoundsCents);
                return nextAddress;
            }
        }
    };
}
