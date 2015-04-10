using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class StructureLightmapGroupBlock : StructureLightmapGroupBlockBase
    {
        public  StructureLightmapGroupBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 104)]
    public class StructureLightmapGroupBlockBase
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
        internal  StructureLightmapGroupBlockBase(BinaryReader binaryReader)
        {
            this.type = (Type)binaryReader.ReadInt16();
            this.flags = (Flags)binaryReader.ReadInt16();
            this.structureChecksum = binaryReader.ReadInt32();
            this.sectionPalette = ReadStructureLightmapPaletteColorBlockArray(binaryReader);
            this.writablePalettes = ReadStructureLightmapPaletteColorBlockArray(binaryReader);
            this.bitmapGroup = binaryReader.ReadTagReference();
            this.clusters = ReadLightmapGeometrySectionBlockArray(binaryReader);
            this.clusterRenderInfo = ReadLightmapGeometryRenderInfoBlockArray(binaryReader);
            this.poopDefinitions = ReadLightmapGeometrySectionBlockArray(binaryReader);
            this.lightingEnvironments = ReadStructureLightmapLightingEnvironmentBlockArray(binaryReader);
            this.geometryBuckets = ReadLightmapVertexBufferBucketBlockArray(binaryReader);
            this.instanceRenderInfo = ReadLightmapGeometryRenderInfoBlockArray(binaryReader);
            this.instanceBucketRefs = ReadLightmapInstanceBucketReferenceBlockArray(binaryReader);
            this.sceneryObjectInfo = ReadLightmapSceneryObjectInfoBlockArray(binaryReader);
            this.sceneryObjectBucketRefs = ReadLightmapInstanceBucketReferenceBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
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
        internal  virtual StructureLightmapPaletteColorBlock[] ReadStructureLightmapPaletteColorBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureLightmapPaletteColorBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureLightmapPaletteColorBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureLightmapPaletteColorBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual LightmapGeometrySectionBlock[] ReadLightmapGeometrySectionBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(LightmapGeometrySectionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new LightmapGeometrySectionBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new LightmapGeometrySectionBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual LightmapGeometryRenderInfoBlock[] ReadLightmapGeometryRenderInfoBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(LightmapGeometryRenderInfoBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new LightmapGeometryRenderInfoBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new LightmapGeometryRenderInfoBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual StructureLightmapLightingEnvironmentBlock[] ReadStructureLightmapLightingEnvironmentBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureLightmapLightingEnvironmentBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureLightmapLightingEnvironmentBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureLightmapLightingEnvironmentBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual LightmapVertexBufferBucketBlock[] ReadLightmapVertexBufferBucketBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(LightmapVertexBufferBucketBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new LightmapVertexBufferBucketBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new LightmapVertexBufferBucketBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual LightmapInstanceBucketReferenceBlock[] ReadLightmapInstanceBucketReferenceBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(LightmapInstanceBucketReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new LightmapInstanceBucketReferenceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new LightmapInstanceBucketReferenceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual LightmapSceneryObjectInfoBlock[] ReadLightmapSceneryObjectInfoBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(LightmapSceneryObjectInfoBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new LightmapSceneryObjectInfoBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new LightmapSceneryObjectInfoBlock(binaryReader);
                }
            }
            return array;
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
