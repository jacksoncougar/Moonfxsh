// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class RenderModelCompoundNodeBlock : RenderModelCompoundNodeBlockBase
    {
        public RenderModelCompoundNodeBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 16, Alignment = 4 )]
    public class RenderModelCompoundNodeBlockBase : IGuerilla
    {
        internal NodeIndices[] nodeIndices;
        internal NodeWeights[] nodeWeights;

        internal RenderModelCompoundNodeBlockBase( BinaryReader binaryReader )
        {
            nodeIndices = new[]
            {
                new NodeIndices( binaryReader ), new NodeIndices( binaryReader ), new NodeIndices( binaryReader ),
                new NodeIndices( binaryReader ),
            };
            nodeWeights = new[]
            {new NodeWeights( binaryReader ), new NodeWeights( binaryReader ), new NodeWeights( binaryReader ),};
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                nodeIndices[ 0 ].Write( binaryWriter );
                nodeIndices[ 1 ].Write( binaryWriter );
                nodeIndices[ 2 ].Write( binaryWriter );
                nodeIndices[ 3 ].Write( binaryWriter );
                nodeWeights[ 0 ].Write( binaryWriter );
                nodeWeights[ 1 ].Write( binaryWriter );
                nodeWeights[ 2 ].Write( binaryWriter );
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