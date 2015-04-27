// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class StructureBspClusterPortalBlock : StructureBspClusterPortalBlockBase
    {
        public StructureBspClusterPortalBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 36, Alignment = 4 )]
    public class StructureBspClusterPortalBlockBase : IGuerilla
    {
        internal short backCluster;
        internal short frontCluster;
        internal int planeIndex;
        internal OpenTK.Vector3 centroid;
        internal float boundingRadius;
        internal Flags flags;
        internal StructureBspClusterPortalVertexBlock[] vertices;

        internal StructureBspClusterPortalBlockBase( BinaryReader binaryReader )
        {
            backCluster = binaryReader.ReadInt16( );
            frontCluster = binaryReader.ReadInt16( );
            planeIndex = binaryReader.ReadInt32( );
            centroid = binaryReader.ReadVector3( );
            boundingRadius = binaryReader.ReadSingle( );
            flags = ( Flags ) binaryReader.ReadInt32( );
            vertices = Guerilla.ReadBlockArray<StructureBspClusterPortalVertexBlock>( binaryReader );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( backCluster );
                binaryWriter.Write( frontCluster );
                binaryWriter.Write( planeIndex );
                binaryWriter.Write( centroid );
                binaryWriter.Write( boundingRadius );
                binaryWriter.Write( ( Int32 ) flags );
                nextAddress = Guerilla.WriteBlockArray<StructureBspClusterPortalVertexBlock>( binaryWriter, vertices,
                    nextAddress );
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum Flags : int
        {
            AICannotHearThroughThis = 1,
            OneWay = 2,
            Door = 4,
            NoWay = 8,
            OneWayReversed = 16,
            NoOneCanHearThroughThis = 32,
        };
    };
}