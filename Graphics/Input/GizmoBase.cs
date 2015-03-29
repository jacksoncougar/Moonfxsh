using System;
using System.Collections.Generic;
using System.Drawing;
using BulletSharp;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Moonfish.Graphics.Input
{
    public abstract class GizmoBase
    {
        protected readonly ClickableCollisionObject forwardCollisionObject;
        protected readonly ClickableCollisionObject rightCollisionObject;
        protected readonly ClickableCollisionObject upCollisionObject;

        private TriangleBatch _batch;
        protected Vector3 position;
        protected Quaternion rotation;
        protected float scale;
        protected Axis selectedAxis;
        protected Vector2 registrationScreenspace;

        protected GizmoBase()
        {
            PixelSize = 30;
            upCollisionObject = new ClickableCollisionObject {CollisionShape = new SphereShape(0.25f)};
            rightCollisionObject = new ClickableCollisionObject {CollisionShape = new SphereShape(0.25f)};
            forwardCollisionObject = new ClickableCollisionObject { CollisionShape = new SphereShape(0.25f) };

            upCollisionObject.OnMouseMove +=
                delegate(object sender, SceneMouseMoveEventArgs args) { Transform(args); };
            rightCollisionObject.OnMouseMove +=
                delegate(object sender, SceneMouseMoveEventArgs args) { Transform(args); };
            forwardCollisionObject.OnMouseMove +=
                delegate(object sender, SceneMouseMoveEventArgs args) { Transform(args); };

            upCollisionObject.OnMouseDown +=
                delegate(object sender, SceneMouseEventArgs args) { SelectAxis(Axis.Up, args); };
            rightCollisionObject.OnMouseDown +=
                delegate(object sender, SceneMouseEventArgs args) { SelectAxis(Axis.Right, args); };
            forwardCollisionObject.OnMouseDown +=
                delegate(object sender, SceneMouseEventArgs args) { SelectAxis(Axis.Forward, args); };

            upCollisionObject.OnMouseUp += delegate { Commit(); };
            rightCollisionObject.OnMouseUp += delegate { Commit(); };
            forwardCollisionObject.OnMouseUp += delegate { Commit(); };

            position = new Vector3(0.1f, 0.1f, 0.0f);
            rotation = Quaternion.Identity;
            scale = 1.0f;

            GenerateModel();
        }

        public IEnumerable<CollisionObject> CollisionObjects
        {
            get
            {
                yield return rightCollisionObject;
                yield return upCollisionObject;
                yield return forwardCollisionObject;
            }
        }

        public virtual Matrix4 LocalMatrix
        {
            get { return CalculateWorldMatrix(position, rotation, scale); }
            set
            {
                position = value.ExtractTranslation();
                rotation = value.ExtractRotation();
                scale = value.ExtractScale().X;
            }
        }

        public RenderBatch Model { get; private set; }
        public int PixelSize { get; set; }

        public virtual Matrix4 WorldMatrix
        {
            get { return CalculateWorldMatrix(position, rotation, scale); }
            set
            {
                position = value.ExtractTranslation();
                rotation = value.ExtractRotation();
                scale = value.ExtractScale().X;
            }
        }

        protected Vector3 ForwardNormalized
        {
            get { return LocalMatrix.Inverted().Column2.Xyz.Normalized(); }
        }

        protected Vector3 RightNormalized
        {
            get { return LocalMatrix.Inverted().Column0.Xyz.Normalized(); }
        }

        protected Vector3 UpNormalized
        {
            get { return LocalMatrix.Inverted().Column1.Xyz.Normalized(); }
        }

        public void DropHandlers()
        {
            WorldMatrixChanged = null;
        }

        public void OnCameraUpdate(object sender, CameraEventArgs e)
        {
            scale = ((Camera) sender).CreateScale(WorldMatrix.ExtractTranslation(), 0.5f, PixelSize);

            Model.AssignUniform("WorldMatrixUniform", WorldMatrix);

            var shape = new SphereShape(scale * 0.15f);
            rightCollisionObject.CollisionShape = shape;
            upCollisionObject.CollisionShape = shape;
            forwardCollisionObject.CollisionShape = shape;

            var collisionMatrix = WorldMatrix.ClearScale();

            rightCollisionObject.WorldTransform = Matrix4.CreateTranslation(Vector3.UnitX * scale) * collisionMatrix;
            upCollisionObject.WorldTransform = Matrix4.CreateTranslation(Vector3.UnitY * scale) * collisionMatrix;
            forwardCollisionObject.WorldTransform = Matrix4.CreateTranslation(Vector3.UnitZ * scale) * collisionMatrix;
        }

        public event MatrixChangedEventHandler WorldMatrixChanged;

        protected static Matrix4 CalculateWorldMatrix(Vector3 translation, Quaternion rotation, float scale)
        {
            var translationMatrix = Matrix4.CreateTranslation(translation);
            var rotationMatrix = Matrix4.CreateFromQuaternion(rotation);
            var scaleMatrix = Matrix4.CreateScale(scale);
            return scaleMatrix * rotationMatrix * translationMatrix;
        }

        protected virtual void Commit()
        {
            selectedAxis = Axis.None;
            SelectAxis(selectedAxis);
        }

        protected Vector3 GetAxisNormal(Axis axis)
        {
            switch (axis)
            {
                case Axis.Right:
                    return RightNormalized;
                case Axis.Up:
                    return UpNormalized;
                case Axis.Forward:
                    return ForwardNormalized;
                default:
                    return Vector3.Zero;
            }
        }

        protected virtual void OnWorldMatrixChanged(ref Matrix4 beforeMatrix, ref Matrix4 afterMatrix)
        {
            if (WorldMatrixChanged != null)
                WorldMatrixChanged(this, new MatrixChangedEventArgs(ref beforeMatrix, ref afterMatrix));
        }

        protected void SelectAxis(Axis axis, SceneMouseEventArgs args = null)
        {
            selectedAxis = axis;
            if (args != null)
            {
                registrationScreenspace = args.ScreenCoordinates;
            }

            var colours = GetColours();
            using (_batch.Begin())
            {
                _batch.BindBuffer(BufferTarget.ArrayBuffer, _batch.BufferIdents[1]);
                _batch.BufferVertexAttributeData(colours);
            }
        }

        private void GenerateModel()
        {
            _batch = new TriangleBatch();
            var coordinates = new[]
            {Vector3.Zero, Vector3.UnitX, Vector3.Zero, Vector3.UnitY, Vector3.Zero, Vector3.UnitZ};
            var colours = GetColours();
            var indices = new short[] {0, 1, 2, 3, 4, 5};
            using (_batch.Begin())
            {
                _batch.BindBuffer(BufferTarget.ArrayBuffer, _batch.GenerateBuffer());
                _batch.BufferVertexAttributeData(coordinates);
                _batch.VertexAttribArray(0, 3, VertexAttribPointerType.Float);
                _batch.BindBuffer(BufferTarget.ArrayBuffer, _batch.GenerateBuffer());
                _batch.BufferVertexAttributeData(colours);
                _batch.VertexAttribArray(1, 4, VertexAttribPointerType.Float);
                _batch.BindBuffer(BufferTarget.ElementArrayBuffer, _batch.GenerateBuffer());
                _batch.BufferElementArrayData(indices);
            }
            Model = new RenderBatch
            {
                BatchObject = _batch,
                DrawElementsType = DrawElementsType.UnsignedShort,
                ElementStartIndex = 0,
                ElementLength = indices.Length,
                PrimitiveType = PrimitiveType.Lines
            };
            Model.AssignRenderState(EnableCap.DepthTest, false);
            Model.AssignUniform("WorldMatrixUniform", Matrix4.Identity);
        }

        private ColorF[] GetColours()
        {
            var rightAxisColour = selectedAxis.HasFlag(Axis.Right) ? Color.Yellow.ToColorF() : Color.Green.ToColorF();
            var upAxisColour = selectedAxis.HasFlag(Axis.Up) ? Color.Yellow.ToColorF() : Color.Red.ToColorF();
            var forwardAxisColour = selectedAxis.HasFlag(Axis.Forward)
                ? Color.Yellow.ToColorF()
                : Color.Blue.ToColorF();
            var colours = new[]
            {
                rightAxisColour, rightAxisColour,
                upAxisColour, upAxisColour,
                forwardAxisColour, forwardAxisColour
            };
            return colours;
        }

        [Flags]
        protected enum Axis
        {
            None = 0,
            Up = 1 << 1,
            Right = 1 << 2,
            Forward = 1 << 3
        };

        protected Vector2 CalculateScreenspaceTranslation(Vector2 originScreenspace, Vector2 axisNormalScreenspace,
            Vector2 cursorScreenspace)
        {
            var cursorVectorScreenspace = cursorScreenspace - originScreenspace;
            var registrationVectorScreenspace = registrationScreenspace - originScreenspace;

            var translationNormalScreenspace =
                (axisNormalScreenspace - originScreenspace).Normalized();

            var cursorInterceptDot = Vector2.Dot(cursorVectorScreenspace,
                translationNormalScreenspace);
            var registrationInterceptDot = Vector2.Dot(registrationVectorScreenspace,
                translationNormalScreenspace);

            var translationDot = cursorInterceptDot - registrationInterceptDot;

            return translationNormalScreenspace * translationDot;
        }

        protected abstract void Transform(SceneMouseMoveEventArgs args);
    }
}