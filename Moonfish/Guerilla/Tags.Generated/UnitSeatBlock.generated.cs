//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Moonfish.Guerilla.Tags
{
    using JetBrains.Annotations;
    using Moonfish.Tags;
    using Moonfish.Model;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    
    [JetBrains.Annotations.UsedImplicitlyAttribute(ImplicitUseTargetFlags.WithMembers)]
    [TagBlockOriginalNameAttribute("unit_seat_block")]
    public partial class UnitSeatBlock : GuerillaBlock, IWriteQueueable
    {
        public Flags UnitSeatFlags;
        public Moonfish.Tags.StringIdent Label;
        public Moonfish.Tags.StringIdent MarkerName;
        public Moonfish.Tags.StringIdent EntryMarkerName;
        public Moonfish.Tags.StringIdent BoardingGrenadeMarker;
        public Moonfish.Tags.StringIdent BoardingGrenadeString;
        public Moonfish.Tags.StringIdent BoardingMeleeString;
        public float PingScale;
        public float TurnoverTime;
        public UnitSeatAccelerationStructBlock Acceleration = new UnitSeatAccelerationStructBlock();
        public float AIScariness;
        public AiSeatTypeEnum AiSeatType;
        public Moonfish.Tags.ShortBlockIndex1 BoardingSeat;
        public float ListenerInterpolationFactor;
        /// <summary>
        /// when the unit velocity is 0, the yaw/pitch rates are the left values
        ///at [max speed reference], the yaw/pitch rates are the right values.
        ///the max speed reference is what the code uses to generate a clamped speed from 0..1
        ///the exponent controls how midrange speeds are interpreted.
        /// </summary>
        public Moonfish.Model.Range YawRateBounds;
        public Moonfish.Model.Range PitchRateBounds;
        public float MinSpeedReference;
        public float MaxSpeedReference;
        public float SpeedExponent;
        public UnitCameraStructBlock UnitCamera = new UnitCameraStructBlock();
        public UnitHudReferenceBlock[] UnitHudInterface = new UnitHudReferenceBlock[0];
        public Moonfish.Tags.StringIdent EnterSeatString;
        public float YawMinimum;
        public float YawMaximum;
        [Moonfish.Tags.TagReferenceAttribute("char")]
        public Moonfish.Tags.TagReference BuiltinGunner;
        /// <summary>
        /// note: the entry radius shouldn't exceed 3 world units, 
        ///as that is as far as the player will search for a vehicle
        ///to enter.
        /// </summary>
        public float EntryRadius;
        public float EntryMarkerConeAngle;
        public float EntryMarkerFacingAngle;
        public float MaximumRelativeVelocity;
        public Moonfish.Tags.StringIdent InvisibleSeatRegion;
        public int RuntimeInvisibleSeatRegionIndex;
        public override int SerializedSize
        {
            get
            {
                return 176;
            }
        }
        public override int Alignment
        {
            get
            {
                return 4;
            }
        }
        public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(Moonfish.Guerilla.BlamBinaryReader binaryReader)
        {
            System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
            this.UnitSeatFlags = ((Flags)(binaryReader.ReadInt32()));
            this.Label = binaryReader.ReadStringIdent();
            this.MarkerName = binaryReader.ReadStringIdent();
            this.EntryMarkerName = binaryReader.ReadStringIdent();
            this.BoardingGrenadeMarker = binaryReader.ReadStringIdent();
            this.BoardingGrenadeString = binaryReader.ReadStringIdent();
            this.BoardingMeleeString = binaryReader.ReadStringIdent();
            this.PingScale = binaryReader.ReadSingle();
            this.TurnoverTime = binaryReader.ReadSingle();
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.Acceleration.ReadFields(binaryReader)));
            this.AIScariness = binaryReader.ReadSingle();
            this.AiSeatType = ((AiSeatTypeEnum)(binaryReader.ReadInt16()));
            this.BoardingSeat = binaryReader.ReadShortBlockIndex1();
            this.ListenerInterpolationFactor = binaryReader.ReadSingle();
            this.YawRateBounds = binaryReader.ReadRange();
            this.PitchRateBounds = binaryReader.ReadRange();
            this.MinSpeedReference = binaryReader.ReadSingle();
            this.MaxSpeedReference = binaryReader.ReadSingle();
            this.SpeedExponent = binaryReader.ReadSingle();
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.UnitCamera.ReadFields(binaryReader)));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(8));
            this.EnterSeatString = binaryReader.ReadStringIdent();
            this.YawMinimum = binaryReader.ReadSingle();
            this.YawMaximum = binaryReader.ReadSingle();
            this.BuiltinGunner = binaryReader.ReadTagReference();
            this.EntryRadius = binaryReader.ReadSingle();
            this.EntryMarkerConeAngle = binaryReader.ReadSingle();
            this.EntryMarkerFacingAngle = binaryReader.ReadSingle();
            this.MaximumRelativeVelocity = binaryReader.ReadSingle();
            this.InvisibleSeatRegion = binaryReader.ReadStringIdent();
            this.RuntimeInvisibleSeatRegionIndex = binaryReader.ReadInt32();
            return pointerQueue;
        }
        public override void ReadInstances(Moonfish.Guerilla.BlamBinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.Acceleration.ReadInstances(binaryReader, pointerQueue);
            this.UnitCamera.ReadInstances(binaryReader, pointerQueue);
            this.UnitHudInterface = base.ReadBlockArrayData<UnitHudReferenceBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            this.Acceleration.QueueWrites(queueableBinaryWriter);
            this.UnitCamera.QueueWrites(queueableBinaryWriter);
            queueableBinaryWriter.QueueWrite(this.UnitHudInterface);
        }
        public override void Write(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBinaryWriter)
        {
            base.Write(queueableBinaryWriter);
            queueableBinaryWriter.Write(((int)(this.UnitSeatFlags)));
            queueableBinaryWriter.Write(this.Label);
            queueableBinaryWriter.Write(this.MarkerName);
            queueableBinaryWriter.Write(this.EntryMarkerName);
            queueableBinaryWriter.Write(this.BoardingGrenadeMarker);
            queueableBinaryWriter.Write(this.BoardingGrenadeString);
            queueableBinaryWriter.Write(this.BoardingMeleeString);
            queueableBinaryWriter.Write(this.PingScale);
            queueableBinaryWriter.Write(this.TurnoverTime);
            this.Acceleration.Write(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.AIScariness);
            queueableBinaryWriter.Write(((short)(this.AiSeatType)));
            queueableBinaryWriter.Write(this.BoardingSeat);
            queueableBinaryWriter.Write(this.ListenerInterpolationFactor);
            queueableBinaryWriter.Write(this.YawRateBounds);
            queueableBinaryWriter.Write(this.PitchRateBounds);
            queueableBinaryWriter.Write(this.MinSpeedReference);
            queueableBinaryWriter.Write(this.MaxSpeedReference);
            queueableBinaryWriter.Write(this.SpeedExponent);
            this.UnitCamera.Write(queueableBinaryWriter);
            queueableBinaryWriter.WritePointer(this.UnitHudInterface);
            queueableBinaryWriter.Write(this.EnterSeatString);
            queueableBinaryWriter.Write(this.YawMinimum);
            queueableBinaryWriter.Write(this.YawMaximum);
            queueableBinaryWriter.Write(this.BuiltinGunner);
            queueableBinaryWriter.Write(this.EntryRadius);
            queueableBinaryWriter.Write(this.EntryMarkerConeAngle);
            queueableBinaryWriter.Write(this.EntryMarkerFacingAngle);
            queueableBinaryWriter.Write(this.MaximumRelativeVelocity);
            queueableBinaryWriter.Write(this.InvisibleSeatRegion);
            queueableBinaryWriter.Write(this.RuntimeInvisibleSeatRegionIndex);
        }
        [System.FlagsAttribute()]
        public enum Flags : int
        {
            None = 0,
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
            InvalidForNonplayer = 131072,
            GunnerplayerOnly = 262144,
            InvisibleUnderMajorDamage = 524288,
        }
        public enum AiSeatTypeEnum : short
        {
            NONE = 0,
            Passenger = 1,
            Gunner = 2,
            SmallCargo = 3,
            LargeCargo = 4,
            Driver = 5,
        }
    }
}
