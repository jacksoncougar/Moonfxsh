// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class StylePaletteBlock : StylePaletteBlockBase
    {
        public StylePaletteBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 8, Alignment = 4 )]
    public class StylePaletteBlockBase : IGuerilla
    {
        [TagReference( "styl" )] internal Moonfish.Tags.TagReference reference;

        internal StylePaletteBlockBase( BinaryReader binaryReader )
        {
            reference = binaryReader.ReadTagReference( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( reference );
                return nextAddress;
            }
        }
    };
}