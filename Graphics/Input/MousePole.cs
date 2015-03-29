using Moonfish.Collision;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using Moonfish.Graphics.Primitives;

namespace Moonfish.Graphics.Input
{
    public enum TransformMode
    {
        World,
        Local,
    }

    public class MousePole : IDisposable
    {
        public TransformMode Mode { get; set; }
        public Vector3 Position
        {
            get { return _position; }
            set
            {
                var previousWorldMatrix = CalculateWorldMatrix();
                _position = value;
                var worldMatrix = CalculateWorldMatrix();
                if (WorldMatrixChanged != null)
                    WorldMatrixChanged(this, new MatrixChangedEventArgs(previousWorldMatrix, worldMatrix));
            }
        }

        public Quaternion Rotation
        {
            get { return _rotation; }
            set
            {
                var previousWorldMatrix = CalculateWorldMatrix();
                _rotation = value;
                var worldMatrix = CalculateWorldMatrix();
                if (WorldMatrixChanged != null)
                    WorldMatrixChanged(this, new MatrixChangedEventArgs(previousWorldMatrix, worldMatrix));
            }
        }

        Matrix4 CalculateWorldMatrix()
        {
            var translationMatrix = Matrix4.CreateTranslation(_position);
            var rotationMatrix = Matrix4.CreateFromQuaternion(_rotation);
            var scaleMatrix = Matrix4.CreateScale(_scale);
            return translationMatrix * rotationMatrix.Inverted();
        }

        public event MatrixChangedEventHandler WorldMatrixChanged;

        public Action<Matrix4> SetWorldMatrix;

        Vector3 _position;
        Vector3 _origin;
        Vector3 _right, _forward, _up;
        Quaternion _rotation;
        int[] _glBuffers;
        int _elementCount;

        public bool Hidden { get; private set; }


        public IEnumerable<BulletSharp.CollisionObject> ContactObjects
        {
            get
            {
                yield return _rightContact;
                yield return _forwardContact;
                yield return _upContact;
            }
        }

        readonly BulletSharp.CollisionObject _rightContact;
        readonly BulletSharp.CollisionObject _forwardContact;
        readonly BulletSharp.CollisionObject _upContact;

        SelectedAxis _selectedAxis;

        Vector3 _worldRegistrationPosition;
        Matrix4 _viewMatrix;
        Matrix4 _projectionMatrix;
        Rectangle _viewport;

        float _scale;

        public MousePole(Camera camera)
            : this(camera, Vector3.UnitY, Vector3.UnitX, Vector3.UnitZ)
        {
        }

        public MousePole(Camera camera, Vector3 forwardAxis, Vector3 rightAxis, Vector3 upAxis)
        {
            Mode = TransformMode.Local;
            _scale = camera.CreateScale(_origin, 0.5f, pixelSize: 85);
            var scaleMatrix = Matrix4.CreateScale(_scale, _scale, _scale);

            var rotationX = Matrix3.CreateRotationX((float)Math.Acos(Vector3.Dot(Vector3.UnitX, rightAxis)));
            var rotationY = Matrix3.CreateRotationY((float)Math.Acos(Vector3.Dot(Vector3.UnitY, forwardAxis)));
            var rotationZ = Matrix3.CreateRotationZ((float)Math.Acos(Vector3.Dot(Vector3.UnitZ, upAxis)));
            _rotation = Quaternion.FromMatrix(rotationX * rotationY * rotationZ);
            var rotationMatrix = Matrix4.CreateFromQuaternion(_rotation);

            _origin = Vector3.Transform(new Vector3(0, 0, 0), scaleMatrix * rotationMatrix);
            _right = Vector3.Transform(new Vector3(1, 0, 0), scaleMatrix * rotationMatrix);
            _forward = Vector3.Transform(new Vector3(0, 1, 0), scaleMatrix * rotationMatrix);
            _up = Vector3.Transform(new Vector3(0, 0, 1), scaleMatrix * rotationMatrix);

            _rightContact = new BulletSharp.CollisionObject() { UserObject = this };
            _forwardContact = new BulletSharp.CollisionObject() { UserObject = this };
            _upContact = new BulletSharp.CollisionObject() { UserObject = this };

            BufferData();
            camera.ViewMatrixChanged += camera_ViewMatrixChanged;
            camera.Viewport.ProjectionChanged += Viewport_ProjectionChanged;
            camera.Viewport.ViewportChanged += Viewport_ViewportChanged;
            camera.CameraUpdated += OnCameraUpdate;
            OnCameraUpdate(this, new CameraEventArgs(camera));
        }

        [Flags]
        public enum SelectedAxis
        {
            None = 0,
            U = 1,
            V = 2,
            W = 4
        }

        public void OnMouseDown(object sender, SceneMouseEventArgs e)
        {
            if (Hidden) return;
            var scene = sender as DynamicScene;
            if (scene == null || e.Button != MouseButtons.Left) return;
            var callback = new BulletSharp.CollisionWorld.ClosestRayResultCallback(e.MouseRay.Origin, e.MouseRay.Origin + e.MouseRay.Direction * e.MouseRayFarPoint);
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
            Vector3 axisdirection;
            switch (_selectedAxis)
            {
                case SelectedAxis.U:
                    axisdirection = _origin + _right;
                    break;
                case SelectedAxis.V:
                    axisdirection = _origin + _up;
                    break;
                case SelectedAxis.W:
                    axisdirection = _origin + _forward;
                    break;
                default:
                    return;
            }
            _worldRegistrationPosition = callback.HitPointWorld - _position;
        }

        public void OnMouseUp(object sender, SceneMouseEventArgs e)
        {
            if (Hidden) return;
            if (e.Button == MouseButtons.Left)
            {
                _selectedAxis = SelectedAxis.None;
            }
        }

        public void OnMouseMove(object sender, SceneMouseEventArgs e)
        {
            if (Hidden) return;
            if (_selectedAxis == SelectedAxis.None) return;
            Vector3 axisdirection;
            switch (_selectedAxis)
            {
                case SelectedAxis.U:
                    axisdirection = _origin + _right;
                    break;
                case SelectedAxis.V:
                    axisdirection = _origin + _up;
                    break;
                case SelectedAxis.W:
                    axisdirection = _origin + _forward;
                    break;
                default:
                    return;
            }
            Vector3 intersection;

            var registrationOrigin = ProjectPoint(_worldRegistrationPosition, axisdirection, _origin);
            var registrationMouse = ProjectScreenPoint(new Vector3(e.ScreenCoordinates));

            var mouseRay = new Ray(
                Maths.Project(_viewMatrix, _projectionMatrix, registrationMouse.Xy, depth: -1, viewport: _viewport).Xyz,
                Maths.Project(_viewMatrix, _projectionMatrix, registrationMouse.Xy, depth: 1, viewport: _viewport).Xyz
                );

            var registrationRay = new Ray(
                Maths.Project(_viewMatrix, _projectionMatrix, registrationOrigin.Xy, depth: -1, viewport: _viewport).Xyz,
                Maths.Project(_viewMatrix, _projectionMatrix, registrationOrigin.Xy, depth: 1, viewport: _viewport).Xyz
                );


            var viewerAxis = (mouseRay.Origin - _origin).Normalized();
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

            Vector3.Normalize(ref planeUNormal, out planeUNormal);
            Vector3.Normalize(ref planeVNormal, out planeVNormal);
            Vector3.Normalize(ref translationNormal, out translationNormal);

            // Calculate the perpendicularness values
            var cosineToPlaneU = Vector3.Cross(viewerAxis, planeUNormal).LengthFast;
            var cosineToPlaneV = Vector3.Cross(viewerAxis, planeVNormal).LengthFast;

            // Select the most perpendicular plane
            var translationPlaneNormal = planeUNormal;
            if (cosineToPlaneU > cosineToPlaneV)
            {
                translationPlaneNormal = planeVNormal;
            }

            // Produce the plane-distance from origin from this objects position vector
            var planeOffset = Vector3.Dot(translationPlaneNormal, _origin);

            var translationPlane = new Plane(translationPlaneNormal, -planeOffset);

            float? hit, registrationHit;
            if (translationPlane.Intersects(mouseRay, out hit) &&
                translationPlane.Intersects(registrationRay, out registrationHit))
            {
                var componentU = Vector3.Dot(planeUNormal, _position) * planeUNormal;
                var componentV = Vector3.Dot(planeVNormal, _position) * planeVNormal;
                var translation = translationNormal *
                                  Vector3.Dot(translationNormal, mouseRay.Origin + mouseRay.Direction * hit.Value);

                var registrationOffset = translationNormal * Vector3.Dot(translationNormal, _worldRegistrationPosition);

                Position = translation - registrationOffset + componentU + componentV;
            }
        }

        public void OnCameraUpdate(object sender, CameraEventArgs e)
        {
            if (Hidden) return;
            _scale = e.Camera.CreateScale(_origin, 0.5f, pixelSize: 30);
            var scaleMatrix = Matrix4.CreateScale(_scale, _scale, _scale);

            var rotationMatrix = Mode == TransformMode.Local ? Matrix4.CreateFromQuaternion(_rotation) : Matrix4.Identity;

            _origin = _position + Vector3.Transform(new Vector3(0, 0, 0), scaleMatrix * rotationMatrix);
            _right = Vector3.Transform(new Vector3(1, 0, 0), scaleMatrix * rotationMatrix);
            _forward = Vector3.Transform(new Vector3(0, 1, 0), scaleMatrix * rotationMatrix);
            _up = Vector3.Transform(new Vector3(0, 0, 1), scaleMatrix * rotationMatrix);

            var contactSize = 0.2f * _scale;

            _rightContact.CollisionShape = new BulletSharp.BoxShape(contactSize);
            _forwardContact.CollisionShape = new BulletSharp.BoxShape(contactSize);
            _upContact.CollisionShape = new BulletSharp.BoxShape(contactSize);

            _rightContact.WorldTransform = Matrix4.CreateTranslation(_origin + _right);
            _forwardContact.WorldTransform = Matrix4.CreateTranslation(_origin + _forward);
            _upContact.WorldTransform = Matrix4.CreateTranslation(_origin + _up);

            Dispose(false);
            BufferData();
        }

        private Vector3 ProjectScreenPoint(Vector3 screenCoordinate)
        {
            var axisDirection = _origin;
            switch (_selectedAxis)
            {
                case SelectedAxis.U:
                    axisDirection = _origin + _right;
                    break;
                case SelectedAxis.V:
                    axisDirection = _origin + _forward;
                    break;
                case SelectedAxis.W:
                    axisDirection = _origin + _up;
                    break;
            }
            var pointA = Maths.UnProject(_viewMatrix * _projectionMatrix, _origin, _viewport, Maths.ProjectionTarget.View);
            var pointB = Maths.UnProject(_viewMatrix * _projectionMatrix, axisDirection, _viewport, Maths.ProjectionTarget.View);

            var lineNormal = (pointB - pointA).Normalized();
            var dotProduct = Vector3.Dot(screenCoordinate - pointA, lineNormal);
            var intersection = pointA + lineNormal * dotProduct;
            return intersection;
        }

        /// <summary>
        /// Projects the worldCoordinate onto a line defined by the ray from axisOrigin heading in axisDirection
        /// </summary>
        /// <returns>projected point in screen-space</returns>
        private Vector3 ProjectPoint(Vector3 worldCoordinate, Vector3 axisDirection, Vector3 axisOrigin)
        {
            var viewProjectionMatrix = _viewMatrix * _projectionMatrix;
            // project the origin(a point on the line) into viewspace
            var pointA = Maths.UnProject(viewProjectionMatrix, _origin, _viewport, Maths.ProjectionTarget.View);
            // project the axis heading(another point on the line) into viewspace
            var pointB = Maths.UnProject(viewProjectionMatrix, axisOrigin + axisDirection, _viewport, Maths.ProjectionTarget.View);
            // project the world coordinate into viewspace
            var pointC = Maths.UnProject(viewProjectionMatrix, worldCoordinate, _viewport, Maths.ProjectionTarget.View);


            var lineSlope = (pointB - pointA).Normalized();
            var dotProduct = Vector3.Dot(pointC - pointA, lineSlope);
            var intersection = pointA + lineSlope * dotProduct;
            return intersection;
        }

        void Viewport_ViewportChanged(object sender, Viewport.ViewportEventArgs e)
        {
            _viewport = e.Viewport;
        }

        void Viewport_ProjectionChanged(object sender, MatrixChangedEventArgs e)
        {
            _projectionMatrix = e.Matrix;
        }

        void camera_ViewMatrixChanged(object sender, MatrixChangedEventArgs e)
        {
            _viewMatrix = e.Matrix;
        }

        public void Render(Program shaderProgram)
        {
#if DEBUG
            GLDebug.DrawLine(Vector3.Zero, _right, Color.Fuchsia, 3.0f);
            GLDebug.DrawLine(Vector3.Zero, _forward, Color.Fuchsia, 3.0f);
            GLDebug.DrawLine(Vector3.Zero, _up, Color.Fuchsia, 3.0f);
#endif
            if (Hidden) return;
            using (shaderProgram.Use())
            using (OpenGL.Enable(EnableCap.PrimitiveRestartFixedIndex))
            using (OpenGL.Disable(EnableCap.DepthTest))
            {
                var worldMatrixUniform = shaderProgram.GetUniformLocation("WorldMatrixUniform");
                shaderProgram.SetUniform(worldMatrixUniform, Matrix4.Identity);
                GL.BindVertexArray(_glBuffers[0]);
                GL.DrawElements(PrimitiveType.Lines, 6, DrawElementsType.UnsignedShort, IntPtr.Zero);
                GL.DrawElements(PrimitiveType.TriangleFan, _elementCount - 6, DrawElementsType.UnsignedShort, (IntPtr)12);
                GL.BindVertexArray(0);
            }
        }

        private void BufferData()
        {
            const float coneHeight = 0.25f;
            var arrow = new Conic(coneHeight, coneHeight / Maths.Phi);

            var rightArrowCoordinates = TransformCoordinates(arrow.VertexCoordinates, _right);
            var forwardArrowCoordinates = TransformCoordinates(arrow.VertexCoordinates, _forward);
            var upArrowCoordinates = TransformCoordinates(arrow.VertexCoordinates, _up);

            var vertexCount = arrow.VertexCoordinates.Count;

            const float magic = 1 - Maths.PhiConjugate;
            var coordinates = new Vector3[] { 
                _origin + _right * magic, 
                _origin + _forward * magic, 
                _origin + _up * magic,
                _origin + _right, 
                _origin + _forward, 
                _origin + _up }
                .Concat(rightArrowCoordinates)
            .Concat(forwardArrowCoordinates)
            .Concat(upArrowCoordinates).ToArray();

            var indices = new ushort[] { 0, 3, 1, 4, 2, 5 };
            var offset = indices.Length;
            var rightArrowIndices = arrow.Indices.Select(x => x == ushort.MaxValue ? x : (ushort)(x + offset)).ToArray();
            offset += vertexCount;
            var forwardArrowIndices = arrow.Indices.Select(x => x == ushort.MaxValue ? x : (ushort)(x + offset)).ToArray();
            offset += vertexCount;
            var upArrowIndices = arrow.Indices.Select(x => x == ushort.MaxValue ? x : (ushort)(x + offset)).ToArray();
            indices = indices.Concat(rightArrowIndices).Concat(new[] { ushort.MaxValue })
                .Concat(forwardArrowIndices).Concat(new[] { ushort.MaxValue })
                .Concat(upArrowIndices).ToArray();

            _elementCount = indices.Length;

            BufferData(coordinates, indices);
        }

        private IEnumerable<Vector3> TransformCoordinates(IEnumerable<Vector3> coordinates, Vector3 targetAxis)
        {
            Vector3 normal;
            Vector3.Normalize(ref targetAxis, out normal);

            var dotProduct = Vector3.Dot(Vector3.UnitZ, normal);
            var axis = Vector3.Cross(Vector3.UnitZ, normal);
            var angle = (float)Math.Acos(dotProduct);

            var translationMatrix = Matrix4.CreateTranslation(Position + targetAxis);
            var rotationMatrix = Maths.NearlyEqual(dotProduct, 1.0) ?
                Matrix4.Identity : Maths.NearlyEqual(dotProduct, -1.0) ? Matrix4.CreateScale(-1.0f)
                : Matrix4.CreateFromAxisAngle(axis, angle);
            var scaleMatrix = Matrix4.CreateScale(_scale);

            var matrix = scaleMatrix * rotationMatrix * translationMatrix;

            var tranformedCoordinates = coordinates.Select(x => Vector3.Transform(x, matrix));

            return tranformedCoordinates;
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
            var colours = colourPallet.SelectMany(x => x.ToFloatRgb()).Concat(colourPallet.SelectMany(x => x.ToFloatRgb()));

            var colourCount = coordinates.Length - 6;
            var palletDivisor = colourCount / 3;
            for (int i = 0; i < colourCount; ++i)
            {
                var index = (i / palletDivisor) % palletDivisor;
                colours = colours.Concat(colourPallet[index].ToFloatRgb());
            }

            var colourArray = colours.ToArray();

            GL.BufferData<ushort>(
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
            GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 0, (IntPtr)(Vector3.SizeInBytes * coordinates.Length));

            GL.EnableVertexAttribArray(0);
            GL.EnableVertexAttribArray(1);

            GL.BindVertexArray(0);
        }

        private static void BufferColourData(int offset, float[] colours)
        {
            GL.BufferSubData<float>(
                BufferTarget.ArrayBuffer,
                (IntPtr)(offset),
                (IntPtr)(sizeof(float) * colours.Length),
                colours);
        }

        private static void BufferPositionData(Vector3[] coordinates)
        {
            GL.BufferSubData<Vector3>(
                BufferTarget.ArrayBuffer,
                (IntPtr)0,
                (IntPtr)(Vector3.SizeInBytes * coordinates.Length),
                coordinates);
        }

        void IDisposable.Dispose()
        {
            Dispose(disposing: true);
        }

        private void Dispose(bool disposing)
        {
            GL.DeleteVertexArray(_glBuffers[0]);
            GL.DeleteBuffer(_glBuffers[1]);
            GL.DeleteBuffer(_glBuffers[2]);
            if (disposing)
            {
                // call IDisposable on members
                _rightContact.Dispose();
                _forwardContact.Dispose();
                _upContact.Dispose();
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
    };
}
