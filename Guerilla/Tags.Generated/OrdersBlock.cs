// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class OrdersBlock : OrdersBlockBase
    {
        public  OrdersBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  OrdersBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 124, Alignment = 4)]
    public class OrdersBlockBase : GuerillaBlock
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
        
        public override int SerializedSize{get { return 124; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  OrdersBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            name = binaryReader.ReadString32();
            style = binaryReader.ReadShortBlockIndex1();
            invalidName_ = binaryReader.ReadBytes(2);
            flags = (Flags)binaryReader.ReadInt32();
            forceCombatStatus = (ForceCombatStatus)binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(2);
            entryScript = binaryReader.ReadString32();
            invalidName_1 = binaryReader.ReadBytes(2);
            followSquad = binaryReader.ReadShortBlockIndex1();
            followRadius = binaryReader.ReadSingle();
            primaryAreaSet = Guerilla.ReadBlockArray<ZoneSetBlock>(binaryReader);
            secondaryAreaSet = Guerilla.ReadBlockArray<SecondaryZoneSetBlock>(binaryReader);
            secondarySetTrigger = Guerilla.ReadBlockArray<SecondarySetTriggerBlock>(binaryReader);
            specialMovement = Guerilla.ReadBlockArray<SpecialMovementBlock>(binaryReader);
            orderEndings = Guerilla.ReadBlockArray<OrderEndingBlock>(binaryReader);
        }
        public  OrdersBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write(style);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write((Int16)forceCombatStatus);
                binaryWriter.Write(invalidName_0, 0, 2);
                binaryWriter.Write(entryScript);
                binaryWriter.Write(invalidName_1, 0, 2);
                binaryWriter.Write(followSquad);
                binaryWriter.Write(followRadius);
                nextAddress = Guerilla.WriteBlockArray<ZoneSetBlock>(binaryWriter, primaryAreaSet, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<SecondaryZoneSetBlock>(binaryWriter, secondaryAreaSet, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<SecondarySetTriggerBlock>(binaryWriter, secondarySetTrigger, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<SpecialMovementBlock>(binaryWriter, specialMovement, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<OrderEndingBlock>(binaryWriter, orderEndings, nextAddress);
                return nextAddress;
            }
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
