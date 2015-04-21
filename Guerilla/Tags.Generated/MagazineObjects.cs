// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class MagazineObjects : MagazineObjectsBase
    {
        public MagazineObjects( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 12, Alignment = 4 )]
    public class MagazineObjectsBase : IGuerilla
    {
        internal short rounds;
        internal byte[] invalidName_;
        [TagReference( "eqip" )] internal Moonfish.Tags.TagReference equipment;

        internal MagazineObjectsBase( BinaryReader binaryReader )
        {
            rounds = binaryReader.ReadInt16( );
            invalidName_ = binaryReader.ReadBytes( 2 );
            equipment = binaryReader.ReadTagReference( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( rounds );
                binaryWriter.Write( invalidName_, 0, 2 );
                binaryWriter.Write( equipment );
                return nextAddress;
            }
        }
    };
}