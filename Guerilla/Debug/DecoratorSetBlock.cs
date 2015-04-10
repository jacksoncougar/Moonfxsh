// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("DECR")]
    public  partial class DecoratorSetBlock : DecoratorSetBlockBase
    {
        public  DecoratorSetBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 112)]
    public class DecoratorSetBlockBase
    {
        internal DecoratorShaderReferenceBlock[] shaders;
        /// <summary>
        /// 0.0 defaults to 0.4
        /// </summary>
        internal float lightingMinScale;
        /// <summary>
        /// 0.0 defaults to 2.0
        /// </summary>
        internal float lightingMaxScale;
        internal DecoratorClassesBlock[] classes;
        internal DecoratorModelsBlock[] models;
        internal DecoratorModelVerticesBlock[] rawVertices;
        internal DecoratorModelIndicesBlock[] indices;
        internal CachedDataBlock[] cachedData;
        internal GlobalGeometryBlockInfoStructBlock geometrySectionInfo;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal  DecoratorSetBlockBase(System.IO.BinaryReader binaryReader)
        {
            ReadDecoratorShaderReferenceBlockArray(binaryReader);
            lightingMinScale = binaryReader.ReadSingle();
            lightingMaxScale = binaryReader.ReadSingle();
            ReadDecoratorClassesBlockArray(binaryReader);
            ReadDecoratorModelsBlockArray(binaryReader);
            ReadDecoratorModelVerticesBlockArray(binaryReader);
            ReadDecoratorModelIndicesBlockArray(binaryReader);
            ReadCachedDataBlockArray(binaryReader);
            geometrySectionInfo = new GlobalGeometryBlockInfoStructBlock(binaryReader);
            invalidName_ = binaryReader.ReadBytes(16);
            invalidName_0 = binaryReader.ReadBytes(4);
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
        internal  virtual DecoratorShaderReferenceBlock[] ReadDecoratorShaderReferenceBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(DecoratorShaderReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new DecoratorShaderReferenceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new DecoratorShaderReferenceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual DecoratorClassesBlock[] ReadDecoratorClassesBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(DecoratorClassesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new DecoratorClassesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new DecoratorClassesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual DecoratorModelsBlock[] ReadDecoratorModelsBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(DecoratorModelsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new DecoratorModelsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new DecoratorModelsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual DecoratorModelVerticesBlock[] ReadDecoratorModelVerticesBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(DecoratorModelVerticesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new DecoratorModelVerticesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new DecoratorModelVerticesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual DecoratorModelIndicesBlock[] ReadDecoratorModelIndicesBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(DecoratorModelIndicesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new DecoratorModelIndicesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new DecoratorModelIndicesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CachedDataBlock[] ReadCachedDataBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CachedDataBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CachedDataBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CachedDataBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteDecoratorShaderReferenceBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteDecoratorClassesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteDecoratorModelsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteDecoratorModelVerticesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteDecoratorModelIndicesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteCachedDataBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                WriteDecoratorShaderReferenceBlockArray(binaryWriter);
                binaryWriter.Write(lightingMinScale);
                binaryWriter.Write(lightingMaxScale);
                WriteDecoratorClassesBlockArray(binaryWriter);
                WriteDecoratorModelsBlockArray(binaryWriter);
                WriteDecoratorModelVerticesBlockArray(binaryWriter);
                WriteDecoratorModelIndicesBlockArray(binaryWriter);
                WriteCachedDataBlockArray(binaryWriter);
                geometrySectionInfo.Write(binaryWriter);
                binaryWriter.Write(invalidName_, 0, 16);
                binaryWriter.Write(invalidName_0, 0, 4);
            }
        }
    };
}
