using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GrenadeAndPowerupStructBlock : GrenadeAndPowerupStructBlockBase
    {
        public  GrenadeAndPowerupStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class GrenadeAndPowerupStructBlockBase
    {
        internal GrenadeBlock[] grenades;
        internal PowerupBlock[] powerups;
        internal  GrenadeAndPowerupStructBlockBase(BinaryReader binaryReader)
        {
            this.grenades = ReadGrenadeBlockArray(binaryReader);
            this.powerups = ReadPowerupBlockArray(binaryReader);
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
        internal  virtual GrenadeBlock[] ReadGrenadeBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GrenadeBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GrenadeBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GrenadeBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PowerupBlock[] ReadPowerupBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PowerupBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PowerupBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PowerupBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
