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
    public partial class CharacterBoardingBlock : CharacterBoardingBlockBase
    {
        public CharacterBoardingBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class CharacterBoardingBlockBase : GuerillaBlock
    {
        internal Flags flags;

        /// <summary>
        /// maximum distance from entry point that we will consider boarding
        /// </summary>
        internal float maxDistanceWus;

        /// <summary>
        /// give up trying to get in boarding seat if entry point is further away than this
        /// </summary>
        internal float abortDistanceWus;

        /// <summary>
        /// maximum speed at which we will consider boarding
        /// </summary>
        internal float maxSpeedWuS;

        public override int SerializedSize
        {
            get { return 16; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public CharacterBoardingBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            flags = (Flags) binaryReader.ReadInt32();
            maxDistanceWus = binaryReader.ReadSingle();
            abortDistanceWus = binaryReader.ReadSingle();
            maxSpeedWuS = binaryReader.ReadSingle();
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
                binaryWriter.Write((Int32) flags);
                binaryWriter.Write(maxDistanceWus);
                binaryWriter.Write(abortDistanceWus);
                binaryWriter.Write(maxSpeedWuS);
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum Flags : int
        {
            AirborneBoarding = 1,
        };
    };
}