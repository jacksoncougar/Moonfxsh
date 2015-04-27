// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class PlatformSoundEffectOverrideDescriptorBlock : PlatformSoundEffectOverrideDescriptorBlockBase
    {
        public  PlatformSoundEffectOverrideDescriptorBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  PlatformSoundEffectOverrideDescriptorBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 1, Alignment = 4)]
    public class PlatformSoundEffectOverrideDescriptorBlockBase : GuerillaBlock
    {
        internal byte overrideDescriptor;
        
        public override int SerializedSize{get { return 1; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  PlatformSoundEffectOverrideDescriptorBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            overrideDescriptor = binaryReader.ReadByte();
        }
        public  PlatformSoundEffectOverrideDescriptorBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(overrideDescriptor);
                return nextAddress;
            }
        }
    };
}
