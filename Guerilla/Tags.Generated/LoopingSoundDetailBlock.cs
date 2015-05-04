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
    public partial class LoopingSoundDetailBlock : LoopingSoundDetailBlockBase
    {
        public LoopingSoundDetailBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 52, Alignment = 4)]
    public class LoopingSoundDetailBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent name;
        [TagReference("snd!")] internal Moonfish.Tags.TagReference sound;

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

        public override int SerializedSize
        {
            get { return 52; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public LoopingSoundDetailBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            name = binaryReader.ReadStringID();
            sound = binaryReader.ReadTagReference();
            randomPeriodBoundsSeconds = binaryReader.ReadRange();
            invalidName_ = binaryReader.ReadSingle();
            flags = (Flags) binaryReader.ReadInt32();
            yawBoundsDegrees = binaryReader.ReadRange();
            pitchBoundsDegrees = binaryReader.ReadRange();
            distanceBoundsWorldUnits = binaryReader.ReadRange();
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
                binaryWriter.Write(name);
                binaryWriter.Write(sound);
                binaryWriter.Write(randomPeriodBoundsSeconds);
                binaryWriter.Write(invalidName_);
                binaryWriter.Write((Int32) flags);
                binaryWriter.Write(yawBoundsDegrees);
                binaryWriter.Write(pitchBoundsDegrees);
                binaryWriter.Write(distanceBoundsWorldUnits);
                return nextAddress;
            }
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