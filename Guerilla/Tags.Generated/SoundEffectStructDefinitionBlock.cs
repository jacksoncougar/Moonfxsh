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
    public partial class SoundEffectStructDefinitionBlock : SoundEffectStructDefinitionBlockBase
    {
        public SoundEffectStructDefinitionBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 40, Alignment = 4)]
    public class SoundEffectStructDefinitionBlockBase : GuerillaBlock
    {
        [TagReference("<fx>")] internal Moonfish.Tags.TagReference invalidName_;
        internal SoundEffectComponentBlock[] components;
        internal SoundEffectOverridesBlock[] soundEffectOverridesBlock;
        internal byte[] invalidName_0;
        internal PlatformSoundEffectCollectionBlock[] platformSoundEffectCollectionBlock;

        public override int SerializedSize
        {
            get { return 40; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public SoundEffectStructDefinitionBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            invalidName_ = binaryReader.ReadTagReference();
            blamPointers.Enqueue(ReadBlockArrayPointer<SoundEffectComponentBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<SoundEffectOverridesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer(binaryReader, 1));
            blamPointers.Enqueue(ReadBlockArrayPointer<PlatformSoundEffectCollectionBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            components = ReadBlockArrayData<SoundEffectComponentBlock>(binaryReader, blamPointers.Dequeue());
            soundEffectOverridesBlock = ReadBlockArrayData<SoundEffectOverridesBlock>(binaryReader,
                blamPointers.Dequeue());
            invalidName_0 = ReadDataByteArray(binaryReader, blamPointers.Dequeue());
            platformSoundEffectCollectionBlock = ReadBlockArrayData<PlatformSoundEffectCollectionBlock>(binaryReader,
                blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_);
                nextAddress = Guerilla.WriteBlockArray<SoundEffectComponentBlock>(binaryWriter, components, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<SoundEffectOverridesBlock>(binaryWriter,
                    soundEffectOverridesBlock, nextAddress);
                nextAddress = Guerilla.WriteData(binaryWriter, invalidName_0, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<PlatformSoundEffectCollectionBlock>(binaryWriter,
                    platformSoundEffectCollectionBlock, nextAddress);
                return nextAddress;
            }
        }
    };
}