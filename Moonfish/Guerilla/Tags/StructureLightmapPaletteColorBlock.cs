using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class StructureLightmapPaletteColorBlock
    {
        public byte[] GetColourPaletteData( )
        {
            var buffer = new byte[1024];
            using ( var binaryWriter = new BlamBinaryWriter( new MemoryStream( buffer ) ) )
            {
                binaryWriter.Write( FIRSTPaletteColor );
                binaryWriter.Write( fieldskip );
            }
            return buffer;
        }
    }
}
