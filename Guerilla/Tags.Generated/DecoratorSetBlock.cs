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
        public static readonly TagClass DECR = (TagClass) "DECR";
    };
} ;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("DECR")]
    public partial class DecoratorSetBlock : DecoratorSetBlockBase
    {
        public DecoratorSetBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 108, Alignment = 4)]
    public class DecoratorSetBlockBase : GuerillaBlock
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

        public override int SerializedSize
        {
            get { return 108; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public DecoratorSetBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<DecoratorShaderReferenceBlock>(binaryReader));
            lightingMinScale = binaryReader.ReadSingle();
            lightingMaxScale = binaryReader.ReadSingle();
            blamPointers.Enqueue(ReadBlockArrayPointer<DecoratorClassesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<DecoratorModelsBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<DecoratorModelVerticesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<DecoratorModelIndicesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<CachedDataBlock>(binaryReader));
            geometrySectionInfo = new GlobalGeometryBlockInfoStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(geometrySectionInfo.ReadFields(binaryReader)));
            invalidName_ = binaryReader.ReadBytes(16);
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            shaders = ReadBlockArrayData<DecoratorShaderReferenceBlock>(binaryReader, blamPointers.Dequeue());
            classes = ReadBlockArrayData<DecoratorClassesBlock>(binaryReader, blamPointers.Dequeue());
            models = ReadBlockArrayData<DecoratorModelsBlock>(binaryReader, blamPointers.Dequeue());
            rawVertices = ReadBlockArrayData<DecoratorModelVerticesBlock>(binaryReader, blamPointers.Dequeue());
            indices = ReadBlockArrayData<DecoratorModelIndicesBlock>(binaryReader, blamPointers.Dequeue());
            cachedData = ReadBlockArrayData<CachedDataBlock>(binaryReader, blamPointers.Dequeue());
            geometrySectionInfo.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<DecoratorShaderReferenceBlock>(binaryWriter, shaders, nextAddress);
                binaryWriter.Write(lightingMinScale);
                binaryWriter.Write(lightingMaxScale);
                nextAddress = Guerilla.WriteBlockArray<DecoratorClassesBlock>(binaryWriter, classes, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<DecoratorModelsBlock>(binaryWriter, models, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<DecoratorModelVerticesBlock>(binaryWriter, rawVertices,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<DecoratorModelIndicesBlock>(binaryWriter, indices, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CachedDataBlock>(binaryWriter, cachedData, nextAddress);
                geometrySectionInfo.Write(binaryWriter);
                binaryWriter.Write(invalidName_, 0, 16);
                return nextAddress;
            }
        }
    };
}