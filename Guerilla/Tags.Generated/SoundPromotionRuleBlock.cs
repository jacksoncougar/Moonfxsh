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
    public partial class SoundPromotionRuleBlock : SoundPromotionRuleBlockBase
    {
        public SoundPromotionRuleBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class SoundPromotionRuleBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.ShortBlockIndex1 pitchRanges;
        internal short maximumPlayingCount;

        /// <summary>
        /// time from when first permutation plays to when another sound from an equal or lower promotion can play
        /// </summary>
        internal float suppressionTimeSeconds;

        internal byte[] invalidName_;

        public override int SerializedSize
        {
            get { return 16; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public SoundPromotionRuleBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            pitchRanges = binaryReader.ReadShortBlockIndex1();
            maximumPlayingCount = binaryReader.ReadInt16();
            suppressionTimeSeconds = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(8);
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
                binaryWriter.Write(pitchRanges);
                binaryWriter.Write(maximumPlayingCount);
                binaryWriter.Write(suppressionTimeSeconds);
                binaryWriter.Write(invalidName_, 0, 8);
                return nextAddress;
            }
        }
    };
}