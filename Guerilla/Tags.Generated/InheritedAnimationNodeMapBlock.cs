// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class InheritedAnimationNodeMapBlock : InheritedAnimationNodeMapBlockBase
    {
        public InheritedAnimationNodeMapBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 2, Alignment = 4 )]
    public class InheritedAnimationNodeMapBlockBase : GuerillaBlock
    {
        internal short localNode;

        public override int SerializedSize
        {
            get { return 2; }
        }

        internal InheritedAnimationNodeMapBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            localNode = binaryReader.ReadInt16( );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( localNode );
                return nextAddress;
            }
        }
    };
}