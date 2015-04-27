// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class AiAnimationReferenceBlock : AiAnimationReferenceBlockBase
    {
        public AiAnimationReferenceBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 52, Alignment = 4 )]
    public class AiAnimationReferenceBlockBase : IGuerilla
    {
        internal Moonfish.Tags.String32 animationName;

        /// <summary>
        /// leave this blank to use the unit's normal animationGraph
        /// </summary>
        [TagReference( "jmad" )] internal Moonfish.Tags.TagReference animationGraph;

        internal byte[] invalidName_;

        internal AiAnimationReferenceBlockBase( BinaryReader binaryReader )
        {
            animationName = binaryReader.ReadString32( );
            animationGraph = binaryReader.ReadTagReference( );
            invalidName_ = binaryReader.ReadBytes( 12 );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( animationName );
                binaryWriter.Write( animationGraph );
                binaryWriter.Write( invalidName_, 0, 12 );
                return nextAddress;
            }
        }
    };
}