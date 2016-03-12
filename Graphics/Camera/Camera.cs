using System;
using System.Windows.Forms;
using BulletSharp;
using Moonfish.Guerilla.Tags;
using OpenTK;
using OpenTK.Input;
using MouseEventArgs = System.Windows.Forms.MouseEventArgs;

namespace Moonfish.Graphics
{
    public class Camera : Node
    {
        private readonly OrbitTrack _orbitTrack;
        private readonly PanTrack _panTrack;
        private readonly ZoomTrack _zoomTrack;
        private Vector2 _previousMouseCoordinate;

        public Camera()
        {
            Viewport = new Viewport();
            Track = new Track();

            Track.Parent = _panTrack = new PanTrack(Track);
            Track.Parent.Parent = _orbitTrack = new OrbitTrack(Track);
            Track.Parent.Parent.Parent = _zoomTrack = new ZoomTrack(Track);

            _zoomTrack.Zoom(-5f);

            Viewport.ProjectionChanged += viewport_ProjectionChanged;

            _orbitTrack.Update(70, 60);

            Update(0f, 0f);
        }

        public new Vector3 Position
        {
            get { return base.Position; }
            set
            {
                base.Position = value;
                CalculateViewProjectionMatrix();
            }
        }

        public Matrix4 ProjectionMatrix { get; private set; }

        public new Quaternion Rotation
        {
            get { return base.Rotation; }
            set
            {
                base.Rotation = value;
                CalculateViewProjectionMatrix();
            }
        }

        public Track Track { get; set; }
        public Matrix4 ViewMatrix { get; private set; }
        public Viewport Viewport { get; set; }

        public Matrix4 ViewProjectionMatrix
        {
            get { return ViewMatrix * ProjectionMatrix; }
        }

        public event EventHandler<CameraEventArgs> CameraUpdated;

        public float CreateScale(Vector3 origin, float halfExtents, float pixelSize)
        {
            var pointA = origin;
            var pointB = origin + WorldMatrix.Row0.Xyz * halfExtents;
            var screenPointA = this.Project(pointA);
            var screenPointB = this.Project(pointB);
            var currentPixelSize = (screenPointB - screenPointA).Length;

            var scale = pixelSize / currentPixelSize;
            return scale;
        }

        public event EventHandler MouseCaptureChanged;
        public event MouseEventHandler MouseDown;
        public event MouseMoveEventHandler MouseMove;
        public event MouseEventHandler MouseUp;

        public void OnMouseCaptureChanged(object sender, EventArgs e)
        {
            if (MouseCaptureChanged != null) MouseCaptureChanged(this, e);
        }

        public void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (MouseDown != null) MouseDown(this, e);
        }

        public void OnMouseMove(object sender, MouseEventArgs e)
        {
            var mouseState = Mouse.GetState();
            var keyboardState = Keyboard.GetState();
            var currentMouseCoordinate = new Vector2(e.X, e.Y);
            if (keyboardState.IsKeyDown(Key.ShiftLeft) && (mouseState[MouseButton.Middle]
                                                               ||
                                                               (mouseState[MouseButton.Left] &&
                                                                 keyboardState[Key.ControlLeft])))
            {
                var previousMouseWorldCoordinate = this.UnProjectToViewspace(_previousMouseCoordinate);
                var mouseWorldCoordinate = this.UnProjectToViewspace(currentMouseCoordinate);
                var delta = mouseWorldCoordinate - previousMouseWorldCoordinate;
                delta *= (Position - Vector3.Zero).Length;
                _panTrack.Update(delta.X, delta.Y);
            }
            else if (keyboardState.IsKeyDown(Key.AltLeft) && (mouseState[MouseButton.Middle]
                                                                  ||
                                                                  (mouseState[MouseButton.Left] &&
                                                                    keyboardState[Key.ControlLeft])))
            {
                var previousMouseWorldCoordinate = this.UnProjectToViewspace(_previousMouseCoordinate);
                var mouseWorldCoordinate = this.UnProjectToViewspace(currentMouseCoordinate);
                var delta = mouseWorldCoordinate - previousMouseWorldCoordinate;
                delta *= 10;
                _zoomTrack.Update(delta.Y, keyboardState[Key.ControlLeft] ? 2.5f : 1.0f);
            }
            else if (mouseState[MouseButton.Middle] ||
                      (mouseState[MouseButton.Left] && keyboardState[Key.ControlLeft]))
            {
                var delta = currentMouseCoordinate - _previousMouseCoordinate;
                _orbitTrack.Update(delta.X, delta.Y);
            }
            if (MouseMove != null)
                MouseMove(this, new SceneMouseEventArgs(this, new Vector2(e.X, e.Y), default(Vector3), e.Button));
            _previousMouseCoordinate = currentMouseCoordinate;
        }

        public void OnMouseUp(object sender, MouseEventArgs e)
        {
            if (MouseUp != null) MouseUp(this, e);
        }

        public void Update(float delta, float time)
        {
            Position = Track.WorldMatrix.ExtractTranslation();
            Rotation = Track.WorldMatrix.ExtractRotation();
            SimulateWind(delta, time);
            if (CameraUpdated != null) CameraUpdated(this, new CameraEventArgs(this));
        }

        Random random =new Random();
        private void SimulateWind( float delta, float time )
        {
            // map to [-0.5, 0.5], over 10 seconds
            var value = (( time % 10 ) - 5) / 1000;
            System.Diagnostics.Debug.WriteLine(value);
            var rand0 = random.Next(0, 1);
            var rand1 = random.Next(0, 1);
            //var output = (float)(value * value * value) / 16f;
            _orbitTrack.ArcRotate( rand0 < 1 ? value : -value, rand1 < 1 ? -value : value );
        }

        public event ViewMatrixChangedEventHandler ViewMatrixChanged;
        public event ViewProjectionMatrixChangedEventHandler ViewProjectionMatrixChanged;

        private void CalculateViewProjectionMatrix()
        {
            var viewMatrix = Matrix4.Invert(Track.WorldMatrix);
            var projectionMatrix = Viewport.ProjectionMatrix;

            var viewDirty = ViewMatrix != viewMatrix;
            var projectionDirty = ProjectionMatrix != projectionMatrix;
            ViewMatrix = viewMatrix;
            ProjectionMatrix = projectionMatrix;

            Matrix4 viewProjectionMatrix;
            Matrix4.Mult(ref viewMatrix, ref projectionMatrix, out viewProjectionMatrix);

            if (viewDirty || projectionDirty)
            {
                OnViewProjectionMatrixChanged(new MatrixChangedEventArgs(ref viewProjectionMatrix));
            }
            if (viewDirty)
            {
                OnViewMatrixChanged(new MatrixChangedEventArgs(ref viewMatrix));
            }
        }

        private void OnViewMatrixChanged(MatrixChangedEventArgs e)
        {
            if (ViewMatrixChanged != null)
                ViewMatrixChanged(this, e);
        }

        private void OnViewProjectionMatrixChanged(MatrixChangedEventArgs e)
        {
            if (ViewProjectionMatrixChanged != null)
                ViewProjectionMatrixChanged(this, e);
        }

        private void viewport_ProjectionChanged(object sender, MatrixChangedEventArgs e)
        {
            CalculateViewProjectionMatrix();
        }

        public void LookAt(Vector3 location)
        {
            _panTrack.Position = location;
        }

        public void ZoomTo(object selectedObject)
        {
            //int instance;
            //var selectedScenarioObject = DynamicScene.GetSelectedScenarioInstance(selectedObject, out instance);
            //if (selectedScenarioObject == null) return;
            //_panTrack.Position = selectedScenarioObject.GetInstanceMatrix(instance).ExtractTranslation();
            //var length = selectedScenarioObject.RenderModel.CompressionInfo[0].ToHalfExtents().Length * 2.5f;
            //_zoomTrack.Position = _zoomTrack.Forward * length;
        }

        public bool CanSee( dynamic instance, ObjectBlock objectBlock )
        {
            //todo implement viewstrum culling
            return true;
        }

        public float DistanceOf( Vector3 worldCoordinate )
        {
            return ( worldCoordinate - Position ).Length;
        }
    }

    public class CameraEventArgs : EventArgs
    {
        public Camera Camera;

        public CameraEventArgs(Camera camera)
        {
            Camera = camera;
        }
    }

    public class MatrixChangedEventArgs : EventArgs
    {
        public Matrix4 Delta;
        public Matrix4 Matrix;

        public MatrixChangedEventArgs(ref Matrix4 view_projection_matrix)
        {
            Matrix = view_projection_matrix;
        }

        public MatrixChangedEventArgs(Matrix4 beforeMatrix, Matrix4 afterMatrix)
        {
            Delta = beforeMatrix.Inverted() * afterMatrix;
            Matrix = afterMatrix;
        }

        public MatrixChangedEventArgs(ref Matrix4 beforeMatrix, ref Matrix4 afterMatrix)
        {
            Delta = beforeMatrix.Inverted() * afterMatrix;
            Matrix = afterMatrix;
        }
    }

    public delegate void ProjectionMatrixChangedEventHandler(object sender, MatrixChangedEventArgs e);

    public delegate void ViewMatrixChangedEventHandler(object sender, MatrixChangedEventArgs e);

    public delegate void ViewProjectionMatrixChangedEventHandler(object sender, MatrixChangedEventArgs e);
}