// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class PlatformSoundEffectTemplateCollectionBlock : PlatformSoundEffectTemplateCollectionBlockBase
    {
        public  PlatformSoundEffectTemplateCollectionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class PlatformSoundEffectTemplateCollectionBlockBase  : IGuerilla
    {
        internal PlatformSoundEffectTemplateBlock[] platformEffectTemplates;
        internal Moonfish.Tags.StringID inputDspEffectName;
        internal  PlatformSoundEffectTemplateCollectionBlockBase(BinaryReader binaryReader)
        {
            platformEffectTemplates = Guerilla.ReadBlockArray<PlatformSoundEffectTemplateBlock>(binaryReader);
            inputDspEffectName = binaryReader.ReadStringID();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                Guerilla.WriteBlockArray<PlatformSoundEffectTemplateBlock>(binaryWriter, platformEffectTemplates, nextAddress);
                binaryWriter.Write(inputDspEffectName);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
