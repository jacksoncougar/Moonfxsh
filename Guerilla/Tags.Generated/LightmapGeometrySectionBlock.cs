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
    public partial class LightmapGeometrySectionBlock : LightmapGeometrySectionBlockBase
    {
        public LightmapGeometrySectionBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 84, Alignment = 4)]
    public class LightmapGeometrySectionBlockBase : GuerillaBlock
    {
        internal GlobalGeometrySectionInfoStructBlock geometryInfo;
        internal GlobalGeometryBlockInfoStructBlock geometryBlockInfo;
        internal LightmapGeometrySectionCacheDataBlock[] cacheData;

        public override int SerializedSize
        {
            get { return 84; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public LightmapGeometrySectionBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            geometryInfo = new GlobalGeometrySectionInfoStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(geometryInfo.ReadFields(binaryReader)));
            geometryBlockInfo = new GlobalGeometryBlockInfoStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(geometryBlockInfo.ReadFields(binaryReader)));
            blamPointers.Enqueue(ReadBlockArrayPointer<LightmapGeometrySectionCacheDataBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            geometryInfo.ReadPointers(binaryReader, blamPointers);
            geometryBlockInfo.ReadPointers(binaryReader, blamPointers);
            cacheData = ReadBlockArrayData<LightmapGeometrySectionCacheDataBlock>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                geometryInfo.Write(binaryWriter);
                geometryBlockInfo.Write(binaryWriter);
                nextAddress = Guerilla.WriteBlockArray<LightmapGeometrySectionCacheDataBlock>(binaryWriter, cacheData,
                    nextAddress);
                return nextAddress;
            }
        }
    };
}