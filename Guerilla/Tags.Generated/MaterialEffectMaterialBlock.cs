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
    public partial class MaterialEffectMaterialBlock : MaterialEffectMaterialBlockBase
    {
        public MaterialEffectMaterialBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class MaterialEffectMaterialBlockBase : GuerillaBlock
    {
        [TagReference("null")] internal Moonfish.Tags.TagReference tagEffectOrSound;
        [TagReference("null")] internal Moonfish.Tags.TagReference secondaryTagEffectOrSound;
        internal Moonfish.Tags.StringIdent materialName;
        internal byte[] invalidName_;
        internal SweetenerMode sweetenerMode;
        internal byte[] invalidName_0;

        public override int SerializedSize
        {
            get { return 24; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public MaterialEffectMaterialBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            tagEffectOrSound = binaryReader.ReadTagReference();
            secondaryTagEffectOrSound = binaryReader.ReadTagReference();
            materialName = binaryReader.ReadStringID();
            invalidName_ = binaryReader.ReadBytes(2);
            sweetenerMode = (SweetenerMode) binaryReader.ReadByte();
            invalidName_0 = binaryReader.ReadBytes(1);
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(tagEffectOrSound);
                binaryWriter.Write(secondaryTagEffectOrSound);
                binaryWriter.Write(materialName);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write((Byte) sweetenerMode);
                binaryWriter.Write(invalidName_0, 0, 1);
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