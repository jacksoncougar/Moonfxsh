// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class PathfindingDataBlock : PathfindingDataBlockBase
    {
        public PathfindingDataBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 116, Alignment = 4 )]
    public class PathfindingDataBlockBase : IGuerilla
    {
        internal SectorBlock[] sectors;
        internal SectorLinkBlock[] links;
        internal RefBlock[] refs;
        internal SectorBsp2dNodesBlock[] bsp2dNodes;
        internal SurfaceFlagsBlock[] surfaceFlags;
        internal SectorVertexBlock[] vertices;
        internal EnvironmentObjectRefs[] objectRefs;
        internal PathfindingHintsBlock[] pathfindingHints;
        internal InstancedGeometryReferenceBlock[] instancedGeometryRefs;
        internal int structureChecksum;
        internal byte[] invalidName_;
        internal UserHintBlock[] userPlacedHints;

        internal PathfindingDataBlockBase( BinaryReader binaryReader )
        {
            sectors = Guerilla.ReadBlockArray<SectorBlock>( binaryReader );
            links = Guerilla.ReadBlockArray<SectorLinkBlock>( binaryReader );
            refs = Guerilla.ReadBlockArray<RefBlock>( binaryReader );
            bsp2dNodes = Guerilla.ReadBlockArray<SectorBsp2dNodesBlock>( binaryReader );
            surfaceFlags = Guerilla.ReadBlockArray<SurfaceFlagsBlock>( binaryReader );
            vertices = Guerilla.ReadBlockArray<SectorVertexBlock>( binaryReader );
            objectRefs = Guerilla.ReadBlockArray<EnvironmentObjectRefs>( binaryReader );
            pathfindingHints = Guerilla.ReadBlockArray<PathfindingHintsBlock>( binaryReader );
            instancedGeometryRefs = Guerilla.ReadBlockArray<InstancedGeometryReferenceBlock>( binaryReader );
            structureChecksum = binaryReader.ReadInt32( );
            invalidName_ = binaryReader.ReadBytes( 32 );
            userPlacedHints = Guerilla.ReadBlockArray<UserHintBlock>( binaryReader );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                nextAddress = Guerilla.WriteBlockArray<SectorBlock>( binaryWriter, sectors, nextAddress );
                nextAddress = Guerilla.WriteBlockArray<SectorLinkBlock>( binaryWriter, links, nextAddress );
                nextAddress = Guerilla.WriteBlockArray<RefBlock>( binaryWriter, refs, nextAddress );
                nextAddress = Guerilla.WriteBlockArray<SectorBsp2dNodesBlock>( binaryWriter, bsp2dNodes, nextAddress );
                nextAddress = Guerilla.WriteBlockArray<SurfaceFlagsBlock>( binaryWriter, surfaceFlags, nextAddress );
                nextAddress = Guerilla.WriteBlockArray<SectorVertexBlock>( binaryWriter, vertices, nextAddress );
                nextAddress = Guerilla.WriteBlockArray<EnvironmentObjectRefs>( binaryWriter, objectRefs, nextAddress );
                nextAddress = Guerilla.WriteBlockArray<PathfindingHintsBlock>( binaryWriter, pathfindingHints,
                    nextAddress );
                nextAddress = Guerilla.WriteBlockArray<InstancedGeometryReferenceBlock>( binaryWriter,
                    instancedGeometryRefs, nextAddress );
                binaryWriter.Write( structureChecksum );
                binaryWriter.Write( invalidName_, 0, 32 );
                nextAddress = Guerilla.WriteBlockArray<UserHintBlock>( binaryWriter, userPlacedHints, nextAddress );
                return nextAddress;
            }
        }
    };
}