using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulletSharp;
using Moonfish.Graphics.Primitives;
using OpenTK;

namespace Moonfish.Graphics
{
    public class ConvexHullCaster
    {
        private CollisionObject selectedCollisionObject;

        public ConvexHullCaster( )
        {
        }

        public void OnSelectedObjectChanged( object sender, SelectEventArgs e )
        {
            var item = e.SelectedObject as CollisionObject;
            if ( item == null )
            {
                selectedCollisionObject = null;
                return;
            }
            var scenarioObject = item.UserObject as ScenarioObject;
            if ( scenarioObject == null )
            {
                selectedCollisionObject = null;
                return;
            }
            selectedCollisionObject = item;
        }

        public event EventHandler<SceneMouseEventArgs> MouseDown;

        public event EventHandler<SceneMouseEventArgs> MouseMove;

        public event EventHandler<SceneMouseEventArgs> MouseUp;

        public event EventHandler<SceneMouseEventArgs> MouseClick;

        public event EventHandler<SceneMouseEventArgs> MouseCaptureChanged;

        public void OnMouseDown(object sender, SceneMouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        public Vector3 debugPoint;

        public void OnMouseMove(object sender, SceneMouseEventArgs e)
        {
            var dynamicScene = sender as DynamicScene;
            if (dynamicScene == null) return;
            if (selectedCollisionObject == null) return;
            var scenarioObject = selectedCollisionObject.UserObject as ScenarioObject;
            if (scenarioObject == null) return;

            var mouse = new
            {
                Close = e.Camera.UnProject(new Vector2(e.ScreenCoordinates.X, e.ScreenCoordinates.Y), depth: -1),
                Far = e.Camera.UnProject(new Vector2(e.ScreenCoordinates.X, e.ScreenCoordinates.Y), depth: 1)
            };

            ClosestRayResultCallback callback = new ClosestRayResultCallback( mouse.Close, mouse.Far )
            {
                CollisionFilterGroup = (CollisionFilterGroups)CollisionGroup.Level,
                CollisionFilterMask = (CollisionFilterGroups)CollisionGroup.Level
            };
            var convexShape = selectedCollisionObject.CollisionShape.IsConvex
                ? ( ConvexShape ) selectedCollisionObject.CollisionShape
                : null;

            var from = e.Camera.WorldMatrix;
            var to = e.Camera.WorldMatrix * Matrix4.CreateTranslation( 0, 0, 100 );

            dynamicScene.CollisionManager.World.RayTest(mouse.Close, mouse.Far, callback);

            if ( callback.HasHit )
            {
                debugPoint = callback.HitPointWorld;
                Console.WriteLine("hit");
                var worldTransform = Matrix4.CreateTranslation(callback.HitPointWorld);
                selectedCollisionObject.WorldTransform = worldTransform;
                scenarioObject.WorldMatrix = worldTransform;
            }
        }

        public void OnMouseUp(object sender, SceneMouseEventArgs e)
        {
            selectedCollisionObject = null;
        }

        public void OnMouseClick(object sender, SceneMouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void OnMouseCaptureChanged(object sender, SceneMouseEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
