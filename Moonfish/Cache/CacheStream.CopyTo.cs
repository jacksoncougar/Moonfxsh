using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Moonfish.Guerilla;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;

namespace Moonfish.Cache
{
    partial class Map
    {
        private const int VirtualBaseAddress = -2147086368;

        private static readonly Dictionary<ResourcePointer, ResourcePointer> ShiftData =
            new Dictionary<ResourcePointer, ResourcePointer>( 1000 );

        public static Map Save( Map map )
        {
            // var filename = Path.Combine( Local.MapsDirectory, @"temp.map" );
            // var copyStream = new FileStream( filename, FileMode.Create,
            //     FileAccess.Write, FileShare.ReadWrite, 4 * 1024, FileOptions.SequentialScan );
            // using ( copyStream )
            // using ( map.BaseStream as FileStream )
            // {
            //     map.SaveTo( copyStream );
            // }
            // File.Delete( map.Name );
            // File.Move( filename, map.Name );
            // return new CacheStream( map.Name );
            return map;
        }

        public Stream SaveTo( Stream outputStream )
        {
            var newHeader = Header.CreateShallowCopy( );

            //  bring all the tags into the cache

            foreach ( var tagData in Index )
            {
                Deserialize( tagData.Identifier );
            }

            //  reserve 2048 bytes for the header

            BaseStream.Seek( 2048, SeekOrigin.Begin );
            outputStream.Seek( 2048, SeekOrigin.Begin );

            //  process sound resources

            CopySoundResources( outputStream );

            //  process model resources 

            CopyModelResources( outputStream );

            //  process ltmp & sbsp resources

            CopyStructureResources( outputStream );

            //  process DECR resources

            CopyDecoratorResources( outputStream );

            //  process PRTM resources

            CopyParticleModelResources( outputStream );

            //  process Lipsync resources

            CopyLipsyncResources( outputStream );

            //  process animation resources

            CopyAnimationResources( outputStream );

            //  process sbsp & ltmp meta

            var allocationSize = CopyStructureMeta( outputStream );

            //  process strings

            newHeader.StringsInfo = GenerateStringsTable( outputStream );

            //  process path table & index

            newHeader.PathsInfo = GeneratePathsTable( outputStream );

            //  process unicode index & table

            CopyUnicodeTable( outputStream );

            //  process 'crazy' data
            //  ehhhhh

            //  process bitmap resources

            CopyBitmapResources( outputStream );

            //  process index
            //  reserve space fo the index to be written into

            newHeader.IndexInfo.IndexOffset = ( int ) outputStream.Position;
            newHeader.IndexInfo.IndexLength = Index.GetSize( );
            outputStream.Seek( newHeader.IndexInfo.IndexLength, SeekOrigin.Current );

            //  process meta table

            var metaDataAddress = VirtualBaseAddress + Index.GetSize( ) + TagIndexBase.HeaderSize + allocationSize;
            int metaDataLength;
            CopyMeta( outputStream, metaDataAddress, out metaDataLength );

            newHeader.IndexInfo.MetaAllocationLength = metaDataLength;
            newHeader.IndexInfo.TotalAllocationLength = newHeader.IndexInfo.IndexLength + allocationSize +
                                                        metaDataLength;

            newHeader.FileSize = ( int ) outputStream.Length;


            outputStream.Seek( newHeader.IndexInfo.IndexOffset, SeekOrigin.Begin );
            Index.SerializeTo( outputStream );

            //  write new header

            outputStream.Seek( 0, SeekOrigin.Begin );
            newHeader.SerializeTo( outputStream );

			return outputStream;
        }

        internal static Map SaveAs( Map map, string destFileName )
        {
            var filename = Path.Combine( Local.MapsDirectory, @"temp.map" );
            var copyStream = new FileStream( filename, FileMode.Create,
                FileAccess.Write, FileShare.ReadWrite, 4 * 1024, FileOptions.SequentialScan );

            using ( copyStream )
            using ( map )
            {
                map.SaveTo( copyStream );
                map.Sign( );
            }
            if ( File.Exists( destFileName ) ) File.Delete( destFileName );
            File.Move( filename, destFileName );
            return new Map( destFileName );
        }

        private void CopyAnimationResources( Stream outputStream )
        {
            foreach ( var moonfishXboxAnimationRawBlock in Index.Where( x => x.Class == TagClass.Jmad )
                .Select( x => ( ModelAnimationGraphBlock ) Deserialize( x.Identifier ) )
                .SelectMany( jmadBlock => jmadBlock.XboxAnimationDataBlock ) )
            {
                CopyResource( outputStream, moonfishXboxAnimationRawBlock );
            }
        }

        private void CopyBitmapResources( Stream outputStream )
        {
            foreach ( var bitmapDataBlock in Index.Where( x => x.Class == TagClass.Bitm )
                .Select( tagData => ( BitmapBlock ) Deserialize( tagData.Identifier ) )
                .SelectMany( bitmapBlock => bitmapBlock.Bitmaps ) )
            {
                CopyIndexedResource( outputStream, bitmapDataBlock, 3 );
            }
        }

        private void CopyDecoratorResources( Stream outputStream )
        {
            foreach ( var decrBlock in Index.Where( x => x.Class == TagClass.DECR )
                .Select( x => ( DecoratorSetBlock ) Deserialize( x.Identifier ) ) )
            {
                CopyResource( outputStream, decrBlock );
            }
        }

        private void CopyIndexedResource( Stream outputStream, IResourceBlock resourceBlock, int resourceCount )
        {
            for ( var i = 0; i < resourceCount; i++ )
            {
                var address = resourceBlock.GetResourcePointer( i );
                var length = resourceBlock.GetResourceLength( i );
                switch ( address.Source )
                {
                    case Halo2.ResourceSource.Local:
                        CopyLocalResource( outputStream, resourceBlock, address, length, i );
                        break;
                    default:
                        //  we don't need to do anything with external resources
                        continue;
                }
            }
        }

        private void CopyLipsyncResources( Stream outputStream )
        {
			if (!Index.Any(x => x.Class == TagClass.Ugh)) return;

            var ughData = Index.First( x => x.Class == TagClass.Ugh );
            var ughBlock = ( SoundCacheFileGestaltBlock ) Deserialize( ughData.Identifier );
            foreach ( var soundGestaltExtraInfoBlock in ughBlock.ExtraInfos )
            {
                CopyResource( outputStream, soundGestaltExtraInfoBlock );
            }
        }

        private void CopyLocalResource( Stream outputStream, IResourceBlock resourceBlock, ResourcePointer address,
            int length, int index = 0 )
        {
            //  the resource has already been copied
            if ( address < GetFilePosition( ) )
            {
                //  if this is true then we've already handled this resource so use the 
                //  new address
                ResourcePointer newAddress;
                if ( ShiftData.TryGetValue( address, out newAddress ) )
                {
                    resourceBlock.SetResourcePointer( newAddress, index );
                    return;
                }
                //  has the resource already been copied? Has it been moved?
                //  well, shit.
                System.Diagnostics.Debug.WriteLineIf( address < GetFilePosition( ),
                    "Warning: address < GetFilePosition()" );
                BaseStream.Seek( address );
            }
            //  this is not strictly an error but it should be treated as such
            if ( address > GetFilePosition( ) )
            {
                System.Diagnostics.Debug.WriteLineIf( address > GetFilePosition( ),
                    "Warning: address > GetFilePosition()" );
                BaseStream.Seek( address );
            }
            System.Diagnostics.Debug.WriteLineIf( address % 512 != 0, "Warning: address % 512 != 0" );
            if ( outputStream.Position % 512 != 0 )
                System.Diagnostics.Debug.WriteLineIf( outputStream.Position % 512 != 0,
                    "Warning: output address % 512 != 0" );


            var position = outputStream.Position;
            ShiftData[ address ] = ( int ) position;
            resourceBlock.SetResourcePointer( ( int ) position, index );

            var size = Padding.Align( length, 512 );
            BaseStream.BufferedCopyBytesTo( size, outputStream );
        }

        private void CopyMeta( Stream outputStream, int address, out int metaDataSize )
        {
            var startAddress = outputStream.Align( 512 );
            var buffer = new VirtualStream( address );

            for ( var i = 0; i < Index.Count; ++i )
            {
                var datum = Index[ i ];

                if ( datum.Class == TagClass.Sbsp || datum.Class == TagClass.Ltmp )
                {
                    datum.Length = 0;
                    datum.VirtualAddress = 0;
                    Index.Update( datum.Identifier, datum );
                    continue;
                }

                var data = Deserialize( datum.Identifier );
                var dataAddress = ( int ) buffer.Position;

                Padding.AssertIsAligned( 4, buffer );

                buffer.Write( data );
                buffer.Align( );
                var length = ( int ) buffer.Position - dataAddress;

                datum.Length = length;
                datum.VirtualAddress = dataAddress;

                Index.Update( datum.Identifier, datum );
            }
            buffer.Position = 0;
            buffer.BufferedCopyBytesTo( ( int ) buffer.Length, outputStream );
            metaDataSize = outputStream.Align( 4096 ) - startAddress;
        }

        private void CopyModelResources( Stream outputStream )
        {
            foreach (
                var renderModelBlock in
                    Index.Where( x => x.Class == TagClass.Mode )
                        .Select( tagData => ( RenderModelBlock ) Deserialize( tagData.Identifier ) ) )
            {
                foreach ( var renderModelSectionBlock in renderModelBlock.Sections )
                {
                    CopyResource( outputStream, renderModelSectionBlock );
                }
                foreach ( var prtInfoBlock in renderModelBlock.PRTInfo )
                {
                    CopyResource( outputStream, prtInfoBlock );
                }
            }
        }

        private void CopyParticleModelResources( Stream outputStream )
        {
            foreach ( var prtmBlock in Index.Where( x => x.Class == TagClass.PRTM )
                .Select( x => ( ParticleModelBlock ) Deserialize( x.Identifier ) ) )
            {
                CopyResource( outputStream, prtmBlock );
            }
        }

        private void CopyResource( Stream outputStream, IResourceBlock resourceBlock )
        {
            CopyIndexedResource( outputStream, resourceBlock, 1 );
        }

        private void CopySoundResources( Stream outputStream )
        {
			if (!Index.Any(x => x.Class == TagClass.Ugh)) return;

			var ughData = Index.First( x => x.Class == TagClass.Ugh );
            var ughBlock = ( SoundCacheFileGestaltBlock ) Deserialize( ughData.Identifier );
            for ( var index = 0; index < ughBlock.Chunks.Length; index++ )
            {
                var soundPermutationChunkBlock = ughBlock.Chunks[ index ];
                CopyResource( outputStream, soundPermutationChunkBlock );
            }
        }

        private int CopyStructureMeta( Stream outputStream )
        {
			if (!Index.Any(x => x.Class == TagClass.Scnr)) return 0;

            var allocationLength = 0;
            var scnrBlock = ( ScenarioBlock ) Deserialize( Index.ScenarioIdent );
            var buffer = new byte[0x2000000]; // 32 mebibytes
            foreach ( var scenarioStructureBspReferenceBlock in scnrBlock.StructureBSPs )
            {
                //  create a virtual stream to write the meta into and assign the origin address
                //  of the first valid memory after the index
                //
                //  note: the virtual stream is used to generate valid pointer addressess
                var allocationAddress = VirtualBaseAddress + Index.GetSize( ) + TagIndexBase.HeaderSize;
                var virtualMemoryStream = new VirtualStream( buffer, allocationAddress );

                var sbspReference = scenarioStructureBspReferenceBlock.StructureBSP;
                var ltmpReference = scenarioStructureBspReferenceBlock.StructureLightmap;

                //  if both references are null then we don't copy out the meta
                if ( TagIdent.IsNull( ltmpReference.Ident ) && TagIdent.IsNull( sbspReference.Ident ) ) continue;

                virtualMemoryStream.Write( new byte[16], 0, 16 );
                //  create an allocation header to hold information about this memory allocation
                var structureAllocationHeader = new StructureAllocationHeader
                {
                    StructureBSPAddress = ( int ) virtualMemoryStream.Position,
                    FourCC = TagClass.Sbsp
                };

                //  grab the structurebsp from the cache and write it out to the virtual stream,
                //  padding it to 4 byte alignement
                var sbspBlock = ( ScenarioStructureBspBlock ) Deserialize( sbspReference.Ident );
                virtualMemoryStream.Write( sbspBlock );
                virtualMemoryStream.Align( );

                //  if the lightmap is not null write out the meta data into the virtual stream
                if ( !TagIdent.IsNull( ltmpReference.Ident ) )
                {
                    structureAllocationHeader.LightmapAddress = ( int ) virtualMemoryStream.Position;
                    var ltmpBlock = ( ScenarioStructureLightmapBlock ) Deserialize( ltmpReference.Ident );
                    virtualMemoryStream.Write( ltmpBlock );
                }


                structureAllocationHeader.BlockLength = Padding.Align(
                    virtualMemoryStream.Position - allocationAddress, 4096 );

                //  set the value of BlockLength to the length of the virtual stream,
                //  then serialize and write the header to the output stream, followed by writing
                //  the contents of the vitual stream to the output stream
                //  finally pad the entire thing to 4096 byte alignment

                //  copy data
                virtualMemoryStream.Seek( 0, SeekOrigin.Begin );
                structureAllocationHeader.SerializeTo( virtualMemoryStream );
                virtualMemoryStream.Seek( -StructureAllocationHeader.SizeInBytes, SeekOrigin.Current );

                scenarioStructureBspReferenceBlock.StructureBlockInfo.BlockOffset =
                    ( int ) outputStream.Position;

                Padding.AssertIsAligned( 512, outputStream );
                virtualMemoryStream.BufferedCopyBytesTo( structureAllocationHeader.BlockLength, outputStream );
                Padding.AssertIsAligned( 512, outputStream );


                scenarioStructureBspReferenceBlock.StructureBlockInfo.BlockAddress =
                    allocationAddress;

                scenarioStructureBspReferenceBlock.StructureBlockInfo.BlockLength =
                    structureAllocationHeader.BlockLength;


                //  return only the largest allocation size, because all allocations are in the 
                //  same virtual memory
                allocationLength = allocationLength > structureAllocationHeader.BlockLength
                    ? allocationLength
                    : structureAllocationHeader.BlockLength;
            }
            return allocationLength;
        }

        private void CopyStructureResources( Stream outputStream )
        {
			if (!Index.Any(x => x.Class == TagClass.Scnr)) return;

            var scnrBlock = ( ScenarioBlock ) Deserialize( Index.ScenarioIdent );
            foreach ( var scenarioStructureBspReferenceBlock in scnrBlock.StructureBSPs )
            {
                var sbspReference = scenarioStructureBspReferenceBlock.StructureBSP;
                var ltmpReference = scenarioStructureBspReferenceBlock.StructureLightmap;

                var sbspBlock = ( ScenarioStructureBspBlock ) Deserialize( sbspReference.Ident );
                foreach ( var structureBspClusterBlock in sbspBlock.Clusters )
                {
                    CopyResource( outputStream, structureBspClusterBlock );
                }
                foreach ( var structureBspInstancedGeometryDefinitionBlock in sbspBlock.InstancedGeometriesDefinitions )
                {
                    CopyResource( outputStream, structureBspInstancedGeometryDefinitionBlock.RenderInfo );
                }
                if ( !TagIdent.IsNull( ltmpReference.Ident ) )
                {
                    var ltmpBlock = ( ScenarioStructureLightmapBlock ) Deserialize( ltmpReference.Ident );
                    foreach ( var result in ltmpBlock.LightmapGroups.SelectMany( x => x.GeometryBuckets ) )
                    {
                        CopyResource( outputStream, result );
                    }
                }
                foreach ( var result in sbspBlock.Decorators0.SelectMany( x => x.CacheBlocks ) )
                {
                    CopyResource( outputStream, result );
                }
                foreach ( var globalWaterDefinitionsBlock in sbspBlock.WaterDefinitions )
                {
                    CopyResource( outputStream, globalWaterDefinitionsBlock );
                }
            }
        }

        private void CopyUnicodeTable( Stream outputStream )
        {
			if (TagIdent.IsNull(Index.GlobalsIdent)) return;

            var globalsBlock = ( GlobalsBlock ) Deserialize( Index.GlobalsIdent );
            var newUnicodeBlockInfo = new MoonfishGlobalUnicodeBlockInfoStructBlock
            {
                EnglishStringCount = globalsBlock.UnicodeBlockInfo.EnglishStringCount,
                EnglishStringTableLength = globalsBlock.UnicodeBlockInfo.EnglishStringTableLength
            };

            //  calculate the size of the Unicode table-index & tables to the nearest 512 aligned block
            var alignedIndexSize = Padding.Align(
                globalsBlock.UnicodeBlockInfo.EnglishStringCount * sizeof ( int ) * 2, 512 );
            var alignedTableSize = Padding.Align( globalsBlock.UnicodeBlockInfo.EnglishStringTableLength, 512 );

            //  move the stream to the start of the unicode data
            BaseStream.Seek( globalsBlock.UnicodeBlockInfo.EnglishStringIndexAddress, SeekOrigin.Begin );

            //  copy the table-index and index to the output stream
            newUnicodeBlockInfo.EnglishStringIndexAddress = ( int ) outputStream.Position;
            Padding.AssertIsAligned( 512, outputStream );
            BaseStream.BufferedCopyBytesTo( alignedIndexSize, outputStream );
            newUnicodeBlockInfo.EnglishStringTableAddress = ( int ) outputStream.Position;
            Padding.AssertIsAligned( 512, outputStream );
            BaseStream.BufferedCopyBytesTo( alignedTableSize, outputStream );

            //  assign the new UnicodeBlockInfo data to the globals block
            globalsBlock.UnicodeBlockInfo = newUnicodeBlockInfo;
        }

        /// <summary>
        ///     Copies the paths from the Index into the given stream at the current address
        ///     note: Creates the table on an align(512) address then creates the table-index on
        ///     an align(512) address following it.
        /// </summary>
        /// <param name="outputStream">The stream to write to</param>
        /// <returns>PathInfoStruct containing addresses/info of the paths table & index</returns>
        private PathsInfoStruct GeneratePathsTable( Stream outputStream )
        {
            var info = new PathsInfoStruct( );
            //  extract the paths from the index and copy them into a local list object.
            var paths = Index.Select( x => x.Path ).ToList( );
            info.PathCount = paths.Count;
            info.PathTableAddress = outputStream.Align( 512 );
            //  pad the stream to align(512) and assign the new address to PathTableAddress.
            GenerateStringEntries( outputStream, paths );
            //  Write the paths into the stream and subtract the PathTableAddress from the new stream position 
            //  to get the PathTableLength.
            info.PathTableLength = ( int ) outputStream.Position - info.PathTableAddress;
            //  pad the stream to align(512) and assign the new address to PathIndexAddress.
            info.PathIndexAddress = outputStream.Align( 512 );
            //  write the index for the path table
            GenerateTableIndex( outputStream, paths );

            //  finish on the next 512 alignment boundary
            outputStream.Align( 512 );
            Padding.AssertIsAligned( 512, outputStream );
            //  return the struct that contains the information about where in the stream this 
            //  resource was written
            return info;
        }

        private void GenerateStringEntries( Stream outputStream, IEnumerable<string> strings )
        {
            var buffer = new byte[128];
            foreach ( var value in strings )
            {
                Array.Clear( buffer, 0, buffer.Length );
                var length = Encoding.ASCII.GetBytes( value, 0, value.Length, buffer, 0 );
                outputStream.Write( buffer, 0, length + 1 );
            }
        }

        /// <summary>
        ///     Copys all the strings from the cache into 128 byte blocks into outputStream.
        ///     note: will pad to align(512) before and after the table
        /// </summary>
        /// <param name="outputStream">stream to copy strings into</param>
        private void GenerateStrings128( Stream outputStream )
        {
            outputStream.Align( 512 );
            var buffer = new byte[128];
            foreach ( var value in Strings.Values )
            {
                //  zero out the buffer, the convert the string into ASII encoding and get the bytes,
                //  compute the length truncated to the length of the buffer to avoid overrunning the buffer
                //  finally copy the string bytes into the buffer
                Array.Clear( buffer, 0, buffer.Length );
                var sourceArray = Encoding.ASCII.GetBytes( value );
                var length = Math.Min( sourceArray.Length, buffer.Length );
                Array.Copy( sourceArray, buffer, length );

                outputStream.Write( buffer, 0, buffer.Length );
            }
        }

        private StringsInfoStruct GenerateStringsTable( Stream outputStream )
        {
            var info = new StringsInfoStruct
            {
                StringCount = Strings.Count,
                Strings128TableAddress = outputStream.Align( 512 )
            };

            GenerateStrings128( outputStream );
            info.StringIndexAddress = outputStream.Align( 512 );
            GenerateTableIndex( outputStream, Strings.Values );
            info.StringTableAddress = outputStream.Align( 512 );
            GenerateStringEntries( outputStream, Strings.Values );
            info.StringTableLength = ( int ) outputStream.Position - info.StringTableAddress;

            outputStream.Align( 512 );

            return info;
        }

        private void GenerateTableIndex( Stream outputStream, ICollection<string> values )
        {
            //  the buffer size is calculated for writing an offset to each string
            var bufferSize = values.Count * sizeof ( int );
            var indexBuffer = new byte[bufferSize];
            using ( var binaryWriter = new BinaryWriter( new MemoryStream( indexBuffer ) ) )
            {
                var offset = 0;
                foreach(var value in values)
                {
                    //  strings are encoded using ASCII
                    //  first write the offset from the start of the strings table to the start of this string
                    //  finally add the length of the string to the offset to get the offset to the next string
                    //  —the strings are null terminated so add one extra byte for the null char
                    var length = Encoding.ASCII.GetByteCount( value );
                    binaryWriter.Write( offset );
                    offset += length + 1;
                }
            }
            outputStream.Write( indexBuffer, 0, indexBuffer.Length );
        }
    }
}