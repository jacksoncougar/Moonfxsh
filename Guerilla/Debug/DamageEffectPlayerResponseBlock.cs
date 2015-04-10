// ReSharper disable All
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
        public  DamageEffectPlayerResponseBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  DamageEffectPlayerResponseBlockBase(System.IO.BinaryReader binaryReader)
        {
            responseType = (ResponseType)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            screenFlash = new ScreenFlashDefinitionStructBlock(binaryReader);
            vibration = new VibrationDefinitionStructBlock(binaryReader);
            soundEffect = new DamageEffectSoundEffectDefinitionBlock(binaryReader);
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)responseType);
                binaryWriter.Write(invalidName_, 0, 2);
                screenFlash.Write(binaryWriter);
                vibration.Write(binaryWriter);
                soundEffect.Write(binaryWriter);
            }
        }
        internal enum ResponseType : short
        
        {
            Shielded = 0,
            Unshielded = 1,
            All = 2,
        };
    };
}
