using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moonfish.Collision
{

    public struct Ray
    {
        public Vector3 Origin;
        public Vector3 Direction;

        public Ray(Vector3 origin, Vector3 direction)
        {
            Origin = origin;
            Direction = (direction - origin).Normalized();
        }
    }

    public struct BoundingBoxAxisAligned
    {
        public readonly Vector3 Origin;
        public readonly float HalfExtents;

        public BoundingBoxAxisAligned(Vector3 origin, float halfExtents)
        {
            this.Origin = origin;
            this.HalfExtents = halfExtents;
        }
    }

    public struct Plane
    {
        public Vector3 Normal;
        public float Distance;

        public Plane(Vector3 normal, float distance)
        {
            this.Normal = normal;
            this.Distance = distance;
        }

        public bool Intersects(Ray ray, out float? closestHitFraction)
        {
            //t = ( ray.Origin [dot] plane.Normal [plus] plane.Distance ) [divided by] ( ray.Direction [dot] plane.Normal )
            closestHitFraction = null;
            var numerator = -(Vector3.Dot(ray.Origin, this.Normal) + this.Distance);
            var denominator = (Vector3.Dot(ray.Direction, this.Normal));
            if (numerator == 0 || denominator == 0) return false;
            closestHitFraction = numerator / denominator;
            return true;
        }
    }
}
