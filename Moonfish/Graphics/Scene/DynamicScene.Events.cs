using System;
using System.Windows.Forms;
using BulletSharp;
using Moonfish.Forms;
using Moonfish.Graphics.Input;
using Moonfish.Graphics.Primitives;
using Moonfish.Guerilla.Tags;
using OpenTK;

namespace Moonfish.Graphics
{
    public partial class DynamicScene
    {
        public static ObjectBlock GetSelectedScenarioInstance(object selectedObject, out int instance)
        {
            instance = -1;
            var item = selectedObject as CollisionObject;
            var scenarioObject = item?.UserObject as ObjectBlock;
            if (scenarioObject == null)
            {
                return null;
            }
            instance = item.UserIndex;
            return scenarioObject;
        }

        public Vector3 CurrentMouseWorldPosition { get; private set; }
        public object SelectedObject { get; private set; }

        public event EventHandler<KeyEventArgs> KeyDown;
        public event EventHandler<SceneMouseEventArgs> MouseDown;
        public event EventHandler<SceneMouseEventArgs> MouseMove;
        public event EventHandler<SceneMouseEventArgs> MouseUp;
        public event EventHandler<SceneMouseEventArgs> MouseClick;
        public event EventHandler MouseCaptureChanged;

        public event SelectedObjectChangedEventHandler SelectedObjectChanged;

        public void SelectObject( CollisionObject selectedObject )
        {
            if ( selectedObject == null )
            {
                SelectedObject = null;
                SelectedObjectChanged?.Invoke(this,new SelectEventArgs(SelectedObject));

            }
            else if ( selectedObject.UserObject is ObjectBlock )
            {
                SelectedObject = selectedObject;
                SelectedObjectChanged?.Invoke( this,
                    new SelectEventArgs(SelectedObject) );
            }
        }

        public void OnMouseDown( object sender, MouseEventArgs e )
        {
            var mouse = new
            {
                Close = Camera.UnProject( new Vector2( e.X, e.Y), -1.0f ),
                Far = Camera.UnProject(new Vector2(e.X, e.Y), 1.0f)
            };

            var callback = new ClosestRayResultCullFaceCallback(mouse.Close, mouse.Far)
            {
                CollisionFilterGroup = CollisionFilterGroups.AllFilter,
                CollisionFilterMask = CollisionFilterGroups.AllFilter
            };
            CollisionManager.World.RayTest( mouse.Close, mouse.Far, callback );

            if ( callback.HasHit )
            {
                var clickableCollisionObject = callback.CollisionObject as IClickable;
                if ( clickableCollisionObject != null )
                {
                    RegisterEventHandler( clickableCollisionObject );
                    clickableCollisionObject.OnMouseDown( this,
                        new SceneMouseEventArgs( Camera, new Vector2( e.X, e.Y ), default( Vector3 ), e.Button ) );
                }
                SelectObject( callback.CollisionObject );
            }
            else if ( e.Button == MouseButtons.Left )
            {
                SelectObject(null);
            }
        }

        private void RegisterEventHandler(IClickable clickableCollisionObject)
        {
            MouseMove += clickableCollisionObject.OnMouseMove;
            MouseUp += clickableCollisionObject.OnMouseUp;
            MouseClick += clickableCollisionObject.OnMouseClick;
            clickableCollisionObject.MouseUp += delegate
            {
                MouseMove -= clickableCollisionObject.OnMouseMove;
                MouseClick -= clickableCollisionObject.OnMouseClick;
                MouseUp -= clickableCollisionObject.OnMouseUp;
            };
        }

        public void OnMouseUp(object sender, MouseEventArgs e)
        {
            MouseUp?.Invoke(this, new SceneMouseEventArgs(Camera, new Vector2(e.X, e.Y), default(Vector3), e.Button));
        }

        public void OnMouseMove( object sender, MouseEventArgs e )
        {
            var mouse = new
            {
                Close = Camera.UnProject( new Vector2( e.X, e.Y ), -1.0f ),
                Far = Camera.UnProject( new Vector2( e.X, e.Y ), 1.0f )
            };

            var callback = new ClosestRayResultCallback( mouse.Close, mouse.Far )
            {
                CollisionFilterMask = ( CollisionFilterGroups ) CollisionGroup.Objects
            };
            CollisionManager.World.RayTest( mouse.Close, mouse.Far, callback );

            if ( callback.HasHit )
            {
                CurrentMouseWorldPosition = callback.HitPointWorld;
                GLDebug.QueuePointDraw( 0, CurrentMouseWorldPosition );
            }

            MouseMove?.Invoke( this,
                new SceneMouseEventArgs( Camera, new Vector2( e.X, e.Y ), default(Vector3), e.Button ) );
        }

        public void OnMouseClick(object sender, MouseEventArgs e)
        {
            MouseClick?.Invoke(this,
                new SceneMouseEventArgs(Camera, new Vector2(e.X, e.Y), default(Vector3), e.Button));
        }

        public void OnMouseCaptureChanged(object sender, EventArgs e)
        {
            //if( this.MouseCaptureChanged != null ) this.MouseCaptureChanged( this, e );
        }

        public void OnKeyDown( object sender, KeyEventArgs e )
        {
            KeyDown?.Invoke( sender, e );
        }
    }
}