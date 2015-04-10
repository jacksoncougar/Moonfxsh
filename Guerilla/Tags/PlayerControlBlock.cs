using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class PlayerControlBlock : PlayerControlBlockBase
    {
        public  PlayerControlBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 128)]
    public class PlayerControlBlockBase
    {
        /// <summary>
        /// how much the crosshair slows over enemies
        /// </summary>
        internal float magnetismFriction;
        /// <summary>
        /// how much the crosshair sticks to enemies
        /// </summary>
        internal float magnetismAdhesion;
        /// <summary>
        /// scales magnetism level for inconsequential targets like infection forms
        /// </summary>
        internal float inconsequentialTargetScale;
        internal byte[] invalidName_;
        /// <summary>
        /// -1..1, 0 is middle of the screen
        /// </summary>
        internal OpenTK.Vector2 crosshairLocation;
        /// <summary>
        /// how long you must be pegged before you start sprinting
        /// </summary>
        internal float secondsToStart;
        /// <summary>
        /// how long you must sprint before you reach top speed
        /// </summary>
        internal float secondsToFullSpeed;
        /// <summary>
        /// how fast being unpegged decays the timer (seconds per second)
        /// </summary>
        internal float decayRate;
        /// <summary>
        /// how much faster we actually go when at full sprint
        /// </summary>
        internal float fullSpeedMultiplier;
        /// <summary>
        /// how far the stick needs to be pressed before being considered pegged
        /// </summary>
        internal float peggedMagnitude;
        /// <summary>
        /// how far off straight up (in degrees) we consider pegged
        /// </summary>
        internal float peggedAngularThreshold;
        internal byte[] invalidName_0;
        internal float lookDefaultPitchRateDegrees;
        internal float lookDefaultYawRateDegrees;
        /// <summary>
        /// magnitude of yaw for pegged acceleration to kick in
        /// </summary>
        internal float lookPegThreshold01;
        /// <summary>
        /// time for a pegged look to reach maximum effect
        /// </summary>
        internal float lookYawAccelerationTimeSeconds;
        /// <summary>
        /// maximum effect of a pegged look (scales last value in the look function below)
        /// </summary>
        internal float lookYawAccelerationScale;
        /// <summary>
        /// time for a pegged look to reach maximum effect
        /// </summary>
        internal float lookPitchAccelerationTimeSeconds;
        /// <summary>
        /// maximum effect of a pegged look (scales last value in the look function below)
        /// </summary>
        internal float lookPitchAccelerationScale;
        /// <summary>
        /// 1 is fast, 0 is none, >1 will probably be really fast
        /// </summary>
        internal float lookAutolevellingScale;
        internal byte[] invalidName_1;
        internal float gravityScale;
        internal byte[] invalidName_2;
        /// <summary>
        /// amount of time player needs to move and not look up or down for autolevelling to kick in
        /// </summary>
        internal short minimumAutolevellingTicks;
        /// <summary>
        /// 0 means the vehicle's up vector is along the ground, 90 means the up vector is pointing straight up:degrees
        /// </summary>
        internal float minimumAngleForVehicleFlipping;
        internal LookFunctionBlock[] lookFunction;
        /// <summary>
        /// time that player needs to press ACTION to register as a HOLD
        /// </summary>
        internal float minimumActionHoldTimeSeconds;
        internal  PlayerControlBlockBase(BinaryReader binaryReader)
        {
            this.magnetismFriction = binaryReader.ReadSingle();
            this.magnetismAdhesion = binaryReader.ReadSingle();
            this.inconsequentialTargetScale = binaryReader.ReadSingle();
            this.invalidName_ = binaryReader.ReadBytes(12);
            this.crosshairLocation = binaryReader.ReadVector2();
            this.secondsToStart = binaryReader.ReadSingle();
            this.secondsToFullSpeed = binaryReader.ReadSingle();
            this.decayRate = binaryReader.ReadSingle();
            this.fullSpeedMultiplier = binaryReader.ReadSingle();
            this.peggedMagnitude = binaryReader.ReadSingle();
            this.peggedAngularThreshold = binaryReader.ReadSingle();
            this.invalidName_0 = binaryReader.ReadBytes(8);
            this.lookDefaultPitchRateDegrees = binaryReader.ReadSingle();
            this.lookDefaultYawRateDegrees = binaryReader.ReadSingle();
            this.lookPegThreshold01 = binaryReader.ReadSingle();
            this.lookYawAccelerationTimeSeconds = binaryReader.ReadSingle();
            this.lookYawAccelerationScale = binaryReader.ReadSingle();
            this.lookPitchAccelerationTimeSeconds = binaryReader.ReadSingle();
            this.lookPitchAccelerationScale = binaryReader.ReadSingle();
            this.lookAutolevellingScale = binaryReader.ReadSingle();
            this.invalidName_1 = binaryReader.ReadBytes(8);
            this.gravityScale = binaryReader.ReadSingle();
            this.invalidName_2 = binaryReader.ReadBytes(2);
            this.minimumAutolevellingTicks = binaryReader.ReadInt16();
            this.minimumAngleForVehicleFlipping = binaryReader.ReadSingle();
            this.lookFunction = ReadLookFunctionBlockArray(binaryReader);
            this.minimumActionHoldTimeSeconds = binaryReader.ReadSingle();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
        }
        internal  virtual LookFunctionBlock[] ReadLookFunctionBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(LookFunctionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new LookFunctionBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new LookFunctionBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
