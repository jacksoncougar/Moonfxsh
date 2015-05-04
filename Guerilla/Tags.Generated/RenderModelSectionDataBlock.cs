// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class RenderModelSectionDataBlock : RenderModelSectionDataBlockBase
    {
        public RenderModelSectionDataBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 112, Alignment = 4)]
    public class RenderModelSectionDataBlockBase : GuerillaBlock
    {
        internal GlobalGeometrySectionStructBlock section;
        internal GlobalGeometryPointDataStructBlock pointData;
        internal RenderModelNodeMapBlock[] nodeMap;
        internal byte[] invalidName_;
        public override int SerializedSize { get { return 112; } }
        public override int Alignment { get { return 4; } }
        public RenderModelSectionDataBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            section = new GlobalGeometrySectionStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(section.ReadFields(binaryReader)));
            pointData = new GlobalGeometryPointDataStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(pointData.ReadFields(binaryReader)));
            blamPointers.Enqueue(ReadBlockArrayPointer<RenderModelNodeMapBlock>(binaryReader));
            invalidName_ = binaryReader.ReadBytes(4);
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            section.ReadPointers(binaryReader, blamPointers);
            pointData.ReadPointers(binaryReader, blamPointers);
            nodeMap = ReadBlockArrayData<RenderModelNodeMapBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                section.Write(binaryWriter);
                pointData.Write(binaryWriter);
                nextAddress = Guerilla.WriteBlockArray<RenderModelNodeMapBlock>(binaryWriter, nodeMap, nextAddress);
                binaryWriter.Write(invalidName_, 0, 4);
                return nextAddress;
            }
        }
    };
}
