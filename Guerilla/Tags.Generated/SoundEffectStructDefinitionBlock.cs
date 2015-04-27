// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class SoundEffectStructDefinitionBlock : SoundEffectStructDefinitionBlockBase
    {
        public  SoundEffectStructDefinitionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  SoundEffectStructDefinitionBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 40, Alignment = 4)]
    public class SoundEffectStructDefinitionBlockBase : GuerillaBlock
    {
        [TagReference("<fx>")]
        internal Moonfish.Tags.TagReference invalidName_;
        internal SoundEffectComponentBlock[] components;
        internal SoundEffectOverridesBlock[] soundEffectOverridesBlock;
        internal byte[] invalidName_0;
        internal PlatformSoundEffectCollectionBlock[] platformSoundEffectCollectionBlock;
        
        public override int SerializedSize{get { return 40; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  SoundEffectStructDefinitionBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            invalidName_ = binaryReader.ReadTagReference();
            components = Guerilla.ReadBlockArray<SoundEffectComponentBlock>(binaryReader);
            soundEffectOverridesBlock = Guerilla.ReadBlockArray<SoundEffectOverridesBlock>(binaryReader);
            invalidName_0 = Guerilla.ReadData(binaryReader);
            platformSoundEffectCollectionBlock = Guerilla.ReadBlockArray<PlatformSoundEffectCollectionBlock>(binaryReader);
        }
        public  SoundEffectStructDefinitionBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            invalidName_ = binaryReader.ReadTagReference();
            components = Guerilla.ReadBlockArray<SoundEffectComponentBlock>(binaryReader);
            soundEffectOverridesBlock = Guerilla.ReadBlockArray<SoundEffectOverridesBlock>(binaryReader);
            invalidName_0 = Guerilla.ReadData(binaryReader);
            platformSoundEffectCollectionBlock = Guerilla.ReadBlockArray<PlatformSoundEffectCollectionBlock>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_);
                nextAddress = Guerilla.WriteBlockArray<SoundEffectComponentBlock>(binaryWriter, components, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<SoundEffectOverridesBlock>(binaryWriter, soundEffectOverridesBlock, nextAddress);
                nextAddress = Guerilla.WriteData(binaryWriter, invalidName_0, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<PlatformSoundEffectCollectionBlock>(binaryWriter, platformSoundEffectCollectionBlock, nextAddress);
                return nextAddress;
            }
        }
    };
}
