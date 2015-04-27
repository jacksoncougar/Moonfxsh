// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class CollisionModelNodeBlock : CollisionModelNodeBlockBase
    {
        public CollisionModelNodeBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 12, Alignment = 4 )]
    public class CollisionModelNodeBlockBase : IGuerilla
    {
        internal Moonfish.Tags.StringID name;
        internal byte[] invalidName_;
        internal Moonfish.Tags.ShortBlockIndex1 parentNode;
        internal Moonfish.Tags.ShortBlockIndex1 nextSiblingNode;
        internal Moonfish.Tags.ShortBlockIndex1 firstChildNode;

        internal CollisionModelNodeBlockBase( BinaryReader binaryReader )
        {
            name = binaryReader.ReadStringID( );
            invalidName_ = binaryReader.ReadBytes( 2 );
            parentNode = binaryReader.ReadShortBlockIndex1( );
            nextSiblingNode = binaryReader.ReadShortBlockIndex1( );
            firstChildNode = binaryReader.ReadShortBlockIndex1( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( name );
                binaryWriter.Write( invalidName_, 0, 2 );
                binaryWriter.Write( parentNode );
                binaryWriter.Write( nextSiblingNode );
                binaryWriter.Write( firstChildNode );
                return nextAddress;
            }
        }
    };
}