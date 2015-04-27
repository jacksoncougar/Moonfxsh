// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class WeaponsBlock : WeaponsBlockBase
    {
        public WeaponsBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 8, Alignment = 4 )]
    public class WeaponsBlockBase : GuerillaBlock
    {
        [TagReference( "item" )] internal Moonfish.Tags.TagReference weapon;

        public override int SerializedSize
        {
            get { return 8; }
        }

        internal WeaponsBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            weapon = binaryReader.ReadTagReference( );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( weapon );
                return nextAddress;
            }
        }
    };
}