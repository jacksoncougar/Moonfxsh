// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class GlobalLeafConnectionBlock : GlobalLeafConnectionBlockBase
    {
        public GlobalLeafConnectionBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 24, Alignment = 4 )]
    public class GlobalLeafConnectionBlockBase : IGuerilla
    {
        internal int planeIndex;
        internal int backLeafIndex;
        internal int frontLeafIndex;
        internal LeafConnectionVertexBlock[] vertices;
        internal float area;

        internal GlobalLeafConnectionBlockBase( BinaryReader binaryReader )
        {
            planeIndex = binaryReader.ReadInt32( );
            backLeafIndex = binaryReader.ReadInt32( );
            frontLeafIndex = binaryReader.ReadInt32( );
            vertices = Guerilla.ReadBlockArray<LeafConnectionVertexBlock>( binaryReader );
            area = binaryReader.ReadSingle( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( planeIndex );
                binaryWriter.Write( backLeafIndex );
                binaryWriter.Write( frontLeafIndex );
                nextAddress = Guerilla.WriteBlockArray<LeafConnectionVertexBlock>( binaryWriter, vertices, nextAddress );
                binaryWriter.Write( area );
                return nextAddress;
            }
        }
    };
}