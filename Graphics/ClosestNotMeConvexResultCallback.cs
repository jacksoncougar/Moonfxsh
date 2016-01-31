using BulletSharp;
using Moonfish.Collision;
using OpenTK;

namespace Moonfish.Graphics
{
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

        //public override float AddSingleResult( LocalConvexResult rayResult, bool normalInWorldSpace )
        //{
        //    var meshObject = rayResult.HitCollisionObject.CollisionShape as BvhTriangleMeshShape;
        //    if ( meshObject == null )
        //        return base.AddSingleResult( rayResult, normalInWorldSpace );

        //    var triangleBuffer = new TriangleBuffer( );
        //    Vector3 aabbMax;
        //    Vector3 aabbMin;
        //    _collisionObject.CollisionShape.GetAabb( Matrix4.Identity, out aabbMin, out aabbMax );
        //    var convexDirection = ConvexToWorld - ConvexFromWorld;
        //    meshObject.PerformConvexcast( triangleBuffer, ConvexFromWorld, ConvexToWorld, aabbMin, aabbMax );


        //    float closestFrontFace = 1f;
        //    for ( int i = 0; i < triangleBuffer.NumTriangles; i++ )
        //    {
        //        var triangle = triangleBuffer.GetTriangle( i );

        //        var edge1 = triangle.vertex1 - triangle.vertex0;
        //        var edge2 = triangle.vertex2 - triangle.vertex0;
        //        var normal = Vector3.Cross( edge1, edge2 );

        //        var dot = Vector3.Dot( normal, convexDirection );
        //        if ( dot > 0 ) continue;

        //        float t;
        //        if ( TriangleRayIntersection.Test( triangle.vertex0, triangle.vertex1, triangle.vertex2,
        //            ConvexFromWorld, convexDirection, out t ) )
        //        {
        //            closestFrontFace = closestFrontFace < t ? closestFrontFace : t;
        //        }
        //    }
        //    rayResult.HitFraction = closestFrontFace;
        //    if (closestFrontFace < ClosestHitFraction)
        //        base.AddSingleResult(rayResult, normalInWorldSpace);
        //    return closestFrontFace;
            
        //}
    }
}