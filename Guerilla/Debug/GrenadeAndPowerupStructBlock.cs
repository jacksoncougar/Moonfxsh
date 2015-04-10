// ReSharper disable All
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
        public  GrenadeAndPowerupStructBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class GrenadeAndPowerupStructBlockBase
    {
        internal GrenadeBlock[] grenades;
        internal PowerupBlock[] powerups;
        internal  GrenadeAndPowerupStructBlockBase(System.IO.BinaryReader binaryReader)
        {
            ReadGrenadeBlockArray(binaryReader);
            ReadPowerupBlockArray(binaryReader);
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
        internal  virtual GrenadeBlock[] ReadGrenadeBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual PowerupBlock[] ReadPowerupBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGrenadeBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WritePowerupBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                WriteGrenadeBlockArray(binaryWriter);
                WritePowerupBlockArray(binaryWriter);
            }
        }
    };
}
