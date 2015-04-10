using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ActorStartingLocationsBlock : ActorStartingLocationsBlockBase
    {
        public  ActorStartingLocationsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 100)]
    public class ActorStartingLocationsBlockBase
    {
        internal Moonfish.Tags.StringID name;
        internal OpenTK.Vector3 position;
        internal short referenceFrame;
        internal byte[] invalidName_;
        internal OpenTK.Vector2 facingYawPitchDegrees;
        internal Flags flags;
        internal Moonfish.Tags.ShortBlockIndex1 characterType;
        internal Moonfish.Tags.ShortBlockIndex1 initialWeapon;
        internal Moonfish.Tags.ShortBlockIndex1 initialSecondaryWeapon;
        internal byte[] invalidName_0;
        internal Moonfish.Tags.ShortBlockIndex1 vehicleType;
        internal SeatType seatType;
        internal GrenadeType grenadeType;
        /// <summary>
        /// number of cretures in swarm if a swarm is spawned at this location
        /// </summary>
        internal short swarmCount;
        internal Moonfish.Tags.StringID actorVariantName;
        internal Moonfish.Tags.StringID vehicleVariantName;
        /// <summary>
        /// before doing anything else, the actor will travel the given distance in its forward direction
        /// </summary>
        internal float initialMovementDistance;
        internal Moonfish.Tags.ShortBlockIndex1 emitterVehicle;
        internal InitialMovementMode initialMovementMode;
        internal Moonfish.Tags.String32 placementScript;
        internal byte[] invalidName_1;
        internal byte[] invalidName_2;
        internal  ActorStartingLocationsBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.position = binaryReader.ReadVector3();
            this.referenceFrame = binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.facingYawPitchDegrees = binaryReader.ReadVector2();
            this.flags = (Flags)binaryReader.ReadInt32();
            this.characterType = binaryReader.ReadShortBlockIndex1();
            this.initialWeapon = binaryReader.ReadShortBlockIndex1();
            this.initialSecondaryWeapon = binaryReader.ReadShortBlockIndex1();
            this.invalidName_0 = binaryReader.ReadBytes(2);
            this.vehicleType = binaryReader.ReadShortBlockIndex1();
            this.seatType = (SeatType)binaryReader.ReadInt16();
            this.grenadeType = (GrenadeType)binaryReader.ReadInt16();
            this.swarmCount = binaryReader.ReadInt16();
            this.actorVariantName = binaryReader.ReadStringID();
            this.vehicleVariantName = binaryReader.ReadStringID();
            this.initialMovementDistance = binaryReader.ReadSingle();
            this.emitterVehicle = binaryReader.ReadShortBlockIndex1();
            this.initialMovementMode = (InitialMovementMode)binaryReader.ReadInt16();
            this.placementScript = binaryReader.ReadString32();
            this.invalidName_1 = binaryReader.ReadBytes(2);
            this.invalidName_2 = binaryReader.ReadBytes(2);
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
            InitiallyAsleep = 1,
            InfectionFormExplode = 2,
            NA = 4,
            AlwaysPlace = 8,
            InitiallyHidden = 16,
        };
        internal enum SeatType : short
        
        {
            DEFAULT = 0,
            Passenger = 1,
            Gunner = 2,
            Driver = 3,
            SmallCargo = 4,
            LargeCargo = 5,
            NODriver = 6,
            NOVehicle = 7,
        };
        internal enum GrenadeType : short
        
        {
            NONE = 0,
            HumanGrenade = 1,
            CovenantPlasma = 2,
        };
        internal enum InitialMovementMode : short
        
        {
            Default = 0,
            Climbing = 1,
            Flying = 2,
        };
    };
}
