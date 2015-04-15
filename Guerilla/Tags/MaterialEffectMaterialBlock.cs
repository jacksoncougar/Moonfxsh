// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class MaterialEffectMaterialBlock : MaterialEffectMaterialBlockBase
    {
        public  MaterialEffectMaterialBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class MaterialEffectMaterialBlockBase  : IGuerilla
    {
        [TagReference("null")]
        internal Moonfish.Tags.TagReference tagEffectOrSound;
        [TagReference("null")]
        internal Moonfish.Tags.TagReference secondaryTagEffectOrSound;
        internal Moonfish.Tags.StringID materialName;
        internal byte[] invalidName_;
        internal SweetenerMode sweetenerMode;
        internal byte[] invalidName_0;
        internal  MaterialEffectMaterialBlockBase(BinaryReader binaryReader)
        {
            tagEffectOrSound = binaryReader.ReadTagReference();
            secondaryTagEffectOrSound = binaryReader.ReadTagReference();
            materialName = binaryReader.ReadStringID();
            invalidName_ = binaryReader.ReadBytes(2);
            sweetenerMode = (SweetenerMode)binaryReader.ReadByte();
            invalidName_0 = binaryReader.ReadBytes(1);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(tagEffectOrSound);
                binaryWriter.Write(secondaryTagEffectOrSound);
                binaryWriter.Write(materialName);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write((Byte)sweetenerMode);
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
