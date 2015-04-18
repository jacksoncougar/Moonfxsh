// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SoundPlatformSoundPlaybackBlock : SoundPlatformSoundPlaybackBlockBase
    {
        public  SoundPlatformSoundPlaybackBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 60, Alignment = 4)]
    public class SoundPlatformSoundPlaybackBlockBase  : IGuerilla
    {
        internal SimplePlatformSoundPlaybackStructBlock playbackDefinition;
        internal GNullBlock[] gNullBlock;
        internal  SoundPlatformSoundPlaybackBlockBase(BinaryReader binaryReader)
        {
            playbackDefinition = new SimplePlatformSoundPlaybackStructBlock(binaryReader);
            gNullBlock = Guerilla.ReadBlockArray<GNullBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                playbackDefinition.Write(binaryWriter);
                nextAddress = Guerilla.WriteBlockArray<GNullBlock>(binaryWriter, gNullBlock, nextAddress);
                return nextAddress;
            }
        }
    };
}
