using System;
using System.Collections.Generic;
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
        public StringID ActivePermuation { get; set; }
        public Dictionary<RenderModelMarkerBlock, MarkerWrapper> Markers;

        private ScenarioObject()
        {
            ActivePermuation = StringID.Zero;
            Nodes = new List<RenderModelNodeBlock>();
            Flags = RenderFlags.RenderMarkers | RenderFlags.RenderMesh | RenderFlags.RenderNodes;

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

            if (model.RenderModel == null) return;

            CollisionObject = new CollisionObject
            {
                UserObject = this,
                CollisionFlags = CollisionFlags.StaticObject,
                CollisionShape = new BoxShape(Model.RenderModel.compressionInfo[0].ToHalfExtents())
            };

            _collisionSpaceMatrix =
                Matrix4.CreateTranslation(Model.RenderModel.compressionInfo[0].ToObjectMatrix().ExtractTranslation());
            _worldMatrix = Matrix4.Identity;

            foreach (var section in model.RenderModel.sections)
            {
                SectionBuffers.Add(new Mesh(section.sectionData[0].section));
            }
            Nodes = new List<RenderModelNodeBlock>(model.RenderModel.nodes);
            Markers = model.RenderModel.markerGroups.SelectMany(x => x.Markers)
                .ToDictionary(x => x, x => new MarkerWrapper(x, Nodes));
        }

        public IEnumerable<RenderBatch> Batches
        {
            get
            {
                if (Flags.HasFlag(RenderFlags.RenderMesh))
                    foreach (var region in Model.RenderModel.regions)
                    {
                        var sectionIndex = region.permutations[0].l6SectionIndexHollywood;
                        var mesh = SectionBuffers[sectionIndex];

                        foreach (var part in mesh.Parts)
                        {
                            var extents = Model.RenderModel.compressionInfo[0].ToObjectMatrix();

                            var texcoordRange = new Vector4(
                                Model.RenderModel.compressionInfo[0].texcoordBoundsX.Min,
                                Model.RenderModel.compressionInfo[0].texcoordBoundsX.Max,
                                Model.RenderModel.compressionInfo[0].texcoordBoundsY.Min,
                                Model.RenderModel.compressionInfo[0].texcoordBoundsY.Max);

                            var batch = new RenderBatch
                            {
                                ElementStartIndex = part.stripStartIndex * sizeof(ushort),
                                ElementLength = part.stripLength
                            };
                            batch.AssignUniform("TexcoordRangeUniform", texcoordRange);
                            batch.AssignUniform("WorldMatrixUniform", WorldMatrix);
                            batch.AssignUniform("ObjectSpaceMatrixUniform", extents);

                            batch.Shader = new ShaderReference(
                                ShaderReference.ReferenceType.Halo2,
                                Model.RenderModel.materials[part.material].shader.Ident);

                            batch.BatchObject = mesh.TriangleBatch;

                            yield return batch;
                        }
                    }
                if (Flags.HasFlag(RenderFlags.RenderMarkers))
                {
                    var markersEnumerator = Model.RenderModel.markerGroups.SelectMany(x => x.markers).ToList();
                    var elementIndices = Enumerable.Range(0, markersEnumerator.Count).Select(Convert.ToUInt16).ToArray();

                    var positionData = new List<Vector3>();
                    foreach (var marker in markersEnumerator)
                    {
                        var nodeIndex = marker.nodeIndex;
                        var translation = marker.translation;
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
                    batch.AssignRenderState(EnableCap.DepthTest, false);
                    batch.AssignRenderState(EnableCap.VertexProgramPointSize, true);
                    batch.BatchObject = _markersBatch;
                    yield return batch;
                }
                if (Flags.HasFlag(RenderFlags.RenderNodes))
                {
                    var positionData = new List<Vector3>();

                    var elementIndices = Enumerable.Range(0, Nodes.Count).Select(x => Convert.ToUInt16(x)).ToArray();

                    foreach (var node in Nodes)
                    {
                        var transformedPosition = Vector3.Transform(node.defaultTranslation,
                            Nodes.GetWorldMatrix(node.parentNode));

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
                    batch.AssignRenderState(EnableCap.DepthTest, false);
                    batch.AssignRenderState(EnableCap.VertexProgramPointSize, true);
                    batch.BatchObject = _nodesBatch;
                    yield return batch;
                }
            }
        }

        public CollisionObject CollisionObject { get; set; }
        public RenderFlags Flags { get; set; }
        public ModelBlock Model { get; set; }
        public List<RenderModelNodeBlock> Nodes { get; private set; }

        public Matrix4 WorldMatrix
        {
            get { return _worldMatrix; }
            set
            {
                _worldMatrix = value;
                CollisionObject.WorldTransform = _collisionSpaceMatrix * value;
            }
        }

        public Matrix4 CalculateChildWorldMatrix(object value)
        {
            if (value.GetType() == typeof(RenderModelMarkerBlock))
                return CalculateWorldMatrix((RenderModelMarkerBlock)value);
            if (value.GetType() == typeof(RenderModelNodeBlock))
                return CalculateWorldMatrix((RenderModelNodeBlock)value);
            throw new InvalidCastException();
        }

        public void SetChildWorldMatrix(object nodeBlock, Matrix4 value)
        {
            if (nodeBlock.GetType() == typeof(RenderModelNodeBlock))
                SetWorldMatrix((RenderModelNodeBlock)nodeBlock, value);
            else throw new InvalidCastException();
        }

        private void SetWorldMatrix(RenderModelNodeBlock nodeBlock, Matrix4 value)
        {
            Nodes.SetWorldMatrix(nodeBlock, value);
        }

        private Matrix4 CalculateWorldMatrix(RenderModelMarkerBlock markerBlock)
        {
            if (!Model.RenderModel.markerGroups.SelectMany(x => x.Markers).Contains(markerBlock))
                throw new ArgumentOutOfRangeException();

            return markerBlock.WorldMatrix * Nodes.GetWorldMatrix(markerBlock.nodeIndex);
        }

        private Matrix4 CalculateWorldMatrix(RenderModelNodeBlock nodeBlock)
        {
            if (!Model.RenderModel.nodes.Contains(nodeBlock))
                throw new ArgumentOutOfRangeException();

            return Nodes.GetWorldMatrix(nodeBlock);
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

                collisionManager.World.ConvexSweepTest((ConvexShape)CollisionObject.CollisionShape, from, to, callback);

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
    }
}