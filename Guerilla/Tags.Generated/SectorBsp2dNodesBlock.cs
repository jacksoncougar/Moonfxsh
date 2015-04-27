// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class SectorBsp2dNodesBlock : SectorBsp2dNodesBlockBase
    {
        public SectorBsp2dNodesBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 20, Alignment = 4 )]
    public class SectorBsp2dNodesBlockBase : IGuerilla
    {
        internal OpenTK.Vector3 plane;
        internal int leftChild;
        internal int rightChild;

        internal SectorBsp2dNodesBlockBase( BinaryReader binaryReader )
        {
            plane = binaryReader.ReadVector3( );
            leftChild = binaryReader.ReadInt32( );
            rightChild = binaryReader.ReadInt32( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( plane );
                binaryWriter.Write( leftChild );
                binaryWriter.Write( rightChild );
                return nextAddress;
            }
        }
    };
}