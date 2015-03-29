using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BulletSharp;
using Moonfish.Collision;
using Moonfish.Graphics.Primitives;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using IDisposable = System.IDisposable;

namespace Moonfish.Graphics.Input.Test
{
    public enum TransformMode
    {
        World,
        Local
    }

    public class MousePole : IDisposable
    {
        [Flags]
        public enum SelectedAxis
        {
            None = 0,
            U = 1,
            V = 2,
            W = 4
        }

        private readonly CollisionObject _forwardContact;
        private readonly CollisionObject _rightContact;
        private readonly CollisionObject _upContact;
        private bool _disposed;
        private int _elementCount;
        private int[] _glBuffers;
        private Matrix4 _projectionMatrix;
        private readonly Vector3 _right = Vector3.UnitX;
        private readonly Vector3 _forward = Vector3.UnitY;
        private readonly Vector3 _up = Vector3.UnitZ;
        private SelectedAxis _selectedAxis;
        public Action<Matrix4> SetWorldMatrix;
        private Matrix4 _viewMatrix;
        private Rectangle _viewport;
        private Vector3 _worldRegistrationPosition;
        private int _pixelSize = 85;

        public MousePole(Camera camera)
            : this(camera, new Vector3(0, 1, 0), new Vector3(1, 0, 0), new Vector3(0, 0, 1))
        {
        }

        public MousePole(Camera camera, Vector3 forwardAxis, Vector3 rightAxis, Vector3 upAxis)
        {
            Mode = TransformMode.Local;
            _collisionHalfExtent = 0.125F;
            Scale = camera.CreateScale(Position, 0.5f, _pixelSize);
            var scaleMatrix = Matrix4.CreateScale(Scale, Scale, Scale);

            var rotationX = Matrix3.CreateRotationX((float)Math.Acos(Vector3.Dot(Vector3.UnitX, rightAxis)));
            var rotationY = Matrix3.CreateRotationY((float)Math.Acos(Vector3.Dot(Vector3.UnitY, forwardAxis)));
            var rotationZ = Matrix3.CreateRotationZ((float)Math.Acos(Vector3.Dot(Vector3.UnitZ, upAxis)));

            Rotation = Quaternion.FromMatrix(rotationX * rotationY * rotationZ) * Quaternion.FromAxisAngle(Vector3.UnitX, OpenTK.MathHelper.DegreesToRadians(45));

            _rightContact = new CollisionObject { UserObject = this };
            _forwardContact = new CollisionObject { UserObject = this };
            _upContact = new CollisionObject { UserObject = this };

            GenerateBufferData();
            camera.ViewMatrixChanged += camera_ViewMatrixChanged;
            camera.Viewport.ProjectionChanged += Viewport_ProjectionChanged;
            camera.Viewport.ViewportChanged += Viewport_ViewportChanged;
            camera.CameraUpdated += OnCameraUpdate;
            OnCameraUpdate(this, new CameraEventArgs(camera));
        }

        public IEnumerable<CollisionObject> ContactObjects
        {
            get
            {
                yield return _rightContact;
                yield return _forwardContact;
                yield return _upContact;
            }
        }

        public bool Hidden { get; private set; }
        public TransformMode Mode { get; set; }

        public float Scale { get; private set; }

        public Vector3 Position { get; set; }

        public Quaternion Rotation
        {
            get
            {
                switch (Mode)
                {
                    case TransformMode.Local:
                        return _rotation;
                    case TransformMode.World:
                        return Quaternion.Identity;
                }
                return _rotation;
            }
            set { _rotation = value; }
        }

        private void SetValue<T>(ref T value, ref T field)
        {
            var previousWorldMatrix = CalculateWorldMatrix();
            field = value;
            var worldMatrix = CalculateWorldMatrix();
            if (WorldMatrixChanged != null)
                WorldMatrixChanged(this, new MatrixChangedEventArgs(previousWorldMatrix, worldMatrix));
        }

        void IDisposable.Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Update()
        {
            var previousWorldMatrix = _worldMatrix;
            var worldMatrix = CalculateWorldMatrix();
            if (WorldMatrixChanged != null) ;
            //WorldMatrixChanged(this, new MatrixChangedEventArgs(previousWorldMatrix, worldMatrix));
        }

        public void OnCameraUpdate(object sender, CameraEventArgs e)
        {
            if (Hidden) return;

            Scale = e.Camera.CreateScale(Position, 1.0f, _pixelSize);

            var matrix = Matrix4.CreateFromQuaternion(Rotation);
            _uNormal = Vector3.Transform(_up, matrix);
            _vNormal = Vector3.Transform(_forward, matrix);
            _tNormal = Vector3.Transform(_right, matrix);


            _rightContact.CollisionShape = new BoxShape(_collisionHalfExtent);
            _forwardContact.CollisionShape = new BoxShape(_collisionHalfExtent);
            _upContact.CollisionShape = new BoxShape(_collisionHalfExtent);

            _rightContact.WorldTransform = Matrix4.CreateTranslation(_right * 1.125f) * _worldMatrix;
            _forwardContact.WorldTransform = Matrix4.CreateTranslation(_forward * 1.125f) * _worldMatrix;
            _upContact.WorldTransform = Matrix4.CreateTranslation(_up * 1.125f) * _worldMatrix;
            Update();
        }

        public void OnMouseDown(object sender, SceneMouseEventArgs e)
        {
            if (Hidden) return;
            var scene = sender as DynamicScene;
            if (scene == null || e.Button != MouseButtons.Left) return;
            var callback = new CollisionWorld.ClosestRayResultCallback(e.MouseRay.Origin, e.MouseRay.Origin + e.MouseRay.Direction * e.MouseRayFarPoint);
            var collisionWorld = scene.CollisionManager.World;
            collisionWorld.RayTest(e.MouseRay.Origin, e.MouseRay.Origin + e.MouseRay.Direction * e.MouseRayFarPoint, callback);

            if (!callback.HasHit) return;
            if (callback.CollisionObject == _rightContact)
                _selectedAxis = SelectedAxis.U;
            else if (callback.CollisionObject == _forwardContact)
                _selectedAxis = SelectedAxis.V;
            else if (callback.CollisionObject == _upContact)
                _selectedAxis = SelectedAxis.W;
            else return;

            _worldRegistrationPosition = callback.HitPointWorld;
        }

        public void OnMouseMove(object sender, SceneMouseEventArgs e)
        {
            if (Hidden) return;
            if (_selectedAxis == SelectedAxis.None) return;
            var registrationMouse = ProjectScreenPoint(new Vector3(e.ScreenCoordinates));


            var mouseRay = new Ray(
                Maths.Project(_viewMatrix, _projectionMatrix, registrationMouse.Xy, depth: -1, viewport: _viewport).Xyz,
                Maths.Project(_viewMatrix, _projectionMatrix, registrationMouse.Xy, depth: 1, viewport: _viewport).Xyz
                );


            var viewerAxis = (mouseRay.Origin - Position).Normalized();
            viewerAxis.Normalize();

            // Setup and select the collision plane
            Vector3 planeUNormal;
            Vector3 planeVNormal;
            Vector3 translationNormal;
            if (_selectedAxis.HasFlag(SelectedAxis.U))
            {
                planeUNormal = _up;
                planeVNormal = _forward;
                translationNormal = _right;
            }
            else if (_selectedAxis.HasFlag(SelectedAxis.V))
            {
                planeUNormal = _right;
                planeVNormal = _up;
                translationNormal = _forward;
            }
            else if (_selectedAxis.HasFlag(SelectedAxis.W))
            {
                planeUNormal = _right;
                planeVNormal = _forward;
                translationNormal = _up;
            }
            else return;



            var translationMatrix = Matrix4.CreateTranslation(Position);
            var rotationMatrix = Matrix4.CreateFromQuaternion(Rotation);
            var matrix = rotationMatrix * translationMatrix;

            Vector3.Transform(ref planeUNormal, ref matrix, out planeUNormal);
            Vector3.Transform(ref planeVNormal, ref matrix, out planeVNormal);
            Vector3.Transform(ref translationNormal, ref matrix, out translationNormal);

            Vector3.Normalize(ref planeUNormal, out planeUNormal);
            Vector3.Normalize(ref planeVNormal, out planeVNormal);
            Vector3.Normalize(ref translationNormal, out translationNormal);


            // Calculate the perpendicularness values
            var cosineToPlaneU = Vector3.Cross(viewerAxis, planeUNormal).LengthFast;
            var cosineToPlaneV = Vector3.Cross(viewerAxis, planeVNormal).LengthFast;

            // Select the most perpendicular plane
            var translationPlaneNormal = cosineToPlaneU > cosineToPlaneV ? planeVNormal : planeUNormal;

            // Produce the plane-distance from origin from this objects position vector
            var planeOffset = Vector3.Dot(translationPlaneNormal, Position);
            var translationPlane = new Plane(translationPlaneNormal, -planeOffset);

            float? hit, registrationRay;
            if (translationPlane.Intersects(mouseRay, out hit))
            {
                var worldHitPoint = mouseRay.Origin + mouseRay.Direction * hit.Value;

                var componentU = Vector3.Dot(planeUNormal, Position) * planeUNormal;
                var componentV = Vector3.Dot(planeVNormal, Position) * planeVNormal;
                var componentW = translationNormal * Vector3.Dot(translationNormal, worldHitPoint);

                //var registrationOffset = translationNormal * Vector3.Dot(translationNormal, _worldRegistrationPosition);
                Position = (componentW);
            }
        }

        public void OnMouseUp(object sender, SceneMouseEventArgs e)
        {
            if (Hidden) return;
            if (e.Button == MouseButtons.Left)
            {
                _selectedAxis = SelectedAxis.None;
            }
        }

        public void Render(Program shaderProgram)
        {
#if DEBUG
            GLDebug.DrawLine(Position, Position + _uNormal, Color.Fuchsia, 3.0f);
            GLDebug.DrawLine(Position, Position + _vNormal, Color.FromArgb(0, 108, 255), 3.0f);
            GLDebug.DrawLine(Position, Position + _tNormal, Color.FromArgb(0, 249, 255), 3.0f);
#endif
            if (Hidden) return;
            using (shaderProgram.Use())
            using (OpenGL.Enable(EnableCap.PrimitiveRestartFixedIndex))
            using (OpenGL.Disable(EnableCap.DepthTest))
            {
                var worldMatrixUniform = shaderProgram.GetUniformLocation("WorldMatrixUniform");
                shaderProgram.SetUniform(worldMatrixUniform, CalculateWorldMatrix());
                GL.BindVertexArray(_glBuffers[0]);
                GL.DrawElements(PrimitiveType.Lines, 6, DrawElementsType.UnsignedShort, IntPtr.Zero);
                GL.DrawElements(PrimitiveType.TriangleFan, _elementCount - 6, DrawElementsType.UnsignedShort, (IntPtr)12);
                GL.BindVertexArray(0);
            }
        }

        public event MatrixChangedEventHandler WorldMatrixChanged;

        protected virtual void Dispose(bool disposing)
        {
            GL.DeleteVertexArray(_glBuffers[0]);
            GL.DeleteBuffer(_glBuffers[1]);
            GL.DeleteBuffer(_glBuffers[2]);
            if (disposing && !_disposed)
            {
                // call IDisposable on members
                _rightContact.Dispose();
                _forwardContact.Dispose();
                _upContact.Dispose();
                _disposed = true;
            }
        }

        internal void DropHandlers()
        {
            SetWorldMatrix = null;
            WorldMatrixChanged = null;
        }

        internal void Hide()
        {
            Hidden = true;
        }

        internal void Show()
        {
            Hidden = false;
        }

        private static void BufferColourData(int offset, float[] colours)
        {
            GL.BufferSubData(
                BufferTarget.ArrayBuffer,
                (IntPtr)(offset),
                (IntPtr)(sizeof(float) * colours.Length),
                colours);
        }

        private void GenerateBufferData()
        {
            const float coneHeight = 0.25f;
            var arrow = new Conic(coneHeight, coneHeight / Maths.Phi);

            var rightArrowCoordinates = TransformCoordinates(arrow.VertexCoordinates, _right);
            var forwardArrowCoordinates = TransformCoordinates(arrow.VertexCoordinates, _forward);
            var upArrowCoordinates = TransformCoordinates(arrow.VertexCoordinates, _up);

            var vertexCount = arrow.VertexCoordinates.Count;

            const float magic = 1 - Maths.PhiConjugate;
            var coordinates = new[]
            {
                _right*magic,
                _forward*magic,
                _up*magic,
                _right,
                _forward,
                _up
            }
                .Concat(rightArrowCoordinates)
                .Concat(forwardArrowCoordinates)
                .Concat(upArrowCoordinates).ToArray();

            var indices = new ushort[] { 0, 3, 1, 4, 2, 5 };
            var offset = indices.Length;
            var rightArrowIndices =
                arrow.Indices.Select(x => x == ushort.MaxValue ? x : (ushort)(x + offset)).ToArray();
            offset += vertexCount;
            var forwardArrowIndices =
                arrow.Indices.Select(x => x == ushort.MaxValue ? x : (ushort)(x + offset)).ToArray();
            offset += vertexCount;
            var upArrowIndices = arrow.Indices.Select(x => x == ushort.MaxValue ? x : (ushort)(x + offset)).ToArray();
            indices = indices.Concat(rightArrowIndices).Concat(new[] { ushort.MaxValue })
                .Concat(forwardArrowIndices).Concat(new[] { ushort.MaxValue })
                .Concat(upArrowIndices).ToArray();

            _elementCount = indices.Length;

            BufferData(coordinates, indices);
        }

        private void BufferData(Vector3[] coordinates, ushort[] indices)
        {
            _glBuffers = new[] { GL.GenVertexArray(), GL.GenBuffer(), GL.GenBuffer() };

            GL.BindVertexArray(_glBuffers[0]);

            GL.BindBuffer(BufferTarget.ArrayBuffer, _glBuffers[1]);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, _glBuffers[2]);

            // assign colours
            var colourPallet = new[]
            {
                _selectedAxis.HasFlag(SelectedAxis.U) ? Colours.Selection : Colours.Red,
                _selectedAxis.HasFlag(SelectedAxis.V) ? Colours.Selection : Colours.Green,
                _selectedAxis.HasFlag(SelectedAxis.W) ? Colours.Selection : Colours.Blue
            };
            var colours =
                colourPallet.SelectMany(x => x.ToFloatRgb()).Concat(colourPallet.SelectMany(x => x.ToFloatRgb()));

            var colourCount = coordinates.Length - 6;
            var palletDivisor = colourCount / 3;
            for (var i = 0; i < colourCount; ++i)
            {
                var index = (i / palletDivisor) % palletDivisor;
                colours = colours.Concat(colourPallet[index].ToFloatRgb());
            }

            var colourArray = colours.ToArray();

            GL.BufferData(
                BufferTarget.ElementArrayBuffer,
                (IntPtr)(sizeof(ushort) * indices.Length),
                indices,
                BufferUsageHint.StreamDraw);
            GL.BufferData(
                BufferTarget.ArrayBuffer,
                (IntPtr)(Vector3.SizeInBytes * coordinates.Length + sizeof(float) * colourArray.Length),
                IntPtr.Zero,
                BufferUsageHint.StreamDraw);

            BufferPositionData(coordinates);

            BufferColourData(Vector3.SizeInBytes * coordinates.Length, colourArray);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);
            GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 0,
                (IntPtr)(Vector3.SizeInBytes * coordinates.Length));

            GL.EnableVertexAttribArray(0);
            GL.EnableVertexAttribArray(1);

            GL.BindVertexArray(0);
        }

        private static void BufferPositionData(Vector3[] coordinates)
        {
            GL.BufferSubData(
                BufferTarget.ArrayBuffer,
                (IntPtr)0,
                (IntPtr)(Vector3.SizeInBytes * coordinates.Length),
                coordinates);
        }

        private Matrix4 _worldMatrix;
        private Quaternion _rotation;
        private float _collisionHalfExtent;
        private Vector3 _uNormal;
        private Vector3 _vNormal;
        private Vector3 _tNormal;

        private Matrix4 CalculateWorldMatrix()
        {
            var translationMatrix = Matrix4.CreateTranslation(Position);
            var rotationMatrix = Matrix4.CreateFromQuaternion(Rotation);
            var scaleMatrix = Matrix4.CreateScale(Scale);
            _worldMatrix = scaleMatrix * rotationMatrix * translationMatrix;
            return _worldMatrix;
        }

        private void camera_ViewMatrixChanged(object sender, MatrixChangedEventArgs e)
        {
            _viewMatrix = e.Matrix;
        }

        /// <summary>
        ///     Projects the worldCoordinate onto a line defined by the ray from axisOrigin heading in axisDirection
        /// </summary>
        /// <returns>projected point in screen-space</returns>
        private Vector3 ProjectPoint(Vector3 worldCoordinate, Vector3 axisDirection, Vector3 axisOrigin)
        {
            var viewProjectionMatrix = _viewMatrix * _projectionMatrix;
            // project the origin(a point on the line) into viewspace
            var pointA = Maths.UnProject(viewProjectionMatrix, Position, _viewport, Maths.ProjectionTarget.View);
            // project the axis heading(another point on the line) into viewspace
            var pointB = Maths.UnProject(viewProjectionMatrix, axisOrigin + axisDirection, _viewport,
                Maths.ProjectionTarget.View);
            // project the world coordinate into viewspace
            var pointC = Maths.UnProject(viewProjectionMatrix, worldCoordinate, _viewport, Maths.ProjectionTarget.View);


            return CalculateIntersection(pointB, pointA, pointC);
        }

        private static Vector3 CalculateIntersection(Vector3 rayOrigin, Vector3 rayDirection, Vector3 point)
        {
            var lineSlope = (rayDirection - rayOrigin).Normalized();
            var dotProduct = Vector3.Dot(point - rayOrigin, lineSlope);
            var intersection = rayOrigin + lineSlope * dotProduct;
            return intersection;
        }

        private Vector3 ProjectScreenPoint(Vector3 screenCoordinate)
        {
            var position = _worldMatrix.ExtractTranslation();
            var axisDirection = position;
            switch (_selectedAxis)
            {
                case SelectedAxis.U:
                    axisDirection = Position + _right;
                    break;
                case SelectedAxis.V:
                    axisDirection = position + _forward;
                    break;
                case SelectedAxis.W:
                    axisDirection = position + _up;
                    break;
            }
            var pointA = Maths.UnProject(_viewMatrix * _projectionMatrix, position, _viewport, Maths.ProjectionTarget.View);
            var pointB = Maths.UnProject(_viewMatrix * _projectionMatrix, axisDirection, _viewport,
                Maths.ProjectionTarget.View);

            var lineNormal = (pointB - pointA).Normalized();
            var dotProduct = Vector3.Dot(screenCoordinate - pointA, lineNormal);
            var intersection = pointA + lineNormal * dotProduct;
            return intersection;
        }

        private IEnumerable<Vector3> TransformCoordinates(IEnumerable<Vector3> coordinates, Vector3 targetAxis)
        {
            Vector3 normal;
            Vector3.Normalize(ref targetAxis, out normal);

            var dotProduct = Vector3.Dot(Vector3.UnitZ, normal);
            var axis = Vector3.Cross(Vector3.UnitZ, normal);
            var angle = (float)Math.Acos(dotProduct);

            var translationMatrix = Matrix4.CreateTranslation(Position + targetAxis);
            var rotationMatrix = Maths.NearlyEqual(dotProduct, 1.0) || Maths.NearlyEqual(dotProduct, -1.0)
                ? Matrix4.Identity
                : Matrix4.CreateFromAxisAngle(axis, angle);

            var matrix = rotationMatrix * translationMatrix;

            var tranformedCoordinates = coordinates.Select(x => Vector3.Transform(x, matrix));

            return tranformedCoordinates;
        }

        private void Viewport_ProjectionChanged(object sender, MatrixChangedEventArgs e)
        {
            _projectionMatrix = e.Matrix;
        }

        private void Viewport_ViewportChanged(object sender, Viewport.ViewportEventArgs e)
        {
            _viewport = e.Viewport;
        }
    };
}