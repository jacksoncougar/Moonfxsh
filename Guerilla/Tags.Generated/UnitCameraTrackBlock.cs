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
    public class UnitCameraTrackBlockBase : GuerillaBlock
    {
        [TagReference( "trak" )] internal Moonfish.Tags.TagReference track;

        public override int SerializedSize
        {
            get { return 8; }
        }

        internal UnitCameraTrackBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            track = binaryReader.ReadTagReference( );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( track );
                return nextAddress;
            }
        }
    };
}