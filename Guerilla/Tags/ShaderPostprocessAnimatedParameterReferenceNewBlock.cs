using Moonfish.Tags;
using Moonfish.Tags.BlamExtension;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ShaderPostprocessAnimatedParameterReferenceNewBlock : ShaderPostprocessAnimatedParameterReferenceNewBlockBase
    {
        public ShaderPostprocessAnimatedParameterReferenceNewBlock( BinaryReader binaryReader )
            : base( binaryReader )
        {

        }
    };
    [LayoutAttribute( Size = 4 )]
    public class ShaderPostprocessAnimatedParameterReferenceNewBlockBase
    {
        internal byte[] invalidName_;
        internal byte parameterIndex;
        internal ShaderPostprocessAnimatedParameterReferenceNewBlockBase( BinaryReader binaryReader )
        {
            this.invalidName_ = binaryReader.ReadBytes( 3 );
            this.parameterIndex = binaryReader.ReadByte();
        }
        internal virtual byte[] ReadData( BinaryReader binaryReader )
        {
            var blamPointer = binaryReader.ReadBlamPointer( 1 );
            var data = new byte[ blamPointer.Count ];
            if ( blamPointer.Count > 0 )
            {
                using ( binaryReader.BaseStream.Pin() )
                {
                    binaryReader.BaseStream.Position = blamPointer[ 0 ];
                    data = binaryReader.ReadBytes( blamPointer.Count );
                }
            }
            return data;
        }
    };
}
