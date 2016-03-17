using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
#if DEBUG
        private static ObjectBlock ObjectBlock;
#endif

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

        public ScenarioManager( )
        {
            _materialManager = new MaterialManager( );
            _drawManager = new DrawManager( );
            _bucketManager = new BucketManager( );
        }

        private List<ObjectBlock> StaticObjects { get; } = new List<ObjectBlock>( );

        [Conditional( "DEBUG" )]
        public void DebugDraw( Camera eye, ProgramManager programManager )
        {
            if ( ObjectBlock == null )
                return;

            foreach ( var staticObject in StaticObjects )
            {
                ForceItem( eye, staticObject, new ScenarioInstanceBlock( ) );
            }
            ForceItem( eye, ObjectBlock, new ScenarioInstanceBlock( ) );

            var program = programManager.DebugShader;
            program.Assign( );
            // TODO better batching!
            var transparentPatches = _drawManager.GetTransparentParts( eye );
            DrawPatchElements( transparentPatches, program );

            foreach ( var shaderIdent in _drawManager.GetShaders( ) )
            {
                var shader = ( ShaderBlock ) shaderIdent.Get( );
                if ( shader.GetType( ) == typeof ( MoonfishScreenSpaceShader ) )
                    program = programManager.ScreenProgram;
                else program = programManager.DebugShader;

                program.Assign( );
                var renderPatches = _drawManager.GetOpaqueParts( shaderIdent );
                DrawPatchElements( renderPatches, program );
            }
        }

        private void DispatchDeletion( ObjectBlock objectBlock, dynamic instance )
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

        public void Load( ObjectBlock objectBlock )
        {
            if ( objectBlock == null || ObjectBlock == objectBlock ) return;
            DispatchDeletion( ObjectBlock, new ScenarioInstanceBlock( ) );
            ObjectBlock = objectBlock;
        }

        public void Load( TagReference reference )
        {
            if ( reference.Class == TagClass.Bitm )
            {
                foreach ( var staticObject in StaticObjects )
                {
                    DispatchDeletion(staticObject, new ScenarioInstanceBlock());
                }
                StaticObjects.Clear(  );
                var billboardObject = new BillboardObject(reference.Ident);
                StaticObjects.Add( billboardObject );
            }
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
            else
            {
                sections = renderBlock.Sections;
            }
            var renderModelSectionBlocks = sections as RenderModelSectionBlock[] ?? sections.ToArray( );

            //  Loop through all the sections and load the vertex data if needed and pass the part along 
            //  to the draw manager to  handle sorting and grouping
            foreach ( var renderModelSection in renderModelSectionBlocks )
            {
                _bucketManager.BufferPartData( renderModelSection.SectionData[ 0 ].Section );

                foreach ( var part in renderModelSection.SectionData[ 0 ].Section.Parts )
                {
                    var materialBlock = renderBlock.Materials[ part.Material ];

                    //  Create an instance for this part and assign a shader for it
                    _drawManager.CreateInstance( part, instance );
                    _drawManager.AssignShader( part, materialBlock.Shader.Ident );
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
                permutationNames.Add( region.Permutations.FirstOrDefault( )?.PermutationName ?? StringIdent.Zero );
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
                            : region.Permutations.SingleOrDefault( u => u.Name == permutationNames[ index ] ) ??
                              region.Permutations[ 0 ], detailLevel );
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
    };
}