using Moonfish.Tags;
using Moonfish.Tags.BlamExtension;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ErrorReportVectorsBlock : ErrorReportVectorsBlockBase
    {
        public ErrorReportVectorsBlock( BinaryReader binaryReader )
            : base( binaryReader )
        {

        }
    };
    [LayoutAttribute( Size = 64 )]
    public class ErrorReportVectorsBlockBase
    {
        internal OpenTK.Vector3 position;
        internal NodeIndices[] nodeIndices;
        internal NodeWeights[] nodeWeights;
        internal OpenTK.Vector4 color;
        internal OpenTK.Vector3 normal;
        internal float screenLength;
        internal ErrorReportVectorsBlockBase( BinaryReader binaryReader )
        {
            this.position = binaryReader.ReadVector3();
            this.nodeIndices = new[] { new NodeIndices( binaryReader ), new NodeIndices( binaryReader ), new NodeIndices( binaryReader ), new NodeIndices( binaryReader ), };
            this.nodeWeights = new[] { new NodeWeights( binaryReader ), new NodeWeights( binaryReader ), new NodeWeights( binaryReader ), new NodeWeights( binaryReader ), };
            this.color = binaryReader.ReadVector4();
            this.normal = binaryReader.ReadVector3();
            this.screenLength = binaryReader.ReadSingle();
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
        public class NodeIndices
        {
            internal byte nodeIndex;
            internal NodeIndices( BinaryReader binaryReader )
            {
                this.nodeIndex = binaryReader.ReadByte();
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
        public class NodeWeights
        {
            internal float nodeWeight;
            internal NodeWeights( BinaryReader binaryReader )
            {
                this.nodeWeight = binaryReader.ReadSingle();
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
    };
}
