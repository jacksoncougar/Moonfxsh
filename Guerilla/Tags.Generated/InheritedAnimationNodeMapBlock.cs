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
    public class InheritedAnimationNodeMapBlockBase : IGuerilla
    {
        internal short localNode;

        internal InheritedAnimationNodeMapBlockBase( BinaryReader binaryReader )
        {
            localNode = binaryReader.ReadInt16( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( localNode );
                return nextAddress;
            }
        }
    };
}