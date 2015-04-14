// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass PhysClass = (TagClass)"phys";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("phys")]
    public  partial class PhysicsBlock : PhysicsBlockBase
    {
        public  PhysicsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 116, Alignment = 4)]
    public class PhysicsBlockBase  : IGuerilla
    {
        /// <summary>
        /// positive uses old inferior physics, negative uses new improved physics
        /// </summary>
        internal float radius;
        internal float momentScale;
        internal float mass;
        internal OpenTK.Vector3 centerOfMass;
        internal float density;
        internal float gravityScale;
        internal float groundFriction;
        internal float groundDepth;
        internal float groundDampFraction;
        internal float groundNormalK1;
        internal float groundNormalK0;
        internal byte[] invalidName_;
        internal float waterFriction;
        internal float waterDepth;
        internal float waterDensity;
        internal byte[] invalidName_0;
        internal float airFriction;
        internal byte[] invalidName_1;
        internal float xxMoment;
        internal float yyMoment;
        internal float zzMoment;
        internal InertialMatrixBlock[] inertialMatrixAndInverse;
        internal PoweredMassPointBlock[] poweredMassPoints;
        internal MassPointBlock[] massPoints;
        internal  PhysicsBlockBase(BinaryReader binaryReader)
        {
            radius = binaryReader.ReadSingle();
            momentScale = binaryReader.ReadSingle();
            mass = binaryReader.ReadSingle();
            centerOfMass = binaryReader.ReadVector3();
            density = binaryReader.ReadSingle();
            gravityScale = binaryReader.ReadSingle();
            groundFriction = binaryReader.ReadSingle();
            groundDepth = binaryReader.ReadSingle();
            groundDampFraction = binaryReader.ReadSingle();
            groundNormalK1 = binaryReader.ReadSingle();
            groundNormalK0 = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(4);
            waterFriction = binaryReader.ReadSingle();
            waterDepth = binaryReader.ReadSingle();
            waterDensity = binaryReader.ReadSingle();
            invalidName_0 = binaryReader.ReadBytes(4);
            airFriction = binaryReader.ReadSingle();
            invalidName_1 = binaryReader.ReadBytes(4);
            xxMoment = binaryReader.ReadSingle();
            yyMoment = binaryReader.ReadSingle();
            zzMoment = binaryReader.ReadSingle();
            inertialMatrixAndInverse = Guerilla.ReadBlockArray<InertialMatrixBlock>(binaryReader);
            poweredMassPoints = Guerilla.ReadBlockArray<PoweredMassPointBlock>(binaryReader);
            massPoints = Guerilla.ReadBlockArray<MassPointBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(radius);
                binaryWriter.Write(momentScale);
                binaryWriter.Write(mass);
                binaryWriter.Write(centerOfMass);
                binaryWriter.Write(density);
                binaryWriter.Write(gravityScale);
                binaryWriter.Write(groundFriction);
                binaryWriter.Write(groundDepth);
                binaryWriter.Write(groundDampFraction);
                binaryWriter.Write(groundNormalK1);
                binaryWriter.Write(groundNormalK0);
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(waterFriction);
                binaryWriter.Write(waterDepth);
                binaryWriter.Write(waterDensity);
                binaryWriter.Write(invalidName_0, 0, 4);
                binaryWriter.Write(airFriction);
                binaryWriter.Write(invalidName_1, 0, 4);
                binaryWriter.Write(xxMoment);
                binaryWriter.Write(yyMoment);
                binaryWriter.Write(zzMoment);
                nextAddress = Guerilla.WriteBlockArray<InertialMatrixBlock>(binaryWriter, inertialMatrixAndInverse, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<PoweredMassPointBlock>(binaryWriter, poweredMassPoints, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<MassPointBlock>(binaryWriter, massPoints, nextAddress);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
