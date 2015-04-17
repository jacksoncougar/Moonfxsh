// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class StructureBspEnvironmentObjectPaletteBlock : StructureBspEnvironmentObjectPaletteBlockBase
    {
        public StructureBspEnvironmentObjectPaletteBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 20, Alignment = 4 )]
    public class StructureBspEnvironmentObjectPaletteBlockBase : IGuerilla
    {
        [TagReference( "scen" )] internal Moonfish.Tags.TagReference definition;
        [TagReference( "mode" )] internal Moonfish.Tags.TagReference model;
        internal byte[] invalidName_;

        internal StructureBspEnvironmentObjectPaletteBlockBase( BinaryReader binaryReader )
        {
            definition = binaryReader.ReadTagReference( );
            model = binaryReader.ReadTagReference( );
            invalidName_ = binaryReader.ReadBytes( 4 );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( definition );
                binaryWriter.Write( model );
                binaryWriter.Write( invalidName_, 0, 4 );
                return nextAddress;
            }
        }
    };
}