// ReSharper disable All
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
        public  SoundGestaltPitchRangeParametersBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  SoundGestaltPitchRangeParametersBlockBase(System.IO.BinaryReader binaryReader)
        {
            naturalPitchCents = binaryReader.ReadInt16();
            bendBoundsCents = binaryReader.ReadInt32();
            maxGainPitchBoundsCents = binaryReader.ReadInt32();
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(naturalPitchCents);
                binaryWriter.Write(bendBoundsCents);
                binaryWriter.Write(maxGainPitchBoundsCents);
            }
        }
    };
}
