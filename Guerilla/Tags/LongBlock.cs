// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class LongBlock : LongBlockBase
    {
        public LongBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 4, Alignment = 4 )]
    public class LongBlockBase : IGuerilla
    {
        internal int bitmapGroupIndex;

        internal LongBlockBase( BinaryReader binaryReader )
        {
            bitmapGroupIndex = binaryReader.ReadInt32( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( bitmapGroupIndex );
                return nextAddress;
            }
        }
    };
}