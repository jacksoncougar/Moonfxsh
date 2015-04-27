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
    public class ScenarioDetailObjectCollectionPaletteBlockBase : GuerillaBlock
    {
        [TagReference( "dobc" )] internal Moonfish.Tags.TagReference name;
        internal byte[] invalidName_;

        public override int SerializedSize
        {
            get { return 40; }
        }

        internal ScenarioDetailObjectCollectionPaletteBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            name = binaryReader.ReadTagReference( );
            invalidName_ = binaryReader.ReadBytes( 32 );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
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