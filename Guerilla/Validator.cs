using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Moonfish.Tags;
using Moonfish.Tags.BlamExtension;

namespace Moonfish.Guerilla
{
    public class Validator
    {
        private Func<BlamPointer, bool> _isPointerOwnedByTagDelegate;
        private Func<BlamPointer, bool> _isValidDelegate;
        private List<Tuple<BlamPointer, ElementArray>> _pointersList;
        private Log _writeMessage;

        private bool error;

        public bool Validate( MoonfishTagGroup validateTag, IEnumerable<MoonfishTagGroup> tagPool, string[] filenames )
        {
            error = false;
            _pointersList = new List<Tuple<BlamPointer, ElementArray>>( );
            var filename = string.Format( @"{1}\analysis\{0}.txt",
                validateTag.Class.ToTokenString( ), Local.MapsDirectory );
            var stringWriter = File.CreateText( filename );

            _writeMessage = ( stringWriter.WriteLine );

            var offset = 0;
            var elementArray = CompileElementArray( validateTag, tagPool, offset );

            elementArray.count = 1;

            foreach ( var file in filenames )
            {
                using ( var map = new CacheStream( file ) )
                {
                    var binaryReader = new BinaryReader( map );

                    OnWriteMessage( string.Format( "Begin ({0})", map.MapName ) );

                    foreach ( var tag in map.Tags )
                    {
                        if ( !( tag.Class == validateTag.Class ) ) continue;

                        var metaTableMemory = map.DefaultMemoryBlock;
                        if ( tag.Class == TagClass.Sbsp || tag.Class == TagClass.Ltmp )
                        {
                            metaTableMemory =
                                map.StructureMemoryBlocks[ map.StructureMemoryBlockBindings[ tag.Identifier ] ];
                            map.ActiveAllocation( CacheStream.StructureCache.VirtualStructureCache0 +
                                                  map.StructureMemoryBlockBindings[ tag.Identifier ] );
                        }

                        if ( tag.Identifier.Index == 8219 )
                        {
                            //135010976
                        }
                        _isValidDelegate = metaTableMemory.Contains;
                        var virtualTagMemory = new VirtualMappedAddress
                        {
                            Address = tag.VirtualAddress,
                            Length = tag.Length
                        };
                        _isPointerOwnedByTagDelegate = virtualTagMemory.Contains;
                        OnWriteMessage( string.Format( "Tag ({0})", tag.Path ) );

                        offset = ( int ) map.Seek( tag );


                        elementArray.virtualAddress = map.GetTag( tag.Identifier ).VirtualAddress;
                        _pointersList = new List<Tuple<BlamPointer, ElementArray>>( );
                        ValidateTagBlock( elementArray, elementArray.ToFixedArrayPointer( ), binaryReader, ref offset );
                        stringWriter.Flush( );
                    }

                    Console.WriteLine( @"Parsed ({0})", map.MapName );
                }
            }
            stringWriter.Close( );

            if ( !error )
                File.Delete( filename );

            return error;
        }

        private ElementArray CompileElementArray( MoonfishTagGroup tag, IEnumerable<MoonfishTagGroup> tags, int offset )
        {
            ElementArray elementArray;
            if ( tag.ParentClass != TagClass.Null )
            {
                var guerillaTagGroups = tags as IList<MoonfishTagGroup> ?? tags.ToList( );
                var parentClass = guerillaTagGroups.Single( x => x.Class == tag.ParentClass );
                if ( parentClass.ParentClass != TagClass.Null )
                {
                    var baseClass = guerillaTagGroups.Single( x => x.Class == parentClass.ParentClass );
                    elementArray = ProcessTagBlockDefinition( baseClass.Definition, ref offset, true );
                    elementArray.Append( ProcessTagBlockDefinition( parentClass.Definition, ref offset, true ) );
                    elementArray.Append( ProcessTagBlockDefinition( tag.Definition, ref offset, true ) );
                }
                else
                {
                    elementArray = ProcessTagBlockDefinition( parentClass.Definition, ref offset, true );
                    elementArray.Append( ProcessTagBlockDefinition( tag.Definition, ref offset, true ) );
                }
            }
            else
            {
                elementArray = ProcessTagBlockDefinition( tag.Definition, ref offset, true );
            }
            return elementArray;
        }

        private bool IsOwnedByTag( BlamPointer pointer )
        {
            return _isPointerOwnedByTagDelegate != null && _isPointerOwnedByTagDelegate( pointer );
        }

        private bool IsValid( BlamPointer pointer )
        {
            return _isValidDelegate != null && _isValidDelegate( pointer );
        }

        private void OnWriteMessage( string message )
        {
            if ( _writeMessage != null ) _writeMessage( message );
        }

        private void ProcessArrayFields( IList<MoonfishTagField> fields, ElementArray elementArray,
            MoonfishTagField field, ref int i, ref int offset )
        {
            var name = field.Name;
            ++i; //move past field_type._field_array_start
            for ( var index = 0; index < field.Count; ++index )
            {
                var startindex = i;
                ProcessFields( fields, elementArray, ref startindex, ref offset );
            }
            ++i; // move past field_type._field_array_end
        }

        private void ProcessFields( IList<MoonfishTagField> fields, ElementArray elementArray, ref int i, ref int offset )
        {
            for ( ; i < fields.Count; ++i )
            {
                var field = fields[ i ];
                // Check the field type.
                switch ( field.Type )
                {
                    case MoonfishFieldType.FieldBlock:
                    {
                        var childElementArray = ProcessTagBlockDefinition( elementArray, field.Definition, ref offset );
                        elementArray.children.Add( childElementArray );
                        break;
                    }
                    case MoonfishFieldType.FieldStruct:
                    {
                        var struct_definition = ( MoonfishTagStruct ) field.Definition;
                        var structOffset = offset;
                        var childElementArray = ProcessTagStructDefinition( elementArray, struct_definition.Definition,
                            ref structOffset );
                        elementArray.children.AddRange( childElementArray );

                        break;
                    }
                    case MoonfishFieldType.FieldData:
                    {
                        var data_definition = ( MoonfishTagDataDefinition ) field.Definition;
                        var childElementArray = new ElementArray
                        {
                            elementSize = ( ( MoonfishTagDataDefinition ) field.Definition ).DataElementSize,
                            name = data_definition.Name,
                            address = offset,
                            parent = elementArray,
                            alignment = data_definition.Alignment
                        };
                        elementArray.children.Add( childElementArray );
                        break;
                    }
                    case MoonfishFieldType.FieldArrayStart:
                    {
                        ProcessArrayFields( fields, elementArray, field, ref i, ref offset );
                        break;
                    }
                    case MoonfishFieldType.FieldArrayEnd:
                    {
                        return;
                    }
                }
                offset += MoonfishTagDefinition.CalculateSizeOfField( field );
            }
        }

        private ElementArray ProcessTagBlockDefinition( MoonfishTagDefinition tagBlock, ref int offset,
            bool inline = false )
        {
            return ProcessTagBlockDefinition( null, tagBlock, ref offset, inline );
        }

        private ElementArray ProcessTagBlockDefinition( ElementArray parent, MoonfishTagDefinition tagBlock,
            ref int offset, bool inline = false )
        {
            var size = tagBlock.CalculateSizeOfFieldSet( );

            var blockElementArray = new ElementArray
            {
                name = tagBlock.Name,
                elementSize = size,
                address = offset,
                parent = parent,
                maxElementCount = tagBlock.MaximumElementCount,
                alignment = tagBlock.Alignment
            };

            var i = 0;
            var blockOffset = inline ? offset : 0;
            ProcessFields( tagBlock.Fields, blockElementArray, ref i, ref blockOffset );
            if ( inline ) offset = blockOffset;
            return blockElementArray;
        }

        private IEnumerable<ElementArray> ProcessTagStructDefinition( ElementArray parent,
            MoonfishTagDefinition definition, ref int offset )
        {
            var size = definition.CalculateSizeOfFieldSet( );

            var blockElementArray = new ElementArray
            {
                name = definition.Name,
                elementSize = size,
                address = offset,
                parent = parent,
                maxElementCount = definition.MaximumElementCount,
                alignment = definition.Alignment
            };

            var i = 0;
            ProcessFields( definition.Fields, blockElementArray, ref i, ref offset );
            return blockElementArray.children;
        }

        private bool ValidateBlamPointer( BlamPointer blamPointer, ElementArray info, CacheStream stream )
        {
            var stringWriter = new StringWriter( );
            if ( blamPointer.elementCount == 0 && blamPointer.startAddress == 0 ) return true;
            if ( blamPointer.elementCount == 0 ^ blamPointer.startAddress == 0 )
                stringWriter.WriteLine( "-> null-value count({0}) address({1}) is invalid", blamPointer.elementCount,
                    blamPointer.startAddress );
            if ( blamPointer.elementCount < 0 )
                stringWriter.WriteLine( "-> count({0}) is invalid", blamPointer.elementCount );
            if ( blamPointer.elementCount > info.maxElementCount && info.maxElementCount > 0 )
                stringWriter.WriteLine( "-> count({0}) > max-count({1})", blamPointer.elementCount, info.maxElementCount );
            if ( !stream.ContainsPointer( blamPointer ) )
                stringWriter.WriteLine( "-> address({0}) not contained in stream({1})", blamPointer.startAddress,
                    stream.Name );

            var errors = stringWriter.ToString( );
            if ( !string.IsNullOrWhiteSpace( errors ) )
            {
                error = true;
                OnWriteMessage( string.Format( "Pointer ({0})\n{1}", info.name, errors ) );
                return false;
            }
            return true;
        }

        private void ValidateChildren( ElementArray elementArray, BinaryReader binaryReader, ref int nextAddress )
        {
            var childrenArrayPointers = ( from child in elementArray.children
                select new
                {
                    ElementArray = child,
                    ArrayPointer = new Func<BlamPointer>( ( ) =>
                    {
                        using ( binaryReader.BaseStream.Pin( ) )
                        {
                            binaryReader.BaseStream.Seek( child.address, SeekOrigin.Current );
                            var arrayPointer = binaryReader.ReadBlamPointer( child.elementSize );
                            child.virtualAddress = arrayPointer.startAddress;
                            child.count = arrayPointer.elementCount;
                            return arrayPointer;
                        }
                    } )( )
                } ).ToList( );
            foreach ( var child in childrenArrayPointers )
            {
                if (
                    !ValidateBlamPointer( child.ArrayPointer, child.ElementArray, binaryReader.BaseStream as CacheStream ) )
                    continue;
                if ( !( child.ArrayPointer.elementCount == 0 && child.ArrayPointer.startAddress == 0 ) )
                {
                    ValidateTagBlock( child.ElementArray, child.ArrayPointer, binaryReader, ref nextAddress );
                }
            }
        }

        private void ValidateTagBlock( ElementArray info, BlamPointer pointer, BinaryReader reader, ref int address )
        {
            using ( reader.BaseStream.Pin( ) )
            {
                // If owned by tag and memory has not been allocated yet*
                var allocated = from item in _pointersList
                    where item.Item1.Equals( pointer )
                    select item;
                var partiallyAllocated = from item in _pointersList
                    where item.Item1.Intersects( pointer )
                    select item;
                if ( IsOwnedByTag( pointer ) )
                {
                    var enumerable = allocated as IList<Tuple<BlamPointer, ElementArray>> ?? allocated.ToList( );
                    if ( !enumerable.Any( ) )
                    {
                        var alignedAddress = ( address ) +
                                             Padding.GetCount( address, info.alignment );
                        if ( pointer.startAddress != alignedAddress )
                        {
                            var mapStream = reader.BaseStream as CacheStream;
                            if ( mapStream != null )
                            {
                                error = true;
                                OnWriteMessage( string.Format( "{2}: Expected address \"{0}\"  - actually was \"{1}\"",
                                    alignedAddress, pointer.startAddress, info.name ) );
                            }
                        }
                        address = pointer.startAddress + pointer.PointedSize;
                    }
                    if ( enumerable.Any( ) )
                    {
                    }
                    else
                    {
                        var overlappingItems = partiallyAllocated as IList<Tuple<BlamPointer, ElementArray>> ??
                                               partiallyAllocated.ToList( );
                        if ( overlappingItems.Any( ) )
                        {
                            foreach ( var overlappingItem in overlappingItems )
                            {
                                error = true;
                                var overlap = pointer.startAddress - overlappingItem.Item1.startAddress -
                                              overlappingItem.Item1.PointedSize;

                                OnWriteMessage(
                                    string.Format(
                                        "Overlap of ({0})\n{3} elements sized '{5}' at '{4}'\nwith ({1})\n{6} elements sized '{8}' at '{7}'\nby ({2}) bytes",
                                        overlappingItem.Item2.ToHierarchyString( ), info.ToHierarchyString( ), overlap,
                                        overlappingItem.Item1.elementCount, overlappingItem.Item1.startAddress,
                                        overlappingItem.Item1.elementSize,
                                        pointer.elementCount, pointer.startAddress, pointer.elementSize ) );
                            }
                        }
                    }
                }
                else if ( !IsValid( pointer ) )
                {
                    error = true;
                    OnWriteMessage( string.Format( "INVALID POINTER {1} -> {0}", info.name, pointer ) );
                    return;
                }
                else
                {
                    OnWriteMessage( string.Format( "EXTERNAL SHARE" ) );
                }

                _pointersList.Add( new Tuple<BlamPointer, ElementArray>( pointer, info ) );

                foreach ( var elementAddress in pointer )
                {
                    reader.BaseStream.Position = elementAddress;
                    ValidateChildren( info, reader, ref address );
                }
            }
        }

        private delegate void Log( string message );
    }

    public class ElementArray
    {
        public readonly List<ElementArray> children;
        public int address;
        public int alignment;
        public int count;
        public int elementSize;
        public int maxElementCount;
        public string name;
        public ElementArray parent;
        public int virtualAddress;

        public ElementArray( )
        {
            name = default( string );
            elementSize = default( int );
            maxElementCount = default( int );
            count = default( int );
            address = -1;
            alignment = 4;
            children = new List<ElementArray>( );
            parent = null;
        }

        public bool HasChildren
        {
            get { return children.Count > 0 ? true : false; }
        }

        public void Append( ElementArray array )
        {
            name = string.Format( "{0}:{1}", name, array.name );
            elementSize = elementSize + array.elementSize;
            alignment = array.alignment > alignment ? array.alignment : alignment;
            children.AddRange( array.children );
        }

        public BlamPointer ToFixedArrayPointer( )
        {
            return new BlamPointer( count, virtualAddress, elementSize );
        }

        public string ToHierarchyString( )
        {
            if ( parent == null )
                return name;
            return parent.ToHierarchyString( ) + " -> " + name;
        }

        public override string ToString( )
        {
            return name;
        }
    }
}