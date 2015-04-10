using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SoundGestaltPitchRangeParametersBlock : SoundGestaltPitchRangeParametersBlockBase
    {
        public  SoundGestaltPitchRangeParametersBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 10)]
    public class SoundGestaltPitchRangeParametersBlockBase
    {
        internal short naturalPitchCents;
        /// <summary>
        /// the range of pitches that will be represented using this sample.
        /// </summary>
        internal int bendBoundsCents;
        internal int maxGainPitchBoundsCents;
        internal  SoundGestaltPitchRangeParametersBlockBase(BinaryReader binaryReader)
        {
            this.naturalPitchCents = binaryReader.ReadInt16();
            this.bendBoundsCents = binaryReader.ReadInt32();
            this.maxGainPitchBoundsCents = binaryReader.ReadInt32();
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
