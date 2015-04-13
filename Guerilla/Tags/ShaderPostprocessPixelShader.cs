using Moonfish.Tags;
using Moonfish.Tags.BlamExtension;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ShaderPostprocessPixelShader : ShaderPostprocessPixelShaderBase
    {
        public ShaderPostprocessPixelShader( BinaryReader binaryReader )
            : base( binaryReader )
        {

        }
    };
    [LayoutAttribute( Size = 44 )]
    public class ShaderPostprocessPixelShaderBase
    {
        internal int pixelShaderHandleRuntime;
        internal int pixelShaderHandleRuntime0;
        internal int pixelShaderHandleRuntime1;
        internal ShaderPostprocessPixelShaderConstantDefaults[] constantRegisterDefaults;
        internal byte[] compiledShader;
        internal byte[] compiledShader0;
        internal byte[] compiledShader1;
        internal ShaderPostprocessPixelShaderBase( BinaryReader binaryReader )
        {
            this.pixelShaderHandleRuntime = binaryReader.ReadInt32();
            this.pixelShaderHandleRuntime0 = binaryReader.ReadInt32();
            this.pixelShaderHandleRuntime1 = binaryReader.ReadInt32();
            this.constantRegisterDefaults = ReadShaderPostprocessPixelShaderConstantDefaultsArray( binaryReader );
            this.compiledShader = ReadData( binaryReader );
            this.compiledShader0 = ReadData( binaryReader );
            this.compiledShader1 = ReadData( binaryReader );
        }
        internal virtual byte[] ReadData( BinaryReader binaryReader )
        {
            var blamPointer = binaryReader.ReadBlamPointer( 1 );
            var data = new byte[ blamPointer.elementCount ];
            if ( blamPointer.elementCount > 0 )
            {
                using ( binaryReader.BaseStream.Pin() )
                {
                    binaryReader.BaseStream.Position = blamPointer[ 0 ];
                    data = binaryReader.ReadBytes( blamPointer.elementCount );
                }
            }
            return data;
        }
        internal virtual ShaderPostprocessPixelShaderConstantDefaults[] ReadShaderPostprocessPixelShaderConstantDefaultsArray( BinaryReader binaryReader )
        {
            var elementSize = Deserializer.SizeOf( typeof( ShaderPostprocessPixelShaderConstantDefaults ) );
            var blamPointer = binaryReader.ReadBlamPointer( elementSize );
            var array = new ShaderPostprocessPixelShaderConstantDefaults[ blamPointer.elementCount ];
            using ( binaryReader.BaseStream.Pin() )
            {
                for ( int i = 0; i < blamPointer.elementCount; ++i )
                {
                    binaryReader.BaseStream.Position = blamPointer[ i ];
                    array[ i ] = new ShaderPostprocessPixelShaderConstantDefaults( binaryReader );
                }
            }
            return array;
        }
    };
}
