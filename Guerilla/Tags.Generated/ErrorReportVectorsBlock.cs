// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ErrorReportVectorsBlock : ErrorReportVectorsBlockBase
    {
        public ErrorReportVectorsBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 64, Alignment = 4 )]
    public class ErrorReportVectorsBlockBase : GuerillaBlock
    {
        internal OpenTK.Vector3 position;
        internal NodeIndices[] nodeIndices;
        internal NodeWeights[] nodeWeights;
        internal OpenTK.Vector4 color;
        internal OpenTK.Vector3 normal;
        internal float screenLength;

        public override int SerializedSize
        {
            get { return 64; }
        }

        internal ErrorReportVectorsBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            position = binaryReader.ReadVector3( );
            nodeIndices = new[]
            {
                new NodeIndices( binaryReader ), new NodeIndices( binaryReader ), new NodeIndices( binaryReader ),
                new NodeIndices( binaryReader ),
            };
            nodeWeights = new[]
            {
                new NodeWeights( binaryReader ), new NodeWeights( binaryReader ), new NodeWeights( binaryReader ),
                new NodeWeights( binaryReader ),
            };
            color = binaryReader.ReadVector4( );
            normal = binaryReader.ReadVector3( );
            screenLength = binaryReader.ReadSingle( );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( position );
                nodeIndices[ 0 ].Write( binaryWriter );
                nodeIndices[ 1 ].Write( binaryWriter );
                nodeIndices[ 2 ].Write( binaryWriter );
                nodeIndices[ 3 ].Write( binaryWriter );
                nodeWeights[ 0 ].Write( binaryWriter );
                nodeWeights[ 1 ].Write( binaryWriter );
                nodeWeights[ 2 ].Write( binaryWriter );
                nodeWeights[ 3 ].Write( binaryWriter );
                binaryWriter.Write( color );
                binaryWriter.Write( normal );
                binaryWriter.Write( screenLength );
                return nextAddress;
            }
        }

        [LayoutAttribute( Size = 1, Alignment = 1 )]
        public class NodeIndices : GuerillaBlock
        {
            internal byte nodeIndex;

            public override int SerializedSize
            {
                get { return 1; }
            }

            internal NodeIndices( BinaryReader binaryReader ) : base( binaryReader )
            {
                nodeIndex = binaryReader.ReadByte( );
            }

            public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
            {
                using ( binaryWriter.BaseStream.Pin( ) )
                {
                    binaryWriter.Write( nodeIndex );
                    return nextAddress;
                }
            }
        };

        [LayoutAttribute( Size = 4, Alignment = 1 )]
        public class NodeWeights : GuerillaBlock
        {
            internal float nodeWeight;

            public override int SerializedSize
            {
                get { return 4; }
            }

            internal NodeWeights( BinaryReader binaryReader ) : base( binaryReader )
            {
                nodeWeight = binaryReader.ReadSingle( );
            }

            public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
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