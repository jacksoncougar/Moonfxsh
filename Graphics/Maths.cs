using OpenTK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Moonfish.Graphics
{
    public static class Maths
    {
        public const int SizeOfMatrix4 = (sizeof(float) * 4 * 4);
        public const float Phi = 1.6180339887f;
        public const float PhiConjugate = 0.6180339887f;
        public const float Pi2 = (float)Math.PI * 2;

        public static T Clamp<T>(this T val, T min, T max) where T : IComparable<T>
        {
            if (val.CompareTo(min) < 0) return min;
            if (val.CompareTo(max) > 0) return max;
            else return val;
        }

        public enum ProjectionTarget
        {
            NormalisedDeviceCoordinates,
            Clip,
            View,
            WorldHomogenous,
            World,
        }
       

        public static Vector4 Project(Matrix4 viewMatrix, Matrix4 projectionMatrix, Vector2 viewportCoordinates, Rectangle viewport, ProjectionTarget projectionTarget = ProjectionTarget.World)
        {
            var viewportNormalisedCoordinates = new Vector3(viewportCoordinates.X, viewportCoordinates.Y, 0.99f);
            return Project(ref viewMatrix, ref projectionMatrix, ref viewportNormalisedCoordinates, viewport, projectionTarget);
        }

        public static Vector4 Project(Matrix4 viewMatrix, Matrix4 projectionMatrix, Vector2 viewportCoordinates, float depth, Rectangle viewport, ProjectionTarget projectionTarget = ProjectionTarget.World)
        {
            var viewportNormalisedCoordinates = new Vector3(viewportCoordinates.X, viewportCoordinates.Y, depth);
            return Project(ref viewMatrix, ref projectionMatrix, ref viewportNormalisedCoordinates, viewport, projectionTarget);
        }

        public static Vector4 Project(Matrix4 viewMatrix, Matrix4 projectionMatrix, Vector3 viewportCoordinates, Rectangle viewport, ProjectionTarget projectionTarget = ProjectionTarget.World)
        {
            return Project(ref viewMatrix, ref projectionMatrix, ref viewportCoordinates, viewport, projectionTarget);
        }

        public static Vector4 Project(ref Matrix4 viewMatrix, ref Matrix4 projectionMatrix, ref Vector3 viewportCoordinates, Rectangle viewport, ProjectionTarget projectionTarget = ProjectionTarget.World)
        {
            // Calculate 'Normalised Device Coordinates'
            // Range: x, y, z [-1:1]
            var x = (2.0f * viewportCoordinates.X) / viewport.Width - 1.0f;
            var y = 1.0f - (2.0f * viewportCoordinates.Y) / viewport.Height;
            var z = viewportCoordinates.Z;

            var normalisedDeviceCoordinates = new Vector3(x, y, z);

            // Calculate Homogenous Clip Coordinates
            // Range: x, y, z, w [-1:1]
            var homogenousClipCoordinates = new Vector4(normalisedDeviceCoordinates.X, normalisedDeviceCoordinates.Y, normalisedDeviceCoordinates.Z, 1.0f);

            if (projectionTarget == ProjectionTarget.Clip)
                return homogenousClipCoordinates;

            // Calculate View Coordinates
            var viewCoordinates = default(Vector4);
            Matrix4 inverseProjectionMatrix;
            Matrix4.Invert(ref projectionMatrix, out inverseProjectionMatrix);
            Vector4.Transform(ref homogenousClipCoordinates, ref inverseProjectionMatrix, out viewCoordinates);
            //viewCoordinates = new Vector4(viewCoordinates.X, viewCoordinates.Y, homogenousClipCoordinates.Z, 0.0f);

            if (projectionTarget == ProjectionTarget.View)
                return viewCoordinates;

            // Calculate World Coordinates
            var worldCoordinate = default(Vector4);
            Matrix4 inverseViewMatrix;
            Matrix4.Invert(ref viewMatrix, out inverseViewMatrix);
            Vector4.Transform(ref viewCoordinates, ref inverseViewMatrix, out worldCoordinate);

            if (projectionTarget == ProjectionTarget.WorldHomogenous)
                return worldCoordinate;

            var perspectiveDivisor = 1.0f / worldCoordinate.W;
            worldCoordinate.X *= perspectiveDivisor;
            worldCoordinate.Y *= perspectiveDivisor;
            worldCoordinate.Z *= perspectiveDivisor;
            worldCoordinate.W *= perspectiveDivisor;

            return worldCoordinate;
        }

        public static Vector3 Project(this Camera camera, Vector2 viewportCoordinates, float depth, 
            ProjectionTarget projectionTarget = ProjectionTarget.World)
        {
            //  map depth to -1 to 1
            depth = Maths.Clamp<float>(depth, 0, 1) * 2 - 1;
            return Project(camera.ViewMatrix, camera.ProjectionMatrix, 
                new Vector3(viewportCoordinates.X, viewportCoordinates.Y, depth), (Rectangle)camera.Viewport, projectionTarget).Xyz;
        }

        public static Vector3 UnProject(Matrix4 viewProjectionMatrix, Vector3 worldCoordinates, Rectangle viewport, 
            ProjectionTarget projectionTarget = ProjectionTarget.NormalisedDeviceCoordinates)
        {
            var normalisedCoordinate = new Vector4(worldCoordinates, 1);
            var matrix = viewProjectionMatrix;

            var screenCoordinates = Vector4.Transform(normalisedCoordinate, matrix);

            screenCoordinates.X /= screenCoordinates.W;
            screenCoordinates.Y /= screenCoordinates.W;
            screenCoordinates.Z /= screenCoordinates.W;
            screenCoordinates.W /= screenCoordinates.W;

            screenCoordinates.Z = -1;

            if (projectionTarget == ProjectionTarget.NormalisedDeviceCoordinates)
                return new Vector3(screenCoordinates.X, screenCoordinates.Y, screenCoordinates.Z);

            var halfWidth = viewport.Width / 2;
            var halfHeight = viewport.Height / 2;

            var x = screenCoordinates.X * halfWidth + halfWidth;
            var y = -screenCoordinates.Y * halfHeight + halfHeight;
            var z = screenCoordinates.Z;

            return new Vector3(x, y, z);
        }

        public static Vector3 UnProject(this Camera camera, Vector3 worldCoordinates, ProjectionTarget projectionTarget = ProjectionTarget.NormalisedDeviceCoordinates)
        {
            return Maths.UnProject(camera.ViewProjectionMatrix, worldCoordinates, (Rectangle)camera.Viewport, projectionTarget);
        }

    }
}
