using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class MaterialEffectBlockV2 : MaterialEffectBlockV2Base
    {
        public  MaterialEffectBlockV2(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 24)]
    public class MaterialEffectBlockV2Base
    {
        internal OldMaterialEffectMaterialBlock[] oldMaterialsDONOTUSE;
        internal MaterialEffectMaterialBlock[] sounds;
        internal MaterialEffectMaterialBlock[] effects;
        internal  MaterialEffectBlockV2Base(BinaryReader binaryReader)
        {
            this.oldMaterialsDONOTUSE = ReadOldMaterialEffectMaterialBlockArray(binaryReader);
            this.sounds = ReadMaterialEffectMaterialBlockArray(binaryReader);
            this.effects = ReadMaterialEffectMaterialBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
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
        internal  virtual OldMaterialEffectMaterialBlock[] ReadOldMaterialEffectMaterialBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(OldMaterialEffectMaterialBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new OldMaterialEffectMaterialBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new OldMaterialEffectMaterialBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual MaterialEffectMaterialBlock[] ReadMaterialEffectMaterialBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(MaterialEffectMaterialBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new MaterialEffectMaterialBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new MaterialEffectMaterialBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
