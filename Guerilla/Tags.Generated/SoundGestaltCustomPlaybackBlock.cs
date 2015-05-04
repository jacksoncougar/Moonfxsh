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
    public partial class SoundGestaltCustomPlaybackBlock : SoundGestaltCustomPlaybackBlockBase
    {
        public SoundGestaltCustomPlaybackBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 52, Alignment = 4)]
    public class SoundGestaltCustomPlaybackBlockBase : GuerillaBlock
    {
        internal SimplePlatformSoundPlaybackStructBlock playbackDefinition;
        public override int SerializedSize { get { return 52; } }
        public override int Alignment { get { return 4; } }
        public SoundGestaltCustomPlaybackBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            playbackDefinition = new SimplePlatformSoundPlaybackStructBlock();
            blamPointers.Concat(playbackDefinition.ReadFields(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            playbackDefinition.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                playbackDefinition.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
