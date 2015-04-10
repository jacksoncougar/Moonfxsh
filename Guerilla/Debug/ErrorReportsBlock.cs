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
        public  ErrorReportsBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 608)]
    public class ErrorReportsBlockBase
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
        internal  ErrorReportsBlockBase(System.IO.BinaryReader binaryReader)
        {
            type = (Type)binaryReader.ReadInt16();
            flags = (Flags)binaryReader.ReadInt16();
            text = ReadData(binaryReader);
            sourceFilename = binaryReader.ReadString32();
            sourceLineNumber = binaryReader.ReadInt32();
            ReadErrorReportVerticesBlockArray(binaryReader);
            ReadErrorReportVectorsBlockArray(binaryReader);
            ReadErrorReportLinesBlockArray(binaryReader);
            ReadErrorReportTrianglesBlockArray(binaryReader);
            ReadErrorReportQuadsBlockArray(binaryReader);
            ReadErrorReportCommentsBlockArray(binaryReader);
            invalidName_ = binaryReader.ReadBytes(380);
            reportKey = binaryReader.ReadInt32();
            nodeIndex = binaryReader.ReadInt32();
            boundsX = binaryReader.ReadRange();
            boundsY = binaryReader.ReadRange();
            boundsZ = binaryReader.ReadRange();
            color = binaryReader.ReadVector4();
            invalidName_0 = binaryReader.ReadBytes(84);
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
        internal  virtual ErrorReportVerticesBlock[] ReadErrorReportVerticesBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ErrorReportVerticesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ErrorReportVerticesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ErrorReportVerticesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ErrorReportVectorsBlock[] ReadErrorReportVectorsBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ErrorReportVectorsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ErrorReportVectorsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ErrorReportVectorsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ErrorReportLinesBlock[] ReadErrorReportLinesBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ErrorReportLinesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ErrorReportLinesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ErrorReportLinesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ErrorReportTrianglesBlock[] ReadErrorReportTrianglesBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ErrorReportTrianglesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ErrorReportTrianglesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ErrorReportTrianglesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ErrorReportQuadsBlock[] ReadErrorReportQuadsBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ErrorReportQuadsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ErrorReportQuadsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ErrorReportQuadsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ErrorReportCommentsBlock[] ReadErrorReportCommentsBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ErrorReportCommentsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ErrorReportCommentsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ErrorReportCommentsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteErrorReportVerticesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteErrorReportVectorsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteErrorReportLinesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteErrorReportTrianglesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteErrorReportQuadsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteErrorReportCommentsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)type);
                binaryWriter.Write((Int16)flags);
                WriteData(binaryWriter);
                binaryWriter.Write(sourceFilename);
                binaryWriter.Write(sourceLineNumber);
                WriteErrorReportVerticesBlockArray(binaryWriter);
                WriteErrorReportVectorsBlockArray(binaryWriter);
                WriteErrorReportLinesBlockArray(binaryWriter);
                WriteErrorReportTrianglesBlockArray(binaryWriter);
                WriteErrorReportQuadsBlockArray(binaryWriter);
                WriteErrorReportCommentsBlockArray(binaryWriter);
                binaryWriter.Write(invalidName_, 0, 380);
                binaryWriter.Write(reportKey);
                binaryWriter.Write(nodeIndex);
                binaryWriter.Write(boundsX);
                binaryWriter.Write(boundsY);
                binaryWriter.Write(boundsZ);
                binaryWriter.Write(color);
                binaryWriter.Write(invalidName_0, 0, 84);
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
