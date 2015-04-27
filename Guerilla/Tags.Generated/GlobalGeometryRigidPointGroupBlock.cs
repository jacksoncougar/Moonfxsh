// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class GlobalGeometryRigidPointGroupBlock : GlobalGeometryRigidPointGroupBlockBase
    {
        public GlobalGeometryRigidPointGroupBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 4, Alignment = 4 )]
    public class GlobalGeometryRigidPointGroupBlockBase : IGuerilla
    {
        internal byte rigidNodeIndex;
        internal byte nodesPoint;
        internal short pointCount;

        internal GlobalGeometryRigidPointGroupBlockBase( BinaryReader binaryReader )
        {
            rigidNodeIndex = binaryReader.ReadByte( );
            nodesPoint = binaryReader.ReadByte( );
            pointCount = binaryReader.ReadInt16( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( rigidNodeIndex );
                binaryWriter.Write( nodesPoint );
                binaryWriter.Write( pointCount );
                return nextAddress;
            }
        }
    };
}