// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ShaderPostprocessBitmapPropertyBlock : ShaderPostprocessBitmapPropertyBlockBase
    {
        public ShaderPostprocessBitmapPropertyBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 4, Alignment = 4 )]
    public class ShaderPostprocessBitmapPropertyBlockBase : GuerillaBlock
    {
        internal short bitmapIndex;
        internal short animatedParameterIndex;

        public override int SerializedSize
        {
            get { return 4; }
        }

        internal ShaderPostprocessBitmapPropertyBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            bitmapIndex = binaryReader.ReadInt16( );
            animatedParameterIndex = binaryReader.ReadInt16( );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( bitmapIndex );
                binaryWriter.Write( animatedParameterIndex );
                return nextAddress;
            }
        }
    };
}