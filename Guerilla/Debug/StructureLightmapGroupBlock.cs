// ReSharper disable All
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
        public  StructureLightmapGroupBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  StructureLightmapGroupBlockBase(System.IO.BinaryReader binaryReader)
        {
            type = (Type)binaryReader.ReadInt16();
            flags = (Flags)binaryReader.ReadInt16();
            structureChecksum = binaryReader.ReadInt32();
            ReadStructureLightmapPaletteColorBlockArray(binaryReader);
            ReadStructureLightmapPaletteColorBlockArray(binaryReader);
            bitmapGroup = binaryReader.ReadTagReference();
            ReadLightmapGeometrySectionBlockArray(binaryReader);
            ReadLightmapGeometryRenderInfoBlockArray(binaryReader);
            ReadLightmapGeometrySectionBlockArray(binaryReader);
            ReadStructureLightmapLightingEnvironmentBlockArray(binaryReader);
            ReadLightmapVertexBufferBucketBlockArray(binaryReader);
            ReadLightmapGeometryRenderInfoBlockArray(binaryReader);
            ReadLightmapInstanceBucketReferenceBlockArray(binaryReader);
            ReadLightmapSceneryObjectInfoBlockArray(binaryReader);
            ReadLightmapInstanceBucketReferenceBlockArray(binaryReader);
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
        internal  virtual StructureLightmapPaletteColorBlock[] ReadStructureLightmapPaletteColorBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual LightmapGeometrySectionBlock[] ReadLightmapGeometrySectionBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual LightmapGeometryRenderInfoBlock[] ReadLightmapGeometryRenderInfoBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual StructureLightmapLightingEnvironmentBlock[] ReadStructureLightmapLightingEnvironmentBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual LightmapVertexBufferBucketBlock[] ReadLightmapVertexBufferBucketBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual LightmapInstanceBucketReferenceBlock[] ReadLightmapInstanceBucketReferenceBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual LightmapSceneryObjectInfoBlock[] ReadLightmapSceneryObjectInfoBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteStructureLightmapPaletteColorBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteLightmapGeometrySectionBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteLightmapGeometryRenderInfoBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteStructureLightmapLightingEnvironmentBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteLightmapVertexBufferBucketBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteLightmapInstanceBucketReferenceBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteLightmapSceneryObjectInfoBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)type);
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(structureChecksum);
                WriteStructureLightmapPaletteColorBlockArray(binaryWriter);
                WriteStructureLightmapPaletteColorBlockArray(binaryWriter);
                binaryWriter.Write(bitmapGroup);
                WriteLightmapGeometrySectionBlockArray(binaryWriter);
                WriteLightmapGeometryRenderInfoBlockArray(binaryWriter);
                WriteLightmapGeometrySectionBlockArray(binaryWriter);
                WriteStructureLightmapLightingEnvironmentBlockArray(binaryWriter);
                WriteLightmapVertexBufferBucketBlockArray(binaryWriter);
                WriteLightmapGeometryRenderInfoBlockArray(binaryWriter);
                WriteLightmapInstanceBucketReferenceBlockArray(binaryWriter);
                WriteLightmapSceneryObjectInfoBlockArray(binaryWriter);
                WriteLightmapInstanceBucketReferenceBlockArray(binaryWriter);
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
