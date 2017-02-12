using System;
using System.Collections.Generic;
using System.Linq;
using Fasterflect;
using Moonfish.Cache;
using Moonfish.Graphics.RenderingEngine;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;
using OpenTK.Graphics.OpenGL4;

namespace Moonfish.Graphics
{
    /// <summary>
    ///     Controls all visual aspects of the rendering pipeline of Moonfxsh
    /// </summary>
    public class ScenarioManager
    {
        /// <summary>
        ///     Controls loading of vertex data and creating attribute buffers
        /// </summary>
        private readonly BucketManager _bucketManager;

        /// <summary>
        ///     Controls batching of calls, sorting of transparancies, etc
        /// </summary>
        private readonly DrawManager _drawManager;

        private readonly MaterialManager _materialManager;

        private readonly TagCache _moonfishCache = new TagCache( );

        private InstanceDataBuffer InstancesBuffer { get; } = new InstanceDataBuffer( );

        public ScenarioManager( )
        {
            _materialManager = new MaterialManager( );
            _drawManager = new DrawManager( );
            _bucketManager = new BucketManager( );
        }

        private static int CurrentBucketVao { get; set; }

        private List<ObjectBlock> StaticObjects { get; } = new List<ObjectBlock>( );

        private Dictionary<Type, bool> SupportsPermutations { get; } = new Dictionary<Type, bool>( );


        /// <summary>
        ///     Walks the scenario and draws all objects with their current state
        /// </summary>
        /// <param name="eye">The viewer camera</param>
        /// <param name="programManager"></param>
        /// <param name="scenario"></param>
        public void DrawScenario( Camera eye, ProgramManager programManager, ScenarioBlock scenario )
        {
            var program = programManager.DebugShader;
            program.Assign( );

            _drawManager.Clear( );
            TraverseScenario( eye, scenario );
            _drawManager.Sort( eye );

            CurrentBucketVao = 0;

            // TODO better batching!
            _drawManager.InstanceManager.BufferInstanceData(InstancesBuffer);
            _drawManager.CreateIndirectDrawCommands( _bucketManager, InstancesBuffer );
            _drawManager.DispatchDraws(InstancesBuffer);
            //foreach ( var shaderIdent in _drawManager.GetShaders( ) )
            //{
            //    var renderPatches = _drawManager.GetOpaqueParts( shaderIdent ).ToArray( );
            //    if ( renderPatches.Length <= 0 )
            //    {
            //        continue;
            //    }
            //    DrawPatchElements( renderPatches, shaderIdent );
            //}
        }
        
        /// <summary>
        ///     Buffers array data and creates draw commands as needed for a given object
        /// </summary>
        /// <param name="eye">Viewer camera used to select detail level</param>
        /// <param name="objectBlock">Object to draw</param>
        /// <param name="instance">Instance data of object to draw</param>
        private void Dispatch( Camera eye, ObjectBlock objectBlock,
            IH2ObjectInstance instance )
        {
            CacheKey cacheKey;
            if ( !objectBlock.TryGetCacheKey( out cacheKey ) ) return;

            var modelBlock = objectBlock.Model.Get<ModelBlock>( cacheKey );
            var renderBlock = modelBlock?.RenderModel.Get<RenderModelBlock>( cacheKey );

            if ( renderBlock == null ) return;

            BucketManager.UnpackVertexData( renderBlock );

            // TODO use bounding offset and bounding radius here x
            var distance = eye.DistanceOf( instance.ObjectDatum.Position );
            var detailLevel = GetDetailLevel( modelBlock, distance );

            var variant = StringIdent.Zero;

            var type = instance.GetType( );
            if ( !SupportsPermutations.ContainsKey( type ) )
            {
                SupportsPermutations[ type ] = type.Field( "PermutationData" ) != null;
            }

            var supportsPermutation = SupportsPermutations[ type ];
            if ( supportsPermutation )
            {
                var instanceVariant = StringIdent.Zero;
                var defaultModelVariant = objectBlock.DefaultModelVariant;

                //  Select the instance variant if it exists, else select the default variant if it exists, 
                //  else default to zero
                variant = instanceVariant == StringIdent.Zero
                    ? defaultModelVariant == StringIdent.Zero ? StringIdent.Zero : defaultModelVariant
                    : instanceVariant;
            }

            var hasVariant = variant != StringIdent.Zero;
            var hasRegions = modelBlock.ModelRegionBlock.Length > 0;

            //  Here sections are collected using the detail level and chosen variant (if it exists)
            RenderModelSectionBlock[] sections;
            if ( hasVariant )
            {
                var variantBlock = modelBlock.Variants.Single( e => e.Name == variant );
                sections = ProcessVariant( variantBlock, renderBlock, detailLevel );
            }
            else if ( hasRegions )
            {
                sections = ProcessRegions( modelBlock.ModelRegionBlock, renderBlock, detailLevel );
            }
            else
            {
                sections = renderBlock.Sections;
            }

            //  Loop through all the sections and load the vertex data if needed and pass the part along 
            //  to the draw manager to  handle sorting and grouping
            foreach ( var renderModelSection in sections )
            {
                if ( renderModelSection.SectionData.Length <= 0 ) continue;

                _bucketManager.BufferPartData( renderModelSection.SectionData[ 0 ].Section );

                foreach ( var part in renderModelSection.SectionData[ 0 ].Section.Parts )
                {
                    var materialBlock = renderBlock.Materials[ part.Material ];

                    //  Create an instance for this part and assign a shader for it
                    _drawManager.CreateInstance( part, instance, supportsPermutation );
                    _drawManager.AssignShader( part, cacheKey, materialBlock.Shader.Ident );
                }
            }
        }

        /// <summary>
        ///     Buffers array data and creates draw commands as needed for a given object
        /// </summary>
        /// <param name="eye">Viewer camera used to select detail level</param>
        /// <param name="objectBlock">Object to draw</param>
        private void Dispatch( Camera eye, ScenarioStructureBspBlock scenarioStructure, CacheKey cacheKey )
        {
            if (scenarioStructure == null ) return;

            foreach ( var cluster in scenarioStructure.Clusters )
            {
                if (! cluster.IsClusterDataLoaded )
                {
                    cluster.LoadClusterData(  );
                }
                var section = cluster.ClusterData[ 0 ].Section;
                _bucketManager.BufferPartData(section);

                foreach (var part in section.Parts)
                {
                    var materialBlock = scenarioStructure.Materials[part.Material];

                    //  Create an instance for this part and assign a shader for it
                    _drawManager.CreateInstance( part, new ScenarioInstanceBlock( ), false );
                    _drawManager.AssignShader(part, cacheKey, materialBlock.Shader.Ident);
                }
            }

        }

        private void DispatchDeletion( ObjectBlock objectBlock, dynamic instance )
        {
            if ( objectBlock == null ) return;
            CacheKey cacheKey;
            if ( !objectBlock.TryGetCacheKey( out cacheKey ) ) return;

            var modelBlock = objectBlock?.Model.Get<ModelBlock>( cacheKey );
            var renderBlock = modelBlock?.RenderModel.Get<RenderModelBlock>( cacheKey );

            if ( renderBlock == null ) return;

            var sections = renderBlock.Sections;

            foreach ( var renderModelSection in sections )
            {
                foreach ( var part in renderModelSection.SectionData.SelectMany( u => u.Section.Parts ) )
                {
                    //_drawManager.RemoveShader( part );
                    _drawManager.RemoveInstance( part, instance );
                }
            }
        }

        private Dictionary<PrimitiveType, IndirectDrawCommandBuffer> PrimitiveIndirectDrawBuffer { get; }=new Dictionary<PrimitiveType, IndirectDrawCommandBuffer>(); 

        /// <summary>
        ///     Draws each patch with an individual call.
        /// </summary>
        private void DrawPatchElements( IEnumerable<GlobalGeometryPartBlockNew> patches, TagGlobalKey shaderKey )
        {
            //var patchDatas = patches as GlobalGeometryPartBlockNew[] ?? patches.ToArray( );
            //var patchData = patchDatas.FirstOrDefault( );
            //if ( patchData == null ) return;
            //MaterialShader material = null;
            //if ( shaderKey.TagKey != TagIdent.NullIdentifier )
            //{
            //    material = _materialManager.GetMaterial( shaderKey );
            //}

            //Bucket bucket = null;
            //var cmdBuffer = new byte[DrawIndirectCmd.CmdSize * patchDatas.Length];
            //using (var binaryWriter = new BinaryWriter(new MemoryStream(cmdBuffer)))
            //    foreach ( var item in patchDatas )
            //    {
            //        if (
            //            !item.GlobalGeometryPartNewFlags.HasFlag( GlobalGeometryPartBlockNew.Flags.OverrideTriangleList ) )
            //        {
            //        }
            //        int vertexBaseIndex;
            //        int indexBaseOffset;
            //        var instanceInfo = InstancesBuffer[ item ];
            //        bucket = _bucketManager.GetBucketResource( item, out indexBaseOffset, out vertexBaseIndex );
            //        DrawIndirectCmd indirectCmd = new DrawIndirectCmd( item.StripLength, instanceInfo.Count,
            //           indexBaseOffset/2 + item.StripStartIndex, vertexBaseIndex, instanceInfo.BaseInstance );
            //        indirectCmd.Write( binaryWriter );
            //    }
            //if ( bucket == null ) return;

            //using ( material == null ? null : _materialManager.Bind( material ) )
            //{
            //    using (CurrentBucketVao == bucket.VertexArrayObject ? null : bucket.Bind())
            //    using (CurrentBucketVao == bucket.VertexArrayObject ? null : InstancesBuffer.Bind())
            //        GL.MultiDrawElementsIndirect( All.Triangles, All.UnsignedShort, IntPtr.Zero, patchDatas.Length,
            //        0 );
                //foreach ( var item in patchDatas )
                //{
                //    int vertexBaseIndex;
                //    int indexBaseOffset;
                //    var bucket = _bucketManager.GetBucketResource( item, out indexBaseOffset, out vertexBaseIndex );
                //    using ( CurrentBucketVao == bucket.VertexArrayObject ? null : bucket.Bind( ) )
                //    using ( CurrentBucketVao == bucket.VertexArrayObject ? null : InstancesBuffer.Bind( ) )
                //    {
                //        var primitiveType =
                //            item.GlobalGeometryPartNewFlags.HasFlag(
                //                GlobalGeometryPartBlockNew.Flags.OverrideTriangleList )
                //                ? PrimitiveType.Triangles
                //                : PrimitiveType.TriangleStrip;
                //        CurrentBucketVao = bucket.VertexArrayObject;
                //        GL.DrawElementsInstancedBaseVertexBaseInstance(
                //            primitiveType, item.StripLength, DrawElementsType.UnsignedShort,
                //            ( IntPtr ) ( indexBaseOffset + item.StripStartIndex * 2 ),
                //            InstancesBuffer[ item ].Count, vertexBaseIndex, InstancesBuffer[ item ].BaseInstance );
                //    }
                //}}
            //}
        }

        private void ForceItem( Camera eye, ObjectBlock @object, ScenarioInstanceBlock instance )
        {
            DrawManager.ClearVisible( );
            using ( _bucketManager.Begin( ) )
            {
                CacheKey key;
                if ( !@object.TryGetCacheKey( out key ) ) return;

                var modelBlock = @object?.Model.Get<ModelBlock>( key );
                var renderModel = modelBlock?.RenderModel.Get<RenderModelBlock>( key );

                if ( renderModel == null ) return;

                if ( eye.CanSee( instance, @object ) )
                {
                    Dispatch( eye, @object, instance );
                }
            }
        }

        /// <summary>
        ///     Calculates the DetailLevel
        /// </summary>
        /// <param name="modelBlock">ModelBlock to select detail level from</param>
        /// <param name="distance">Distance from viewer to object</param>
        /// <returns>DetailLevel value from Level1 to Level6</returns>
        private static DetailLevel GetDetailLevel( ModelBlock modelBlock, float distance )
        {
            if ( distance > modelBlock.ReduceToL1 ) return DetailLevel.Level1;
            if ( distance > modelBlock.ReduceToL2 ) return DetailLevel.Level2;
            if ( distance > modelBlock.ReduceToL3 ) return DetailLevel.Level3;
            if ( distance > modelBlock.ReduceToL4 ) return DetailLevel.Level4;
            return distance > modelBlock.ReduceToL5 ? DetailLevel.Level5 : DetailLevel.Level6;
        }

        /// <summary>
        ///     Returns the index of the section containing the permutation at a given level of detail
        /// </summary>
        /// <param name="permutation"></param>
        /// <param name="detailLevel"></param>
        /// <returns>Index of the section</returns>
        private static int GetSectionIndex( RenderModelPermutationBlock permutation, DetailLevel detailLevel )
        {
            switch ( detailLevel )
            {
                case DetailLevel.Level1:
                    return permutation.L1SectionIndex;
                case DetailLevel.Level2:
                    return permutation.L2SectionIndex;
                case DetailLevel.Level3:
                    return permutation.L3SectionIndex;
                case DetailLevel.Level4:
                    return permutation.L4SectionIndex;
                case DetailLevel.Level5:
                    return permutation.L5SectionIndex;
                case DetailLevel.Level6:
                    return permutation.L6SectionIndex;
                default:
                    throw new ArgumentOutOfRangeException( nameof( detailLevel ), detailLevel, null );
            }
        }

        /// <summary>
        ///     Loops through each instance and dispatches them for processing
        /// </summary>
        private void ProcessPalette( Camera eye, CacheKey key, IEnumerable<IH2ObjectInstance> instanceCollection,
            IReadOnlyList<IH2ObjectPalette> paletteCollection )
        {
            foreach ( var instance in instanceCollection )
            {
                var paletteIndex = instance.PaletteIndex;

                var objectBlock = paletteCollection[ paletteIndex ].ObjectReference.Get<ObjectBlock>( key );
                var modelBlock = objectBlock?.Model.Get<ModelBlock>( key );
                var renderModel = modelBlock?.RenderModel.Get<RenderModelBlock>( key );

                if ( renderModel == null ) continue;

                if ( eye.CanSee( instance, objectBlock ) )
                {
                    Dispatch( eye, objectBlock, instance );
                }
            }
        }

        private static RenderModelSectionBlock[] ProcessRegions(
            IReadOnlyCollection<ModelRegionBlock> modelRegionBlock, RenderModelBlock renderBlock,
            DetailLevel detailLevel )
        {
            var regionNames = new List<StringIdent>( modelRegionBlock.Count );
            foreach ( var region in modelRegionBlock )
            {
                regionNames.Add( region.Name );
            }
            var sectionIndices = SelectRenderModelSections( renderBlock, regionNames, null, detailLevel );

            var blocks = new RenderModelSectionBlock[sectionIndices.Length];
            for ( var i = 0; i < blocks.Length; ++i )
            {
                blocks[ i ] = renderBlock.Sections[ sectionIndices[ i ] ];
            }
            return blocks;
        }

        private static RenderModelSectionBlock[] ProcessVariant( ModelVariantBlock variantBlock,
            RenderModelBlock renderBlock, DetailLevel detailLevel )
        {
            var regionNames = new List<StringIdent>( variantBlock.Regions.Length );
            var permutationNames = new List<StringIdent>( variantBlock.Regions.Length );
            foreach ( var region in variantBlock.Regions )
            {
                regionNames.Add( region.RegionName );
                permutationNames.Add( region.Permutations.FirstOrDefault( )?.PermutationName ?? StringIdent.Zero );
            }
            var sectionIndices = SelectRenderModelSections( renderBlock, regionNames, permutationNames, detailLevel );
            return renderBlock.Sections.Where( ( e, i ) => sectionIndices.Contains( i ) ).ToArray( );
        }

        /// <summary>
        ///     Returns array of indices of sections containing each region at a given level of detail
        /// </summary>
        /// <param name="renderBlock">Where the regions are located</param>
        /// <param name="regionNames">A list of names for each region to return</param>
        /// <param name="permutationNames"></param>
        /// <param name="detailLevel">The detail level of mesh to return</param>
        private static int[] SelectRenderModelSections( RenderModelBlock renderBlock,
            List<StringIdent> regionNames, IReadOnlyList<StringIdent> permutationNames, DetailLevel detailLevel )
        {
            var indices = new int[renderBlock.Regions.Length];
            var index = 0;
            foreach ( var region in renderBlock.Regions )
            {
                if ( regionNames.BinarySearch( region.Name ) < 0 )
                    continue;

                var sectionIndex =
                    GetSectionIndex(
                        permutationNames == null
                            ? region.Permutations[ 0 ]
                            : region.Permutations.SingleOrDefault( u => u.Name == permutationNames[ 0 ] ) ??
                              region.Permutations[ 0 ], detailLevel );
                indices[ index++ ] = sectionIndex;
            }
            return indices.TakeSubset( 0, index ).ToArray( );
        }

        /// <summary>
        ///     Walks the scenario tree and render all renderable parts
        /// </summary>
        private void TraverseScenario( Camera eyeCamera, ScenarioBlock scenarioBlock )
        {
            if ( scenarioBlock == null ) return;
            CacheKey cachekey;
            if ( !scenarioBlock.TryGetCacheKey( out cachekey ) ) return;
            DrawManager.ClearVisible( );
            using ( _bucketManager.Begin( ) )
            {
                ProcessPalette(eyeCamera, cachekey, scenarioBlock.Scenery, scenarioBlock.SceneryPalette);
                ProcessPalette(eyeCamera, cachekey, scenarioBlock.Crates, scenarioBlock.CratesPalette);
                ProcessPalette(eyeCamera, cachekey, scenarioBlock.Vehicles, scenarioBlock.VehiclePalette);
                ProcessPalette(eyeCamera, cachekey, scenarioBlock.Weapons, scenarioBlock.WeaponPalette);

                ProcessStructure( eyeCamera, cachekey, scenarioBlock.StructureBSPs[ 0 ] );
            }
        }

        private void ProcessStructure( Camera eyeCamera, CacheKey cachekey, ScenarioStructureBspReferenceBlock structureBsP )
        {
            var levelData = (ScenarioStructureBspBlock)structureBsP.StructureBSP.Get( cachekey );
            if ( levelData == null ) return;

            Dispatch( eyeCamera, levelData, cachekey );

        }
    };
}