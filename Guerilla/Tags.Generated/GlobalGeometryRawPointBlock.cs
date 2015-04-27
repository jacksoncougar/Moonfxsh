// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class GlobalGeometryRawPointBlock : GlobalGeometryRawPointBlockBase
    {
        public GlobalGeometryRawPointBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 68, Alignment = 4 )]
    public class GlobalGeometryRawPointBlockBase : GuerillaBlock
    {
        internal OpenTK.Vector3 position;
        internal NodeIndicesOLD[] nodeIndicesOLD;
        internal NodeWeights[] nodeWeights;
        internal NodeIndicesNEW[] nodeIndicesNEW;
        internal int useNewNodeIndices;
        internal int adjustedCompoundNodeIndex;

        public override int SerializedSize
        {
            get { return 68; }
        }

        internal GlobalGeometryRawPointBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            position = binaryReader.ReadVector3( );
            nodeIndicesOLD = new[]
            {
                new NodeIndicesOLD( binaryReader ), new NodeIndicesOLD( binaryReader ), new NodeIndicesOLD( binaryReader ),
                new NodeIndicesOLD( binaryReader ),
            };
            nodeWeights = new[]
            {
                new NodeWeights( binaryReader ), new NodeWeights( binaryReader ), new NodeWeights( binaryReader ),
                new NodeWeights( binaryReader ),
            };
            nodeIndicesNEW = new[]
            {
                new NodeIndicesNEW( binaryReader ), new NodeIndicesNEW( binaryReader ), new NodeIndicesNEW( binaryReader ),
                new NodeIndicesNEW( binaryReader ),
            };
            useNewNodeIndices = binaryReader.ReadInt32( );
            adjustedCompoundNodeIndex = binaryReader.ReadInt32( );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( position );
                nodeIndicesOLD[ 0 ].Write( binaryWriter );
                nodeIndicesOLD[ 1 ].Write( binaryWriter );
                nodeIndicesOLD[ 2 ].Write( binaryWriter );
                nodeIndicesOLD[ 3 ].Write( binaryWriter );
                nodeWeights[ 0 ].Write( binaryWriter );
                nodeWeights[ 1 ].Write( binaryWriter );
                nodeWeights[ 2 ].Write( binaryWriter );
                nodeWeights[ 3 ].Write( binaryWriter );
                nodeIndicesNEW[ 0 ].Write( binaryWriter );
                nodeIndicesNEW[ 1 ].Write( binaryWriter );
                nodeIndicesNEW[ 2 ].Write( binaryWriter );
                nodeIndicesNEW[ 3 ].Write( binaryWriter );
                binaryWriter.Write( useNewNodeIndices );
                binaryWriter.Write( adjustedCompoundNodeIndex );
                return nextAddress;
            }
        }

        [LayoutAttribute( Size = 4, Alignment = 1 )]
        public class NodeIndicesOLD : GuerillaBlock
        {
            internal int nodeIndexOLD;

            public override int SerializedSize
            {
                get { return 4; }
            }

            internal NodeIndicesOLD( BinaryReader binaryReader ) : base( binaryReader )
            {
                nodeIndexOLD = binaryReader.ReadInt32( );
            }

            public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
            {
                using ( binaryWriter.BaseStream.Pin( ) )
                {
                    binaryWriter.Write( nodeIndexOLD );
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

        [LayoutAttribute( Size = 4, Alignment = 1 )]
        public class NodeIndicesNEW : GuerillaBlock
        {
            internal int nodeIndexNEW;

            public override int SerializedSize
            {
                get { return 4; }
            }

            internal NodeIndicesNEW( BinaryReader binaryReader ) : base( binaryReader )
            {
                nodeIndexNEW = binaryReader.ReadInt32( );
            }

            public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
            {
                using ( binaryWriter.BaseStream.Pin( ) )
                {
                    binaryWriter.Write( nodeIndexNEW );
                    return nextAddress;
                }
            }
        };
    };
}