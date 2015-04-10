using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("ctrl")]
    public  partial class DeviceControlBlock : DeviceControlBlockBase
    {
        public  DeviceControlBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 36)]
    public class DeviceControlBlockBase : DeviceBlock
    {
        internal Type type;
        internal TriggersWhen triggersWhen;
        internal float callValue01;
        internal Moonfish.Tags.StringID actionString;
        [TagReference("null")]
        internal Moonfish.Tags.TagReference on;
        [TagReference("null")]
        internal Moonfish.Tags.TagReference off;
        [TagReference("null")]
        internal Moonfish.Tags.TagReference deny;
        internal  DeviceControlBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            this.type = (Type)binaryReader.ReadInt16();
            this.triggersWhen = (TriggersWhen)binaryReader.ReadInt16();
            this.callValue01 = binaryReader.ReadSingle();
            this.actionString = binaryReader.ReadStringID();
            this.on = binaryReader.ReadTagReference();
            this.off = binaryReader.ReadTagReference();
            this.deny = binaryReader.ReadTagReference();
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
        internal enum Type : short
        
        {
            ToggleSwitch = 0,
            OnButton = 1,
            OffButton = 2,
            CallButton = 3,
        };
        internal enum TriggersWhen : short
        
        {
            TouchedByPlayer = 0,
            Destroyed = 1,
        };
    };
}
