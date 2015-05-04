// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Udlg = (TagClass)"udlg";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("udlg")]
    public partial class DialogueBlock : DialogueBlockBase
    {
        public DialogueBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class DialogueBlockBase : GuerillaBlock
    {
        [TagReference("adlg")]
        internal Moonfish.Tags.TagReference globalDialogueInfo;
        internal Flags flags;
        internal SoundReferencesBlock[] vocalizations;
        /// <summary>
        /// 3-letter missionDialogueDesignator name
        /// </summary>
        internal Moonfish.Tags.StringIdent missionDialogueDesignator;
        public override int SerializedSize { get { return 24; } }
        public override int Alignment { get { return 4; } }
        public DialogueBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            globalDialogueInfo = binaryReader.ReadTagReference();
            flags = (Flags)binaryReader.ReadInt32();
            blamPointers.Enqueue(ReadBlockArrayPointer<SoundReferencesBlock>(binaryReader));
            missionDialogueDesignator = binaryReader.ReadStringID();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            vocalizations = ReadBlockArrayData<SoundReferencesBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(globalDialogueInfo);
                binaryWriter.Write((Int32)flags);
                nextAddress = Guerilla.WriteBlockArray<SoundReferencesBlock>(binaryWriter, vocalizations, nextAddress);
                binaryWriter.Write(missionDialogueDesignator);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        {
            Female = 1,
        };
    };
}
