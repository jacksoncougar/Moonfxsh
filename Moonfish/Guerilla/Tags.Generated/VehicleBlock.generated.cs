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
    [TagClassAttribute("vehi")]
    [TagBlockOriginalNameAttribute("vehicle_block")]
    public partial class VehicleBlock : UnitBlock, IWriteDeferrable
    {
        public VehicleFlags VehicleVehicleFlags;
        public TypeEnum Type;
        public ControlEnum Control;
        public float MaximumForwardSpeed;
        public float MaximumReverseSpeed;
        public float SpeedAcceleration;
        public float SpeedDeceleration;
        public float MaximumLeftTurn;
        public float MaximumRightTurn;
        public float WheelCircumference;
        public float TurnRate;
        public float BlurSpeed;
        public SpecificTypeEnum SpecificType;
        public PlayerTrainingVehicleTypeEnum PlayerTrainingVehicleType;
        public Moonfish.Tags.StringIdent FlipMessage;
        public float TurnScale;
        public float SpeedTurnPenaltyPower;
        public float SpeedTurnPenalty;
        public float MaximumLeftSlide;
        public float MaximumRightSlide;
        public float SlideAcceleration;
        public float SlideDeceleration;
        public float MinimumFlippingAngularVelocity;
        public float MaximumFlippingAngularVelocity;
        public VehicleSizeEnum VehicleSize;
        private byte[] fieldpad4 = new byte[2];
        public float FixedGunYaw;
        public float FixedGunPitch;
        /// <summary>
        /// when the steering is off by more than the cusp angle
        ///the steering will overcompensate more and more.  when it
        ///is less, it overcompensates less and less.  the exponent
        ///should be something in the neighborhood of 2.0
        /// </summary>
        public float OverdampenCuspAngle;
        public float OverdampenExponent;
        public float CrouchTransitionTime;
        private byte[] fieldpad5 = new byte[4];
        public float EngineMoment;
        public float EngineMaxAngularVelocity;
        public GearBlock[] Gears = new GearBlock[0];
        public float FlyingTorqueScale;
        public float SeatEnteranceAccelerationScale;
        public float SeatExitAccelersationScale;
        public float AirFrictionDeceleration;
        public float ThrustScale;
        [Moonfish.Tags.TagReferenceAttribute("snd!")]
        public Moonfish.Tags.TagReference SuspensionSound;
        [Moonfish.Tags.TagReferenceAttribute("snd!")]
        public Moonfish.Tags.TagReference CrashSound;
        [Moonfish.Tags.TagReferenceAttribute("foot")]
        public Moonfish.Tags.TagReference UNUSED;
        [Moonfish.Tags.TagReferenceAttribute("effe")]
        public Moonfish.Tags.TagReference SpecialEffect;
        [Moonfish.Tags.TagReferenceAttribute("effe")]
        public Moonfish.Tags.TagReference UnusedEffect;
        public HavokVehiclePhysicsStructBlock HavokVehiclePhysics = new HavokVehiclePhysicsStructBlock();
        public override int SerializedSize
        {
            get
            {
                return 768;
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
            this.VehicleVehicleFlags = ((VehicleFlags)(binaryReader.ReadInt32()));
            this.Type = ((TypeEnum)(binaryReader.ReadInt16()));
            this.Control = ((ControlEnum)(binaryReader.ReadInt16()));
            this.MaximumForwardSpeed = binaryReader.ReadSingle();
            this.MaximumReverseSpeed = binaryReader.ReadSingle();
            this.SpeedAcceleration = binaryReader.ReadSingle();
            this.SpeedDeceleration = binaryReader.ReadSingle();
            this.MaximumLeftTurn = binaryReader.ReadSingle();
            this.MaximumRightTurn = binaryReader.ReadSingle();
            this.WheelCircumference = binaryReader.ReadSingle();
            this.TurnRate = binaryReader.ReadSingle();
            this.BlurSpeed = binaryReader.ReadSingle();
            this.SpecificType = ((SpecificTypeEnum)(binaryReader.ReadInt16()));
            this.PlayerTrainingVehicleType = ((PlayerTrainingVehicleTypeEnum)(binaryReader.ReadInt16()));
            this.FlipMessage = binaryReader.ReadStringIdent();
            this.TurnScale = binaryReader.ReadSingle();
            this.SpeedTurnPenaltyPower = binaryReader.ReadSingle();
            this.SpeedTurnPenalty = binaryReader.ReadSingle();
            this.MaximumLeftSlide = binaryReader.ReadSingle();
            this.MaximumRightSlide = binaryReader.ReadSingle();
            this.SlideAcceleration = binaryReader.ReadSingle();
            this.SlideDeceleration = binaryReader.ReadSingle();
            this.MinimumFlippingAngularVelocity = binaryReader.ReadSingle();
            this.MaximumFlippingAngularVelocity = binaryReader.ReadSingle();
            this.VehicleSize = ((VehicleSizeEnum)(binaryReader.ReadInt16()));
            this.fieldpad4 = binaryReader.ReadBytes(2);
            this.FixedGunYaw = binaryReader.ReadSingle();
            this.FixedGunPitch = binaryReader.ReadSingle();
            this.OverdampenCuspAngle = binaryReader.ReadSingle();
            this.OverdampenExponent = binaryReader.ReadSingle();
            this.CrouchTransitionTime = binaryReader.ReadSingle();
            this.fieldpad5 = binaryReader.ReadBytes(4);
            this.EngineMoment = binaryReader.ReadSingle();
            this.EngineMaxAngularVelocity = binaryReader.ReadSingle();
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(68));
            this.FlyingTorqueScale = binaryReader.ReadSingle();
            this.SeatEnteranceAccelerationScale = binaryReader.ReadSingle();
            this.SeatExitAccelersationScale = binaryReader.ReadSingle();
            this.AirFrictionDeceleration = binaryReader.ReadSingle();
            this.ThrustScale = binaryReader.ReadSingle();
            this.SuspensionSound = binaryReader.ReadTagReference();
            this.CrashSound = binaryReader.ReadTagReference();
            this.UNUSED = binaryReader.ReadTagReference();
            this.SpecialEffect = binaryReader.ReadTagReference();
            this.UnusedEffect = binaryReader.ReadTagReference();
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.HavokVehiclePhysics.ReadFields(binaryReader)));
            return pointerQueue;
        }
        public override void ReadInstances(Moonfish.Guerilla.BlamBinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.Gears = base.ReadBlockArrayData<GearBlock>(binaryReader, pointerQueue.Dequeue());
            this.HavokVehiclePhysics.ReadInstances(binaryReader, pointerQueue);
        }
        public override void DeferReferences(Moonfish.Guerilla.LinearBinaryWriter queueableBinaryWriter)
        {
            base.DeferReferences(queueableBinaryWriter);
            queueableBinaryWriter.Defer(this.Gears);
            this.HavokVehiclePhysics.DeferReferences(queueableBinaryWriter);
        }
        public override void Write(Moonfish.Guerilla.LinearBinaryWriter queueableBinaryWriter)
        {
            base.Write(queueableBinaryWriter);
            queueableBinaryWriter.Write(((int)(this.VehicleVehicleFlags)));
            queueableBinaryWriter.Write(((short)(this.Type)));
            queueableBinaryWriter.Write(((short)(this.Control)));
            queueableBinaryWriter.Write(this.MaximumForwardSpeed);
            queueableBinaryWriter.Write(this.MaximumReverseSpeed);
            queueableBinaryWriter.Write(this.SpeedAcceleration);
            queueableBinaryWriter.Write(this.SpeedDeceleration);
            queueableBinaryWriter.Write(this.MaximumLeftTurn);
            queueableBinaryWriter.Write(this.MaximumRightTurn);
            queueableBinaryWriter.Write(this.WheelCircumference);
            queueableBinaryWriter.Write(this.TurnRate);
            queueableBinaryWriter.Write(this.BlurSpeed);
            queueableBinaryWriter.Write(((short)(this.SpecificType)));
            queueableBinaryWriter.Write(((short)(this.PlayerTrainingVehicleType)));
            queueableBinaryWriter.Write(this.FlipMessage);
            queueableBinaryWriter.Write(this.TurnScale);
            queueableBinaryWriter.Write(this.SpeedTurnPenaltyPower);
            queueableBinaryWriter.Write(this.SpeedTurnPenalty);
            queueableBinaryWriter.Write(this.MaximumLeftSlide);
            queueableBinaryWriter.Write(this.MaximumRightSlide);
            queueableBinaryWriter.Write(this.SlideAcceleration);
            queueableBinaryWriter.Write(this.SlideDeceleration);
            queueableBinaryWriter.Write(this.MinimumFlippingAngularVelocity);
            queueableBinaryWriter.Write(this.MaximumFlippingAngularVelocity);
            queueableBinaryWriter.Write(((short)(this.VehicleSize)));
            queueableBinaryWriter.Write(this.fieldpad4);
            queueableBinaryWriter.Write(this.FixedGunYaw);
            queueableBinaryWriter.Write(this.FixedGunPitch);
            queueableBinaryWriter.Write(this.OverdampenCuspAngle);
            queueableBinaryWriter.Write(this.OverdampenExponent);
            queueableBinaryWriter.Write(this.CrouchTransitionTime);
            queueableBinaryWriter.Write(this.fieldpad5);
            queueableBinaryWriter.Write(this.EngineMoment);
            queueableBinaryWriter.Write(this.EngineMaxAngularVelocity);
            queueableBinaryWriter.WritePointer(this.Gears);
            queueableBinaryWriter.Write(this.FlyingTorqueScale);
            queueableBinaryWriter.Write(this.SeatEnteranceAccelerationScale);
            queueableBinaryWriter.Write(this.SeatExitAccelersationScale);
            queueableBinaryWriter.Write(this.AirFrictionDeceleration);
            queueableBinaryWriter.Write(this.ThrustScale);
            queueableBinaryWriter.Write(this.SuspensionSound);
            queueableBinaryWriter.Write(this.CrashSound);
            queueableBinaryWriter.Write(this.UNUSED);
            queueableBinaryWriter.Write(this.SpecialEffect);
            queueableBinaryWriter.Write(this.UnusedEffect);
            this.HavokVehiclePhysics.Write(queueableBinaryWriter);
        }
        [System.FlagsAttribute()]
        public enum VehicleFlags : int
        {
            None = 0,
            SpeedWakesPhysics = 1,
            TurnWakesPhysics = 2,
            DriverPowerWakesPhysics = 4,
            GunnerPowerWakesPhysics = 8,
            ControlOppositeSpeedSetsBrake = 16,
            SlideWakesPhysics = 32,
            KillsRidersAtTerminalVelocity = 64,
            CausesCollisionDamage = 128,
            AiWeaponCannotRotate = 256,
            AiDoesNotRequireDriver = 512,
            AiUnused = 1024,
            AiDriverEnable = 2048,
            AiDriverFlying = 4096,
            AiDriverCansidestep = 8192,
            AiDriverHovering = 16384,
            VehicleSteersDirectly = 32768,
            Unused = 65536,
            HasEbrake = 131072,
            NoncombatVehicle = 262144,
            NoFrictionWdriver = 524288,
            CanTriggerAutomaticOpeningDoors = 1048576,
            AutoaimWhenTeamless = 2097152,
        }
        public enum TypeEnum : short
        {
            HumanTank = 0,
            HumanJeep = 1,
            HumanBoat = 2,
            HumanPlane = 3,
            AlienScout = 4,
            AlienFighter = 5,
            Turret = 6,
        }
        public enum ControlEnum : short
        {
            VehicleControlNormal = 0,
            VehicleControlUnused = 1,
            VehicleControlTank = 2,
        }
        public enum SpecificTypeEnum : short
        {
            None = 0,
            Ghost = 1,
            Wraith = 2,
            Spectre = 3,
            SentinelEnforcer = 4,
        }
        public enum PlayerTrainingVehicleTypeEnum : short
        {
            None = 0,
            Warthog = 1,
            WarthogTurret = 2,
            Ghost = 3,
            Banshee = 4,
            Tank = 5,
            Wraith = 6,
        }
        public enum VehicleSizeEnum : short
        {
            Small = 0,
            Large = 1,
        }
    }
}
namespace Moonfish.Tags
{
    
    public partial struct TagClass
    {
        public static TagClass Vehi = ((TagClass)("vehi"));
    }
}
