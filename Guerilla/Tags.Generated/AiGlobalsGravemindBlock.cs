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
    public partial class AiGlobalsGravemindBlock : AiGlobalsGravemindBlockBase
    {
        public AiGlobalsGravemindBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class AiGlobalsGravemindBlockBase : GuerillaBlock
    {
        internal float minRetreatTimeSecs;
        internal float idealRetreatTimeSecs;
        internal float maxRetreatTimeSecs;

        public override int SerializedSize
        {
            get { return 12; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public AiGlobalsGravemindBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            minRetreatTimeSecs = binaryReader.ReadSingle();
            idealRetreatTimeSecs = binaryReader.ReadSingle();
            maxRetreatTimeSecs = binaryReader.ReadSingle();
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
                binaryWriter.Write(minRetreatTimeSecs);
                binaryWriter.Write(idealRetreatTimeSecs);
                binaryWriter.Write(maxRetreatTimeSecs);
                return nextAddress;
            }
        }
    };
}