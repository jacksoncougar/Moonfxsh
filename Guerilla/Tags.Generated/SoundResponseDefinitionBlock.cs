// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class SoundResponseDefinitionBlock : SoundResponseDefinitionBlockBase
    {
        public  SoundResponseDefinitionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  SoundResponseDefinitionBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 80, Alignment = 4)]
    public class SoundResponseDefinitionBlockBase : GuerillaBlock
    {
        internal SoundFlags soundFlags;
        internal byte[] invalidName_;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference englishSound;
        internal SoundResponseExtraSoundsStructBlock extraSounds;
        internal float probability;
        
        public override int SerializedSize{get { return 80; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  SoundResponseDefinitionBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            soundFlags = (SoundFlags)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            englishSound = binaryReader.ReadTagReference();
            extraSounds = new SoundResponseExtraSoundsStructBlock(binaryReader);
            probability = binaryReader.ReadSingle();
        }
        public  SoundResponseDefinitionBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            soundFlags = (SoundFlags)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            englishSound = binaryReader.ReadTagReference();
            extraSounds = new SoundResponseExtraSoundsStructBlock(binaryReader);
            probability = binaryReader.ReadSingle();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)soundFlags);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(englishSound);
                extraSounds.Write(binaryWriter);
                binaryWriter.Write(probability);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum SoundFlags : short
        {
            AnnouncerSound = 1,
        };
    };
}
