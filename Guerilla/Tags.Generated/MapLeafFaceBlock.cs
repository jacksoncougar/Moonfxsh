// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class MapLeafFaceBlock : MapLeafFaceBlockBase
    {
        public MapLeafFaceBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 12, Alignment = 4 )]
    public class MapLeafFaceBlockBase : IGuerilla
    {
        internal int nodeIndex;
        internal MapLeafFaceVertexBlock[] vertices;

        internal MapLeafFaceBlockBase( BinaryReader binaryReader )
        {
            nodeIndex = binaryReader.ReadInt32( );
            vertices = Guerilla.ReadBlockArray<MapLeafFaceVertexBlock>( binaryReader );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( nodeIndex );
                nextAddress = Guerilla.WriteBlockArray<MapLeafFaceVertexBlock>( binaryWriter, vertices, nextAddress );
                return nextAddress;
            }
        }
    };
}