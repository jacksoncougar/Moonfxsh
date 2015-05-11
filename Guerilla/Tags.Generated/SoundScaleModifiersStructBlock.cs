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
    public partial class SoundScaleModifiersStructBlock : SoundScaleModifiersStructBlockBase
    {
        public SoundScaleModifiersStructBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class SoundScaleModifiersStructBlockBase : GuerillaBlock
    {
        internal Moonfish.Model.Range gainModifierDB;
        internal int pitchModifierCents;
        internal OpenTK.Vector2 skipFractionModifier;

        public override int SerializedSize
        {
            get { return 20; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public SoundScaleModifiersStructBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            gainModifierDB = binaryReader.ReadRange();
            pitchModifierCents = binaryReader.ReadInt32();
            skipFractionModifier = binaryReader.ReadVector2();
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
                binaryWriter.Write(gainModifierDB);
                binaryWriter.Write(pitchModifierCents);
                binaryWriter.Write(skipFractionModifier);
                return nextAddress;
            }
        }
    };
}