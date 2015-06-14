using System;
using System.Collections.Generic;
using System.Linq;
using BulletSharp;
using Moonfish.Cache;
using Moonfish.Graphics.Input;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Moonfish.Graphics
{
    public class MeshManager
    {
        private readonly Dictionary<TagIdent, ScenarioObject> _objectInstances;
        private ScenarioBlock _scenario;
        private ScenarioStructureLightmapBlock _lightmapBlock;

        public MeshManager( )
        {
            _objectInstances = new Dictionary<TagIdent, ScenarioObject>( );
            ClusterObjects = new List<RenderObject>( );
            InstancedGeometryObjects = new List<RenderObject>( );
        }

        public List<RenderObject> ClusterObjects { get; private set; }
        public CollisionManager Collision { get; set; }
        public List<RenderObject> InstancedGeometryObjects { get; private set; }

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

        public void Draw( ProgramManager programManager )
        {
            DrawLightmap( _lightmapBlock );
            foreach (var renderBatch in _objectInstances.Select(x => x.Value).SelectMany(x => x.Batches))
            {
                Draw( programManager, renderBatch );
            }
        }

        public void Draw( ProgramManager programManager, RenderBatch batch, string programName = null )
        {
            if ( batch.BatchObject == null ) return;

            var program = programManager.GetProgram( batch.Shader, programName );

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
            GL.DrawElementsInstanced( batch.PrimitiveType, batch.ElementLength, batch.DrawElementsType, (IntPtr)batch.ElementStartIndex, batch.InstanceCount );
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

        public void LoadCollision( )
        {
            foreach ( var item in _objectInstances.Select( x => x.Value ) )
            {
                for ( int index = 0; index < item.InstanceWorldMatrices.Count; index++ )
                {
                    var instanceWorldMatrix = item.InstanceWorldMatrices[ index ];

                    CollisionObject collisionObject = new ClickableCollisionObject( );
                    collisionObject.CollisionShape =
                        new BoxShape( item.RenderModel.CompressionInfo[ 0 ].ToHalfExtents( ) );
                    collisionObject.WorldTransform = Matrix4.CreateTranslation(
                        item.RenderModel.CompressionInfo[ 0 ].ToObjectMatrix( ).ExtractTranslation( ) ) *
                                                     instanceWorldMatrix;
                    collisionObject.UserIndex = index;
                    collisionObject.UserObject = item;
                    Collision.World.AddCollisionObject( collisionObject );
                }
            }
        }

        public void LoadScenario( CacheStream map )
        {
            var ident = map.Index.Select( ( TagClass ) "scnr", "" ).First( ).Identifier;
            _scenario = ( ScenarioBlock ) map.Deserialize( ident );

            var scenarioStructureBspReferenceBlock = _scenario.StructureBSPs.First();
            var scenarioStructureBspBlock =
                (ScenarioStructureBspBlock)scenarioStructureBspReferenceBlock.StructureBSP.Get();
            LoadScenarioStructure(scenarioStructureBspBlock, map);
            LoadScenarioLightmap(
                (ScenarioStructureLightmapBlock)scenarioStructureBspReferenceBlock.StructureLightmap.Get());
            LoadInstances(
                _scenario.Scenery.Select(x => (IH2ObjectInstance)x).ToList(),
                _scenario.SceneryPalette.Select(x => (IH2ObjectPalette)x).ToList(), map);
            LoadInstances(
                _scenario.Crates.Select( x => ( IH2ObjectInstance ) x ).ToList( ),
                _scenario.CratesPalette.Select( x => ( IH2ObjectPalette ) x ).ToList( ), map );
            LoadInstances(
                _scenario.Weapons.Select( x => ( IH2ObjectInstance ) x ).ToList( ),
                _scenario.WeaponPalette.Select( x => ( IH2ObjectPalette ) x ).ToList( ), map );
            LoadNetgameEquipment(
                _scenario.NetgameEquipment.Select( x => x ).ToList( ), map );

            Collision.LoadScenarioCollision( scenarioStructureBspBlock );
            LoadCollision( );
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
                InstancedGeometryObjects.Add( new RenderObject( item ) );
            }
            ProgramManager.LoadMaterials( Level.Materials, cacheStream );
        }

        internal void Add( TagIdent ident, ScenarioObject @object )
        {
            _objectInstances[ident] = (@object);
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
                    var paletteIndex =
                        _lightmapBlock.LightmapGroups[ 0 ].ClusterRenderInfo[ i ].PaletteIndex;
                    batch.AssignUniform( "LightmapPaletteIndexUniform", ( float ) paletteIndex );
                    Draw( ProgramManager, batch, "lightmapped" );
                }
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
            for ( var i = 0; i < ClusterObjects.Count; ++i )
            {
                var bitmapGroup = scenarioStructureLightmapBlock.LightmapGroups[ 0 ].BitmapGroup;
                var bitmapIndex =
                    scenarioStructureLightmapBlock.LightmapGroups[ 0 ].ClusterRenderInfo[ i ].BitmapIndex;
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
                var bitmapIndex =
                    scenarioStructureLightmapBlock.LightmapGroups[ 0 ].InstanceRenderInfo[ i ].BitmapIndex;
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
            GL.DrawElements( batch.PrimitiveType, batch.ElementLength, batch.DrawElementsType,
                batch.ElementStartIndex );
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
            ProgramManager.LoadPalettedTextureGroup( bitmapIndex, paletteIndex, bitmapDataBlock,
                colourPaletteData, TextureMagFilter.Linear, TextureMinFilter.LinearMipmapLinear );
        }

        private void LoadInstances( List<IH2ObjectInstance> instances, List<IH2ObjectPalette> objectPalette,
            CacheStream cacheStream )
        {
            var objects = objectPalette.Where( x => x.ObjectReference.Ident != TagIdent.NullIdentifier );

            foreach ( var h2ObjectPalette in objects )
            {
                var palette = h2ObjectPalette;
                var h2ObjectInstances = instances;
                var instanceInformation =
                    h2ObjectInstances.Where( x => x.PaletteIndex == objectPalette.IndexOf( palette ) );

                var scenarioObject = new ScenarioObject(
                    Halo2.GetReferenceObject<ModelBlock>(
                        Halo2.GetReferenceObject<ObjectBlock>( h2ObjectPalette.ObjectReference ).Model ) );
                var matrix4s = instanceInformation.Select( x=>x.WorldMatrix ).ToList(  );
                scenarioObject.AssignInstanceMatrices( matrix4s.ToArray(  ) );

                var renderModel = scenarioObject.Model.RenderModel.Get<RenderModelBlock>( );
                if ( renderModel != null )
                    ProgramManager.LoadMaterials( renderModel.Materials, cacheStream );

                Add( h2ObjectPalette.ObjectReference.Ident, scenarioObject );
            }
        }

        private void LoadNetgameEquipment( List<ScenarioNetgameEquipmentBlock> list, CacheStream cacheStream )
        {
            var objects =
                list.Where( x => x.ItemVehicleCollection.Ident != TagIdent.NullIdentifier )
                    .Select( x => x.ItemVehicleCollection )
                    .Distinct( );

            foreach ( var tagReference in objects )
            {
                var block = tagReference;
                var intanceWorldMatrices =
                    list.Where( x => x.ItemVehicleCollection.Ident == block.Ident ).Select( x => x.WorldMatrix );

                var collectionBlock = block.Class == TagClass.Itmc
                    ? block.Get<ItemCollectionBlock>( ).ItemPermutations[ 0 ].Item.Get<ObjectBlock>( ).Model
                    : block.Get<VehicleCollectionBlock>( ).VehiclePermutations[ 0 ].Vehicle.Get<ObjectBlock>( ).Model;

                var scenarioObject = new ScenarioObject(
                    Halo2.GetReferenceObject<ModelBlock>(
                        collectionBlock));
                scenarioObject.AssignInstanceMatrices(intanceWorldMatrices.ToArray());

                var renderModel = scenarioObject.Model.RenderModel.Get<RenderModelBlock>();
                if (renderModel != null)
                    ProgramManager.LoadMaterials(renderModel.Materials, cacheStream);

                Add(block.Ident, scenarioObject);
            }
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

        public void Update( )
        {
            foreach ( var objectInstance in _objectInstances.Select( x=>x.Value ) )
            {
                objectInstance.Update( );
            }
        }

        public void AddInstance( TagIdent ident, out int instanceIdent, out ScenarioObject instanceScenarioObject )
        {
            instanceScenarioObject = this[ident];
            var instanceWorldMatrix = Matrix4.Identity;
            instanceIdent = instanceScenarioObject.InstanceWorldMatrices.Count;

            instanceScenarioObject.InstanceWorldMatrices.Add(instanceWorldMatrix);

            CollisionObject collisionObject = new ClickableCollisionObject();
            collisionObject.CollisionShape =
                new BoxShape(instanceScenarioObject.RenderModel.CompressionInfo[0].ToHalfExtents());
            collisionObject.WorldTransform = Matrix4.CreateTranslation(
                instanceScenarioObject.RenderModel.CompressionInfo[0].ToObjectMatrix().ExtractTranslation()) *
                                             instanceWorldMatrix;
            collisionObject.UserIndex = instanceIdent;
            collisionObject.UserObject = instanceScenarioObject;
            Collision.World.AddCollisionObject(collisionObject);
        }
    }
}