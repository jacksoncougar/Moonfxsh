using OpenTK;
using System;
using System.Windows.Forms;
using Moonfish.Graphics.Input;
using OpenTK.Input;
using OpenTK.Platform.Windows;

namespace Moonfish.Graphics
{
    public partial class DynamicScene
    {
        public event EventHandler<SceneMouseEventArgs> MouseDown;
        public event EventHandler<SceneMouseMoveEventArgs> MouseMove;
        public event EventHandler<SceneMouseEventArgs> MouseUp;
        public event EventHandler<SceneMouseEventArgs> MouseClick;

        public event EventHandler MouseCaptureChanged;

        public event SelectedObjectChangedEventHandler SelectedObjectChanged;

        public void OnMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            var mouse = new
            {
                Close = Camera.ReProject(new Vector2(e.X, e.Y), depth: -1),
                Far = Camera.ReProject(new Vector2(e.X, e.Y), depth: 1)
            };

            var callback = new BulletSharp.CollisionWorld.ClosestRayResultCallback(mouse.Close, mouse.Far);
            CollisionManager.World.PerformDiscreteCollisionDetection();
            CollisionManager.World.RayTest(mouse.Close, mouse.Far, callback);

            if (callback.HasHit)
            {
                var clickableCollisionObject = callback.CollisionObject as ClickableCollisionObject;
                if (clickableCollisionObject != null)
                {
                    RegisterEventHandler(clickableCollisionObject);
                    clickableCollisionObject.MouseDown(this, new SceneMouseEventArgs(Camera, new Vector2(e.X, e.Y), default(Vector3), e.Button));
                }
                var iSelectable = callback.CollisionObject.UserObject as ISelectable;
                if (iSelectable != null &&
                    SelectedObjectChanged != null)
                {
                    SelectedObjectChanged(this, new SelectEventArgs(callback.CollisionObject.UserObject));
                }
            }
            else
            {
                if (e.Button == MouseButtons.Left)
                {
                    MousePole.DropHandlers();
                }
            }
        }

        private void RegisterEventHandler(ClickableCollisionObject clickableCollisionObject)
        {
            MouseMove += clickableCollisionObject.MouseMove;
            MouseUp += clickableCollisionObject.MouseUp;
            MouseClick += clickableCollisionObject.MouseClick;
        }

        public void OnMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (MouseUp != null) MouseUp(this, new SceneMouseEventArgs(Camera, new Vector2(e.X, e.Y), default(Vector3), e.Button));
            MouseMove = null;
            MouseUp = null;
            MouseClick = null;
        }

        public void OnMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (MouseMove != null) MouseMove(this, new SceneMouseMoveEventArgs(Camera, e));
        }

        public void OnMouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (MouseClick != null) MouseClick(this, new SceneMouseEventArgs(Camera, new Vector2(e.X, e.Y), default(Vector3), e.Button));
        }

        public void OnMouseCaptureChanged(object sender, EventArgs e)
        {
            //if( this.MouseCaptureChanged != null ) this.MouseCaptureChanged( this, e );
        }
    }
}
