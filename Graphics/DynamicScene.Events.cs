using OpenTK;
using System;
using System.Windows.Forms;

namespace Moonfish.Graphics
{
    public partial class DynamicScene
    {
        public event MouseMoveEventHandler MouseMove;

        public event MouseEventHandler MouseUp;

        public event MouseEventHandler MouseDown;

        public event EventHandler MouseCaptureChanged;

        public event SelectedObjectChangedEventHandler SelectedObjectChanged;

        public void OnMouseDown( object sender, System.Windows.Forms.MouseEventArgs e )
        {
            MousePole.OnMouseDown( this, new MouseEventArgs( Camera, new Vector2( e.X, e.Y ), default( Vector3 ), e.Button ) );

            var mouse = new
            {
                Close = Camera.Project( new Vector2( e.X, e.Y ), depth: -1 ),
                Far = Camera.Project( new Vector2( e.X, e.Y ), depth: 1 )
            };

            var callback = new BulletSharp.CollisionWorld.ClosestRayResultCallback( mouse.Close, mouse.Far );
            CollisionManager.World.PerformDiscreteCollisionDetection();
            CollisionManager.World.RayTest( mouse.Close, mouse.Far, callback );

            if ( callback.HasHit )
            {
                var iSelectable = callback.CollisionObject.UserObject as ISelectable;
                if ( iSelectable != null && 
                    SelectedObjectChanged != null)
                {
                    SelectedObjectChanged( this, new SelectEventArgs( callback.CollisionObject.UserObject ) );
                }
            }
            else
            {
                if ( e.Button == System.Windows.Forms.MouseButtons.Left )
                {
                    MousePole.DropHandlers();
                    MousePole.Hide();
                }
            }
        }
        public void OnMouseUp( object sender, System.Windows.Forms.MouseEventArgs e )
        {
            MousePole.OnMouseUp( this, new MouseEventArgs( Camera, new Vector2( e.X, e.Y ), default( Vector3 ), e.Button ) );
        }
        public void OnMouseMove( object sender, System.Windows.Forms.MouseEventArgs e ) 
        {
            MousePole.OnMouseMove( this, new MouseEventArgs( Camera, new Vector2( e.X, e.Y ), default( Vector3 ), e.Button ) );
        }
        public void OnMouseCaptureChanged( object sender, EventArgs e )
        {
            //if( this.MouseCaptureChanged != null ) this.MouseCaptureChanged( this, e );
        }
    }
}
