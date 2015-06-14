using System;
using System.Drawing;
using System.Windows.Forms;
using Moonfish.Collision;
using OpenTK;
using OpenTK.Input;
using MouseEventArgs = System.Windows.Forms.MouseEventArgs;

namespace Moonfish.Graphics
{
    public interface IClickable
    {
        event EventHandler<SceneMouseEventArgs> MouseDown;
        event EventHandler<SceneMouseEventArgs> MouseMove;
        event EventHandler<SceneMouseEventArgs> MouseUp;
        event EventHandler<SceneMouseEventArgs> MouseClick;
        event EventHandler<SceneMouseEventArgs> MouseCaptureChanged;
        void OnMouseDown(Object sender, SceneMouseEventArgs e);
        void OnMouseMove(Object sender, SceneMouseEventArgs e);
        void OnMouseUp(Object sender, SceneMouseEventArgs e);
        void OnMouseClick(Object sender, SceneMouseEventArgs e);
        void OnMouseCaptureChanged(Object sender, SceneMouseEventArgs e);
    }

    public class SelectEventArgs : EventArgs
    {
        public object SelectedObject { get; private set; }

        public SelectEventArgs(object selectedObject)
        {
            this.SelectedObject = selectedObject;
        }
    }

    public class SceneMouseMoveEventArgs : MouseEventArgs
    {
        public readonly Camera Camera;

        public SceneMouseMoveEventArgs(Camera camera, MouseEventArgs e)
            : base(e.Button, e.Clicks, e.X, e.Y, e.Delta)
        {
            Camera = camera;
        }
    }

    public class SceneMouseEventArgs : EventArgs
    {
        public Ray MouseRay { get; private set; }
        public float MouseRayFarPoint { get; private set; }
        public Vector2 ScreenCoordinates { get; private set; }
        public Vector3 WorldCoordinates { get; private set; }
        public MouseButtons Button { get; private set; }

        public bool WasHit { get; set; }
        public Vector3 HitPointWorld { get; set; }
        public Vector3 HitNormalWorld { get; set; }
        public readonly Camera Camera;

        public SceneMouseEventArgs(Camera camera, Vector2 mouseViewportCoordinates, Vector3 mouseWorldCoordinates,
            MouseButtons button)
        {
            // Project the mouse coordinates into world-space at the far z-plane
            var distantWorldPoint = camera.UnProject(mouseViewportCoordinates, 1);

            // Produce a ray originating at the camera and pointing towards the distant world point^
            Camera = camera;
            this.ScreenCoordinates = mouseViewportCoordinates;
            this.MouseRay = new Ray(camera.Position, distantWorldPoint);
            this.MouseRayFarPoint = (distantWorldPoint - camera.Position).Length;
            this.Button = button;
            this.WorldCoordinates = distantWorldPoint;
        }
    }

    public delegate void SelectedObjectChangedEventHandler(object sender, SelectEventArgs e);

    public delegate void MouseMoveEventHandler(object sender, SceneMouseEventArgs e);

    public delegate void MatrixChangedEventHandler(object sender, MatrixChangedEventArgs e);
}