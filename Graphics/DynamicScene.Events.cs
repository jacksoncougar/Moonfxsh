using System;
using System.Windows.Forms;
using BulletSharp;
using Moonfish.Graphics.Input;
using Moonfish.Graphics.Primitives;
using OpenTK;

namespace Moonfish.Graphics
{
    public partial class DynamicScene
    {
        public static ScenarioObject GetSelectedScenarioInstance(object selectedObject, out int instance)
        {
            instance = -1;
            var item = selectedObject as CollisionObject;
            if (item == null)
            {
                return null;
            }
            var scenarioObject = item.UserObject as ScenarioObject;
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

        public void SelectObject( object selectedObject )
        {
            if (SelectedObjectChanged != null)
            {
                SelectedObjectChanged(this, new SelectEventArgs(SelectedObject = selectedObject));
            }
        }

        public void OnMouseDown( object sender, MouseEventArgs e )
        {
            var mouse = new
            {
                Close = Camera.UnProject( new Vector2( e.X, e.Y), -1.0f ),
                Far = Camera.UnProject(new Vector2(e.X, e.Y), 1.0f)
            };

            var callback = new ClosestRayResultCallback( mouse.Close, mouse.Far )
            {
                CollisionFilterMask = ( CollisionFilterGroups ) CollisionGroup.Objects
            };
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
            if (MouseUp != null)
                MouseUp(this, new SceneMouseEventArgs(Camera, new Vector2(e.X, e.Y), default(Vector3), e.Button));
        }

        public void OnMouseMove(object sender, MouseEventArgs e)
        {
            var mouse = new
            {
                Close = Camera.UnProject(new Vector2(e.X, e.Y), -1.0f),
                Far = Camera.UnProject(new Vector2(e.X, e.Y), 1.0f)
            };

            var callback = new ClosestRayResultCallback(mouse.Close, mouse.Far)
            {
                CollisionFilterMask = (CollisionFilterGroups)CollisionGroup.Objects
            };
            CollisionManager.World.RayTest(mouse.Close, mouse.Far, callback);

            if (callback.HasHit)
            {
                CurrentMouseWorldPosition = callback.HitPointWorld;
                GLDebug.QueuePointDraw( 0, CurrentMouseWorldPosition );
            }

            if (MouseMove != null) 
                MouseMove(this, new SceneMouseEventArgs(Camera, new Vector2(e.X, e.Y), default(Vector3), e.Button));
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

        public void OnKeyDown( object sender, KeyEventArgs e )
        {
            if ( KeyDown != null )
                KeyDown( sender, e );
        }
    }
}