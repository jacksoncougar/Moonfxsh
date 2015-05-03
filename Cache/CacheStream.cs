using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using Fasterflect;
using Moonfish.Cache;
using Moonfish.Guerilla;
using Moonfish.Tags;
using Moonfish.Tags.BlamExtension;
using OpenTK.Graphics.OpenGL;

namespace Moonfish
{
    /// <summary>
    ///     A minimalist class to load essential data which can be used to parse a retail cache map.
    /// </summary>
    public class CacheStream : FileStream
    {
        private readonly Dictionary<TagIdent, dynamic> _deserializedTagCache;
        private readonly Dictionary<TagIdent, string> _tagHashDictionary;
        private readonly HaloVersion BuildVersion;

        public readonly VirtualMappedAddress DefaultMemoryBlock;

        /// <summary>
        ///     name of this cache (is not used in anything, just compiled into the header)
        /// </summary>
        public readonly string MapName;

        /// <summary>
        ///     path of the scenario (local directory path storing the resources of this map when decompiled)
        /// </summary>
        public readonly string Scenario;

        public readonly string[] Strings;
        public readonly Dictionary<TagIdent, int> StructureMemoryBlockBindings;
        public readonly List<VirtualMappedAddress> StructureMemoryBlocks;
        public readonly MapType Type;
        private readonly int tagCacheLength;

        public CacheStream( string filename )
            : base( filename, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite, 1024 )
        {
            //HEADER
            var binaryReader = new BinaryReader( this, Encoding.UTF8 );

            base.Seek( 0, SeekOrigin.Begin );
            if ( binaryReader.ReadTagClass( ) != ( TagClass ) "head" )
                throw new InvalidDataException( "Not a halo-map file" );

            base.Seek( 42, SeekOrigin.Begin );
            BuildVersion = ( HaloVersion ) binaryReader.ReadInt32( );

            base.Seek( 16, SeekOrigin.Begin );
            var indexAddress = binaryReader.ReadInt32( );
            var indexLength = binaryReader.ReadInt32( );
            tagCacheLength = binaryReader.ReadInt32( );


            if ( BuildVersion == HaloVersion.PC_RETAIL )
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
            base.Seek( indexAddress, SeekOrigin.Begin );

            Index = new TagIndex( this, paths );

            // Calculate File-pointer magic
            var secondaryMagic = Index[ Index.GlobalsIdent ].VirtualAddress - ( indexAddress + indexLength );

            DefaultMemoryBlock = new VirtualMappedAddress
            {
                Address = Index[ 0 ].VirtualAddress,
                Length = tagCacheLength,
                Magic = secondaryMagic
            };

            /* Intent: read the sbsp and lightmap address and lengths from the scenario tag 
             * and store them in the Tags array.
             */
            if ( BuildVersion == HaloVersion.XBOX_RETAIL )
            {
                base.Seek( Index[ Index.ScenarioIdent ].VirtualAddress - secondaryMagic + 528, SeekOrigin.Begin );
                var count = binaryReader.ReadInt32( );
                var address = binaryReader.ReadInt32( );

                StructureMemoryBlockBindings = new Dictionary<TagIdent, int>( count * 2 );
                StructureMemoryBlocks = new List<VirtualMappedAddress>( count );
                for ( var i = 0; i < count; ++i )
                {
                    base.Seek( address - secondaryMagic + i * 68, SeekOrigin.Begin );
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

                    var sbspDatum = Index[ sbspIdentifier ];
                    sbspDatum.VirtualAddress = sbspVirtualAddress;
                    sbspDatum.Length = sbspLength;
                    Index.Update( sbspIdentifier, sbspDatum );

                    StructureMemoryBlocks.Add( block );
                    var index = StructureMemoryBlocks.Count - 1;
                    StructureMemoryBlockBindings[ sbspIdentifier ] = index;

                    if ( hasLightmapData )
                    {
                        var ltmpDatum = Index[ ltmpIdentifier ];
                        ltmpDatum.VirtualAddress = ltmpVirtualAddress;
                        ltmpDatum.Length = ltmpLength;
                        Index.Update(ltmpIdentifier, ltmpDatum);
                        StructureMemoryBlockBindings[ ltmpIdentifier ] = index;
                    }
                }
                ActiveAllocation( StructureCache.VirtualStructureCache0 );
            }

            _deserializedTagCache = new Dictionary<TagIdent, dynamic>( Index.Count );
            _tagHashDictionary = new Dictionary<TagIdent, string>( Index.Count );
            Halo2.ActiveMap( this );
        }

        public TagIndex Index { get; private set; }

        public override long Position
        {
            get
            {
                var value = ( int ) base.Position;
                return TryConvertOffsetToPointer( ref value ) ? value : base.Position;
            }
            set { base.Position = CheckOffset( value ); }
        }

        private VirtualMappedAddress ActiveStructureMemoryAllocation { get; set; }

        public void Add<T>(T item, string tagName ) where T : GuerillaBlock
        {
            var lastDatum = Index.Last( );

            var stream = new VirtualStream( lastDatum.VirtualAddress);
            var binaryWriter = new BinaryWriter( stream );

            binaryWriter.Write( item );
            var serializedTagData = stream.ToArray( );
            
            var attribute = (TagClassAttribute)typeof ( T ).Attribute( typeof ( TagClassAttribute ) );
            var tagDatum = Index.Add(attribute.TagClass, tagName, serializedTagData.Length, lastDatum.VirtualAddress);

#if DEBUG
            var v = new Validator(  );
            v.Validate( tagDatum, stream );
#endif

            Allocate( tagDatum.Identifier, serializedTagData.Length );
        }

        void Allocate( TagIdent ident, int size )
        {
            //create virtual stream to write into
            var tagCacheStream = new VirtualStream( Index[ Index.GlobalsIdent ].VirtualAddress );

            var binaryWriter = new BinaryWriter(tagCacheStream);

            for ( var i = 0; i < Index.Count; ++i )
            {
                var datum = Index[ i ];
                
                // is this address affected by the shift?
                if (datum.Identifier == ident)
                {
                    var alignment = Guerilla.Guerilla.AlignmentOf(Halo2.GetTypeOf(Index[ident].Class));
                    datum.VirtualAddress = binaryWriter.BaseStream.Pad(alignment);
                    binaryWriter.Write(new byte[size]);
                    datum.Length = size;
                    Index.Update(datum.Identifier, datum);
                }
                else
                {
                    var data = Deserialize(datum.Identifier);
                    //var alignment = Guerilla.Guerilla.AlignmentOf(data.GetType());
                    //datum.VirtualAddress = binaryWriter.BaseStream.Pad(alignment);
                    //var length = binaryWriter.BaseStream.Length;
                    //binaryWriter.Write(data);
                    //binaryWriter.Seek(0, SeekOrigin.End);
                    //length = ( int ) binaryWriter.BaseStream.Length - length;
                    //datum.Length = (int)length;
                    //Index.Update(datum.Identifier, datum);
                }
            }
            binaryWriter.WritePadding( 512 );
        }

        private static void ProcessFields( List<MoonfishTagField> fields, BinaryReader binaryReader , BinaryWriter binaryWriter, int address )
        {
            foreach (var field in fields)
            {
                if ( field.Type == MoonfishFieldType.FieldBlock )
                {
                    // move the stream to the field
                    var offsetOfField = MoonfishTagDefinition.CalculateOffsetOfField(fields, field);
                    binaryReader.BaseStream.Position = address + offsetOfField;

                    var elementSize = ( ( MoonfishTagDefinition ) field.Definition ).CalculateSizeOfFieldSet( );
                    var pointer = binaryReader.ReadBlamPointer( elementSize );

                }
                if ( field.Type == MoonfishFieldType.FieldData )
                {
                }
            }
        }


        public void ActiveAllocation( StructureCache activeAllocation )
        {
            var index = ( int ) activeAllocation;
            ActiveStructureMemoryAllocation = StructureMemoryBlocks[ index ];
        }

        public string CalculateHash( TagIdent ident )
        {
            using ( var sha1 = new SHA1CryptoServiceProvider( ) )
            {
                var hash = Convert.ToBase64String( sha1.ComputeHash( GetInternalTagMeta( ident ) ) );
                //Console.WriteLine(hash);
                return hash;
            }
        }

        public bool ContainsPointer( BlamPointer blamPointer )
        {
            return DefaultMemoryBlock.Contains( blamPointer ) || ActiveStructureMemoryAllocation.Contains( blamPointer );
        }

        public object Deserialize( TagIdent ident )
        {
            object deserializedTag;
            if ( _deserializedTagCache.TryGetValue( ident, out deserializedTag ) )
                return deserializedTag;

            Seek( ident );

            var typeQuery = Halo2.GetTypeOf(Index[ident].Class);

            if ( typeQuery == null ) return null;

            _deserializedTagCache[ ident ] = this.Deserialize( typeQuery );
            _tagHashDictionary[ ident ] = CalculateHash( ident );

            return _deserializedTagCache[ ident ];
        }

        public long GetFilePosition( )
        {
            return base.Position;
        }

        public string GetTagHash( TagIdent ident )
        {
            return _tagHashDictionary.ContainsKey( ident ) ? _tagHashDictionary[ ident ] : null;
        }

        public void ClearCache( TagIdent ident )
        {
            _deserializedTagCache.Remove( ident );
        }

        public long Seek( TagIdent tagident )
        {
            return Seek( Index[ tagident ].VirtualAddress, SeekOrigin.Begin );
        }

        public override long Seek( long offset, SeekOrigin origin )
        {
            offset = CheckOffset( offset );
            base.Seek( offset, origin );
            return Position;
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

        private int CalculateChecksum( )
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

        private long CheckOffset( long value )
        {
            // if 'value' is a Pointer
            if ( value < 0 || value > Length )
            {
                return VirtualAddressToFileOffset( ( int ) value );
            }
            return value;
        }

        /// <summary>
        ///     Returns the meta that is linked to the Tag
        /// </summary>
        /// <param name="ident"></param>
        /// <returns></returns>
        private byte[] GetInternalTagMeta( TagIdent ident )
        {
            using ( this.Pin( ) )
            {
                Seek( ident );
                var tag = Index[ ident ];
                var buffer = new byte[tag.Length];
                Read( buffer, 0, tag.Length );
                return buffer;
            }
        }

        private bool TryConvertOffsetToPointer( ref int value )
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