using BulletSharp;
using Moonfish.Collision;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;
using OpenTK;
using OpenTK.Graphics.ES30;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace Moonfish.Graphics
{
    public interface ISelectable
    {
        void Select();
    }

    public interface IRenderable
    {
        void Render(IEnumerable<Program> shaderPasses);
    }

    public class NodeCollection : List<RenderModelNodeBlock>
    {
        public NodeCollection() : base() { }
        public NodeCollection(int capacity)
            : base(capacity)
        {
        }
        public NodeCollection(IEnumerable<RenderModelNodeBlock> collection)
            : base(collection)
        {
        }
        public Matrix4 GetWorldMatrix(int nodeIndex)
        {
            return GetWorldMatrix(this[nodeIndex]);
        }
        public Matrix4 GetWorldMatrix(RenderModelNodeBlock node)
        {
            if (!this.Contains(node)) throw new ArgumentOutOfRangeException();

            var worldMatrix = node.WorldMatrix;
            if ((int)node.parentNode < 0) return worldMatrix;
            return worldMatrix * GetWorldMatrix(this[(int)node.parentNode]);
        }
    }


    public class ScenarioObject : RenderObject, IClickable, IRenderable, IEnumerable<BulletSharp.CollisionObject>
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

        public bool Selected { get; set; }

        private Matrix4 worldMatrix;
        private Matrix4 collisionSpaceMatrix;

        IList<object> selectedObjects;

        public ScenarioObject()
            : base()
        {
            activePermuation = StringID.Zero;
            selectedObjects = new List<object>();
            Nodes = new NodeCollection();
            Selected = false;
        }

        public ScenarioObject(ModelBlock model)
            : this()
        {
            this.Model = model;

            if (model.RenderModel == null) return;

            this.CollisionObject = new CollisionObject()
            {
                UserObject = this,
                CollisionFlags = CollisionFlags.StaticObject,
                CollisionShape = new BoxShape(this.Model.RenderModel.compressionInfo[0].ToHalfExtents())
            };

            collisionSpaceMatrix = Matrix4.CreateTranslation(this.Model.RenderModel.compressionInfo[0].ToExtentsMatrix().ExtractTranslation());
            worldMatrix = Matrix4.Identity;

            foreach (var section in model.RenderModel.sections)
            {
                base.sectionBuffers.Add(new Mesh(section.sectionData[0].section));
            }
            this.Nodes = new NodeCollection(model.RenderModel.nodes);
            this.Markers = model.RenderModel.markerGroups.SelectMany(x => x.Markers).ToDictionary(x => x, x => new MarkerWrapper(x, this.Nodes));
        }

        void Render(IEnumerable<Program> shaderPasses)
        {
            foreach (var program in shaderPasses)
            {
                RenderPass(program);
            }

        }

        private void RenderPass(Program program)
        {
            if (Model.RenderModel == null) return;
            if (program.Name != "system")
            {
                using (program.Use())
                {
                    var extents = Model.RenderModel.compressionInfo[0].ToExtentsMatrix();

                    var objectMatrixAttribute = program.GetAttributeLocation("objectExtents");
                    var colourAttribute = program.GetAttributeLocation("colour");
                                        
                    program.SetAttribute(objectMatrixAttribute, extents);
                    program.SetAttribute(colourAttribute, Selected ? Color.Yellow.ToFloatRgba() : Color.LightCoral.ToFloatRgba());
                    foreach (var region in Model.RenderModel.regions)
                    {
                        var section_index = region.permutations[0].l6SectionIndexHollywood;
                        var mesh = sectionBuffers[section_index];
                        using (mesh.Bind())
                        {
                            GL.UseProgram(program.Ident);
                            foreach (var part in mesh.Parts)
                            {
                                GL.DrawElements(PrimitiveType.TriangleStrip, part.stripLength, DrawElementsType.UnsignedShort,
                                    (IntPtr)(part.stripStartIndex * 2)); OpenGL.ReportError();
                            }
                        }
                    }
                }
            }
            if (program.Name == "system")
            {
                using (program.Use())
                using (OpenGL.Disable(EnableCap.DepthTest))
                {
                    foreach (var markerGroup in Model.RenderModel.markerGroups)
                    {
                        foreach (var marker in markerGroup.markers)
                        {
                            var nodeIndex = marker.nodeIndex;
                            var translation = marker.translation;
                            var rotation = marker.rotation;
                            var scale = marker.scale;

                            var worldMatrix = this.Nodes.GetWorldMatrix(nodeIndex);

                            var worldMatrixUniform = program.GetUniformLocation("worldMatrix");
                            program.SetUniform(worldMatrixUniform, OpenTK.Matrix4.Identity);

                            if (selectedObjects.Contains(marker))
                            {
                                GL.VertexAttrib3(1, Color.Black.ToFloatRgba());
                                DebugDrawer.DrawPoint(translation, 7);
                                GL.VertexAttrib3(1, Color.Tomato.ToFloatRgba());
                                DebugDrawer.DrawPoint(translation, 4);
                            }
                            else
                            {
                                GL.VertexAttrib3(1, Color.White.ToFloatRgba());
                                DebugDrawer.DrawPoint(translation, 7);
                                GL.VertexAttrib3(1, Color.SkyBlue.ToFloatRgba());
                                DebugDrawer.DrawPoint(translation, 3);
                            }

                            DebugDrawer.DrawPoint(translation, 5);
                        }
                    }
                }
            }
        }

        void IRenderable.Render(IEnumerable<Program> shaderPasses)
        {
            this.Render(shaderPasses);
        }

        internal void Select(IEnumerable<object> collection)
        {
            selectedObjects.Clear();
            foreach (var item in collection)
            {
                selectedObjects.Add(item);
            }
        }

        IEnumerator<BulletSharp.CollisionObject> IEnumerable<BulletSharp.CollisionObject>.GetEnumerator()
        {

            foreach (var markerGroup in Model.RenderModel.markerGroups)
            {
                foreach (var marker in markerGroup.markers)
                {
                    var collisionObject = new BulletSharp.CollisionObject();
                    collisionObject.CollisionShape = new BulletSharp.BoxShape(0.045f);
                    collisionObject.WorldTransform = Matrix4.CreateTranslation(marker.translation) * this.Nodes.GetWorldMatrix(marker.nodeIndex);
                    collisionObject.UserObject = this.Markers[marker];
                    yield return collisionObject;

                    var setPropertyMethodInfo = typeof(BulletSharp.CollisionObject).GetProperty("WorldTransform").GetSetMethod();
                    var setProperty = Delegate.CreateDelegate(typeof(Action<Matrix4>), collisionObject, setPropertyMethodInfo);

                    this.Markers[marker].MarkerUpdatedCallback += (Action<Matrix4>)setProperty;
                }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return null;
        }

        internal void Save(MapStream map)
        {
            //BinaryWriter binaryWriter = new BinaryWriter( map );
            //map[model.renderModel.TagID].Seek();
            // this.model.RenderModel.Write(binaryWriter);
        }

        event EventHandler<MouseEventArgs> IClickable.MouseClick
        {
            add { throw new NotImplementedException(); }
            remove { throw new NotImplementedException(); }
        }

        void IClickable.OnMouseDown(object sender, MouseEventArgs e)
        {
            this.Selected = true;
            if (sender is MouseEventDispatcher)
            {
            }
        }

        //class myCallback : BulletSharp.CollisionWorld.ConvexResultCallback
        //{
        //    public myCallback(ref Vector3 convexFromWorld, ref Vector3 convexToWorld)   { }
        //    public myCallback(Vector3 convexFromWorld, Vector3 convexToWorld) { }
        //    public CollisionObject CollisionObject { get; set; }
        //    public Vector3 ConvexFromWorld { get; set; }
        //    public Vector3 ConvexToWorld { get; set; }
        //    public Vector3 HitNormalWorld { get; set; }
        //    public Vector3 HitPointWorld { get; set; }


        //    public new float AddSingleResult(CollisionWorld.LocalConvexResult convexResult, bool normalInWorldSpace)
        //    {
        //        return 0;
        //    }
        //}

        public class myCallback : OverlapFilterCallback
        {
            public myCallback()
                : base()
            {
            }

            public override bool NeedBroadphaseCollision(BroadphaseProxy proxy0, BroadphaseProxy proxy1)
            {
                throw new NotImplementedException();
            }
        }

        public void OnMouseMove(CollisionManager CollisionManager, Camera ActiveCamera, System.Windows.Forms.MouseEventArgs e)
        {
            var mouse = new
            {
                Near = ActiveCamera.Project(new Vector2(e.X, e.Y), depth: -0.90f),
                Far = ActiveCamera.Project(new Vector2(e.X, e.Y), depth: 1)
            };

            Matrix4 from = Matrix4.Translation(mouse.Near);
            Matrix4 to = Matrix4.Translation(mouse.Far);

            var d = (mouse.Far - mouse.Near).Normalized();
            using (var callback = new CollisionWorld.ClosestConvexResultCallback(mouse.Near, mouse.Far))
            {

                callback.CollisionFilterGroup = CollisionFilterGroups.StaticFilter;
                callback.CollisionFilterMask = CollisionFilterGroups.StaticFilter;

                CollisionManager.World.ConvexSweepTest((ConvexShape)CollisionObject.CollisionShape, from, to, callback);
                
                var lookingNormal = (callback.ConvexToWorld - callback.ConvexFromWorld).Normalized();
                var dot = Vector3.Dot(callback.HitNormalWorld, lookingNormal);
                Console.WriteLine(callback.HitNormalWorld);
                if (callback.HasHit)
                {
                    if (!this.Selected) return;
                    var matrix = this.WorldMatrix.ClearTranslation();
                    var collMtrix = this.Model.RenderModel.compressionInfo[0].ToExtentsMatrix();

                    Vector3 linVel, angVel;
                    TransformUtil.CalculateVelocity(from, to, 1.0f, out linVel, out angVel);
                    Matrix4 T;
                    TransformUtil.IntegrateTransform(from, linVel, angVel, callback.ClosestHitFraction, out T);

                    this.WorldMatrix = T;
                }

            }
        }

        void IClickable.OnMouseMove(object sender, MouseEventArgs e)
        {
            //Console.WriteLine(this.Model.RenderModel.compressionInfo[0].positionBoundsZ.Length / 2);
            //Console.WriteLine(collisionSpaceMatrix.ExtractTranslation().ToString());
            //if (!this.Selected) return;
            //var matrix = this.WorldMatrix.ClearTranslation();
            //var collMtrix = this.Model.RenderModel.compressionInfo[0].ToExtentsMatrix();
            //var translation = Matrix4.CreateTranslation(
            //    e.HitPointWorld);
            //this.WorldMatrix = matrix * translation;
        }

        void IClickable.OnMouseUp(object sender, MouseEventArgs e)
        {
            this.Selected = false;
        }

        void IClickable.OnMouseClick(object sender, MouseEventArgs e)
        {
        }

        event EventHandler<MouseEventArgs> IClickable.MouseDown
        {
            add { throw new NotImplementedException(); }
            remove { throw new NotImplementedException(); }
        }

        event EventHandler<MouseEventArgs> IClickable.MouseMove
        {
            add { throw new NotImplementedException(); }
            remove { throw new NotImplementedException(); }
        }

        event EventHandler<MouseEventArgs> IClickable.MouseUp
        {
            add { throw new NotImplementedException(); }
            remove { throw new NotImplementedException(); }
        }


        event EventHandler<MouseEventArgs> IClickable.MouseCaptureChanged
        {
            add { throw new NotImplementedException(); }
            remove { throw new NotImplementedException(); }
        }

        void IClickable.OnMouseCaptureChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        internal void UpdateWorldMatrix(object sender, MatrixChangedEventArgs e)
        {
            this.WorldMatrix = e.Matrix;
        }
    }

    class ScenarioObjectd
    {
        ModelBlock model;

        public ScenarioObjectd(ModelBlock test)
        {
            this.model = test;
            ActivePermutation = StringID.Zero;
        }

        public StringID ActivePermutation { get; set; }

        public IEnumerable<StringID> Permutations
        {
            get
            {
                var query = model.RenderModel.regions.SelectMany(x => x.permutations).Select(x => x.name).Distinct();
                return query;
            }
        }

        public void Draw()
        {
        }
    }
}
