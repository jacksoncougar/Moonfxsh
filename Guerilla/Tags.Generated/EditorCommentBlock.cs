// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class EditorCommentBlock : EditorCommentBlockBase
    {
        public EditorCommentBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 304, Alignment = 4 )]
    public class EditorCommentBlockBase : GuerillaBlock
    {
        internal OpenTK.Vector3 position;
        internal Type type;
        internal Moonfish.Tags.String32 name;
        internal Moonfish.Tags.String256 comment;

        public override int SerializedSize
        {
            get { return 304; }
        }

        internal EditorCommentBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            position = binaryReader.ReadVector3( );
            type = ( Type ) binaryReader.ReadInt32( );
            name = binaryReader.ReadString32( );
            comment = binaryReader.ReadString256( );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( position );
                binaryWriter.Write( ( Int32 ) type );
                binaryWriter.Write( name );
                binaryWriter.Write( comment );
                return nextAddress;
            }
        }

        internal enum Type : int
        {
            Generic = 0,
        };
    };
}