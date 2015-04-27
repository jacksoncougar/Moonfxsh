// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class PlatformSoundEffectTemplateBlock : PlatformSoundEffectTemplateBlockBase
    {
        public  PlatformSoundEffectTemplateBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  PlatformSoundEffectTemplateBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class PlatformSoundEffectTemplateBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringID inputDspEffectName;
        internal byte[] invalidName_;
        internal PlatformSoundEffectTemplateComponentBlock[] components;
        
        public override int SerializedSize{get { return 24; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  PlatformSoundEffectTemplateBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            inputDspEffectName = binaryReader.ReadStringID();
            invalidName_ = binaryReader.ReadBytes(12);
            components = Guerilla.ReadBlockArray<PlatformSoundEffectTemplateComponentBlock>(binaryReader);
        }
        public  PlatformSoundEffectTemplateBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            inputDspEffectName = binaryReader.ReadStringID();
            invalidName_ = binaryReader.ReadBytes(12);
            components = Guerilla.ReadBlockArray<PlatformSoundEffectTemplateComponentBlock>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(inputDspEffectName);
                binaryWriter.Write(invalidName_, 0, 12);
                nextAddress = Guerilla.WriteBlockArray<PlatformSoundEffectTemplateComponentBlock>(binaryWriter, components, nextAddress);
                return nextAddress;
            }
        }
    };
}
