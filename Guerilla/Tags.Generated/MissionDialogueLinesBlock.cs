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
    public partial class MissionDialogueLinesBlock : MissionDialogueLinesBlockBase
    {
        public MissionDialogueLinesBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class MissionDialogueLinesBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent name;
        internal MissionDialogueVariantsBlock[] variants;
        internal Moonfish.Tags.StringIdent defaultSoundEffect;

        public override int SerializedSize
        {
            get { return 16; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public MissionDialogueLinesBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            name = binaryReader.ReadStringID();
            blamPointers.Enqueue(ReadBlockArrayPointer<MissionDialogueVariantsBlock>(binaryReader));
            defaultSoundEffect = binaryReader.ReadStringID();
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            variants = ReadBlockArrayData<MissionDialogueVariantsBlock>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                nextAddress = Guerilla.WriteBlockArray<MissionDialogueVariantsBlock>(binaryWriter, variants, nextAddress);
                binaryWriter.Write(defaultSoundEffect);
                return nextAddress;
            }
        }
    };
}