// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GlobalGeometryPointDataStructBlock : GlobalGeometryPointDataStructBlockBase
    {
        public  GlobalGeometryPointDataStructBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 32)]
    public class GlobalGeometryPointDataStructBlockBase
    {
        internal GlobalGeometryRawPointBlock[] rawPoints;
        internal byte[] runtimePointData;
        internal GlobalGeometryRigidPointGroupBlock[] rigidPointGroups;
        internal GlobalGeometryPointDataIndexBlock[] vertexPointIndices;
        internal  GlobalGeometryPointDataStructBlockBase(System.IO.BinaryReader binaryReader)
        {
            ReadGlobalGeometryRawPointBlockArray(binaryReader);
            runtimePointData = ReadData(binaryReader);
            ReadGlobalGeometryRigidPointGroupBlockArray(binaryReader);
            ReadGlobalGeometryPointDataIndexBlockArray(binaryReader);
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
        internal  virtual GlobalGeometryRawPointBlock[] ReadGlobalGeometryRawPointBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalGeometryRawPointBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalGeometryRawPointBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalGeometryRawPointBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GlobalGeometryRigidPointGroupBlock[] ReadGlobalGeometryRigidPointGroupBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalGeometryRigidPointGroupBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalGeometryRigidPointGroupBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalGeometryRigidPointGroupBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GlobalGeometryPointDataIndexBlock[] ReadGlobalGeometryPointDataIndexBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalGeometryPointDataIndexBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalGeometryPointDataIndexBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalGeometryPointDataIndexBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGlobalGeometryRawPointBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGlobalGeometryRigidPointGroupBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGlobalGeometryPointDataIndexBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                WriteGlobalGeometryRawPointBlockArray(binaryWriter);
                WriteData(binaryWriter);
                WriteGlobalGeometryRigidPointGroupBlockArray(binaryWriter);
                WriteGlobalGeometryPointDataIndexBlockArray(binaryWriter);
            }
        }
    };
}
