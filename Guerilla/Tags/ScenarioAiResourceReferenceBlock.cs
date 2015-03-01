using Moonfish.Tags;
using Moonfish.Tags.BlamExtension;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioAiResourceReferenceBlock : ScenarioAiResourceReferenceBlockBase
    {
        public ScenarioAiResourceReferenceBlock( BinaryReader binaryReader )
            : base( binaryReader )
        {

        }
    };
    [LayoutAttribute( Size = 8 )]
    public class ScenarioAiResourceReferenceBlockBase
    {
        [TagReference( "ai**" )]
        internal Moonfish.Tags.TagReference reference;
        internal ScenarioAiResourceReferenceBlockBase( BinaryReader binaryReader )
        {
            this.reference = binaryReader.ReadTagReference();
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
