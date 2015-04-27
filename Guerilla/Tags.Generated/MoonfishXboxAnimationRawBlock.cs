// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class MoonfishXboxAnimationRawBlock : MoonfishXboxAnimationRawBlockBase
    {
        public MoonfishXboxAnimationRawBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 20, Alignment = 4 )]
    public class MoonfishXboxAnimationRawBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.TagIdent ownerTag;
        internal int blockSize;
        internal int blockLength;
        internal int unknown;
        internal int unknown1;

        public override int SerializedSize
        {
            get { return 20; }
        }

        internal MoonfishXboxAnimationRawBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            ownerTag = binaryReader.ReadTagIdent( );
            blockSize = binaryReader.ReadInt32( );
            blockLength = binaryReader.ReadInt32( );
            unknown = binaryReader.ReadInt32( );
            unknown1 = binaryReader.ReadInt32( );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( ownerTag );
                binaryWriter.Write( blockSize );
                binaryWriter.Write( blockLength );
                binaryWriter.Write( unknown );
                binaryWriter.Write( unknown1 );
                return nextAddress;
            }
        }
    };
}