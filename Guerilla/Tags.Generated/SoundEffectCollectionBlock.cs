// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Sfx = (TagClass)"sfx+";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("sfx+")]
    public partial class SoundEffectCollectionBlock : SoundEffectCollectionBlockBase
    {
        public  SoundEffectCollectionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  SoundEffectCollectionBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class SoundEffectCollectionBlockBase : GuerillaBlock
    {
        internal PlatformSoundPlaybackBlock[] soundEffects;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  SoundEffectCollectionBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            soundEffects = Guerilla.ReadBlockArray<PlatformSoundPlaybackBlock>(binaryReader);
        }
        public  SoundEffectCollectionBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            soundEffects = Guerilla.ReadBlockArray<PlatformSoundPlaybackBlock>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<PlatformSoundPlaybackBlock>(binaryWriter, soundEffects, nextAddress);
                return nextAddress;
            }
        }
    };
}
