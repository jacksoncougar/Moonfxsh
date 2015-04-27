// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ShaderPostprocessValueBlock : ShaderPostprocessValueBlockBase
    {
        public ShaderPostprocessValueBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 5, Alignment = 4 )]
    public class ShaderPostprocessValueBlockBase : GuerillaBlock
    {
        internal byte parameterIndex;
        internal float value;

        public override int SerializedSize
        {
            get { return 5; }
        }

        internal ShaderPostprocessValueBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            parameterIndex = binaryReader.ReadByte( );
            value = binaryReader.ReadSingle( );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( parameterIndex );
                binaryWriter.Write( value );
                return nextAddress;
            }
        }
    };
}