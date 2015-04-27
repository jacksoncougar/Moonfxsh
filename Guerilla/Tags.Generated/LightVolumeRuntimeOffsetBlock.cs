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
    public class LightVolumeRuntimeOffsetBlockBase : GuerillaBlock
    {
        internal OpenTK.Vector2 invalidName_;

        public override int SerializedSize
        {
            get { return 8; }
        }

        internal LightVolumeRuntimeOffsetBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            invalidName_ = binaryReader.ReadVector2( );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( invalidName_ );
                return nextAddress;
            }
        }
    };
}