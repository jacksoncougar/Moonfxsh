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
        public  DecoratorSetBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  DecoratorSetBlockBase(BinaryReader binaryReader)
        {
            this.shaders = ReadDecoratorShaderReferenceBlockArray(binaryReader);
            this.lightingMinScale = binaryReader.ReadSingle();
            this.lightingMaxScale = binaryReader.ReadSingle();
            this.classes = ReadDecoratorClassesBlockArray(binaryReader);
            this.models = ReadDecoratorModelsBlockArray(binaryReader);
            this.rawVertices = ReadDecoratorModelVerticesBlockArray(binaryReader);
            this.indices = ReadDecoratorModelIndicesBlockArray(binaryReader);
            this.cachedData = ReadCachedDataBlockArray(binaryReader);
            this.geometrySectionInfo = new GlobalGeometryBlockInfoStructBlock(binaryReader);
            this.invalidName_ = binaryReader.ReadBytes(16);
            this.invalidName_0 = binaryReader.ReadBytes(4);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
        }
        internal  virtual DecoratorShaderReferenceBlock[] ReadDecoratorShaderReferenceBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(DecoratorShaderReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new DecoratorShaderReferenceBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new DecoratorShaderReferenceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual DecoratorClassesBlock[] ReadDecoratorClassesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(DecoratorClassesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new DecoratorClassesBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new DecoratorClassesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual DecoratorModelsBlock[] ReadDecoratorModelsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(DecoratorModelsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new DecoratorModelsBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new DecoratorModelsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual DecoratorModelVerticesBlock[] ReadDecoratorModelVerticesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(DecoratorModelVerticesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new DecoratorModelVerticesBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new DecoratorModelVerticesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual DecoratorModelIndicesBlock[] ReadDecoratorModelIndicesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(DecoratorModelIndicesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new DecoratorModelIndicesBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new DecoratorModelIndicesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CachedDataBlock[] ReadCachedDataBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CachedDataBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CachedDataBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CachedDataBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
