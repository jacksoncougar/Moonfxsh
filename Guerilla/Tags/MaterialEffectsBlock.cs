using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("foot")]
    public  partial class MaterialEffectsBlock : MaterialEffectsBlockBase
    {
        public  MaterialEffectsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8)]
    public class MaterialEffectsBlockBase
    {
        internal MaterialEffectBlockV2[] effects;
        internal  MaterialEffectsBlockBase(BinaryReader binaryReader)
        {
            this.effects = ReadMaterialEffectBlockV2Array(binaryReader);
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
        internal  virtual MaterialEffectBlockV2[] ReadMaterialEffectBlockV2Array(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(MaterialEffectBlockV2));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new MaterialEffectBlockV2[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new MaterialEffectBlockV2(binaryReader);
                }
            }
            return array;
        }
    };
}
