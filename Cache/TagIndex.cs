using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Moonfish.Tags;

namespace Moonfish.Cache
{
    public class TagIndex : TagIndexBase, IReadOnlyList<TagDatum>
    {
        private readonly List<TagClassHeirarchy> _classes;
        private readonly List<TagDatum> _data;

        public TagIndex( CacheStream cache, IReadOnlyList<string> paths )
            : base( cache )
        {
            var binaryReader = new BinaryReader( cache );
            _classes = new List<TagClassHeirarchy>( new TagClassHeirarchy[classArrayCount] );
            for ( var i = 0; i < classArrayCount; i++ )
            {
                _classes[ i ] = new TagClassHeirarchy( binaryReader.ReadTagClass( ), binaryReader.ReadTagClass( ),
                    binaryReader.ReadTagClass( ) );
            }

            _data = new List<TagDatum>( new TagDatum[datumArrayCount] );
            for ( var i = 0; i < datumArrayCount; i++ )
            {
                _data[ i ] = new TagDatum
                {
                    Class = binaryReader.ReadTagClass( ),
                    Identifier = ( TagIdent ) binaryReader.ReadInt32( ),
                    VirtualAddress = binaryReader.ReadInt32( ),
                    Length = binaryReader.ReadInt32( ),
                    Path = paths[ i ]
                };
            }
        }

        public TagDatum this[ TagIdent ident ]
        {
            get { return this[ ident.Index ]; }
        }

        public TagDatum this[ int index ]
        {
            get { return _data[ index ]; }
        }

        public void Update( TagIdent ident, TagDatum item )
        {
            _data[ ident.Index ] = item;
        }

        public int IndexOf( TagDatum item )
        {
            return _data[ item.Identifier.Index ] == item ? item.Identifier.Index : _data.IndexOf( item );
        }
        public int Count
        {
            get { return _data.Count; }
        }

        public IEnumerator<TagDatum> GetEnumerator( )
        {
            return _data.GetEnumerator( );
        }

        IEnumerator IEnumerable.GetEnumerator( )
        {
            return _data.GetEnumerator( );
        }

        public IEnumerable<TagDatum> Select( TagClass tagClass, string path )
        {
            return from item in _data
                where item.Class == tagClass
                where item.Path == path
                select item;
        }

        protected unsafe byte[] Serialize( int address )
        {
            // Calculate size of arrays
            var sizeOfTagClassHeirarchyArray = _classes.Count * sizeof(TagClassHeirarchy);
            const int sizeOfTagDatum = 16;
            var sizeOfTagDatumArray = _data.Count * sizeOfTagDatum;
            
            // Create buffer and writer
            var stream =
                new VirtualStream(new byte[HeaderSize + sizeOfTagClassHeirarchyArray + sizeOfTagDatumArray], address);
            var binaryWriter = new BinaryWriter(stream);
            
            // move past the header
            stream.Seek(HeaderSize, SeekOrigin.Begin);

            // write tag-class array
            classArrayAddress = (int)stream.Position;
            classArrayCount = _classes.Count;
            foreach ( var tagClassHeirarchy in _classes )
            {
                WriteTagHeirarchy( binaryWriter, tagClassHeirarchy );
            }

            // write tag-data array
            datumArrayAddress = (int)stream.Position;
            datumArrayCount = _data.Count;
            foreach ( var tagDatum in _data )
            {
                WriteTagDatum( binaryWriter, tagDatum );
            }

            // 
            binaryWriter.WritePadding(512);

            // Serialise header and update address
            var headerBytes = SerializeHeader(); 

            stream.Seek(0, SeekOrigin.Begin);
            binaryWriter.Write(headerBytes);

            return stream.GetBuffer( );
        }

        protected byte[] SerializePaths( )
        {
            var length = _data.Sum( x => Encoding.UTF8.GetByteCount( x.Path ) + 1 );
            var stream = new MemoryStream( new byte[length] );
            var binaryWriter = new BinaryWriter( stream );
            _data.ForEach( x =>
            {
                binaryWriter.Write( Encoding.UTF8.GetBytes( x.Path ) );
                binaryWriter.Write( ( byte ) 0 );
            }
                );
            return stream.GetBuffer( );
        }

        private static void WriteTagDatum( BinaryWriter binaryWriter, TagDatum tagDatum )
        {
            binaryWriter.Write( tagDatum.Class );
            binaryWriter.Write( tagDatum.Identifier );
            binaryWriter.Write( tagDatum.VirtualAddress );
            binaryWriter.Write( tagDatum.Length );
        }

        private static void WriteTagHeirarchy( BinaryWriter binaryWriter, TagClassHeirarchy tagClassHeirarchy )
        {
            binaryWriter.Write( tagClassHeirarchy.Class );
            binaryWriter.Write( tagClassHeirarchy.Parent );
            binaryWriter.Write( tagClassHeirarchy.Root );
        }

        public TagDatum Add(TagClass tagClass, string newPath, int length, int virtualAddress)
        {
            var last = _data.Last( );
            var newDatum = new TagDatum
            {
                Class = tagClass,
                Identifier = last.Identifier,
                Length = length,
                Path = newPath,
                VirtualAddress = virtualAddress
            };
            _data.Insert(IndexOf(last), newDatum);
            last.Identifier++;
            Update( last.Identifier, last );
            return newDatum;
        }
    }
}