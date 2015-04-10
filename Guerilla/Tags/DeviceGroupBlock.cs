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
        public  DeviceGroupBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 40)]
    public class DeviceGroupBlockBase
    {
        internal Moonfish.Tags.String32 name;
        internal float initialValue01;
        internal Flags flags;
        internal  DeviceGroupBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadString32();
            this.initialValue01 = binaryReader.ReadSingle();
            this.flags = (Flags)binaryReader.ReadInt32();
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
        [FlagsAttribute]
        internal enum Flags : int
        
        {
            CanChangeOnlyOnce = 1,
        };
    };
}
