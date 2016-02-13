using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Moonfish.Cache;
using Moonfish.Guerilla;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;
using OpenTK;
using OpenTK.Graphics.OpenGL4;

namespace Moonfish.Graphics
{
    public class ScenarioManager
    {
        private readonly NewBucketManager _bucketManager;
        private static DrawManager _drawManager;

        private readonly Dictionary<int, List<DrawCommand>> _levelGeometryDrawCommands =
            new Dictionary<int, List<DrawCommand>>( );

        private CacheStream _cache;

        public ScenarioManager( )
        {
            _drawManager = new DrawManager(  );
            _bucketManager = new NewBucketManager( );
        }

        public void Draw( Camera eyeCamera, ProgramManager programManager )
        {
            var program = programManager.DebugShader;
            program.Assign( );
            TraverseSceenario( eyeCamera );

            var transparentPatches = _drawManager.GetTransparentParts( eyeCamera );
            var renderPatches = _drawManager.GetOpaqueParts( eyeCamera );

            Draw(transparentPatches, program);
            Draw( renderPatches, program );
        }

        private void Draw( IEnumerable<RenderPatch> patches, Program program )
        {
            foreach ( var patch in patches )
            {
                var location = program.GetUniformLocation( "WorldMatrixUniform" );
                program.SetUniform( location, patch.Data.worldMatrix );
                int vertexBaseIndex;
                int indexBaseOffset;
                var bucket = _bucketManager.GetBucketResource( patch.Part, out indexBaseOffset, out vertexBaseIndex );
                using ( bucket.Bind( ) )
                {
                    GL.DrawElementsBaseVertex(
                        PrimitiveType.TriangleStrip, patch.Part.StripLength, DrawElementsType.UnsignedShort,
                        ( IntPtr ) (indexBaseOffset + patch.Part.StripStartIndex * 2), vertexBaseIndex );
                }
                GL.Finish(  );
            }
        }

        public List<DrawCommand> GetLevelGeometryDrawCommands( int sbspIndex = 0 )
        {
            ////  cache and return commands since they shouldn't change
            //if ( _levelGeometryDrawCommands.ContainsKey( sbspIndex ) ) return _levelGeometryDrawCommands[ sbspIndex ];

            //var scenarioBlock = _cache.Index.ScenarioIdent.Get<ScenarioBlock>( );

            //var scenarioStructureBspReferenceBlock = scenarioBlock.StructureBSPs[ sbspIndex ];
            //var scenarioStructureBspBlock =
            //    scenarioStructureBspReferenceBlock.StructureBSP.Get<ScenarioStructureBspBlock>( );

            //var drawCommands = new List<DrawCommand>( );
            //foreach ( var structureBspClusterBlock in scenarioStructureBspBlock.Clusters )
            //{
            //    drawCommands.AddRange( _bucketManager.GetDrawCommands( structureBspClusterBlock.ClusterData[ 0 ].Section ) );
            //}

            //drawCommands = new List<DrawCommand>( Optimize( drawCommands ) );

            //foreach ( var item in scenarioStructureBspBlock.InstancedGeometriesDefinitions )
            //{
            //    drawCommands.AddRange( _bucketManager.GetDrawCommands( item.RenderInfo.RenderData[ 0 ].Section ) );
            //}
            //_levelGeometryDrawCommands[ sbspIndex ] = drawCommands;
            //return _levelGeometryDrawCommands[ sbspIndex ];
            return new List<DrawCommand>();
        }
        
        public void Load( CacheStream cache, int sbspIndex = 0 )
        {
            _cache = cache;

            var scenarioBlock = cache.Index.ScenarioIdent.Get<ScenarioBlock>( );

            var scenarioStructureBspReferenceBlock = scenarioBlock.StructureBSPs[ sbspIndex ];
            var scenarioStructureBspBlock =
                scenarioStructureBspReferenceBlock.StructureBSP.Get<ScenarioStructureBspBlock>( );

            // Load Level Geometry
            LoadLevelGeometry( scenarioStructureBspBlock );
        }

        /// <summary>
        ///     Buffers array data and creates draw commands as needed
        /// </summary>
        /// <param name="eyeCamera"></param>
        /// <param name="objectBlock"></param>
        /// <param name="instance"></param>
        private void Dispatch( Camera eyeCamera, ObjectBlock objectBlock,
            ScenarioSceneryBlock instance )
        {
            var modelBlock = objectBlock.Model.Get<ModelBlock>( );
            var renderBlock = modelBlock?.RenderModel.Get<RenderModelBlock>( );

            if ( renderBlock == null ) return;

            NewBucketManager.UnpackVertexData( renderBlock );

            // TODO use bounding offset and bounding radius here x
            var distance = eyeCamera.DistanceOf( instance.ObjectData.Position );
            var detailLevel = GetDetailLevel( modelBlock, distance );

            var instanceVariant = instance.PermutationData.VariantName;
            var defaultModelVariant = objectBlock.DefaultModelVariant;

            //  Select the instance variant if it exists, else select the default variant if it exists, 
            //  else default to zero
            var variant = instanceVariant == StringIdent.Zero
                ? defaultModelVariant == StringIdent.Zero ? StringIdent.Zero : defaultModelVariant
                : instanceVariant;

            var hasVariant = variant != StringIdent.Zero;
            var hasRegions = modelBlock.ModelRegionBlock.Length > 0;

            //  Here sections are collected using the detail level and chosen variant (if it exists)
            var sections = Enumerable.Empty<RenderModelSectionBlock>( );
            if ( hasVariant )
            {
                var variantBlock = modelBlock.Variants.Single( e => e.Name == variant );
                sections = DrawVariant( variantBlock, renderBlock, detailLevel );
            }
            else if ( hasRegions )
            {
                sections = DrawRegions( modelBlock.ModelRegionBlock, renderBlock, detailLevel );
            }
            var renderModelSectionBlocks = sections as RenderModelSectionBlock[] ?? sections.ToArray( );

            //  Loop through all the sections and load the vertex data if needed and pass the part along 
            //  to the draw manager to  handle sorting and grouping
            foreach ( var renderModelSection in renderModelSectionBlocks )
            {
                _bucketManager.BufferPartData( renderModelSection.SectionData[ 0 ].Section );

                foreach ( var part in renderModelSection.SectionData[ 0 ].Section.Parts )
                {
                    _drawManager.CreateInstance( part, instance );
                }
            }
        }

        private static IEnumerable<RenderModelSectionBlock> DrawRegions(
            IReadOnlyCollection<ModelRegionBlock> modelRegionBlock, RenderModelBlock renderBlock,
            DetailLevel detailLevel )
        {
            var regionNames = new List<StringIdent>( modelRegionBlock.Count );
            foreach ( var region in modelRegionBlock )
            {
                regionNames.Add( region.Name );
            }
            var sectionIndices = SelectRenderModelSections( renderBlock, regionNames, null, detailLevel );
            return renderBlock.Sections.Where( ( e, i ) => sectionIndices.Contains( i ) );
        }

        private static IEnumerable<RenderModelSectionBlock> DrawVariant( ModelVariantBlock variantBlock,
            RenderModelBlock renderBlock, DetailLevel detailLevel )
        {
            var regionNames = new List<StringIdent>(variantBlock.Regions.Length);
            var permutationNames = new List<StringIdent>(variantBlock.Regions.Length);
            foreach ( var region in variantBlock.Regions )
            {
                regionNames.Add( region.RegionName );
                permutationNames.Add( region.Permutations.SingleOrDefault( )?.PermutationName ?? StringIdent.Zero );
            }
            var sectionIndices = SelectRenderModelSections( renderBlock, regionNames, permutationNames, detailLevel );
            return renderBlock.Sections.Where( ( e, i ) => sectionIndices.Contains( i ) );
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

        private void LoadLevelGeometry( ScenarioStructureBspBlock structureBsp )
        {
            //using ( _bucketManager.BeginBucket( ) )
            //{
            //    foreach ( var structureBspClusterBlock in structureBsp.Clusters )
            //    {
            //        structureBspClusterBlock.LoadClusterData( );
            //        BucketManager.UnpackLightingData( structureBspClusterBlock.ClusterData[ 0 ].Section );
            //    }

            //    _bucketManager.QueueSectionData( structureBsp.Clusters.Select( e => e.ClusterData[ 0 ].Section ) );
            //}

            //using ( _bucketManager.BeginBucket( ) )
            //{
            //    for ( var index = 0; index < structureBsp.InstancedGeometriesDefinitions.Length; index++ )
            //    {
            //        var item = structureBsp.InstancedGeometriesDefinitions[ index ];
            //        var index1 = index;
            //        var items =
            //            structureBsp.InstancedGeometryInstances.Where( e => e.InstanceDefinition == index1 )
            //                .Select( e => e.WorldMatrix )
            //                .ToList( );
            //        item.RenderInfo.LoadRenderData( );
            //        BucketManager.UnpackLightingData( item.RenderInfo.RenderData[ 0 ].Section );
            //        _bucketManager.QueueSectionData( new[] {item.RenderInfo.RenderData[ 0 ].Section} );
            //        _bucketManager.QueueInstanceData( new[] {item.RenderInfo.RenderData[ 0 ].Section}, items );
            //    }
            //}
        }

        /// <summary>
        ///     Returns array of indices of sections containing each region at a given level of detail
        /// </summary>
        /// <param name="renderBlock">Where the regions are located</param>
        /// <param name="regionNames">A list of names for each region to return</param>
        /// <param name="permutationNames"></param>
        /// <param name="detailLevel">The detail level of mesh to return</param>
        private static int[] SelectRenderModelSections( RenderModelBlock renderBlock, List<StringIdent> regionNames, List<StringIdent> permutationNames, DetailLevel detailLevel )
        {
            var renderModelRegionBlocks = renderBlock.Regions.Where( u => regionNames.Contains( u.Name ) ).ToArray( );
            var sectionIndices = new int[renderModelRegionBlocks.Length];
            for ( var index = 0; index < renderModelRegionBlocks.Length; index++ )
            {
                var region = renderModelRegionBlocks[ index ];
                var sectionIndex =
                    GetSectionIndex(
                        permutationNames == null
                            ? region.Permutations[ 0 ]
                            : region.Permutations.Single( u => u.Name == permutationNames[ index ] ), detailLevel );
                sectionIndices[ index ] = sectionIndex;
            }
            return sectionIndices;
        }

        /// <summary>
        /// Walks the scenario tree and render all renderable parts
        /// </summary>
        /// <param name="eyeCamera"></param>
        private void TraverseSceenario( Camera eyeCamera )
        {
            var scenarioBlock = _cache.Index.ScenarioIdent.Get<ScenarioBlock>( );

            DrawManager.ClearVisable( );
            using ( _bucketManager.Begin( ) )
            {
                foreach ( var instance in scenarioBlock.Scenery )
                {
                    var palette = instance.Type;

                    var objectBlock = scenarioBlock.SceneryPalette[ palette ].Name.Get<ObjectBlock>( );
                    var modelBlock = objectBlock?.Model.Get<ModelBlock>( );
                    var renderModel = modelBlock?.RenderModel.Get<RenderModelBlock>( );

                    if ( renderModel == null ) continue;

                    if ( !eyeCamera.CanSee( instance, objectBlock ) ) continue;

                    Dispatch( eyeCamera, objectBlock, instance );
                }
            }
        }

        private class DrawManager
        {
            private InstanceId _currentInstanceId;

            private readonly Dictionary<InstanceId, InstanceData> _instanceDataDictionary =
                new Dictionary<InstanceId, InstanceData>( );

            private readonly Dictionary<GuerillaBlock, InstanceId> _instanceDictionary =
                new Dictionary<GuerillaBlock, InstanceId>( );
            
            private readonly Dictionary<GlobalGeometryPartBlockNew, List<InstanceId>> _partDictionary =
                new Dictionary<GlobalGeometryPartBlockNew, List<InstanceId>>( );

            private static readonly Comparer<float> Comparer = Comparer<float>.Create( ( a, b ) => a <= b? 1 : -1 );

            public void CreateInstance( GlobalGeometryPartBlockNew part, ScenarioSceneryBlock instance )
            {
                if ( !_partDictionary.ContainsKey( part ) )
                {
                    _partDictionary.Add( part, new List<InstanceId>( ) );
                }

                if ( !_instanceDictionary.ContainsKey( instance ) )
                {
                    _instanceDictionary.Add( instance, _currentInstanceId );
                    _instanceDataDictionary.Add( CreateInstanceId( ), new InstanceData( instance ) );
                }

                var instanceId = _instanceDictionary[ instance ];
                if ( !_partDictionary[ part ].Contains( instanceId ) )
                {
                    _partDictionary[ part ].Add( instanceId );
                }
            }

            public IEnumerable<RenderPatch> GetTransparentParts( Camera eye )
            {
                var transparentParts = _partDictionary.Where( e => e.Key.Type == GlobalGeometryPartBlockNew.TypeEnum.Transparent );
                return  SortTransparentParts( transparentParts, eye);
            }

            public IEnumerable<RenderPatch> GetOpaqueParts(Camera eye)
            {
                var patches =
                    _partDictionary.Where(
                        e =>
                            e.Key.Type == GlobalGeometryPartBlockNew.TypeEnum.OpaqueShadowCasting ||
                            e.Key.Type == GlobalGeometryPartBlockNew.TypeEnum.OpaqueShadowOnly ||
                            e.Key.Type == GlobalGeometryPartBlockNew.TypeEnum.OpaqueNonshadowing );
                var opaquePatches = new List<RenderPatch>( );
                foreach ( var pair in patches )
                {
                    foreach ( var instanceId in pair.Value )
                    {
                        var instanceData = _instanceDataDictionary[ instanceId ];
                        opaquePatches.Add( new RenderPatch( pair.Key, instanceData ) );
                    }
                }
                return opaquePatches;
            }

            /// <summary>
            /// Returns a sorted collection of DrawStubs
            /// </summary>
            /// <param name="transparentPartDictionary"></param>
            /// <param name="eye"></param>
            /// <returns></returns>
            private IEnumerable<RenderPatch> SortTransparentParts(
                IEnumerable<KeyValuePair<GlobalGeometryPartBlockNew, List<InstanceId>>> transparentPartDictionary,
                Camera eye )
            {
                var keyValuePairs =
                    transparentPartDictionary as IList<KeyValuePair<GlobalGeometryPartBlockNew, List<InstanceId>>> ??
                    transparentPartDictionary.ToList( );
                
                var capacity = keyValuePairs.Sum( u => u.Value.Count );

                var transparentDrawsSortedList =
                    new SortedList<float, RenderPatch>( capacity, Comparer );

                foreach ( var item in keyValuePairs )
                {
                    var part = item.Key;
                    var instances = item.Value;
                    foreach ( var id in instances )
                    {
                        var instanceData = _instanceDataDictionary[ id ];
                        Vector3 scenePosition;
                        Vector3.TransformPosition( ref part.Position, ref instanceData.worldMatrix,
                            out scenePosition );

                        // Reverse the sorting here with negation
                        var distance = eye.DistanceOf( scenePosition );

                        transparentDrawsSortedList.Add( distance, new RenderPatch( part, instanceData ) );
                    }
                }
                return transparentDrawsSortedList.Select( u=>u.Value );
            }

            private InstanceId CreateInstanceId( )
            {
                return _currentInstanceId++;
            }

            private struct InstanceId
            {
                private int _id;

                public override int GetHashCode( )
                {
                    return _id.GetHashCode( );
                }

                public static InstanceId operator ++( InstanceId instanceId )
                {
                    instanceId._id++;
                    return instanceId;
                }
            }

            public static void ClearVisable( )
            {
                //TODO implement filtering here
            }
        }
    };

    internal class RenderPatch
    {
        public GlobalGeometryPartBlockNew Part { get; }
        public InstanceData Data { get; }

        public RenderPatch( GlobalGeometryPartBlockNew part, InstanceData data )
        {
            Part = part;
            Data = data;
        }
    }

    internal struct InstanceData
    {
        private Vector4 Colour;
        public Matrix4 worldMatrix;

        public InstanceData( ScenarioSceneryBlock sceneryInstance )
        {
            // RGBA format
            Colour = new Vector4(
                sceneryInstance.PermutationData.PrimaryColor.R / 255f,
                sceneryInstance.PermutationData.PrimaryColor.G / 255f,
                sceneryInstance.PermutationData.PrimaryColor.B / 255f,
                1.0f );
            worldMatrix = sceneryInstance.ObjectData.CreateWorldMatrix( );
        }
    }
}