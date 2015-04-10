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
        public  GlobalGeometrySectionStructBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 68)]
    public class GlobalGeometrySectionStructBlockBase
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
        internal  GlobalGeometrySectionStructBlockBase(System.IO.BinaryReader binaryReader)
        {
            ReadGlobalGeometryPartBlockNewArray(binaryReader);
            ReadGlobalSubpartsBlockArray(binaryReader);
            ReadGlobalVisibilityBoundsBlockArray(binaryReader);
            ReadGlobalGeometrySectionRawVertexBlockArray(binaryReader);
            ReadGlobalGeometrySectionStripIndexBlockArray(binaryReader);
            visibilityMoppCode = ReadData(binaryReader);
            ReadGlobalGeometrySectionStripIndexBlockArray(binaryReader);
            ReadGlobalGeometrySectionVertexBufferBlockArray(binaryReader);
            invalidName_ = binaryReader.ReadBytes(4);
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
        internal  virtual GlobalGeometryPartBlockNew[] ReadGlobalGeometryPartBlockNewArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalGeometryPartBlockNew));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalGeometryPartBlockNew[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalGeometryPartBlockNew(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GlobalSubpartsBlock[] ReadGlobalSubpartsBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalSubpartsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalSubpartsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalSubpartsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GlobalVisibilityBoundsBlock[] ReadGlobalVisibilityBoundsBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalVisibilityBoundsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalVisibilityBoundsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalVisibilityBoundsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GlobalGeometrySectionRawVertexBlock[] ReadGlobalGeometrySectionRawVertexBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalGeometrySectionRawVertexBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalGeometrySectionRawVertexBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalGeometrySectionRawVertexBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GlobalGeometrySectionStripIndexBlock[] ReadGlobalGeometrySectionStripIndexBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalGeometrySectionStripIndexBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalGeometrySectionStripIndexBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalGeometrySectionStripIndexBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GlobalGeometrySectionVertexBufferBlock[] ReadGlobalGeometrySectionVertexBufferBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalGeometrySectionVertexBufferBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalGeometrySectionVertexBufferBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalGeometrySectionVertexBufferBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGlobalGeometryPartBlockNewArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGlobalSubpartsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGlobalVisibilityBoundsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGlobalGeometrySectionRawVertexBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGlobalGeometrySectionStripIndexBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGlobalGeometrySectionVertexBufferBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                WriteGlobalGeometryPartBlockNewArray(binaryWriter);
                WriteGlobalSubpartsBlockArray(binaryWriter);
                WriteGlobalVisibilityBoundsBlockArray(binaryWriter);
                WriteGlobalGeometrySectionRawVertexBlockArray(binaryWriter);
                WriteGlobalGeometrySectionStripIndexBlockArray(binaryWriter);
                WriteData(binaryWriter);
                WriteGlobalGeometrySectionStripIndexBlockArray(binaryWriter);
                WriteGlobalGeometrySectionVertexBufferBlockArray(binaryWriter);
                binaryWriter.Write(invalidName_, 0, 4);
            }
        }
    };
}
