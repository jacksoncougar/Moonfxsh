// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class PlatformSoundEffectCollectionBlock : PlatformSoundEffectCollectionBlockBase
    {
        public  PlatformSoundEffectCollectionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class PlatformSoundEffectCollectionBlockBase  : IGuerilla
    {
        internal PlatformSoundEffectBlock[] soundEffects;
        internal PlatformSoundEffectFunctionBlock[] lowFrequencyInput;
        internal int soundEffectOverrides;
        internal  PlatformSoundEffectCollectionBlockBase(BinaryReader binaryReader)
        {
            soundEffects = Guerilla.ReadBlockArray<PlatformSoundEffectBlock>(binaryReader);
            lowFrequencyInput = Guerilla.ReadBlockArray<PlatformSoundEffectFunctionBlock>(binaryReader);
            soundEffectOverrides = binaryReader.ReadInt32();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                Guerilla.WriteBlockArray<PlatformSoundEffectBlock>(binaryWriter, soundEffects, nextAddress);
                Guerilla.WriteBlockArray<PlatformSoundEffectFunctionBlock>(binaryWriter, lowFrequencyInput, nextAddress);
                binaryWriter.Write(soundEffectOverrides);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
