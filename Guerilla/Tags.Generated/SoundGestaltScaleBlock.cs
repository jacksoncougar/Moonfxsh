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
    public partial class SoundGestaltScaleBlock : SoundGestaltScaleBlockBase
    {
        public SoundGestaltScaleBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class SoundGestaltScaleBlockBase : GuerillaBlock
    {
        internal SoundScaleModifiersStructBlock soundScaleModifiersStruct;
        public override int SerializedSize { get { return 20; } }
        public override int Alignment { get { return 4; } }
        public SoundGestaltScaleBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            soundScaleModifiersStruct = new SoundScaleModifiersStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(soundScaleModifiersStruct.ReadFields(binaryReader)));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            soundScaleModifiersStruct.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                soundScaleModifiersStruct.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
