// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class PlatformSoundEffectConstantBlock : PlatformSoundEffectConstantBlockBase
    {
        public PlatformSoundEffectConstantBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 4, Alignment = 4 )]
    public class PlatformSoundEffectConstantBlockBase : GuerillaBlock
    {
        internal float constantValue;

        public override int SerializedSize
        {
            get { return 4; }
        }

        internal PlatformSoundEffectConstantBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            constantValue = binaryReader.ReadSingle( );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( constantValue );
                return nextAddress;
            }
        }
    };
}