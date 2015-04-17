// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class StructureBspLightmapDataBlock : StructureBspLightmapDataBlockBase
    {
        public StructureBspLightmapDataBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 8, Alignment = 4 )]
    public class StructureBspLightmapDataBlockBase : IGuerilla
    {
        [TagReference( "bitm" )] internal Moonfish.Tags.TagReference bitmapGroup;

        internal StructureBspLightmapDataBlockBase( BinaryReader binaryReader )
        {
            bitmapGroup = binaryReader.ReadTagReference( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( bitmapGroup );
                return nextAddress;
            }
        }
    };
}