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
        public static readonly TagClass Cmnt = ( TagClass ) "/**/";
    };
} ;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute( "/**/" )]
    public partial class ScenarioCommentsResourceBlock : ScenarioCommentsResourceBlockBase
    {
        public ScenarioCommentsResourceBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 8, Alignment = 4 )]
    public class ScenarioCommentsResourceBlockBase : IGuerilla
    {
        internal EditorCommentBlock[] comments;

        internal ScenarioCommentsResourceBlockBase( BinaryReader binaryReader )
        {
            comments = Guerilla.ReadBlockArray<EditorCommentBlock>( binaryReader );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                nextAddress = Guerilla.WriteBlockArray<EditorCommentBlock>( binaryWriter, comments, nextAddress );
                return nextAddress;
            }
        }
    };
}