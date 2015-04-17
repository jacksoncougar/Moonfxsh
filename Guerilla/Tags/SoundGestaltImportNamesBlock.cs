// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class SoundGestaltImportNamesBlock : SoundGestaltImportNamesBlockBase
    {
        public SoundGestaltImportNamesBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 4, Alignment = 4 )]
    public class SoundGestaltImportNamesBlockBase : IGuerilla
    {
        internal Moonfish.Tags.StringID importName;

        internal SoundGestaltImportNamesBlockBase( BinaryReader binaryReader )
        {
            importName = binaryReader.ReadStringID( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( importName );
                return nextAddress;
            }
        }
    };
}