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
    public partial class SoundGestaltPlaybackBlock : SoundGestaltPlaybackBlockBase
    {
        public SoundGestaltPlaybackBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 56, Alignment = 4)]
    public class SoundGestaltPlaybackBlockBase : GuerillaBlock
    {
        internal SoundPlaybackParametersStructBlock soundPlaybackParametersStruct;
        public override int SerializedSize { get { return 56; } }
        public override int Alignment { get { return 4; } }
        public SoundGestaltPlaybackBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            soundPlaybackParametersStruct = new SoundPlaybackParametersStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(soundPlaybackParametersStruct.ReadFields(binaryReader)));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            soundPlaybackParametersStruct.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                soundPlaybackParametersStruct.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
