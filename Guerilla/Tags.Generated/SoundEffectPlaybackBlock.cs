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
    public partial class SoundEffectPlaybackBlock : SoundEffectPlaybackBlockBase
    {
        public SoundEffectPlaybackBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 40, Alignment = 4)]
    public class SoundEffectPlaybackBlockBase : GuerillaBlock
    {
        internal SoundEffectStructDefinitionBlock soundEffectStruct;

        public override int SerializedSize
        {
            get { return 40; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public SoundEffectPlaybackBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            soundEffectStruct = new SoundEffectStructDefinitionBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(soundEffectStruct.ReadFields(binaryReader)));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            soundEffectStruct.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                soundEffectStruct.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}