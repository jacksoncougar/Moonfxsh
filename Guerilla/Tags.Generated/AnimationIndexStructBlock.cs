// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class AnimationIndexStructBlock : AnimationIndexStructBlockBase
    {
        public AnimationIndexStructBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 4, Alignment = 4 )]
    public class AnimationIndexStructBlockBase : GuerillaBlock
    {
        internal short graphIndex;
        internal Moonfish.Tags.ShortBlockIndex1 animation;

        public override int SerializedSize
        {
            get { return 4; }
        }

        internal AnimationIndexStructBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            graphIndex = binaryReader.ReadInt16( );
            animation = binaryReader.ReadShortBlockIndex1( );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( graphIndex );
                binaryWriter.Write( animation );
                return nextAddress;
            }
        }
    };
}