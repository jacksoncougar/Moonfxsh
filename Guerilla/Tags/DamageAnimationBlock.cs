using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class DamageAnimationBlock : DamageAnimationBlockBase
    {
        public  DamageAnimationBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12)]
    public class DamageAnimationBlockBase
    {
        internal Moonfish.Tags.StringID label;
        internal DamageDirectionBlock[] directionsAABBCC;
        internal  DamageAnimationBlockBase(BinaryReader binaryReader)
        {
            this.label = binaryReader.ReadStringID();
            this.directionsAABBCC = ReadDamageDirectionBlockArray(binaryReader);
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
        internal  virtual DamageDirectionBlock[] ReadDamageDirectionBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(DamageDirectionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new DamageDirectionBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new DamageDirectionBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
