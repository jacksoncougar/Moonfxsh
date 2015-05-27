using System;
using System.Windows.Forms;
using BulletSharp;
using Moonfish.Graphics.Input;
using OpenTK;

namespace Moonfish.Graphics
{
    public partial class DynamicScene
    {
        public event EventHandler<SceneMouseEventArgs> MouseDown;
        public event EventHandler<SceneMouseEventArgs> MouseMove;
        public event EventHandler<SceneMouseEventArgs> MouseUp;
        public event EventHandler<SceneMouseEventArgs> MouseClick;
        public event EventHandler MouseCaptureChanged;

        public event SelectedObjectChangedEventHandler SelectedObjectChanged;

        public void OnMouseDown( object sender, MouseEventArgs e )
        {
            var mouse = new
            {
                Close = Camera.Project( new Vector2( e.X, e.Y ), depth: -1 ),
                Far = Camera.Project( new Vector2( e.X, e.Y ), depth: 1 )
            };

            var callback = new ClosestRayResultCallback( mouse.Close, mouse.Far )
            {

                CollisionFilterGroup = CollisionFilterGroups.AllFilter
            };
            CollisionManager.World.PerformDiscreteCollisionDetection( );
            CollisionManager.World.RayTest( mouse.Close, mouse.Far, callback );

            if ( e.Button == MouseButtons.Left && callback.HasHit )
            {
                var clickableCollisionObject = callback.CollisionObject as IClickable;
                if ( clickableCollisionObject != null )
                {
                    RegisterEventHandler( clickableCollisionObject );
                    clickableCollisionObject.OnMouseDown( this,
                        new SceneMouseEventArgs( Camera, new Vector2( e.X, e.Y ), default( Vector3 ), e.Button ) );
                }
                if ( SelectedObjectChanged != null )
                {
                    SelectedObjectChanged( this, new SelectEventArgs( callback.CollisionObject ) );
                }
            }
            else if ( e.Button == MouseButtons.Left )
            {
                if ( SelectedObjectChanged != null )
                    SelectedObjectChanged( this, new SelectEventArgs( null ) );
            }
        }

        private void RegisterEventHandler(IClickable clickableCollisionObject)
        {
            MouseMove += clickableCollisionObject.OnMouseMove;
            MouseUp += clickableCollisionObject.OnMouseUp;
            MouseClick += clickableCollisionObject.OnMouseClick;
        }

        public void OnMouseUp(object sender, MouseEventArgs e)
        {
            if (MouseUp != null)
                MouseUp(this, new SceneMouseEventArgs(Camera, new Vector2(e.X, e.Y), default(Vector3), e.Button));
            MouseMove = null;
            MouseUp = null;
            MouseClick = null;
        }

        public void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (MouseMove != null) MouseMove(this, new SceneMouseEventArgs(Camera, new Vector2(e.X, e.Y), default(Vector3), e.Button));
        }

        public void OnMouseClick(object sender, MouseEventArgs e)
        {
            if (MouseClick != null)
                MouseClick(this,
                    new SceneMouseEventArgs(Camera, new Vector2(e.X, e.Y), default(Vector3), e.Button));
        }

        public void OnMouseCaptureChanged(object sender, EventArgs e)
        {
            //if( this.MouseCaptureChanged != null ) this.MouseCaptureChanged( this, e );
        }
    }
}