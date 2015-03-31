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
        private readonly EventHandler<SceneMouseEventArgs> _mouseDownXDelegate;
        private readonly EventHandler<SceneMouseEventArgs> _mouseDownYDelegate;
        private readonly EventHandler<SceneMouseEventArgs> _mouseDownZDelegate;
        private readonly EventHandler<SceneMouseMoveEventArgs> _mouseMoveDelegate;
        private readonly EventHandler<SceneMouseEventArgs> _mouseUpDelegate;
        private readonly ClickableCollisionObject _forwardCollisionObject;
        private readonly ClickableCollisionObject _rightCollisionObject;
        private readonly ClickableCollisionObject _upCollisionObject;
        private TriangleBatch _batch;
        private bool _hidden;
        protected Vector3 position;
        private Vector2 _registrationScreenspace;
        protected Quaternion rotation;
        protected float scale;
        protected Axis selectedAxis;

        protected GizmoBase()
        {
            PixelSize = 30;
            _upCollisionObject = new ClickableCollisionObject { CollisionShape = new SphereShape(0.25f), UserObject = this };
            _rightCollisionObject = new ClickableCollisionObject { CollisionShape = new SphereShape(0.25f), UserObject = this };
            _forwardCollisionObject = new ClickableCollisionObject { CollisionShape = new SphereShape(0.25f), UserObject = this };

            _mouseDownXDelegate = delegate(object sender, SceneMouseEventArgs args) { SelectAxis(Axis.Right, args); };
            _mouseDownYDelegate = delegate(object sender, SceneMouseEventArgs args) { SelectAxis(Axis.Up, args); };
            _mouseDownZDelegate = delegate(object sender, SceneMouseEventArgs args) { SelectAxis(Axis.Forward, args); };
            _mouseMoveDelegate = delegate(object sender, SceneMouseMoveEventArgs args) { Transform(args); };
            _mouseUpDelegate = delegate { Commit(); };
            AssignCollisionObjectFunctions();

            position = new Vector3(0.1f, 0.1f, 0.0f);
            rotation = Quaternion.Identity;
            scale = 1.0f;

            GenerateModel();
        }

        public IEnumerable<CollisionObject> CollisionObjects
        {
            get
            {
                yield return _rightCollisionObject;
                yield return _upCollisionObject;
                yield return _forwardCollisionObject;
            }
        }

        protected virtual Matrix4 LocalMatrix
        {
            get { return CalculateWorldMatrix(position, rotation, scale); }
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
            scale = ((Camera)sender).CreateScale(WorldMatrix.ExtractTranslation(), 0.5f, PixelSize);

            Model.AssignUniform("WorldMatrixUniform", WorldMatrix);

            var shape = new SphereShape(scale * 0.15f);
            _rightCollisionObject.CollisionShape = shape;
            _upCollisionObject.CollisionShape = shape;
            _forwardCollisionObject.CollisionShape = shape;

            var collisionMatrix = WorldMatrix.ClearScale();

            _rightCollisionObject.WorldTransform = Matrix4.CreateTranslation(Vector3.UnitX * scale) * collisionMatrix;
            _upCollisionObject.WorldTransform = Matrix4.CreateTranslation(Vector3.UnitY * scale) * collisionMatrix;
            _forwardCollisionObject.WorldTransform = Matrix4.CreateTranslation(Vector3.UnitZ * scale) * collisionMatrix;
        }

        public void Show(bool show)
        {
            if (!_hidden == show) return;

            _hidden = !show;
            Model.BatchObject = show ? _batch : null;

            if (show) AssignCollisionObjectFunctions();
            else ClearCollisionObjectFunctions();
        }

        public event MatrixChangedEventHandler WorldMatrixChanged;

        protected Vector2 CalculateScreenspaceTranslation(Vector2 originScreenspace, Vector2 axisNormalScreenspace,
            Vector2 cursorScreenspace)
        {
            var cursorVectorScreenspace = cursorScreenspace - originScreenspace;
            var registrationVectorScreenspace = _registrationScreenspace - originScreenspace;

            var translationNormalScreenspace =
                (axisNormalScreenspace - originScreenspace).Normalized();

            var cursorInterceptDot = Vector2.Dot(cursorVectorScreenspace,
                translationNormalScreenspace);
            var registrationInterceptDot = Vector2.Dot(registrationVectorScreenspace,
                translationNormalScreenspace);

            var translationDot = cursorInterceptDot - registrationInterceptDot;

            return translationNormalScreenspace * translationDot;
        }

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

        protected void OnWorldMatrixChanged(ref Matrix4 beforeMatrix, ref Matrix4 afterMatrix)
        {
            if (WorldMatrixChanged != null)
                WorldMatrixChanged(this, new MatrixChangedEventArgs(ref beforeMatrix, ref afterMatrix));
        }

        protected void SelectAxis(Axis axis, SceneMouseEventArgs args = null)
        {
            selectedAxis = axis;
            if (args != null)
            {
                _registrationScreenspace = args.ScreenCoordinates;
            }

            var colours = GetColours();
            using (_batch.Begin())
            {
                _batch.BindBuffer(BufferTarget.ArrayBuffer, _batch.BufferIdents[1]);
                _batch.BufferVertexAttributeData(colours);
            }
        }

        protected abstract void Transform(SceneMouseMoveEventArgs args);

        private void AssignCollisionObjectFunctions()
        {
            _upCollisionObject.OnMouseMove += _mouseMoveDelegate;
            _rightCollisionObject.OnMouseMove += _mouseMoveDelegate;
            _forwardCollisionObject.OnMouseMove += _mouseMoveDelegate;

            _upCollisionObject.OnMouseDown += _mouseDownYDelegate;
            _rightCollisionObject.OnMouseDown += _mouseDownXDelegate;
            _forwardCollisionObject.OnMouseDown += _mouseDownZDelegate;

            _upCollisionObject.OnMouseUp += _mouseUpDelegate;
            _rightCollisionObject.OnMouseUp += _mouseUpDelegate;
            _forwardCollisionObject.OnMouseUp += _mouseUpDelegate;
        }

        private void ClearCollisionObjectFunctions()
        {
            _upCollisionObject.OnMouseMove -= _mouseMoveDelegate;
            _rightCollisionObject.OnMouseMove -= _mouseMoveDelegate;
            _forwardCollisionObject.OnMouseMove -= _mouseMoveDelegate;

            _upCollisionObject.OnMouseDown -= _mouseDownYDelegate;
            _rightCollisionObject.OnMouseDown -= _mouseDownXDelegate;
            _forwardCollisionObject.OnMouseDown -= _mouseDownZDelegate;

            _upCollisionObject.OnMouseUp -= _mouseUpDelegate;
            _rightCollisionObject.OnMouseUp -= _mouseUpDelegate;
            _forwardCollisionObject.OnMouseUp -= _mouseUpDelegate;
        }

        private void GenerateModel()
        {
            _batch = new TriangleBatch();
            var coordinates = new[] { Vector3.Zero, Vector3.UnitX, Vector3.Zero, Vector3.UnitY, Vector3.Zero, Vector3.UnitZ };
            var colours = GetColours();
            var indices = new short[] { 0, 1, 2, 3, 4, 5 };
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
    }
}