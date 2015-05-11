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
    public partial class PlatformSoundFilterLfoBlock : PlatformSoundFilterLfoBlockBase
    {
        public PlatformSoundFilterLfoBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 64, Alignment = 4)]
    public class PlatformSoundFilterLfoBlockBase : GuerillaBlock
    {
        internal SoundPlaybackParameterDefinitionBlock delay;
        internal SoundPlaybackParameterDefinitionBlock frequency;
        internal SoundPlaybackParameterDefinitionBlock cutoffModulation;
        internal SoundPlaybackParameterDefinitionBlock gainModulation;

        public override int SerializedSize
        {
            get { return 64; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public PlatformSoundFilterLfoBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            delay = new SoundPlaybackParameterDefinitionBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(delay.ReadFields(binaryReader)));
            frequency = new SoundPlaybackParameterDefinitionBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(frequency.ReadFields(binaryReader)));
            cutoffModulation = new SoundPlaybackParameterDefinitionBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(cutoffModulation.ReadFields(binaryReader)));
            gainModulation = new SoundPlaybackParameterDefinitionBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(gainModulation.ReadFields(binaryReader)));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            delay.ReadPointers(binaryReader, blamPointers);
            frequency.ReadPointers(binaryReader, blamPointers);
            cutoffModulation.ReadPointers(binaryReader, blamPointers);
            gainModulation.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                delay.Write(binaryWriter);
                frequency.Write(binaryWriter);
                cutoffModulation.Write(binaryWriter);
                gainModulation.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}