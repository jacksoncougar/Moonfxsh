// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class PlatformSoundEffectBlock : PlatformSoundEffectBlockBase
    {
        public  PlatformSoundEffectBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 28, Alignment = 4)]
    public class PlatformSoundEffectBlockBase  : IGuerilla
    {
        internal PlatformSoundEffectFunctionBlock[] functionInputs;
        internal PlatformSoundEffectConstantBlock[] constantInputs;
        internal PlatformSoundEffectOverrideDescriptorBlock[] templateOverrideDescriptors;
        internal int inputOverrides;
        internal  PlatformSoundEffectBlockBase(BinaryReader binaryReader)
        {
            functionInputs = Guerilla.ReadBlockArray<PlatformSoundEffectFunctionBlock>(binaryReader);
            constantInputs = Guerilla.ReadBlockArray<PlatformSoundEffectConstantBlock>(binaryReader);
            templateOverrideDescriptors = Guerilla.ReadBlockArray<PlatformSoundEffectOverrideDescriptorBlock>(binaryReader);
            inputOverrides = binaryReader.ReadInt32();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                Guerilla.WriteBlockArray<PlatformSoundEffectFunctionBlock>(binaryWriter, functionInputs, nextAddress);
                Guerilla.WriteBlockArray<PlatformSoundEffectConstantBlock>(binaryWriter, constantInputs, nextAddress);
                Guerilla.WriteBlockArray<PlatformSoundEffectOverrideDescriptorBlock>(binaryWriter, templateOverrideDescriptors, nextAddress);
                binaryWriter.Write(inputOverrides);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
