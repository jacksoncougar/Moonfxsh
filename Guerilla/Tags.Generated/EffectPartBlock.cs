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
    public partial class EffectPartBlock : EffectPartBlockBase
    {
        public EffectPartBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 56, Alignment = 4)]
    public class EffectPartBlockBase : GuerillaBlock
    {
        internal CreateIn createIn;
        internal CreateIn createIn0;
        internal Moonfish.Tags.ShortBlockIndex1 location;
        internal Flags flags;
        internal byte[] invalidName_;
        [TagReference("null")] internal Moonfish.Tags.TagReference type;

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

        public override int SerializedSize
        {
            get { return 56; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public EffectPartBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            createIn = (CreateIn) binaryReader.ReadInt16();
            createIn0 = (CreateIn) binaryReader.ReadInt16();
            location = binaryReader.ReadShortBlockIndex1();
            flags = (Flags) binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(4);
            type = binaryReader.ReadTagReference();
            velocityBoundsWorldUnitsPerSecond = binaryReader.ReadRange();
            velocityConeAngleDegrees = binaryReader.ReadSingle();
            angularVelocityBoundsDegreesPerSecond = binaryReader.ReadRange();
            radiusModifierBounds = binaryReader.ReadRange();
            aScalesValues = (AScalesValues) binaryReader.ReadInt32();
            bScalesValues = (BScalesValues) binaryReader.ReadInt32();
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16) createIn);
                binaryWriter.Write((Int16) createIn0);
                binaryWriter.Write(location);
                binaryWriter.Write((Int16) flags);
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(type);
                binaryWriter.Write(velocityBoundsWorldUnitsPerSecond);
                binaryWriter.Write(velocityConeAngleDegrees);
                binaryWriter.Write(angularVelocityBoundsDegreesPerSecond);
                binaryWriter.Write(radiusModifierBounds);
                binaryWriter.Write((Int32) aScalesValues);
                binaryWriter.Write((Int32) bScalesValues);
                return nextAddress;
            }
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