// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class DeviceGroupBlock : DeviceGroupBlockBase
    {
        public  DeviceGroupBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  DeviceGroupBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 40, Alignment = 4)]
    public class DeviceGroupBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.String32 name;
        internal float initialValue01;
        internal Flags flags;
        
        public override int SerializedSize{get { return 40; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  DeviceGroupBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            name = binaryReader.ReadString32();
            initialValue01 = binaryReader.ReadSingle();
            flags = (Flags)binaryReader.ReadInt32();
        }
        public  DeviceGroupBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            name = binaryReader.ReadString32();
            initialValue01 = binaryReader.ReadSingle();
            flags = (Flags)binaryReader.ReadInt32();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write(initialValue01);
                binaryWriter.Write((Int32)flags);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        {
            CanChangeOnlyOnce = 1,
        };
    };
}
