using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class DamageDirectionBlock : DamageDirectionBlockBase
    {
        public  DamageDirectionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8)]
    public class DamageDirectionBlockBase
    {
        internal DamageRegionBlock[] regionsAABBCC;
        internal  DamageDirectionBlockBase(BinaryReader binaryReader)
        {
            this.regionsAABBCC = ReadDamageRegionBlockArray(binaryReader);
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
        internal  virtual DamageRegionBlock[] ReadDamageRegionBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(DamageRegionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new DamageRegionBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new DamageRegionBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
