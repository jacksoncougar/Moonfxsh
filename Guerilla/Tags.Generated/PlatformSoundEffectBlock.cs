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
    public partial class PlatformSoundEffectBlock : PlatformSoundEffectBlockBase
    {
        public PlatformSoundEffectBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 28, Alignment = 4)]
    public class PlatformSoundEffectBlockBase : GuerillaBlock
    {
        internal PlatformSoundEffectFunctionBlock[] functionInputs;
        internal PlatformSoundEffectConstantBlock[] constantInputs;
        internal PlatformSoundEffectOverrideDescriptorBlock[] templateOverrideDescriptors;
        internal int inputOverrides;

        public override int SerializedSize
        {
            get { return 28; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public PlatformSoundEffectBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<PlatformSoundEffectFunctionBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<PlatformSoundEffectConstantBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<PlatformSoundEffectOverrideDescriptorBlock>(binaryReader));
            inputOverrides = binaryReader.ReadInt32();
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            functionInputs = ReadBlockArrayData<PlatformSoundEffectFunctionBlock>(binaryReader, blamPointers.Dequeue());
            constantInputs = ReadBlockArrayData<PlatformSoundEffectConstantBlock>(binaryReader, blamPointers.Dequeue());
            templateOverrideDescriptors = ReadBlockArrayData<PlatformSoundEffectOverrideDescriptorBlock>(binaryReader,
                blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<PlatformSoundEffectFunctionBlock>(binaryWriter, functionInputs,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<PlatformSoundEffectConstantBlock>(binaryWriter, constantInputs,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<PlatformSoundEffectOverrideDescriptorBlock>(binaryWriter,
                    templateOverrideDescriptors, nextAddress);
                binaryWriter.Write(inputOverrides);
                return nextAddress;
            }
        }
    };
}