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
    
    public partial class SquadsBlock : GuerillaBlock, IWriteQueueable
    {
        public Moonfish.Tags.String32 Name;
        public Flags SquadsFlags;
        public TeamEnum Team;
        public Moonfish.Tags.ShortBlockIndex1 Parent;
        public float SquadDelayTime;
        public short NormalDiffCount;
        public short InsaneDiffCount;
        public MajorUpgradeEnum MajorUpgrade;
        private byte[] fieldpad = new byte[2];
        /// <summary>
        /// The following default values are used for spawned actors
        /// </summary>
        public Moonfish.Tags.ShortBlockIndex1 VehicleType;
        public Moonfish.Tags.ShortBlockIndex1 CharacterType;
        public Moonfish.Tags.ShortBlockIndex1 InitialZone;
        private byte[] fieldpad0 = new byte[2];
        public Moonfish.Tags.ShortBlockIndex1 InitialWeapon;
        public Moonfish.Tags.ShortBlockIndex1 InitialSecondaryWeapon;
        public GrenadeTypeEnum GrenadeType;
        public Moonfish.Tags.ShortBlockIndex1 InitialOrder;
        public Moonfish.Tags.StringIdent VehicleVariant;
        public ActorStartingLocationsBlock[] StartingLocations = new ActorStartingLocationsBlock[0];
        public Moonfish.Tags.String32 PlacementScript;
        private byte[] fieldskip = new byte[2];
        private byte[] fieldpad1 = new byte[2];
        public override int SerializedSize
        {
            get
            {
                return 116;
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
            this.Name = binaryReader.ReadString32();
            this.SquadsFlags = ((Flags)(binaryReader.ReadInt32()));
            this.Team = ((TeamEnum)(binaryReader.ReadInt16()));
            this.Parent = binaryReader.ReadShortBlockIndex1();
            this.SquadDelayTime = binaryReader.ReadSingle();
            this.NormalDiffCount = binaryReader.ReadInt16();
            this.InsaneDiffCount = binaryReader.ReadInt16();
            this.MajorUpgrade = ((MajorUpgradeEnum)(binaryReader.ReadInt16()));
            this.fieldpad = binaryReader.ReadBytes(2);
            this.VehicleType = binaryReader.ReadShortBlockIndex1();
            this.CharacterType = binaryReader.ReadShortBlockIndex1();
            this.InitialZone = binaryReader.ReadShortBlockIndex1();
            this.fieldpad0 = binaryReader.ReadBytes(2);
            this.InitialWeapon = binaryReader.ReadShortBlockIndex1();
            this.InitialSecondaryWeapon = binaryReader.ReadShortBlockIndex1();
            this.GrenadeType = ((GrenadeTypeEnum)(binaryReader.ReadInt16()));
            this.InitialOrder = binaryReader.ReadShortBlockIndex1();
            this.VehicleVariant = binaryReader.ReadStringID();
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(100));
            this.PlacementScript = binaryReader.ReadString32();
            this.fieldskip = binaryReader.ReadBytes(2);
            this.fieldpad1 = binaryReader.ReadBytes(2);
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.StartingLocations = base.ReadBlockArrayData<ActorStartingLocationsBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            queueableBinaryWriter.QueueWrite(this.StartingLocations);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.Name);
            queueableBinaryWriter.Write(((int)(this.SquadsFlags)));
            queueableBinaryWriter.Write(((short)(this.Team)));
            queueableBinaryWriter.Write(this.Parent);
            queueableBinaryWriter.Write(this.SquadDelayTime);
            queueableBinaryWriter.Write(this.NormalDiffCount);
            queueableBinaryWriter.Write(this.InsaneDiffCount);
            queueableBinaryWriter.Write(((short)(this.MajorUpgrade)));
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.Write(this.VehicleType);
            queueableBinaryWriter.Write(this.CharacterType);
            queueableBinaryWriter.Write(this.InitialZone);
            queueableBinaryWriter.Write(this.fieldpad0);
            queueableBinaryWriter.Write(this.InitialWeapon);
            queueableBinaryWriter.Write(this.InitialSecondaryWeapon);
            queueableBinaryWriter.Write(((short)(this.GrenadeType)));
            queueableBinaryWriter.Write(this.InitialOrder);
            queueableBinaryWriter.Write(this.VehicleVariant);
            queueableBinaryWriter.WritePointer(this.StartingLocations);
            queueableBinaryWriter.Write(this.PlacementScript);
            queueableBinaryWriter.Write(this.fieldskip);
            queueableBinaryWriter.Write(this.fieldpad1);
        }
        [System.FlagsAttribute()]
        public enum Flags : int
        {
            None = 0,
            Unused = 1,
            NeverSearch = 2,
            StartTimerImmediately = 4,
            NoTimerDelayForever = 8,
            MagicSightAfterTimer = 16,
            AutomaticMigration = 32,
            DEPRECATED = 64,
            RespawnEnabled = 128,
            Blind = 256,
            Deaf = 512,
            Braindead = 1024,
            _3dFiringPositions = 2048,
            InitiallyPlaced = 4096,
            UnitsNotEnterableByPlayer = 8192,
        }
        public enum TeamEnum : short
        {
            Default = 0,
            Player = 1,
            Human = 2,
            Covenant = 3,
            Flood = 4,
            Sentinel = 5,
            Heretic = 6,
            Prophet = 7,
            Unused8 = 8,
            Unused9 = 9,
            Unused10 = 10,
            Unused11 = 11,
            Unused12 = 12,
            Unused13 = 13,
            Unused14 = 14,
            Unused15 = 15,
        }
        public enum MajorUpgradeEnum : short
        {
            Normal = 0,
            Few = 1,
            Many = 2,
            None = 3,
            All = 4,
        }
        public enum GrenadeTypeEnum : short
        {
            NONE = 0,
            HumanGrenade = 1,
            CovenantPlasma = 2,
        }
    }
}
