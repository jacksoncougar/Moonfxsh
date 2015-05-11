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
    public partial class ErrorReportsBlock : ErrorReportsBlockBase
    {
        public ErrorReportsBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 608, Alignment = 4)]
    public class ErrorReportsBlockBase : GuerillaBlock
    {
        internal Type type;
        internal Flags flags;
        internal byte[] text;
        internal Moonfish.Tags.String32 sourceFilename;
        internal int sourceLineNumber;
        internal ErrorReportVerticesBlock[] vertices;
        internal ErrorReportVectorsBlock[] vectors;
        internal ErrorReportLinesBlock[] lines;
        internal ErrorReportTrianglesBlock[] triangles;
        internal ErrorReportQuadsBlock[] quads;
        internal ErrorReportCommentsBlock[] comments;
        internal byte[] invalidName_;
        internal int reportKey;
        internal int nodeIndex;
        internal Moonfish.Model.Range boundsX;
        internal Moonfish.Model.Range boundsY;
        internal Moonfish.Model.Range boundsZ;
        internal OpenTK.Vector4 color;
        internal byte[] invalidName_0;

        public override int SerializedSize
        {
            get { return 608; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ErrorReportsBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            type = (Type) binaryReader.ReadInt16();
            flags = (Flags) binaryReader.ReadInt16();
            blamPointers.Enqueue(ReadBlockArrayPointer(binaryReader, 1));
            sourceFilename = binaryReader.ReadString32();
            sourceLineNumber = binaryReader.ReadInt32();
            blamPointers.Enqueue(ReadBlockArrayPointer<ErrorReportVerticesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ErrorReportVectorsBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ErrorReportLinesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ErrorReportTrianglesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ErrorReportQuadsBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ErrorReportCommentsBlock>(binaryReader));
            invalidName_ = binaryReader.ReadBytes(380);
            reportKey = binaryReader.ReadInt32();
            nodeIndex = binaryReader.ReadInt32();
            boundsX = binaryReader.ReadRange();
            boundsY = binaryReader.ReadRange();
            boundsZ = binaryReader.ReadRange();
            color = binaryReader.ReadVector4();
            invalidName_0 = binaryReader.ReadBytes(84);
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            text = ReadDataByteArray(binaryReader, blamPointers.Dequeue());
            vertices = ReadBlockArrayData<ErrorReportVerticesBlock>(binaryReader, blamPointers.Dequeue());
            vectors = ReadBlockArrayData<ErrorReportVectorsBlock>(binaryReader, blamPointers.Dequeue());
            lines = ReadBlockArrayData<ErrorReportLinesBlock>(binaryReader, blamPointers.Dequeue());
            triangles = ReadBlockArrayData<ErrorReportTrianglesBlock>(binaryReader, blamPointers.Dequeue());
            quads = ReadBlockArrayData<ErrorReportQuadsBlock>(binaryReader, blamPointers.Dequeue());
            comments = ReadBlockArrayData<ErrorReportCommentsBlock>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16) type);
                binaryWriter.Write((Int16) flags);
                nextAddress = Guerilla.WriteData(binaryWriter, text, nextAddress);
                binaryWriter.Write(sourceFilename);
                binaryWriter.Write(sourceLineNumber);
                nextAddress = Guerilla.WriteBlockArray<ErrorReportVerticesBlock>(binaryWriter, vertices, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ErrorReportVectorsBlock>(binaryWriter, vectors, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ErrorReportLinesBlock>(binaryWriter, lines, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ErrorReportTrianglesBlock>(binaryWriter, triangles, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ErrorReportQuadsBlock>(binaryWriter, quads, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ErrorReportCommentsBlock>(binaryWriter, comments, nextAddress);
                binaryWriter.Write(invalidName_, 0, 380);
                binaryWriter.Write(reportKey);
                binaryWriter.Write(nodeIndex);
                binaryWriter.Write(boundsX);
                binaryWriter.Write(boundsY);
                binaryWriter.Write(boundsZ);
                binaryWriter.Write(color);
                binaryWriter.Write(invalidName_0, 0, 84);
                return nextAddress;
            }
        }

        internal enum Type : short
        {
            Silent = 0,
            Comment = 1,
            Warning = 2,
            Error = 3,
        };

        [FlagsAttribute]
        internal enum Flags : short
        {
            Rendered = 1,
            TangentSpace = 2,
            Noncritical = 4,
            LightmapLight = 8,
            ReportKeyIsValid = 16,
        };
    };
}