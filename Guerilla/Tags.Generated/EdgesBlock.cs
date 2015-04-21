// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class EdgesBlock : EdgesBlockBase
    {
        public EdgesBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 12, Alignment = 4 )]
    public class EdgesBlockBase : IGuerilla
    {
        internal short startVertex;
        internal short endVertex;
        internal short forwardEdge;
        internal short reverseEdge;
        internal short leftSurface;
        internal short rightSurface;

        internal EdgesBlockBase( BinaryReader binaryReader )
        {
            startVertex = binaryReader.ReadInt16( );
            endVertex = binaryReader.ReadInt16( );
            forwardEdge = binaryReader.ReadInt16( );
            reverseEdge = binaryReader.ReadInt16( );
            leftSurface = binaryReader.ReadInt16( );
            rightSurface = binaryReader.ReadInt16( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( startVertex );
                binaryWriter.Write( endVertex );
                binaryWriter.Write( forwardEdge );
                binaryWriter.Write( reverseEdge );
                binaryWriter.Write( leftSurface );
                binaryWriter.Write( rightSurface );
                return nextAddress;
            }
        }
    };
}