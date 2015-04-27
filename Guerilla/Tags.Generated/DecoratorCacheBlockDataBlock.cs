// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class DecoratorCacheBlockDataBlock : DecoratorCacheBlockDataBlockBase
    {
        public DecoratorCacheBlockDataBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 136, Alignment = 4 )]
    public class DecoratorCacheBlockDataBlockBase : GuerillaBlock
    {
        internal DecoratorPlacementBlock[] placements;
        internal DecalVerticesBlock[] decalVertices;
        internal IndicesBlock[] decalIndices;
        internal Moonfish.Tags.VertexBuffer decalVertexBuffer;
        internal byte[] invalidName_;
        internal SpriteVerticesBlock[] spriteVertices;
        internal IndicesBlock[] spriteIndices;
        internal Moonfish.Tags.VertexBuffer spriteVertexBuffer;
        internal byte[] invalidName_0;

        public override int SerializedSize
        {
            get { return 136; }
        }

        internal DecoratorCacheBlockDataBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            placements = Guerilla.ReadBlockArray<DecoratorPlacementBlock>( binaryReader );
            decalVertices = Guerilla.ReadBlockArray<DecalVerticesBlock>( binaryReader );
            decalIndices = Guerilla.ReadBlockArray<IndicesBlock>( binaryReader );
            decalVertexBuffer = binaryReader.ReadVertexBuffer( );
            invalidName_ = binaryReader.ReadBytes( 16 );
            spriteVertices = Guerilla.ReadBlockArray<SpriteVerticesBlock>( binaryReader );
            spriteIndices = Guerilla.ReadBlockArray<IndicesBlock>( binaryReader );
            spriteVertexBuffer = binaryReader.ReadVertexBuffer( );
            invalidName_0 = binaryReader.ReadBytes( 16 );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                nextAddress = Guerilla.WriteBlockArray<DecoratorPlacementBlock>( binaryWriter, placements, nextAddress );
                nextAddress = Guerilla.WriteBlockArray<DecalVerticesBlock>( binaryWriter, decalVertices, nextAddress );
                nextAddress = Guerilla.WriteBlockArray<IndicesBlock>( binaryWriter, decalIndices, nextAddress );
                binaryWriter.Write( decalVertexBuffer );
                binaryWriter.Write( invalidName_, 0, 16 );
                nextAddress = Guerilla.WriteBlockArray<SpriteVerticesBlock>( binaryWriter, spriteVertices, nextAddress );
                nextAddress = Guerilla.WriteBlockArray<IndicesBlock>( binaryWriter, spriteIndices, nextAddress );
                binaryWriter.Write( spriteVertexBuffer );
                binaryWriter.Write( invalidName_0, 0, 16 );
                return nextAddress;
            }
        }
    };
}