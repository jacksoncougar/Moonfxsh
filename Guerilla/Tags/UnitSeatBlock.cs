// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class UnitSeatBlock : UnitSeatBlockBase
    {
        public  UnitSeatBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 176, Alignment = 4)]
    public class UnitSeatBlockBase  : IGuerilla
    {
        internal Flags flags;
        internal Moonfish.Tags.StringID label;
        internal Moonfish.Tags.StringID markerName;
        internal Moonfish.Tags.StringID entryMarkerSName;
        internal Moonfish.Tags.StringID boardingGrenadeMarker;
        internal Moonfish.Tags.StringID boardingGrenadeString;
        internal Moonfish.Tags.StringID boardingMeleeString;
        /// <summary>
        /// nathan is too lazy to make pings for each seat.
        /// </summary>
        internal float pingScale;
        /// <summary>
        /// how much time it takes to evict a rider from a flipped vehicle
        /// </summary>
        internal float turnoverTimeSeconds;
        internal UnitSeatAccelerationStructBlock acceleration;
        internal float aIScariness;
        internal AiSeatType aiSeatType;
        internal Moonfish.Tags.ShortBlockIndex1 boardingSeat;
        /// <summary>
        /// how far to interpolate listener position from camera to occupant's head
        /// </summary>
        internal float listenerInterpolationFactor;
        internal Moonfish.Model.Range yawRateBoundsDegreesPerSecond;
        internal Moonfish.Model.Range pitchRateBoundsDegreesPerSecond;
        internal float minSpeedReference;
        internal float maxSpeedReference;
        internal float speedExponent;
        internal UnitCameraStructBlock unitCamera;
        internal UnitHudReferenceBlock[] unitHudInterface;
        internal Moonfish.Tags.StringID enterSeatString;
        internal float yawMinimum;
        internal float yawMaximum;
        [TagReference("char")]
        internal Moonfish.Tags.TagReference builtInGunner;
        /// <summary>
        /// how close to the entry marker a unit must be
        /// </summary>
        internal float entryRadius;
        /// <summary>
        /// angle from marker forward the unit must be
        /// </summary>
        internal float entryMarkerConeAngle;
        /// <summary>
        /// angle from unit facing the marker must be
        /// </summary>
        internal float entryMarkerFacingAngle;
        internal float maximumRelativeVelocity;
        internal Moonfish.Tags.StringID invisibleSeatRegion;
        internal int runtimeInvisibleSeatRegionIndex;
        internal  UnitSeatBlockBase(BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt32();
            label = binaryReader.ReadStringID();
            markerName = binaryReader.ReadStringID();
            entryMarkerSName = binaryReader.ReadStringID();
            boardingGrenadeMarker = binaryReader.ReadStringID();
            boardingGrenadeString = binaryReader.ReadStringID();
            boardingMeleeString = binaryReader.ReadStringID();
            pingScale = binaryReader.ReadSingle();
            turnoverTimeSeconds = binaryReader.ReadSingle();
            acceleration = new UnitSeatAccelerationStructBlock(binaryReader);
            aIScariness = binaryReader.ReadSingle();
            aiSeatType = (AiSeatType)binaryReader.ReadInt16();
            boardingSeat = binaryReader.ReadShortBlockIndex1();
            listenerInterpolationFactor = binaryReader.ReadSingle();
            yawRateBoundsDegreesPerSecond = binaryReader.ReadRange();
            pitchRateBoundsDegreesPerSecond = binaryReader.ReadRange();
            minSpeedReference = binaryReader.ReadSingle();
            maxSpeedReference = binaryReader.ReadSingle();
            speedExponent = binaryReader.ReadSingle();
            unitCamera = new UnitCameraStructBlock(binaryReader);
            unitHudInterface = Guerilla.ReadBlockArray<UnitHudReferenceBlock>(binaryReader);
            enterSeatString = binaryReader.ReadStringID();
            yawMinimum = binaryReader.ReadSingle();
            yawMaximum = binaryReader.ReadSingle();
            builtInGunner = binaryReader.ReadTagReference();
            entryRadius = binaryReader.ReadSingle();
            entryMarkerConeAngle = binaryReader.ReadSingle();
            entryMarkerFacingAngle = binaryReader.ReadSingle();
            maximumRelativeVelocity = binaryReader.ReadSingle();
            invisibleSeatRegion = binaryReader.ReadStringID();
            runtimeInvisibleSeatRegionIndex = binaryReader.ReadInt32();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write(label);
                binaryWriter.Write(markerName);
                binaryWriter.Write(entryMarkerSName);
                binaryWriter.Write(boardingGrenadeMarker);
                binaryWriter.Write(boardingGrenadeString);
                binaryWriter.Write(boardingMeleeString);
                binaryWriter.Write(pingScale);
                binaryWriter.Write(turnoverTimeSeconds);
                acceleration.Write(binaryWriter);
                binaryWriter.Write(aIScariness);
                binaryWriter.Write((Int16)aiSeatType);
                binaryWriter.Write(boardingSeat);
                binaryWriter.Write(listenerInterpolationFactor);
                binaryWriter.Write(yawRateBoundsDegreesPerSecond);
                binaryWriter.Write(pitchRateBoundsDegreesPerSecond);
                binaryWriter.Write(minSpeedReference);
                binaryWriter.Write(maxSpeedReference);
                binaryWriter.Write(speedExponent);
                unitCamera.Write(binaryWriter);
                nextAddress = Guerilla.WriteBlockArray<UnitHudReferenceBlock>(binaryWriter, unitHudInterface, nextAddress);
                binaryWriter.Write(enterSeatString);
                binaryWriter.Write(yawMinimum);
                binaryWriter.Write(yawMaximum);
                binaryWriter.Write(builtInGunner);
                binaryWriter.Write(entryRadius);
                binaryWriter.Write(entryMarkerConeAngle);
                binaryWriter.Write(entryMarkerFacingAngle);
                binaryWriter.Write(maximumRelativeVelocity);
                binaryWriter.Write(invisibleSeatRegion);
                binaryWriter.Write(runtimeInvisibleSeatRegionIndex);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        {
            Invisible = 1,
            Locked = 2,
            Driver = 4,
            Gunner = 8,
            ThirdPersonCamera = 16,
            AllowsWeapons = 32,
            ThirdPersonOnEnter = 64,
            FirstPersonCameraSlavedToGun = 128,
            AllowVehicleCommunicationAnimations = 256,
            NotValidWithoutDriver = 512,
            AllowAINoncombatants = 1024,
            BoardingSeat = 2048,
            AiFiringDisabledByMaxAcceleration = 4096,
            BoardingEntersSeat = 8192,
            BoardingNeedAnyPassenger = 16384,
            ControlsOpenAndClose = 32768,
            InvalidForPlayer = 65536,
            InvalidForNonPlayer = 131072,
            GunnerPlayerOnly = 262144,
            InvisibleUnderMajorDamage = 524288,
        };
        internal enum AiSeatType : short
        {
            NONE = 0,
            Passenger = 1,
            Gunner = 2,
            SmallCargo = 3,
            LargeCargo = 4,
            Driver = 5,
        };
    };
}
