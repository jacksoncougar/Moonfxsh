using Moonfish.Collision;
using OpenTK;
using OpenTK.Graphics.ES30;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Moonfish.Graphics.Input
{
    public enum TransformMode
    {
        World,
        Local,
    }
    public class MousePole2D : IDisposable
    {
        public TransformMode Mode { get; set; }
        public Vector3 Position
        {
            get { return this.Position; }
            set
            {
                var previousWorldMatrix = CalculateWorldMatrix( );
                this.position = value;
                var worldMatrix = CalculateWorldMatrix( );
                if( WorldMatrixChanged != null )
                    WorldMatrixChanged( this, new MatrixChangedEventArgs( previousWorldMatrix, worldMatrix ) );
            }
        }

        public Quaternion Rotation
        {
            get { return this.rotation; }
            set
            {
                var previousWorldMatrix = CalculateWorldMatrix( );
                this.rotation = value;
                var worldMatrix = CalculateWorldMatrix( );
                if( WorldMatrixChanged != null )
                    WorldMatrixChanged( this, new MatrixChangedEventArgs( previousWorldMatrix, worldMatrix ) );
            }
        }

        Matrix4 CalculateWorldMatrix( )
        {
            var translationMatrix = Matrix4.CreateTranslation( this.position );
            var rotationMatrix = Matrix4.CreateFromQuaternion( this.rotation );
            var scaleMatrix = Matrix4.CreateScale( this.scale );
            var worldMatrix = rotationMatrix *  translationMatrix ;
            return worldMatrix;
        }

        public event MatrixChangedEventHandler WorldMatrixChanged;
        public Action<Matrix4> SetWorldMatrix;

        Vector3 position;
        Vector3 origin;
        Vector3 right, forward, up;
        Quaternion rotation;
        int[] glBuffers;
        int elementCount;

        public bool Hidden { get; private set; }

        BulletSharp.CollisionObject rightContact, forwardContact, upContact;
        SelectedAxis selectedAxis;

        Vector3 worldRegistrationPosition, lineRegistration;
        Matrix4 viewMatrix, projectionMatrix;
        Rectangle viewport;

        float scale;

        [Flags]
        public enum SelectedAxis
        {
            None = 0,
            U = 1,
            V = 2,
            W = 4
        }

        public void OnMouseDown( object sender, MouseEventArgs e )
        {
            throw new NotImplementedException();
            //if( Hidden ) return;
            //var scene = sender;
            //if( scene != null && e.Button == MouseButtons.Left )
            //{
            //    var callback = new BulletSharp.CollisionWorld.ClosestRayResultCallback( e.MouseRay.Origin, e.MouseRay.Origin + e.MouseRay.Direction * e.MouseRayFarPoint );
            //    var collisionWorld = //scene.CollisionManager.World;
            //    collisionWorld.RayTest( e.MouseRay.Origin, e.MouseRay.Origin + e.MouseRay.Direction * e.MouseRayFarPoint, callback );

            //    if( callback.HasHit )
            //    {
            //        if( callback.CollisionObject == rightContact )
            //            this.selectedAxis = SelectedAxis.U;
            //        else if( callback.CollisionObject == forwardContact )
            //            this.selectedAxis = SelectedAxis.V;
            //        else if( callback.CollisionObject == upContact )
            //            this.selectedAxis = SelectedAxis.W;
            //        else return;
            //        worldRegistrationPosition = callback.HitPointWorld - this.position;
            //    }
            //}
        }

        public void OnMouseUp( object sender, MouseEventArgs e )
        {
            if( Hidden ) return;
            if( e.Button == MouseButtons.Left )
            {
                selectedAxis = SelectedAxis.None;
            }
        }

        public void OnMouseMove( object sender, MouseEventArgs e )
        {
            if( Hidden ) return;
            if( selectedAxis != SelectedAxis.None )
            {
                Vector3 intersection;

                var registrationOrigin = ProjectPoint( worldRegistrationPosition );
                var registrationMouse = ProjectScreenPoint( new Vector3( e.ScreenCoordinates ) );

                var mouseRay = new Ray(
                    Maths.Project( viewMatrix, projectionMatrix, registrationMouse.Xy, depth: -1, viewport: viewport ).Xyz,
                    Maths.Project( viewMatrix, projectionMatrix, registrationMouse.Xy, depth: 1, viewport: viewport ).Xyz
                    );

                var registrationRay = new Ray(
                    Maths.Project( viewMatrix, projectionMatrix, registrationOrigin.Xy, depth: -1, viewport: viewport ).Xyz,
                    Maths.Project( viewMatrix, projectionMatrix, registrationOrigin.Xy, depth: 1, viewport: viewport ).Xyz
                    );


                var viewerAxis = ( mouseRay.Origin - origin ).Normalized( );
                viewerAxis.Normalize( );

                // Setup and select the collision plane
                var planeUNormal = new Vector3( 0, 0, 0 );
                var planeVNormal = new Vector3( 0, 0, 0 );
                var translationNormal = new Vector3( 0, 0, 0 );
                if( selectedAxis.HasFlag( SelectedAxis.U ) )
                {
                    planeUNormal = up;
                    planeVNormal = forward;
                    translationNormal = right;
                }
                else if( selectedAxis.HasFlag( SelectedAxis.V ) )
                {
                    planeUNormal = right;
                    planeVNormal = up;
                    translationNormal = forward;
                }
                else if( selectedAxis.HasFlag( SelectedAxis.W ) )
                {
                    planeUNormal = right;
                    planeVNormal = forward;
                    translationNormal = up;
                }
                else return;

                Vector3.Normalize( ref planeUNormal, out planeUNormal );
                Vector3.Normalize( ref planeVNormal, out planeVNormal );
                Vector3.Normalize( ref translationNormal, out translationNormal );

                // Calculate the perpendicularness values
                var cosineToPlaneU = Vector3.Cross( viewerAxis, planeUNormal ).LengthFast;
                var cosineToPlaneV = Vector3.Cross( viewerAxis, planeVNormal ).LengthFast;

                // Select the most perpendicular plane
                var translationPlaneNormal = planeUNormal;
                if( cosineToPlaneU > cosineToPlaneV )
                {
                    translationPlaneNormal = planeVNormal;
                }

                // Produce the plane-distance from origin from this obejcts position vector
                var planeOffset = Vector3.Dot( translationPlaneNormal, origin );

                var translationPlane = new Plane( translationPlaneNormal, -planeOffset );

                float? hit, registrationHit;
                if( translationPlane.Intersects( mouseRay, out hit )
                    && translationPlane.Intersects( registrationRay, out registrationHit ) )
                {
                    //// Debug drawing code
                    //GL.VertexAttrib3(1, new[] { 230f / 255f, 128f / 255f, 0f / 255f });
                    //DebugDrawer.DrawPlane(translationPlane);
                    //using (Form1.ScreenProgram.Use())
                    //{
                    //    GL.VertexAttrib3(1, new[] { 225f / 255f, 128f / 255f, 255f / 255f });
                    //    DebugDrawer.DrawPoint(mouseRay.Origin + mouseRay.Direction * hit.Value, pointSize: 7);
                    //    GL.VertexAttrib3(1, new[] { 15f / 255f, 128f / 255f, 255f / 255f });
                    //    DebugDrawer.DrawPoint(registrationRay.Origin + registrationRay.Direction * registrationHit.Value, pointSize: 9);
                    //}
                    var componentU = Vector3.Dot( planeUNormal, this.position ) * planeUNormal;
                    var componentV = Vector3.Dot( planeVNormal, this.position ) * planeVNormal;
                    var dot = Vector3.Dot( translationNormal, mouseRay.Origin + mouseRay.Direction * hit.Value );
                    var translation = translationNormal * Vector3.Dot( translationNormal, mouseRay.Origin + mouseRay.Direction * hit.Value );
                    var registrationOffset = translationNormal * Vector3.Dot( translationNormal, worldRegistrationPosition );
                    var actualtranslation = mouseRay.Origin + mouseRay.Direction * hit.Value;
                    this.Position = translation - registrationOffset + componentU + componentV;

                }

            }
        }

        public void OnCameraUpdate( object sender, CameraEventArgs e )
        {
            if( Hidden ) return;
            this.scale = e.Camera.CreateScale( origin, 0.5f, pixelSize: 30 );
            var scaleMatrix = Matrix4.CreateScale( scale, scale, scale );

            var rotationMatrix = Mode == TransformMode.Local ? Matrix4.CreateFromQuaternion( this.rotation ) : Matrix4.Identity;

            this.origin = this.position + Vector3.Transform( new Vector3( 0, 0, 0 ), scaleMatrix * rotationMatrix );
            this.right = Vector3.Transform( new Vector3( 1, 0, 0 ), scaleMatrix * rotationMatrix );
            this.forward = Vector3.Transform( new Vector3( 0, 1, 0 ), scaleMatrix * rotationMatrix );
            this.up = Vector3.Transform( new Vector3( 0, 0, 1 ), scaleMatrix * rotationMatrix );

            var contactSize = 0.2f * scale;

            rightContact.CollisionShape = new BulletSharp.SphereShape( contactSize );
            forwardContact.CollisionShape = new BulletSharp.SphereShape( contactSize );
            upContact.CollisionShape = new BulletSharp.SphereShape( contactSize );

            rightContact.WorldTransform = Matrix4.CreateTranslation( this.origin + right );
            forwardContact.WorldTransform = Matrix4.CreateTranslation( this.origin + forward );
            upContact.WorldTransform = Matrix4.CreateTranslation( this.origin + up );

            this.Dispose( false );
            BufferData( e.Camera );
        }

        private Vector3 ProjectScreenPoint( Vector3 screenCoordinate )
        {
            var axisDirection = origin;
            switch( selectedAxis )
            {
                case SelectedAxis.U:
                    axisDirection = origin + right;
                    break;
                case SelectedAxis.V:
                    axisDirection = origin + forward;
                    break;
                case SelectedAxis.W:
                    axisDirection = origin + up;
                    break;
            }
            var pointA = Maths.UnProject( viewMatrix * projectionMatrix, origin, viewport, Maths.ProjectionTarget.View );
            var pointB = Maths.UnProject( viewMatrix * projectionMatrix, axisDirection, viewport, Maths.ProjectionTarget.View );

            var lineNormal = ( pointB - pointA ).Normalized( );
            var dotProduct = Vector3.Dot( screenCoordinate - pointA, lineNormal );
            var intersection = pointA + lineNormal * dotProduct;
            return intersection;
        }

        /// <summary>
        /// Projects the worldCoordinate onto the currently selected axis
        /// </summary>
        /// <param name="worldCoordinate"></param>
        /// <returns>projected point in screen-space</returns>
        private Vector3 ProjectPoint( Vector3 worldCoordinate )
        {
            var axisDirection = origin;
            switch( selectedAxis )
            {
                case SelectedAxis.U:
                    axisDirection = origin + right;
                    break;
                case SelectedAxis.V:
                    axisDirection = origin + forward;
                    break;
                case SelectedAxis.W:
                    axisDirection = origin + up;
                    break;
            }
            var pointA = Maths.UnProject( viewMatrix * projectionMatrix, origin, viewport, Maths.ProjectionTarget.View );
            var pointB = Maths.UnProject( viewMatrix * projectionMatrix, axisDirection, viewport, Maths.ProjectionTarget.View );
            var pointC = Maths.UnProject( viewMatrix * projectionMatrix, worldCoordinate, viewport, Maths.ProjectionTarget.View );


            var lineNormal = ( pointB - pointA ).Normalized( );
            var dotProduct = Vector3.Dot( pointC - pointA, lineNormal );
            var intersection = pointA + lineNormal * dotProduct;
            return intersection;
        }

        public MousePole2D( Camera camera )
            : this( camera, new Vector3( 0, 1, 0 ), new Vector3( 1, 0, 0 ), new Vector3( 0, 0, 1 ) )
        {
        }

        public MousePole2D( Camera camera, Vector3 forwardAxis, Vector3 rightAxis, Vector3 upAxis )
        {
            this.scale = camera.CreateScale( origin, 0.5f, pixelSize: 85 );
            var scaleMatrix = Matrix4.CreateScale( scale, scale, scale );

            var rotationX = Matrix3.CreateRotationX( (float)Math.Acos( Vector3.Dot( Vector3.UnitX, rightAxis ) ) );
            var rotationY = Matrix3.CreateRotationY( (float)Math.Acos( Vector3.Dot( Vector3.UnitY, forwardAxis ) ) );
            var rotationZ = Matrix3.CreateRotationZ( (float)Math.Acos( Vector3.Dot( Vector3.UnitZ, upAxis ) ) );
            this.rotation = Quaternion.FromMatrix( rotationX * rotationY * rotationZ );
            var rotationMatrix = Matrix4.CreateFromQuaternion( this.rotation );

            this.origin = Vector3.Transform( new Vector3( 0, 0, 0 ), scaleMatrix * rotationMatrix );
            this.right = Vector3.Transform( new Vector3( 1, 0, 0 ), scaleMatrix * rotationMatrix );
            this.forward = Vector3.Transform( new Vector3( 0, 1, 0 ), scaleMatrix * rotationMatrix );
            this.up = Vector3.Transform( new Vector3( 0, 0, 1 ), scaleMatrix * rotationMatrix );

            rightContact = new BulletSharp.CollisionObject( ) { UserObject = this };
            forwardContact = new BulletSharp.CollisionObject( ) { UserObject = this };
            upContact = new BulletSharp.CollisionObject( ) { UserObject = this };

            BufferData( camera );
            camera.ViewMatrixChanged += camera_ViewMatrixChanged;
            camera.Viewport.ProjectionChanged += Viewport_ProjectionChanged;
            camera.Viewport.ViewportChanged += Viewport_ViewportChanged;
            OnCameraUpdate( this, new CameraEventArgs( camera ) );
        }

        void Viewport_ViewportChanged( object sender, Viewport.ViewportEventArgs e )
        {
            this.viewport = e.Viewport;
        }

        void Viewport_ProjectionChanged( object sender, MatrixChangedEventArgs e )
        {
            this.projectionMatrix = e.Matrix;
        }

        void camera_ViewMatrixChanged( object sender, MatrixChangedEventArgs e )
        {
            this.viewMatrix = e.Matrix;
        }

        public void Render( Program shaderProgram )
        {
            if( Hidden ) return;
            using( shaderProgram.Use( ) )
            using( OpenGL.Enable( EnableCap.PrimitiveRestartFixedIndex ) )
            {
                var worldMatrixUniform = shaderProgram.GetUniformLocation("worldMatrix");
                shaderProgram.SetUniform(worldMatrixUniform, Matrix4.Identity);
                GL.BindVertexArray( glBuffers[0] );
                GL.DrawElements( PrimitiveType.Lines, 6, DrawElementsType.UnsignedShort, IntPtr.Zero );
                GL.DrawElements( PrimitiveType.TriangleFan, elementCount - 6, DrawElementsType.UnsignedShort, (IntPtr)12 );
                GL.BindVertexArray( 0 );
            }
        }

        private void BufferData( Camera camera )
        {
            var coneHeight = 0.25f;
            Conic_ arrow = new Conic_( coneHeight, coneHeight / Maths.Phi );

            var rightArrowCoordinates = TransformCoordinates( ref arrow, this.right );
            var forwardArrowCoordinates = TransformCoordinates( ref arrow, this.forward );
            var upArrowCoordinates = TransformCoordinates( ref arrow, this.up );

            var vertexCount = arrow.VertexCoordinates.Count;

            var magic = 1 - Maths.PhiConjugate;
            var coordinates = new Vector3[] { 
                origin + right * magic, 
                origin + forward * magic, 
                origin + up * magic,
                origin + right, 
                origin + forward, 
                origin + up }
                .Concat( rightArrowCoordinates )
            .Concat( forwardArrowCoordinates )
            .Concat( upArrowCoordinates ).ToArray( );

            var indices = new ushort[] { 0, 3, 1, 4, 2, 5 };
            var offset = indices.Length;
            var rightArrowIndices = arrow.Indices.Select( x => x == ushort.MaxValue ? x : (ushort)( x + offset ) ).ToArray( );
            offset += vertexCount;
            var forwardArrowIndices = arrow.Indices.Select( x => x == ushort.MaxValue ? x : (ushort)( x + offset ) ).ToArray( );
            offset += vertexCount;
            var upArrowIndices = arrow.Indices.Select( x => x == ushort.MaxValue ? x : (ushort)( x + offset ) ).ToArray( );
            indices = indices.Concat( rightArrowIndices ).Concat( new[] { ushort.MaxValue } )
                .Concat( forwardArrowIndices ).Concat( new[] { ushort.MaxValue } )
                .Concat( upArrowIndices ).ToArray( );

            this.elementCount = indices.Length;

            BufferData( coordinates, indices );
        }

        private IEnumerable<Vector3> TransformCoordinates( ref Conic_ arrow, Vector3 targetAxis )
        {
            var normal = targetAxis;
            normal.Normalize( );
            normal.Normalize( );// idk.
            var dot = Vector3.Dot( Vector3.UnitZ, normal );

            var axis = Vector3.Cross( Vector3.UnitZ, normal );
            var projection = axis.Length;
            var angle = (float)Math.Acos( dot );


            var translationMatrix = Matrix4.CreateTranslation( origin + targetAxis );
            var rotationMatrix = dot == 1 || dot == -1 ? Matrix4.Identity : Matrix4.CreateFromAxisAngle( axis, angle );
            var scaleMatrix = Matrix4.CreateScale( this.scale == 0 ? 1 : scale );

            var matrix = scaleMatrix * rotationMatrix * translationMatrix;

            var rightArrowCoordinates = arrow.VertexCoordinates.Select( x => Vector3.Transform( x, matrix ) ).ToArray( );

            return rightArrowCoordinates;
        }

        private void BufferData( Vector3[] coordinates, ushort[] indices )
        {
            this.glBuffers = new[] { GL.GenVertexArray( ), GL.GenBuffer( ), GL.GenBuffer( ) };

            GL.BindVertexArray( glBuffers[0] );

            GL.BindBuffer( BufferTarget.ArrayBuffer, glBuffers[1] );
            GL.BindBuffer( BufferTarget.ElementArrayBuffer, glBuffers[2] );

            // assign colours
            var colourPallet = new[] 
            {
                selectedAxis.HasFlag(SelectedAxis.U) ? Colours.Selection : Colours.Red,
                selectedAxis.HasFlag(SelectedAxis.V) ? Colours.Selection : Colours.Green,
                selectedAxis.HasFlag(SelectedAxis.W) ? Colours.Selection : Colours.Blue
            };
            var colours = colourPallet.SelectMany( x => x.ToFloatRgb( ) ).Concat( colourPallet.SelectMany( x => x.ToFloatRgb( ) ) );

            var colourCount = coordinates.Length - 6;
            var palletDivisor = colourCount / 3;
            for( int i = 0; i < colourCount; ++i )
            {
                var index = ( i / palletDivisor ) % palletDivisor;
                colours = colours.Concat( colourPallet[index].ToFloatRgb( ) );
            }

            var colourArray = colours.ToArray( );

            GL.BufferData<ushort>(
                BufferTarget.ElementArrayBuffer,
                (IntPtr)( sizeof( ushort ) * indices.Length ),
                indices,
                BufferUsageHint.StreamDraw );
            GL.BufferData(
                BufferTarget.ArrayBuffer,
                (IntPtr)( Vector3.SizeInBytes * coordinates.Length + sizeof( float ) * colourArray.Length ),
                IntPtr.Zero,
                BufferUsageHint.StreamDraw );

            BufferPositionData( coordinates );

            BufferColourData( Vector3.SizeInBytes * coordinates.Length, colourArray );

            GL.VertexAttribPointer( 0, 3, VertexAttribPointerType.Float, false, 0, 0 );
            GL.VertexAttribPointer( 1, 3, VertexAttribPointerType.Float, false, 0, (IntPtr)( Vector3.SizeInBytes * coordinates.Length ) );

            GL.EnableVertexAttribArray( 0 );
            GL.EnableVertexAttribArray( 1 );

            GL.BindVertexArray( 0 );
        }

        private static void BufferColourData( int offset, float[] colours )
        {
            GL.BufferSubData<float>(
                BufferTarget.ArrayBuffer,
                (IntPtr)( offset ),
                (IntPtr)( sizeof( float ) * colours.Length ),
                colours );
        }

        private static void BufferPositionData( Vector3[] coordinates )
        {
            GL.BufferSubData<Vector3>(
                BufferTarget.ArrayBuffer,
                (IntPtr)0,
                (IntPtr)( Vector3.SizeInBytes * coordinates.Length ),
                coordinates );
        }

        void IDisposable.Dispose( )
        {
            Dispose( disposing: true );
        }

        private void Dispose( bool disposing )
        {
            GL.DeleteVertexArray( glBuffers[0] );
            GL.DeleteBuffer( glBuffers[1] );
            GL.DeleteBuffer( glBuffers[2] );
            if( disposing )
            {
                // call IDisposable on members
                rightContact.Dispose( );
                forwardContact.Dispose( );
                upContact.Dispose( );
            }
        }

        public IEnumerable<BulletSharp.CollisionObject> ContactObjects
        {
            get
            {
                yield return rightContact;
                yield return forwardContact;
                yield return upContact;
            }
        }

        internal void DropHandlers( )
        {
            SetWorldMatrix = null;
            WorldMatrixChanged = null;
        }

        internal void Hide( )
        {
            this.Hidden = true;
        }

        internal void Show( )
        {
            this.Hidden = false;
        }
    };
}
