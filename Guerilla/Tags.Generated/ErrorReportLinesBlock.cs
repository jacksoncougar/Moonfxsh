// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ErrorReportLinesBlock : ErrorReportLinesBlockBase
    {
        public ErrorReportLinesBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 58, Alignment = 4 )]
    public class ErrorReportLinesBlockBase : IGuerilla
    {
        internal Points[] points;
        internal NodeWeights[] nodeWeights;

        internal ErrorReportLinesBlockBase( BinaryReader binaryReader )
        {
            points = new[] {new Points( binaryReader ), new Points( binaryReader ),};
            nodeWeights = new[]
            {
                new NodeWeights( binaryReader ), new NodeWeights( binaryReader ), new NodeWeights( binaryReader ),
                new NodeWeights( binaryReader ),
            };
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                points[ 0 ].Write( binaryWriter );
                points[ 1 ].Write( binaryWriter );
                nodeWeights[ 0 ].Write( binaryWriter );
                nodeWeights[ 1 ].Write( binaryWriter );
                nodeWeights[ 2 ].Write( binaryWriter );
                nodeWeights[ 3 ].Write( binaryWriter );
                return nextAddress;
            }
        }

        public class Points : IGuerilla
        {
            internal OpenTK.Vector3 position;
            internal NodeIndices[] nodeIndices;

            internal Points( BinaryReader binaryReader )
            {
                position = binaryReader.ReadVector3( );
                nodeIndices = new[]
                {
                    new NodeIndices( binaryReader ), new NodeIndices( binaryReader ), new NodeIndices( binaryReader ),
                    new NodeIndices( binaryReader ),
                };
            }

            public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
            {
                using ( binaryWriter.BaseStream.Pin( ) )
                {
                    binaryWriter.Write( position );
                    nodeIndices[ 0 ].Write( binaryWriter );
                    nodeIndices[ 1 ].Write( binaryWriter );
                    nodeIndices[ 2 ].Write( binaryWriter );
                    nodeIndices[ 3 ].Write( binaryWriter );
                    return nextAddress;
                }
            }

            public class NodeIndices : IGuerilla
            {
                internal byte nodeIndex;

                internal NodeIndices( BinaryReader binaryReader )
                {
                    nodeIndex = binaryReader.ReadByte( );
                }

                public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
                {
                    using ( binaryWriter.BaseStream.Pin( ) )
                    {
                        binaryWriter.Write( nodeIndex );
                        return nextAddress;
                    }
                }
            };
        };

        public class NodeWeights : IGuerilla
        {
            internal float nodeWeight;

            internal NodeWeights( BinaryReader binaryReader )
            {
                nodeWeight = binaryReader.ReadSingle( );
            }

            public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
            {
                using ( binaryWriter.BaseStream.Pin( ) )
                {
                    binaryWriter.Write( nodeWeight );
                    return nextAddress;
                }
            }
        };
    };
}