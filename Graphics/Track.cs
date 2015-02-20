using Moonfish.Model;
using OpenTK;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moonfish.Graphics
{
    public class PanTrack : Track
    {
        public PanTrack( Track track )
            : base( track )
        {
        }

        public void Pan( float x, float y )
        {
            var worldMatrix = this.WorldMatrix;
            var rightVector = worldMatrix.Row0.Xyz;
            var upVector = worldMatrix.Row1.Xyz;
            this.Position -= upVector * y;
            this.Position -= rightVector * x;
        }

        public override void Update( params float[] input )
        {
            if( input.Length >= 2 ) Pan( input[0], input[1] );
        }
    }

    public class ZoomTrack : Track
    {
        public float Delta { get; set; }
        public Range ZoomRange { get; set; }
        public ZoomTrack( Track track )
            : base( track )
        {
            Delta = 1.0f;
        }

        public void Zoom( float input )
        {
            var zoomDisplacement = -this.Forward * input * Delta;
            var zoomCoordinate = this.Position + zoomDisplacement;
            Position += zoomDisplacement;
        }

        public override void Update( params float[] input )
        {
            if( input.Length == 2 ) Zoom( input[0] * input[1] );
            if( input.Length == 1 ) Zoom( input[0] );
            else if( input.Length > 0 ) Zoom( input[0] );
        }
    }

    public class OrbitTrack : Track
    {
        float azimuth = 0;
        float polar = 0;

        public OrbitTrack( Track track )
            : base( track )
        {
        }
        public override void Update( params float[] input )
        {
            if( input.Length >= 2 ) ArcRotate( input[0], input[1] );
        }
        public void ArcRotate( float polarIncrement, float azimuthIncrement )
        {
            azimuth += MathHelper.DegreesToRadians( azimuthIncrement );
            polar += MathHelper.DegreesToRadians( polarIncrement );

            var worldMatrix = this.WorldMatrix;
            var upVector = worldMatrix.Row1.Xyz;

            Rotation = Quaternion.FromAxisAngle( Vector3.UnitZ, polar );
            Rotation *= Quaternion.FromAxisAngle( Vector3.UnitX, azimuth );
        }
        public override Matrix4 WorldMatrix
        {
            get
            {
                var parentMatrix = ( Parent == null ? Matrix4.Identity : Parent.WorldMatrix );

                var translation_matrix = Matrix4.CreateTranslation( Position );
                var rotation_matrix = Matrix4.CreateFromQuaternion( Rotation );
                var scale_matrix = Matrix4.CreateScale( Scale );

                var transformMatrix = rotation_matrix * translation_matrix * scale_matrix;

                return parentMatrix * transformMatrix;
            }
        }
    }

    public class IdentityTrack : Track
    {
        public IdentityTrack( )
        {
            Rotation = Quaternion.Identity;
            Right = new Vector3( 1, 0, 0 );
            Up = new Vector3( 0, 1, 0 );
            Forward = new Vector3( 0, 0, 1 );
            Position = new Vector3( 0, 0, 5 );
        }
    }

    public class Track : Node
    {
        public Track Parent { get; set; }

        public Vector3 Right { get; set; }
        public Vector3 Up { get; set; }
        public Vector3 Forward { get; set; }

        public override Matrix4 WorldMatrix
        {
            get
            {
                return ( Parent == null ? Matrix4.Identity : Parent.WorldMatrix ) * base.WorldMatrix;
            }
        }

        public Track( )
        {
            Rotation = Quaternion.Identity;
            Right = new Vector3( 1, 0, 0 );
            Up = new Vector3( 0, 1, 0 );
            Forward = new Vector3( 0, 0, 1 );
            Position = new Vector3( 0, 0, 0 );
        }

        public Track( Track copy )
        {
            this.Position = copy.Position;
            this.Rotation = copy.Rotation;
            this.Up = copy.Up;
            this.Right = copy.Right;
            this.Forward = copy.Forward;
        }

        public virtual void Update( params float[] input )
        {
            return;
        }

    }
}
