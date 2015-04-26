using System.IO;
using Moonfish.Tags;

namespace Moonfish.Cache
{
    public class TagIndexBase
    {
        protected const int HeaderSize = 32;

        protected int classArrayAddress;
        protected int classArrayCount;
        protected int datumArrayAddress;
        public TagIdent ScenarioIdent { get; private set; }
        public TagIdent GlobalsIdent { get; private set; }
        private int _noodleValue;
        protected int datumArrayCount;
        private readonly TagClass fourCC;

        protected TagIndexBase( CacheStream cache )
        {
            var binaryReader = new BinaryReader(cache);
            classArrayAddress = binaryReader.ReadInt32( );
            classArrayCount = binaryReader.ReadInt32( );
            datumArrayAddress = binaryReader.ReadInt32( );
            ScenarioIdent = binaryReader.ReadTagIdent( );
            GlobalsIdent = binaryReader.ReadTagIdent( );
            _noodleValue = binaryReader.ReadInt32( );
            datumArrayCount = binaryReader.ReadInt32( );
            fourCC = binaryReader.ReadTagClass();
            if (fourCC != new TagClass("tags")) throw new InvalidDataException();
        }

        protected byte[] SerializeHeader( )
        {
            MemoryStream stream = new MemoryStream( HeaderSize );
            BinaryWriter binaryWriter = new BinaryWriter( stream );
            binaryWriter.Write( classArrayAddress );
            binaryWriter.Write( classArrayCount );
            binaryWriter.Write( datumArrayAddress );
            binaryWriter.Write( ScenarioIdent );
            binaryWriter.Write( GlobalsIdent );
            binaryWriter.Write( _noodleValue );
            binaryWriter.Write( datumArrayCount );
            binaryWriter.Write( fourCC );
            return stream.GetBuffer( );
        }
    }
}