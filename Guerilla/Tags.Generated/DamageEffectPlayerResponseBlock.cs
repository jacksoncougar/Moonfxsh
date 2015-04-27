// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class DamageEffectPlayerResponseBlock : DamageEffectPlayerResponseBlockBase
    {
        public  DamageEffectPlayerResponseBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  DamageEffectPlayerResponseBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 76, Alignment = 4)]
    public class DamageEffectPlayerResponseBlockBase : GuerillaBlock
    {
        internal ResponseType responseType;
        internal byte[] invalidName_;
        internal ScreenFlashDefinitionStructBlock screenFlash;
        internal VibrationDefinitionStructBlock vibration;
        internal DamageEffectSoundEffectDefinitionBlock soundEffect;
        
        public override int SerializedSize{get { return 76; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  DamageEffectPlayerResponseBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            responseType = (ResponseType)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            screenFlash = new ScreenFlashDefinitionStructBlock(binaryReader);
            vibration = new VibrationDefinitionStructBlock(binaryReader);
            soundEffect = new DamageEffectSoundEffectDefinitionBlock(binaryReader);
        }
        public  DamageEffectPlayerResponseBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            responseType = (ResponseType)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            screenFlash = new ScreenFlashDefinitionStructBlock(binaryReader);
            vibration = new VibrationDefinitionStructBlock(binaryReader);
            soundEffect = new DamageEffectSoundEffectDefinitionBlock(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)responseType);
                binaryWriter.Write(invalidName_, 0, 2);
                screenFlash.Write(binaryWriter);
                vibration.Write(binaryWriter);
                soundEffect.Write(binaryWriter);
                return nextAddress;
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
