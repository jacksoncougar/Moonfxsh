using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using Fasterflect;
using Moonfish.Graphics.RenderingEngine;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;

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

        private InstanceDataBuffer InstancesBuffer { get; } = new InstanceDataBuffer( );

        public ScenarioManager( )
        {
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
        public void DrawScenario( Camera eye, ProgramManager programManager )
        {
            var program = programManager.DebugShader;
            program.Assign( );

            _drawManager.Clear( );
            TraverseScenario( eye );
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
            throw new NotImplementedException();

/*
            var modelBlock = objectBlock.Model.Get<ModelBlock>(  );
            var renderBlock = modelBlock?.RenderModel.Get<RenderModelBlock>( );

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
                    _drawManager.AssignShader( part, materialBlock.Shader.Ident );
                }
            }
*/
        }

        /// <summary>
        ///     Buffers array data and creates draw commands as needed for a given object
        /// </summary>
        /// <param name="eye">Viewer camera used to select detail level</param>
        /// <param name="objectBlock">Object to draw</param>
        private void Dispatch( Camera eye, ScenarioStructureBspBlock scenarioStructure )
        {
            if (scenarioStructure == null ) return;

            foreach ( var cluster in scenarioStructure.Clusters )
            {
                if (! cluster.IsClusterDataLoaded )
                {
                }
                var section = cluster.ClusterData[ 0 ].Section;
                _bucketManager.BufferPartData(section);

                foreach (var part in section.Parts)
                {
                    var materialBlock = scenarioStructure.Materials[part.Material];

                    //  Create an instance for this part and assign a shader for it
                    _drawManager.CreateInstance( part, new ScenarioInstanceBlock( ), false );
                    _drawManager.AssignShader(part, materialBlock.Shader.Ident);
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
        private void ProcessPalette( Camera eye, IEnumerable<IH2ObjectInstance> instanceCollection,
            IReadOnlyList<IH2ObjectPalette> paletteCollection )
        {
            foreach ( var instance in instanceCollection )
            {
                var paletteIndex = instance.PaletteIndex;

                var objectBlock = paletteCollection[ paletteIndex ].ObjectReference.Get<ObjectBlock>();
                var modelBlock = objectBlock?.Model.Get<ModelBlock>();
                var renderModel = modelBlock?.RenderModel.Get<RenderModelBlock>();

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
        private void TraverseScenario( Camera eyeCamera )
        {
            throw new NotImplementedException();
            //if ( scenarioBlock == null ) return;
            //DrawManager.ClearVisible( );
            //using ( _bucketManager.Begin( ) )
            //{
            //    ProcessPalette(eyeCamera, scenarioBlock.Scenery, scenarioBlock.SceneryPalette);
            //    ProcessPalette(eyeCamera, scenarioBlock.Crates, scenarioBlock.CratesPalette);
            //    ProcessPalette(eyeCamera, scenarioBlock.Vehicles, scenarioBlock.VehiclePalette);
            //    ProcessPalette(eyeCamera, scenarioBlock.Weapons, scenarioBlock.WeaponPalette);

            //    ProcessStructure( eyeCamera, cachekey, scenarioBlock.StructureBSPs[ 0 ] );
            //}
        }

        private void ProcessStructure( Camera eyeCamera, ScenarioStructureBspReferenceBlock structureBsP )
        {
            var levelData = (ScenarioStructureBspBlock)structureBsP.StructureBSP.Get();
            if ( levelData == null ) return;

            Dispatch( eyeCamera, levelData );

        }
    };
}