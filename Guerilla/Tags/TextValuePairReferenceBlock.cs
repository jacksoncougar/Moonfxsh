// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class TextValuePairReferenceBlock : TextValuePairReferenceBlockBase
    {
        public TextValuePairReferenceBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 12, Alignment = 4 )]
    public class TextValuePairReferenceBlockBase : IGuerilla
    {
        internal Flags flags;
        internal int value;
        internal Moonfish.Tags.StringID labelStringId;

        internal TextValuePairReferenceBlockBase( BinaryReader binaryReader )
        {
            flags = ( Flags ) binaryReader.ReadInt32( );
            value = binaryReader.ReadInt32( );
            labelStringId = binaryReader.ReadStringID( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( ( Int32 ) flags );
                binaryWriter.Write( value );
                binaryWriter.Write( labelStringId );
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum Flags : int
        {
            DefaultSetting = 1,
        };
    };
}