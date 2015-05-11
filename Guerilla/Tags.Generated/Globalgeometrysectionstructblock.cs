// ReSharper disable All

using Moonfish.Model;

using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class GlobalGeometrySectionStructBlock : GlobalGeometrySectionStructBlockBase
    {
        public GlobalGeometrySectionStructBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 68, Alignment = 4)]
    public class GlobalGeometrySectionStructBlockBase : GuerillaBlock
    {
        internal GlobalGeometryPartBlockNew[] parts;
        internal GlobalSubpartsBlock[] subparts;
        internal GlobalVisibilityBoundsBlock[] visibilityBounds;
        internal GlobalGeometrySectionRawVertexBlock[] rawVertices;
        internal GlobalGeometrySectionStripIndexBlock[] stripIndices;
        internal byte[] visibilityMoppCode;
        internal GlobalGeometrySectionStripIndexBlock[] moppReorderTable;
        internal GlobalGeometrySectionVertexBufferBlock[] vertexBuffers;
        internal byte[] invalidName_;

        public override int SerializedSize
        {
            get { return 68; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public GlobalGeometrySectionStructBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<GlobalGeometryPartBlockNew>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<GlobalSubpartsBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<GlobalVisibilityBoundsBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<GlobalGeometrySectionRawVertexBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<GlobalGeometrySectionStripIndexBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer(binaryReader, 1));
            blamPointers.Enqueue(ReadBlockArrayPointer<GlobalGeometrySectionStripIndexBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<GlobalGeometrySectionVertexBufferBlock>(binaryReader));
            invalidName_ = binaryReader.ReadBytes(4);
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            parts = ReadBlockArrayData<GlobalGeometryPartBlockNew>(binaryReader, blamPointers.Dequeue());
            subparts = ReadBlockArrayData<GlobalSubpartsBlock>(binaryReader, blamPointers.Dequeue());
            visibilityBounds = ReadBlockArrayData<GlobalVisibilityBoundsBlock>(binaryReader, blamPointers.Dequeue());
            rawVertices = ReadBlockArrayData<GlobalGeometrySectionRawVertexBlock>(binaryReader, blamPointers.Dequeue());
            stripIndices = ReadBlockArrayData<GlobalGeometrySectionStripIndexBlock>(binaryReader, blamPointers.Dequeue());
            visibilityMoppCode = ReadDataByteArray(binaryReader, blamPointers.Dequeue());
            moppReorderTable = ReadBlockArrayData<GlobalGeometrySectionStripIndexBlock>(binaryReader,
                blamPointers.Dequeue());
            vertexBuffers = ReadBlockArrayData<GlobalGeometrySectionVertexBufferBlock>(binaryReader,
                blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<GlobalGeometryPartBlockNew>(binaryWriter, parts, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GlobalSubpartsBlock>(binaryWriter, subparts, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GlobalVisibilityBoundsBlock>(binaryWriter, visibilityBounds,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GlobalGeometrySectionRawVertexBlock>(binaryWriter, rawVertices,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GlobalGeometrySectionStripIndexBlock>(binaryWriter, stripIndices,
                    nextAddress);
                nextAddress = Guerilla.WriteData(binaryWriter, visibilityMoppCode, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GlobalGeometrySectionStripIndexBlock>(binaryWriter,
                    moppReorderTable, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GlobalGeometrySectionVertexBufferBlock>(binaryWriter,
                    vertexBuffers, nextAddress);
                binaryWriter.Write(invalidName_, 0, 4);
                return nextAddress;
            }
        }
    };
}