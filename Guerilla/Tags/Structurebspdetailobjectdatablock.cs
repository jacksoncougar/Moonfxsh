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
        public  StructureBspDetailObjectDataBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 36, Alignment = 4)]
    public class StructureBspDetailObjectDataBlockBase  : IGuerilla
    {
        internal GlobalDetailObjectCellsBlock[] cells;
        internal GlobalDetailObjectBlock[] instances;
        internal GlobalDetailObjectCountsBlock[] counts;
        internal GlobalZReferenceVectorBlock[] zReferenceVectors;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal  StructureBspDetailObjectDataBlockBase(BinaryReader binaryReader)
        {
            cells = Guerilla.ReadBlockArray<GlobalDetailObjectCellsBlock>(binaryReader);
            instances = Guerilla.ReadBlockArray<GlobalDetailObjectBlock>(binaryReader);
            counts = Guerilla.ReadBlockArray<GlobalDetailObjectCountsBlock>(binaryReader);
            zReferenceVectors = Guerilla.ReadBlockArray<GlobalZReferenceVectorBlock>(binaryReader);
            invalidName_ = binaryReader.ReadBytes(1);
            invalidName_0 = binaryReader.ReadBytes(3);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<GlobalDetailObjectCellsBlock>(binaryWriter, cells, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GlobalDetailObjectBlock>(binaryWriter, instances, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GlobalDetailObjectCountsBlock>(binaryWriter, counts, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GlobalZReferenceVectorBlock>(binaryWriter, zReferenceVectors, nextAddress);
                binaryWriter.Write(invalidName_, 0, 1);
                binaryWriter.Write(invalidName_0, 0, 3);
                return nextAddress;
            }
        }
    };
}
