// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class DamageEffectPlayerResponseBlock : DamageEffectPlayerResponseBlockBase
    {
        public DamageEffectPlayerResponseBlock() : base()
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
        public override int SerializedSize { get { return 76; } }
        public override int Alignment { get { return 4; } }
        public DamageEffectPlayerResponseBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            responseType = (ResponseType)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            screenFlash = new ScreenFlashDefinitionStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(screenFlash.ReadFields(binaryReader)));
            vibration = new VibrationDefinitionStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(vibration.ReadFields(binaryReader)));
            soundEffect = new DamageEffectSoundEffectDefinitionBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(soundEffect.ReadFields(binaryReader)));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            screenFlash.ReadPointers(binaryReader, blamPointers);
            vibration.ReadPointers(binaryReader, blamPointers);
            soundEffect.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
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
