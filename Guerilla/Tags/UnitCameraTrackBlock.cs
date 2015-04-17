// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class UnitCameraTrackBlock : UnitCameraTrackBlockBase
    {
        public UnitCameraTrackBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 8, Alignment = 4 )]
    public class UnitCameraTrackBlockBase : IGuerilla
    {
        [TagReference( "trak" )] internal Moonfish.Tags.TagReference track;

        internal UnitCameraTrackBlockBase( BinaryReader binaryReader )
        {
            track = binaryReader.ReadTagReference( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( track );
                return nextAddress;
            }
        }
    };
}