// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class PlatformSoundEffectCollectionBlock : PlatformSoundEffectCollectionBlockBase
    {
        public  PlatformSoundEffectCollectionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  PlatformSoundEffectCollectionBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class PlatformSoundEffectCollectionBlockBase : GuerillaBlock
    {
        internal PlatformSoundEffectBlock[] soundEffects;
        internal PlatformSoundEffectFunctionBlock[] lowFrequencyInput;
        internal int soundEffectOverrides;
        
        public override int SerializedSize{get { return 20; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  PlatformSoundEffectCollectionBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            soundEffects = Guerilla.ReadBlockArray<PlatformSoundEffectBlock>(binaryReader);
            lowFrequencyInput = Guerilla.ReadBlockArray<PlatformSoundEffectFunctionBlock>(binaryReader);
            soundEffectOverrides = binaryReader.ReadInt32();
        }
        public  PlatformSoundEffectCollectionBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            soundEffects = Guerilla.ReadBlockArray<PlatformSoundEffectBlock>(binaryReader);
            lowFrequencyInput = Guerilla.ReadBlockArray<PlatformSoundEffectFunctionBlock>(binaryReader);
            soundEffectOverrides = binaryReader.ReadInt32();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<PlatformSoundEffectBlock>(binaryWriter, soundEffects, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<PlatformSoundEffectFunctionBlock>(binaryWriter, lowFrequencyInput, nextAddress);
                binaryWriter.Write(soundEffectOverrides);
                return nextAddress;
            }
        }
    };
}
