// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class CollisionModelPermutationBlock : CollisionModelPermutationBlockBase
    {
        public CollisionModelPermutationBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 20, Alignment = 4 )]
    public class CollisionModelPermutationBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringID name;
        internal CollisionModelBspBlock[] bsps;
        internal CollisionBspPhysicsBlock[] bspPhysics;

        public override int SerializedSize
        {
            get { return 20; }
        }

        internal CollisionModelPermutationBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            name = binaryReader.ReadStringID( );
            bsps = Guerilla.ReadBlockArray<CollisionModelBspBlock>( binaryReader );
            bspPhysics = Guerilla.ReadBlockArray<CollisionBspPhysicsBlock>( binaryReader );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( name );
                nextAddress = Guerilla.WriteBlockArray<CollisionModelBspBlock>( binaryWriter, bsps, nextAddress );
                nextAddress = Guerilla.WriteBlockArray<CollisionBspPhysicsBlock>( binaryWriter, bspPhysics, nextAddress );
                return nextAddress;
            }
        }
    };
}