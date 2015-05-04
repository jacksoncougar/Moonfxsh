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
    public partial class HudDashlightsBlock : HudDashlightsBlockBase
    {
        public HudDashlightsBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 28, Alignment = 4)]
    public class HudDashlightsBlockBase : GuerillaBlock
    {
        [TagReference("bitm")] internal Moonfish.Tags.TagReference bitmap;
        [TagReference("shad")] internal Moonfish.Tags.TagReference shader;
        internal short sequenceIndex;
        internal Flags flags;
        [TagReference("snd!")] internal Moonfish.Tags.TagReference sound;

        public override int SerializedSize
        {
            get { return 28; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public HudDashlightsBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            bitmap = binaryReader.ReadTagReference();
            shader = binaryReader.ReadTagReference();
            sequenceIndex = binaryReader.ReadInt16();
            flags = (Flags) binaryReader.ReadInt16();
            sound = binaryReader.ReadTagReference();
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
                binaryWriter.Write(bitmap);
                binaryWriter.Write(shader);
                binaryWriter.Write(sequenceIndex);
                binaryWriter.Write((Int16) flags);
                binaryWriter.Write(sound);
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum Flags : short
        {
            DontScaleWhenPulsing = 1,
        };
    };
}