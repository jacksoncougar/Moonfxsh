using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GlobalCollisionBspStructBlock : GlobalCollisionBspStructBlockBase
    {
        public  GlobalCollisionBspStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 64)]
    public class GlobalCollisionBspStructBlockBase
    {
        internal Bsp3dNodesBlock[] bSP3DNodes;
        internal PlanesBlock[] planes;
        internal LeavesBlock[] leaves;
        internal Bsp2dReferencesBlock[] bSP2DReferences;
        internal Bsp2dNodesBlock[] bSP2DNodes;
        internal SurfacesBlock[] surfaces;
        internal EdgesBlock[] edges;
        internal VerticesBlock[] vertices;
        internal  GlobalCollisionBspStructBlockBase(BinaryReader binaryReader)
        {
            this.bSP3DNodes = ReadBsp3dNodesBlockArray(binaryReader);
            this.planes = ReadPlanesBlockArray(binaryReader);
            this.leaves = ReadLeavesBlockArray(binaryReader);
            this.bSP2DReferences = ReadBsp2dReferencesBlockArray(binaryReader);
            this.bSP2DNodes = ReadBsp2dNodesBlockArray(binaryReader);
            this.surfaces = ReadSurfacesBlockArray(binaryReader);
            this.edges = ReadEdgesBlockArray(binaryReader);
            this.vertices = ReadVerticesBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
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
        internal  virtual Bsp3dNodesBlock[] ReadBsp3dNodesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(Bsp3dNodesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new Bsp3dNodesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new Bsp3dNodesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PlanesBlock[] ReadPlanesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PlanesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PlanesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PlanesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual LeavesBlock[] ReadLeavesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(LeavesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new LeavesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new LeavesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual Bsp2dReferencesBlock[] ReadBsp2dReferencesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(Bsp2dReferencesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new Bsp2dReferencesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new Bsp2dReferencesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual Bsp2dNodesBlock[] ReadBsp2dNodesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(Bsp2dNodesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new Bsp2dNodesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new Bsp2dNodesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SurfacesBlock[] ReadSurfacesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SurfacesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SurfacesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SurfacesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual EdgesBlock[] ReadEdgesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(EdgesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new EdgesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new EdgesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual VerticesBlock[] ReadVerticesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(VerticesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new VerticesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new VerticesBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
