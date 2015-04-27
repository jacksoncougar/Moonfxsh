// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class DamageAnimationBlock : DamageAnimationBlockBase
    {
        public DamageAnimationBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 12, Alignment = 4 )]
    public class DamageAnimationBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringID label;
        internal DamageDirectionBlock[] directionsAABBCC;

        public override int SerializedSize
        {
            get { return 12; }
        }

        internal DamageAnimationBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            label = binaryReader.ReadStringID( );
            directionsAABBCC = Guerilla.ReadBlockArray<DamageDirectionBlock>( binaryReader );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( label );
                nextAddress = Guerilla.WriteBlockArray<DamageDirectionBlock>( binaryWriter, directionsAABBCC,
                    nextAddress );
                return nextAddress;
            }
        }
    };
}