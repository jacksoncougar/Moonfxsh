using System;
using System.Collections.Generic;
using System.Drawing;
using BulletSharp;
using Moonfish.Collision;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Moonfish.Graphics.Input
{
    public class TranslationGizmo
    {
        private readonly ClickableCollisionObject _forwardCollisionObject;
        private readonly ClickableCollisionObject _rightCollisionObject;
        private readonly ClickableCollisionObject _upCollisionObject;
        private TriangleBatch _batch;
        private Vector3 _position;
        private Vector2 _registrationScreenspace;
        private Quaternion _rotation;
        private float _scale;
        private Axis _selectedAxis;
        private Vector3 _translation;

        public TranslationGizmo()
        {
            PixelSize = 30;
            _upCollisionObject = new ClickableCollisionObject { CollisionShape = new SphereShape(0.25f) };
            _rightCollisionObject = new ClickableCollisionObject { CollisionShape = new SphereShape(0.25f) };
            _forwardCollisionObject = new ClickableCollisionObject { CollisionShape = new SphereShape(0.25f) };


            _position = new Vector3(0.1f, 0.1f, 0.0f);
            _rotation = Quaternion.Identity;
            _scale = 1.0f;

            GenerateModel();
            Initialize();
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

        public RenderBatch Model { get; private set; }

        public Matrix4 WorldMatrix
        {
            get { return CalculateWorldMatrix(_position + _translation, _rotation, _scale); }
            set
            {
                _position = value.ExtractTranslation();
                _rotation = value.ExtractRotation();
                _scale = value.ExtractScale().X;
            }
        }

        private Vector3 ForwardNormalized
        {
            get { return WorldMatrix.Inverted().Column2.Xyz.Normalized(); }
        }

        private Vector3 RightNormalized
        {
            get { return WorldMatrix.Inverted().Column0.Xyz.Normalized(); }
        }

        private Vector3 UpNormalized
        {
            get { return WorldMatrix.Inverted().Column1.Xyz.Normalized(); }
        }

        public void OnCameraUpdate(object sender, CameraEventArgs e)
        {
            _scale = ((Camera)sender).CreateScale(_position + _translation, 0.5f, PixelSize);

            Model.AssignUniform("WorldMatrixUniform", WorldMatrix);

            var shape = new SphereShape(_scale * 0.15f);
            _rightCollisionObject.CollisionShape = shape;
            _upCollisionObject.CollisionShape = shape;
            _forwardCollisionObject.CollisionShape = shape;

            var collisionMatrix = WorldMatrix.ClearScale();

            _rightCollisionObject.WorldTransform = Matrix4.CreateTranslation(Vector3.UnitX * _scale) * collisionMatrix;
            _upCollisionObject.WorldTransform = Matrix4.CreateTranslation(Vector3.UnitY * _scale) * collisionMatrix;
            _forwardCollisionObject.WorldTransform = Matrix4.CreateTranslation(Vector3.UnitZ * _scale) * collisionMatrix;
        }

        public int PixelSize { get; set; }

        public event MatrixChangedEventHandler WorldMatrixChanged;

        private Vector2 CalculateScreenspaceTranslation(Vector2 originScreenspace, Vector2 axisNormalScreenspace, Vector2 cursorScreenspace)
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

        private static Matrix4 CalculateWorldMatrix(Vector3 translation, Quaternion rotation, float scale)
        {
            var translationMatrix = Matrix4.CreateTranslation(translation);
            var rotationMatrix = Matrix4.CreateFromQuaternion(rotation);
            var scaleMatrix = Matrix4.CreateScale(scale);
            return scaleMatrix * rotationMatrix * translationMatrix;
        }

        private void Commit()
        {
            _selectedAxis = Axis.None;
            _position += _translation;
            _translation = Vector3.Zero;
            SelectAxis(Axis.None);
        }

        private Vector3 FindPlaneNormal(Vector3 viewerAxis, Vector3 axisNormal)
        {
            var planeUNormal = UpNormalized;
            var planeVNormal = RightNormalized;
            var planeWNormal = ForwardNormalized;
            var cosineToNormalU = Vector3.Cross(planeUNormal, axisNormal).Length;
            var cosineToNormalV = Vector3.Cross(planeVNormal, axisNormal).Length;
            var cosineToNormalW = Vector3.Cross(planeWNormal, axisNormal).Length;
            var cosineToPlaneU = Vector3.Cross(planeUNormal, viewerAxis).Length - cosineToNormalU;
            var cosineToPlaneV = Vector3.Cross(planeVNormal, viewerAxis).Length - cosineToNormalV;
            var cosineToPlaneW = Vector3.Cross(planeWNormal, viewerAxis).Length - cosineToNormalW;

            var normal = cosineToPlaneU < cosineToPlaneV
                ? cosineToPlaneU < cosineToPlaneW ? planeUNormal : planeWNormal
                : cosineToPlaneV < cosineToPlaneW ? planeVNormal : planeWNormal;
            return normal;
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

        private Vector3 GetAxisNormal(Axis selectedAxis)
        {
            switch (selectedAxis)
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

        private ColorF[] GetColours()
        {
            var rightAxisColour = _selectedAxis.HasFlag(Axis.Right) ? Color.Yellow.ToColorF() : Color.Green.ToColorF();
            var upAxisColour = _selectedAxis.HasFlag(Axis.Up) ? Color.Yellow.ToColorF() : Color.Red.ToColorF();
            var forwardAxisColour = _selectedAxis.HasFlag(Axis.Forward)
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

        private void Initialize()
        {
            _upCollisionObject.OnMouseDown +=
                delegate(object sender, SceneMouseEventArgs args) { SelectAxis(Axis.Up, args); };
            _rightCollisionObject.OnMouseDown +=
                delegate(object sender, SceneMouseEventArgs args) { SelectAxis(Axis.Right, args); };
            _forwardCollisionObject.OnMouseDown +=
                delegate(object sender, SceneMouseEventArgs args) { SelectAxis(Axis.Forward, args); };

            _upCollisionObject.OnMouseMove +=
                delegate(object sender, SceneMouseMoveEventArgs args) { Translate(args); };
            _rightCollisionObject.OnMouseMove +=
                delegate(object sender, SceneMouseMoveEventArgs args) { Translate(args); };
            _forwardCollisionObject.OnMouseMove +=
                delegate(object sender, SceneMouseMoveEventArgs args) { Translate(args); };

            _upCollisionObject.OnMouseUp += delegate { Commit(); };
            _rightCollisionObject.OnMouseUp += delegate { Commit(); };
            _forwardCollisionObject.OnMouseUp += delegate { Commit(); };
        }

        private void SelectAxis(Axis axis, SceneMouseEventArgs args = null)
        {
            _selectedAxis = axis;
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

        private void SetTranslation(Vector3 translation)
        {
            var beforeMatrix = CalculateWorldMatrix(_position + _translation, _rotation, _scale);
            var afterMatrix = CalculateWorldMatrix(_position + translation, _rotation, _scale);
            if (WorldMatrixChanged != null)
                WorldMatrixChanged(this, new MatrixChangedEventArgs(ref beforeMatrix, ref afterMatrix));
            _translation = translation;
        }

        private void Translate(SceneMouseMoveEventArgs args)
        {
            if (_selectedAxis == Axis.None) return;
            var camera = args.Camera;

            var originScreenspace = camera.Project(_position);
            var axisNormal = GetAxisNormal(_selectedAxis);
            var translation_screenspace = CalculateScreenspaceTranslation(originScreenspace,
                camera.Project(_position + axisNormal), new Vector2(args.X, args.Y));

            var near = camera.UnProject(originScreenspace + translation_screenspace);
            var far = camera.UnProject(originScreenspace + translation_screenspace, -0.01f);

            var mouseRay = new Ray(near, far);

            // Setup and select the collision plane
            var normal = FindPlaneNormal(mouseRay.Direction, axisNormal);
            // Produce the plane-distance from origin from this objects position vector
            var planeOffset = Vector3.Dot(normal, _position);
            // We use negetive offset here
            var translationPlane = new Plane(normal, -planeOffset);

            float? distance;
            if (!translationPlane.Intersects(mouseRay, out distance)) return;

            var mouseVector = mouseRay.Origin + mouseRay.Direction * distance.GetValueOrDefault();
            var mouseProjectionLength = Vector3.Dot(axisNormal, mouseVector);
            var positionProjectionLength = Vector3.Dot(axisNormal, _position);
            var translationProjectionLength = (mouseProjectionLength - positionProjectionLength);
            var translation = (translationProjectionLength * axisNormal);

            if (!(translation.Length > 0)) return;

            SetTranslation(translation);
        }

        [Flags]
        private enum Axis
        {
            None = 0,
            Up = 1 << 1,
            Right = 1 << 2,
            Forward = 1 << 3
        };

        public void DropHandlers()
        {
            WorldMatrixChanged = null;
        }
    }
}