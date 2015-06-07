using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BulletSharp;
using Moonfish.Graphics.Primitives;
using Moonfish.Guerilla.Tags;
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

        public class ClosestNotMeConvexResultCallback : ClosestConvexResultCallback
        {
            private readonly CollisionObject _collisionObject;

            public ClosestNotMeConvexResultCallback(CollisionObject collisionObject, Vector3 convexFromWorld, Vector3 convexToWorld ) : base( convexFromWorld, convexToWorld )
            {
                _collisionObject = collisionObject;
            }

            public override bool NeedsCollision( BroadphaseProxy proxy0 )
            {
                if (proxy0.ClientObject == _collisionObject) return false;
                return base.NeedsCollision( proxy0 );
            }
        }

        public class ClosestNotMeRayResultCallback : ClosestRayResultCallback
        {
            private readonly CollisionObject _collisionObject;

            public ClosestNotMeRayResultCallback(CollisionObject collisionObject, Vector3 rayFromWorld, Vector3 rayToWorld)
                : base(rayFromWorld, rayToWorld)
            {
                _collisionObject = collisionObject;
            }

            public override bool NeedsCollision( BroadphaseProxy proxy0 )
            {
                if (proxy0.ClientObject == _collisionObject) return false;
                return base.NeedsCollision( proxy0 );
            }
        }

        public Vector3 debugPoint0;
        public Vector3 debugPoint1;
        public Vector3 debugPoint2;
        public Vector3 debugPoint3;

        public void OnMouseMove( object sender, SceneMouseEventArgs e )
        {
            var dynamicScene = sender as DynamicScene;
            if ( dynamicScene == null ) return;
            if ( selectedCollisionObject == null ) return;
            var scenarioObject = selectedCollisionObject.UserObject as ScenarioObject;
            if ( scenarioObject == null ) return;

            var mouse = new
            {
                Close = e.Camera.UnProject( new Vector2( e.ScreenCoordinates.X, e.ScreenCoordinates.Y ), depth: -1 ),
                Far = e.Camera.UnProject( new Vector2( e.ScreenCoordinates.X, e.ScreenCoordinates.Y ), depth: 1 )
            };

            var rayCallback = new ClosestNotMeRayResultCallback(selectedCollisionObject, mouse.Close, mouse.Far)
            {
                CollisionFilterGroup = (CollisionFilterGroups)CollisionGroup.Level,
                CollisionFilterMask = (CollisionFilterGroups)(CollisionGroup.Level | CollisionGroup.Objects)
            };


            dynamicScene.CollisionManager.World.RayTest(mouse.Close, mouse.Far, rayCallback );
            if (!rayCallback.HasHit) return;

            debugPoint0 = rayCallback.HitPointWorld;

            var groundNormal = rayCallback.HitNormalWorld;

            var objectNormal = selectedCollisionObject.WorldTransform.Column2.Xyz.Normalized(  );
            var objectRight =  selectedCollisionObject.WorldTransform.Column0.Xyz.Normalized(  );
            var objectForward =  selectedCollisionObject.WorldTransform.Column1.Xyz.Normalized(  );


            var angle2 = Vector3.CalculateAngle(groundNormal, objectNormal);
            Matrix4 t;
            if ( angle2 > 0.01f )
            {
                var X = Vector3.Dot( groundNormal, objectRight ) < Vector3.Dot( groundNormal, objectForward )
                    ? objectRight
                    : objectForward;
                var Y = Vector3.Cross( groundNormal, X );
                X = Vector3.Cross( Y, groundNormal );
                t = new Matrix4(
                    new Vector4( X ),
                    new Vector4( Y ),
                    new Vector4( groundNormal ),
                    new Vector4( 0, 0, 0, 1 ) );
                debugPoint1 = debugPoint0 + Vector3.Transform( objectNormal, t ) * 10f;
            }
            else t = selectedCollisionObject.WorldTransform.ClearTranslation( );

            var destination = debugPoint0 =  rayCallback.HitPointWorld;

            var convexCallback = new ClosestNotMeConvexResultCallback(selectedCollisionObject, selectedCollisionObject.WorldTransform.ExtractTranslation(), destination)
            {
                CollisionFilterGroup = ( CollisionFilterGroups ) CollisionGroup.Level,
                CollisionFilterMask = (CollisionFilterGroups)(CollisionGroup.Level | CollisionGroup.Objects)
            };

            
            var convexShape = selectedCollisionObject.CollisionShape.IsConvex
                ? ( ConvexShape ) selectedCollisionObject.CollisionShape
                : null;



            var fromTranslation = Matrix4.CreateTranslation(e.Camera.WorldMatrix.ExtractTranslation(  ));
            var fromRotation = selectedCollisionObject.WorldTransform.ClearTranslation( );
            var from = t * fromTranslation;
            var to = t * Matrix4.CreateTranslation(destination);

            dynamicScene.CollisionManager.World.ConvexSweepTest( convexShape, from, to, convexCallback );

            if ( convexCallback.HasHit )
            {
                Debug.WriteLine("hit");

                Vector3 linVel;
                Vector3 angVel;
                TransformUtil.CalculateVelocity(from, to, 1.0f, out linVel, out angVel);
                Matrix4 T;
                TransformUtil.IntegrateTransform(from, linVel, angVel, convexCallback.ClosestHitFraction, out T);

                debugPoint2 = T.ExtractTranslation(  );
                debugPoint3 = convexCallback.HitPointWorld + convexCallback.HitNormalWorld;

                selectedCollisionObject.WorldTransform = T;
                scenarioObject.AssignInstanceWorldTransform(selectedCollisionObject.UserIndex, T );
            }
        }

        private Matrix4 Transform(Vector3 translation, Vector3 scale, Quaternion rotation )
        {
            var T = Matrix4.CreateTranslation(translation);
            var S = Matrix4.CreateScale(scale);
            var R = Matrix4.CreateFromQuaternion(rotation);
            return S * R * T;
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

        public void OnKeyDown( object sender, KeyEventArgs e )
        {
            float delta = 0.00f;
            switch ( e.KeyCode )
            {
                case Keys.Q: delta = -0.1f;
                    break;
                case Keys.E: delta = 0.1f;
                    break;
                default:
                    return;
            } 
            
            if ( selectedCollisionObject == null ) return;
            var scenarioObject = selectedCollisionObject.UserObject as ScenarioObject;
            if ( scenarioObject == null ) return;

            var upAxis = selectedCollisionObject.WorldTransform.Row2.Xyz.Normalized();
            var existingRotation = selectedCollisionObject.WorldTransform.ExtractRotation( );
            Debug.WriteLine(upAxis);
            var R = Quaternion.FromAxisAngle( upAxis, delta );
            var T = selectedCollisionObject.WorldTransform;
            var transform = Matrix4.CreateFromQuaternion(existingRotation) * Matrix4.CreateFromQuaternion(R) * T.ClearRotation();

            selectedCollisionObject.WorldTransform = transform;
            scenarioObject.AssignWorldTransform(transform);
        }
    }
}
