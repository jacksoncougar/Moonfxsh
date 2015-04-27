// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Garb = ( TagClass ) "garb";
    };
} ;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute( "garb" )]
    public partial class GarbageBlock : GarbageBlockBase
    {
        public GarbageBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 168, Alignment = 4 )]
    public class GarbageBlockBase : ItemBlock
    {
        internal byte[] invalidName_;

        internal GarbageBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            invalidName_ = binaryReader.ReadBytes( 168 );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( invalidName_, 0, 168 );
                return nextAddress;
            }
        }
    };
}