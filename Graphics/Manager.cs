using System;
using System.Collections.Generic;
using System.Linq;
using Moonfish.Cache;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;
using OpenTK.Graphics.OpenGL;

namespace Moonfish.Graphics
{
    public class MeshManager
    {
        public ProgramManager ProgramManager { get; set; }
        private readonly Dictionary<TagIdent, List<ScenarioObject>> _objectInstances;
        private ScenarioBlock _scenario;

        public MeshManager( )
        {
            _objectInstances = new Dictionary<TagIdent, List<ScenarioObject>>( );
            ClusterObjects = new List<RenderObject>( );
            InstancedGeometryObjects = new List<RenderObject>( );
        }

        public CollisionManager Collision { get; set; }
        public ScenarioStructureBspBlock Level { get; private set; }
        public List<RenderObject> ClusterObjects { get; private set; }
        public List<RenderObject> InstancedGeometryObjects { get; private set; }

        public IEnumerable<ScenarioObject> this[ TagIdent ident ]
        {
            get
            {
                List<ScenarioObject> instances;
                if ( _objectInstances.TryGetValue( ident, out instances ) )
                    return instances;
                return Enumerable.Empty<ScenarioObject>( );
            }
        }

        public void LoadScenarioStructure( ScenarioStructureBspBlock levelBlock, CacheStream cacheStream )
        {
            Level = levelBlock;
            ClusterObjects = new List<RenderObject>( );
            InstancedGeometryObjects = new List<RenderObject>( );
            foreach ( var cluster in Level.Clusters )
            {
                ClusterObjects.Add( new RenderObject( cluster ) );
            }
            foreach ( var item in Level.InstancedGeometriesDefinitions )
            {
                //InstancedGeometryObjects.Add( new RenderObject( item ) );
            }
            ProgramManager.LoadMaterials( Level.Materials, cacheStream );
        }

        internal void Add( TagIdent ident, ScenarioObject @object )
        {
            List<ScenarioObject> instanceList;
            if ( !_objectInstances.TryGetValue( ident, out instanceList ) )
            {
                instanceList = _objectInstances[ ident ] = new List<ScenarioObject>( );
            }
            instanceList.Add( @object );
        }

        public void LoadCollision(  )
        {
            foreach ( var item in _objectInstances.SelectMany( x => x.Value ) )
            {
                Collision.World.AddCollisionObject( item.CollisionObject );
            }
        }

        public void LoadScenario( CacheStream map )
        {
            var ident = map.Index.Select( ( TagClass ) "scnr", "" ).First( ).Identifier;
            _scenario = ( ScenarioBlock ) map.Deserialize( ident );

            var scenarioStructureBspReferenceBlock = _scenario.StructureBSPs.First( );
            var scenarioStructureBspBlock = ( ScenarioStructureBspBlock ) scenarioStructureBspReferenceBlock.StructureBSP.Get( );
            LoadScenarioStructure(
                scenarioStructureBspBlock, map );
            LoadScenarioLightmap(
                ( ScenarioStructureLightmapBlock ) scenarioStructureBspReferenceBlock.StructureLightmap.Get( ), map );


            //LoadInstances(
            //    _scenario.Scenery.Select( x => ( IH2ObjectInstance ) x ).ToList( ),
            //    _scenario.SceneryPalette.Select( x => ( IH2ObjectPalette ) x ).ToList( ), map );
            //LoadInstances(
            //    _scenario.Crates.Select( x => ( IH2ObjectInstance ) x ).ToList( ),
            //    _scenario.CratesPalette.Select( x => ( IH2ObjectPalette ) x ).ToList( ), map );
            //LoadInstances(
            //    _scenario.Weapons.Select( x => ( IH2ObjectInstance ) x ).ToList( ),
            //    _scenario.WeaponPalette.Select( x => ( IH2ObjectPalette ) x ).ToList( ), map );
            //LoadNetgameEquipment(
            //    _scenario.NetgameEquipment.Select( x => x ).ToList( ), map );

            Collision.LoadScenarioCollision( scenarioStructureBspBlock );
            LoadCollision(  );
        }

        private ScenarioStructureLightmapBlock lightmapBlock;

        private void LoadScenarioLightmap( ScenarioStructureLightmapBlock scenarioStructureLightmapBlock,
            CacheStream cacheStream )
        {
            if ( scenarioStructureLightmapBlock == null ) return;

            lightmapBlock = scenarioStructureLightmapBlock;

            foreach ( var structureLightmapGroupBlock in scenarioStructureLightmapBlock.LightmapGroups )
            {
                ProgramManager.LoadTextureGroup( structureLightmapGroupBlock.BitmapGroup.Ident );
                foreach ( var lightmapGeometrySectionBlock in structureLightmapGroupBlock.GeometryBuckets )
                {
                    lightmapGeometrySectionBlock.LoadCacheData( );
                }
            }
        }

        private void LoadNetgameEquipment( List<ScenarioNetgameEquipmentBlock> list, CacheStream cacheStream )
        {
            foreach ( var item in list.Where( x => !TagIdent.IsNull( x.ItemVehicleCollection.Ident )
                                                   &&
                                                   ( x.ItemVehicleCollection.Class.ToString( ) == "vehc" ||
                                                     x.ItemVehicleCollection.Class.ToString( ) == "itmc" ) ) )
            {
                try
                {
                    var scenarioObject = new ScenarioObject( Halo2.GetReferenceObject<ModelBlock>(
                        Halo2.GetReferenceObject<ObjectBlock>(
                            item.ItemVehicleCollection.Class.ToString( ) == "itmc"
                                ? Halo2.GetReferenceObject<ItemCollectionBlock>( item.ItemVehicleCollection )
                                    .ItemPermutations.First( )
                                    .Item
                                : Halo2.GetReferenceObject<VehicleCollectionBlock>( item.ItemVehicleCollection )
                                    .VehiclePermutations.First( )
                                    .Vehicle ).Model ) )
                    {
                        WorldMatrix = item.WorldMatrix
                    };
                    var renderModel = scenarioObject.Model.RenderModel.Get<RenderModelBlock>( );
                    ProgramManager.LoadMaterials( renderModel.Materials, cacheStream );
                    Add( item.ItemVehicleCollection.Ident, scenarioObject );
                }
                catch ( NullReferenceException )
                {
                }
            }
        }

        private void LoadInstances( List<IH2ObjectInstance> instances, List<IH2ObjectPalette> objectPalette,
            CacheStream cacheStream )
        {
            var join = ( from instance in instances
                join palette in objectPalette on ( int ) instance.PaletteIndex equals objectPalette.IndexOf( palette )
                    into gj
                from items in gj.DefaultIfEmpty( )
                select new {instance, Object = items.ObjectReference} ).ToArray( );

            foreach ( var item in join )
            {
                var scenarioObject = new ScenarioObject(
                    Halo2.GetReferenceObject<ModelBlock>( Halo2.GetReferenceObject<ObjectBlock>( item.Object ).Model ) )
                {
                    WorldMatrix = item.instance.WorldMatrix
                };
                var renderModel = scenarioObject.Model.RenderModel.Get<RenderModelBlock>( );
                ProgramManager.LoadMaterials( renderModel.Materials, cacheStream );
                Add( item.Object.Ident, scenarioObject );
            }
        }

        public void Draw( ProgramManager programManager )
        {
            DrawLightmap( lightmapBlock );
            DrawLevel( );
            foreach ( var item in _objectInstances.SelectMany( x => x.Value ).Select( x => new {x, x.Batches} ) )
            {
                foreach ( var renderBatch in item.Batches )
                {
                    Draw( programManager, renderBatch );
                }
            }
        }

        private void DrawLevel( )
        {
            foreach ( var batch in ClusterObjects.SelectMany( x => x.Batches ) )
            {
                var index = batch.Shader.Ident;
                batch.Shader.Ident = ( int ) Level.Materials[ index ].Shader.Ident;
                Draw( ProgramManager, batch, "lightmapped" );
            }
            foreach ( var structureBspInstancedGeometryInstancesBlock in Level.InstancedGeometryInstances )
            {
                var shortBlockIndex1 = structureBspInstancedGeometryInstancesBlock.InstanceDefinition;
                var instancedGeometryObject = shortBlockIndex1 < InstancedGeometryObjects.Count
                    ? InstancedGeometryObjects[ shortBlockIndex1 ]
                    : null;
                if ( instancedGeometryObject == null ) continue;
                foreach (
                    var renderBatch in instancedGeometryObject.Batches )
                {
                    var index = renderBatch.Shader.Ident;
                    renderBatch.Shader.Ident = ( int ) Level.Materials[ index ].Shader.Ident;
                    renderBatch.Uniforms[ "WorldMatrixUniform" ] =
                        structureBspInstancedGeometryInstancesBlock.WorldMatrix;
                    Draw( ProgramManager, renderBatch, "lightmapped" );
                }
            }
        }

        private void DrawLightmap( ScenarioStructureLightmapBlock scenarioStructureLightmapBlock )
        {
            for ( int i = 0; i < ClusterObjects.Count; ++i )
            {
                foreach ( var batch in ClusterObjects[ i ].Batches )
                {
                    var index = batch.Shader.Ident;
                    batch.Shader.Ident = ( int ) Level.Materials[ index ].Shader.Ident;

                    if ( batch.BatchObject == null ) return;
                    var program = ProgramManager.GetProgram( batch.Shader, "lightmapped" );
                    var bitmapGroup = scenarioStructureLightmapBlock.LightmapGroups[ 0 ].BitmapGroup;
                    var bitmapIndex =
                        scenarioStructureLightmapBlock.LightmapGroups[ 0 ].ClusterRenderInfo[ i ].BitmapIndex;
                    var submaps = ProgramManager.LoadedTextureArrays[ bitmapGroup.Ident ];
                    GL.ActiveTexture( TextureUnit.Texture0 + 4 );
                    submaps[ bitmapIndex ].Bind( );

                    if ( program == null ) return;

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
                    GL.DrawElements( batch.PrimitiveType, batch.ElementLength, batch.DrawElementsType,
                        batch.ElementStartIndex );
                }
            }
        }

        public void Draw( ProgramManager programManager, RenderBatch batch, string programName = null )
        {
            if ( batch.BatchObject == null ) return;
            var program = programManager.GetProgram( batch.Shader, programName );
            if ( program == null ) return;

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

        public void Draw( TagIdent item )
        {
            if ( _objectInstances.ContainsKey( item ) )
            {
                //IRenderable @object = objects[item] as IRenderable;
                //@object.Render( new[] { program, systemProgram } );
            }
            else
            {
                var data = Halo2.GetReferenceObject( item );
                //objects[item] = new ScenarioObject( (ModelBlock)data );
            }
        }

        internal void Remove( TagIdent item )
        {
            _objectInstances.Remove( item );
        }

        internal void Clear( )
        {
            _objectInstances.Clear( );
        }
    }
}