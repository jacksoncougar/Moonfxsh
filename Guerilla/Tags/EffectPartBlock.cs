using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class EffectPartBlock : EffectPartBlockBase
    {
        public  EffectPartBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 56)]
    public class EffectPartBlockBase
    {
        internal CreateIn createIn;
        internal CreateIn createIn0;
        internal Moonfish.Tags.ShortBlockIndex1 location;
        internal Flags flags;
        internal byte[] invalidName_;
        [TagReference("null")]
        internal Moonfish.Tags.TagReference type;
        /// <summary>
        /// initial velocity along the location's forward, for decals the distance at which decal is created (defaults to 0.5)
        /// </summary>
        internal Moonfish.Model.Range velocityBoundsWorldUnitsPerSecond;
        /// <summary>
        /// initial velocity will be inside the cone defined by this angle.
        /// </summary>
        internal float velocityConeAngleDegrees;
        internal Moonfish.Model.Range angularVelocityBoundsDegreesPerSecond;
        internal Moonfish.Model.Range radiusModifierBounds;
        internal AScalesValues aScalesValues;
        internal BScalesValues bScalesValues;
        internal  EffectPartBlockBase(BinaryReader binaryReader)
        {
            this.createIn = (CreateIn)binaryReader.ReadInt16();
            this.createIn0 = (CreateIn)binaryReader.ReadInt16();
            this.location = binaryReader.ReadShortBlockIndex1();
            this.flags = (Flags)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(4);
            this.type = binaryReader.ReadTagReference();
            this.velocityBoundsWorldUnitsPerSecond = binaryReader.ReadRange();
            this.velocityConeAngleDegrees = binaryReader.ReadSingle();
            this.angularVelocityBoundsDegreesPerSecond = binaryReader.ReadRange();
            this.radiusModifierBounds = binaryReader.ReadRange();
            this.aScalesValues = (AScalesValues)binaryReader.ReadInt32();
            this.bScalesValues = (BScalesValues)binaryReader.ReadInt32();
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
        internal enum CreateIn : short
        
        {
            AnyEnvironment = 0,
            AirOnly = 1,
            WaterOnly = 2,
            SpaceOnly = 3,
        };
        internal enum CreateIn0 : short
        
        {
            EitherMode = 0,
            ViolentModeOnly = 1,
            NonviolentModeOnly = 2,
        };
        [FlagsAttribute]
        internal enum Flags : short
        
        {
            FaceDownRegardlessOfLocationDecals = 1,
            OffsetOriginAwayFromGeometryLights = 2,
            NeverAttachedToObject = 4,
            DisabledForDebugging = 8,
            DrawRegardlessOfDistance = 16,
        };
        [FlagsAttribute]
        internal enum AScalesValues : int
        
        {
            Velocity = 1,
            VelocityDelta = 2,
            VelocityConeAngle = 4,
            AngularVelocity = 8,
            AngularVelocityDelta = 16,
            TypeSpecificScale = 32,
        };
        [FlagsAttribute]
        internal enum BScalesValues : int
        
        {
            Velocity = 1,
            VelocityDelta = 2,
            VelocityConeAngle = 4,
            AngularVelocity = 8,
            AngularVelocityDelta = 16,
            TypeSpecificScale = 32,
        };
    };
}
