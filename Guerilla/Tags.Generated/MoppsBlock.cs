// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class MoppsBlock : MoppsBlockBase
    {
        public MoppsBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 20, Alignment = 4 )]
    public class MoppsBlockBase : GuerillaBlock
    {
        internal byte[] invalidName_;
        internal short size;
        internal short count;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;
        internal Moonfish.Tags.ShortBlockIndex1 list;
        internal int codeOffset;

        public override int SerializedSize
        {
            get { return 20; }
        }

        internal MoppsBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            invalidName_ = binaryReader.ReadBytes( 4 );
            size = binaryReader.ReadInt16( );
            count = binaryReader.ReadInt16( );
            invalidName_0 = binaryReader.ReadBytes( 4 );
            invalidName_1 = binaryReader.ReadBytes( 2 );
            list = binaryReader.ReadShortBlockIndex1( );
            codeOffset = binaryReader.ReadInt32( );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( invalidName_, 0, 4 );
                binaryWriter.Write( size );
                binaryWriter.Write( count );
                binaryWriter.Write( invalidName_0, 0, 4 );
                binaryWriter.Write( invalidName_1, 0, 2 );
                binaryWriter.Write( list );
                binaryWriter.Write( codeOffset );
                return nextAddress;
            }
        }
    };
}