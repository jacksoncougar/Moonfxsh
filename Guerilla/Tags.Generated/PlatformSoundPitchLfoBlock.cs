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
    public partial class PlatformSoundPitchLfoBlock : PlatformSoundPitchLfoBlockBase
    {
        public PlatformSoundPitchLfoBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 48, Alignment = 4)]
    public class PlatformSoundPitchLfoBlockBase : GuerillaBlock
    {
        internal SoundPlaybackParameterDefinitionBlock delay;
        internal SoundPlaybackParameterDefinitionBlock frequency;
        internal SoundPlaybackParameterDefinitionBlock pitchModulation;
        public override int SerializedSize { get { return 48; } }
        public override int Alignment { get { return 4; } }
        public PlatformSoundPitchLfoBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            delay = new SoundPlaybackParameterDefinitionBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(delay.ReadFields(binaryReader)));
            frequency = new SoundPlaybackParameterDefinitionBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(frequency.ReadFields(binaryReader)));
            pitchModulation = new SoundPlaybackParameterDefinitionBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(pitchModulation.ReadFields(binaryReader)));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            delay.ReadPointers(binaryReader, blamPointers);
            frequency.ReadPointers(binaryReader, blamPointers);
            pitchModulation.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                delay.Write(binaryWriter);
                frequency.Write(binaryWriter);
                pitchModulation.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
