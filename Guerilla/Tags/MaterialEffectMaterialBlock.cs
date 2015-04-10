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
    [LayoutAttribute(Size = 24)]
    public class MaterialEffectMaterialBlockBase
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
            this.tagEffectOrSound = binaryReader.ReadTagReference();
            this.secondaryTagEffectOrSound = binaryReader.ReadTagReference();
            this.materialName = binaryReader.ReadStringID();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.sweetenerMode = (SweetenerMode)binaryReader.ReadByte();
            this.invalidName_0 = binaryReader.ReadBytes(1);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
        }
        internal enum SweetenerMode : byte
        
        {
            SweetenerDefault = 0,
            SweetenerEnabled = 1,
            SweetenerDisabled = 2,
        };
    };
}
