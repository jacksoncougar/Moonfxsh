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
        public static readonly TagClass Spk = (TagClass)"spk!";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("spk!")]
    public partial class SoundDialogueConstantsBlock : SoundDialogueConstantsBlockBase
    {
        public SoundDialogueConstantsBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 40, Alignment = 4)]
    public class SoundDialogueConstantsBlockBase : GuerillaBlock
    {
        internal float almostNever;
        internal float rarely;
        internal float somewhat;
        internal float often;
        internal byte[] invalidName_;
        public override int SerializedSize { get { return 40; } }
        public override int Alignment { get { return 4; } }
        public SoundDialogueConstantsBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            almostNever = binaryReader.ReadSingle();
            rarely = binaryReader.ReadSingle();
            somewhat = binaryReader.ReadSingle();
            often = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(24);
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
                binaryWriter.Write(almostNever);
                binaryWriter.Write(rarely);
                binaryWriter.Write(somewhat);
                binaryWriter.Write(often);
                binaryWriter.Write(invalidName_, 0, 24);
                return nextAddress;
            }
        }
    };
}
