// ReSharper disable All
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
        public  GlobalCollisionBspStructBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  GlobalCollisionBspStructBlockBase(System.IO.BinaryReader binaryReader)
        {
            ReadBsp3dNodesBlockArray(binaryReader);
            ReadPlanesBlockArray(binaryReader);
            ReadLeavesBlockArray(binaryReader);
            ReadBsp2dReferencesBlockArray(binaryReader);
            ReadBsp2dNodesBlockArray(binaryReader);
            ReadSurfacesBlockArray(binaryReader);
            ReadEdgesBlockArray(binaryReader);
            ReadVerticesBlockArray(binaryReader);
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
        internal  virtual Bsp3dNodesBlock[] ReadBsp3dNodesBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual PlanesBlock[] ReadPlanesBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual LeavesBlock[] ReadLeavesBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual Bsp2dReferencesBlock[] ReadBsp2dReferencesBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual Bsp2dNodesBlock[] ReadBsp2dNodesBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual SurfacesBlock[] ReadSurfacesBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual EdgesBlock[] ReadEdgesBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual VerticesBlock[] ReadVerticesBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteBsp3dNodesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WritePlanesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteLeavesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteBsp2dReferencesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteBsp2dNodesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteSurfacesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteEdgesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteVerticesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                WriteBsp3dNodesBlockArray(binaryWriter);
                WritePlanesBlockArray(binaryWriter);
                WriteLeavesBlockArray(binaryWriter);
                WriteBsp2dReferencesBlockArray(binaryWriter);
                WriteBsp2dNodesBlockArray(binaryWriter);
                WriteSurfacesBlockArray(binaryWriter);
                WriteEdgesBlockArray(binaryWriter);
                WriteVerticesBlockArray(binaryWriter);
            }
        }
    };
}
