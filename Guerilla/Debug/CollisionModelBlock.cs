// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("coll")]
    public  partial class CollisionModelBlock : CollisionModelBlockBase
    {
        public  CollisionModelBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 52)]
    public class CollisionModelBlockBase
    {
        internal GlobalTagImportInfoBlock[] importInfo;
        internal GlobalErrorReportCategoriesBlock[] errors;
        internal Flags flags;
        internal CollisionModelMaterialBlock[] materials;
        internal CollisionModelRegionBlock[] regions;
        internal CollisionModelPathfindingSphereBlock[] pathfindingSpheres;
        internal CollisionModelNodeBlock[] nodes;
        internal  CollisionModelBlockBase(System.IO.BinaryReader binaryReader)
        {
            ReadGlobalTagImportInfoBlockArray(binaryReader);
            ReadGlobalErrorReportCategoriesBlockArray(binaryReader);
            flags = (Flags)binaryReader.ReadInt32();
            ReadCollisionModelMaterialBlockArray(binaryReader);
            ReadCollisionModelRegionBlockArray(binaryReader);
            ReadCollisionModelPathfindingSphereBlockArray(binaryReader);
            ReadCollisionModelNodeBlockArray(binaryReader);
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
        internal  virtual CollisionModelMaterialBlock[] ReadCollisionModelMaterialBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CollisionModelMaterialBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CollisionModelMaterialBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CollisionModelMaterialBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CollisionModelRegionBlock[] ReadCollisionModelRegionBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CollisionModelRegionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CollisionModelRegionBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CollisionModelRegionBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CollisionModelPathfindingSphereBlock[] ReadCollisionModelPathfindingSphereBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CollisionModelPathfindingSphereBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CollisionModelPathfindingSphereBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CollisionModelPathfindingSphereBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CollisionModelNodeBlock[] ReadCollisionModelNodeBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CollisionModelNodeBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CollisionModelNodeBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CollisionModelNodeBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGlobalTagImportInfoBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGlobalErrorReportCategoriesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteCollisionModelMaterialBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteCollisionModelRegionBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteCollisionModelPathfindingSphereBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteCollisionModelNodeBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                WriteGlobalTagImportInfoBlockArray(binaryWriter);
                WriteGlobalErrorReportCategoriesBlockArray(binaryWriter);
                binaryWriter.Write((Int32)flags);
                WriteCollisionModelMaterialBlockArray(binaryWriter);
                WriteCollisionModelRegionBlockArray(binaryWriter);
                WriteCollisionModelPathfindingSphereBlockArray(binaryWriter);
                WriteCollisionModelNodeBlockArray(binaryWriter);
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        
        {
            ContainsOpenEdges = 1,
        };
    };
}
