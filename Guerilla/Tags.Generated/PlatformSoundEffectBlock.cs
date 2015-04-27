// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class PlatformSoundEffectBlock : PlatformSoundEffectBlockBase
    {
        public  PlatformSoundEffectBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  PlatformSoundEffectBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 28, Alignment = 4)]
    public class PlatformSoundEffectBlockBase : GuerillaBlock
    {
        internal PlatformSoundEffectFunctionBlock[] functionInputs;
        internal PlatformSoundEffectConstantBlock[] constantInputs;
        internal PlatformSoundEffectOverrideDescriptorBlock[] templateOverrideDescriptors;
        internal int inputOverrides;
        
        public override int SerializedSize{get { return 28; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  PlatformSoundEffectBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            functionInputs = Guerilla.ReadBlockArray<PlatformSoundEffectFunctionBlock>(binaryReader);
            constantInputs = Guerilla.ReadBlockArray<PlatformSoundEffectConstantBlock>(binaryReader);
            templateOverrideDescriptors = Guerilla.ReadBlockArray<PlatformSoundEffectOverrideDescriptorBlock>(binaryReader);
            inputOverrides = binaryReader.ReadInt32();
        }
        public  PlatformSoundEffectBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            functionInputs = Guerilla.ReadBlockArray<PlatformSoundEffectFunctionBlock>(binaryReader);
            constantInputs = Guerilla.ReadBlockArray<PlatformSoundEffectConstantBlock>(binaryReader);
            templateOverrideDescriptors = Guerilla.ReadBlockArray<PlatformSoundEffectOverrideDescriptorBlock>(binaryReader);
            inputOverrides = binaryReader.ReadInt32();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<PlatformSoundEffectFunctionBlock>(binaryWriter, functionInputs, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<PlatformSoundEffectConstantBlock>(binaryWriter, constantInputs, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<PlatformSoundEffectOverrideDescriptorBlock>(binaryWriter, templateOverrideDescriptors, nextAddress);
                binaryWriter.Write(inputOverrides);
                return nextAddress;
            }
        }
    };
}
