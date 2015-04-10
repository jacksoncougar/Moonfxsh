// ReSharper disable All
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
        public  OldMaterialEffectMaterialBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  OldMaterialEffectMaterialBlockBase(System.IO.BinaryReader binaryReader)
        {
            effect = binaryReader.ReadTagReference();
            sound = binaryReader.ReadTagReference();
            materialName = binaryReader.ReadStringID();
            invalidName_ = binaryReader.ReadBytes(4);
            sweetenerMode = (SweetenerMode)binaryReader.ReadByte();
            invalidName_0 = binaryReader.ReadBytes(3);
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
                binaryWriter.Write(effect);
                binaryWriter.Write(sound);
                binaryWriter.Write(materialName);
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write((Byte)sweetenerMode);
                binaryWriter.Write(invalidName_0, 0, 3);
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
