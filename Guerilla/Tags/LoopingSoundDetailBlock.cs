using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class LoopingSoundDetailBlock : LoopingSoundDetailBlockBase
    {
        public  LoopingSoundDetailBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 52)]
    public class LoopingSoundDetailBlockBase
    {
        internal Moonfish.Tags.StringID name;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference sound;
        /// <summary>
        /// the time between successive playings of this sound will be randomly selected from this range.
        /// </summary>
        internal Moonfish.Model.Range randomPeriodBoundsSeconds;
        internal float invalidName_;
        internal Flags flags;
        /// <summary>
        /// the sound's position along the horizon will be randomly selected from this range.
        /// </summary>
        internal Moonfish.Model.Range yawBoundsDegrees;
        /// <summary>
        /// the sound's position above (positive values) or below (negative values) the horizon will be randomly selected from this range.
        /// </summary>
        internal Moonfish.Model.Range pitchBoundsDegrees;
        /// <summary>
        /// the sound's distance (from its spatialized looping sound or from the listener if the looping sound is stereo) will be randomly selected from this range.
        /// </summary>
        internal Moonfish.Model.Range distanceBoundsWorldUnits;
        internal  LoopingSoundDetailBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.sound = binaryReader.ReadTagReference();
            this.randomPeriodBoundsSeconds = binaryReader.ReadRange();
            this.invalidName_ = binaryReader.ReadSingle();
            this.flags = (Flags)binaryReader.ReadInt32();
            this.yawBoundsDegrees = binaryReader.ReadRange();
            this.pitchBoundsDegrees = binaryReader.ReadRange();
            this.distanceBoundsWorldUnits = binaryReader.ReadRange();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
        }
        [FlagsAttribute]
        internal enum Flags : int
        
        {
            DontPlayWithAlternate = 1,
            DontPlayWithoutAlternate = 2,
            StartImmediatelyWithLoop = 4,
        };
    };
}
