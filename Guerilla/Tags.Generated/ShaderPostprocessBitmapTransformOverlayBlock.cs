// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ShaderPostprocessBitmapTransformOverlayBlock : ShaderPostprocessBitmapTransformOverlayBlockBase
    {
        public ShaderPostprocessBitmapTransformOverlayBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 23, Alignment = 4 )]
    public class ShaderPostprocessBitmapTransformOverlayBlockBase : IGuerilla
    {
        internal byte parameterIndex;
        internal byte transformIndex;
        internal byte animationPropertyType;
        internal Moonfish.Tags.StringID inputName;
        internal Moonfish.Tags.StringID rangeName;
        internal float timePeriodInSeconds;
        internal ScalarFunctionStructBlock function;

        internal ShaderPostprocessBitmapTransformOverlayBlockBase( BinaryReader binaryReader )
        {
            parameterIndex = binaryReader.ReadByte( );
            transformIndex = binaryReader.ReadByte( );
            animationPropertyType = binaryReader.ReadByte( );
            inputName = binaryReader.ReadStringID( );
            rangeName = binaryReader.ReadStringID( );
            timePeriodInSeconds = binaryReader.ReadSingle( );
            function = new ScalarFunctionStructBlock( binaryReader );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( parameterIndex );
                binaryWriter.Write( transformIndex );
                binaryWriter.Write( animationPropertyType );
                binaryWriter.Write( inputName );
                binaryWriter.Write( rangeName );
                binaryWriter.Write( timePeriodInSeconds );
                function.Write( binaryWriter );
                return nextAddress;
            }
        }
    };
}