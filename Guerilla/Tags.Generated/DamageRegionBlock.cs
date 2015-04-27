// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class DamageRegionBlock : DamageRegionBlockBase
    {
        public DamageRegionBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 4, Alignment = 4 )]
    public class DamageRegionBlockBase : IGuerilla
    {
        internal AnimationIndexStructBlock animation;

        internal DamageRegionBlockBase( BinaryReader binaryReader )
        {
            animation = new AnimationIndexStructBlock( binaryReader );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                animation.Write( binaryWriter );
                return nextAddress;
            }
        }
    };
}