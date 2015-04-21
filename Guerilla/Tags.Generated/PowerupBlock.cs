// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class PowerupBlock : PowerupBlockBase
    {
        public PowerupBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 8, Alignment = 4 )]
    public class PowerupBlockBase : IGuerilla
    {
        [TagReference( "eqip" )] internal Moonfish.Tags.TagReference weapon;

        internal PowerupBlockBase( BinaryReader binaryReader )
        {
            weapon = binaryReader.ReadTagReference( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( weapon );
                return nextAddress;
            }
        }
    };
}