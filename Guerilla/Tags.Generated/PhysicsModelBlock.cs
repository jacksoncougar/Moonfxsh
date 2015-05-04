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
        public static readonly TagClass Phmo = (TagClass)"phmo";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("phmo")]
    public partial class PhysicsModelBlock : PhysicsModelBlockBase
    {
        public PhysicsModelBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 272, Alignment = 4)]
    public class PhysicsModelBlockBase : GuerillaBlock
    {
        internal Flags flags;
        internal float mass;
        /// <summary>
        /// 0 is default (1). LESS than 1 deactivates less aggressively. GREATER than 1 is more agressive.
        /// </summary>
        internal float lowFreqDeactivationScale;
        /// <summary>
        /// 0 is default (1). LESS than 1 deactivates less aggressively. GREATER than 1 is more agressive.
        /// </summary>
        internal float highFreqDeactivationScale;
        internal byte[] invalidName_;
        internal PhantomTypesBlock[] phantomTypes;
        internal PhysicsModelNodeConstraintEdgeBlock[] nodeEdges;
        internal RigidBodiesBlock[] rigidBodies;
        internal MaterialsBlock[] materials;
        internal SpheresBlock[] spheres;
        internal MultiSpheresBlock[] multiSpheres;
        internal PillsBlock[] pills;
        internal BoxesBlock[] boxes;
        internal TrianglesBlock[] triangles;
        internal PolyhedraBlock[] polyhedra;
        internal PolyhedronFourVectorsBlock[] polyhedronFourVectors;
        internal PolyhedronPlaneEquationsBlock[] polyhedronPlaneEquations;
        internal MassDistributionsBlock[] massDistributions;
        internal ListsBlock[] lists;
        internal ListShapesBlock[] listShapes;
        internal MoppsBlock[] mopps;
        internal byte[] moppCodes;
        internal HingeConstraintsBlock[] hingeConstraints;
        internal RagdollConstraintsBlock[] ragdollConstraints;
        internal RegionsBlock[] regions;
        internal NodesBlock[] nodes;
        internal GlobalTagImportInfoBlock[] importInfo;
        internal GlobalErrorReportCategoriesBlock[] errors;
        internal PointToPathCurveBlock[] pointToPathCurves;
        internal LimitedHingeConstraintsBlock[] limitedHingeConstraints;
        internal BallAndSocketConstraintsBlock[] ballAndSocketConstraints;
        internal StiffSpringConstraintsBlock[] stiffSpringConstraints;
        internal PrismaticConstraintsBlock[] prismaticConstraints;
        internal PhantomsBlock[] phantoms;
        public override int SerializedSize { get { return 272; } }
        public override int Alignment { get { return 4; } }
        public PhysicsModelBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            flags = (Flags)binaryReader.ReadInt32();
            mass = binaryReader.ReadSingle();
            lowFreqDeactivationScale = binaryReader.ReadSingle();
            highFreqDeactivationScale = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(24);
            blamPointers.Enqueue(ReadBlockArrayPointer<PhantomTypesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<PhysicsModelNodeConstraintEdgeBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<RigidBodiesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<MaterialsBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<SpheresBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<MultiSpheresBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<PillsBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<BoxesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<TrianglesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<PolyhedraBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<PolyhedronFourVectorsBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<PolyhedronPlaneEquationsBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<MassDistributionsBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ListsBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ListShapesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<MoppsBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer(binaryReader, 1));
            blamPointers.Enqueue(ReadBlockArrayPointer<HingeConstraintsBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<RagdollConstraintsBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<RegionsBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<NodesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<GlobalTagImportInfoBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<GlobalErrorReportCategoriesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<PointToPathCurveBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<LimitedHingeConstraintsBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<BallAndSocketConstraintsBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<StiffSpringConstraintsBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<PrismaticConstraintsBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<PhantomsBlock>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            phantomTypes = ReadBlockArrayData<PhantomTypesBlock>(binaryReader, blamPointers.Dequeue());
            nodeEdges = ReadBlockArrayData<PhysicsModelNodeConstraintEdgeBlock>(binaryReader, blamPointers.Dequeue());
            rigidBodies = ReadBlockArrayData<RigidBodiesBlock>(binaryReader, blamPointers.Dequeue());
            materials = ReadBlockArrayData<MaterialsBlock>(binaryReader, blamPointers.Dequeue());
            spheres = ReadBlockArrayData<SpheresBlock>(binaryReader, blamPointers.Dequeue());
            multiSpheres = ReadBlockArrayData<MultiSpheresBlock>(binaryReader, blamPointers.Dequeue());
            pills = ReadBlockArrayData<PillsBlock>(binaryReader, blamPointers.Dequeue());
            boxes = ReadBlockArrayData<BoxesBlock>(binaryReader, blamPointers.Dequeue());
            triangles = ReadBlockArrayData<TrianglesBlock>(binaryReader, blamPointers.Dequeue());
            polyhedra = ReadBlockArrayData<PolyhedraBlock>(binaryReader, blamPointers.Dequeue());
            polyhedronFourVectors = ReadBlockArrayData<PolyhedronFourVectorsBlock>(binaryReader, blamPointers.Dequeue());
            polyhedronPlaneEquations = ReadBlockArrayData<PolyhedronPlaneEquationsBlock>(binaryReader, blamPointers.Dequeue());
            massDistributions = ReadBlockArrayData<MassDistributionsBlock>(binaryReader, blamPointers.Dequeue());
            lists = ReadBlockArrayData<ListsBlock>(binaryReader, blamPointers.Dequeue());
            listShapes = ReadBlockArrayData<ListShapesBlock>(binaryReader, blamPointers.Dequeue());
            mopps = ReadBlockArrayData<MoppsBlock>(binaryReader, blamPointers.Dequeue());
            moppCodes = ReadDataByteArray(binaryReader, blamPointers.Dequeue());
            hingeConstraints = ReadBlockArrayData<HingeConstraintsBlock>(binaryReader, blamPointers.Dequeue());
            ragdollConstraints = ReadBlockArrayData<RagdollConstraintsBlock>(binaryReader, blamPointers.Dequeue());
            regions = ReadBlockArrayData<RegionsBlock>(binaryReader, blamPointers.Dequeue());
            nodes = ReadBlockArrayData<NodesBlock>(binaryReader, blamPointers.Dequeue());
            importInfo = ReadBlockArrayData<GlobalTagImportInfoBlock>(binaryReader, blamPointers.Dequeue());
            errors = ReadBlockArrayData<GlobalErrorReportCategoriesBlock>(binaryReader, blamPointers.Dequeue());
            pointToPathCurves = ReadBlockArrayData<PointToPathCurveBlock>(binaryReader, blamPointers.Dequeue());
            limitedHingeConstraints = ReadBlockArrayData<LimitedHingeConstraintsBlock>(binaryReader, blamPointers.Dequeue());
            ballAndSocketConstraints = ReadBlockArrayData<BallAndSocketConstraintsBlock>(binaryReader, blamPointers.Dequeue());
            stiffSpringConstraints = ReadBlockArrayData<StiffSpringConstraintsBlock>(binaryReader, blamPointers.Dequeue());
            prismaticConstraints = ReadBlockArrayData<PrismaticConstraintsBlock>(binaryReader, blamPointers.Dequeue());
            phantoms = ReadBlockArrayData<PhantomsBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write(mass);
                binaryWriter.Write(lowFreqDeactivationScale);
                binaryWriter.Write(highFreqDeactivationScale);
                binaryWriter.Write(invalidName_, 0, 24);
                nextAddress = Guerilla.WriteBlockArray<PhantomTypesBlock>(binaryWriter, phantomTypes, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<PhysicsModelNodeConstraintEdgeBlock>(binaryWriter, nodeEdges, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<RigidBodiesBlock>(binaryWriter, rigidBodies, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<MaterialsBlock>(binaryWriter, materials, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<SpheresBlock>(binaryWriter, spheres, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<MultiSpheresBlock>(binaryWriter, multiSpheres, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<PillsBlock>(binaryWriter, pills, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<BoxesBlock>(binaryWriter, boxes, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<TrianglesBlock>(binaryWriter, triangles, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<PolyhedraBlock>(binaryWriter, polyhedra, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<PolyhedronFourVectorsBlock>(binaryWriter, polyhedronFourVectors, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<PolyhedronPlaneEquationsBlock>(binaryWriter, polyhedronPlaneEquations, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<MassDistributionsBlock>(binaryWriter, massDistributions, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ListsBlock>(binaryWriter, lists, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ListShapesBlock>(binaryWriter, listShapes, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<MoppsBlock>(binaryWriter, mopps, nextAddress);
                nextAddress = Guerilla.WriteData(binaryWriter, moppCodes, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<HingeConstraintsBlock>(binaryWriter, hingeConstraints, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<RagdollConstraintsBlock>(binaryWriter, ragdollConstraints, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<RegionsBlock>(binaryWriter, regions, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<NodesBlock>(binaryWriter, nodes, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GlobalTagImportInfoBlock>(binaryWriter, importInfo, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GlobalErrorReportCategoriesBlock>(binaryWriter, errors, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<PointToPathCurveBlock>(binaryWriter, pointToPathCurves, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<LimitedHingeConstraintsBlock>(binaryWriter, limitedHingeConstraints, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<BallAndSocketConstraintsBlock>(binaryWriter, ballAndSocketConstraints, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StiffSpringConstraintsBlock>(binaryWriter, stiffSpringConstraints, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<PrismaticConstraintsBlock>(binaryWriter, prismaticConstraints, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<PhantomsBlock>(binaryWriter, phantoms, nextAddress);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        {
            Unused = 1,
        };
    };
}
