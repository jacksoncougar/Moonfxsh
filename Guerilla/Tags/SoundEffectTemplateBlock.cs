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
        public static readonly TagClass FxClass = (TagClass)"<fx>";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("<fx>")]
    public  partial class SoundEffectTemplateBlock : SoundEffectTemplateBlockBase
    {
        public  SoundEffectTemplateBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 28, Alignment = 4)]
    public class SoundEffectTemplateBlockBase  : IGuerilla
    {
        internal SoundEffectTemplatesBlock[] templateCollection;
        internal Moonfish.Tags.StringID inputEffectName;
        internal SoundEffectTemplateAdditionalSoundInputBlock[] additionalSoundInputs;
        internal PlatformSoundEffectTemplateCollectionBlock[] platformSoundEffectTemplateCollectionBlock;
        internal  SoundEffectTemplateBlockBase(BinaryReader binaryReader)
        {
            templateCollection = Guerilla.ReadBlockArray<SoundEffectTemplatesBlock>(binaryReader);
            inputEffectName = binaryReader.ReadStringID();
            additionalSoundInputs = Guerilla.ReadBlockArray<SoundEffectTemplateAdditionalSoundInputBlock>(binaryReader);
            platformSoundEffectTemplateCollectionBlock = Guerilla.ReadBlockArray<PlatformSoundEffectTemplateCollectionBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                Guerilla.WriteBlockArray<SoundEffectTemplatesBlock>(binaryWriter, templateCollection, nextAddress);
                binaryWriter.Write(inputEffectName);
                Guerilla.WriteBlockArray<SoundEffectTemplateAdditionalSoundInputBlock>(binaryWriter, additionalSoundInputs, nextAddress);
                Guerilla.WriteBlockArray<PlatformSoundEffectTemplateCollectionBlock>(binaryWriter, platformSoundEffectTemplateCollectionBlock, nextAddress);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
