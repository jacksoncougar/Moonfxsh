// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ShaderPostprocessColorPropertyBlock : ShaderPostprocessColorPropertyBlockBase
    {
        public ShaderPostprocessColorPropertyBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 12, Alignment = 4 )]
    public class ShaderPostprocessColorPropertyBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.ColorR8G8B8 color;

        public override int SerializedSize
        {
            get { return 12; }
        }

        internal ShaderPostprocessColorPropertyBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            color = binaryReader.ReadColorR8G8B8( );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( color );
                return nextAddress;
            }
        }
    };
}