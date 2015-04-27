// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ModelRegionBlock : ModelRegionBlockBase
    {
        public ModelRegionBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 16, Alignment = 4 )]
    public class ModelRegionBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringID name;
        internal byte collisionRegionIndex;
        internal byte physicsRegionIndex;
        internal byte[] invalidName_;
        internal ModelPermutationBlock[] permutations;

        public override int SerializedSize
        {
            get { return 16; }
        }

        internal ModelRegionBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            name = binaryReader.ReadStringID( );
            collisionRegionIndex = binaryReader.ReadByte( );
            physicsRegionIndex = binaryReader.ReadByte( );
            invalidName_ = binaryReader.ReadBytes( 2 );
            permutations = Guerilla.ReadBlockArray<ModelPermutationBlock>( binaryReader );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( name );
                binaryWriter.Write( collisionRegionIndex );
                binaryWriter.Write( physicsRegionIndex );
                binaryWriter.Write( invalidName_, 0, 2 );
                nextAddress = Guerilla.WriteBlockArray<ModelPermutationBlock>( binaryWriter, permutations, nextAddress );
                return nextAddress;
            }
        }
    };
}