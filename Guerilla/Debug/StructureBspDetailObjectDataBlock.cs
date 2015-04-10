// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class StructureBspDetailObjectDataBlock : StructureBspDetailObjectDataBlockBase
    {
        public  StructureBspDetailObjectDataBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 36)]
    public class StructureBspDetailObjectDataBlockBase
    {
        internal GlobalDetailObjectCellsBlock[] cells;
        internal GlobalDetailObjectBlock[] instances;
        internal GlobalDetailObjectCountsBlock[] counts;
        internal GlobalZReferenceVectorBlock[] zReferenceVectors;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal  StructureBspDetailObjectDataBlockBase(System.IO.BinaryReader binaryReader)
        {
            ReadGlobalDetailObjectCellsBlockArray(binaryReader);
            ReadGlobalDetailObjectBlockArray(binaryReader);
            ReadGlobalDetailObjectCountsBlockArray(binaryReader);
            ReadGlobalZReferenceVectorBlockArray(binaryReader);
            invalidName_ = binaryReader.ReadBytes(1);
            invalidName_0 = binaryReader.ReadBytes(3);
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
        internal  virtual GlobalDetailObjectCellsBlock[] ReadGlobalDetailObjectCellsBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalDetailObjectCellsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalDetailObjectCellsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalDetailObjectCellsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GlobalDetailObjectBlock[] ReadGlobalDetailObjectBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalDetailObjectBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalDetailObjectBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalDetailObjectBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GlobalDetailObjectCountsBlock[] ReadGlobalDetailObjectCountsBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalDetailObjectCountsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalDetailObjectCountsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalDetailObjectCountsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GlobalZReferenceVectorBlock[] ReadGlobalZReferenceVectorBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalZReferenceVectorBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalZReferenceVectorBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalZReferenceVectorBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGlobalDetailObjectCellsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGlobalDetailObjectBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGlobalDetailObjectCountsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGlobalZReferenceVectorBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                WriteGlobalDetailObjectCellsBlockArray(binaryWriter);
                WriteGlobalDetailObjectBlockArray(binaryWriter);
                WriteGlobalDetailObjectCountsBlockArray(binaryWriter);
                WriteGlobalZReferenceVectorBlockArray(binaryWriter);
                binaryWriter.Write(invalidName_, 0, 1);
                binaryWriter.Write(invalidName_0, 0, 3);
            }
        }
    };
}
