using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moonfish.Guerilla.Tags
{
    public partial class StructureLightmapPaletteColorBlock
    {
        public byte[] GetColourPaletteData( )
        {
            var buffer = new byte[1024];
            using ( var binaryWriter = new BinaryWriter( new MemoryStream( buffer ) ) )
            {
                binaryWriter.Write( FIRSTPaletteColor );
                binaryWriter.Write( fieldskip );
            }
            return buffer;
        }
    }
}
