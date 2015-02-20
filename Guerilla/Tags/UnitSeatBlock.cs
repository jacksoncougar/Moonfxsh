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
    [LayoutAttribute(Size = 176)]
    public class UnitSeatBlockBase
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
            this.flags = (Flags)binaryReader.ReadInt32();
            this.label = binaryReader.ReadStringID();
            this.markerName = binaryReader.ReadStringID();
            this.entryMarkerSName = binaryReader.ReadStringID();
            this.boardingGrenadeMarker = binaryReader.ReadStringID();
            this.boardingGrenadeString = binaryReader.ReadStringID();
            this.boardingMeleeString = binaryReader.ReadStringID();
            this.pingScale = binaryReader.ReadSingle();
            this.turnoverTimeSeconds = binaryReader.ReadSingle();
            this.acceleration = new UnitSeatAccelerationStructBlock(binaryReader);
            this.aIScariness = binaryReader.ReadSingle();
            this.aiSeatType = (AiSeatType)binaryReader.ReadInt16();
            this.boardingSeat = binaryReader.ReadShortBlockIndex1();
            this.listenerInterpolationFactor = binaryReader.ReadSingle();
            this.yawRateBoundsDegreesPerSecond = binaryReader.ReadRange();
            this.pitchRateBoundsDegreesPerSecond = binaryReader.ReadRange();
            this.minSpeedReference = binaryReader.ReadSingle();
            this.maxSpeedReference = binaryReader.ReadSingle();
            this.speedExponent = binaryReader.ReadSingle();
            this.unitCamera = new UnitCameraStructBlock(binaryReader);
            this.unitHudInterface = ReadUnitHudReferenceBlockArray(binaryReader);
            this.enterSeatString = binaryReader.ReadStringID();
            this.yawMinimum = binaryReader.ReadSingle();
            this.yawMaximum = binaryReader.ReadSingle();
            this.builtInGunner = binaryReader.ReadTagReference();
            this.entryRadius = binaryReader.ReadSingle();
            this.entryMarkerConeAngle = binaryReader.ReadSingle();
            this.entryMarkerFacingAngle = binaryReader.ReadSingle();
            this.maximumRelativeVelocity = binaryReader.ReadSingle();
            this.invisibleSeatRegion = binaryReader.ReadStringID();
            this.runtimeInvisibleSeatRegionIndex = binaryReader.ReadInt32();
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
        internal  virtual UnitHudReferenceBlock[] ReadUnitHudReferenceBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(UnitHudReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new UnitHudReferenceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new UnitHudReferenceBlock(binaryReader);
                }
            }
            return array;
        }
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
