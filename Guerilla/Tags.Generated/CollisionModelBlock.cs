// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Coll = (TagClass)"coll";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("coll")]
    public partial class CollisionModelBlock : CollisionModelBlockBase
    {
        public CollisionModelBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 52, Alignment = 4)]
    public class CollisionModelBlockBase : GuerillaBlock
    {
        internal GlobalTagImportInfoBlock[] importInfo;
        internal GlobalErrorReportCategoriesBlock[] errors;
        internal Flags flags;
        internal CollisionModelMaterialBlock[] materials;
        internal CollisionModelRegionBlock[] regions;
        internal CollisionModelPathfindingSphereBlock[] pathfindingSpheres;
        internal CollisionModelNodeBlock[] nodes;
        public override int SerializedSize { get { return 52; } }
        public override int Alignment { get { return 4; } }
        public CollisionModelBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<GlobalTagImportInfoBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<GlobalErrorReportCategoriesBlock>(binaryReader));
            flags = (Flags)binaryReader.ReadInt32();
            blamPointers.Enqueue(ReadBlockArrayPointer<CollisionModelMaterialBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<CollisionModelRegionBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<CollisionModelPathfindingSphereBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<CollisionModelNodeBlock>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            importInfo = ReadBlockArrayData<GlobalTagImportInfoBlock>(binaryReader, blamPointers.Dequeue());
            errors = ReadBlockArrayData<GlobalErrorReportCategoriesBlock>(binaryReader, blamPointers.Dequeue());
            materials = ReadBlockArrayData<CollisionModelMaterialBlock>(binaryReader, blamPointers.Dequeue());
            regions = ReadBlockArrayData<CollisionModelRegionBlock>(binaryReader, blamPointers.Dequeue());
            pathfindingSpheres = ReadBlockArrayData<CollisionModelPathfindingSphereBlock>(binaryReader, blamPointers.Dequeue());
            nodes = ReadBlockArrayData<CollisionModelNodeBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<GlobalTagImportInfoBlock>(binaryWriter, importInfo, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GlobalErrorReportCategoriesBlock>(binaryWriter, errors, nextAddress);
                binaryWriter.Write((Int32)flags);
                nextAddress = Guerilla.WriteBlockArray<CollisionModelMaterialBlock>(binaryWriter, materials, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CollisionModelRegionBlock>(binaryWriter, regions, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CollisionModelPathfindingSphereBlock>(binaryWriter, pathfindingSpheres, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CollisionModelNodeBlock>(binaryWriter, nodes, nextAddress);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        {
            ContainsOpenEdges = 1,
        };
    };
}
