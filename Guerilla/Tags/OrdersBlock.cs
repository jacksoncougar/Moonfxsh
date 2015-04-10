using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class OrdersBlock : OrdersBlockBase
    {
        public  OrdersBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 124)]
    public class OrdersBlockBase
    {
        internal Moonfish.Tags.String32 name;
        internal Moonfish.Tags.ShortBlockIndex1 style;
        internal byte[] invalidName_;
        internal Flags flags;
        internal ForceCombatStatus forceCombatStatus;
        internal byte[] invalidName_0;
        internal Moonfish.Tags.String32 entryScript;
        internal byte[] invalidName_1;
        internal Moonfish.Tags.ShortBlockIndex1 followSquad;
        internal float followRadius;
        internal ZoneSetBlock[] primaryAreaSet;
        internal SecondaryZoneSetBlock[] secondaryAreaSet;
        internal SecondarySetTriggerBlock[] secondarySetTrigger;
        internal SpecialMovementBlock[] specialMovement;
        internal OrderEndingBlock[] orderEndings;
        internal  OrdersBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadString32();
            this.style = binaryReader.ReadShortBlockIndex1();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.flags = (Flags)binaryReader.ReadInt32();
            this.forceCombatStatus = (ForceCombatStatus)binaryReader.ReadInt16();
            this.invalidName_0 = binaryReader.ReadBytes(2);
            this.entryScript = binaryReader.ReadString32();
            this.invalidName_1 = binaryReader.ReadBytes(2);
            this.followSquad = binaryReader.ReadShortBlockIndex1();
            this.followRadius = binaryReader.ReadSingle();
            this.primaryAreaSet = ReadZoneSetBlockArray(binaryReader);
            this.secondaryAreaSet = ReadSecondaryZoneSetBlockArray(binaryReader);
            this.secondarySetTrigger = ReadSecondarySetTriggerBlockArray(binaryReader);
            this.specialMovement = ReadSpecialMovementBlockArray(binaryReader);
            this.orderEndings = ReadOrderEndingBlockArray(binaryReader);
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
        internal  virtual ZoneSetBlock[] ReadZoneSetBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ZoneSetBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ZoneSetBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ZoneSetBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SecondaryZoneSetBlock[] ReadSecondaryZoneSetBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SecondaryZoneSetBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SecondaryZoneSetBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SecondaryZoneSetBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SecondarySetTriggerBlock[] ReadSecondarySetTriggerBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SecondarySetTriggerBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SecondarySetTriggerBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SecondarySetTriggerBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SpecialMovementBlock[] ReadSpecialMovementBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SpecialMovementBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SpecialMovementBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SpecialMovementBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual OrderEndingBlock[] ReadOrderEndingBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(OrderEndingBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new OrderEndingBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new OrderEndingBlock(binaryReader);
                }
            }
            return array;
        }
        [FlagsAttribute]
        internal enum Flags : int
        
        {
            Locked = 1,
            AlwaysActive = 2,
            DebugOn = 4,
            StrictAreaDef = 8,
            FollowClosestPlayer = 16,
            FollowSquad = 32,
            ActiveCamo = 64,
            SuppressCombatUntilEngaged = 128,
            InhibitVehicleUse = 256,
        };
        internal enum ForceCombatStatus : short
        
        {
            NONE = 0,
            Asleep = 1,
            Idle = 2,
            Alert = 3,
            Combat = 4,
        };
    };
}
