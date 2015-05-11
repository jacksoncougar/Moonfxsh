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
    public partial class ScreenEffectBonusStructBlock : ScreenEffectBonusStructBlockBase
    {
        public ScreenEffectBonusStructBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class ScreenEffectBonusStructBlockBase : GuerillaBlock
    {
        [TagReference("egor")] internal Moonfish.Tags.TagReference halfscreenScreenEffect;
        [TagReference("egor")] internal Moonfish.Tags.TagReference quarterscreenScreenEffect;

        public override int SerializedSize
        {
            get { return 16; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ScreenEffectBonusStructBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            halfscreenScreenEffect = binaryReader.ReadTagReference();
            quarterscreenScreenEffect = binaryReader.ReadTagReference();
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
                binaryWriter.Write(halfscreenScreenEffect);
                binaryWriter.Write(quarterscreenScreenEffect);
                return nextAddress;
            }
        }
    };
}