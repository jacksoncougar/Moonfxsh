// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class SoundsBlock : SoundsBlockBase
    {
        public SoundsBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 8, Alignment = 4 )]
    public class SoundsBlockBase : GuerillaBlock
    {
        [TagReference( "snd!" )] internal Moonfish.Tags.TagReference sound;

        public override int SerializedSize
        {
            get { return 8; }
        }

        internal SoundsBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            sound = binaryReader.ReadTagReference( );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( sound );
                return nextAddress;
            }
        }
    };
}