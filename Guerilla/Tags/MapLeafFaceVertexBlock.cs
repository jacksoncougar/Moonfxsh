// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class MapLeafFaceVertexBlock : MapLeafFaceVertexBlockBase
    {
        public MapLeafFaceVertexBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 12, Alignment = 4 )]
    public class MapLeafFaceVertexBlockBase : IGuerilla
    {
        internal OpenTK.Vector3 vertex;

        internal MapLeafFaceVertexBlockBase( BinaryReader binaryReader )
        {
            vertex = binaryReader.ReadVector3( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( vertex );
                return nextAddress;
            }
        }
    };
}