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
        public static readonly TagClass Fx = (TagClass)"<fx>";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("<fx>")]
    public partial class SoundEffectTemplateBlock : SoundEffectTemplateBlockBase
    {
        public  SoundEffectTemplateBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  SoundEffectTemplateBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 28, Alignment = 4)]
    public class SoundEffectTemplateBlockBase : GuerillaBlock
    {
        internal SoundEffectTemplatesBlock[] templateCollection;
        internal Moonfish.Tags.StringID inputEffectName;
        internal SoundEffectTemplateAdditionalSoundInputBlock[] additionalSoundInputs;
        internal PlatformSoundEffectTemplateCollectionBlock[] platformSoundEffectTemplateCollectionBlock;
        
        public override int SerializedSize{get { return 28; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  SoundEffectTemplateBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            templateCollection = Guerilla.ReadBlockArray<SoundEffectTemplatesBlock>(binaryReader);
            inputEffectName = binaryReader.ReadStringID();
            additionalSoundInputs = Guerilla.ReadBlockArray<SoundEffectTemplateAdditionalSoundInputBlock>(binaryReader);
            platformSoundEffectTemplateCollectionBlock = Guerilla.ReadBlockArray<PlatformSoundEffectTemplateCollectionBlock>(binaryReader);
        }
        public  SoundEffectTemplateBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<SoundEffectTemplatesBlock>(binaryWriter, templateCollection, nextAddress);
                binaryWriter.Write(inputEffectName);
                nextAddress = Guerilla.WriteBlockArray<SoundEffectTemplateAdditionalSoundInputBlock>(binaryWriter, additionalSoundInputs, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<PlatformSoundEffectTemplateCollectionBlock>(binaryWriter, platformSoundEffectTemplateCollectionBlock, nextAddress);
                return nextAddress;
            }
        }
    };
}
