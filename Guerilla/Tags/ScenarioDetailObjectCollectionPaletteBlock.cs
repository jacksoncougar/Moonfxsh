// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioDetailObjectCollectionPaletteBlock : ScenarioDetailObjectCollectionPaletteBlockBase
    {
        public ScenarioDetailObjectCollectionPaletteBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 40, Alignment = 4 )]
    public class ScenarioDetailObjectCollectionPaletteBlockBase : IGuerilla
    {
        [TagReference( "dobc" )] internal Moonfish.Tags.TagReference name;
        internal byte[] invalidName_;

        internal ScenarioDetailObjectCollectionPaletteBlockBase( BinaryReader binaryReader )
        {
            name = binaryReader.ReadTagReference( );
            invalidName_ = binaryReader.ReadBytes( 32 );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( name );
                binaryWriter.Write( invalidName_, 0, 32 );
                return nextAddress;
            }
        }
    };
}