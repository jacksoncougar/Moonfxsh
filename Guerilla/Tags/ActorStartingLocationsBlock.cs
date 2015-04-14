// ReSharper disable All
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
    [LayoutAttribute(Size = 100, Alignment = 4)]
    public class ActorStartingLocationsBlockBase  : IGuerilla
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
            name = binaryReader.ReadStringID();
            position = binaryReader.ReadVector3();
            referenceFrame = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            facingYawPitchDegrees = binaryReader.ReadVector2();
            flags = (Flags)binaryReader.ReadInt32();
            characterType = binaryReader.ReadShortBlockIndex1();
            initialWeapon = binaryReader.ReadShortBlockIndex1();
            initialSecondaryWeapon = binaryReader.ReadShortBlockIndex1();
            invalidName_0 = binaryReader.ReadBytes(2);
            vehicleType = binaryReader.ReadShortBlockIndex1();
            seatType = (SeatType)binaryReader.ReadInt16();
            grenadeType = (GrenadeType)binaryReader.ReadInt16();
            swarmCount = binaryReader.ReadInt16();
            actorVariantName = binaryReader.ReadStringID();
            vehicleVariantName = binaryReader.ReadStringID();
            initialMovementDistance = binaryReader.ReadSingle();
            emitterVehicle = binaryReader.ReadShortBlockIndex1();
            initialMovementMode = (InitialMovementMode)binaryReader.ReadInt16();
            placementScript = binaryReader.ReadString32();
            invalidName_1 = binaryReader.ReadBytes(2);
            invalidName_2 = binaryReader.ReadBytes(2);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write(position);
                binaryWriter.Write(referenceFrame);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(facingYawPitchDegrees);
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write(characterType);
                binaryWriter.Write(initialWeapon);
                binaryWriter.Write(initialSecondaryWeapon);
                binaryWriter.Write(invalidName_0, 0, 2);
                binaryWriter.Write(vehicleType);
                binaryWriter.Write((Int16)seatType);
                binaryWriter.Write((Int16)grenadeType);
                binaryWriter.Write(swarmCount);
                binaryWriter.Write(actorVariantName);
                binaryWriter.Write(vehicleVariantName);
                binaryWriter.Write(initialMovementDistance);
                binaryWriter.Write(emitterVehicle);
                binaryWriter.Write((Int16)initialMovementMode);
                binaryWriter.Write(placementScript);
                binaryWriter.Write(invalidName_1, 0, 2);
                binaryWriter.Write(invalidName_2, 0, 2);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
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
