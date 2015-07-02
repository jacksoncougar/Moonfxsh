using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using BulletSharp;
using Moonfish.Graphics.Primitives;
using Moonfish.Guerilla.Tags;
using OpenTK;
using OpenTK.Graphics.ES10;
using Key = OpenTK.Input.Key;
using KeyEventArgs = System.Windows.Forms.KeyEventArgs;
using Mouse = OpenTK.Input.Mouse;
using MouseButton = OpenTK.Input.MouseButton;

namespace Moonfish.Graphics
{
    public class ConvexHullCaster
    {
        private CollisionObject selectedCollisionObject;
        private ScenarioObjectAxisAlignedWrapper selectedScenarioObject;
        private float _axisAlignedRotation;

        public Vector3 MouseWorldPosition { get; private set; }

        public ConvexHullCaster( )
        {
        }

        public void OnSelectedObjectChanged( object sender, SelectEventArgs e )
        {
            GetSelectedInstance( e );
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
            var scenarioObject = item.UserObject as ScenarioObject;
            if ( scenarioObject == null )
            {
                selectedCollisionObject = null;
                selectedScenarioObject = null;
                return;
            }
            selectedScenarioObject = new ScenarioObjectAxisAlignedWrapper( scenarioObject );
            selectedCollisionObject = item;
        }

        public event EventHandler<SceneMouseEventArgs> MouseDown;

        public event EventHandler<SceneMouseEventArgs> MouseMove;

        public event EventHandler<SceneMouseEventArgs> MouseUp;

        public event EventHandler<SceneMouseEventArgs> MouseClick;

        public event EventHandler<SceneMouseEventArgs> MouseCaptureChanged;

        public void OnMouseDown( object sender, SceneMouseEventArgs e )
        {
            throw new NotImplementedException( );
        }

        public class ClosestNotMeConvexResultCallback : ClosestConvexResultCallback
        {
            private readonly CollisionObject _collisionObject;

            public ClosestNotMeConvexResultCallback( CollisionObject collisionObject, Vector3 convexFromWorld,
                Vector3 convexToWorld ) : base( convexFromWorld, convexToWorld )
            {
                _collisionObject = collisionObject;
            }

            public override bool NeedsCollision( BroadphaseProxy proxy0 )
            {
                if ( proxy0.ClientObject == _collisionObject ) return false;
                return base.NeedsCollision( proxy0 );
            }
        }
        
        public class ClosestNotMeRayResultCallback : ClosestRayResultCallback
        {
            public Vector3 HitSurfaceTangent { get; set; }
            public Vector3 HitSurfaceBitangent { get; set; }
            public Vector3 HitSurfaceNormal { get; set; }

            private readonly CollisionObject _collisionObject;

            public ClosestNotMeRayResultCallback( CollisionObject collisionObject, Vector3 rayFromWorld,
                Vector3 rayToWorld )
                : base( rayFromWorld, rayToWorld )
            {
                _collisionObject = collisionObject;
            }

            public override float AddSingleResult(LocalRayResult rayResult, bool normalInWorldSpace)
            {
                if (rayResult.HitFraction <= ClosestHitFraction)
                {
                    var value = base.AddSingleResult(rayResult, normalInWorldSpace);

                    var collisionObject = rayResult.CollisionObject;

                    if (collisionObject != null && value <= ClosestHitFraction)
                    {
                        var meshShape = collisionObject.CollisionShape as BvhTriangleMeshShape;
                        if (meshShape != null)
                        {
                            TriangleBuffer test = new TriangleBuffer();
                            meshShape.PerformRaycast(test, RayFromWorld,
                                RayFromWorld + ((RayToWorld - RayFromWorld) * ClosestHitFraction));
                            GLDebug.ClearLines();
                            if (test.NumTriangles > 0)
                            {
                                for (int index = 0; index < test.NumTriangles; index++)
                                {
                                    var triangle = test.GetTriangle(index);
                                    var triangleIndex = triangle.triangleIndex;
                                    var info = meshShape.MeshInterface as InfoTriangleIndexVertexArray;
                                    if (info != null)
                                    {
                                        var vertexIndex =
                                            info.IndexedMeshArray[triangle.partId].TriangleIndices[triangleIndex * 3];
                                        HitSurfaceTangent = info.Tangents[vertexIndex];
                                        HitSurfaceNormal = info.Normals[vertexIndex];
                                        HitSurfaceBitangent = info.Bitangents[vertexIndex];
                                    }
                                    var stride = index * 9;
                                    Debug.WriteLine(triangle.triangleIndex);
                                    GLDebug.QueueLineDraw(stride + 0, triangle.vertex0,
                                        triangle.vertex0 + HitSurfaceNormal.Normalized());
                                    GLDebug.QueueLineDraw(stride + 1, triangle.vertex1,
                                        triangle.vertex1 + HitSurfaceNormal.Normalized());
                                    GLDebug.QueueLineDraw(stride + 2, triangle.vertex2,
                                        triangle.vertex2 + HitSurfaceNormal.Normalized());
                                    GLDebug.QueueLineDraw(stride + 3, triangle.vertex0,
                                        triangle.vertex0 + HitSurfaceTangent.Normalized());
                                    GLDebug.QueueLineDraw(stride + 4, triangle.vertex1,
                                        triangle.vertex1 + HitSurfaceTangent.Normalized());
                                    GLDebug.QueueLineDraw(stride + 5, triangle.vertex2,
                                        triangle.vertex2 + HitSurfaceTangent.Normalized());
                                    GLDebug.QueueLineDraw(stride + 6, triangle.vertex0,
                                        triangle.vertex0 + HitSurfaceBitangent.Normalized());
                                    GLDebug.QueueLineDraw(stride + 7, triangle.vertex1,
                                        triangle.vertex1 + HitSurfaceBitangent.Normalized());
                                    GLDebug.QueueLineDraw(stride + 8, triangle.vertex2,
                                        triangle.vertex2 + HitSurfaceBitangent.Normalized());
                                }
                            }
                        }
                        HitSurfaceBitangent = Vector3.Normalize(HitSurfaceBitangent);
                        HitSurfaceNormal = Vector3.Normalize(HitSurfaceNormal);
                        HitSurfaceTangent = Vector3.Normalize(HitSurfaceTangent);
                        HitSurfaceNormal.Normalize();
                    }
                    return value;
                }
                return ClosestHitFraction;
            }

            public override bool NeedsCollision( BroadphaseProxy proxy0 )
            {
                if ( proxy0.ClientObject == _collisionObject )
                    return false;
                var value = base.NeedsCollision( proxy0 );
                if ( value == false )
                {
                    
                }
                return value;
            }
        }

        public Vector3 debugPoint0;
        public Vector3 debugPoint1;
        public Vector3 debugPoint2;
        public Vector3 debugPoint3;

        public void OnMouseMove( object sender, SceneMouseEventArgs e )
        {

            var state = Mouse.GetState( );
            //if ( !state.IsButtonDown( MouseButton.Left ) ) return;

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

            GLDebug.QueuePointDraw(0, mouse.Close);
            GLDebug.QueuePointDraw(0, mouse.Far);

            var rayCallback = new ClosestNotMeRayResultCallback( selectedCollisionObject, mouse.Close, mouse.Far )
            {
                CollisionFilterGroup = ( CollisionFilterGroups ) CollisionGroup.Level,
                CollisionFilterMask = ( CollisionFilterGroups ) ( CollisionGroup.Level | CollisionGroup.Objects )
            };


            dynamicScene.CollisionManager.World.RayTest( mouse.Close, mouse.Far, rayCallback );
            if ( !rayCallback.HasHit ) return;


            var surfaceNormal = rayCallback.HitSurfaceNormal;
            var surfaceTangent = rayCallback.HitSurfaceTangent;
            var surfaceBitangent = rayCallback.HitSurfaceBitangent;

            var basisMatrix = new Matrix4( new Vector4( surfaceTangent ), new Vector4( surfaceBitangent ),
                new Vector4( surfaceNormal ), new Vector4( 0, 0, 0, 1 ) );


            var destination = MouseWorldPosition = rayCallback.HitPointWorld;

            var convexCallback = new ClosestNotMeConvexResultCallback( selectedCollisionObject,
                selectedCollisionObject.WorldTransform.ExtractTranslation( ), destination )
            {
                CollisionFilterGroup = ( CollisionFilterGroups ) CollisionGroup.Level,
                CollisionFilterMask = ( CollisionFilterGroups ) ( CollisionGroup.Level | CollisionGroup.Objects )
            };


            var convexShape = selectedCollisionObject.CollisionShape.IsConvex
                ? ( ConvexShape ) selectedCollisionObject.CollisionShape
                : null;


            var from = basisMatrix * Matrix4.CreateTranslation( e.Camera.WorldMatrix.ExtractTranslation( ) );
            var to = basisMatrix * Matrix4.CreateTranslation( destination );

            dynamicScene.CollisionManager.World.ConvexSweepTest( convexShape, from, to, convexCallback );

            if ( convexCallback.HasHit )
            {
                Debug.WriteLine( "hit" );

                Vector3 linVel;
                Vector3 angVel;
                TransformUtil.CalculateVelocity( from, to, 1.0f, out linVel, out angVel );
                Matrix4 T;
                TransformUtil.IntegrateTransform( from, linVel, angVel, convexCallback.ClosestHitFraction, out T );


                var instanceBasis =
                    scenarioObject.InstanceBasisMatrices[selectedCollisionObject.UserIndex];

                scenarioObject.AssignInstanceBasisTransform(selectedCollisionObject.UserIndex, basisMatrix);
                
                var upAxis = instanceBasis.Row2.Xyz.Normalized();

                GLDebug.QueueLineDraw(0, selectedCollisionObject.WorldTransform.ExtractTranslation(),
                    selectedCollisionObject.WorldTransform.ExtractTranslation() + upAxis);


                var instanceRotation = scenarioObject.InstanceRotations[selectedCollisionObject.UserIndex];

                //selectedScenarioObject.SetAxisAlignedRotation( selectedCollisionObject.UserIndex, rotation );

                var R = Quaternion.FromAxisAngle(upAxis, _axisAlignedRotation);

                selectedCollisionObject.WorldTransform = instanceBasis * Matrix4.CreateFromQuaternion(R) * Matrix4.CreateTranslation(T.ExtractTranslation());

                debugPoint2 = T.ExtractTranslation( );
                debugPoint3 = convexCallback.HitPointWorld + convexCallback.HitNormalWorld;

               // selectedCollisionObject.WorldTransform = T;
                //var localMatrix = scenarioObject.collisionSpaceMatrix.Inverted() * t.Inverted() * T;
               // scenarioObject.InstanceRotations[selectedCollisionObject.UserIndex] = instanceRotation;
                selectedScenarioObject.SetAxisAlignedRotation(selectedCollisionObject.UserIndex, _axisAlignedRotation);
                scenarioObject.InstancePositions[ selectedCollisionObject.UserIndex ] = (scenarioObject.collisionSpaceMatrix.Inverted(  ) *  T).ExtractTranslation(  );
                   // localMatrix.ExtractTranslation( );
            }
        }

        private Matrix4 Transform( Vector3 translation, Vector3 scale, Quaternion rotation )
        {
            var T = Matrix4.CreateTranslation( translation );
            var S = Matrix4.CreateScale( scale );
            var R = Matrix4.CreateFromQuaternion( rotation );
            return S * R * T;
        }

        public void OnMouseUp( object sender, SceneMouseEventArgs e )
        {
            selectedCollisionObject = null;
        }

        public void OnMouseClick( object sender, SceneMouseEventArgs e )
        {
            throw new NotImplementedException( );
        }

        public void OnMouseCaptureChanged( object sender, SceneMouseEventArgs e )
        {
            throw new NotImplementedException( );
        }

        public void OnUpdate( object sender, EventArgs e )
        {
            float delta = 0.00f;
            var state = OpenTK.Input.Keyboard.GetState( );
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

            if ( selectedCollisionObject == null ) return;
            var scenarioObject = selectedCollisionObject.UserObject as ScenarioObject;
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
    }
}
