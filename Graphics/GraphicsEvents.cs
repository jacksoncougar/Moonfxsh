using Moonfish.Collision;
using OpenTK;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Moonfish.Graphics
{
    public interface IClickable
    {
        event EventHandler<MouseEventArgs> MouseDown;
        event EventHandler<MouseEventArgs> MouseMove;
        event EventHandler<MouseEventArgs> MouseUp;
        event EventHandler<MouseEventArgs> MouseClick;
        event EventHandler<MouseEventArgs> MouseCaptureChanged;
        void OnMouseDown(Object sender, MouseEventArgs e);
        void OnMouseMove(Object sender, MouseEventArgs e);
        void OnMouseUp(Object sender, MouseEventArgs e);
        void OnMouseClick( Object sender, MouseEventArgs e );
        void OnMouseCaptureChanged( Object sender, EventArgs e );
    }

    public class MouseEventArgs : EventArgs
    {
        public Ray MouseRay { get; private set; }
        public float MouseRayFarPoint { get; private set; }
        public Vector2 ScreenCoordinates { get; private set; }
        public Vector3 WorldCoordinates { get; private set; }
        public System.Windows.Forms.MouseButtons Button { get; private set; }

        public bool WasHit { get; set; }
        public Vector3 HitPointWorld { get; set; }
        public Vector3 HitNormalWorld { get; set; }

        public MouseEventArgs(Camera camera, Vector2 mouseViewportCoordinates, Vector3 mouseWorldCoordinates, 
            System.Windows.Forms.MouseButtons button)
        {
            // Project the mouse coordinates into world-space at the far z-plane
            var distantWorldPoint = Maths.Project(camera.ViewMatrix, camera.ProjectionMatrix,
                new Vector3(mouseViewportCoordinates.X, mouseViewportCoordinates.Y, 1f),
                (Rectangle)camera.Viewport).Xyz;

            // Produce a ray originating at the camera and pointing towards the distant world point^
            this.ScreenCoordinates = mouseViewportCoordinates;
            this.MouseRay = new Ray(camera.Position, distantWorldPoint);
            this.MouseRayFarPoint = (distantWorldPoint - camera.Position).Length;
            this.Button = button;
            this.WorldCoordinates = mouseWorldCoordinates;
        }
    }

    public delegate void MouseMoveEventHandler(object sender, MouseEventArgs e);

    public delegate void MatrixChangedEventHandler(object sender, MatrixChangedEventArgs e);
}
