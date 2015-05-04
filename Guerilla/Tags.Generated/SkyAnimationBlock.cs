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
    public partial class SkyAnimationBlock : SkyAnimationBlockBase
    {
        public SkyAnimationBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 36, Alignment = 4)]
    public class SkyAnimationBlockBase : GuerillaBlock
    {
        /// <summary>
        /// Index of the animation in the animation graph.
        /// </summary>
        internal short animationIndex;

        internal byte[] invalidName_;
        internal float periodSec;
        internal byte[] invalidName_0;

        public override int SerializedSize
        {
            get { return 36; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public SkyAnimationBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            animationIndex = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            periodSec = binaryReader.ReadSingle();
            invalidName_0 = binaryReader.ReadBytes(28);
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
                binaryWriter.Write(animationIndex);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(periodSec);
                binaryWriter.Write(invalidName_0, 0, 28);
                return nextAddress;
            }
        }
    };
}