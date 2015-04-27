// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class PrecacheListBlock : PrecacheListBlockBase
    {
        public PrecacheListBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 4, Alignment = 4 )]
    public class PrecacheListBlockBase : GuerillaBlock
    {
        internal int cacheBlockIndex;

        public override int SerializedSize
        {
            get { return 4; }
        }

        internal PrecacheListBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            cacheBlockIndex = binaryReader.ReadInt32( );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( cacheBlockIndex );
                return nextAddress;
            }
        }
    };
}