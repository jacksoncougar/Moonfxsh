// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class Pixel32Block : Pixel32BlockBase
    {
        public Pixel32Block( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 4, Alignment = 4 )]
    public class Pixel32BlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.ColourA1R1G1B1 color;

        public override int SerializedSize
        {
            get { return 4; }
        }

        internal Pixel32BlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            color = binaryReader.ReadColourA1R1G1B1( );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( color );
                return nextAddress;
            }
        }
    };
}