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
    public partial class OldMaterialEffectMaterialBlock : OldMaterialEffectMaterialBlockBase
    {
        public OldMaterialEffectMaterialBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 28, Alignment = 4)]
    public class OldMaterialEffectMaterialBlockBase : GuerillaBlock
    {
        [TagReference("effe")]
        internal Moonfish.Tags.TagReference effect;
        [TagReference("null")]
        internal Moonfish.Tags.TagReference sound;
        internal Moonfish.Tags.StringIdent materialName;
        internal byte[] invalidName_;
        internal SweetenerMode sweetenerMode;
        internal byte[] invalidName_0;
        public override int SerializedSize { get { return 28; } }
        public override int Alignment { get { return 4; } }
        public OldMaterialEffectMaterialBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            effect = binaryReader.ReadTagReference();
            sound = binaryReader.ReadTagReference();
            materialName = binaryReader.ReadStringID();
            invalidName_ = binaryReader.ReadBytes(4);
            sweetenerMode = (SweetenerMode)binaryReader.ReadByte();
            invalidName_0 = binaryReader.ReadBytes(3);
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
            invalidName_[1].ReadPointers(binaryReader, blamPointers);
            invalidName_[2].ReadPointers(binaryReader, blamPointers);
            invalidName_[3].ReadPointers(binaryReader, blamPointers);
            invalidName_0[0].ReadPointers(binaryReader, blamPointers);
            invalidName_0[1].ReadPointers(binaryReader, blamPointers);
            invalidName_0[2].ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(effect);
                binaryWriter.Write(sound);
                binaryWriter.Write(materialName);
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write((Byte)sweetenerMode);
                binaryWriter.Write(invalidName_0, 0, 3);
                return nextAddress;
            }
        }
        internal enum SweetenerMode : byte
        {
            SweetenerDefault = 0,
            SweetenerEnabled = 1,
            SweetenerDisabled = 2,
        };
    };
}
