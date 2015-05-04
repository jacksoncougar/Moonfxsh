// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Phys = (TagClass)"phys";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("phys")]
    public partial class PhysicsBlock : PhysicsBlockBase
    {
        public PhysicsBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 116, Alignment = 4)]
    public class PhysicsBlockBase : GuerillaBlock
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
        public override int SerializedSize { get { return 116; } }
        public override int Alignment { get { return 4; } }
        public PhysicsBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
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
            blamPointers.Enqueue(ReadBlockArrayPointer<InertialMatrixBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<PoweredMassPointBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<MassPointBlock>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            inertialMatrixAndInverse = ReadBlockArrayData<InertialMatrixBlock>(binaryReader, blamPointers.Dequeue());
            poweredMassPoints = ReadBlockArrayData<PoweredMassPointBlock>(binaryReader, blamPointers.Dequeue());
            massPoints = ReadBlockArrayData<MassPointBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
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
                return nextAddress;
            }
        }
    };
}
