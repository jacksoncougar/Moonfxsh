using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class OldMaterialEffectMaterialBlock : OldMaterialEffectMaterialBlockBase
    {
        public  OldMaterialEffectMaterialBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 28)]
    public class OldMaterialEffectMaterialBlockBase
    {
        [TagReference("effe")]
        internal Moonfish.Tags.TagReference effect;
        [TagReference("null")]
        internal Moonfish.Tags.TagReference sound;
        internal Moonfish.Tags.StringID materialName;
        internal byte[] invalidName_;
        internal SweetenerMode sweetenerMode;
        internal byte[] invalidName_0;
        internal  OldMaterialEffectMaterialBlockBase(BinaryReader binaryReader)
        {
            this.effect = binaryReader.ReadTagReference();
            this.sound = binaryReader.ReadTagReference();
            this.materialName = binaryReader.ReadStringID();
            this.invalidName_ = binaryReader.ReadBytes(4);
            this.sweetenerMode = (SweetenerMode)binaryReader.ReadByte();
            this.invalidName_0 = binaryReader.ReadBytes(3);
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
        internal enum SweetenerMode : byte
        
        {
            SweetenerDefault = 0,
            SweetenerEnabled = 1,
            SweetenerDisabled = 2,
        };
    };
}
