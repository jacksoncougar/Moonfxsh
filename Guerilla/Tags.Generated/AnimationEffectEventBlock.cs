// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class AnimationEffectEventBlock : AnimationEffectEventBlockBase
    {
        public AnimationEffectEventBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 4, Alignment = 4 )]
    public class AnimationEffectEventBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.ShortBlockIndex1 effect;
        internal short frame;

        public override int SerializedSize
        {
            get { return 4; }
        }

        internal AnimationEffectEventBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            effect = binaryReader.ReadShortBlockIndex1( );
            frame = binaryReader.ReadInt16( );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( effect );
                binaryWriter.Write( frame );
                return nextAddress;
            }
        }
    };
}