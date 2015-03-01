using Moonfish.Tags;
using Moonfish.Tags.BlamExtension;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ShaderTemplateRuntimeExternalLightResponseIndexBlock : ShaderTemplateRuntimeExternalLightResponseIndexBlockBase
    {
        public ShaderTemplateRuntimeExternalLightResponseIndexBlock( BinaryReader binaryReader )
            : base( binaryReader )
        {

        }
    };
    [LayoutAttribute( Size = 4 )]
    public class ShaderTemplateRuntimeExternalLightResponseIndexBlockBase
    {
        internal int eMPTYSTRING;
        internal ShaderTemplateRuntimeExternalLightResponseIndexBlockBase( BinaryReader binaryReader )
        {
            this.eMPTYSTRING = binaryReader.ReadInt32();
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
