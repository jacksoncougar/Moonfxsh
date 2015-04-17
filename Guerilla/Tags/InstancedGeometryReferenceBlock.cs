// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class InstancedGeometryReferenceBlock : InstancedGeometryReferenceBlockBase
    {
        public InstancedGeometryReferenceBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 4, Alignment = 4 )]
    public class InstancedGeometryReferenceBlockBase : IGuerilla
    {
        internal short pathfindingObjectIndex;
        internal byte[] invalidName_;

        internal InstancedGeometryReferenceBlockBase( BinaryReader binaryReader )
        {
            pathfindingObjectIndex = binaryReader.ReadInt16( );
            invalidName_ = binaryReader.ReadBytes( 2 );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( pathfindingObjectIndex );
                binaryWriter.Write( invalidName_, 0, 2 );
                return nextAddress;
            }
        }
    };
}