// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class RigidBodiesBlock : RigidBodiesBlockBase
    {
        public  RigidBodiesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  RigidBodiesBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 144, Alignment = 16)]
    public class RigidBodiesBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.ShortBlockIndex1 node;
        internal Moonfish.Tags.ShortBlockIndex1 region;
        internal Moonfish.Tags.ShortBlockIndex2 permutattion;
        internal byte[] invalidName_;
        internal OpenTK.Vector3 boudingSphereOffset;
        internal float boundingSphereRadius;
        internal Flags flags;
        internal MotionType motionType;
        internal Moonfish.Tags.ShortBlockIndex1 noPhantomPowerAlt;
        internal Size size;
        /// <summary>
        /// 0.0 defaults to 1.0
        /// </summary>
        internal float inertiaTensorScale;
        /// <summary>
        /// this goes from 0-10 (10 is really, really high)
        /// </summary>
        internal float linearDamping;
        /// <summary>
        /// this goes from 0-10 (10 is really, really high)
        /// </summary>
        internal float angularDamping;
        internal OpenTK.Vector3 centerOffMassOffset;
        internal ShapeType shapeType;
        internal Moonfish.Tags.ShortBlockIndex2 shape;
        internal float massKg;
        internal OpenTK.Vector3 centerOfMass;
        internal byte[] invalidName_0;
        internal OpenTK.Vector3 intertiaTensorX;
        internal byte[] invalidName_1;
        internal OpenTK.Vector3 intertiaTensorY;
        internal byte[] invalidName_2;
        internal OpenTK.Vector3 intertiaTensorZ;
        internal byte[] invalidName_3;
        /// <summary>
        /// the bounding sphere for this rigid body will be outset by this much
        /// </summary>
        internal float boundingSpherePad;
        internal byte[] invalidName_4;
        
        public override int SerializedSize{get { return 144; }}
        
        
        public override int Alignment{get { return 16; }}
        
        public  RigidBodiesBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            node = binaryReader.ReadShortBlockIndex1();
            region = binaryReader.ReadShortBlockIndex1();
            permutattion = binaryReader.ReadShortBlockIndex2();
            invalidName_ = binaryReader.ReadBytes(2);
            boudingSphereOffset = binaryReader.ReadVector3();
            boundingSphereRadius = binaryReader.ReadSingle();
            flags = (Flags)binaryReader.ReadInt16();
            motionType = (MotionType)binaryReader.ReadInt16();
            noPhantomPowerAlt = binaryReader.ReadShortBlockIndex1();
            size = (Size)binaryReader.ReadInt16();
            inertiaTensorScale = binaryReader.ReadSingle();
            linearDamping = binaryReader.ReadSingle();
            angularDamping = binaryReader.ReadSingle();
            centerOffMassOffset = binaryReader.ReadVector3();
            shapeType = (ShapeType)binaryReader.ReadInt16();
            shape = binaryReader.ReadShortBlockIndex2();
            massKg = binaryReader.ReadSingle();
            centerOfMass = binaryReader.ReadVector3();
            invalidName_0 = binaryReader.ReadBytes(4);
            intertiaTensorX = binaryReader.ReadVector3();
            invalidName_1 = binaryReader.ReadBytes(4);
            intertiaTensorY = binaryReader.ReadVector3();
            invalidName_2 = binaryReader.ReadBytes(4);
            intertiaTensorZ = binaryReader.ReadVector3();
            invalidName_3 = binaryReader.ReadBytes(4);
            boundingSpherePad = binaryReader.ReadSingle();
            invalidName_4 = binaryReader.ReadBytes(12);
        }
        public  RigidBodiesBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            node = binaryReader.ReadShortBlockIndex1();
            region = binaryReader.ReadShortBlockIndex1();
            permutattion = binaryReader.ReadShortBlockIndex2();
            invalidName_ = binaryReader.ReadBytes(2);
            boudingSphereOffset = binaryReader.ReadVector3();
            boundingSphereRadius = binaryReader.ReadSingle();
            flags = (Flags)binaryReader.ReadInt16();
            motionType = (MotionType)binaryReader.ReadInt16();
            noPhantomPowerAlt = binaryReader.ReadShortBlockIndex1();
            size = (Size)binaryReader.ReadInt16();
            inertiaTensorScale = binaryReader.ReadSingle();
            linearDamping = binaryReader.ReadSingle();
            angularDamping = binaryReader.ReadSingle();
            centerOffMassOffset = binaryReader.ReadVector3();
            shapeType = (ShapeType)binaryReader.ReadInt16();
            shape = binaryReader.ReadShortBlockIndex2();
            massKg = binaryReader.ReadSingle();
            centerOfMass = binaryReader.ReadVector3();
            invalidName_0 = binaryReader.ReadBytes(4);
            intertiaTensorX = binaryReader.ReadVector3();
            invalidName_1 = binaryReader.ReadBytes(4);
            intertiaTensorY = binaryReader.ReadVector3();
            invalidName_2 = binaryReader.ReadBytes(4);
            intertiaTensorZ = binaryReader.ReadVector3();
            invalidName_3 = binaryReader.ReadBytes(4);
            boundingSpherePad = binaryReader.ReadSingle();
            invalidName_4 = binaryReader.ReadBytes(12);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(node);
                binaryWriter.Write(region);
                binaryWriter.Write(permutattion);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(boudingSphereOffset);
                binaryWriter.Write(boundingSphereRadius);
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write((Int16)motionType);
                binaryWriter.Write(noPhantomPowerAlt);
                binaryWriter.Write((Int16)size);
                binaryWriter.Write(inertiaTensorScale);
                binaryWriter.Write(linearDamping);
                binaryWriter.Write(angularDamping);
                binaryWriter.Write(centerOffMassOffset);
                binaryWriter.Write((Int16)shapeType);
                binaryWriter.Write(shape);
                binaryWriter.Write(massKg);
                binaryWriter.Write(centerOfMass);
                binaryWriter.Write(invalidName_0, 0, 4);
                binaryWriter.Write(intertiaTensorX);
                binaryWriter.Write(invalidName_1, 0, 4);
                binaryWriter.Write(intertiaTensorY);
                binaryWriter.Write(invalidName_2, 0, 4);
                binaryWriter.Write(intertiaTensorZ);
                binaryWriter.Write(invalidName_3, 0, 4);
                binaryWriter.Write(boundingSpherePad);
                binaryWriter.Write(invalidName_4, 0, 12);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : short
        {
            NoCollisionsWSelf = 1,
            OnlyCollideWEnv = 2,
            DisableEffectsThisRigidBodyWillNotGenerateImpactEffectsUnlessItHitsAnotherDynamicRigidBodyThatDoes = 4,
            DoesNotInteractWEnvironmentSetThisFlagIfThisRigidBodiesWontTouchTheEnvironmentThisAllowsUsToOpenUpSomeOptimizations = 8,
            BestEarlyMoverBodyIfYouHaveEitherOfTheEarlyMoverFlagsSetInTheObjectDefinitoinThisBodyWillBeChoosenAsTheOneToMakeEveryThingLocalToOtherwiseIPick = 16,
            HasNoPhantomPowerVersionDontCheckThisFlagWithoutTalkingToEamon = 32,
        };
        internal enum MotionType : short
        {
            Sphere = 0,
            StabilizedSphere = 1,
            Box = 2,
            StabilizedBox = 3,
            Keyframed = 4,
            Fixed = 5,
        };
        internal enum Size : short
        {
            Default = 0,
            Tiny = 1,
            Small = 2,
            Medium = 3,
            Large = 4,
            Huge = 5,
            ExtraHuge = 6,
        };
        internal enum ShapeType : short
        {
            Sphere = 0,
            Pill = 1,
            Box = 2,
            Triangle = 3,
            Polyhedron = 4,
            MultiSphere = 5,
            Unused0 = 6,
            Unused1 = 7,
            Unused2 = 8,
            Unused3 = 9,
            Unused4 = 10,
            Unused5 = 11,
            Unused6 = 12,
            Unused7 = 13,
            List = 14,
            Mopp = 15,
        };
    };
}
