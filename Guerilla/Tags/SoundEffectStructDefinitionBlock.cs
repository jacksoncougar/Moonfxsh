// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SoundEffectStructDefinitionBlock : SoundEffectStructDefinitionBlockBase
    {
        public  SoundEffectStructDefinitionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 40, Alignment = 4)]
    public class SoundEffectStructDefinitionBlockBase  : IGuerilla
    {
        [TagReference("<fx>")]
        internal Moonfish.Tags.TagReference invalidName_;
        internal SoundEffectComponentBlock[] components;
        internal SoundEffectOverridesBlock[] soundEffectOverridesBlock;
        internal byte[] invalidName_0;
        internal PlatformSoundEffectCollectionBlock[] platformSoundEffectCollectionBlock;
        internal  SoundEffectStructDefinitionBlockBase(BinaryReader binaryReader)
        {
            invalidName_ = binaryReader.ReadTagReference();
            components = Guerilla.ReadBlockArray<SoundEffectComponentBlock>(binaryReader);
            soundEffectOverridesBlock = Guerilla.ReadBlockArray<SoundEffectOverridesBlock>(binaryReader);
            invalidName_0 = Guerilla.ReadData(binaryReader);
            platformSoundEffectCollectionBlock = Guerilla.ReadBlockArray<PlatformSoundEffectCollectionBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_);
                nextAddress = Guerilla.WriteBlockArray<SoundEffectComponentBlock>(binaryWriter, components, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<SoundEffectOverridesBlock>(binaryWriter, soundEffectOverridesBlock, nextAddress);
                nextAddress = Guerilla.WriteData(binaryWriter, invalidName_0, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<PlatformSoundEffectCollectionBlock>(binaryWriter, platformSoundEffectCollectionBlock, nextAddress);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
