// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ByteBlock : ByteBlockBase
    {
        public ByteBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 1, Alignment = 4 )]
    public class ByteBlockBase : GuerillaBlock
    {
        internal byte value;

        public override int SerializedSize
        {
            get { return 1; }
        }

        internal ByteBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            value = binaryReader.ReadByte( );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( value );
                return nextAddress;
            }
        }
    };
}