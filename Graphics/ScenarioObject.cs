using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BulletSharp;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Moonfish.Graphics
{
    public interface IRenderable
    {
        void Render(IEnumerable<Program> shaderPasses);
    }


    public class ShaderReference
    {
        public enum ReferenceType
        {
            Halo2,
            System
        }

        public int Ident;

        public ShaderReference(ReferenceType type, int ident)
        {
            Type = type;
            Ident = ident;
        }

        public ReferenceType Type { get; set; }
    }


    public class ScenarioObject : RenderObject
    {
        [Flags]
        public enum RenderFlags
        {
            RenderMesh = 1,
            RenderMarkers = 1 << 1,
            RenderNodes = 1 << 2
        }

        private readonly Matrix4 _collisionSpaceMatrix;
        private readonly TriangleBatch _markersBatch;
        private readonly TriangleBatch _nodesBatch;
        private Matrix4 _worldMatrix;

        private ScenarioObject()
        {
            ActivePermuation = StringIdent.Zero;
            Nodes = new List<RenderModelNodeBlock>();
            Flags =  RenderFlags.RenderMesh;

            _nodesBatch = new TriangleBatch();
            using (_nodesBatch.Begin())
            {
                _nodesBatch.GenerateBuffer();
                _nodesBatch.BindBuffer(BufferTarget.ArrayBuffer, _nodesBatch.BufferIdents.Last());
                _nodesBatch.VertexAttribArray(0, 3, VertexAttribPointerType.Float);
                _nodesBatch.GenerateBuffer();
                _nodesBatch.BindBuffer(BufferTarget.ElementArrayBuffer, _nodesBatch.BufferIdents.Last());
            }
            _markersBatch = new TriangleBatch();
            using (_markersBatch.Begin())
            {
                _markersBatch.GenerateBuffer();
                _markersBatch.BindBuffer(BufferTarget.ArrayBuffer, _markersBatch.BufferIdents.Last());
                _markersBatch.VertexAttribArray(0, 3, VertexAttribPointerType.Float);
                _markersBatch.GenerateBuffer();
                _markersBatch.BindBuffer(BufferTarget.ElementArrayBuffer, _markersBatch.BufferIdents.Last());
            }
        }

        public ScenarioObject(ModelBlock model)
            : this()
        {
            Model = model;

            RenderModel = (RenderModelBlock)model.RenderModel.Get();
            if (RenderModel == null) return;

            CollisionObject = new CollisionObject
            {
                UserObject = this,
                CollisionFlags = CollisionFlags.StaticObject,
                CollisionShape = new BoxShape(RenderModel.CompressionInfo[0].ToHalfExtents())
            };

            _collisionSpaceMatrix =
                Matrix4.CreateTranslation(
                    RenderModel.CompressionInfo[0].ToObjectMatrix().ExtractTranslation());
            _worldMatrix = Matrix4.Identity;

            LoadSections(RenderModel.L3SectionGroupIndex);

            Nodes = new List<RenderModelNodeBlock>(RenderModel.Nodes);
        }

        private void LoadSections( byte sectionGroupIndex )
        {
            foreach ( var sectionBuffer in SectionBuffers )
            {
                sectionBuffer.Dispose(  );
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
                    SectionBuffers.Add( mesh );
                }
            }
        }

        public StringIdent ActivePermuation { get; set; }

        public IEnumerable<RenderBatch> Batches
        {
            get
            {
                if (Flags.HasFlag(RenderFlags.RenderMesh))
                    foreach (var renderBatch in RenderBatches()) yield return renderBatch;
                if (Flags.HasFlag(RenderFlags.RenderMarkers))
                {
                    var renderModel = (RenderModelBlock)Model.RenderModel.Get();
                    var markersEnumerator = renderModel.MarkerGroups.SelectMany(x => x.Markers).ToList();
                    var elementIndices =
                        Enumerable.Range(0, markersEnumerator.Count).Select(Convert.ToUInt16).ToArray();

                    var positionData = new List<Vector3>();
                    foreach (var marker in markersEnumerator)
                    {
                        var nodeIndex = marker.NodeIndex;
                        var translation = marker.Translation;
                        var transformedPosition = Vector3.Transform(translation, Nodes.GetWorldMatrix(nodeIndex));

                        positionData.Add(transformedPosition);
                    }
                    using (_markersBatch.Begin())
                    {
                        _markersBatch.BindBuffer(BufferTarget.ArrayBuffer, _markersBatch.BufferIdents.First());
                        _markersBatch.BufferVertexAttributeData(positionData.ToArray());
                        _markersBatch.BindBuffer(BufferTarget.ElementArrayBuffer, _markersBatch.BufferIdents.Last());
                        _markersBatch.BufferElementArrayData(elementIndices);
                    }

                    var batch = new RenderBatch
                    {
                        ElementStartIndex = 0,
                        ElementLength = elementIndices.Length,
                        PrimitiveType = PrimitiveType.Points,
                        Shader = new ShaderReference(ShaderReference.ReferenceType.System, 0)
                    };

                    batch.AssignUniform("WorldMatrixUniform", Matrix4.Identity);
                    batch.AssignAttribute("Colour", new ColorF(Color.Red).RGBA);
                    batch.BatchObject = _markersBatch;
                    yield return batch;
                }
                if (Flags.HasFlag(RenderFlags.RenderNodes))
                {
                    var positionData = new List<Vector3>();

                    var elementIndices =
                        Enumerable.Range(0, Nodes.Count).Select(x => Convert.ToUInt16(x)).ToArray();

                    foreach (var node in Nodes)
                    {
                        var transformedPosition = Vector3.Transform(node.DefaultTranslation,
                            Nodes.GetWorldMatrix(node.ParentNode));

                        positionData.Add(transformedPosition);
                    }

                    using (_nodesBatch.Begin())
                    {
                        _nodesBatch.BindBuffer(BufferTarget.ArrayBuffer, _nodesBatch.BufferIdents.First());
                        _nodesBatch.BufferVertexAttributeData(positionData.ToArray());
                        _nodesBatch.BindBuffer(BufferTarget.ElementArrayBuffer, _nodesBatch.BufferIdents.Last());
                        _nodesBatch.BufferElementArrayData(elementIndices);
                    }

                    var batch = new RenderBatch
                    {
                        ElementStartIndex = 0,
                        ElementLength = elementIndices.Length,
                        PrimitiveType = PrimitiveType.Points,
                        Shader = new ShaderReference(ShaderReference.ReferenceType.System, 0)
                    };

                    batch.AssignUniform("WorldMatrixUniform", Matrix4.Identity);
                    batch.AssignAttribute("Colour", new ColorF(Color.White).RGBA);
                    batch.BatchObject = _nodesBatch;
                    yield return batch;
                }
            }
        }

        public CollisionObject CollisionObject { get; set; }

        public RenderFlags Flags { get; set; }

        public IEnumerable<RenderModelMarkerBlock> Markers
        {
            get { return ((RenderModelBlock)Model.RenderModel.Get()).MarkerGroups.SelectMany(x => x.Markers); }
        }

        public ModelBlock Model { get; set; }
        public RenderModelBlock RenderModel { get; set; }

        [TypeConverter(typeof (ExpandableObjectConverter))]
        public List<RenderModelNodeBlock> Nodes { get; private set; }

        public Matrix4 WorldMatrix
        {
            get { return _worldMatrix; }
            set
            {
                _worldMatrix = value;
                CollisionObject.WorldTransform = _collisionSpaceMatrix*value;
            }
        }

        public Matrix4 CalculateChildWorldMatrix(object value)
        {
            if (value.GetType() == typeof (RenderModelMarkerBlock))
                return CalculateWorldMatrix((RenderModelMarkerBlock) value);
            if (value.GetType() == typeof (RenderModelNodeBlock))
                return CalculateWorldMatrix((RenderModelNodeBlock) value);
            throw new InvalidCastException();
        }

        public void OnMouseMove(CollisionManager collisionManager, Camera activeCamera,
            MouseEventArgs e)
        {
            var mouse = new
            {
                Near = activeCamera.ReProject(new Vector2(e.X, e.Y), -0.90f),
                Far = activeCamera.ReProject(new Vector2(e.X, e.Y), 1)
            };

            var from = Matrix4.CreateTranslation(mouse.Near);
            var to = Matrix4.CreateTranslation(mouse.Far);

            var d = (mouse.Far - mouse.Near).Normalized();
            using (var callback = new ClosestConvexResultCallback(mouse.Near, mouse.Far))
            {
                callback.CollisionFilterGroup = CollisionFilterGroups.StaticFilter;
                callback.CollisionFilterMask = CollisionFilterGroups.StaticFilter;

                collisionManager.World.ConvexSweepTest((ConvexShape) CollisionObject.CollisionShape, from, to,
                    callback);

                Console.WriteLine(callback.HitNormalWorld);
                if (callback.HasHit)
                {
                    Vector3 linVel, angVel;
                    TransformUtil.CalculateVelocity(from, to, 1.0f, out linVel, out angVel);
                    Matrix4 T;
                    TransformUtil.IntegrateTransform(from, linVel, angVel, callback.ClosestHitFraction, out T);

                    WorldMatrix = T;
                }
            }
        }

        public void SetChildWorldMatrix(object nodeBlock, Matrix4 value)
        {
            if (nodeBlock.GetType() == typeof (RenderModelNodeBlock))
                SetWorldMatrix((RenderModelNodeBlock) nodeBlock, value);
            else throw new InvalidCastException();
        }

        private Matrix4 CalculateWorldMatrix(RenderModelMarkerBlock markerBlock)
        {
            if (
                !((RenderModelBlock) Model.RenderModel.Get()).MarkerGroups.SelectMany(x => x.Markers)
                    .Contains(markerBlock))
                throw new ArgumentOutOfRangeException();

            return markerBlock.WorldMatrix*Nodes.GetWorldMatrix(markerBlock.NodeIndex);
        }

        private Matrix4 CalculateWorldMatrix(RenderModelNodeBlock nodeBlock)
        {
            if (!((RenderModelBlock)Model.RenderModel.Get()).Nodes.Contains(nodeBlock))
                throw new ArgumentOutOfRangeException();

            return Nodes.GetWorldMatrix(nodeBlock);
        }

        private IEnumerable<RenderBatch> RenderBatches( )
        {
            foreach ( var sectionBuffer in SectionBuffers )
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
                    for ( int i = 0; i < mesh.SectionBlock.SectionData[ 0 ].NodeMap.Length; ++i )
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

        private void SetWorldMatrix(RenderModelNodeBlock nodeBlock, Matrix4 value)
        {
            Nodes.SetWorldMatrix(nodeBlock, value);
        }
    }
}