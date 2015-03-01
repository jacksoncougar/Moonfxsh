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
                var clickableInterface = callback.CollisionObject.UserObject as IClickable;
                if ( clickableInterface != null )
                {
                    clickableInterface.OnMouseClick( this, new MouseEventArgs( Camera, new Vector2( e.X, e.Y ), callback.CollisionObject.WorldTransform.ExtractTranslation(), e.Button ) );
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
            //if( this.MouseUp != null ) MouseUp( this, e );
        }
        public void OnMouseMove( object sender, System.Windows.Forms.MouseEventArgs e )
        {
            //if (this.MouseMove != null) this.MouseMove(this, e);
        }
        public void OnMouseCaptureChanged( object sender, EventArgs e )
        {
            //if( this.MouseCaptureChanged != null ) this.MouseCaptureChanged( this, e );
        }
    }
}
