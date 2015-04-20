using Fasterflect;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using Moonfish.Guerilla;
using Moonfish.Tags;

namespace Moonfish
{
    public enum MapType
    {
        Multiplayer = 1,
        MainMenu = 2,
        Shared = 3,
        SinglePlayerShared = 4,
    }

    /// <summary>
    /// A minimalist class to load essential data which can be used to parse a retail cache map.
    /// </summary>
    public class MapStream : FileStream, IMap, IEnumerable<Tag>
    {
        public readonly Version BuildVersion;

        /// <summary>
        /// name of this cache (is not used in anything, just compiled into the header)
        /// </summary>
        public readonly string MapName;

        /// <summary>
        /// path of the scenario (local directory path storing the resources of this map when decompiled)
        /// </summary>
        public readonly string Scenario;

        /// <summary>
        /// magic values are used to convert from pre-calculated memory pointers to file-addresses
        /// </summary>
        public readonly int PrimaryMagic;

        /// <summary>
        /// magic values are used to convert from pre-calculated memory pointers to file-addresses
        /// </summary>
        public readonly int SecondaryMagic;

        public readonly MapType Type;

        public readonly UnicodeValueNamePair[] Unicode;
        public readonly string[] Strings;
        public readonly Tag[] Tags;

        public readonly int IndexVirtualAddress;
        public readonly int TagCacheLength;

        public readonly VirtualMappedAddress DefaultMemoryBlock;

        public readonly Dictionary<TagIdent, int> StructureMemoryBlockBindings;
        public readonly List<VirtualMappedAddress> StructureMemoryBlocks;

        private VirtualMappedAddress ActiveStructureMemoryAllocation { get; set; }

        public void ActiveAllocation( StructureCache activeAllocation )
        {
            var index = ( int ) activeAllocation;
            ActiveStructureMemoryAllocation = StructureMemoryBlocks[ index ];
        }

        private Dictionary<TagIdent, dynamic> deserializedTags;
        private Dictionary<TagIdent, string> hashTags;

        public MapStream( string filename )
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
                Tags[ i ] = new Tag( )
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
                Magic = SecondaryMagic,
            };

            /* Intent: read the sbsp and lightmap address and lengths from the scenario tag 
             * and store them in the Tags array.
             */
            if ( BuildVersion == Version.XBOX_RETAIL )
            {
                base.Seek( Tags[ ScenarioID.Index ].VirtualAddress - SecondaryMagic + 528, SeekOrigin.Begin );
                var count = binaryReader.ReadInt32( );
                var address = binaryReader.ReadInt32( );

                Debug = new StructureReference[count];
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


        public readonly StructureReference[] Debug;

        public struct StructureReference
        {
            public int SBSPOffset;
            public int SBSPVirtualOffset;
            public int LTMPOffset;
            public int LTMPVirtualOffset;
            public int LTMPLength;
            public int SBSPLength { get; set; }
        }

        private Tag _currentTag = new Tag( );

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
                else
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
                else _currentTag = TagIdent.IsNull( ident ) ? null : Tags[ ident.Index ];
                return this;
            }
        }

        [Obsolete]
        dynamic IMap.Deserialize( )
        {
            return Deserialize( _currentTag );
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

        public long Seek( Tag tag )
        {
            return Seek( tag.VirtualAddress, SeekOrigin.Begin );
        }

        public long Seek( TagIdent tagident )
        {
            return Seek( Tags[ tagident.Index ] );
        }

        public Tag GetTag( TagIdent ident )
        {
            return Tags[ ident.Index ];
        }

        public IEnumerable<Tag> Select( TagClass tagClass, string path )
        {
            return ( from tag in Tags
                where tag.Class == tagClass
                where tag.Path.Contains( path )
                select tag );
        }

        public void Remove( TagIdent ident )
        {
            deserializedTags.Remove( ident );
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

        public string GetTagHash( TagIdent ident )
        {
            return hashTags.ContainsKey( ident ) ? hashTags[ ident ] : null;
        }

        Tag IMap.Meta
        {
            get { return _currentTag; }
            set { }
        }

        public long GetFilePosition( )
        {
            return base.Position;
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

        public enum StructureCache
        {
            VirtualStructureCache0,
            VirtualStructureCache1,
            VirtualStructureCache2,
            VirtualStructureCache3,
            VirtualStructureCache4,
            VirtualStructureCache5,
            VirtualStructureCache6,
            VirtualStructureCache7,
        }

        public override long Seek( long offset, SeekOrigin origin )
        {
            offset = CheckOffset( offset );
            base.Seek( offset, origin );
            return Position;
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

        public bool Sign( )
        {
            if ( !CanWrite ) return false;
            var checksum = CalculateChecksum( );

            var writer = new BinaryWriter( this );
            writer.BaseStream.Position = 0x000002F0;
            writer.Write( checksum );
            return true;
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

        IEnumerator<Tag> IEnumerable<Tag>.GetEnumerator( )
        {
            return ( ( IEnumerable<Tag> ) Tags ).GetEnumerator( );
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator( )
        {
            return ( ( IEnumerable<Tag> ) Tags ).GetEnumerator( );
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
    }

    public enum Version
    {
        XBOX_RETAIL,
        PC_RETAIL,
    }

    /* * *
     * Unicode Handling
     * ----------------
     * Store an index pointing to a table which maps to a UTF8 string for each language.
     * For each Unicode there will be a memory usage of 4 + ( language_count * 4 ) used for indexers
     * 
     * [StringID] -> [index] : 0 -> [Language Switch Mappings] -> [English] -> UTF8 String
     * 
     * Using a dictionary to map the string_id value to an index in the language map
     * using a custom struct to hold to language mappings
     * using a list to hold the UTF8 strings
     * 
     * * */

    internal struct UnicodeItem
    {
        private int[] _indices;

        private int[] Indices
        {
            get { return _indices; }
        }
    }

    public struct UnicodeValueNamePair
    {
        //depre.//
        public StringID Name;
        public string Value;

        public override string ToString( )
        {
            return string.Format( "{0}:{1} : \"{2}\"", Name.Index, Name.Length, Value );
        }
    }

    public struct VirtualMappedAddress
    {
        public int Address;
        public int Length;
        public int Magic;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="address">Address Value</param>
        /// <param name="isVirtualAddress">If true Address Value is a virtual address else Address Value is file address</param>
        /// <returns>true if address points to this map</returns>
        public bool ContainsFileOffset( long address )
        {
            return Contains( address, false );
        }

        [Pure]
        public bool ContainsVirtualOffset( long address )
        {
            return Contains( address );
        }

        public bool Contains( BlamPointer pointer )
        {
            var failed = false;
            foreach ( var address in pointer )
            {
                failed |= !Contains( address );
                if ( failed ) break;
            }

            failed |= !Contains( pointer.EndAddress - 1 );

            return !failed;
        }

        [Pure]
        private bool Contains( long address, bool isVirtualAddress = true )
        {
            var virtualOffset = isVirtualAddress ? 0 : Magic;
            var fileAddress = ( int ) address + virtualOffset;
            var beginAddress = Address;
            var endAddress = beginAddress + Length;
            return fileAddress >= beginAddress && fileAddress < endAddress;
        }

        [Pure]
        public int GetOffset( int address, bool addressIsVirtualAddress = true, bool returnVirtualAddress = false )
        {
            if ( addressIsVirtualAddress )
            {
                address = returnVirtualAddress ? address : address - Magic;
            }
            else
            {
                address = returnVirtualAddress ? address + Magic : address;
            }
            return address;
        }
    }

    public interface IMap
    {
        /// <summary>
        /// Returns a TagBlock from the current class
        /// </summary>
        /// <returns></returns>
        dynamic Deserialize( );

        /// <summary>
        /// Access meta information about the tag
        /// </summary>
        Tag Meta { get; set; }

        byte[] TagData { get; }
    }

    public class Tag
    {
        public TagClass Class;
        public string Path { get; set; }
        public TagIdent Identifier;
        public int VirtualAddress;
        public int Length;

        internal bool Contains( int address )
        {
            return ( address >= VirtualAddress && address < VirtualAddress + Length );
        }
    }
}