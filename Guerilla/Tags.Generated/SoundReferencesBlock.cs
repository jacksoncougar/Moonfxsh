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
    public partial class SoundReferencesBlock : SoundReferencesBlockBase
    {
        public SoundReferencesBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class SoundReferencesBlockBase : GuerillaBlock
    {
        internal Flags flags;
        internal byte[] invalidName_;
        internal Moonfish.Tags.StringIdent vocalization;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference sound;
        public override int SerializedSize { get { return 16; } }
        public override int Alignment { get { return 4; } }
        public SoundReferencesBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            flags = (Flags)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            vocalization = binaryReader.ReadStringID();
            sound = binaryReader.ReadTagReference();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
            invalidName_[1].ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(vocalization);
                binaryWriter.Write(sound);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : short
        {
            NewVocalization = 1,
        };
    };
}
