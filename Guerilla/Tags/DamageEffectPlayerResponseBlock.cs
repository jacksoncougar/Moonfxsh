using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class DamageEffectPlayerResponseBlock : DamageEffectPlayerResponseBlockBase
    {
        public  DamageEffectPlayerResponseBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 76)]
    public class DamageEffectPlayerResponseBlockBase
    {
        internal ResponseType responseType;
        internal byte[] invalidName_;
        internal ScreenFlashDefinitionStructBlock screenFlash;
        internal VibrationDefinitionStructBlock vibration;
        internal DamageEffectSoundEffectDefinitionBlock soundEffect;
        internal  DamageEffectPlayerResponseBlockBase(BinaryReader binaryReader)
        {
            this.responseType = (ResponseType)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.screenFlash = new ScreenFlashDefinitionStructBlock(binaryReader);
            this.vibration = new VibrationDefinitionStructBlock(binaryReader);
            this.soundEffect = new DamageEffectSoundEffectDefinitionBlock(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
        }
        internal enum ResponseType : short
        
        {
            Shielded = 0,
            Unshielded = 1,
            All = 2,
        };
    };
}
