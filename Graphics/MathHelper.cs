using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace Moonfish.Graphics
{
    public static class MathHelper
    {
        public static Vector3 UnProject(this Camera camera, Vector2 screenCoordinates, float depth = 0.0f)
        {
            return UnProject(camera.ViewProjectionMatrix, screenCoordinates, depth, (Rectangle) camera.Viewport).Xyz;
        }

        public static Vector4 UnProject(Matrix4 viewProjectionMatrix,
               Vector2 viewportCoordinates, float depth, Rectangle viewport)
        {
            // Calculate 'Normalised Device Coordinates'
            // Range: x, y, z [-1:1]
            var x = (viewportCoordinates.X - viewport.Left) / viewport.Right * 2.0f - 1.0f;
            var y = (viewport.Bottom - viewportCoordinates.Y) / viewport.Height * 2.0f - 1.0f;
            var z = 2.0f * depth - 1.0f;

            var coordinates = new Vector4(x, y, z, 1.0f);

            // Calculate View Coordinates
            Matrix4 inverseMatrix;
            Matrix4.Invert(ref viewProjectionMatrix, out inverseMatrix);
            Vector4.Transform(ref coordinates, ref inverseMatrix, out coordinates);

            var inverseW = 1.0f / coordinates.W;
            coordinates.X *= inverseW;
            coordinates.Y *= inverseW;
            coordinates.Z *= inverseW;
            coordinates.W *= inverseW;

            return coordinates;
        }

        public static Vector2 Project(this Camera camera, Vector3 worldCoordinates)
        {
            return Project(camera.ViewProjectionMatrix, worldCoordinates, (Rectangle) camera.Viewport).Xy;
        }

        public static Vector3 Project(Matrix4 viewProjectionMatrix, Vector3 worldCoordinates, Rectangle viewport)
        {
            var coordinates = new Vector4(worldCoordinates, 1);
            coordinates = Vector4.Transform(coordinates, viewProjectionMatrix);

            var inverseW = 1.0f / coordinates.W;
            coordinates.X *= inverseW;
            coordinates.Y *= inverseW;
            coordinates.Z *= inverseW;

            //  map coordinates to range [0..1]
            var x = (coordinates.X * 0.5f + 0.5f) * viewport.Width;
            var y = (-coordinates.Y * 0.5f + 0.5f) * viewport.Height;
            var z = (coordinates.Z + 1.0f) * 0.5f;

            return new Vector3(x, y, z);
        }

    }
}
