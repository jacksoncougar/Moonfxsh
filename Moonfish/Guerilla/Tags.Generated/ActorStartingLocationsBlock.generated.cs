//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Moonfish.Guerilla.Tags
{
    using Moonfish.Tags;
    using Moonfish.Model;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    
    public partial class ActorStartingLocationsBlock : GuerillaBlock, IWriteQueueable
    {
        public Moonfish.Tags.StringIdent Name;
        public OpenTK.Vector3 Position;
        public short ReferenceFrame;
        private byte[] fieldpad = new byte[2];
        public OpenTK.Vector2 Facing;
        public Flags ActorStartingLocationsFlags;
        public Moonfish.Tags.ShortBlockIndex1 CharacterType;
        public Moonfish.Tags.ShortBlockIndex1 InitialWeapon;
        public Moonfish.Tags.ShortBlockIndex1 InitialSecondaryWeapon;
        private byte[] fieldpad0 = new byte[2];
        public Moonfish.Tags.ShortBlockIndex1 VehicleType;
        public SeatTypeEnum SeatType;
        public GrenadeTypeEnum GrenadeType;
        public short SwarmCount;
        public Moonfish.Tags.StringIdent ActorVariantName;
        public Moonfish.Tags.StringIdent VehicleVariantName;
        public float InitialMovementDistance;
        public Moonfish.Tags.ShortBlockIndex1 EmitterVehicle;
        public InitialMovementModeEnum InitialMovementMode;
        public Moonfish.Tags.String32 PlacementScript;
        private byte[] fieldskip = new byte[2];
        private byte[] fieldpad1 = new byte[2];
        public override int SerializedSize
        {
            get
            {
                return 100;
            }
        }
        public override int Alignment
        {
            get
            {
                return 4;
            }
        }
        public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(System.IO.BinaryReader binaryReader)
        {
            System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
            this.Name = binaryReader.ReadStringID();
            this.Position = binaryReader.ReadVector3();
            this.ReferenceFrame = binaryReader.ReadInt16();
            this.fieldpad = binaryReader.ReadBytes(2);
            this.Facing = binaryReader.ReadVector2();
            this.ActorStartingLocationsFlags = ((Flags)(binaryReader.ReadInt32()));
            this.CharacterType = binaryReader.ReadShortBlockIndex1();
            this.InitialWeapon = binaryReader.ReadShortBlockIndex1();
            this.InitialSecondaryWeapon = binaryReader.ReadShortBlockIndex1();
            this.fieldpad0 = binaryReader.ReadBytes(2);
            this.VehicleType = binaryReader.ReadShortBlockIndex1();
            this.SeatType = ((SeatTypeEnum)(binaryReader.ReadInt16()));
            this.GrenadeType = ((GrenadeTypeEnum)(binaryReader.ReadInt16()));
            this.SwarmCount = binaryReader.ReadInt16();
            this.ActorVariantName = binaryReader.ReadStringID();
            this.VehicleVariantName = binaryReader.ReadStringID();
            this.InitialMovementDistance = binaryReader.ReadSingle();
            this.EmitterVehicle = binaryReader.ReadShortBlockIndex1();
            this.InitialMovementMode = ((InitialMovementModeEnum)(binaryReader.ReadInt16()));
            this.PlacementScript = binaryReader.ReadString32();
            this.fieldskip = binaryReader.ReadBytes(2);
            this.fieldpad1 = binaryReader.ReadBytes(2);
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.Name);
            queueableBinaryWriter.Write(this.Position);
            queueableBinaryWriter.Write(this.ReferenceFrame);
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.Write(this.Facing);
            queueableBinaryWriter.Write(((int)(this.ActorStartingLocationsFlags)));
            queueableBinaryWriter.Write(this.CharacterType);
            queueableBinaryWriter.Write(this.InitialWeapon);
            queueableBinaryWriter.Write(this.InitialSecondaryWeapon);
            queueableBinaryWriter.Write(this.fieldpad0);
            queueableBinaryWriter.Write(this.VehicleType);
            queueableBinaryWriter.Write(((short)(this.SeatType)));
            queueableBinaryWriter.Write(((short)(this.GrenadeType)));
            queueableBinaryWriter.Write(this.SwarmCount);
            queueableBinaryWriter.Write(this.ActorVariantName);
            queueableBinaryWriter.Write(this.VehicleVariantName);
            queueableBinaryWriter.Write(this.InitialMovementDistance);
            queueableBinaryWriter.Write(this.EmitterVehicle);
            queueableBinaryWriter.Write(((short)(this.InitialMovementMode)));
            queueableBinaryWriter.Write(this.PlacementScript);
            queueableBinaryWriter.Write(this.fieldskip);
            queueableBinaryWriter.Write(this.fieldpad1);
        }
        [System.FlagsAttribute()]
        public enum Flags : int
        {
            None = 0,
            InitiallyAsleep = 1,
            InfectionFormExplode = 2,
            Na = 4,
            AlwaysPlace = 8,
            InitiallyHidden = 16,
        }
        public enum SeatTypeEnum : short
        {
            DEFAULT = 0,
            Passenger = 1,
            Gunner = 2,
            Driver = 3,
            SmallCargo = 4,
            LargeCargo = 5,
            NODriver = 6,
            NOVehicle = 7,
        }
        public enum GrenadeTypeEnum : short
        {
            NONE = 0,
            HumanGrenade = 1,
            CovenantPlasma = 2,
        }
        public enum InitialMovementModeEnum : short
        {
            Default = 0,
            Climbing = 1,
            Flying = 2,
        }
    }
}
