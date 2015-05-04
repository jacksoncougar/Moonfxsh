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
    public partial class SoundGlobalsBlock : SoundGlobalsBlockBase
    {
        public SoundGlobalsBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 36, Alignment = 4)]
    public class SoundGlobalsBlockBase : GuerillaBlock
    {
        [TagReference("sncl")] internal Moonfish.Tags.TagReference soundClasses;
        [TagReference("sfx+")] internal Moonfish.Tags.TagReference soundEffects;
        [TagReference("snmx")] internal Moonfish.Tags.TagReference soundMix;
        [TagReference("spk!")] internal Moonfish.Tags.TagReference soundCombatDialogueConstants;
        internal int invalidName_;

        public override int SerializedSize
        {
            get { return 36; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public SoundGlobalsBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            soundClasses = binaryReader.ReadTagReference();
            soundEffects = binaryReader.ReadTagReference();
            soundMix = binaryReader.ReadTagReference();
            soundCombatDialogueConstants = binaryReader.ReadTagReference();
            invalidName_ = binaryReader.ReadInt32();
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
                binaryWriter.Write(soundClasses);
                binaryWriter.Write(soundEffects);
                binaryWriter.Write(soundMix);
                binaryWriter.Write(soundCombatDialogueConstants);
                binaryWriter.Write(invalidName_);
                return nextAddress;
            }
        }
    };
}