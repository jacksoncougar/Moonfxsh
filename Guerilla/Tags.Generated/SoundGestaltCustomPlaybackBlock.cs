// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class SoundGestaltCustomPlaybackBlock : SoundGestaltCustomPlaybackBlockBase
    {
        public  SoundGestaltCustomPlaybackBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  SoundGestaltCustomPlaybackBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 52, Alignment = 4)]
    public class SoundGestaltCustomPlaybackBlockBase : GuerillaBlock
    {
        internal SimplePlatformSoundPlaybackStructBlock playbackDefinition;
        
        public override int SerializedSize{get { return 52; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  SoundGestaltCustomPlaybackBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            playbackDefinition = new SimplePlatformSoundPlaybackStructBlock(binaryReader);
        }
        public  SoundGestaltCustomPlaybackBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            playbackDefinition = new SimplePlatformSoundPlaybackStructBlock(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                playbackDefinition.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
