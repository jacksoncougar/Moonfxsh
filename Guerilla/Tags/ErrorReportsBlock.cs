// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ErrorReportsBlock : ErrorReportsBlockBase
    {
        public  ErrorReportsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 608, Alignment = 4)]
    public class ErrorReportsBlockBase  : IGuerilla
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
        internal  ErrorReportsBlockBase(BinaryReader binaryReader)
        {
            type = (Type)binaryReader.ReadInt16();
            flags = (Flags)binaryReader.ReadInt16();
            text = Guerilla.ReadData(binaryReader);
            sourceFilename = binaryReader.ReadString32();
            sourceLineNumber = binaryReader.ReadInt32();
            vertices = Guerilla.ReadBlockArray<ErrorReportVerticesBlock>(binaryReader);
            vectors = Guerilla.ReadBlockArray<ErrorReportVectorsBlock>(binaryReader);
            lines = Guerilla.ReadBlockArray<ErrorReportLinesBlock>(binaryReader);
            triangles = Guerilla.ReadBlockArray<ErrorReportTrianglesBlock>(binaryReader);
            quads = Guerilla.ReadBlockArray<ErrorReportQuadsBlock>(binaryReader);
            comments = Guerilla.ReadBlockArray<ErrorReportCommentsBlock>(binaryReader);
            invalidName_ = binaryReader.ReadBytes(380);
            reportKey = binaryReader.ReadInt32();
            nodeIndex = binaryReader.ReadInt32();
            boundsX = binaryReader.ReadRange();
            boundsY = binaryReader.ReadRange();
            boundsZ = binaryReader.ReadRange();
            color = binaryReader.ReadVector4();
            invalidName_0 = binaryReader.ReadBytes(84);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)type);
                binaryWriter.Write((Int16)flags);
                Guerilla.WriteData(binaryWriter);
                binaryWriter.Write(sourceFilename);
                binaryWriter.Write(sourceLineNumber);
                Guerilla.WriteBlockArray<ErrorReportVerticesBlock>(binaryWriter, vertices, nextAddress);
                Guerilla.WriteBlockArray<ErrorReportVectorsBlock>(binaryWriter, vectors, nextAddress);
                Guerilla.WriteBlockArray<ErrorReportLinesBlock>(binaryWriter, lines, nextAddress);
                Guerilla.WriteBlockArray<ErrorReportTrianglesBlock>(binaryWriter, triangles, nextAddress);
                Guerilla.WriteBlockArray<ErrorReportQuadsBlock>(binaryWriter, quads, nextAddress);
                Guerilla.WriteBlockArray<ErrorReportCommentsBlock>(binaryWriter, comments, nextAddress);
                binaryWriter.Write(invalidName_, 0, 380);
                binaryWriter.Write(reportKey);
                binaryWriter.Write(nodeIndex);
                binaryWriter.Write(boundsX);
                binaryWriter.Write(boundsY);
                binaryWriter.Write(boundsZ);
                binaryWriter.Write(color);
                binaryWriter.Write(invalidName_0, 0, 84);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
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
