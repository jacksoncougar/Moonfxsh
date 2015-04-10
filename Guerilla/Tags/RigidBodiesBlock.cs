using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class RigidBodiesBlock : RigidBodiesBlockBase
    {
        public  RigidBodiesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 144)]
    public class RigidBodiesBlockBase
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
        internal  RigidBodiesBlockBase(BinaryReader binaryReader)
        {
            this.node = binaryReader.ReadShortBlockIndex1();
            this.region = binaryReader.ReadShortBlockIndex1();
            this.permutattion = binaryReader.ReadShortBlockIndex2();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.boudingSphereOffset = binaryReader.ReadVector3();
            this.boundingSphereRadius = binaryReader.ReadSingle();
            this.flags = (Flags)binaryReader.ReadInt16();
            this.motionType = (MotionType)binaryReader.ReadInt16();
            this.noPhantomPowerAlt = binaryReader.ReadShortBlockIndex1();
            this.size = (Size)binaryReader.ReadInt16();
            this.inertiaTensorScale = binaryReader.ReadSingle();
            this.linearDamping = binaryReader.ReadSingle();
            this.angularDamping = binaryReader.ReadSingle();
            this.centerOffMassOffset = binaryReader.ReadVector3();
            this.shapeType = (ShapeType)binaryReader.ReadInt16();
            this.shape = binaryReader.ReadShortBlockIndex2();
            this.massKg = binaryReader.ReadSingle();
            this.centerOfMass = binaryReader.ReadVector3();
            this.invalidName_0 = binaryReader.ReadBytes(4);
            this.intertiaTensorX = binaryReader.ReadVector3();
            this.invalidName_1 = binaryReader.ReadBytes(4);
            this.intertiaTensorY = binaryReader.ReadVector3();
            this.invalidName_2 = binaryReader.ReadBytes(4);
            this.intertiaTensorZ = binaryReader.ReadVector3();
            this.invalidName_3 = binaryReader.ReadBytes(4);
            this.boundingSpherePad = binaryReader.ReadSingle();
            this.invalidName_4 = binaryReader.ReadBytes(12);
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
