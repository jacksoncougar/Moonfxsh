using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using OpenTK;

namespace Moonfish.Graphics
{
    public static class MathHelper
    {
        [SuppressMessage( "ReSharper", "CompareOfFloatsByEqualityOperator" )]
        public static bool NearlyEqual( this float a, double value, float epsilon = 0.00001f )
        {
            var absA = Math.Abs( a );
            var absB = Math.Abs( value );
            var diff = Math.Abs( a - value );

            if ( a == value )
            {
                // shortcut, handles infinities
                return true;
            }
            if ( a == 0 || value == 0 || diff < epsilon )
            {
                // a or b is zero or both are extremely close to it
                // relative error is less meaningful here
                return diff < ( epsilon * Double.MinValue );
            }
            // use relative error
            return diff / ( absA + absB ) < epsilon;
        }

        public static Vector3 UnProject( this Camera camera, Vector2 screenCoordinates, float depth = 0.0f )
        {
            return UnProject( camera.ViewProjectionMatrix, screenCoordinates, depth, ( Rectangle ) camera.Viewport ).Xyz;
        }

        private static Vector4 UnProject( Matrix4 viewProjectionMatrix,
            Vector2 viewportCoordinates, float depth, Rectangle viewport )
        {
            // Calculate 'Normalised Device Coordinates'
            // Range: x, y, z [-1:1]
            var x = ( viewportCoordinates.X - viewport.Left ) / viewport.Right * 2.0f - 1.0f;
            var y = ( viewport.Bottom - viewportCoordinates.Y ) / viewport.Height * 2.0f - 1.0f;
            var z = 2.0f * depth - 1.0f;

            var coordinates = new Vector4( x, y, z, 1.0f );

            // Calculate View Coordinates
            Matrix4 inverseMatrix;
            Matrix4.Invert( ref viewProjectionMatrix, out inverseMatrix );
            Vector4.Transform( ref coordinates, ref inverseMatrix, out coordinates );

            var inverseW = 1.0f / coordinates.W;
            coordinates.X *= inverseW;
            coordinates.Y *= inverseW;
            coordinates.Z *= inverseW;
            coordinates.W *= inverseW;

            return coordinates;
        }

        public static Vector2 Project( this Camera camera, Vector3 worldCoordinates )
        {
            return Project( camera.ViewProjectionMatrix, worldCoordinates, ( Rectangle ) camera.Viewport ).Xy;
        }

        private static Vector3 Project( Matrix4 viewProjectionMatrix, Vector3 worldCoordinates, Rectangle viewport )
        {
            var coordinates = new Vector4( worldCoordinates, 1 );
            coordinates = Vector4.Transform( coordinates, viewProjectionMatrix );

            var inverseW = 1.0f / coordinates.W;
            coordinates.X *= inverseW;
            coordinates.Y *= inverseW;
            coordinates.Z *= inverseW;

            //  map coordinates to range [0..1]
            var x = ( coordinates.X * 0.5f + 0.5f ) * viewport.Width;
            var y = ( -coordinates.Y * 0.5f + 0.5f ) * viewport.Height;
            var z = ( coordinates.Z + 1.0f ) * 0.5f;

            return new Vector3( x, y, z );
        }
    }
}