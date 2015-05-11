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
    public partial class PlatformSoundEffectCollectionBlock : PlatformSoundEffectCollectionBlockBase
    {
        public PlatformSoundEffectCollectionBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class PlatformSoundEffectCollectionBlockBase : GuerillaBlock
    {
        internal PlatformSoundEffectBlock[] soundEffects;
        internal PlatformSoundEffectFunctionBlock[] lowFrequencyInput;
        internal int soundEffectOverrides;

        public override int SerializedSize
        {
            get { return 20; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public PlatformSoundEffectCollectionBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<PlatformSoundEffectBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<PlatformSoundEffectFunctionBlock>(binaryReader));
            soundEffectOverrides = binaryReader.ReadInt32();
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            soundEffects = ReadBlockArrayData<PlatformSoundEffectBlock>(binaryReader, blamPointers.Dequeue());
            lowFrequencyInput = ReadBlockArrayData<PlatformSoundEffectFunctionBlock>(binaryReader,
                blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<PlatformSoundEffectBlock>(binaryWriter, soundEffects, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<PlatformSoundEffectFunctionBlock>(binaryWriter, lowFrequencyInput,
                    nextAddress);
                binaryWriter.Write(soundEffectOverrides);
                return nextAddress;
            }
        }
    };
}