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
    public partial class SoundEffectTemplateAdditionalSoundInputBlock : SoundEffectTemplateAdditionalSoundInputBlockBase
    {
        public SoundEffectTemplateAdditionalSoundInputBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class SoundEffectTemplateAdditionalSoundInputBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent dspEffect;
        internal MappingFunctionBlock lowFrequencySound;
        internal float timePeriodSeconds;

        public override int SerializedSize
        {
            get { return 16; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public SoundEffectTemplateAdditionalSoundInputBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            dspEffect = binaryReader.ReadStringID();
            lowFrequencySound = new MappingFunctionBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(lowFrequencySound.ReadFields(binaryReader)));
            timePeriodSeconds = binaryReader.ReadSingle();
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            lowFrequencySound.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(dspEffect);
                lowFrequencySound.Write(binaryWriter);
                binaryWriter.Write(timePeriodSeconds);
                return nextAddress;
            }
        }
    };
}