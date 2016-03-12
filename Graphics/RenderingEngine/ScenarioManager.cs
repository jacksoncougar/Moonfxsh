using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Moonfish.Cache;
using Moonfish.Graphics.RenderingEngine;
using Moonfish.Guerilla;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;
using OpenTK;
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

        /// <summary>
        ///     The cache where scenario data is
        /// </summary>
        private CacheStream _cache;
#if DEBUG
        private static readonly ScenarioInstanceBlock instance = new ScenarioInstanceBlock(  );
        private static ObjectBlock ObjectBlock;
#endif 

        public ScenarioManager( )
        {
            _materialManager = new MaterialManager(  );
               _drawManager = new DrawManager( );
            _bucketManager = new BucketManager( );
        }
        
        [Conditional("DEBUG")]
        public void DebugDraw( Camera eye, ProgramManager programManager )
        {
            if ( ObjectBlock == null )
                return;
            

            var program = programManager.DebugShader;
            program.Assign( );
            
            ForceItem( eye, ObjectBlock, instance );

            var transparentPatches = _drawManager.GetTransparentParts( eye );
            var renderPatches = _drawManager.GetOpaqueParts( );

            // TODO better batching!
            DrawPatchElements( transparentPatches, program );
            DrawPatchElements( renderPatches, program );
        }

        /// <summary>
        ///     Walks the scenario and draws all objects with their current state
        /// </summary>
        /// <param name="eye">The viewer camera</param>
        /// <param name="programManager"></param>
        public void DrawScenario( Camera eye, ProgramManager programManager )
        {
            var program = programManager.DebugShader;
            program.Assign( );

            TraverseScenario( eye );

            var transparentPatches = _drawManager.GetTransparentParts( eye );
            var renderPatches = _drawManager.GetOpaqueParts( );

            // TODO better batching!
            DrawPatchElements( transparentPatches, program );
            DrawPatchElements( renderPatches, program );
        }

        /// <summary>
        ///     Loads scenario from Cache
        /// </summary>
        /// <param name="cacheStream"></param>
        public void Load( CacheStream cacheStream )
        {
            _cache = cacheStream;
        }

        /// <summary>
        ///     Buffers array data and creates draw commands as needed for a given object
        /// </summary>
        /// <param name="eye">Viewer camera used to select detail level</param>
        /// <param name="objectBlock">Object to draw</param>
        /// <param name="instance">Instance data of object to draw</param>
        private void Dispatch( Camera eye, ObjectBlock objectBlock,
            dynamic instance )
        {
            var modelBlock = objectBlock.Model.Get<ModelBlock>( );
            var renderBlock = modelBlock?.RenderModel.Get<RenderModelBlock>( );

            if ( renderBlock == null ) return;

            BucketManager.UnpackVertexData( renderBlock );

            // TODO use bounding offset and bounding radius here x
            var distance = eye.DistanceOf( instance.ObjectData.Position );
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
                sections = ProcessVariant( variantBlock, renderBlock, detailLevel );
            }
            else if ( hasRegions )
            {
                sections = ProcessRegions( modelBlock.ModelRegionBlock, renderBlock, detailLevel );
            }
            var renderModelSectionBlocks = sections as RenderModelSectionBlock[] ?? sections.ToArray( );

            //  Loop through all the sections and load the vertex data if needed and pass the part along 
            //  to the draw manager to  handle sorting and grouping
            foreach ( var renderModelSection in renderModelSectionBlocks )
            {
                _bucketManager.BufferPartData( renderModelSection.SectionData[ 0 ].Section );

                foreach ( var part in renderModelSection.SectionData[ 0 ].Section.Parts )
                {
                    var materialBlock = renderBlock.Materials[part.Material];

                    //  Create an instance for this part and assign a shader for it
                    _drawManager.CreateInstance(part, instance);
                    _drawManager.AssignShader(part, materialBlock.Shader.Ident);
                }
            }
        }

        public void DispatchDeletion( ObjectBlock objectBlock, dynamic instance )
        {
            var modelBlock = objectBlock?.Model.Get<ModelBlock>( );
            var renderBlock = modelBlock?.RenderModel.Get<RenderModelBlock>( );

            if ( renderBlock == null ) return;

            var sections = renderBlock.Sections;

            foreach ( var renderModelSection in sections )
            {
                foreach ( var part in renderModelSection.SectionData[ 0 ].Section.Parts )
                {
                    _drawManager.RemoveInstance( part, instance );
                }
            }
        }

        /// <summary>
        ///     Draws each patch with an individual call.
        /// </summary>
        /// <param name="patches">Patches to draw</param>
        /// <param name="program">Program to shad patches with</param>
        private void DrawPatchElements( IEnumerable<PatchData> patches, Program program )
        {
            foreach ( var patch in patches )
            {
                var location = program.GetUniformLocation( "WorldMatrixUniform" );
                program.SetUniform( location, patch.Data.worldMatrix );
                int vertexBaseIndex;
                int indexBaseOffset;
                

                var bucket = _bucketManager.GetBucketResource( patch.Part, out indexBaseOffset, out vertexBaseIndex );
                if ( patch.ShaderIdent != TagIdent.NullIdentifier )
                {
                    var material = _materialManager.GetMaterial( patch.ShaderIdent );
                    _materialManager.Bind( material );
                }
                using ( bucket.Bind( ) )
                {
                    GL.DrawElementsBaseVertex(
                        PrimitiveType.TriangleStrip, patch.Part.StripLength, DrawElementsType.UnsignedShort,
                        ( IntPtr ) ( indexBaseOffset + patch.Part.StripStartIndex * 2 ), vertexBaseIndex );
                }
            }
        }

        private void DispatchMaterial( TagIdent shaderIdent )
        {
            
        }

        private void ForceItem( Camera eye, ObjectBlock @object, ScenarioInstanceBlock instance )
        {
            var scenarioBlock = _cache?.Index.ScenarioIdent.Get<ScenarioBlock>( );
            if ( scenarioBlock == null ) return;

            DrawManager.ClearVisible( );
            using ( _bucketManager.Begin( ) )
            {
                var modelBlock = @object?.Model.Get<ModelBlock>( );
                var renderModel = modelBlock?.RenderModel.Get<RenderModelBlock>( );

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
        /// <param name="eye">Viewer camera</param>
        /// <param name="instanceCollection">Only pass valid scenario instance block array</param>
        /// <param name="paletteCollection">Only pass valid scenario palette block array</param>
        private void ProcessPalette( Camera eye, dynamic instanceCollection, dynamic paletteCollection )
        {
            foreach ( var instance in instanceCollection )
            {
                var paletteIndex = instance.Type;

                var objectBlock = paletteCollection[ paletteIndex ].Name.Get<ObjectBlock>( );
                var modelBlock = objectBlock?.Model.Get<ModelBlock>( );
                var renderModel = modelBlock?.RenderModel.Get<RenderModelBlock>( );

                if ( renderModel == null ) continue;

                if ( eye.CanSee( instance, objectBlock ) )
                {
                    Dispatch( eye, objectBlock, instance );
                }
            }
        }

        private static IEnumerable<RenderModelSectionBlock> ProcessRegions(
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

        private static IEnumerable<RenderModelSectionBlock> ProcessVariant( ModelVariantBlock variantBlock,
            RenderModelBlock renderBlock, DetailLevel detailLevel )
        {
            var regionNames = new List<StringIdent>( variantBlock.Regions.Length );
            var permutationNames = new List<StringIdent>( variantBlock.Regions.Length );
            foreach ( var region in variantBlock.Regions )
            {
                regionNames.Add( region.RegionName );
                permutationNames.Add( region.Permutations.SingleOrDefault( )?.PermutationName ?? StringIdent.Zero );
            }
            var sectionIndices = SelectRenderModelSections( renderBlock, regionNames, permutationNames, detailLevel );
            return renderBlock.Sections.Where( ( e, i ) => sectionIndices.Contains( i ) );
        }

        /// <summary>
        ///     Returns array of indices of sections containing each region at a given level of detail
        /// </summary>
        /// <param name="renderBlock">Where the regions are located</param>
        /// <param name="regionNames">A list of names for each region to return</param>
        /// <param name="permutationNames"></param>
        /// <param name="detailLevel">The detail level of mesh to return</param>
        private static IEnumerable<int> SelectRenderModelSections( RenderModelBlock renderBlock,
            List<StringIdent> regionNames, IReadOnlyList<StringIdent> permutationNames, DetailLevel detailLevel )
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
        ///     Walks the scenario tree and render all renderable parts
        /// </summary>
        /// <param name="eyeCamera"></param>
        private void TraverseScenario( Camera eyeCamera )
        {
            var scenarioBlock = _cache?.Index.ScenarioIdent.Get<ScenarioBlock>( );
            if ( scenarioBlock == null ) return;

            DrawManager.ClearVisible( );
            using ( _bucketManager.Begin( ) )
            {
                ProcessPalette( eyeCamera, scenarioBlock.Scenery, scenarioBlock.SceneryPalette );
                ProcessPalette( eyeCamera, scenarioBlock.Crates, scenarioBlock.CratesPalette );
                ProcessPalette( eyeCamera, scenarioBlock.Bipeds, scenarioBlock.BipedPalette );
                ProcessPalette( eyeCamera, scenarioBlock.Creatures, scenarioBlock.CreaturesPalette );
                ProcessPalette( eyeCamera, scenarioBlock.Controls, scenarioBlock.ControlPalette );
                ProcessPalette( eyeCamera, scenarioBlock.Decals, scenarioBlock.DecalsPalette );
                ProcessPalette( eyeCamera, scenarioBlock.Decorators, scenarioBlock.DecoratorsPalette );
                ProcessPalette( eyeCamera, scenarioBlock.Machines, scenarioBlock.MachinePalette );
                ProcessPalette( eyeCamera, scenarioBlock.Equipment, scenarioBlock.EquipmentPalette );
                ProcessPalette( eyeCamera, scenarioBlock.SoundScenery, scenarioBlock.SoundSceneryPalette );
                ProcessPalette( eyeCamera, scenarioBlock.Vehicles, scenarioBlock.VehiclePalette );
                ProcessPalette( eyeCamera, scenarioBlock.Weapons, scenarioBlock.WeaponPalette );
            }
        }

        /// <summary>
        ///     A defuault instance wrapper
        /// </summary>
        public class ScenarioInstanceBlock : GuerillaBlock
        {
            private byte[] indexer = new byte[4];
            public ScenarioObjectDatumStructBlock ObjectData = new ScenarioObjectDatumStructBlock( );
            public ScenarioObjectPermutationStructBlock PermutationData = new ScenarioObjectPermutationStructBlock( );
            public ScenarioSceneryDatumStructV4Block SceneryData = new ScenarioSceneryDatumStructV4Block( );
            public override int Alignment { get; }
            public override int SerializedSize { get; }
        }

        /// <summary>
        ///     Sorts render calls into optimized batches
        /// </summary>
        private class DrawManager
        {
            /// <summary>
            ///     Clears all parts currently marked as visible ( Call this at the start of a frame )
            /// </summary>
            public static void ClearVisible( )
            {
                //TODO implement filtering here
            }

            private InstanceManager InstanceManager { get; set; } = new InstanceManager(  );

            /// <summary>
            ///     Creates an instance object for the given part
            /// </summary>
            /// <param name="part">The part to be instanced</param>
            /// <param name="instance">The instance data</param>
            public void CreateInstance( GlobalGeometryPartBlockNew part, dynamic instance )
            {
                InstanceManager.CreateInstance( part, instance );
            }

            public void RemoveInstance( GlobalGeometryPartBlockNew part, dynamic instance )
            {
                InstanceManager.RemoveInstance( part, instance );
            }

            /// <summary>
            ///     Returns all Opaque* type parts
            /// </summary>
            /// <returns>A sequence of patch data</returns>
            public IEnumerable<PatchData> GetOpaqueParts( )
            {
                var opaqueParts = InstanceManager.Parts.Where(
                    e =>
                        e.Type == GlobalGeometryPartBlockNew.TypeEnum.OpaqueShadowCasting ||
                        e.Type == GlobalGeometryPartBlockNew.TypeEnum.OpaqueShadowOnly ||
                        e.Type == GlobalGeometryPartBlockNew.TypeEnum.OpaqueNonshadowing );
                var patches = new List<PatchData>( );
                foreach ( var part in opaqueParts )
                {
                    foreach ( var instance in InstanceManager.GetInstancesOf( part ) )
                    {
                        patches.Add( new PatchData( part, instance )
                        {
                            ShaderIdent = _shaderDictionary[ part ]
                        } );
                    }
                }
                return patches;
            }

            /// <summary>
            ///     Returns all Transparent type parts
            /// </summary>
            /// <param name="eye">The viewer used for depth sorting</param>
            /// <returns>A sequence of patch data</returns>
            public IEnumerable<PatchData> GetTransparentParts( Camera eye )
            {
                var transparentParts =
                    InstanceManager.Parts.Where( e => e.Type == GlobalGeometryPartBlockNew.TypeEnum.Transparent )
                        .ToList( );
                return SortTransparentParts( transparentParts, eye );
            }

            /// <summary>
            ///     Returns a sorted collection of DrawStubs
            /// </summary>
            /// <param name="transparentParts"></param>
            /// <param name="eye"></param>
            /// <returns></returns>
            private IEnumerable<PatchData> SortTransparentParts(
                ICollection<GlobalGeometryPartBlockNew> transparentParts,
                Camera eye )
            {

                var capacity = transparentParts.Sum( u => InstanceManager.GetInstanceCount( u ) );

                var transparentDrawsSortedList =
                    new SortedList<float, PatchData>( capacity, DistanceComparer );

                foreach ( var part in transparentParts )
                {
                    foreach ( var instance in InstanceManager.GetInstancesOf( part ) )
                    {
                        var scenePosition = Vector3.TransformPosition( part.Position, instance.worldMatrix );

                        var distance = eye.DistanceOf( scenePosition );

                        transparentDrawsSortedList.Add( distance, new PatchData( part, instance )
                        {
                            ShaderIdent = _shaderDictionary[ part ]
                        } );
                    }
                }
                return transparentDrawsSortedList.Select( u => u.Value );
            }


            private static readonly Comparer<float> DistanceComparer = Comparer<float>.Create( ( a, b ) => a <= b ? 1 : -1 );

            private readonly Dictionary<GlobalGeometryPartBlockNew, TagIdent> _shaderDictionary =
                new Dictionary<GlobalGeometryPartBlockNew, TagIdent>();
            

            public void AssignShader( GlobalGeometryPartBlockNew part, TagIdent shaderIdent )
            {
                //  Does this work now?
                _shaderDictionary[ part ] = shaderIdent;
            }
        }

        public void Load( ObjectBlock objectBlock)
        {
            if ( objectBlock == null || ObjectBlock == objectBlock) return;
            DispatchDeletion( ObjectBlock, instance );
            ObjectBlock = objectBlock;
        }

    };
}