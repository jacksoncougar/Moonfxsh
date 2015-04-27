// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ShaderPostprocessColorOverlayBlock : ShaderPostprocessColorOverlayBlockBase
    {
        public ShaderPostprocessColorOverlayBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 21, Alignment = 4 )]
    public class ShaderPostprocessColorOverlayBlockBase : GuerillaBlock
    {
        internal byte parameterIndex;
        internal Moonfish.Tags.StringID inputName;
        internal Moonfish.Tags.StringID rangeName;
        internal float timePeriodInSeconds;
        internal ColorFunctionStructBlock function;

        public override int SerializedSize
        {
            get { return 21; }
        }

        internal ShaderPostprocessColorOverlayBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            parameterIndex = binaryReader.ReadByte( );
            inputName = binaryReader.ReadStringID( );
            rangeName = binaryReader.ReadStringID( );
            timePeriodInSeconds = binaryReader.ReadSingle( );
            function = new ColorFunctionStructBlock( binaryReader );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( parameterIndex );
                binaryWriter.Write( inputName );
                binaryWriter.Write( rangeName );
                binaryWriter.Write( timePeriodInSeconds );
                function.Write( binaryWriter );
                return nextAddress;
            }
        }
    };
}