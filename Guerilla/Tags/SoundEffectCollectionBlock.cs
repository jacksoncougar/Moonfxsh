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
        public static readonly TagClass SfxClass = (TagClass)"sfx+";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("sfx+")]
    public  partial class SoundEffectCollectionBlock : SoundEffectCollectionBlockBase
    {
        public  SoundEffectCollectionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class SoundEffectCollectionBlockBase  : IGuerilla
    {
        internal PlatformSoundPlaybackBlock[] soundEffects;
        internal  SoundEffectCollectionBlockBase(BinaryReader binaryReader)
        {
            soundEffects = Guerilla.ReadBlockArray<PlatformSoundPlaybackBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<PlatformSoundPlaybackBlock>(binaryWriter, soundEffects, nextAddress);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
