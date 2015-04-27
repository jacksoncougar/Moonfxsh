// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Ctrl = (TagClass)"ctrl";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("ctrl")]
    public partial class DeviceControlBlock : DeviceControlBlockBase
    {
        public  DeviceControlBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  DeviceControlBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 36, Alignment = 4)]
    public class DeviceControlBlockBase : GuerillaBlock
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
        
        public override int SerializedSize{get { return 36; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  DeviceControlBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            type = (Type)binaryReader.ReadInt16();
            triggersWhen = (TriggersWhen)binaryReader.ReadInt16();
            callValue01 = binaryReader.ReadSingle();
            actionString = binaryReader.ReadStringID();
            on = binaryReader.ReadTagReference();
            off = binaryReader.ReadTagReference();
            deny = binaryReader.ReadTagReference();
        }
        public  DeviceControlBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            type = (Type)binaryReader.ReadInt16();
            triggersWhen = (TriggersWhen)binaryReader.ReadInt16();
            callValue01 = binaryReader.ReadSingle();
            actionString = binaryReader.ReadStringID();
            on = binaryReader.ReadTagReference();
            off = binaryReader.ReadTagReference();
            deny = binaryReader.ReadTagReference();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)type);
                binaryWriter.Write((Int16)triggersWhen);
                binaryWriter.Write(callValue01);
                binaryWriter.Write(actionString);
                binaryWriter.Write(on);
                binaryWriter.Write(off);
                binaryWriter.Write(deny);
                return nextAddress;
            }
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
