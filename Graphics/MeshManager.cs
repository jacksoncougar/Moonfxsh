using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using BulletSharp;
using Moonfish.Cache;
using Moonfish.Graphics.Input;
using Moonfish.Graphics.Primitives;
using Moonfish.Guerilla;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Moonfish.Graphics
{
    public class NewSceneManager
    {
        public BucketManager bucketManager;
        private CacheStream _cache;
        private Dictionary<int,List<DrawCommand>> _levelGeometryDrawCommands = new Dictionary<int, List<DrawCommand>>();

        public NewSceneManager(  )
        {
            bucketManager = new BucketManager(  );
        }

        public void Load( CacheStream cache, int sbspIndex = 0 )
        {
            _cache = cache;

            var scenarioBlock = cache.Index.ScenarioIdent.Get<ScenarioBlock>();

            var scenarioStructureBspReferenceBlock = scenarioBlock.StructureBSPs[ sbspIndex ];
            var scenarioStructureBspBlock = scenarioStructureBspReferenceBlock.StructureBSP.Get<ScenarioStructureBspBlock>( );

            // Load Level Geometry
            LoadLevelGeometry(scenarioStructureBspBlock);
        }

        
        public void Draw(ProgramManager programManager, ICollection<DrawCommand> drawCommands)
        {
            programManager.DebugShader.Assign();

            BucketManager.Draw(drawCommands, programManager.DebugShader);
        }

        public List<DrawCommand> GetLevelGeometryDrawCommands( int sbspIndex = 0 )
        {
            //  cache and return commands since they shouldn't change
            if ( _levelGeometryDrawCommands.ContainsKey( sbspIndex ) ) return _levelGeometryDrawCommands[ sbspIndex ];
            
            var scenarioBlock = _cache.Index.ScenarioIdent.Get<ScenarioBlock>( );

            var scenarioStructureBspReferenceBlock = scenarioBlock.StructureBSPs[ sbspIndex ];
            var scenarioStructureBspBlock =
                scenarioStructureBspReferenceBlock.StructureBSP.Get<ScenarioStructureBspBlock>( );

            var drawCommands = new List<DrawCommand>( );
            foreach ( var structureBspClusterBlock in scenarioStructureBspBlock.Clusters )
            {
                drawCommands.AddRange( bucketManager.GetDrawCommands( structureBspClusterBlock.ClusterData[ 0 ].Section ) );
            }

            drawCommands = new List<DrawCommand>( Optimize( drawCommands ) );

            foreach ( var item in scenarioStructureBspBlock.InstancedGeometriesDefinitions )
            {
                drawCommands.AddRange( bucketManager.GetDrawCommands( item.RenderInfo.RenderData[ 0 ].Section ) );
            }
            _levelGeometryDrawCommands[sbspIndex] = drawCommands;
            return _levelGeometryDrawCommands[ sbspIndex ];
        }

        private static IEnumerable<DrawCommand> Optimize( List<DrawCommand> drawCommands )
        {
            var enumerables = drawCommands.GroupBy( g => g.bucket ) as IList<IGrouping<Bucket, DrawCommand>> ??
                              drawCommands.GroupBy( g => g.bucket ).ToList( );

            var optimizedCommands = new List<DrawCommand>( enumerables.Count );
            foreach ( var grouping in enumerables )
            {
                var count = grouping.Count( );

                var primitiveCounts = new int[count];
                var baseOffsets = new int[count];
                var baseVertices = new int[count];

                var index = 0;
                foreach ( var drawCommand in grouping )
                {
                    primitiveCounts[ index ] = drawCommand.count[ 0 ];
                    baseOffsets[ index ] = drawCommand.offset[ 0 ];
                    baseVertices[ index ] = drawCommand.baseVertex[ 0 ];
                    index++;
                }
                var copy = grouping.First( );
                copy.baseVertex = baseVertices;
                copy.count = primitiveCounts;
                copy.offset = baseOffsets;
                copy.multiDrawCount = count;
                copy.AssignAttribute("instanceWorldMatrix", Matrix4.Identity);
                optimizedCommands.Add( copy );
            }
            return optimizedCommands;
        }

        private void LoadLevelGeometry(ScenarioStructureBspBlock structureBsp )
        {
            using ( bucketManager.BeginBucket( ) )
            {
                foreach ( var structureBspClusterBlock in structureBsp.Clusters )
                {
                    structureBspClusterBlock.LoadClusterData( );
                    BucketManager.UnpackLightingData( structureBspClusterBlock.ClusterData[ 0 ].Section );
                }

                bucketManager.QueueSectionData(structureBsp.Clusters.Select( e => e.ClusterData[ 0 ].Section ) );
            }

            using ( bucketManager.BeginBucket( ) )
            {
                for ( var index = 0; index < structureBsp.InstancedGeometriesDefinitions.Length; index++ )
                {
                    var item = structureBsp.InstancedGeometriesDefinitions[ index ];
                    var index1 = index;
                    var items =
                        structureBsp.InstancedGeometryInstances.Where( e => e.InstanceDefinition == index1 )
                            .Select( e => e.WorldMatrix )
                            .ToList( );
                    item.RenderInfo.LoadRenderData( );
                    BucketManager.UnpackLightingData( item.RenderInfo.RenderData[ 0 ].Section );
                    bucketManager.QueueSectionData( new[] {item.RenderInfo.RenderData[ 0 ].Section} );
                    bucketManager.QueueInstanceData( new[] {item.RenderInfo.RenderData[ 0 ].Section}, items );
                }
            }
        }
    };

    public class SceneManager
    {
        private readonly Dictionary<TagIdent, ScenarioObject> _objectInstances;
        public readonly BucketManager bucketManager = new BucketManager( );
        private DrawCommand[] _drawCommands;
        private ScenarioStructureLightmapBlock _lightmapBlock;
        private ScenarioBlock _scenario;
        private Lookup<VertexAttributeType, TriangleBucket> Buckets;
        public ObjectBlock _objectBlock;

        public SceneManager( )
        {
            _objectInstances = new Dictionary<TagIdent, ScenarioObject>( );
            ClusterObjects = new List<RenderObject>( );
            InstancedGeometryObjects = new List<RenderObject>( );
        }

        public List<RenderObject> ClusterObjects { get; private set; }
        public CollisionManager Collision { get; set; }
        public List<RenderObject> InstancedGeometryObjects { get; private set; }

        public Dictionary<ObjectBlock, Matrix4[]> Instances { get; set; } = new Dictionary<ObjectBlock, Matrix4[]>( );

        public ScenarioObject this[ TagIdent ident ]
        {
            get
            {
                ScenarioObject instances;
                if ( _objectInstances.TryGetValue( ident, out instances ) )
                    return instances;
                return null;
            }
        }

        public ScenarioStructureBspBlock Level { get; private set; }
        public ProgramManager ProgramManager { get; set; }

        public void AddInstance( TagIdent ident, out int instanceIdent, out ScenarioObject instanceScenarioObject,
            Matrix4 instanceWorldMatrix = new Matrix4( ) )
        {
            instanceWorldMatrix = instanceWorldMatrix == Matrix4.Zero ? Matrix4.Identity : instanceWorldMatrix;
            instanceScenarioObject = this[ ident ];
            instanceIdent = instanceScenarioObject.InstanceBasisMatrices.Count;

            instanceScenarioObject.AddInstance( instanceWorldMatrix );

            CollisionObject collisionObject = new ClickableCollisionObject( );
            collisionObject.CollisionShape =
                new BoxShape( instanceScenarioObject.RenderModel.CompressionInfo[ 0 ].ToHalfExtents( ) );
            collisionObject.WorldTransform = Matrix4.CreateTranslation(
                instanceScenarioObject.RenderModel.CompressionInfo[ 0 ].ToObjectMatrix( ).ExtractTranslation( ) ) *
                                             instanceWorldMatrix;
            collisionObject.UserIndex = instanceIdent;
            collisionObject.UserObject = instanceScenarioObject;
            Collision.World.AddCollisionObject( collisionObject );
        }

        public bool Contains( TagIdent ident )
        {
            return _objectInstances.ContainsKey( ident );
        }

        public void Draw(ProgramManager programManager)
        {
            var worldMatrixUniform = programManager.DebugShader.GetUniformLocation("WorldMatrixUniform");
            programManager.DebugShader.SetUniform(worldMatrixUniform, Matrix4.Zero);
            BucketManager.Draw(_drawCommands, programManager.DebugShader);
        }

        public void Draw(ProgramManager programManager, DrawCommand[] drawCommands)
        {
            var worldMatrixUniform = programManager.DebugShader.GetUniformLocation("WorldMatrixUniform");
            programManager.DebugShader.SetUniform(worldMatrixUniform, Matrix4.Zero);
            BucketManager.Draw(drawCommands, programManager.DebugShader);
        }

        public void ExplicitDraw( ProgramManager programManager, RenderBatch batch, string programName = null )
        {
            if ( batch.BatchObject == null ) return;

            var program = programManager.DebugShader;

            if ( program == null ) return;

            // Begin Render Setup

            GL.BindVertexArray( batch.BatchObject.VertexArrayObjectIdent );
            foreach ( var attribute in batch.Attributes.Select( x => new {Name = x.Key, x.Value} ) )
            {
                var attributeLocation = program.GetAttributeLocation( attribute.Name );
                Program.SetAttribute( attributeLocation, attribute.Value );
            }
            foreach ( var uniform in batch.Uniforms.Select( x => new {Name = x.Key, x.Value} ) )
            {
                var uniformLocation = program.GetUniformLocation( uniform.Name );
                program.SetUniform( uniformLocation, uniform.Value );
            }
            GL.DrawElementsInstanced( batch.PrimitiveType, batch.ElementLength, batch.DrawElementsType,
                ( IntPtr ) batch.ElementStartIndex, 1 );
        }


        public void LoadScenario( CacheStream map )
        {
            var ident = map.Index.Where( ( TagClass ) "scnr", "" ).First( ).Identifier;
            _scenario = ( ScenarioBlock ) map.Deserialize( ident );

            var multiplayerMatchGlobalsId = map.Index.Where( ( TagClass ) "mulg", "" ).First( ).Identifier;
            var multiplayerMatchGlobals = ( MultiplayerGlobalsBlock ) map.Deserialize( multiplayerMatchGlobalsId );

            var scenarioStructureBspReferenceBlock = _scenario.StructureBSPs.First( );
            var scenarioStructureBspBlock =
                ( ScenarioStructureBspBlock ) scenarioStructureBspReferenceBlock.StructureBSP.Get( );
            LoadScenarioStructure(scenarioStructureBspBlock, map);
            //LoadScenarioLightmap(
            //    ( ScenarioStructureLightmapBlock ) scenarioStructureBspReferenceBlock.StructureLightmap.Get( ) );
            LoadInstances(
                _scenario.Scenery.Select(x => (IH2ObjectInstance)x).ToList(),
                _scenario.SceneryPalette.Select(x => (IH2ObjectPalette)x).ToList());
            LoadInstances(
                _scenario.Crates.Select(x => (IH2ObjectInstance)x).ToList(),
                _scenario.CratesPalette.Select(x => (IH2ObjectPalette)x).ToList());
            LoadInstances(
                _scenario.Weapons.Select(x => (IH2ObjectInstance)x).ToList(),
                _scenario.WeaponPalette.Select(x => (IH2ObjectPalette)x).ToList());
            LoadNetgameEquipment(
                _scenario.NetgameEquipment.Select(x => x).ToList());

            if (multiplayerMatchGlobals.Runtime.Length > 0)
                LoadNetgameFlags(_scenario.NetgameFlags, multiplayerMatchGlobals.Runtime[0]);

            Collision.LoadScenarioCollision( scenarioStructureBspBlock );
            //LoadCollision( );
            //_drawCommands = bucketManager.GetCommands( );
        }

        public void Update( )
        {
            //foreach ( CollisionObject collisionObject in Collision.World.CollisionObjectArray )
            //{
            //    var userObject = collisionObject.UserObject as ObjectBlock;
            //    if ( collisionObject.UserObject != null && ( userObject != null ) )
            //    {
            //        UpdateInstance( userObject, collisionObject.UserIndex, collisionObject.WorldTransform );
            //    }
            //}
        }

        public void UpdateInstance( ObjectBlock userObject, int userIndex, Matrix4 instanceMatrix )
        {
            var renderModelBlock = userObject.Model.Get<ModelBlock>( ).RenderModel.Get<RenderModelBlock>( );

            var collisionSpaceMatrix =
                Matrix4.CreateTranslation(
                    -renderModelBlock.CompressionInfo[ 0 ].ToObjectMatrix( ).ExtractTranslation( ) );

            Instances[ userObject ][ userIndex ] = collisionSpaceMatrix * instanceMatrix;

            bucketManager.LoadSectionInstanceData( renderModelBlock.Sections.Select( e => e.SectionData[ 0 ].Section ),
                new[] {collisionSpaceMatrix * instanceMatrix}, userIndex );
        }

        internal void Add( TagIdent ident, ScenarioObject @object )
        {
            _objectInstances[ ident ] = @object;
        }

        internal void Clear( )
        {
            _objectInstances.Clear( );
        }

        internal void Remove( TagIdent item )
        {
            _objectInstances.Remove( item );
        }

        private void DrawLevel( )
        {
            for ( var i = 0; i < ClusterObjects.Count; ++i )
            {
                foreach ( var batch in ClusterObjects[ i ].Batches )
                {
                    var index = batch.Shader.Ident;
                    batch.Shader.Ident = ( int ) Level.Materials[ index ].Shader.Ident;
                    var paletteIndex = _lightmapBlock.LightmapGroups[ 0 ].ClusterRenderInfo[ i ].PaletteIndex;
                    batch.AssignUniform( "LightmapPaletteIndexUniform", ( float ) paletteIndex );
                    ExplicitDraw( ProgramManager, batch, "lightmapped" );
                }
            }
            foreach ( var structureBspInstancedGeometryInstancesBlock in Level.InstancedGeometryInstances )
            {
                var shortBlockIndex1 = structureBspInstancedGeometryInstancesBlock.InstanceDefinition;
                var instancedGeometryObject = shortBlockIndex1 < InstancedGeometryObjects.Count
                    ? InstancedGeometryObjects[ shortBlockIndex1 ]
                    : null;
                if ( instancedGeometryObject == null ) continue;
                foreach ( var renderBatch in instancedGeometryObject.Batches )
                {
                    var index = renderBatch.Shader.Ident;
                    renderBatch.Shader.Ident = ( int ) Level.Materials[ index ].Shader.Ident;
                    renderBatch.Uniforms[ "WorldMatrixUniform" ] =
                        structureBspInstancedGeometryInstancesBlock.WorldMatrix;
                    ExplicitDraw( ProgramManager, renderBatch, "lightmapped" );
                }
            }
        }

        private void DrawLightmap( ScenarioStructureLightmapBlock scenarioStructureLightmapBlock )
        {
            if ( Level == null ) return;
            for ( var i = 0; i < ClusterObjects.Count; ++i )
            {
                var bitmapGroup = scenarioStructureLightmapBlock.LightmapGroups[ 0 ].BitmapGroup;
                var bitmapIndex = scenarioStructureLightmapBlock.LightmapGroups[ 0 ].ClusterRenderInfo[ i ].BitmapIndex;
                var paletteIndex =
                    scenarioStructureLightmapBlock.LightmapGroups[ 0 ].ClusterRenderInfo[ i ].PaletteIndex;
                foreach ( var batch in ClusterObjects[ i ].Batches )
                {
                    DrawLightmappedBatch( batch, paletteIndex, bitmapIndex );
                }
            }
            for ( var i = 0; i < Level.InstancedGeometryInstances.Length; ++i )
            {
                var instance = Level.InstancedGeometryInstances[ i ];
                var bitmapGroup = scenarioStructureLightmapBlock.LightmapGroups[ 0 ].BitmapGroup;
                var bitmapIndex = scenarioStructureLightmapBlock.LightmapGroups[ 0 ].InstanceRenderInfo[ i ].BitmapIndex;
                var paletteIndex =
                    scenarioStructureLightmapBlock.LightmapGroups[ 0 ].InstanceRenderInfo[ i ].PaletteIndex;
                foreach ( var renderBatch in InstancedGeometryObjects[ instance.InstanceDefinition ].Batches )
                {
                    renderBatch.AssignUniform( "WorldMatrixUniform", instance.WorldMatrix );
                    DrawLightmappedBatch( renderBatch, paletteIndex, bitmapIndex );
                }
            }
        }

        private void DrawLightmappedBatch( RenderBatch batch, byte paletteIndex, short bitmapIndex )
        {
            var index = batch.Shader.Ident;
            batch.Shader.Ident = ( int ) Level.Materials[ index ].Shader.Ident;

            if ( batch.BatchObject == null ) return;
            var program = ProgramManager.GetProgram( batch.Shader, "lightmapped" );
            if ( program == null ) return;

            batch.AssignUniform( "LightmapPaletteIndexUniform", ( float ) paletteIndex );

            if ( bitmapIndex >= 0 )
            {
                var texture = ProgramManager.GetLightmapTexture( bitmapIndex, paletteIndex );
                GL.ActiveTexture( TextureUnit.Texture0 + 4 );
                texture.Bind( );
            }

            GL.BindVertexArray( batch.BatchObject.VertexArrayObjectIdent );
            foreach ( var attribute in batch.Attributes.Select( x => new {Name = x.Key, x.Value} ) )
            {
                var attributeLocation = program.GetAttributeLocation( attribute.Name );
                Program.SetAttribute( attributeLocation, attribute.Value );
            }
            foreach ( var uniform in batch.Uniforms.Select( x => new {Name = x.Key, x.Value} ) )
            {
                var uniformLocation = program.GetUniformLocation( uniform.Name );
                program.SetUniform( uniformLocation, uniform.Value );
            }
            GL.DrawElements( batch.PrimitiveType, batch.ElementLength, batch.DrawElementsType, batch.ElementStartIndex );
        }

        private void GenerateTextureFromLightmapPalette(
            LightmapGeometryRenderInfoBlock lightmapGeometryRenderInfoBlock,
            StructureLightmapGroupBlock structureLightmapGroupBlock, BitmapBlock bitmapBlock )
        {
            var bitmapIndex = lightmapGeometryRenderInfoBlock.BitmapIndex;
            var paletteIndex = lightmapGeometryRenderInfoBlock.PaletteIndex;
            if ( paletteIndex == byte.MaxValue || bitmapIndex < 0 ) return;

            var colourPaletteData = structureLightmapGroupBlock.SectionPalette[ paletteIndex ];
            var bitmapDataBlock = bitmapBlock.Bitmaps[ bitmapIndex ];
            ProgramManager.LoadPalettedTextureGroup( bitmapIndex, paletteIndex, bitmapDataBlock, colourPaletteData,
                TextureMagFilter.Linear, TextureMinFilter.LinearMipmapLinear );
        }

        private void LoadInstanceCollision( RenderModelBlock renderModelBlock, Matrix4 matrix4, int instanceId,
            ObjectBlock objectBlock )
        {
            CollisionObject collisionObject = new ClickableCollisionObject
            {
                CollisionShape = new BoxShape( renderModelBlock.CompressionInfo[ 0 ].ToHalfExtents( ) ),
                WorldTransform =
                    Matrix4.CreateTranslation(
                        renderModelBlock.CompressionInfo[ 0 ].ToObjectMatrix( ).ExtractTranslation( ) ) * matrix4,
                UserIndex = instanceId,
                UserObject = objectBlock,
                Friction = 0
            };
            Collision.World.AddCollisionObject( collisionObject, CollisionFilterGroups.DefaultFilter,
                CollisionFilterGroups.StaticFilter | CollisionFilterGroups.DefaultFilter );
        }

        private void LoadInstances( List<IH2ObjectInstance> instances, IEnumerable<IH2ObjectPalette> objectPalette )
        {
            var objects = objectPalette.Where( x => x.ObjectReference.Ident != TagIdent.NullIdentifier );
            var h2ObjectPalettes = objects as IH2ObjectPalette[] ?? objects.ToArray( );

            using ( bucketManager.BeginBucket( ) )
            {
                for ( var index = 0; index < h2ObjectPalettes.Length; index++ )
                {
                    var h2ObjectPalette = h2ObjectPalettes[ index ];
                    var objectBlock = h2ObjectPalette.ObjectReference.Get<ObjectBlock>( );
                    var renderModelBlock = objectBlock.Model.Get<ModelBlock>( )?.RenderModel.Get<RenderModelBlock>( );

                    if ( renderModelBlock == null ) continue;

                    var sections = renderModelBlock.Sections.ToList( );

                    LoadSectionData( sections, renderModelBlock );

                    var sectionStructBlocks =
                        new List<GlobalGeometrySectionStructBlock>( sections.Select( x => x.SectionData[ 0 ].Section ) );

                    var instanceWorldMatrixs =
                        instances.Where( x => x.PaletteIndex == index ).Select( x => x.WorldMatrix ).ToList( );

                    if ( instanceWorldMatrixs.Count <= 0 ) continue;

                    bucketManager.QueueSectionData(sectionStructBlocks);
                    
                    bucketManager.QueueInstanceData( sectionStructBlocks, instanceWorldMatrixs);

                    if ( !Instances.ContainsKey( objectBlock ) )
                        Instances.Add( objectBlock, instanceWorldMatrixs.ToArray( ) );

                    for ( var instanceId = 0; instanceId < instanceWorldMatrixs.Count; instanceId++ )
                    {
                        var instanecWorldMatrix = instanceWorldMatrixs[ instanceId ];
                        LoadInstanceCollision( renderModelBlock, instanecWorldMatrix, instanceId, objectBlock );
                    }
                }
            }
        }

        private void LoadNetgameEquipment( List<ScenarioNetgameEquipmentBlock> list )
        {
            var objects =
                list.Where( x => x.ItemVehicleCollection.Ident != TagIdent.NullIdentifier )
                    .Select( x => x.ItemVehicleCollection )
                    .Distinct( );

            using ( bucketManager.BeginBucket( ) )
            {
                foreach ( var tagReference in objects )
                {
                    var block = tagReference;
                    var intanceWorldMatrices =
                        list.Where( x => x.ItemVehicleCollection.Ident == block.Ident )
                            .Select( x => x.WorldMatrix )
                            .ToList( );

                    var objectBlock = block.Class == TagClass.Itmc
                        ? block.Get<ItemCollectionBlock>( ).ItemPermutations[ 0 ].Item.Get<ObjectBlock>( )
                        : block.Get<VehicleCollectionBlock>( ).VehiclePermutations[ 0 ].Vehicle.Get<ObjectBlock>( );

                    var renderModelBlock = objectBlock.Model.Get<ModelBlock>( ).RenderModel.Get<RenderModelBlock>( );

                    var sections =
                        objectBlock.Model.Get<ModelBlock>( ).RenderModel.Get<RenderModelBlock>( ).Sections.ToList( );
                    foreach ( var renderModelSectionBlock in sections )
                    {
                        renderModelSectionBlock.LoadSectionData( );
                    }
                    BucketManager.UnpackVertexData( renderModelBlock );

                    var sectionStructBlocks =
                        new List<GlobalGeometrySectionStructBlock>( sections.Select( x => x.SectionData[ 0 ].Section ) );
                    bucketManager.QueueSectionData( sectionStructBlocks );
                    bucketManager.QueueInstanceData(sectionStructBlocks, intanceWorldMatrices);
                }
            }
        }

        private void LoadNetgameFlags( ScenarioNetpointsBlock[] netgameFlags,
            MultiplayerRuntimeBlock multiplayerRuntimeBlock )
        {
            var flagModel = multiplayerRuntimeBlock.Flag.Get<ObjectBlock>( )?.Model.Get<ModelBlock>(  )?.RenderModel.Get<RenderModelBlock>(  );
            var bombMdel = multiplayerRuntimeBlock.DaBomb.Get<ObjectBlock>( )?.Model.Get<ModelBlock>()?.RenderModel.Get<RenderModelBlock>();
            var unitModel = multiplayerRuntimeBlock.Unit.Get<ObjectBlock>()?.Model.Get<ModelBlock>()?.RenderModel.Get<RenderModelBlock>();
            var ballModel = multiplayerRuntimeBlock.Ball.Get<ObjectBlock>()?.Model.Get<ModelBlock>()?.RenderModel.Get<RenderModelBlock>();
            if ( flagModel == null ) throw new ArgumentNullException( nameof( flagModel ) );
            if ( unitModel == null ) throw new ArgumentNullException( nameof( unitModel ) );
            if ( ballModel == null ) throw new ArgumentNullException( nameof( ballModel ) );

            using ( bucketManager.BeginBucket( ) )
            {
                LoadObjectRenderModelData( flagModel );
                LoadObjectRenderModelData( bombMdel );
                LoadObjectRenderModelData( unitModel );
                LoadObjectRenderModelData( ballModel );

                Dictionary<ScenarioNetpointsBlock.TypeEnum, List<Matrix4>> netgameFlagWorldMatrices =
                    new Dictionary<ScenarioNetpointsBlock.TypeEnum, List<Matrix4>>( );

                foreach ( var scenarioNetpointsBlock in netgameFlags )
                {
                    if ( !netgameFlagWorldMatrices.ContainsKey( scenarioNetpointsBlock.Type ) )
                    {
                        netgameFlagWorldMatrices.Add( scenarioNetpointsBlock.Type, new List<Matrix4>( ) );
                    }
                    else
                    {
                        netgameFlagWorldMatrices[ scenarioNetpointsBlock.Type ].Add(
                            Matrix4.CreateTranslation( scenarioNetpointsBlock.Position ) );
                    }
                }
                foreach ( var typeEnum in netgameFlagWorldMatrices.Keys )
                {
                    switch ( typeEnum )
                    {
                        case ScenarioNetpointsBlock.TypeEnum.CTFFlagReturn:
                        case ScenarioNetpointsBlock.TypeEnum.CTFFlagSpawn:
                        case ScenarioNetpointsBlock.TypeEnum.TerritoriesFlag:
                            bucketManager.QueueInstanceData(
                                flagModel.Sections.Select( e => e.SectionData[ 0 ].Section ),
                                netgameFlagWorldMatrices[ typeEnum ] );
                            break;
                        case ScenarioNetpointsBlock.TypeEnum.AssaultBombReturn:
                        case ScenarioNetpointsBlock.TypeEnum.AssaultBombSpawn:
                            bucketManager.QueueInstanceData(
                                bombMdel.Sections.Select( e => e.SectionData[ 0 ].Section ),
                                netgameFlagWorldMatrices[ typeEnum ] );
                            break;
                        case ScenarioNetpointsBlock.TypeEnum.OddballSpawn:
                            bucketManager.QueueInstanceData(
                                ballModel.Sections.Select( e => e.SectionData[ 0 ].Section ),
                                netgameFlagWorldMatrices[ typeEnum ] );
                            break;
                    }
                }
            }
        }

        private void LoadObjectRenderModelData( RenderModelBlock renderModel )
        { 
            if (renderModel == null ) return;

            var sections = renderModel.Sections.ToList( );
            LoadSectionData( sections, renderModel);

            var sectionStructBlocks =
                new List<GlobalGeometrySectionStructBlock>( sections.Select( x => x.SectionData[ 0 ].Section ) );

            bucketManager.QueueSectionData( sectionStructBlocks );
        }

        private void LoadScenarioLightmap( ScenarioStructureLightmapBlock scenarioStructureLightmapBlock )
        {
            if ( scenarioStructureLightmapBlock == null ) return;

            _lightmapBlock = scenarioStructureLightmapBlock;

            foreach ( var structureLightmapGroupBlock in scenarioStructureLightmapBlock.LightmapGroups )
            {
                var bitmapBlock = structureLightmapGroupBlock.BitmapGroup.Get<BitmapBlock>( );
                foreach ( var lightmapGeometryRenderInfoBlock in structureLightmapGroupBlock.ClusterRenderInfo )
                {
                    GenerateTextureFromLightmapPalette( lightmapGeometryRenderInfoBlock, structureLightmapGroupBlock,
                        bitmapBlock );
                }
                foreach ( var lightmapGeometryRenderInfoBlock in structureLightmapGroupBlock.InstanceRenderInfo )
                {
                    GenerateTextureFromLightmapPalette( lightmapGeometryRenderInfoBlock, structureLightmapGroupBlock,
                        bitmapBlock );
                }
                OpenGL.GetError( );
            }
        }

        private void LoadScenarioStructure( ScenarioStructureBspBlock levelBlock, CacheStream cacheStream )
        {
            Level = levelBlock;
            ClusterObjects = new List<RenderObject>( );
            InstancedGeometryObjects = new List<RenderObject>( );
            using ( bucketManager.BeginBucket( ) )
            {
                foreach ( var structureBspClusterBlock in Level.Clusters )
                {
                    structureBspClusterBlock.LoadClusterData( );
                    BucketManager.UnpackLightingData( structureBspClusterBlock.ClusterData[ 0 ].Section );
                }

                bucketManager.QueueSectionData( Level.Clusters.Select( e => e.ClusterData[ 0 ].Section ) );
            }

            using (bucketManager.BeginBucket())
            {
                for (var index = 0; index < Level.InstancedGeometriesDefinitions.Length; index++)
                {
                    var item = Level.InstancedGeometriesDefinitions[index];
                    var index1 = index;
                    var items =
                        Level.InstancedGeometryInstances.Where(e => e.InstanceDefinition == index1)
                            .Select(e => e.WorldMatrix)
                            .ToList();
                    item.RenderInfo.LoadRenderData();
                    BucketManager.UnpackLightingData(item.RenderInfo.RenderData[0].Section);
                    bucketManager.QueueSectionData(new[] { item.RenderInfo.RenderData[0].Section });
                    bucketManager.QueueInstanceData(new[] { item.RenderInfo.RenderData[0].Section }, items);
                }
            }

            foreach ( var cluster in Level.Clusters )
            {
                //bucketManager.LoadRenderModels(  );
                //cluster.LoadClusterData(  );
                //cluster.ClusterData[0].Section
                //ClusterObjects.Add( new RenderObject( cluster ) );
            }
            foreach ( var item in Level.InstancedGeometriesDefinitions )
            {
                // InstancedGeometryObjects.Add( new RenderObject( item ) );
            }
            //ProgramManager.LoadMaterials( Level.Materials, cacheStream );
        }

        private void LoadSectionData( List<RenderModelSectionBlock> sections, RenderModelBlock renderModelBlock )
        {
            foreach ( var renderModelSectionBlock in sections )
            {
                renderModelSectionBlock.LoadSectionData( );
            }
            BucketManager.UnpackVertexData( renderModelBlock );
        }

        public void LoadObject( ObjectBlock objectBlock )
        {
            _objectBlock = objectBlock;

            using ( bucketManager.BeginBucket( ) )
            {
                var renderModelBlock = objectBlock.Model.Get<ModelBlock>( )?.RenderModel.Get<RenderModelBlock>( );
                if ( renderModelBlock == null ) throw new ArgumentNullException( nameof( renderModelBlock ) );

                var sections =
                    objectBlock.Model.Get<ModelBlock>( ).RenderModel.Get<RenderModelBlock>( ).Sections.ToList( );

                foreach ( var renderModelSectionBlock in sections )
                {
                    renderModelSectionBlock.LoadSectionData( );
                }
                BucketManager.UnpackVertexData( renderModelBlock );

                var sectionStructBlocks =
                    new List<GlobalGeometrySectionStructBlock>( sections.Select( x => x.SectionData[ 0 ].Section ) );
                bucketManager.QueueSectionData( sectionStructBlocks );
                bucketManager.QueueInstanceData( sectionStructBlocks, new[] {Matrix4.Identity} );

            }
        }
    }
}