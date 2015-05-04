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
    public partial class SoundGestaltPitchRangeParametersBlock : SoundGestaltPitchRangeParametersBlockBase
    {
        public SoundGestaltPitchRangeParametersBlock() : base()
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

        public override int SerializedSize
        {
            get { return 10; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public SoundGestaltPitchRangeParametersBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            naturalPitchCents = binaryReader.ReadInt16();
            bendBoundsCents = binaryReader.ReadInt32();
            maxGainPitchBoundsCents = binaryReader.ReadInt32();
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
                binaryWriter.Write(naturalPitchCents);
                binaryWriter.Write(bendBoundsCents);
                binaryWriter.Write(maxGainPitchBoundsCents);
                return nextAddress;
            }
        }
    };
}