using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("phmo")]
    public  partial class PhysicsModelBlock : PhysicsModelBlockBase
    {
        public  PhysicsModelBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 272)]
    public class PhysicsModelBlockBase
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
        internal  PhysicsModelBlockBase(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt32();
            this.mass = binaryReader.ReadSingle();
            this.lowFreqDeactivationScale = binaryReader.ReadSingle();
            this.highFreqDeactivationScale = binaryReader.ReadSingle();
            this.invalidName_ = binaryReader.ReadBytes(24);
            this.phantomTypes = ReadPhantomTypesBlockArray(binaryReader);
            this.nodeEdges = ReadPhysicsModelNodeConstraintEdgeBlockArray(binaryReader);
            this.rigidBodies = ReadRigidBodiesBlockArray(binaryReader);
            this.materials = ReadMaterialsBlockArray(binaryReader);
            this.spheres = ReadSpheresBlockArray(binaryReader);
            this.multiSpheres = ReadMultiSpheresBlockArray(binaryReader);
            this.pills = ReadPillsBlockArray(binaryReader);
            this.boxes = ReadBoxesBlockArray(binaryReader);
            this.triangles = ReadTrianglesBlockArray(binaryReader);
            this.polyhedra = ReadPolyhedraBlockArray(binaryReader);
            this.polyhedronFourVectors = ReadPolyhedronFourVectorsBlockArray(binaryReader);
            this.polyhedronPlaneEquations = ReadPolyhedronPlaneEquationsBlockArray(binaryReader);
            this.massDistributions = ReadMassDistributionsBlockArray(binaryReader);
            this.lists = ReadListsBlockArray(binaryReader);
            this.listShapes = ReadListShapesBlockArray(binaryReader);
            this.mopps = ReadMoppsBlockArray(binaryReader);
            this.moppCodes = ReadData(binaryReader);
            this.hingeConstraints = ReadHingeConstraintsBlockArray(binaryReader);
            this.ragdollConstraints = ReadRagdollConstraintsBlockArray(binaryReader);
            this.regions = ReadRegionsBlockArray(binaryReader);
            this.nodes = ReadNodesBlockArray(binaryReader);
            this.importInfo = ReadGlobalTagImportInfoBlockArray(binaryReader);
            this.errors = ReadGlobalErrorReportCategoriesBlockArray(binaryReader);
            this.pointToPathCurves = ReadPointToPathCurveBlockArray(binaryReader);
            this.limitedHingeConstraints = ReadLimitedHingeConstraintsBlockArray(binaryReader);
            this.ballAndSocketConstraints = ReadBallAndSocketConstraintsBlockArray(binaryReader);
            this.stiffSpringConstraints = ReadStiffSpringConstraintsBlockArray(binaryReader);
            this.prismaticConstraints = ReadPrismaticConstraintsBlockArray(binaryReader);
            this.phantoms = ReadPhantomsBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
        }
        internal  virtual PhantomTypesBlock[] ReadPhantomTypesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PhantomTypesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PhantomTypesBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PhantomTypesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PhysicsModelNodeConstraintEdgeBlock[] ReadPhysicsModelNodeConstraintEdgeBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PhysicsModelNodeConstraintEdgeBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PhysicsModelNodeConstraintEdgeBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PhysicsModelNodeConstraintEdgeBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual RigidBodiesBlock[] ReadRigidBodiesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(RigidBodiesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new RigidBodiesBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new RigidBodiesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual MaterialsBlock[] ReadMaterialsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(MaterialsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new MaterialsBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new MaterialsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SpheresBlock[] ReadSpheresBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SpheresBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SpheresBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SpheresBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual MultiSpheresBlock[] ReadMultiSpheresBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(MultiSpheresBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new MultiSpheresBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new MultiSpheresBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PillsBlock[] ReadPillsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PillsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PillsBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PillsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual BoxesBlock[] ReadBoxesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(BoxesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new BoxesBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new BoxesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual TrianglesBlock[] ReadTrianglesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(TrianglesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new TrianglesBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new TrianglesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PolyhedraBlock[] ReadPolyhedraBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PolyhedraBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PolyhedraBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PolyhedraBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PolyhedronFourVectorsBlock[] ReadPolyhedronFourVectorsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PolyhedronFourVectorsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PolyhedronFourVectorsBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PolyhedronFourVectorsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PolyhedronPlaneEquationsBlock[] ReadPolyhedronPlaneEquationsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PolyhedronPlaneEquationsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PolyhedronPlaneEquationsBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PolyhedronPlaneEquationsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual MassDistributionsBlock[] ReadMassDistributionsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(MassDistributionsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new MassDistributionsBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new MassDistributionsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ListsBlock[] ReadListsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ListsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ListsBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ListsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ListShapesBlock[] ReadListShapesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ListShapesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ListShapesBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ListShapesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual MoppsBlock[] ReadMoppsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(MoppsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new MoppsBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new MoppsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual HingeConstraintsBlock[] ReadHingeConstraintsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(HingeConstraintsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new HingeConstraintsBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new HingeConstraintsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual RagdollConstraintsBlock[] ReadRagdollConstraintsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(RagdollConstraintsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new RagdollConstraintsBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new RagdollConstraintsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual RegionsBlock[] ReadRegionsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(RegionsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new RegionsBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new RegionsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual NodesBlock[] ReadNodesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(NodesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new NodesBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new NodesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GlobalTagImportInfoBlock[] ReadGlobalTagImportInfoBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalTagImportInfoBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalTagImportInfoBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalTagImportInfoBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GlobalErrorReportCategoriesBlock[] ReadGlobalErrorReportCategoriesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalErrorReportCategoriesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalErrorReportCategoriesBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalErrorReportCategoriesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PointToPathCurveBlock[] ReadPointToPathCurveBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PointToPathCurveBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PointToPathCurveBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PointToPathCurveBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual LimitedHingeConstraintsBlock[] ReadLimitedHingeConstraintsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(LimitedHingeConstraintsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new LimitedHingeConstraintsBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new LimitedHingeConstraintsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual BallAndSocketConstraintsBlock[] ReadBallAndSocketConstraintsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(BallAndSocketConstraintsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new BallAndSocketConstraintsBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new BallAndSocketConstraintsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual StiffSpringConstraintsBlock[] ReadStiffSpringConstraintsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StiffSpringConstraintsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StiffSpringConstraintsBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StiffSpringConstraintsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PrismaticConstraintsBlock[] ReadPrismaticConstraintsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PrismaticConstraintsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PrismaticConstraintsBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PrismaticConstraintsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PhantomsBlock[] ReadPhantomsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PhantomsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PhantomsBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PhantomsBlock(binaryReader);
                }
            }
            return array;
        }
        [FlagsAttribute]
        internal enum Flags : int
        
        {
            Unused = 1,
        };
    };
}
