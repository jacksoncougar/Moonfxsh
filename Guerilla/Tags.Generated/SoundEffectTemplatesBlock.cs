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
    public partial class SoundEffectTemplatesBlock : SoundEffectTemplatesBlockBase
    {
        public SoundEffectTemplatesBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 28, Alignment = 4)]
    public class SoundEffectTemplatesBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent dspEffect;
        internal byte[] explanation;
        internal Flags flags;
        internal short invalidName_;
        internal short invalidName_0;
        internal SoundEffectTemplateParameterBlock[] parameters;

        public override int SerializedSize
        {
            get { return 28; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public SoundEffectTemplatesBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            dspEffect = binaryReader.ReadStringID();
            blamPointers.Enqueue(ReadBlockArrayPointer(binaryReader, 1));
            flags = (Flags) binaryReader.ReadInt32();
            invalidName_ = binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadInt16();
            blamPointers.Enqueue(ReadBlockArrayPointer<SoundEffectTemplateParameterBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            explanation = ReadDataByteArray(binaryReader, blamPointers.Dequeue());
            parameters = ReadBlockArrayData<SoundEffectTemplateParameterBlock>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(dspEffect);
                nextAddress = Guerilla.WriteData(binaryWriter, explanation, nextAddress);
                binaryWriter.Write((Int32) flags);
                binaryWriter.Write(invalidName_);
                binaryWriter.Write(invalidName_0);
                nextAddress = Guerilla.WriteBlockArray<SoundEffectTemplateParameterBlock>(binaryWriter, parameters,
                    nextAddress);
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum Flags : int
        {
            UseHighLevelParameters = 1,
            CustomParameters = 2,
        };
    };
}