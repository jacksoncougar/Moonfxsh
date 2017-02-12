using System;
using System.Drawing;
using System.Threading.Tasks;
using BulletSharp;
using Moonfish.Collision;
using Moonfish.Graphics.Primitives;
using Moonfish.Guerilla.Tags;
using OpenTK;
using OpenTK.Input;

namespace Moonfish.Graphics
{
    public class ConvexHullCaster
    {
        private float _axisAlignedRotation;
        private CollisionObject selectedCollisionObject;
        private ScenarioObjectAxisAlignedWrapper selectedScenarioObject;

        public event EventHandler<SceneMouseEventArgs> MouseCaptureChanged;

        public event EventHandler<SceneMouseEventArgs> MouseClick;

        public event EventHandler<SceneMouseEventArgs> MouseDown;

        public event EventHandler<SceneMouseEventArgs> MouseMove;

        public event EventHandler<SceneMouseEventArgs> MouseUp;

        public void OnMouseCaptureChanged( object sender, SceneMouseEventArgs e )
        {
            throw new NotImplementedException( );
        }

        public void OnMouseClick( object sender, SceneMouseEventArgs e )
        {
            throw new NotImplementedException( );
        }

        public void OnMouseDown( object sender, SceneMouseEventArgs e )
        {
            throw new NotImplementedException( );
        }

        public async void OnMouseMove( object sender, SceneMouseEventArgs e )
        {
            //var state = Mouse.GetState( );
            //if ( !state.IsButtonDown( MouseButton.Left ) ) return;

            var dynamicScene = sender as DynamicScene;
            if ( dynamicScene == null ) return;
            var collisionObject = selectedCollisionObject;
            var scenarioObject = collisionObject?.UserObject as ObjectBlock;
            if ( scenarioObject == null ) return;

            var mouse = new
            {
                Close = e.Camera.UnProject( new Vector2( e.ScreenCoordinates.X, e.ScreenCoordinates.Y ), -1 ),
                Far = e.Camera.UnProject( new Vector2( e.ScreenCoordinates.X, e.ScreenCoordinates.Y ), 1 )
            };

            var rayCullCallback = new ClosestRayResultCullFaceCallback(mouse.Close, mouse.Far, false)
            {
                CollisionFilterGroup = CollisionFilterGroups.AllFilter,
                CollisionFilterMask = CollisionFilterGroups.StaticFilter
            };

            dynamicScene.CollisionManager.World.RayTest(mouse.Close, mouse.Far, rayCullCallback);


            var rayCallback = new ClosestNotMeRayResultCallback( collisionObject, mouse.Close, mouse.Far )
            {
                CollisionFilterGroup = CollisionFilterGroups.AllFilter,
                CollisionFilterMask = CollisionFilterGroups.StaticFilter
            };
           // GLDebug.Clear();

            dynamicScene.CollisionManager.World.RayTest( mouse.Close, mouse.Far, rayCallback );
            if ( !rayCallback.HasHit ) return;


            var splice = dynamicScene.Camera.Position;
            if ( rayCullCallback.HasHit && rayCullCallback.ClosestHitFraction < rayCallback.ClosestHitFraction)
            {
                splice = rayCullCallback.HitPointWorld;
            }

            Ray positionRay = new Ray(mouse.Close, mouse.Far);
            Vector3 center;
            float radius;
            collisionObject.CollisionShape.GetBoundingSphere( out center, out radius );
            var origin = mouse.Close + (mouse.Far - mouse.Close) * (rayCallback.ClosestHitFraction - 0.01f);

            var surfaceNormal = rayCallback.HitSurfaceNormal;
            var surfaceTangent = Vector3.Cross( rayCallback.HitSurfaceTangent, rayCallback.HitNormalWorld );
            var surfaceBitangent = rayCallback.HitSurfaceTangent;


            var basisMatrix = new Matrix4( new Vector4( surfaceTangent ), new Vector4( surfaceBitangent ),
                new Vector4(rayCallback.HitSurfaceNormal), new Vector4( 0, 0, 0, 1 ) );


            GLDebug.QueuePointDraw(rayCallback.HitPointWorld);
            var destination = rayCallback.HitPointWorld;

            GLDebug.QueueLineDraw(destination, destination + surfaceNormal * 1.5f);
            GLDebug.QueueLineDraw(destination, destination + surfaceTangent * 0.5f);
            GLDebug.QueueLineDraw(destination, destination + surfaceBitangent * 0.5f);


            var convexCallback = new ClosestNotMeConvexResultCallback( collisionObject,
                collisionObject.WorldTransform.ExtractTranslation( ), destination )
            {
                CollisionFilterGroup = CollisionFilterGroups.DefaultFilter | CollisionFilterGroups.StaticFilter,
                CollisionFilterMask = CollisionFilterGroups.StaticFilter
            };
            var convexShape = collisionObject.CollisionShape.IsConvex
                ? ( ConvexShape ) collisionObject.CollisionShape
                : null;

            var extractRotation = Matrix4.CreateFromQuaternion( collisionObject.WorldTransform.ExtractRotation( ) );
            var vector3 = destination + surfaceNormal * 1.5f;

            var extractTranslation = Matrix4.CreateTranslation(vector3);
            var from = basisMatrix * extractTranslation;
            var to = basisMatrix * Matrix4.CreateTranslation( destination );

            GLDebug.QueueLineDraw(from.ExtractTranslation(  ), to.ExtractTranslation(  ), Color.Red.ToColorF(  ).RGBA.Xyz);

            await Task.Run(
                    ( ) => dynamicScene.CollisionManager.World.ConvexSweepTest( convexShape, from, to, convexCallback ) );

            if ( convexCallback.HasHit )
            {
                Vector3 linVel;
                Vector3 angVel;
                TransformUtil.CalculateVelocity(from, to, 1.0f, out linVel, out angVel );
                Matrix4 T;
                TransformUtil.IntegrateTransform(from, linVel, angVel, convexCallback.ClosestHitFraction, out T );


                //.WorldTransform = basisMatrix * T;

                //var instanceBasis = 
                //    scenarioObject.InstanceBasisMatrices[selectedCollisionObject.UserIndex];

                //scenarioObject.AssignInstanceBasisTransform(selectedCollisionObject.UserIndex, basisMatrix);

                //var upAxis = basisMatrix.Row2.Xyz.Normalized();

                //GLDebug.QueueLineDraw(0, selectedCollisionObject.WorldTransform.ExtractTranslation(),
                //    selectedCollisionObject.WorldTransform.ExtractTranslation() + upAxis);


                //var instanceRotation = scenarioObject.InstanceRotations[selectedCollisionObject.UserIndex];

                //////selectedScenarioObject.SetAxisAlignedRotation( selectedCollisionObject.UserIndex, rotation );

                //var R = Quaternion.FromAxisAngle(upAxis, _axisAlignedRotation);

                collisionObject.WorldTransform = T;

                //debugPoint2 = T.ExtractTranslation();
                //debugPoint3 = convexCallback.HitPointWorld + convexCallback.HitNormalWorld;

                //// selectedCollisionObject.WorldTransform = T;
                ////var localMatrix = scenarioObject.collisionSpaceMatrix.Inverted() * t.Inverted() * T;
                //// scenarioObject.InstanceRotations[selectedCollisionObject.UserIndex] = instanceRotation;
                //selectedScenarioObject.SetAxisAlignedRotation(selectedCollisionObject.UserIndex, _axisAlignedRotation);
                //scenarioObject.InstancePositions[selectedCollisionObject.UserIndex] = (scenarioObject.collisionSpaceMatrix.Inverted() * T).ExtractTranslation();
                //localMatrix.ExtractTranslation();
            }
        }

        public void OnMouseUp( object sender, SceneMouseEventArgs e )
        {
            selectedCollisionObject = null;
        }

        public void OnSelectedObjectChanged( object sender, SelectEventArgs e )
        {
            GetSelectedInstance( e );
        }

        public void OnUpdate( object sender, EventArgs e )
        {
            var delta = 0.00f;
            var state = Keyboard.GetState( );
            if ( state.IsKeyDown( Key.Q ) )
            {
                delta = -0.1f;
            }
            if ( state.IsKeyDown( Key.E ) )
            {
                delta = +0.1f;
            }
            if ( state.IsKeyDown( Key.Escape ) )
            {
                selectedCollisionObject = null;
            }

            var scenarioObject = selectedCollisionObject?.UserObject as ScenarioObject;
            if ( scenarioObject == null ) return;

            var instanceBasis =
                scenarioObject.InstanceBasisMatrices[ selectedCollisionObject.UserIndex ];

            var upAxis = instanceBasis.Row2.Xyz.Normalized( );

            GLDebug.QueueLineDraw( 0, selectedCollisionObject.WorldTransform.ExtractTranslation( ),
                selectedCollisionObject.WorldTransform.ExtractTranslation( ) + upAxis );

            _axisAlignedRotation += delta;

            var R = Quaternion.FromAxisAngle( upAxis, _axisAlignedRotation );
            var T = selectedCollisionObject.WorldTransform;

            selectedScenarioObject.SetAxisAlignedRotation( selectedCollisionObject.UserIndex, _axisAlignedRotation );

            selectedCollisionObject.WorldTransform = instanceBasis * Matrix4.CreateFromQuaternion( R ) *
                                                     Matrix4.CreateTranslation( T.ExtractTranslation( ) );

            //scenarioObject.InstanceRotations[selectedCollisionObject.UserIndex] = instanceRotation;
        }

        private void GetSelectedInstance( SelectEventArgs e )
        {
            var item = e.SelectedObject as CollisionObject;
            if ( item == null || item == selectedCollisionObject )
            {
                selectedCollisionObject = null;
                selectedScenarioObject = null;
                return;
            }
            var scenarioObject = item.UserObject as ObjectBlock;
            if ( scenarioObject == null )
            {
                selectedCollisionObject = null;
                selectedScenarioObject = null;
                return;
            }
            selectedScenarioObject = new ScenarioObjectAxisAlignedWrapper( scenarioObject );
            selectedCollisionObject = item;
        }

        private Matrix4 Transform( Vector3 translation, Vector3 scale, Quaternion rotation )
        {
            var T = Matrix4.CreateTranslation( translation );
            var S = Matrix4.CreateScale( scale );
            var R = Matrix4.CreateFromQuaternion( rotation );
            return S * R * T;
        }


        public class ClosestNotMeRayResultCallback : ClosestRayResultCallback
        {
            private readonly CollisionObject _collisionObject;

            public ClosestNotMeRayResultCallback( CollisionObject collisionObject, Vector3 rayFromWorld,
                Vector3 rayToWorld )
                : base( rayFromWorld, rayToWorld )
            {
                _collisionObject = collisionObject;
            }

            public Vector3 HitSurfaceBitangent { get; set; }
            public Vector3 HitSurfaceNormal { get; set; }
            public Vector3 HitSurfaceTangent { get; set; }

            public override float AddSingleResult( LocalRayResult rayResult, bool normalInWorldSpace )
            {
                var collisionObject = rayResult.CollisionObject;

                if ( collisionObject == null) return base.AddSingleResult( rayResult, normalInWorldSpace );

                var meshShape = collisionObject.CollisionShape as BvhTriangleMeshShape;
                if (meshShape == null) return base.AddSingleResult(rayResult, normalInWorldSpace);

                var meshObject = rayResult.CollisionObject.CollisionShape as BvhTriangleMeshShape;
                if ( meshObject == null ) return base.AddSingleResult( rayResult, normalInWorldSpace );

                var rayFromWorld = RayFromWorld;
                var rayDirection = RayToWorld - rayFromWorld;

                var triangleBuffer = new TriangleBuffer( );
                meshShape.PerformRaycast( triangleBuffer, RayFromWorld, RayToWorld );

                float closestFrontFace = 1000f;
                for ( int i = 0; i < triangleBuffer.NumTriangles; i++ )
                {
                    var triangle = triangleBuffer.GetTriangle( i );


                    var triangleIndex = triangle.triangleIndex * 3;
                    var info = meshShape.MeshInterface as InfoTriangleIndexVertexArray;
                    var part = info?.IndexedMeshArray[triangle.partId];
                    if (part == null) continue;

                    var edge1 = triangle.vertex1 - triangle.vertex0;
                    var edge2 = triangle.vertex2 - triangle.vertex0;
                    var normal = Vector3.Cross( edge1, edge2 );

                    var dot = Vector3.Dot(normal, rayDirection);
                    if (dot > 0) continue;

                    float t;
                    if ( TriangleRayIntersection.Test( triangle.vertex0, triangle.vertex1, triangle.vertex2,
                        rayFromWorld, rayDirection, out t ) )
                    {
                        if ( !( closestFrontFace < t ) )
                        {
                            GLDebug.QueueTriangleDraw(ref triangle.vertex0, ref triangle.vertex1, ref triangle.vertex2);
                            closestFrontFace = t;
                        }
                    }
                    else
                    {
                        continue;
                    }

                    var bitangent = info.SurfaceInfo[ triangle.partId ].Bitangents[
                        part.TriangleIndices[ triangleIndex ] ];
                    var tangent = Vector3.Cross( bitangent, normal );



                    HitSurfaceTangent = tangent.Normalized();
                    HitSurfaceNormal = normal.Normalized();
                    HitSurfaceBitangent = bitangent.Normalized();


                }
                rayResult.HitFraction = closestFrontFace;
                if(closestFrontFace < ClosestHitFraction)
                    base.AddSingleResult(rayResult, normalInWorldSpace);
                return closestFrontFace;
            }

            public override bool NeedsCollision( BroadphaseProxy proxy0 )
            {
                return base.NeedsCollision( proxy0 );
            }
        }
    }
}