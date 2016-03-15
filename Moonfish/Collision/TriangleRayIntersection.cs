using System;
using Moonfish.Guerilla;
using Moonfish.Guerilla.Tags;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Moonfish.Collision
{
    public static class TriangleRayIntersection
    {
        public static bool Test( Vector3 vertex1, Vector3 vertex2, Vector3 vertex3, 
            Vector3 rayOrigin, Vector3 rayTarget,
            out float closestHitFraction)
        {
            Vector3 edge1, edge2;
            Vector3 P, Q, T;
            float determinant, inverseDeterminant, u, v;
            float t;
            closestHitFraction = 0;

            //  Find vectors for two edges sharing vertex1
            Vector3.Subtract( ref vertex2, ref vertex1, out edge1 );
            Vector3.Subtract( ref vertex3, ref vertex1, out edge2 );

            //  Begin calculating determinant - also used to caculate u parameter
            Vector3.Cross( ref rayTarget, ref edge2, out P );
            //  If determinant is near zero, ray lies in plane of triangle
            Vector3.Dot( ref edge1, ref P, out determinant );

            //  NOT CULLING
            if ( determinant > -float.Epsilon && determinant < float.Epsilon )
            {
                return false;
            }

            inverseDeterminant = 1.0f / determinant;

            //  Calculate distance from vertex1 to rayOrigin
            Vector3.Subtract( ref rayOrigin, ref vertex1, out T );

            //  Calculate u parameter and test bound
            Vector3.Dot( ref T, ref P, out u );
            u *= inverseDeterminant;

            //  The intersection lie outside of the triangle
            if ( u < 0.0f || u > 1.0f)
            {
                return false;
            }

            Vector3.Cross( ref T, ref edge1, out Q );

            //  Calculate V parameter and test bound
            Vector3.Dot( ref rayTarget, ref Q, out v );
            v *= inverseDeterminant;

            if ( v < 0.0f || u + v > 1.0f )
            {
                return false;
            }

            Vector3.Dot( ref edge2, ref Q, out t );
            t *= inverseDeterminant;

            if ( t > float.Epsilon )
            {
                closestHitFraction = t;
                return true;
            }

            //  No hit, no win
            return false;
        }
    }
}