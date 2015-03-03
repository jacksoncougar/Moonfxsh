using BulletSharp;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Moonfish.Graphics
{
    public class CollisionManager
    {
        public CollisionWorld World { get; private set; }

        public CollisionManager( Program debug )
        {
            var defaultCollisionConfiguration = new DefaultCollisionConfiguration();
            var collisionDispatcher = new CollisionDispatcher( defaultCollisionConfiguration );
            var broadphase = new DbvtBroadphase();
            this.World = new CollisionWorld( collisionDispatcher, broadphase, defaultCollisionConfiguration );
            if ( debug != null )
                this.World.DebugDrawer = new BulletDebugDrawer( debug );
        }

        public void LoadScenarioObjectCollection( ScenarioObject scenarioObject )
        {
            foreach ( var marker in scenarioObject.Model.RenderModel.markerGroups.SelectMany( x => x.markers ) )
            {
                var collisionObject = new BulletSharp.CollisionObject();
                collisionObject.CollisionShape = new BulletSharp.BoxShape( 0.015f );
                collisionObject.WorldTransform = Matrix4.CreateFromQuaternion( marker.rotation ) * Matrix4.CreateTranslation( marker.translation ) * scenarioObject.Nodes.GetWorldMatrix( marker.nodeIndex );
                collisionObject.UserObject = scenarioObject.Markers[ marker ];

                World.AddCollisionObject( collisionObject );

                var setPropertyMethodInfo = typeof( BulletSharp.CollisionObject ).GetProperty( "WorldTransform" ).GetSetMethod();
                var setProperty = Delegate.CreateDelegate( typeof( Action<Matrix4> ), collisionObject, setPropertyMethodInfo );

                scenarioObject.Markers[ marker ].MarkerUpdatedCallback += ( Action<Matrix4> )setProperty;
            }
        }

        internal void LoadScenarioCollision( ScenarioStructureBspBlock structureBSP )
        {

            foreach ( var cluster in structureBSP.clusters )
            {
                var triangleMesh = new TriangleMesh();

                var vertices = new Vector3[ cluster.clusterData[ 0 ].section.vertexBuffers[ 0 ].vertexBuffer.Data.Length / 12 ];
                for ( int i = 0; i < vertices.Length; ++i )
                {
                    var data = cluster.clusterData[ 0 ].section.vertexBuffers[ 0 ].vertexBuffer.Data;
                    vertices[ i ] = new Vector3(
                        BitConverter.ToSingle( data, i * 12 + 0 ),
                        BitConverter.ToSingle( data, i * 12 + 4 ),
                        BitConverter.ToSingle( data, i * 12 + 8 ) );
                }
                TriangleIndexVertexArray inte = new TriangleIndexVertexArray(
                    cluster.clusterData[ 0 ].section.stripIndices.Select( x => ( int )x.index ).ToArray(), vertices );

                CollisionObject o = new CollisionObject();
                o.CollisionShape = new BvhTriangleMeshShape( inte, true );
                o.CollisionFlags = CollisionFlags.StaticObject;


                World.AddCollisionObject( o, CollisionFilterGroups.StaticFilter, CollisionFilterGroups.AllFilter );
            }
        }

        public void OnMouseClick( object sender, System.Windows.Forms.MouseEventArgs e )
        {

        }
    }

    public class LevelManager
    {
        Program shaded, system;

        public ScenarioStructureBspBlock Level { get; private set; }
        public List<RenderObject> ClusterObjects { get; private set; }
        public List<RenderObject> InstancedGeometryObjects { get; private set; }

        public LevelManager( params Program[] programs )
        {
            shaded = programs.Length > 0 ? programs[ 0 ] : null;
            system = programs.Length > 1 ? programs[ 1 ] : null;
        }

        public void LoadScenarioStructure( ScenarioStructureBspBlock levelBlock )
        {
            this.Level = levelBlock;
            ClusterObjects = new List<RenderObject>();
            InstancedGeometryObjects = new List<RenderObject>();
            foreach ( var cluster in this.Level.clusters )
            {
                ClusterObjects.Add( new RenderObject( cluster ) { DiffuseColour = Colours.LinearRandomDiffuseColor } );

            }
            foreach ( var item in this.Level.instancedGeometriesDefinitions )
            {
                InstancedGeometryObjects.Add( new RenderObject( item ) { DiffuseColour = Color.DarkRed } );
            }
        }

        public void RenderLevel( )
        {
            if ( Level == null ) return;

            var worldMatrixAttribute = shaded.GetAttributeLocation( "worldMatrix" );
            var objectMatrixAttribute = shaded.GetAttributeLocation( "objectExtents" );

            shaded.SetAttribute( worldMatrixAttribute, Matrix4.Identity );
            shaded.SetAttribute( objectMatrixAttribute, Matrix4.Identity );

            foreach ( var item in ClusterObjects )
                item.Render( shaded );
            foreach ( var instance in this.Level.instancedGeometryInstances )
            {
                shaded.SetAttribute( worldMatrixAttribute, instance.WorldMatrix );
                InstancedGeometryObjects[ ( int )instance.instanceDefinition ].Render( shaded );
            }
        }
    }
    
    public class MeshManager
    {
        CollisionManager Collision { get; set; }
        ScenarioBlock scenario;
        Program old_program;
        Program systemProgram;
        Dictionary<TagIdent, List<ScenarioObject>> objectInstances;

        public IEnumerable<ScenarioObject> this[ TagIdent ident ]
        {
            get
            {
                List<ScenarioObject> instances;
                if ( objectInstances.TryGetValue( ident, out instances ) )
                    return instances;
                else return Enumerable.Empty<ScenarioObject>();
            }
        }

        internal void Add( TagIdent ident, ScenarioObject @object )
        {
            List<ScenarioObject> instanceList;
            if ( !objectInstances.TryGetValue( ident, out instanceList ) )
            {
                instanceList = objectInstances[ ident ] = new List<ScenarioObject>();
            }
            instanceList.Add( @object );
        }

        public MeshManager( Program program, Program systemProgram )
            : this()
        {
            this.old_program = program;
            this.systemProgram = systemProgram;
        }

        public MeshManager( )
        {
            objectInstances = new Dictionary<TagIdent, List<ScenarioObject>>();
        }

        public void LoadCollision( CollisionManager collision )
        {
            this.Collision = collision;
            foreach ( var item in objectInstances.SelectMany( x => x.Value ) )
            {
                Collision.World.AddCollisionObject( item.CollisionObject );
            }
        }

        public void LoadScenario( MapStream map )
        {
            this.scenario = map[ "scnr", "" ].Deserialize();

            LoadInstances(
                scenario.scenery.Select( x => ( IH2ObjectInstance )x ).ToList(),
                scenario.sceneryPalette.Select( x => ( IH2ObjectPalette )x ).ToList() );
            LoadInstances(
                scenario.crates.Select( x => ( IH2ObjectInstance )x ).ToList(),
                scenario.cratesPalette.Select( x => ( IH2ObjectPalette )x ).ToList() );
            LoadInstances(
                scenario.weapons.Select( x => ( IH2ObjectInstance )x ).ToList(),
                scenario.weaponPalette.Select( x => ( IH2ObjectPalette )x ).ToList() );
            LoadNetgameEquipment(
                scenario.netgameEquipment.Select( x => x ).ToList() );

            Log.Info( GL.GetError().ToString() );
        }

        private void LoadNetgameEquipment( List<ScenarioNetgameEquipmentBlock> list )
        {
            foreach ( var item in list.Where( x => !TagIdent.IsNull( x.itemVehicleCollection.Ident )
                && ( x.itemVehicleCollection.Class.ToString() == "vehc" || x.itemVehicleCollection.Class.ToString() == "itmc" ) ) )
            {
                try
                {
                    Add( item.itemVehicleCollection.Ident, new ScenarioObject( Halo2.GetReferenceObject<ModelBlock>(
                    Halo2.GetReferenceObject<ObjectBlock>(
                    item.itemVehicleCollection.Class.ToString() == "itmc" ?
                    Halo2.GetReferenceObject<ItemCollectionBlock>( item.itemVehicleCollection ).itemPermutations.First().item
                    : Halo2.GetReferenceObject<VehicleCollectionBlock>( item.itemVehicleCollection ).vehiclePermutations.First().vehicle ).model ) )
                    {
                        WorldMatrix = item.WorldMatrix
                    }
                        );
                }
                catch ( NullReferenceException )
                {
                }
            }
        }

        private void LoadInstances( List<IH2ObjectInstance> instances, List<IH2ObjectPalette> objectPalette )
        {
            var join = ( from instance in instances
                         join palette in objectPalette on ( int )instance.PaletteIndex equals objectPalette.IndexOf( palette ) into gj
                         from items in gj.DefaultIfEmpty()
                         select new { instance, Object = items.ObjectReference } ).ToArray();

            foreach ( var item in join )
            {
                Add( item.Object.Ident, new ScenarioObject(
                    Halo2.GetReferenceObject<ModelBlock>( Halo2.GetReferenceObject<ObjectBlock>( item.Object ).model ) )
                {
                    WorldMatrix = item.instance.WorldMatrix
                }
                );
            }
        }

        public void Draw( Program shaderProgram )
        {
            if ( shaderProgram == null ) return;
            foreach ( var item in objectInstances.SelectMany( x => x.Value ) )
            {
                Vector4 texcoordRange = new Vector4(
                    item.Model.RenderModel.compressionInfo[ 0 ].texcoordBoundsX.Min,
                    item.Model.RenderModel.compressionInfo[ 0 ].texcoordBoundsX.Max,
                    item.Model.RenderModel.compressionInfo[ 0 ].texcoordBoundsY.Min,
                    item.Model.RenderModel.compressionInfo[ 0 ].texcoordBoundsY.Max );

                shaderProgram.Use();

                var worldMatrixAttribute = shaderProgram.GetAttributeLocation( "worldMatrix" );
                shaderProgram.SetAttribute( worldMatrixAttribute, item.WorldMatrix );

                var texcoordRangeUniform = shaderProgram.GetUniformLocation( "texcoordRangeUniform" );
                shaderProgram.SetUniform( texcoordRangeUniform, ref texcoordRange );

                item.Flags = ScenarioObject.RenderFlags.RenderMarkers;
                IRenderable @object = item;
                @object.Render( new[] { shaderProgram } );
            }
        }

        public void Draw( ProgramManager programManager )
        {
            foreach ( var batch in objectInstances.SelectMany( x => x.Value ).SelectMany( x => x.Batches ) )
            {
                var program = programManager.GetProgram( batch.Shader );
                if ( program == null ) continue;

                var usingProgram = program.Use();

                GL.BindVertexArray( batch.BatchObject.VertexArrayObjectIdent );
                foreach ( var attribute in batch.Attributes.Select( x => new { Name = x.Key, Value = x.Value } ) )
                {
                    var attributeLocation = program.GetAttributeLocation( attribute.Name );
                    program.SetAttribute( attributeLocation, attribute.Value );
                }
                foreach ( var uniform in batch.Uniforms.Select( x => new { Name = x.Key, Value = x.Value } ) )
                {
                    var uniformLocation = program.GetUniformLocation( uniform.Name );
                    program.SetUniform( uniformLocation, uniform.Value );
                }
                List<System.IDisposable> openGLStates = new List<System.IDisposable>();
                foreach ( var state in batch.RenderStates.Select( x => new { Capability = x.Key, Enabled = x.Value } ) )
                {
                    openGLStates.Add( state.Enabled ? OpenGL.Enable( state.Capability ) : OpenGL.Disable( state.Capability ) );
                }

                GL.DrawElements( batch.PrimitiveType, batch.ElementLength, batch.DrawElementsType, batch.ElementStartIndex );

                // Cleanup states
                foreach ( var state in openGLStates ) state.Dispose();
                usingProgram.Dispose();

            }
        }


        public void Add( TagIdent item )
        {
            var data = Halo2.GetReferenceObject( item );
            //objects[item] = new ScenarioObject( (ModelBlock)data );
        }

        public void Draw( TagIdent item )
        {
            if ( objectInstances.ContainsKey( item ) )
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
            this.objectInstances.Remove( item );
        }

        internal void Clear( )
        {
            this.objectInstances.Clear();
        }
    }
}
