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
        public  GlobalGeometryPointDataStructBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  GlobalGeometryPointDataStructBlockBase(BinaryReader binaryReader)
        {
            this.rawPoints = ReadGlobalGeometryRawPointBlockArray(binaryReader);
            this.runtimePointData = ReadData(binaryReader);
            this.rigidPointGroups = ReadGlobalGeometryRigidPointGroupBlockArray(binaryReader);
            this.vertexPointIndices = ReadGlobalGeometryPointDataIndexBlockArray(binaryReader);
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
        internal  virtual GlobalGeometryRawPointBlock[] ReadGlobalGeometryRawPointBlockArray(BinaryReader binaryReader)
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
        internal  virtual GlobalGeometryRigidPointGroupBlock[] ReadGlobalGeometryRigidPointGroupBlockArray(BinaryReader binaryReader)
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
        internal  virtual GlobalGeometryPointDataIndexBlock[] ReadGlobalGeometryPointDataIndexBlockArray(BinaryReader binaryReader)
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
    };
}
