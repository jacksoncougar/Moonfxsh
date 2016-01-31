using BulletSharp;
using Moonfish.Collision;
using OpenTK;

namespace Moonfish.Graphics
{
    public class ClosestRayResultCullFaceCallback : ClosestRayResultCallback
    {
        private bool _ccw;

        public ClosestRayResultCullFaceCallback( ref Vector3 rayFromWorld, ref Vector3 rayToWorld, bool ccw = true )
            : base( ref rayFromWorld, ref rayToWorld )
        {
            _ccw = ccw;
        }

        public ClosestRayResultCullFaceCallback( Vector3 rayFromWorld, Vector3 rayToWorld, bool ccw = true)
            : base( rayFromWorld, rayToWorld )
        {
            _ccw = ccw;
        }

        public override float AddSingleResult( LocalRayResult rayResult, bool normalInWorldSpace )
        {
            var meshObject = rayResult.CollisionObject.CollisionShape as BvhTriangleMeshShape;
            if ( meshObject == null )
                return base.AddSingleResult( rayResult, normalInWorldSpace );
            ;

            var triangleBuffer = new TriangleBuffer( );
            meshObject.PerformRaycast( triangleBuffer, RayFromWorld, RayToWorld );

            var rayFromWorld = RayFromWorld;
            var rayTarget = RayToWorld - rayFromWorld;
            float closestFrontFace = 1f;
            for ( int i = 0; i < triangleBuffer.NumTriangles; i++ )
            {
                var triangle = triangleBuffer.GetTriangle( i );

                var edge1 = triangle.vertex1 - triangle.vertex0;
                var edge2 = triangle.vertex2 - triangle.vertex0;
                var normal = Vector3.Cross( edge1, edge2 );

                var dot = _ccw ? Vector3.Dot( rayTarget, normal ) : -Vector3.Dot( normal, rayTarget );
                if ( dot > 0 ) continue;

                float t;
                if ( TriangleRayIntersection.Test( triangle.vertex0, triangle.vertex1, triangle.vertex2,
                    rayFromWorld, rayTarget, out t ) )
                {
                    closestFrontFace = closestFrontFace < t ? closestFrontFace : t;
                }
            }
            rayResult.HitFraction = closestFrontFace;
            if ( closestFrontFace < ClosestHitFraction )
                base.AddSingleResult( rayResult, normalInWorldSpace );
            return closestFrontFace;
        }
    }
}