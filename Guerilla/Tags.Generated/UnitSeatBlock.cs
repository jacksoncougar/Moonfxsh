// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class UnitSeatBlock : UnitSeatBlockBase
    {
        public UnitSeatBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 176, Alignment = 4)]
    public class UnitSeatBlockBase : GuerillaBlock
    {
        internal Flags flags;
        internal Moonfish.Tags.StringIdent label;
        internal Moonfish.Tags.StringIdent markerName;
        internal Moonfish.Tags.StringIdent entryMarkerSName;
        internal Moonfish.Tags.StringIdent boardingGrenadeMarker;
        internal Moonfish.Tags.StringIdent boardingGrenadeString;
        internal Moonfish.Tags.StringIdent boardingMeleeString;
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
        internal Moonfish.Tags.StringIdent enterSeatString;
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
        internal Moonfish.Tags.StringIdent invisibleSeatRegion;
        internal int runtimeInvisibleSeatRegionIndex;
        public override int SerializedSize { get { return 176; } }
        public override int Alignment { get { return 4; } }
        public UnitSeatBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            flags = (Flags)binaryReader.ReadInt32();
            label = binaryReader.ReadStringID();
            markerName = binaryReader.ReadStringID();
            entryMarkerSName = binaryReader.ReadStringID();
            boardingGrenadeMarker = binaryReader.ReadStringID();
            boardingGrenadeString = binaryReader.ReadStringID();
            boardingMeleeString = binaryReader.ReadStringID();
            pingScale = binaryReader.ReadSingle();
            turnoverTimeSeconds = binaryReader.ReadSingle();
            acceleration = new UnitSeatAccelerationStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(acceleration.ReadFields(binaryReader)));
            aIScariness = binaryReader.ReadSingle();
            aiSeatType = (AiSeatType)binaryReader.ReadInt16();
            boardingSeat = binaryReader.ReadShortBlockIndex1();
            listenerInterpolationFactor = binaryReader.ReadSingle();
            yawRateBoundsDegreesPerSecond = binaryReader.ReadRange();
            pitchRateBoundsDegreesPerSecond = binaryReader.ReadRange();
            minSpeedReference = binaryReader.ReadSingle();
            maxSpeedReference = binaryReader.ReadSingle();
            speedExponent = binaryReader.ReadSingle();
            unitCamera = new UnitCameraStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(unitCamera.ReadFields(binaryReader)));
            blamPointers.Enqueue(ReadBlockArrayPointer<UnitHudReferenceBlock>(binaryReader));
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
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            acceleration.ReadPointers(binaryReader, blamPointers);
            unitCamera.ReadPointers(binaryReader, blamPointers);
            unitHudInterface = ReadBlockArrayData<UnitHudReferenceBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
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
