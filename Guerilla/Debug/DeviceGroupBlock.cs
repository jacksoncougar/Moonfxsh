// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class DeviceGroupBlock : DeviceGroupBlockBase
    {
        public  DeviceGroupBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 40)]
    public class DeviceGroupBlockBase
    {
        internal Moonfish.Tags.String32 name;
        internal float initialValue01;
        internal Flags flags;
        internal  DeviceGroupBlockBase(System.IO.BinaryReader binaryReader)
        {
            name = binaryReader.ReadString32();
            initialValue01 = binaryReader.ReadSingle();
            flags = (Flags)binaryReader.ReadInt32();
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
                binaryWriter.Write(name);
                binaryWriter.Write(initialValue01);
                binaryWriter.Write((Int32)flags);
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        
        {
            CanChangeOnlyOnce = 1,
        };
    };
}
