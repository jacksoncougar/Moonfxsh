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
    public partial class PlatformSoundEffectTemplateCollectionBlock : PlatformSoundEffectTemplateCollectionBlockBase
    {
        public PlatformSoundEffectTemplateCollectionBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class PlatformSoundEffectTemplateCollectionBlockBase : GuerillaBlock
    {
        internal PlatformSoundEffectTemplateBlock[] platformEffectTemplates;
        internal Moonfish.Tags.StringIdent inputDspEffectName;

        public override int SerializedSize
        {
            get { return 12; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public PlatformSoundEffectTemplateCollectionBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<PlatformSoundEffectTemplateBlock>(binaryReader));
            inputDspEffectName = binaryReader.ReadStringID();
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            platformEffectTemplates = ReadBlockArrayData<PlatformSoundEffectTemplateBlock>(binaryReader,
                blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<PlatformSoundEffectTemplateBlock>(binaryWriter,
                    platformEffectTemplates, nextAddress);
                binaryWriter.Write(inputDspEffectName);
                return nextAddress;
            }
        }
    };
}