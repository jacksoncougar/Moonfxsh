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
    public partial class PlatformSoundPlaybackStructBlock : PlatformSoundPlaybackStructBlockBase
    {
        public PlatformSoundPlaybackStructBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 52, Alignment = 4)]
    public class PlatformSoundPlaybackStructBlockBase : GuerillaBlock
    {
        internal PlatformSoundOverrideMixbinsBlock[] platformSoundOverrideMixbinsBlock;
        internal Flags flags;
        internal byte[] invalidName_;
        internal PlatformSoundFilterBlock[] filter;
        internal PlatformSoundPitchLfoBlock[] pitchLfo;
        internal PlatformSoundFilterLfoBlock[] filterLfo;
        internal SoundEffectPlaybackBlock[] soundEffect;

        public override int SerializedSize
        {
            get { return 52; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public PlatformSoundPlaybackStructBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<PlatformSoundOverrideMixbinsBlock>(binaryReader));
            flags = (Flags) binaryReader.ReadInt32();
            invalidName_ = binaryReader.ReadBytes(8);
            blamPointers.Enqueue(ReadBlockArrayPointer<PlatformSoundFilterBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<PlatformSoundPitchLfoBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<PlatformSoundFilterLfoBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<SoundEffectPlaybackBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            platformSoundOverrideMixbinsBlock = ReadBlockArrayData<PlatformSoundOverrideMixbinsBlock>(binaryReader,
                blamPointers.Dequeue());
            filter = ReadBlockArrayData<PlatformSoundFilterBlock>(binaryReader, blamPointers.Dequeue());
            pitchLfo = ReadBlockArrayData<PlatformSoundPitchLfoBlock>(binaryReader, blamPointers.Dequeue());
            filterLfo = ReadBlockArrayData<PlatformSoundFilterLfoBlock>(binaryReader, blamPointers.Dequeue());
            soundEffect = ReadBlockArrayData<SoundEffectPlaybackBlock>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<PlatformSoundOverrideMixbinsBlock>(binaryWriter,
                    platformSoundOverrideMixbinsBlock, nextAddress);
                binaryWriter.Write((Int32) flags);
                binaryWriter.Write(invalidName_, 0, 8);
                nextAddress = Guerilla.WriteBlockArray<PlatformSoundFilterBlock>(binaryWriter, filter, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<PlatformSoundPitchLfoBlock>(binaryWriter, pitchLfo, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<PlatformSoundFilterLfoBlock>(binaryWriter, filterLfo, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<SoundEffectPlaybackBlock>(binaryWriter, soundEffect, nextAddress);
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum Flags : int
        {
            Use3DRadioHack = 1,
        };
    };
}