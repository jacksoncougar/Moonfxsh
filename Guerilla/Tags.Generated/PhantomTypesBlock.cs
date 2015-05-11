// ReSharper disable All

using Moonfish.Model;

using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class PhantomTypesBlock : PhantomTypesBlockBase
    {
        public PhantomTypesBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 104, Alignment = 4)]
    public class PhantomTypesBlockBase : GuerillaBlock
    {
        internal Flags flags;
        internal MinimumSize minimumSize;
        internal MaximumSize maximumSize;
        internal byte[] invalidName_;

        /// <summary>
        /// you don't need this if you're just generating effects.  If empty it defaults to the up of the object
        /// </summary>
        internal Moonfish.Tags.StringIdent markerName;

        /// <summary>
        /// you don't need this if you're just generating effects.  If empty it defaults to "marker name"
        /// </summary>
        internal Moonfish.Tags.StringIdent alignmentMarkerName;

        internal byte[] invalidName_0;

        /// <summary>
        /// 0 if you don't want this to behave like spring.  1 is a good starting point if you do.
        /// </summary>
        internal float hookesLawE;

        /// <summary>
        /// radius from linear motion origin in which acceleration is dead.
        /// </summary>
        internal float linearDeadRadius;

        internal float centerAcc;
        internal float centerMaxVel;
        internal float axisAcc;
        internal float axisMaxVel;
        internal float directionAcc;
        internal float directionMaxVel;
        internal byte[] invalidName_1;

        /// <summary>
        /// 0 if you don't want this to behave like spring.  1 is a good starting point if you do.
        /// </summary>
        internal float alignmentHookesLawE;

        internal float alignmentAcc;
        internal float alignmentMaxVel;
        internal byte[] invalidName_2;

        public override int SerializedSize
        {
            get { return 104; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public PhantomTypesBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            flags = (Flags) binaryReader.ReadInt32();
            minimumSize = (MinimumSize) binaryReader.ReadByte();
            maximumSize = (MaximumSize) binaryReader.ReadByte();
            invalidName_ = binaryReader.ReadBytes(2);
            markerName = binaryReader.ReadStringID();
            alignmentMarkerName = binaryReader.ReadStringID();
            invalidName_0 = binaryReader.ReadBytes(8);
            hookesLawE = binaryReader.ReadSingle();
            linearDeadRadius = binaryReader.ReadSingle();
            centerAcc = binaryReader.ReadSingle();
            centerMaxVel = binaryReader.ReadSingle();
            axisAcc = binaryReader.ReadSingle();
            axisMaxVel = binaryReader.ReadSingle();
            directionAcc = binaryReader.ReadSingle();
            directionMaxVel = binaryReader.ReadSingle();
            invalidName_1 = binaryReader.ReadBytes(28);
            alignmentHookesLawE = binaryReader.ReadSingle();
            alignmentAcc = binaryReader.ReadSingle();
            alignmentMaxVel = binaryReader.ReadSingle();
            invalidName_2 = binaryReader.ReadBytes(8);
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
                binaryWriter.Write((Int32) flags);
                binaryWriter.Write((Byte) minimumSize);
                binaryWriter.Write((Byte) maximumSize);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(markerName);
                binaryWriter.Write(alignmentMarkerName);
                binaryWriter.Write(invalidName_0, 0, 8);
                binaryWriter.Write(hookesLawE);
                binaryWriter.Write(linearDeadRadius);
                binaryWriter.Write(centerAcc);
                binaryWriter.Write(centerMaxVel);
                binaryWriter.Write(axisAcc);
                binaryWriter.Write(axisMaxVel);
                binaryWriter.Write(directionAcc);
                binaryWriter.Write(directionMaxVel);
                binaryWriter.Write(invalidName_1, 0, 28);
                binaryWriter.Write(alignmentHookesLawE);
                binaryWriter.Write(alignmentAcc);
                binaryWriter.Write(alignmentMaxVel);
                binaryWriter.Write(invalidName_2, 0, 8);
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum Flags : int
        {
            GeneratesEffects = 1,
            UseAccAsForce = 2,
            NegatesGravity = 4,
            IgnoresPlayers = 8,
            IgnoresNonplayers = 16,
            IgnoresBipeds = 32,
            IgnoresVehicles = 64,
            IgnoresWeapons = 128,
            IgnoresEquipment = 256,
            IgnoresGarbage = 512,
            IgnoresProjectiles = 1024,
            IgnoresScenery = 2048,
            IgnoresMachines = 4096,
            IgnoresControls = 8192,
            IgnoresLightFixtures = 16384,
            IgnoresSoundScenery = 32768,
            IgnoresCrates = 65536,
            IgnoresCreatures = 131072,
            InvalidName = 262144,
            InvalidName0 = 524288,
            InvalidName1 = 1048576,
            InvalidName2 = 2097152,
            InvalidName3 = 4194304,
            InvalidName4 = 8388608,
            LocalizesPhysics = 16777216,
            DisableLinearDamping = 33554432,
            DisableAngularDamping = 67108864,
            IgnoresDeadBipeds = 134217728,
        };

        internal enum MinimumSize : byte
        {
            Default = 0,
            Tiny = 1,
            Small = 2,
            Medium = 3,
            Large = 4,
            Huge = 5,
            ExtraHuge = 6,
        };

        internal enum MaximumSize : byte
        {
            Default = 0,
            Tiny = 1,
            Small = 2,
            Medium = 3,
            Large = 4,
            Huge = 5,
            ExtraHuge = 6,
        };
    };
}