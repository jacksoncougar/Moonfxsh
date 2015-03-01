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

    public class ProgramManager : IEnumerable<Program>
    {
        public Program SystemProgram { get { return this.Shaders[ "system" ]; } }
        Dictionary<string, Program> Shaders { get; set; }

        OpenTK.Vector3 lightPosition = new OpenTK.Vector3( 1f, 1f, 0.5f );
        int NormalMapPaletteTexture;


        public ProgramManager( )
        {
            Shaders = new Dictionary<string, Program>();
            LoadDefaultShader();
            LoadSystemShader();

        }

        private void LoadSystemShader( )
        {
            Program defaultProgram;
            var vertex_shader = new Shader( "data/sys_vertex.vert", ShaderType.VertexShader );
            var fragment_shader = new Shader( "data/sys_fragment.frag", ShaderType.FragmentShader );
            defaultProgram = new Program( "system" ); OpenGL.ReportError();
            GL.BindAttribLocation( defaultProgram.Ident, 0, "Position" ); OpenGL.ReportError();

            defaultProgram.Link( new List<Shader>( 2 ) { vertex_shader, fragment_shader } ); OpenGL.ReportError();
            Shaders[ "system" ] = defaultProgram;

        }

        private void LoadDefaultShader( )
        {
            Program defaultProgram;
            var vertex_shader = new Shader( "data/vertex.vert", ShaderType.VertexShader );
            var fragment_shader = new Shader( "data/fragment.frag", ShaderType.FragmentShader );
            defaultProgram = new Program( "shaded" ); OpenGL.ReportError();
            GL.BindAttribLocation( defaultProgram.Ident, 0, "position" ); OpenGL.ReportError();
            GL.BindAttribLocation( defaultProgram.Ident, 1, "texcoord" ); OpenGL.ReportError();
            GL.BindAttribLocation( defaultProgram.Ident, 2, "iNormal" ); OpenGL.ReportError();
            GL.BindAttribLocation( defaultProgram.Ident, 3, "iTangent" ); OpenGL.ReportError();
            GL.BindAttribLocation( defaultProgram.Ident, 4, "iBitangent" ); OpenGL.ReportError();

            //GL.BindAttribLocation(defaultProgram.ID, 3, "colour"); OpenGL.ReportError();
            defaultProgram.Link( new List<Shader>( 2 ) { vertex_shader, fragment_shader } ); OpenGL.ReportError();
            var loc = GL.GetAttribLocation( defaultProgram.Ident, "worldMatrix" );
            Shaders[ "default" ] = defaultProgram;


            LoadNormalMapPalette();

            var p8NormalColourUniform = Shaders[ "default" ].GetUniformLocation( "P8NormalColour" );
            var p8NormalMapUniform = Shaders[ "default" ].GetUniformLocation( "P8NormalMap" );
            var diffuseMapUniform = Shaders[ "default" ].GetUniformLocation( "DiffuseMap" );
            var environmentMapUniform = Shaders[ "default" ].GetUniformLocation( "EnvironmentMap" );

            Shaders[ "default" ].Use();
            Shaders[ "default" ].SetUniform( p8NormalColourUniform, 0 );
            Shaders[ "default" ].SetUniform( p8NormalMapUniform, 3 );
            Shaders[ "default" ].SetUniform( diffuseMapUniform, 1 );
            Shaders[ "default" ].SetUniform( environmentMapUniform, 2 );


        }

        private void LoadNormalMapPalette( )
        {
            NormalMapPaletteTexture = GL.GenTexture();
            GL.ActiveTexture( TextureUnit.Texture0 );
            GL.BindTexture( TextureTarget.Texture1D, NormalMapPaletteTexture );
            GL.TexParameter( TextureTarget.Texture1D, TextureParameterName.TextureWrapS, ( int )TextureWrapMode.Clamp );
            GL.TexParameter( TextureTarget.Texture1D, TextureParameterName.TextureMagFilter, ( int )TextureMagFilter.Nearest );
            GL.TexParameter( TextureTarget.Texture1D, TextureParameterName.TextureMinFilter, ( int )TextureMinFilter.Nearest );

            #region Palette Data
            byte[] H2PaletteBuffer = new byte[] {
                255, 126, 126, 255, 255, 127, 126, 255, 255, 128, 126, 255, 255, 129, 126, 255, 255, 126, 
                127, 255, 255, 127, 127, 255, 255, 128, 127, 255, 255, 129, 127, 255, 255, 126, 128, 255, 
                255, 127, 128, 255, 255, 128, 128, 255, 255, 129, 128, 255, 255, 126, 129, 255, 255, 127, 
                129, 255, 255, 128, 129, 255, 255, 129, 129, 255, 255, 130, 127, 255, 255, 127, 131, 255, 
                255, 127, 125, 255, 255, 131, 129, 255, 255, 124, 129, 255, 255, 130, 124, 255, 255, 129, 
                132, 255, 255, 124, 125, 255, 255, 133, 127, 255, 255, 125, 132, 255, 255, 128, 122, 255, 
                255, 132, 132, 255, 255, 122, 128, 255, 255, 133, 124, 255, 255, 127, 135, 255, 255, 124, 
                122, 255, 255, 136, 130, 255, 255, 121, 132, 255, 255, 131, 120, 255, 255, 132, 136, 255, 
                255, 119, 124, 255, 255, 137, 125, 255, 255, 123, 137, 255, 255, 125, 118, 255, 255, 137, 
                134, 255, 255, 117, 130, 255, 255, 135, 119, 255, 255, 129, 140, 255, 255, 119, 120, 255, 
                255, 141, 128, 255, 255, 119, 137, 255, 255, 129, 115, 255, 255, 136, 139, 255, 255, 114, 
                126, 255, 255, 140, 120, 255, 255, 124, 142, 255, 255, 121, 115, 255, 255, 142, 133, 255, 
                255, 113, 134, 255, 254, 135, 113, 255, 254, 133, 144, 255, 254, 113, 120, 255, 254, 145, 
                124, 255, 254, 118, 142, 255, 254, 126, 110, 255, 254, 142, 140, 255, 254, 109, 129, 255, 
                254, 142, 114, 255, 254, 127, 147, 255, 254, 115, 113, 255, 254, 148, 131, 255, 254, 111, 
                140, 255, 254, 133, 107, 255, 254, 139, 147, 255, 254, 107, 121, 255, 254, 148, 119, 255, 
                253, 119, 149, 255, 253, 120, 106, 255, 253, 149, 139, 255, 253, 105, 134, 255, 253, 141, 
                108, 255, 253, 132, 152, 255, 253, 108, 113, 255, 253, 153, 126, 255, 253, 111, 147, 255, 
                253, 128, 102, 255, 253, 146, 147, 255, 253, 101, 126, 255, 253, 150, 111, 255, 252, 123, 
                155, 255, 252, 113, 104, 255, 252, 155, 135, 255, 252, 103, 141, 255, 252, 138, 101, 255, 
                252, 139, 155, 255, 252, 101, 115, 255, 252, 157, 119, 255, 252, 113, 155, 255, 252, 121, 
                98, 255, 252, 154, 146, 255, 251, 96, 132, 255, 251, 149, 103, 255, 251, 129, 161, 255, 
                251, 105, 105, 255, 251, 161, 129, 255, 251, 102, 150, 255, 251, 132, 94, 255, 251, 148, 
                156, 255, 251, 94, 120, 255, 251, 159, 110, 255, 250, 117, 162, 255, 250, 113, 95, 255, 
                250, 162, 142, 255, 250, 93, 141, 255, 250, 145, 95, 255, 250, 138, 164, 255, 250, 96, 
                108, 255, 250, 166, 121, 255, 249, 104, 159, 255, 249, 125, 89, 255, 249, 157, 155, 255, 
                249, 88, 128, 255, 249, 158, 101, 255, 249, 124, 169, 255, 249, 103, 95, 255, 248, 169, 
                135, 255, 248, 92, 151, 255, 248, 139, 87, 255, 248, 148, 166, 255, 248, 87, 113, 255, 
                248, 168, 111, 255, 248, 109, 168, 255, 247, 115, 86, 255, 247, 167, 150, 255, 247, 84, 
                138, 255, 247, 154, 91, 255, 247, 134, 174, 255, 247, 92, 98, 255, 247, 175, 126, 255, 
                246, 94, 162, 255, 246, 130, 80, 255, 246, 159, 165, 255, 246, 80, 122, 255, 246, 168, 
                100, 255, 246, 117, 176, 255, 245, 103, 85, 255, 245, 176, 143, 255, 245, 82, 149, 255, 
                245, 148, 81, 255, 245, 146, 176, 255, 244, 82, 104, 255, 244, 178, 114, 255, 244, 100, 
                172, 255, 244, 119, 76, 255, 244, 170, 161, 255, 244, 74, 133, 255, 243, 165, 88, 255, 
                243, 128, 183, 255, 243, 91, 87, 255, 243, 183, 133, 255, 243, 84, 162, 255, 242, 138, 
                73, 255, 242, 158, 176, 255, 242, 73, 113, 255, 242, 179, 101, 255, 242, 108, 182, 255, 
                241, 106, 74, 255, 241, 181, 153, 255, 241, 72, 146, 255, 241, 158, 76, 255, 240, 141, 
                187, 255, 240, 79, 93, 255, 240, 188, 120, 255, 240, 89, 175, 255, 240, 125, 66, 255, 
                239, 172, 172, 255, 239, 66, 125, 255, 239, 176, 88, 255, 239, 120, 191, 255, 238, 92, 
                76, 255, 238, 191, 142, 255, 238, 72, 160, 255, 238, 148, 66, 255, 237, 156, 187, 255, 
                237, 67, 103, 255, 237, 190, 105, 255, 237, 97, 187, 255, 237, 111, 63, 255, 236, 185, 
                164, 255, 236, 61, 140, 255, 236, 170, 74, 255, 235, 134, 196, 255, 235, 77, 81, 255, 
                235, 197, 128, 255, 235, 77, 175, 255, 234, 134, 58, 255, 234, 171, 184, 255, 234, 58, 
                116, 255, 234, 188, 90, 255, 233, 109, 197, 255, 233, 95, 64, 255, 233, 196, 153, 255, 
                233, 61, 156, 255, 232, 159, 62, 255, 232, 150, 198, 255, 232, 64, 91, 255, 231, 201, 
                112, 255, 231, 85, 189, 255, 231, 118, 53, 255, 231, 186, 177, 255, 230, 52, 131, 255, 
                230, 182, 74, 255, 230, 125, 205, 255, 229, 78, 69, 255, 229, 205, 138, 255, 229, 64, 
                173, 255, 228, 145, 51, 255, 228, 167, 196, 255, 228, 52, 104, 255, 227, 200, 94, 255, 
                227, 97, 202, 255, 227, 101, 52, 255, 227, 200, 165, 255, 226, 49, 149, 255, 226, 172, 
                59, 255, 226, 142, 209, 255, 225, 63, 78, 255, 225, 211, 121, 255, 225, 72, 189, 255, 
                224, 128, 44, 255, 224, 185, 190, 255, 224, 44, 121, 255, 223, 195, 76, 255, 223, 113, 
                212, 255, 223, 82, 56, 255, 222, 211, 150, 255, 222, 51, 168, 255, 221, 158, 47, 255, 
                221, 161, 209, 255, 221, 49, 91, 255, 220, 212, 102, 255, 220, 84, 204, 255, 220, 109, 
                41, 255, 219, 201, 179, 255, 219, 39, 140, 255, 219, 186, 59, 255, 218, 132, 218, 255, 
                218, 64, 64, 255, 217, 219, 132, 255, 217, 58, 187, 255, 217, 140, 37, 255, 216, 181, 
                203, 255, 216, 38, 108, 255, 216, 208, 82, 255, 215, 100, 217, 255, 215, 89, 43, 255, 
                214, 215, 164, 255, 214, 39, 160, 255, 214, 172, 44, 255, 255, 128, 128, 0, };
            #endregion

            GL.TexImage1D( TextureTarget.Texture1D, 0, PixelInternalFormat.Rgba8, 256, 0, PixelFormat.Bgra, PixelType.UnsignedByte, H2PaletteBuffer );
        }

        public void BindNormalMapPaletteTexture( TextureUnit target = TextureUnit.Texture0 )
        {
            GL.ActiveTexture( target );
            GL.BindTexture( TextureTarget.Texture1D, NormalMapPaletteTexture );
        }

        public Program GetProgram( ShaderReference reference )
        {
            switch ( reference.Type )
            {
                case ShaderReference.ReferenceType.Halo2: return this.Shaders[ "default" ];
                case ShaderReference.ReferenceType.System: return this.Shaders[ "system" ];
            }
            return null;
        }

        public IEnumerator<Program> GetEnumerator( )
        {
            return this.Shaders.Select( x => x.Value ).GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator( )
        {
            return this.GetEnumerator();
        }
    };

    public class MeshManager
    {
        CollisionManager Collision { get; set; }
        ScenarioBlock scenario;
        Program old_program;
        Program systemProgram;
        Dictionary<TagIdent, List<ScenarioObject>> objectInstances;

        public IEnumerable<ScenarioObject> this[ TagIdent ident ]
        {
            get { return objectInstances[ ident ]; }
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

        IEnumerable<RenderBatch> batchbuffer;
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
