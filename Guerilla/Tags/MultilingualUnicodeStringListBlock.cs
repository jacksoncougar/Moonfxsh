// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Unic = ( TagClass ) "unic";
    };
} ;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute( "unic" )]
    public partial class MultilingualUnicodeStringListBlock : MultilingualUnicodeStringListBlockBase
    {
        public MultilingualUnicodeStringListBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 52, Alignment = 4 )]
    public class MultilingualUnicodeStringListBlockBase : IGuerilla
    {
        internal MultilingualUnicodeStringReferenceBlock[] stringReferences;
        internal byte[] stringDataUtf8;
        internal byte[] invalidName_;

        internal MultilingualUnicodeStringListBlockBase( BinaryReader binaryReader )
        {
            stringReferences = Guerilla.ReadBlockArray<MultilingualUnicodeStringReferenceBlock>( binaryReader );
            stringDataUtf8 = Guerilla.ReadData( binaryReader );
            invalidName_ = binaryReader.ReadBytes( 36 );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                nextAddress = Guerilla.WriteBlockArray<MultilingualUnicodeStringReferenceBlock>( binaryWriter,
                    stringReferences, nextAddress );
                nextAddress = Guerilla.WriteData( binaryWriter, stringDataUtf8, nextAddress );
                binaryWriter.Write( invalidName_, 0, 36 );
                return nextAddress;
            }
        }
    };
}