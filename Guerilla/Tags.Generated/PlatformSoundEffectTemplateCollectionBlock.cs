// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class PlatformSoundEffectTemplateCollectionBlock : PlatformSoundEffectTemplateCollectionBlockBase
    {
        public  PlatformSoundEffectTemplateCollectionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  PlatformSoundEffectTemplateCollectionBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class PlatformSoundEffectTemplateCollectionBlockBase : GuerillaBlock
    {
        internal PlatformSoundEffectTemplateBlock[] platformEffectTemplates;
        internal Moonfish.Tags.StringID inputDspEffectName;
        
        public override int SerializedSize{get { return 12; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  PlatformSoundEffectTemplateCollectionBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            platformEffectTemplates = Guerilla.ReadBlockArray<PlatformSoundEffectTemplateBlock>(binaryReader);
            inputDspEffectName = binaryReader.ReadStringID();
        }
        public  PlatformSoundEffectTemplateCollectionBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            platformEffectTemplates = Guerilla.ReadBlockArray<PlatformSoundEffectTemplateBlock>(binaryReader);
            inputDspEffectName = binaryReader.ReadStringID();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<PlatformSoundEffectTemplateBlock>(binaryWriter, platformEffectTemplates, nextAddress);
                binaryWriter.Write(inputDspEffectName);
                return nextAddress;
            }
        }
    };
}
