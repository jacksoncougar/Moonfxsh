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
    public partial class AnimationSoundEventBlock : AnimationSoundEventBlockBase
    {
        public AnimationSoundEventBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class AnimationSoundEventBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.ShortBlockIndex1 sound;
        internal short frame;
        internal Moonfish.Tags.StringIdent markerName;
        public override int SerializedSize { get { return 8; } }
        public override int Alignment { get { return 4; } }
        public AnimationSoundEventBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            sound = binaryReader.ReadShortBlockIndex1();
            frame = binaryReader.ReadInt16();
            markerName = binaryReader.ReadStringID();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(sound);
                binaryWriter.Write(frame);
                binaryWriter.Write(markerName);
                return nextAddress;
            }
        }
    };
}
