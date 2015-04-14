// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GlobalGeometrySectionStructBlock : GlobalGeometrySectionStructBlockBase
    {
        public  GlobalGeometrySectionStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 68, Alignment = 4)]
    public class GlobalGeometrySectionStructBlockBase  : IGuerilla
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
        internal  GlobalGeometrySectionStructBlockBase(BinaryReader binaryReader)
        {
            parts = Guerilla.ReadBlockArray<GlobalGeometryPartBlockNew>(binaryReader);
            subparts = Guerilla.ReadBlockArray<GlobalSubpartsBlock>(binaryReader);
            visibilityBounds = Guerilla.ReadBlockArray<GlobalVisibilityBoundsBlock>(binaryReader);
            rawVertices = Guerilla.ReadBlockArray<GlobalGeometrySectionRawVertexBlock>(binaryReader);
            stripIndices = Guerilla.ReadBlockArray<GlobalGeometrySectionStripIndexBlock>(binaryReader);
            visibilityMoppCode = Guerilla.ReadData(binaryReader);
            moppReorderTable = Guerilla.ReadBlockArray<GlobalGeometrySectionStripIndexBlock>(binaryReader);
            vertexBuffers = Guerilla.ReadBlockArray<GlobalGeometrySectionVertexBufferBlock>(binaryReader);
            invalidName_ = binaryReader.ReadBytes(4);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                Guerilla.WriteBlockArray<GlobalGeometryPartBlockNew>(binaryWriter, parts, nextAddress);
                Guerilla.WriteBlockArray<GlobalSubpartsBlock>(binaryWriter, subparts, nextAddress);
                Guerilla.WriteBlockArray<GlobalVisibilityBoundsBlock>(binaryWriter, visibilityBounds, nextAddress);
                Guerilla.WriteBlockArray<GlobalGeometrySectionRawVertexBlock>(binaryWriter, rawVertices, nextAddress);
                Guerilla.WriteBlockArray<GlobalGeometrySectionStripIndexBlock>(binaryWriter, stripIndices, nextAddress);
                Guerilla.WriteData(binaryWriter);
                Guerilla.WriteBlockArray<GlobalGeometrySectionStripIndexBlock>(binaryWriter, moppReorderTable, nextAddress);
                Guerilla.WriteBlockArray<GlobalGeometrySectionVertexBufferBlock>(binaryWriter, vertexBuffers, nextAddress);
                binaryWriter.Write(invalidName_, 0, 4);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
