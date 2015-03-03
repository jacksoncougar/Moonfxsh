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

    public interface IRenderable
    {
        void Render( IEnumerable<Program> shaderPasses );
    }


    public class ShaderReference
    {
        public ReferenceType Type { get; set; }
        public int Ident;
        public enum ReferenceType
        {
            Halo2,
            System,
        }

        public ShaderReference( ReferenceType type, int ident )
        {
            this.Type = type;
            this.Ident = ident;
        }
    }

    public class RenderBatch
    {
        public ShaderReference Shader { get; set; }
        public Batch BatchObject { get; set; }
        public PrimitiveType PrimitiveType { get; set; }
        public DrawElementsType DrawElementsType { get; set; }
        public int ElementStartIndex { get; set; }
        public int ElementLength { get; set; }
        public Dictionary<string, dynamic> Attributes { get; private set; }
        public Dictionary<string, dynamic> Uniforms { get; private set; }
        public Dictionary<EnableCap, bool> RenderStates { get; private set; }

        public RenderBatch( )
            : this( 0, 0, 0 )
        {
        }

        public RenderBatch( int attributeCount, int uniformCount, int stateCount )
        {
            this.Shader = new ShaderReference( ShaderReference.ReferenceType.System, 0 );
            this.Attributes = new Dictionary<string, object>( attributeCount );
            this.Uniforms = new Dictionary<string, object>( uniformCount );
            this.RenderStates = new Dictionary<EnableCap, bool>( stateCount );
            this.PrimitiveType = PrimitiveType.TriangleStrip;
            this.DrawElementsType = DrawElementsType.UnsignedShort;
        }

        public void AssignAttribute( string attributeName, dynamic value )
        {
            this.Attributes[ attributeName ] = value;
        }

        public void AssignUniform( string uniformName, dynamic value )
        {
            this.Uniforms[ uniformName ] = value;
        }

        public void AssignRenderState( EnableCap state, bool value )
        {
            this.RenderStates[ state ] = value;
        }
    }


    public class ScenarioObject : RenderObject
    {
        public ModelBlock Model { get; set; }
        public CollisionObject CollisionObject { get; set; }
        public Matrix4 WorldMatrix
        {
            get { return worldMatrix; }
            set { worldMatrix = value; CollisionObject.WorldTransform = collisionSpaceMatrix * value; }
        }
        public NodeCollection Nodes { get; private set; }
        public Dictionary<RenderModelMarkerBlock, MarkerWrapper> Markers;
        public StringID activePermuation;

        [Flags]
        public enum RenderFlags
        {
            RenderMesh = 1,
            RenderMarkers = 1 << 1,
            RenderNodes = 1 << 2,
        }

        public RenderFlags Flags { get; set; }

        public bool Selected { get; set; }

        private Matrix4 worldMatrix;
        private Matrix4 collisionSpaceMatrix;

        private Batch NodesBatch;
        private Batch MarkersBatch;

        IList<object> selectedObjects;

        public ScenarioObject( )
            : base()
        {
            activePermuation = StringID.Zero;
            selectedObjects = new List<object>();
            Nodes = new NodeCollection();
            Selected = false;
            Flags = RenderFlags.RenderMarkers;

            NodesBatch = new Batch();
            using ( NodesBatch.Begin() )
            {
                NodesBatch.GenerateBuffer();
                NodesBatch.BindBuffer( BufferTarget.ArrayBuffer, NodesBatch.BufferIdents.Last() );
                NodesBatch.VertexAttribArray( 0, 3, VertexAttribPointerType.Float );
                NodesBatch.GenerateBuffer();
                NodesBatch.BindBuffer( BufferTarget.ElementArrayBuffer, NodesBatch.BufferIdents.Last() );
            }
            MarkersBatch = new Batch();
            using ( MarkersBatch.Begin() )
            {
                MarkersBatch.GenerateBuffer();
                MarkersBatch.BindBuffer( BufferTarget.ArrayBuffer, MarkersBatch.BufferIdents.Last() );
                MarkersBatch.VertexAttribArray( 0, 3, VertexAttribPointerType.Float );
                MarkersBatch.GenerateBuffer();
                MarkersBatch.BindBuffer( BufferTarget.ElementArrayBuffer, MarkersBatch.BufferIdents.Last() );
            }

        }

        public IEnumerable<RenderBatch> Batches
        {
            get
            {
                if ( this.Flags.HasFlag( RenderFlags.RenderMesh ) )
                    foreach ( var region in Model.RenderModel.regions )
                    {
                        var section_index = region.permutations[ 0 ].l6SectionIndexHollywood;
                        var mesh = sectionBuffers[ section_index ];
                        using ( mesh.Bind() )
                        {
                            foreach ( var part in mesh.Parts )
                            {
                                var extents = Model.RenderModel.compressionInfo[ 0 ].ToObjectMatrix();
                                var colour = Selected ? new ColorF( Color.Yellow ).RGBA : new ColorF( Color.LightCoral ).RGBA;

                                var texcoordRange = new Vector4(
                                       Model.RenderModel.compressionInfo[ 0 ].texcoordBoundsX.Min,
                                       Model.RenderModel.compressionInfo[ 0 ].texcoordBoundsX.Max,
                                       Model.RenderModel.compressionInfo[ 0 ].texcoordBoundsY.Min,
                                       Model.RenderModel.compressionInfo[ 0 ].texcoordBoundsY.Max );

                                RenderBatch batch = new RenderBatch()
                                {
                                    ElementStartIndex = part.stripStartIndex * sizeof( ushort ),
                                    ElementLength = part.stripLength
                                };
                                batch.AssignAttribute( "colour", colour );

                                batch.AssignUniform( "TexcoordRangeUniform", texcoordRange );
                                batch.AssignUniform( "WorldMatrixUniform", this.WorldMatrix );
                                batch.AssignUniform( "ObjectSpaceMatrixUniform", extents );

                                batch.Shader = new ShaderReference(
                                    ShaderReference.ReferenceType.Halo2,
                                    Model.RenderModel.materials[ ( short )part.material ].shader.Ident );

                                batch.BatchObject = mesh.GetBatch();

                                yield return batch;
                            }
                        }
                    }
                if ( this.Flags.HasFlag( RenderFlags.RenderMarkers ) )
                {
                    List<Vector3> positionData = new List<Vector3>();
                    List<ColorF> colourData = new List<ColorF>();

                    var markersEnumerator = Model.RenderModel.markerGroups.SelectMany( x => x.markers );
                    ushort[] elementIndices = Enumerable.Range( 0, markersEnumerator.Count() ).Select( x => Convert.ToUInt16( x ) ).ToArray();

                    foreach ( var marker in markersEnumerator )
                    {
                        var nodeIndex = marker.nodeIndex;
                        var translation = marker.translation;
                        var rotation = marker.rotation;
                        var scale = marker.scale;

                        var transformedPosition = Vector3.Transform( translation, this.Nodes.GetWorldMatrix( nodeIndex ) );

                        var colour = selectedObjects.Contains( marker ) ? new ColorF( Color.Yellow ) : new ColorF( Color.White );

                        positionData.Add( transformedPosition );
                        colourData.Add( colour );
                    }
                    using ( MarkersBatch.Begin() )
                    {
                        MarkersBatch.BindBuffer( BufferTarget.ArrayBuffer, MarkersBatch.BufferIdents.First() );
                        MarkersBatch.BufferVertexAttributeData<Vector3>( positionData.ToArray() );
                        MarkersBatch.BindBuffer( BufferTarget.ElementArrayBuffer, MarkersBatch.BufferIdents.Last() );
                        MarkersBatch.BufferElementArrayData( elementIndices );
                    }

                    RenderBatch batch = new RenderBatch()
                    {
                        ElementStartIndex = 0,
                        ElementLength = elementIndices.Length,
                        PrimitiveType = PrimitiveType.Points,
                    };

                    batch.Shader = new ShaderReference( ShaderReference.ReferenceType.System, 0 );
                    batch.AssignUniform( "WorldMatrixUniform", Matrix4.Identity );
                    batch.AssignAttribute( "Colour", new ColorF( Color.Red ).RGBA );
                    batch.AssignRenderState( EnableCap.DepthTest, false );
                    batch.AssignRenderState( EnableCap.VertexProgramPointSize, true );
                    batch.BatchObject = MarkersBatch;
                    yield return batch;
                }
                if ( this.Flags.HasFlag( RenderFlags.RenderNodes ) )
                {
                    List<Vector3> positionData = new List<Vector3>();

                    var markersEnumerator = Model.RenderModel.markerGroups.SelectMany( x => x.markers );
                    ushort[] elementIndices = Enumerable.Range( 0, Nodes.Count ).Select( x => Convert.ToUInt16( x ) ).ToArray();

                    foreach ( var node in Nodes )
                    {
                        var transformedPosition = Vector3.Transform( node.defaultTranslation, this.Nodes.GetWorldMatrix( ( short )node.parentNode ) );

                        positionData.Add( transformedPosition );
                    }

                    using ( NodesBatch.Begin() )
                    {
                        NodesBatch.BindBuffer( BufferTarget.ArrayBuffer, NodesBatch.BufferIdents.First() );
                        NodesBatch.BufferVertexAttributeData<Vector3>( positionData.ToArray() );
                        NodesBatch.BindBuffer( BufferTarget.ElementArrayBuffer, NodesBatch.BufferIdents.Last() );
                        NodesBatch.BufferElementArrayData( elementIndices );
                    }

                    RenderBatch batch = new RenderBatch()
                    {
                        ElementStartIndex = 0,
                        ElementLength = elementIndices.Length,
                        PrimitiveType = PrimitiveType.Points,
                    };

                    batch.Shader = new ShaderReference( ShaderReference.ReferenceType.System, 0 );
                    batch.AssignUniform( "WorldMatrixUniform", Matrix4.Identity );
                    batch.AssignAttribute( "Colour", new ColorF( Color.White ).RGBA );
                    batch.AssignRenderState( EnableCap.DepthTest, false );
                    batch.AssignRenderState( EnableCap.VertexProgramPointSize, true );
                    batch.BatchObject = NodesBatch;
                    yield return batch;
                }
            }
        }

        public ScenarioObject( ModelBlock model )
            : this()
        {
            this.Model = model;

            if ( model.RenderModel == null ) return;

            this.CollisionObject = new CollisionObject()
            {
                UserObject = this,
                CollisionFlags = CollisionFlags.StaticObject,
                CollisionShape = new BoxShape( this.Model.RenderModel.compressionInfo[ 0 ].ToHalfExtents() )
            };

            collisionSpaceMatrix = Matrix4.CreateTranslation( this.Model.RenderModel.compressionInfo[ 0 ].ToObjectMatrix().ExtractTranslation() );
            worldMatrix = Matrix4.Identity;

            foreach ( var section in model.RenderModel.sections )
            {
                base.sectionBuffers.Add( new Mesh( section.sectionData[ 0 ].section ) );
            }
            this.Nodes = new NodeCollection( model.RenderModel.nodes );
            this.Markers = model.RenderModel.markerGroups.SelectMany( x => x.Markers ).ToDictionary( x => x, x => new MarkerWrapper( x, this.Nodes ) );
        }

        internal void Select( IEnumerable<object> collection )
        {
            selectedObjects.Clear();
            foreach ( var item in collection )
            {
                selectedObjects.Add( item );
            }
        }

        //IEnumerator<BulletSharp.CollisionObject> IEnumerable<BulletSharp.CollisionObject>.GetEnumerator()
        //{

        //    foreach (var markerGroup in Model.RenderModel.markerGroups)
        //    {
        //        foreach (var marker in markerGroup.markers)
        //        {
        //            var collisionObject = new BulletSharp.CollisionObject();
        //            collisionObject.CollisionShape = new BulletSharp.BoxShape(0.045f);
        //            collisionObject.WorldTransform = Matrix4.CreateTranslation(marker.translation) * this.Nodes.GetWorldMatrix(marker.nodeIndex);
        //            collisionObject.UserObject = this.Markers[marker];
        //            yield return collisionObject;

        //            var setPropertyMethodInfo = typeof(BulletSharp.CollisionObject).GetProperty("WorldTransform").GetSetMethod();
        //            var setProperty = Delegate.CreateDelegate(typeof(Action<Matrix4>), collisionObject, setPropertyMethodInfo);

        //            this.Markers[marker].MarkerUpdatedCallback += (Action<Matrix4>)setProperty;
        //        }
        //    }
        //}

        //System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        //{
        //    return null;
        //}

        public void OnMouseMove( CollisionManager CollisionManager, Camera ActiveCamera, System.Windows.Forms.MouseEventArgs e )
        {
            var mouse = new
            {
                Near = ActiveCamera.Project( new Vector2( e.X, e.Y ), depth: -0.90f ),
                Far = ActiveCamera.Project( new Vector2( e.X, e.Y ), depth: 1 )
            };

            Matrix4 from = Matrix4.CreateTranslation( mouse.Near );
            Matrix4 to = Matrix4.CreateTranslation( mouse.Far );

            var d = ( mouse.Far - mouse.Near ).Normalized();
            using ( var callback = new CollisionWorld.ClosestConvexResultCallback( mouse.Near, mouse.Far ) )
            {

                callback.CollisionFilterGroup = CollisionFilterGroups.StaticFilter;
                callback.CollisionFilterMask = CollisionFilterGroups.StaticFilter;

                CollisionManager.World.ConvexSweepTest( ( ConvexShape )CollisionObject.CollisionShape, from, to, callback );

                var lookingNormal = ( callback.ConvexToWorld - callback.ConvexFromWorld ).Normalized();
                var dot = Vector3.Dot( callback.HitNormalWorld, lookingNormal );
                Console.WriteLine( callback.HitNormalWorld );
                if ( callback.HasHit )
                {
                    if ( !this.Selected ) return;
                    var matrix = this.WorldMatrix.ClearTranslation();
                    var collMtrix = this.Model.RenderModel.compressionInfo[ 0 ].ToObjectMatrix();

                    Vector3 linVel, angVel;
                    TransformUtil.CalculateVelocity( from, to, 1.0f, out linVel, out angVel );
                    Matrix4 T;
                    TransformUtil.IntegrateTransform( from, linVel, angVel, callback.ClosestHitFraction, out T );

                    this.WorldMatrix = T;
                }

            }
        }

        internal void UpdateWorldMatrix( object sender, MatrixChangedEventArgs e )
        {
            this.WorldMatrix = e.Matrix;
        }
    }
}
