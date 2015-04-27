// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class GlobalCollisionBspBlock : GlobalCollisionBspBlockBase
    {
        public GlobalCollisionBspBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 64, Alignment = 4 )]
    public class GlobalCollisionBspBlockBase : IGuerilla
    {
        internal Bsp3dNodesBlock[] bSP3DNodes;
        internal PlanesBlock[] planes;
        internal LeavesBlock[] leaves;
        internal Bsp2dReferencesBlock[] bSP2DReferences;
        internal Bsp2dNodesBlock[] bSP2DNodes;
        internal SurfacesBlock[] surfaces;
        internal EdgesBlock[] edges;
        internal VerticesBlock[] vertices;

        internal GlobalCollisionBspBlockBase( BinaryReader binaryReader )
        {
            bSP3DNodes = Guerilla.ReadBlockArray<Bsp3dNodesBlock>( binaryReader );
            planes = Guerilla.ReadBlockArray<PlanesBlock>( binaryReader );
            leaves = Guerilla.ReadBlockArray<LeavesBlock>( binaryReader );
            bSP2DReferences = Guerilla.ReadBlockArray<Bsp2dReferencesBlock>( binaryReader );
            bSP2DNodes = Guerilla.ReadBlockArray<Bsp2dNodesBlock>( binaryReader );
            surfaces = Guerilla.ReadBlockArray<SurfacesBlock>( binaryReader );
            edges = Guerilla.ReadBlockArray<EdgesBlock>( binaryReader );
            vertices = Guerilla.ReadBlockArray<VerticesBlock>( binaryReader );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                nextAddress = Guerilla.WriteBlockArray<Bsp3dNodesBlock>( binaryWriter, bSP3DNodes, nextAddress );
                nextAddress = Guerilla.WriteBlockArray<PlanesBlock>( binaryWriter, planes, nextAddress );
                nextAddress = Guerilla.WriteBlockArray<LeavesBlock>( binaryWriter, leaves, nextAddress );
                nextAddress = Guerilla.WriteBlockArray<Bsp2dReferencesBlock>( binaryWriter, bSP2DReferences, nextAddress );
                nextAddress = Guerilla.WriteBlockArray<Bsp2dNodesBlock>( binaryWriter, bSP2DNodes, nextAddress );
                nextAddress = Guerilla.WriteBlockArray<SurfacesBlock>( binaryWriter, surfaces, nextAddress );
                nextAddress = Guerilla.WriteBlockArray<EdgesBlock>( binaryWriter, edges, nextAddress );
                nextAddress = Guerilla.WriteBlockArray<VerticesBlock>( binaryWriter, vertices, nextAddress );
                return nextAddress;
            }
        }
    };
}