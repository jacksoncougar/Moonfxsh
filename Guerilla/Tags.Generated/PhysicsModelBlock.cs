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
        public static readonly TagClass Phmo = (TagClass)"phmo";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("phmo")]
    public partial class PhysicsModelBlock : PhysicsModelBlockBase
    {
        public  PhysicsModelBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  PhysicsModelBlock(): base()
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
        
        public override int SerializedSize{get { return 272; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  PhysicsModelBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt32();
            mass = binaryReader.ReadSingle();
            lowFreqDeactivationScale = binaryReader.ReadSingle();
            highFreqDeactivationScale = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(24);
            phantomTypes = Guerilla.ReadBlockArray<PhantomTypesBlock>(binaryReader);
            nodeEdges = Guerilla.ReadBlockArray<PhysicsModelNodeConstraintEdgeBlock>(binaryReader);
            rigidBodies = Guerilla.ReadBlockArray<RigidBodiesBlock>(binaryReader);
            materials = Guerilla.ReadBlockArray<MaterialsBlock>(binaryReader);
            spheres = Guerilla.ReadBlockArray<SpheresBlock>(binaryReader);
            multiSpheres = Guerilla.ReadBlockArray<MultiSpheresBlock>(binaryReader);
            pills = Guerilla.ReadBlockArray<PillsBlock>(binaryReader);
            boxes = Guerilla.ReadBlockArray<BoxesBlock>(binaryReader);
            triangles = Guerilla.ReadBlockArray<TrianglesBlock>(binaryReader);
            polyhedra = Guerilla.ReadBlockArray<PolyhedraBlock>(binaryReader);
            polyhedronFourVectors = Guerilla.ReadBlockArray<PolyhedronFourVectorsBlock>(binaryReader);
            polyhedronPlaneEquations = Guerilla.ReadBlockArray<PolyhedronPlaneEquationsBlock>(binaryReader);
            massDistributions = Guerilla.ReadBlockArray<MassDistributionsBlock>(binaryReader);
            lists = Guerilla.ReadBlockArray<ListsBlock>(binaryReader);
            listShapes = Guerilla.ReadBlockArray<ListShapesBlock>(binaryReader);
            mopps = Guerilla.ReadBlockArray<MoppsBlock>(binaryReader);
            moppCodes = Guerilla.ReadData(binaryReader);
            hingeConstraints = Guerilla.ReadBlockArray<HingeConstraintsBlock>(binaryReader);
            ragdollConstraints = Guerilla.ReadBlockArray<RagdollConstraintsBlock>(binaryReader);
            regions = Guerilla.ReadBlockArray<RegionsBlock>(binaryReader);
            nodes = Guerilla.ReadBlockArray<NodesBlock>(binaryReader);
            importInfo = Guerilla.ReadBlockArray<GlobalTagImportInfoBlock>(binaryReader);
            errors = Guerilla.ReadBlockArray<GlobalErrorReportCategoriesBlock>(binaryReader);
            pointToPathCurves = Guerilla.ReadBlockArray<PointToPathCurveBlock>(binaryReader);
            limitedHingeConstraints = Guerilla.ReadBlockArray<LimitedHingeConstraintsBlock>(binaryReader);
            ballAndSocketConstraints = Guerilla.ReadBlockArray<BallAndSocketConstraintsBlock>(binaryReader);
            stiffSpringConstraints = Guerilla.ReadBlockArray<StiffSpringConstraintsBlock>(binaryReader);
            prismaticConstraints = Guerilla.ReadBlockArray<PrismaticConstraintsBlock>(binaryReader);
            phantoms = Guerilla.ReadBlockArray<PhantomsBlock>(binaryReader);
        }
        public  PhysicsModelBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt32();
            mass = binaryReader.ReadSingle();
            lowFreqDeactivationScale = binaryReader.ReadSingle();
            highFreqDeactivationScale = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(24);
            phantomTypes = Guerilla.ReadBlockArray<PhantomTypesBlock>(binaryReader);
            nodeEdges = Guerilla.ReadBlockArray<PhysicsModelNodeConstraintEdgeBlock>(binaryReader);
            rigidBodies = Guerilla.ReadBlockArray<RigidBodiesBlock>(binaryReader);
            materials = Guerilla.ReadBlockArray<MaterialsBlock>(binaryReader);
            spheres = Guerilla.ReadBlockArray<SpheresBlock>(binaryReader);
            multiSpheres = Guerilla.ReadBlockArray<MultiSpheresBlock>(binaryReader);
            pills = Guerilla.ReadBlockArray<PillsBlock>(binaryReader);
            boxes = Guerilla.ReadBlockArray<BoxesBlock>(binaryReader);
            triangles = Guerilla.ReadBlockArray<TrianglesBlock>(binaryReader);
            polyhedra = Guerilla.ReadBlockArray<PolyhedraBlock>(binaryReader);
            polyhedronFourVectors = Guerilla.ReadBlockArray<PolyhedronFourVectorsBlock>(binaryReader);
            polyhedronPlaneEquations = Guerilla.ReadBlockArray<PolyhedronPlaneEquationsBlock>(binaryReader);
            massDistributions = Guerilla.ReadBlockArray<MassDistributionsBlock>(binaryReader);
            lists = Guerilla.ReadBlockArray<ListsBlock>(binaryReader);
            listShapes = Guerilla.ReadBlockArray<ListShapesBlock>(binaryReader);
            mopps = Guerilla.ReadBlockArray<MoppsBlock>(binaryReader);
            moppCodes = Guerilla.ReadData(binaryReader);
            hingeConstraints = Guerilla.ReadBlockArray<HingeConstraintsBlock>(binaryReader);
            ragdollConstraints = Guerilla.ReadBlockArray<RagdollConstraintsBlock>(binaryReader);
            regions = Guerilla.ReadBlockArray<RegionsBlock>(binaryReader);
            nodes = Guerilla.ReadBlockArray<NodesBlock>(binaryReader);
            importInfo = Guerilla.ReadBlockArray<GlobalTagImportInfoBlock>(binaryReader);
            errors = Guerilla.ReadBlockArray<GlobalErrorReportCategoriesBlock>(binaryReader);
            pointToPathCurves = Guerilla.ReadBlockArray<PointToPathCurveBlock>(binaryReader);
            limitedHingeConstraints = Guerilla.ReadBlockArray<LimitedHingeConstraintsBlock>(binaryReader);
            ballAndSocketConstraints = Guerilla.ReadBlockArray<BallAndSocketConstraintsBlock>(binaryReader);
            stiffSpringConstraints = Guerilla.ReadBlockArray<StiffSpringConstraintsBlock>(binaryReader);
            prismaticConstraints = Guerilla.ReadBlockArray<PrismaticConstraintsBlock>(binaryReader);
            phantoms = Guerilla.ReadBlockArray<PhantomsBlock>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
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
