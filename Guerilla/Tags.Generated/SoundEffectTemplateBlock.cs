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
        public static readonly TagClass Fx = (TagClass) "<fx>";
    };
} ;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("<fx>")]
    public partial class SoundEffectTemplateBlock : SoundEffectTemplateBlockBase
    {
        public SoundEffectTemplateBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 28, Alignment = 4)]
    public class SoundEffectTemplateBlockBase : GuerillaBlock
    {
        internal SoundEffectTemplatesBlock[] templateCollection;
        internal Moonfish.Tags.StringIdent inputEffectName;
        internal SoundEffectTemplateAdditionalSoundInputBlock[] additionalSoundInputs;
        internal PlatformSoundEffectTemplateCollectionBlock[] platformSoundEffectTemplateCollectionBlock;

        public override int SerializedSize
        {
            get { return 28; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public SoundEffectTemplateBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<SoundEffectTemplatesBlock>(binaryReader));
            inputEffectName = binaryReader.ReadStringID();
            blamPointers.Enqueue(ReadBlockArrayPointer<SoundEffectTemplateAdditionalSoundInputBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<PlatformSoundEffectTemplateCollectionBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            templateCollection = ReadBlockArrayData<SoundEffectTemplatesBlock>(binaryReader, blamPointers.Dequeue());
            additionalSoundInputs = ReadBlockArrayData<SoundEffectTemplateAdditionalSoundInputBlock>(binaryReader,
                blamPointers.Dequeue());
            platformSoundEffectTemplateCollectionBlock =
                ReadBlockArrayData<PlatformSoundEffectTemplateCollectionBlock>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<SoundEffectTemplatesBlock>(binaryWriter, templateCollection,
                    nextAddress);
                binaryWriter.Write(inputEffectName);
                nextAddress = Guerilla.WriteBlockArray<SoundEffectTemplateAdditionalSoundInputBlock>(binaryWriter,
                    additionalSoundInputs, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<PlatformSoundEffectTemplateCollectionBlock>(binaryWriter,
                    platformSoundEffectTemplateCollectionBlock, nextAddress);
                return nextAddress;
            }
        }
    };
}