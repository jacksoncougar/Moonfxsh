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
    public partial class StructureLightmapGroupBlock : StructureLightmapGroupBlockBase
    {
        public StructureLightmapGroupBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 104, Alignment = 4)]
    public class StructureLightmapGroupBlockBase : GuerillaBlock
    {
        internal Type type;
        internal Flags flags;
        internal int structureChecksum;
        internal StructureLightmapPaletteColorBlock[] sectionPalette;
        internal StructureLightmapPaletteColorBlock[] writablePalettes;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference bitmapGroup;
        internal LightmapGeometrySectionBlock[] clusters;
        internal LightmapGeometryRenderInfoBlock[] clusterRenderInfo;
        internal LightmapGeometrySectionBlock[] poopDefinitions;
        internal StructureLightmapLightingEnvironmentBlock[] lightingEnvironments;
        internal LightmapVertexBufferBucketBlock[] geometryBuckets;
        internal LightmapGeometryRenderInfoBlock[] instanceRenderInfo;
        internal LightmapInstanceBucketReferenceBlock[] instanceBucketRefs;
        internal LightmapSceneryObjectInfoBlock[] sceneryObjectInfo;
        internal LightmapInstanceBucketReferenceBlock[] sceneryObjectBucketRefs;
        public override int SerializedSize { get { return 104; } }
        public override int Alignment { get { return 4; } }
        public StructureLightmapGroupBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            type = (Type)binaryReader.ReadInt16();
            flags = (Flags)binaryReader.ReadInt16();
            structureChecksum = binaryReader.ReadInt32();
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureLightmapPaletteColorBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureLightmapPaletteColorBlock>(binaryReader));
            bitmapGroup = binaryReader.ReadTagReference();
            blamPointers.Enqueue(ReadBlockArrayPointer<LightmapGeometrySectionBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<LightmapGeometryRenderInfoBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<LightmapGeometrySectionBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureLightmapLightingEnvironmentBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<LightmapVertexBufferBucketBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<LightmapGeometryRenderInfoBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<LightmapInstanceBucketReferenceBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<LightmapSceneryObjectInfoBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<LightmapInstanceBucketReferenceBlock>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            sectionPalette = ReadBlockArrayData<StructureLightmapPaletteColorBlock>(binaryReader, blamPointers.Dequeue());
            writablePalettes = ReadBlockArrayData<StructureLightmapPaletteColorBlock>(binaryReader, blamPointers.Dequeue());
            clusters = ReadBlockArrayData<LightmapGeometrySectionBlock>(binaryReader, blamPointers.Dequeue());
            clusterRenderInfo = ReadBlockArrayData<LightmapGeometryRenderInfoBlock>(binaryReader, blamPointers.Dequeue());
            poopDefinitions = ReadBlockArrayData<LightmapGeometrySectionBlock>(binaryReader, blamPointers.Dequeue());
            lightingEnvironments = ReadBlockArrayData<StructureLightmapLightingEnvironmentBlock>(binaryReader, blamPointers.Dequeue());
            geometryBuckets = ReadBlockArrayData<LightmapVertexBufferBucketBlock>(binaryReader, blamPointers.Dequeue());
            instanceRenderInfo = ReadBlockArrayData<LightmapGeometryRenderInfoBlock>(binaryReader, blamPointers.Dequeue());
            instanceBucketRefs = ReadBlockArrayData<LightmapInstanceBucketReferenceBlock>(binaryReader, blamPointers.Dequeue());
            sceneryObjectInfo = ReadBlockArrayData<LightmapSceneryObjectInfoBlock>(binaryReader, blamPointers.Dequeue());
            sceneryObjectBucketRefs = ReadBlockArrayData<LightmapInstanceBucketReferenceBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)type);
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(structureChecksum);
                nextAddress = Guerilla.WriteBlockArray<StructureLightmapPaletteColorBlock>(binaryWriter, sectionPalette, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StructureLightmapPaletteColorBlock>(binaryWriter, writablePalettes, nextAddress);
                binaryWriter.Write(bitmapGroup);
                nextAddress = Guerilla.WriteBlockArray<LightmapGeometrySectionBlock>(binaryWriter, clusters, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<LightmapGeometryRenderInfoBlock>(binaryWriter, clusterRenderInfo, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<LightmapGeometrySectionBlock>(binaryWriter, poopDefinitions, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StructureLightmapLightingEnvironmentBlock>(binaryWriter, lightingEnvironments, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<LightmapVertexBufferBucketBlock>(binaryWriter, geometryBuckets, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<LightmapGeometryRenderInfoBlock>(binaryWriter, instanceRenderInfo, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<LightmapInstanceBucketReferenceBlock>(binaryWriter, instanceBucketRefs, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<LightmapSceneryObjectInfoBlock>(binaryWriter, sceneryObjectInfo, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<LightmapInstanceBucketReferenceBlock>(binaryWriter, sceneryObjectBucketRefs, nextAddress);
                return nextAddress;
            }
        }
        internal enum Type : short
        {
            Normal = 0,
        };
        [FlagsAttribute]
        internal enum Flags : short
        {
            Unused = 1,
        };
    };
}
