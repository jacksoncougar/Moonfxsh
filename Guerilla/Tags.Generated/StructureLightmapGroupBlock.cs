// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class StructureLightmapGroupBlock : StructureLightmapGroupBlockBase
    {
        public StructureLightmapGroupBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 104, Alignment = 4 )]
    public class StructureLightmapGroupBlockBase : IGuerilla
    {
        internal Type type;
        internal Flags flags;
        internal int structureChecksum;
        internal StructureLightmapPaletteColorBlock[] sectionPalette;
        internal StructureLightmapPaletteColorBlock[] writablePalettes;
        [TagReference( "bitm" )] internal Moonfish.Tags.TagReference bitmapGroup;
        internal LightmapGeometrySectionBlock[] clusters;
        internal LightmapGeometryRenderInfoBlock[] clusterRenderInfo;
        internal LightmapGeometrySectionBlock[] poopDefinitions;
        internal StructureLightmapLightingEnvironmentBlock[] lightingEnvironments;
        internal LightmapVertexBufferBucketBlock[] geometryBuckets;
        internal LightmapGeometryRenderInfoBlock[] instanceRenderInfo;
        internal LightmapInstanceBucketReferenceBlock[] instanceBucketRefs;
        internal LightmapSceneryObjectInfoBlock[] sceneryObjectInfo;
        internal LightmapInstanceBucketReferenceBlock[] sceneryObjectBucketRefs;

        internal StructureLightmapGroupBlockBase( BinaryReader binaryReader )
        {
            type = ( Type ) binaryReader.ReadInt16( );
            flags = ( Flags ) binaryReader.ReadInt16( );
            structureChecksum = binaryReader.ReadInt32( );
            sectionPalette = Guerilla.ReadBlockArray<StructureLightmapPaletteColorBlock>( binaryReader );
            writablePalettes = Guerilla.ReadBlockArray<StructureLightmapPaletteColorBlock>( binaryReader );
            bitmapGroup = binaryReader.ReadTagReference( );
            clusters = Guerilla.ReadBlockArray<LightmapGeometrySectionBlock>( binaryReader );
            clusterRenderInfo = Guerilla.ReadBlockArray<LightmapGeometryRenderInfoBlock>( binaryReader );
            poopDefinitions = Guerilla.ReadBlockArray<LightmapGeometrySectionBlock>( binaryReader );
            lightingEnvironments = Guerilla.ReadBlockArray<StructureLightmapLightingEnvironmentBlock>( binaryReader );
            geometryBuckets = Guerilla.ReadBlockArray<LightmapVertexBufferBucketBlock>( binaryReader );
            instanceRenderInfo = Guerilla.ReadBlockArray<LightmapGeometryRenderInfoBlock>( binaryReader );
            instanceBucketRefs = Guerilla.ReadBlockArray<LightmapInstanceBucketReferenceBlock>( binaryReader );
            sceneryObjectInfo = Guerilla.ReadBlockArray<LightmapSceneryObjectInfoBlock>( binaryReader );
            sceneryObjectBucketRefs = Guerilla.ReadBlockArray<LightmapInstanceBucketReferenceBlock>( binaryReader );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( ( Int16 ) type );
                binaryWriter.Write( ( Int16 ) flags );
                binaryWriter.Write( structureChecksum );
                nextAddress = Guerilla.WriteBlockArray<StructureLightmapPaletteColorBlock>( binaryWriter, sectionPalette,
                    nextAddress );
                nextAddress = Guerilla.WriteBlockArray<StructureLightmapPaletteColorBlock>( binaryWriter,
                    writablePalettes, nextAddress );
                binaryWriter.Write( bitmapGroup );
                nextAddress = Guerilla.WriteBlockArray<LightmapGeometrySectionBlock>( binaryWriter, clusters,
                    nextAddress );
                nextAddress = Guerilla.WriteBlockArray<LightmapGeometryRenderInfoBlock>( binaryWriter, clusterRenderInfo,
                    nextAddress );
                nextAddress = Guerilla.WriteBlockArray<LightmapGeometrySectionBlock>( binaryWriter, poopDefinitions,
                    nextAddress );
                nextAddress = Guerilla.WriteBlockArray<StructureLightmapLightingEnvironmentBlock>( binaryWriter,
                    lightingEnvironments, nextAddress );
                nextAddress = Guerilla.WriteBlockArray<LightmapVertexBufferBucketBlock>( binaryWriter, geometryBuckets,
                    nextAddress );
                nextAddress = Guerilla.WriteBlockArray<LightmapGeometryRenderInfoBlock>( binaryWriter,
                    instanceRenderInfo, nextAddress );
                nextAddress = Guerilla.WriteBlockArray<LightmapInstanceBucketReferenceBlock>( binaryWriter,
                    instanceBucketRefs, nextAddress );
                nextAddress = Guerilla.WriteBlockArray<LightmapSceneryObjectInfoBlock>( binaryWriter, sceneryObjectInfo,
                    nextAddress );
                nextAddress = Guerilla.WriteBlockArray<LightmapInstanceBucketReferenceBlock>( binaryWriter,
                    sceneryObjectBucketRefs, nextAddress );
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