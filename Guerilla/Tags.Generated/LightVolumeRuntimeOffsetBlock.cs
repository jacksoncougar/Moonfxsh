// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class LightVolumeRuntimeOffsetBlock : LightVolumeRuntimeOffsetBlockBase
    {
        public LightVolumeRuntimeOffsetBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 8, Alignment = 4 )]
    public class LightVolumeRuntimeOffsetBlockBase : IGuerilla
    {
        internal OpenTK.Vector2 invalidName_;

        internal LightVolumeRuntimeOffsetBlockBase( BinaryReader binaryReader )
        {
            invalidName_ = binaryReader.ReadVector2( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( invalidName_ );
                return nextAddress;
            }
        }
    };
}