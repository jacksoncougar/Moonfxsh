using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using Fasterflect;
using Moonfish.Tags;

namespace Moonfish
{
    /// <summary>
    ///     A minimalist class to load essential data which can be used to parse a retail cache map.
    /// </summary>
    public class CacheStream : FileStream, IMap, IEnumerable<Tag>
    {
        public enum StructureCache
        {
            VirtualStructureCache0,
            VirtualStructureCache1,
            VirtualStructureCache2,
            VirtualStructureCache3,
            VirtualStructureCache4,
            VirtualStructureCache5,
            VirtualStructureCache6,
            VirtualStructureCache7
        }

        public readonly Version BuildVersion;
        public readonly VirtualMappedAddress DefaultMemoryBlock;
        private readonly Dictionary<TagIdent, dynamic> deserializedTags;
        private readonly Dictionary<TagIdent, string> hashTags;
        public readonly int IndexVirtualAddress;

        /// <summary>
        ///     name of this cache (is not used in anything, just compiled into the header)
        /// </summary>
        public readonly string MapName;

        /// <summary>
        ///     magic values are used to convert from pre-calculated memory pointers to file-addresses
        /// </summary>
        public readonly int PrimaryMagic;

        /// <summary>
        ///     path of the scenario (local directory path storing the resources of this map when decompiled)
        /// </summary>
        public readonly string Scenario;

        /// <summary>
        ///     magic values are used to convert from pre-calculated memory pointers to file-addresses
        /// </summary>
        public readonly int SecondaryMagic;

        public readonly string[] Strings;
        public readonly Dictionary<TagIdent, int> StructureMemoryBlockBindings;
        public readonly List<VirtualMappedAddress> StructureMemoryBlocks;
        public readonly int TagCacheLength;
        public readonly Tag[] Tags;
        public readonly MapType Type;
        public readonly UnicodeValueNamePair[] Unicode;
        private Tag _currentTag = new Tag( );

        public CacheStream( string filename )
            : base( filename, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite, 1024 )
        {
            //HEADER
            var binaryReader = new BinaryReader( this, Encoding.UTF8 );

            base.Seek( 0, SeekOrigin.Begin );
            if ( binaryReader.ReadTagClass( ) != ( TagClass ) "head" )
                throw new InvalidDataException( "Not a halo-map file" );

            base.Seek( 42, SeekOrigin.Begin );
            BuildVersion = ( Version ) binaryReader.ReadInt32( );

            base.Seek( 16, SeekOrigin.Begin );
            var indexAddress = binaryReader.ReadInt32( );
            var indexLength = binaryReader.ReadInt32( );
            TagCacheLength = binaryReader.ReadInt32( );


            if ( BuildVersion == Version.PC_RETAIL )
                base.Seek( 12, SeekOrigin.Current );

            // Read maptype
            using ( this.Pin( ) )
            {
                base.Seek( 320, SeekOrigin.Begin );
                Type = ( MapType ) binaryReader.ReadInt32( );
            }

            base.Seek( 332, SeekOrigin.Current );

            var stringTableLength = binaryReader.ReadInt32( );
            base.Seek( 4, SeekOrigin.Current );
            var stringTableAddress = binaryReader.ReadInt32( );

            base.Seek( 36, SeekOrigin.Current );

            MapName = binaryReader.ReadFixedString( 32 );

            base.Seek( 4, SeekOrigin.Current );

            Scenario = binaryReader.ReadFixedString( 256 );

            base.Seek( 4, SeekOrigin.Current );
            var pathsCount = binaryReader.ReadInt32( );
            var pathsTableAddress = binaryReader.ReadInt32( );
            var pathsTableLength = binaryReader.ReadInt32( );


            base.Seek( pathsTableAddress, SeekOrigin.Begin );
            var paths = Encoding.UTF8.GetString( binaryReader.ReadBytes( pathsTableLength - 1 ) ).Split( char.MinValue );

            Halo2.Paths.Assign( paths );

            //STRINGS

            Seek( stringTableAddress, SeekOrigin.Begin );
            Strings = Encoding.UTF8.GetString( binaryReader.ReadBytes( stringTableLength - 1 ) ).Split( char.MinValue );

            Halo2.Strings.Assign( new List<string>( Strings ) );


            //  INDEX
            /*
             *  Vista doesn't use memory addresses for the following address-values. (they are instead 0-based from the index-address)
             *  
             *  0x00    Address to Classes array
             *  0x04    Classes array length
             *  0x08    Address to Tags array
             *  0x0C    Scenario        tag_id
             *  0x10    Match-Globals   tag_id
             *  0x14    ~
             *  0x18    Tags array length
             *  0xC0    'sgat'          four_cc
             * 
             *  */
            base.Seek( indexAddress, SeekOrigin.Begin );
            var tagClassTableVirtualAddress = binaryReader.ReadInt32( );
            IndexVirtualAddress = tagClassTableVirtualAddress - 32;

            base.Seek( 4, SeekOrigin.Current );

            var tagDatumTableVirtualAddress = binaryReader.ReadInt32( );
            var ScenarioID = binaryReader.ReadTagIdent( );
            var GlobalsID = binaryReader.ReadTagIdent( );
            var tagDatumTableOffset = tagDatumTableVirtualAddress - tagClassTableVirtualAddress;

            base.Seek( 4, SeekOrigin.Current );

            var tagDatumCount = binaryReader.ReadInt32( );

            base.Seek( 4 + tagDatumTableOffset, SeekOrigin.Current );
            Tags = new Tag[tagDatumCount];
            for ( var i = 0; i < tagDatumCount; i++ )
            {
                Tags[ i ] = new Tag
                {
                    Class = binaryReader.ReadTagClass( ),
                    Identifier = binaryReader.ReadInt32( ),
                    VirtualAddress = binaryReader.ReadInt32( ),
                    Length = binaryReader.ReadInt32( )
                };

                //Borky vista fix - broken paths are broken
                //if (Tags[i].VirtualAddress == 0) continue;
                // var tag = Tags[i];
                Tags[ i ].Path = paths[ Tags[ i ].Identifier.Index ];
            }

            // Calculate File-pointer magic
            SecondaryMagic = Tags[ 0 ].VirtualAddress - ( indexAddress + indexLength );

            DefaultMemoryBlock = new VirtualMappedAddress
            {
                Address = Tags[ 0 ].VirtualAddress,
                Length = TagCacheLength,
                Magic = SecondaryMagic
            };

            /* Intent: read the sbsp and lightmap address and lengths from the scenario tag 
             * and store them in the Tags array.
             */
            if ( BuildVersion == Version.XBOX_RETAIL )
            {
                base.Seek( Tags[ ScenarioID.Index ].VirtualAddress - SecondaryMagic + 528, SeekOrigin.Begin );
                var count = binaryReader.ReadInt32( );
                var address = binaryReader.ReadInt32( );

                StructureMemoryBlockBindings = new Dictionary<TagIdent, int>( count * 2 );
                StructureMemoryBlocks = new List<VirtualMappedAddress>( count );
                for ( var i = 0; i < count; ++i )
                {
                    base.Seek( address - SecondaryMagic + i * 68, SeekOrigin.Begin );
                    var structureBlockOffset = binaryReader.ReadInt32( );
                    var structureBlockLength = binaryReader.ReadInt32( );
                    var structureBlockAddress = binaryReader.ReadInt32( );
                    base.Seek( 8, SeekOrigin.Current );
                    var sbspIdentifier = binaryReader.ReadTagIdent( );
                    base.Seek( 4, SeekOrigin.Current );
                    var ltmpIdentifier = binaryReader.ReadTagIdent( );

                    base.Seek( structureBlockOffset, SeekOrigin.Begin );


                    var blockLength = binaryReader.ReadInt32( );
                    var sbspVirtualAddress = binaryReader.ReadInt32( );
                    var ltmpVirtualAddress = binaryReader.ReadInt32( );
                    var sbsp = binaryReader.ReadTagClass( );

                    var hasLightmapData = !TagIdent.IsNull( ltmpIdentifier );

                    var sbspLength = hasLightmapData ? ltmpVirtualAddress - sbspVirtualAddress : blockLength;

                    var ltmpLength = blockLength - sbspLength;

                    var block = new VirtualMappedAddress
                    {
                        Address = structureBlockAddress,
                        Length = structureBlockLength,
                        Magic = structureBlockAddress - structureBlockOffset
                    };


                    Tags[ sbspIdentifier.Index ].VirtualAddress = sbspVirtualAddress;
                    Tags[ sbspIdentifier.Index ].Length = sbspLength;

                    StructureMemoryBlocks.Add( block );
                    var index = StructureMemoryBlocks.Count - 1;
                    StructureMemoryBlockBindings[ sbspIdentifier ] = index;

                    if ( hasLightmapData )
                    {
                        Tags[ ltmpIdentifier.Index ].VirtualAddress = ltmpVirtualAddress;
                        Tags[ ltmpIdentifier.Index ].Length = ltmpLength;
                        StructureMemoryBlockBindings[ ltmpIdentifier ] = index;
                    }
                }
                ActiveAllocation( StructureCache.VirtualStructureCache0 );

                ////UNICODE
                //this.Seek(Tags[GlobalsID.Index].VirtualAddress - SecondaryMagic + 400, SeekOrigin.Begin);
                //int unicodeCount = bin.ReadInt32();
                //int unicodeTableLength = bin.ReadInt32();
                //int unicodeIndexAddress = bin.ReadInt32();
                //int unicodeTableAddress = bin.ReadInt32();

                //Unicode = new UnicodeValueNamePair[unicodeCount];

                //StringID[] strRefs = new StringID[unicodeCount];
                //int[] strOffsets = new int[unicodeCount];

                //this.Seek(unicodeIndexAddress, SeekOrigin.Begin);
                //for (int i = 0; i < unicodeCount; i++)
                //{
                //    strRefs[i] = (StringID)bin.ReadInt32();
                //    strOffsets[i] = bin.ReadInt32();
                //}
                //for (int i = 0; i < unicodeCount; i++)
                //{
                //    this.Seek(unicodeTableAddress + strOffsets[i], SeekOrigin.Begin);
                //    StringBuilder unicodeString = new StringBuilder(byte.MaxValue);
                //    while (bin.PeekChar() != char.MinValue)
                //        unicodeString.Append(bin.ReadChar());
                //    Unicode[i] = new UnicodeValueNamePair { Name = strRefs[i], Value = unicodeString.ToString() };
                //}
            }

            deserializedTags = new Dictionary<TagIdent, dynamic>( Tags.Length );
            hashTags = new Dictionary<TagIdent, string>( Tags.Length );
            Halo2.ActiveMap( this );
        }

        [Obsolete]
        public IMap this[ TagReference tagReference ]
        {
            get { return this[ tagReference.Ident ]; }
        }

        [Obsolete]
        public IMap this[ string @class, string path ]
        {
            get
            {
                if ( _currentTag.Class == ( TagClass ) @class && _currentTag.Path.Contains( path ) )
                    return this;
                _currentTag = ( from tag in Tags
                    where tag.Class == ( TagClass ) @class
                    where tag.Path.Contains( path )
                    select tag ).First( );
                return this;
            }
        }

        [Obsolete]
        public IMap this[ TagClass @class, string path ]
        {
            get { return this[ @class.ToString( ), path ]; }
        }

        [Obsolete]
        public IMap this[ TagIdent ident ]
        {
            get
            {
                if ( _currentTag.Identifier == ident ) return this;
                _currentTag = TagIdent.IsNull( ident ) ? null : Tags[ ident.Index ];
                return this;
            }
        }

        public override long Position
        {
            get
            {
                var value = ( int ) base.Position;
                if ( TryConvertOffsetToPointer( ref value ) ) return value;
                return base.Position;
            }
            set { base.Position = CheckOffset( value ); }
        }

        private VirtualMappedAddress ActiveStructureMemoryAllocation { get; set; }

        IEnumerator<Tag> IEnumerable<Tag>.GetEnumerator( )
        {
            return ( ( IEnumerable<Tag> ) Tags ).GetEnumerator( );
        }

        IEnumerator IEnumerable.GetEnumerator( )
        {
            return ( ( IEnumerable<Tag> ) Tags ).GetEnumerator( );
        }

        [Obsolete]
        dynamic IMap.Deserialize( )
        {
            return Deserialize( _currentTag );
        }

        Tag IMap.Meta
        {
            get { return _currentTag; }
            set { }
        }

        byte[] IMap.TagData
        {
            get
            {
                Position = _currentTag.VirtualAddress;
                var buffer = new byte[_currentTag.Length];
                Read( buffer, 0, buffer.Length );
                return buffer;
            }
        }

        public void ActiveAllocation( StructureCache activeAllocation )
        {
            var index = ( int ) activeAllocation;
            ActiveStructureMemoryAllocation = StructureMemoryBlocks[ index ];
        }

        public int CalculateChecksum( )
        {
            const int blockSize = 512;
            var buffer = new byte[blockSize];

            var word_count = ( ( int ) Length - 2048 ) / sizeof ( uint );
            var pass_count = word_count / ( blockSize / 4 );
            var remainder = word_count % pass_count;

            Position = 2048;
            var checksum = 0;
            for ( var pass = 0; pass < pass_count; pass++ )
            {
                Read( buffer, 0, blockSize );
                for ( var index = 0; index < blockSize / sizeof ( uint ); index += 4 )
                {
                    checksum ^= BitConverter.ToInt32( buffer, ( index + 0 ) * sizeof ( uint ) );
                    checksum ^= BitConverter.ToInt32( buffer, ( index + 1 ) * sizeof ( uint ) );
                    checksum ^= BitConverter.ToInt32( buffer, ( index + 2 ) * sizeof ( uint ) );
                    checksum ^= BitConverter.ToInt32( buffer, ( index + 3 ) * sizeof ( uint ) );
                }
            }
            Read( buffer, 0, remainder );
            for ( var index = 0; index < remainder / sizeof ( uint ); index += 4 )
            {
                checksum ^= BitConverter.ToInt32( buffer, ( index + 0 ) * sizeof ( uint ) );
                checksum ^= BitConverter.ToInt32( buffer, ( index + 1 ) * sizeof ( uint ) );
                checksum ^= BitConverter.ToInt32( buffer, ( index + 2 ) * sizeof ( uint ) );
                checksum ^= BitConverter.ToInt32( buffer, ( index + 3 ) * sizeof ( uint ) );
            }
            return checksum;
        }

        public string CalculateTaghash( TagIdent ident )
        {
            using ( var sha1 = new SHA1CryptoServiceProvider( ) )
            {
                var hash = Convert.ToBase64String( sha1.ComputeHash( this[ ident ].TagData ) );
                //Console.WriteLine(hash);
                return hash;
            }
        }

        public bool ContainsPointer( BlamPointer blamPointer )
        {
            return DefaultMemoryBlock.Contains( blamPointer ) || ActiveStructureMemoryAllocation.Contains( blamPointer );
        }

        public int ConvertOffsetToPointer( int value )
        {
            //foreach ( var block in MemoryBlocks )
            //{
            //    if ( block.GetOffset( ref value, false, true ) ) return value;
            //}
            return value;
        }

        public dynamic Deserialize( Tag tag )
        {
            dynamic deserializedTag;
            if ( deserializedTags.TryGetValue( tag.Identifier, out deserializedTag ) )
                return deserializedTag;

            Seek( tag );

            var typeQuery = (
                from types in Assembly.GetExecutingAssembly( ).GetTypes( )
                where types.HasAttribute( typeof ( TagClassAttribute ) )
                where types.Attribute<TagClassAttribute>( ).TagClass == tag.Class
                select types
                ).FirstOrDefault( );

            if ( typeQuery == null ) return null;

            deserializedTags[ tag.Identifier ] = this.Deserialize( typeQuery );
            hashTags[ tag.Identifier ] = CalculateTaghash( tag.Identifier );

            return deserializedTags[ tag.Identifier ];
        }

        public long GetFilePosition( )
        {
            return base.Position;
        }

        public Tag GetTag( TagIdent ident )
        {
            return Tags[ ident.Index ];
        }

        public string GetTagHash( TagIdent ident )
        {
            return hashTags.ContainsKey( ident ) ? hashTags[ ident ] : null;
        }

        public void Remove( TagIdent ident )
        {
            deserializedTags.Remove( ident );
        }

        public long Seek( Tag tag )
        {
            return Seek( tag.VirtualAddress, SeekOrigin.Begin );
        }

        public long Seek( TagIdent tagident )
        {
            return Seek( Tags[ tagident.Index ] );
        }

        public override long Seek( long offset, SeekOrigin origin )
        {
            offset = CheckOffset( offset );
            base.Seek( offset, origin );
            return Position;
        }

        public IEnumerable<Tag> Select( TagClass tagClass, string path )
        {
            return ( from tag in Tags
                where tag.Class == tagClass
                where tag.Path.Contains( path )
                select tag );
        }

        public bool Sign( )
        {
            if ( !CanWrite ) return false;
            var checksum = CalculateChecksum( );

            var writer = new BinaryWriter( this );
            writer.BaseStream.Position = 0x000002F0;
            writer.Write( checksum );
            return true;
        }

        public bool TryConvertOffsetToPointer( ref int value )
        {
            if ( DefaultMemoryBlock.ContainsFileOffset( value ) )
            {
                value = DefaultMemoryBlock.GetOffset( value, false, true );
                return true;
            }
            if ( ActiveStructureMemoryAllocation.ContainsFileOffset( value ) )
            {
                value = ActiveStructureMemoryAllocation.GetOffset( value, false, true );
                return true;
            }
            return false;
        }

        private long CheckOffset( long value )
        {
            // if 'value' is a Pointer
            if ( value < 0 || value > Length )
            {
                return VirtualAddressToFileOffset( ( int ) value );
            }
            return value;
        }

        private int VirtualAddressToFileOffset( int value )
        {
            if ( DefaultMemoryBlock.ContainsVirtualOffset( value ) )
            {
                return DefaultMemoryBlock.GetOffset( value );
            }
            if ( ActiveStructureMemoryAllocation.ContainsVirtualOffset( value ) )
            {
                return ActiveStructureMemoryAllocation.GetOffset( value );
            }
            throw new InvalidOperationException( );
        }
    }
}