using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using BulletSharp;
using Moonfish.Graphics.Input;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Moonfish.Graphics
{
    public class ScenarioObject : RenderObject
    {
        [Flags]
        public enum RenderFlags
        {
            RenderMesh = 1,
            RenderMarkers = 1 << 1,
            RenderNodes = 1 << 2
        }

        public readonly Matrix4 collisionSpaceMatrix;
        private readonly VertexArrayObject _markersBatch;
        private readonly VertexArrayObject _nodesBatch;
        private Matrix4 _worldMatrix;
        private CacheKey _key;

        private ScenarioObject( )
        {
            ActivePermuation = StringIdent.Zero;
            Nodes = new List<RenderModelNodeBlock>( );
            Flags = RenderFlags.RenderMesh;

            _nodesBatch = new VertexArrayObject( );
            using ( _nodesBatch.Begin( ) )
            {
                _nodesBatch.GenerateBuffer( );
                _nodesBatch.BindBuffer( BufferTarget.ArrayBuffer, _nodesBatch.BufferIdents.Last( ) );
                _nodesBatch.VertexAttribArray( 0, 3, VertexAttribPointerType.Float );
                _nodesBatch.GenerateBuffer( );
                _nodesBatch.BindBuffer( BufferTarget.ElementArrayBuffer, _nodesBatch.BufferIdents.Last( ) );
            }
            _markersBatch = new VertexArrayObject( );
            using ( _markersBatch.Begin( ) )
            {
                _markersBatch.GenerateBuffer( );
                _markersBatch.BindBuffer( BufferTarget.ArrayBuffer, _markersBatch.BufferIdents.Last( ) );
                _markersBatch.VertexAttribArray( 0, 3, VertexAttribPointerType.Float );
                _markersBatch.GenerateBuffer( );
                _markersBatch.BindBuffer( BufferTarget.ElementArrayBuffer, _markersBatch.BufferIdents.Last( ) );
            }
        }

        public ScenarioObject( ModelBlock model )
            : this(  )
        {
            Model = model;
            if ( !model.TryGetCacheKey( out _key ) ) return;

            RenderModel = ( RenderModelBlock ) model.RenderModel.Get(_key);

            if ( RenderModel == null )
            {

                CollisionObject = new ClickableCollisionObject
                {
                    UserObject = this,
                    CollisionFlags = CollisionFlags.StaticObject,
                    CollisionShape = new BoxShape( 0 )
                };
                return;
            }
            else
            {
                CollisionObject = new ClickableCollisionObject
                {
                    UserObject = this,
                    CollisionFlags = CollisionFlags.StaticObject,
                    CollisionShape = new BoxShape( RenderModel.CompressionInfo[ 0 ].ToHalfExtents( ) )
                };
            }

            collisionSpaceMatrix =
                Matrix4.CreateTranslation(
                    RenderModel.CompressionInfo[ 0 ].ToObjectMatrix( ).ExtractTranslation( ) );
            _worldMatrix = Matrix4.Identity;

            LoadSections(5);
            RenderBatches = GetRenderBatches();

            Nodes = new List<RenderModelNodeBlock>( RenderModel.Nodes );
        }

        public List<RenderBatch> RenderBatches { get; private set; }

        public void AssignInstanceMatrices( Matrix4[] instanceWorldMatrices )
        {
            new List<Matrix4>( instanceWorldMatrices );
            InstanceBasisMatrices =
                new List<Matrix4>( Enumerable.Repeat( Matrix4.Identity, instanceWorldMatrices.Length ) );
            InstanceRotations = new List<Quaternion>( instanceWorldMatrices.Length );
            InstancePositions = new List<Vector3>( instanceWorldMatrices.Length );
            foreach ( var instanceWorldMatrix in instanceWorldMatrices )
            {
                InstanceRotations.Add( instanceWorldMatrix.ExtractRotation( ) );
                InstancePositions.Add( instanceWorldMatrix.ExtractTranslation( ) );
            }
            RenderBatches = GetRenderBatches( );
        }

        public StringIdent ActivePermuation { get; set; }

        public CollisionObject CollisionObject { get; set; }
        public RenderFlags Flags { get; set; }

        public IEnumerable<RenderModelMarkerBlock> Markers { get; }

        public ModelBlock Model { get; set; }

        [TypeConverter( typeof ( ExpandableObjectConverter ) )]
        public List<RenderModelNodeBlock> Nodes { get; private set; }

        public RenderModelBlock RenderModel { get; set; }

        public Matrix4 WorldMatrix
        {
            get { return _worldMatrix; }
            set
            {
                _worldMatrix = value;
                CollisionObject.WorldTransform = collisionSpaceMatrix * value;
            }
        }

        public Matrix4 CalculateChildWorldMatrix( object value )
        {
            if ( value.GetType( ) == typeof ( RenderModelMarkerBlock ) )
                return CalculateWorldMatrix( ( RenderModelMarkerBlock ) value );
            if ( value.GetType( ) == typeof ( RenderModelNodeBlock ) )
                return CalculateWorldMatrix( ( RenderModelNodeBlock ) value );
            throw new InvalidCastException( );
        }

        public void SetChildWorldMatrix( object nodeBlock, Matrix4 value )
        {
            if ( nodeBlock.GetType( ) == typeof ( RenderModelNodeBlock ) )
                SetWorldMatrix( ( RenderModelNodeBlock ) nodeBlock, value );
            else throw new InvalidCastException( );
        }

        private Matrix4 CalculateWorldMatrix( RenderModelMarkerBlock markerBlock )
        {
            if (
                !( ( RenderModelBlock ) Model.RenderModel.Get(_key) ).MarkerGroups.SelectMany( x => x.Markers )
                    .Contains( markerBlock ) )
                throw new ArgumentOutOfRangeException( );

            return markerBlock.WorldMatrix * Nodes.GetWorldMatrix( markerBlock.NodeIndex );
        }

        private Matrix4 CalculateWorldMatrix( RenderModelNodeBlock nodeBlock )
        {
            if ( !( ( RenderModelBlock ) Model.RenderModel.Get(_key) ).Nodes.Contains( nodeBlock ) )
                throw new ArgumentOutOfRangeException( );

            return Nodes.GetWorldMatrix( nodeBlock );
        }

        private void LoadSections( byte sectionGroupIndex )
        {
            foreach ( var sectionBuffer in sectionBuffers )
            {
                sectionBuffer.Dispose( );
            }
            foreach ( var renderModelRegionBlock in RenderModel.Regions )
            {
                foreach ( var renderModelPermutationBlock in renderModelRegionBlock.Permutations )
                {
                    RenderModelSectionBlock section;
                    switch ( sectionGroupIndex )
                    {
                        case 0:
                            section = RenderModel.Sections[ renderModelPermutationBlock.L1SectionIndex ];
                            break;
                        case 1:
                            section = RenderModel.Sections[ renderModelPermutationBlock.L2SectionIndex ];
                            break;
                        case 2:
                            section = RenderModel.Sections[ renderModelPermutationBlock.L3SectionIndex ];
                            break;
                        case 3:
                            section = RenderModel.Sections[ renderModelPermutationBlock.L4SectionIndex ];
                            break;
                        case 4:
                            section = RenderModel.Sections[ renderModelPermutationBlock.L5SectionIndex ];
                            break;
                        case 5:
                            section = RenderModel.Sections[ renderModelPermutationBlock.L6SectionIndex ];
                            break;
                        default:
                            continue;
                    }

                    section.LoadSectionData( );
                    var mesh = new Mesh( section.SectionData[ 0 ].Section, RenderModel.CompressionInfo[ 0 ] )
                    {
                        SectionBlock = section
                    };
                    sectionBuffers.Add( mesh );
                }
            }
        }

        private unsafe List<RenderBatch> GetRenderBatches()
        {
            var collectionBatches =
                new List<RenderBatch>(sectionBuffers.SelectMany(x => x.Parts).Count());

            foreach (var sectionBuffer in sectionBuffers)
            {
                var mesh = sectionBuffer;

                foreach (var part in mesh.Parts)
                {
                    var batch = new RenderBatch
                    {
                        ElementStartIndex = part.StripStartIndex * sizeof(ushort),
                        ElementLength = part.StripLength,
                        Shader = new ShaderReference(
                            ShaderReference.ReferenceType.Halo2,
                            (int)RenderModel.Materials[part.Material].Shader.Ident),
                        PrimitiveType = PrimitiveType.TriangleStrip,
                        BatchObject = mesh.TriangleBatch
                    };
                    var texcoordRange = RenderModel.CompressionInfo[0].ExtractTexcoordScaling();
                    batch.AssignUniform("TexcoordRangeUniform", texcoordRange);
                    batch.AssignUniform("WorldMatrixUniform", WorldMatrix);

                    if (InstanceBasisMatrices != null && InstanceBasisMatrices.Count > 0)
                    {
                        using (batch.BatchObject.Begin())
                        {

                            batch.BatchObject.BindBuffer(BufferTarget.ArrayBuffer,
                                batch.BatchObject.GetOrGenerateBuffer("instance data"));
                            batch.InstanceCount = InstanceBasisMatrices.Count;
                            batch.BatchObject.BufferVertexAttributeData(GetInstanceMatrices(), BufferUsageHint.StreamDraw);

                            var stride = sizeof(Matrix4);
                            var sizeOfVector4 = sizeof(Vector4);
                            batch.BatchObject.VertexAttribArray(8, 4, VertexAttribPointerType.Float, false, stride,
                                sizeOfVector4 * 0);
                            batch.BatchObject.VertexAttribArray(9, 4, VertexAttribPointerType.Float, false, stride,
                                sizeOfVector4 * 1);
                            batch.BatchObject.VertexAttribArray(10, 4, VertexAttribPointerType.Float, false, stride,
                                sizeOfVector4 * 2);
                            batch.BatchObject.VertexAttribArray(11, 4, VertexAttribPointerType.Float, false, stride,
                                sizeOfVector4 * 3);

                            batch.BatchObject.VertexAttribDivisor(8, 1);
                            batch.BatchObject.VertexAttribDivisor(9, 1);
                            batch.BatchObject.VertexAttribDivisor(10, 1);
                            batch.BatchObject.VertexAttribDivisor(11, 1);
                        }
                    }
                    collectionBatches.Add(batch);
                }
            }
            return collectionBatches;
        }

        private Matrix4[] GetInstanceMatrices( )
        {
            Matrix4[] matrices = new Matrix4[InstanceBasisMatrices.Count];
            for ( int i = 0; i < matrices.Length; i++ )
            {
                matrices[ i ] = GetInstanceMatrix( i );
            }
            return matrices;
        }

        public Matrix4 GetInstanceMatrix( int instance )
        {
            return InstanceBasisMatrices[ instance ] * Matrix4.CreateFromQuaternion( InstanceRotations[ instance ] ) *
                   Matrix4.CreateTranslation( InstancePositions[ instance ] );
        }


        public List<Matrix4> InstanceBasisMatrices { get; set; }
        public List<Quaternion> InstanceRotations { get; set; }
        public List<Vector3> InstancePositions { get; set; }

        private IEnumerable<RenderBatch> _RenderBatches( )
        {
            foreach ( var sectionBuffer in sectionBuffers )
            {
                var mesh = sectionBuffer;

                foreach ( var part in mesh.Parts )
                {
                    var texcoordRange = RenderModel.CompressionInfo[ 0 ].ExtractTexcoordScaling( );

                    var batch = new RenderBatch
                    {
                        ElementStartIndex = part.StripStartIndex * sizeof ( ushort ),
                        ElementLength = part.StripLength
                    };

                    batch.AssignUniform( "TexcoordRangeUniform", texcoordRange );
                    batch.AssignUniform( "WorldMatrixUniform", WorldMatrix );
                    for ( var i = 0; i < mesh.SectionBlock.SectionData[ 0 ].NodeMap.Length; ++i )
                    {
                        var inverseBindPoseMatrix =
                            Nodes.GetInverseBindPoseTransfrom( mesh.SectionBlock.SectionData[ 0 ].NodeMap[ i ].NodeIndex );
                        var poseMatrix =
                            Nodes.GetPoseTransfrom( mesh.SectionBlock.SectionData[ 0 ].NodeMap[ i ].NodeIndex );
                        var final = inverseBindPoseMatrix * poseMatrix;

                        batch.AssignUniform( string.Format( "BoneMatrices[{0}]", i ), final );
                    }

                    batch.Shader = new ShaderReference(
                        ShaderReference.ReferenceType.Halo2,
                        ( int ) RenderModel.Materials[ part.Material ].Shader.Ident );
                    batch.PrimitiveType = PrimitiveType.TriangleStrip;
                    batch.BatchObject = mesh.TriangleBatch;

                    yield return batch;
                }
            }
        }

        private void SetWorldMatrix( RenderModelNodeBlock nodeBlock, Matrix4 value )
        {
            Nodes.SetWorldMatrix( nodeBlock, value );
        }

        /// <summary>
        /// Updates the matrices for each instance.
        /// </summary>
        public void Update( )
        {
           // RenderBatches = GetRenderBatches();
        }

        public void AssignInstanceBasisTransform(int instance, Matrix4 basisMatrix4)
        {
            InstanceBasisMatrices[instance] = basisMatrix4;
        }

        public void AddInstance( Matrix4 instanceWorldMatrix )
        {
            InstanceBasisMatrices.Add( Matrix4.Identity );
            InstancePositions.Add( instanceWorldMatrix.ExtractTranslation(  ) );
            InstanceRotations.Add( instanceWorldMatrix.ExtractRotation(  ) );
        }
    }

    class ScenarioObjectAxisAlignedWrapper
    {
        private readonly ScenarioObject _scenarioObject;
        private float _axisAlignedRotation;

        public void SetAxisAlignedRotation(int instance, float value)
        {
                _axisAlignedRotation = value;
               // var upAxis = _scenarioObject.InstanceBasisMatrices[instance].Row2.Xyz.Normalized();
                //_scenarioObject.InstanceRotations[instance] = Quaternion.FromAxisAngle(upAxis, _axisAlignedRotation);
        }

        public ScenarioObjectAxisAlignedWrapper( ObjectBlock scenarioObject )
        {
           // _scenarioObject = scenarioObject;
        }
    }
}