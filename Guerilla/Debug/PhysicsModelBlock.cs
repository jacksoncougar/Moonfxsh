// ReSharper disable All
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
        public  PhysicsModelBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  PhysicsModelBlockBase(System.IO.BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt32();
            mass = binaryReader.ReadSingle();
            lowFreqDeactivationScale = binaryReader.ReadSingle();
            highFreqDeactivationScale = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(24);
            ReadPhantomTypesBlockArray(binaryReader);
            ReadPhysicsModelNodeConstraintEdgeBlockArray(binaryReader);
            ReadRigidBodiesBlockArray(binaryReader);
            ReadMaterialsBlockArray(binaryReader);
            ReadSpheresBlockArray(binaryReader);
            ReadMultiSpheresBlockArray(binaryReader);
            ReadPillsBlockArray(binaryReader);
            ReadBoxesBlockArray(binaryReader);
            ReadTrianglesBlockArray(binaryReader);
            ReadPolyhedraBlockArray(binaryReader);
            ReadPolyhedronFourVectorsBlockArray(binaryReader);
            ReadPolyhedronPlaneEquationsBlockArray(binaryReader);
            ReadMassDistributionsBlockArray(binaryReader);
            ReadListsBlockArray(binaryReader);
            ReadListShapesBlockArray(binaryReader);
            ReadMoppsBlockArray(binaryReader);
            moppCodes = ReadData(binaryReader);
            ReadHingeConstraintsBlockArray(binaryReader);
            ReadRagdollConstraintsBlockArray(binaryReader);
            ReadRegionsBlockArray(binaryReader);
            ReadNodesBlockArray(binaryReader);
            ReadGlobalTagImportInfoBlockArray(binaryReader);
            ReadGlobalErrorReportCategoriesBlockArray(binaryReader);
            ReadPointToPathCurveBlockArray(binaryReader);
            ReadLimitedHingeConstraintsBlockArray(binaryReader);
            ReadBallAndSocketConstraintsBlockArray(binaryReader);
            ReadStiffSpringConstraintsBlockArray(binaryReader);
            ReadPrismaticConstraintsBlockArray(binaryReader);
            ReadPhantomsBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
        internal  virtual PhantomTypesBlock[] ReadPhantomTypesBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PhantomTypesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PhantomTypesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PhantomTypesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PhysicsModelNodeConstraintEdgeBlock[] ReadPhysicsModelNodeConstraintEdgeBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PhysicsModelNodeConstraintEdgeBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PhysicsModelNodeConstraintEdgeBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PhysicsModelNodeConstraintEdgeBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual RigidBodiesBlock[] ReadRigidBodiesBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(RigidBodiesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new RigidBodiesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new RigidBodiesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual MaterialsBlock[] ReadMaterialsBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(MaterialsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new MaterialsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new MaterialsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SpheresBlock[] ReadSpheresBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SpheresBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SpheresBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SpheresBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual MultiSpheresBlock[] ReadMultiSpheresBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(MultiSpheresBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new MultiSpheresBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new MultiSpheresBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PillsBlock[] ReadPillsBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PillsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PillsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PillsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual BoxesBlock[] ReadBoxesBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(BoxesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new BoxesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new BoxesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual TrianglesBlock[] ReadTrianglesBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(TrianglesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new TrianglesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new TrianglesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PolyhedraBlock[] ReadPolyhedraBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PolyhedraBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PolyhedraBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PolyhedraBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PolyhedronFourVectorsBlock[] ReadPolyhedronFourVectorsBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PolyhedronFourVectorsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PolyhedronFourVectorsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PolyhedronFourVectorsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PolyhedronPlaneEquationsBlock[] ReadPolyhedronPlaneEquationsBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PolyhedronPlaneEquationsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PolyhedronPlaneEquationsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PolyhedronPlaneEquationsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual MassDistributionsBlock[] ReadMassDistributionsBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(MassDistributionsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new MassDistributionsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new MassDistributionsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ListsBlock[] ReadListsBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ListsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ListsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ListsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ListShapesBlock[] ReadListShapesBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ListShapesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ListShapesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ListShapesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual MoppsBlock[] ReadMoppsBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(MoppsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new MoppsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new MoppsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual HingeConstraintsBlock[] ReadHingeConstraintsBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(HingeConstraintsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new HingeConstraintsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new HingeConstraintsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual RagdollConstraintsBlock[] ReadRagdollConstraintsBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(RagdollConstraintsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new RagdollConstraintsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new RagdollConstraintsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual RegionsBlock[] ReadRegionsBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(RegionsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new RegionsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new RegionsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual NodesBlock[] ReadNodesBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(NodesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new NodesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new NodesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GlobalTagImportInfoBlock[] ReadGlobalTagImportInfoBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalTagImportInfoBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalTagImportInfoBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalTagImportInfoBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GlobalErrorReportCategoriesBlock[] ReadGlobalErrorReportCategoriesBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalErrorReportCategoriesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalErrorReportCategoriesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalErrorReportCategoriesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PointToPathCurveBlock[] ReadPointToPathCurveBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PointToPathCurveBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PointToPathCurveBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PointToPathCurveBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual LimitedHingeConstraintsBlock[] ReadLimitedHingeConstraintsBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(LimitedHingeConstraintsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new LimitedHingeConstraintsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new LimitedHingeConstraintsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual BallAndSocketConstraintsBlock[] ReadBallAndSocketConstraintsBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(BallAndSocketConstraintsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new BallAndSocketConstraintsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new BallAndSocketConstraintsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual StiffSpringConstraintsBlock[] ReadStiffSpringConstraintsBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StiffSpringConstraintsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StiffSpringConstraintsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StiffSpringConstraintsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PrismaticConstraintsBlock[] ReadPrismaticConstraintsBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PrismaticConstraintsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PrismaticConstraintsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PrismaticConstraintsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PhantomsBlock[] ReadPhantomsBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PhantomsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PhantomsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PhantomsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WritePhantomTypesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WritePhysicsModelNodeConstraintEdgeBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteRigidBodiesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteMaterialsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteSpheresBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteMultiSpheresBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WritePillsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteBoxesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteTrianglesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WritePolyhedraBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WritePolyhedronFourVectorsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WritePolyhedronPlaneEquationsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteMassDistributionsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteListsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteListShapesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteMoppsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteHingeConstraintsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteRagdollConstraintsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteRegionsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteNodesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGlobalTagImportInfoBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGlobalErrorReportCategoriesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WritePointToPathCurveBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteLimitedHingeConstraintsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteBallAndSocketConstraintsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteStiffSpringConstraintsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WritePrismaticConstraintsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WritePhantomsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write(mass);
                binaryWriter.Write(lowFreqDeactivationScale);
                binaryWriter.Write(highFreqDeactivationScale);
                binaryWriter.Write(invalidName_, 0, 24);
                WritePhantomTypesBlockArray(binaryWriter);
                WritePhysicsModelNodeConstraintEdgeBlockArray(binaryWriter);
                WriteRigidBodiesBlockArray(binaryWriter);
                WriteMaterialsBlockArray(binaryWriter);
                WriteSpheresBlockArray(binaryWriter);
                WriteMultiSpheresBlockArray(binaryWriter);
                WritePillsBlockArray(binaryWriter);
                WriteBoxesBlockArray(binaryWriter);
                WriteTrianglesBlockArray(binaryWriter);
                WritePolyhedraBlockArray(binaryWriter);
                WritePolyhedronFourVectorsBlockArray(binaryWriter);
                WritePolyhedronPlaneEquationsBlockArray(binaryWriter);
                WriteMassDistributionsBlockArray(binaryWriter);
                WriteListsBlockArray(binaryWriter);
                WriteListShapesBlockArray(binaryWriter);
                WriteMoppsBlockArray(binaryWriter);
                WriteData(binaryWriter);
                WriteHingeConstraintsBlockArray(binaryWriter);
                WriteRagdollConstraintsBlockArray(binaryWriter);
                WriteRegionsBlockArray(binaryWriter);
                WriteNodesBlockArray(binaryWriter);
                WriteGlobalTagImportInfoBlockArray(binaryWriter);
                WriteGlobalErrorReportCategoriesBlockArray(binaryWriter);
                WritePointToPathCurveBlockArray(binaryWriter);
                WriteLimitedHingeConstraintsBlockArray(binaryWriter);
                WriteBallAndSocketConstraintsBlockArray(binaryWriter);
                WriteStiffSpringConstraintsBlockArray(binaryWriter);
                WritePrismaticConstraintsBlockArray(binaryWriter);
                WritePhantomsBlockArray(binaryWriter);
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        
        {
            Unused = 1,
        };
    };
}
