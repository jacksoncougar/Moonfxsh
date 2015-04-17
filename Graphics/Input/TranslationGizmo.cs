using System;
using System.Drawing;
using Moonfish.Collision;
using Moonfish.Graphics.Primitives;
using OpenTK;

namespace Moonfish.Graphics.Input
{
    public class TranslationGizmo : GizmoBase
    {
        private Vector3 _translation;

        public override Matrix4 WorldMatrix
        {
            get { return CalculateWorldMatrix( position + _translation, rotation, scale ); }
            set { base.WorldMatrix = value; }
        }

        private Vector3 FindPlaneNormal( Vector3 viewerAxis, Vector3 axisNormal )
        {
            var planeUNormal = UpNormalized;
            var planeVNormal = RightNormalized;
            var planeWNormal = ForwardNormalized;
            var cosineToNormalU = Vector3.Cross( planeUNormal, axisNormal ).Length;
            var cosineToNormalV = Vector3.Cross( planeVNormal, axisNormal ).Length;
            var cosineToNormalW = Vector3.Cross( planeWNormal, axisNormal ).Length;
            var cosineToPlaneU = Vector3.Cross( planeUNormal, viewerAxis ).Length - cosineToNormalU;
            var cosineToPlaneV = Vector3.Cross( planeVNormal, viewerAxis ).Length - cosineToNormalV;
            var cosineToPlaneW = Vector3.Cross( planeWNormal, viewerAxis ).Length - cosineToNormalW;

            var normal = cosineToPlaneU < cosineToPlaneV
                ? cosineToPlaneU < cosineToPlaneW ? planeUNormal : planeWNormal
                : cosineToPlaneV < cosineToPlaneW ? planeVNormal : planeWNormal;
            return normal;
        }

        protected override void Commit( )
        {
            position += _translation;
            _translation = Vector3.Zero;
            base.Commit( );
        }

        private void SetTranslation( Vector3 translationVector3 )
        {
            var beforeMatrix = CalculateWorldMatrix( position, rotation, scale );
            var afterMatrix = CalculateWorldMatrix( position + translationVector3, rotation, scale );
            _translation = translationVector3;
            OnWorldMatrixChanged( ref beforeMatrix, ref afterMatrix );
        }

        protected override void Transform( SceneMouseMoveEventArgs args )
        {
            if ( selectedAxis == Axis.None ) return;
            var camera = args.Camera;

            var originScreenspace = camera.Project( position );
            var axisNormal = GetAxisNormal( selectedAxis );
            var translation_screenspace = CalculateScreenspaceTranslation( originScreenspace,
                camera.Project( position + axisNormal ), new Vector2( args.X, args.Y ) );

            var near = camera.UnProject( originScreenspace + translation_screenspace );
            var far = camera.UnProject( originScreenspace + translation_screenspace, -0.01f );

            var mouseRay = new Ray( near, far );

            // Setup and select the collision plane
            var normal = FindPlaneNormal( mouseRay.Direction, axisNormal );
            // Produce the plane-distance from origin from this objects position vector
            var planeOffset = Vector3.Dot( normal, position );
            // We use negetive offset here
            var translationPlane = new Plane( normal, -planeOffset );

            float? distance;
            if ( !translationPlane.Intersects( mouseRay, out distance ) ) return;

            var mouseVector = mouseRay.Origin + mouseRay.Direction * distance.GetValueOrDefault( );
            var mouseProjectionLength = Vector3.Dot( axisNormal, mouseVector );
            var positionProjectionLength = Vector3.Dot( axisNormal, position );
            var translationProjectionLength = ( mouseProjectionLength - positionProjectionLength );

            var vector = ( translationProjectionLength * axisNormal );

            if ( !( vector.Length > 0 ) ) return;
            SetTranslation( vector );
        }
    }

    public class ConstrainedTranslationGizmo : TranslationGizmo
    {
        private Vector3 _pivot;
        private Vector3 _translation;
        private Quaternion _transform;
        public float SinTheta { get; private set; }
        public float CosTheta { get; private set; }
        public Matrix4 FromQuaternion { get; private set; }

        public ConstrainedTranslationGizmo( )
        {
            _transform = Quaternion.Identity;
        }

        public Matrix4 PivotWorldMatrix
        {
            set { _pivot = value.ExtractTranslation( ); }
        }


        public override Matrix4 WorldMatrix
        {
            get
            {
                return CalculateWorldMatrix( position, rotation, scale ) * Matrix4.CreateFromQuaternion( _transform );
            }
            set { base.WorldMatrix = value; }
        }

        private Vector3 FindPlaneNormal( Vector3 viewerAxis, Vector3 axisNormal )
        {
            var planeUNormal = UpNormalized;
            var planeVNormal = RightNormalized;
            var planeWNormal = ForwardNormalized;
            var cosineToNormalU = Vector3.Cross( planeUNormal, axisNormal ).Length;
            var cosineToNormalV = Vector3.Cross( planeVNormal, axisNormal ).Length;
            var cosineToNormalW = Vector3.Cross( planeWNormal, axisNormal ).Length;
            var cosineToPlaneU = Vector3.Cross( planeUNormal, viewerAxis ).Length - cosineToNormalU;
            var cosineToPlaneV = Vector3.Cross( planeVNormal, viewerAxis ).Length - cosineToNormalV;
            var cosineToPlaneW = Vector3.Cross( planeWNormal, viewerAxis ).Length - cosineToNormalW;

            var normal = cosineToPlaneU < cosineToPlaneV
                ? cosineToPlaneU < cosineToPlaneW ? planeUNormal : planeWNormal
                : cosineToPlaneV < cosineToPlaneW ? planeVNormal : planeWNormal;
            return normal;
        }

        protected override void Commit( )
        {
            rotation =
                ( CalculateWorldMatrix( position, rotation, scale ) * Matrix4.CreateFromQuaternion( _transform ) )
                    .ExtractRotation( );
            position =
                ( CalculateWorldMatrix( position, rotation, scale ) * Matrix4.CreateFromQuaternion( _transform ) )
                    .ExtractTranslation( );
            rotation.Normalize( );
            _transform = Quaternion.Identity;
            base.Commit( );
        }

        private void SetTranslation( Vector3 translationVector3 )
        {
            var beforeMatrix = CalculateWorldMatrix( position, rotation, scale );
            var afterMatrix = CalculateWorldMatrix( position + translationVector3, rotation, scale );
            _translation = translationVector3;
            OnWorldMatrixChanged( ref beforeMatrix, ref afterMatrix );
        }

        protected override void Transform( SceneMouseMoveEventArgs args )
        {
            if ( selectedAxis == Axis.None ) return;

            var camera = args.Camera;
            var originScreenspace = camera.Project( _pivot );
            var axisNormal = GetAxisNormal( selectedAxis );
            var translation_screenspace = CalculateScreenspaceTranslation( originScreenspace,
                camera.Project( position + axisNormal ), new Vector2( args.X, args.Y ) );

            var near = camera.UnProject( new Vector2( args.X, args.Y ) );
            var far = camera.UnProject( new Vector2( args.X, args.Y ), -0.01f );

            var mouseRay = new Ray( near, far );

            // Setup and select the collision plane
            var normal = Vector3.UnitZ; // FindPlaneNormal(mouseRay.Direction, axisNormal);
            // Produce the plane-distance from origin from this objects position vector
            var planeOffset = Vector3.Dot( normal, position );
            // We use negetive offset here
            var translationPlane = new Plane( normal, -planeOffset );

            float? distance;
            if ( !translationPlane.Intersects( mouseRay, out distance ) ) return;

            var mouseVector = mouseRay.Origin + mouseRay.Direction * distance.GetValueOrDefault( );
            var mouseProjectionLength = Vector3.Dot( axisNormal, mouseVector );
            var positionProjectionLength = Vector3.Dot( axisNormal, position );
            var translationProjectionLength = ( mouseProjectionLength - positionProjectionLength );

            var positionVector = WorldMatrix.ExtractTranslation( );
            var translationVector = mouseVector - _pivot;
            var vector = ( mouseProjectionLength * axisNormal );
            var length = ( position - _pivot ).Length;
            var t = ( mouseVector - _pivot ).Normalized( ) * length;
            var normalizedPositionVector = positionVector.Normalized( );
            var normalizedTransformVector = ( _pivot + t ).Normalized( );
            CosTheta = Vector3.Dot( normalizedPositionVector, normalizedTransformVector );
            SinTheta = Vector3.Cross( normalizedPositionVector, normalizedTransformVector ).Length;

            var atanPosition = Math.Atan2( normalizedPositionVector.Y, normalizedPositionVector.X );
            var atanTransform = Math.Atan2( normalizedTransformVector.Y, normalizedTransformVector.X );


            var angle = atanTransform - atanPosition;

            var transform = Quaternion.FromAxisAngle( normal, ( float ) translationProjectionLength ).Normalized( );
                // (positionVector, translationVector);

            FromQuaternion = Matrix4.CreateFromQuaternion( transform );

            var test = CalculateWorldMatrix( position, rotation, scale ) * FromQuaternion;
            var g = test.ExtractTranslation( );

#if DEBUG
            GLDebug.DrawPoint( _pivot, Color.AliceBlue, 5.0f );
            GLDebug.DrawPoint( g, Color.Black, 5.0f );
            GLDebug.Draw2DPoint( originScreenspace, Color.AliceBlue, 5.0f );
            GLDebug.DrawLine( _pivot, mouseVector, Color.Red, 2.0f );
            GLDebug.DrawLine( position + vector, position, Color.Aquamarine, 2.0f );
            GLDebug.DrawLine( position + vector, _pivot, Color.BlueViolet, 1.0f );
            GLDebug.DrawLine( _pivot + vector, _pivot, Color.RoyalBlue, 2.0f );
            GLDebug.DrawLine( _pivot + normal, _pivot, Color.Aqua, 2.0f );
            GLDebug.DrawLine( _pivot + t, _pivot, Color.LawnGreen, 2.0f );
            //GLDebug.DrawLine(_pivot + axisNormal, _pivot, Color.SpringGreen, 1.0f);
#endif

            SetTransform( transform );
        }

        private void SetTransform( Quaternion transform )
        {
            _transform = transform;

            var beforeMatrix = CalculateWorldMatrix( position, rotation, scale );
            var afterMatrix = CalculateWorldMatrix( position, _transform * rotation, scale );
            OnWorldMatrixChanged( ref beforeMatrix, ref afterMatrix );
        }

        private Quaternion FromTwoVectors( Vector3 u, Vector3 v )
        {
            float norm_u_norm_v = ( float ) Math.Sqrt( Vector3.Dot( u, u ) * Vector3.Dot( v, v ) );
            float real_part = norm_u_norm_v + Vector3.Dot( u, v );
            Vector3 w;

            if ( real_part.NearlyEqual( norm_u_norm_v ) )
            {
                /* If u and v are exactly opposite, rotate 180 degrees
                * around an arbitrary orthogonal axis. Axis normalisation
                * can happen later, when we normalise the quaternion. */
                real_part = 0.0f;
                w = Math.Abs( u.X ) > Math.Abs( u.Z )
                    ? new Vector3( -u.Y, u.X, 0.0f )
                    : new Vector3( 0.0f, -u.Z, u.Y );
            }
            else
            {
                /* Otherwise, build quaternion the standard way. */
                w = Vector3.Cross( u, v );
            }

            return new Quaternion( real_part, w.X, w.Y, w.Z ).Normalized( );
        }
    }
}