using OpenTK;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Moonfish.Graphics
{
    public class Camera : Node
    {
        #region Properties
        public Viewport Viewport { get { return viewport; } set { viewport = value; } }
        public Track Track { get { return track; } set { track = value; } }

        public new Vector3 Position
        {
            get
            {
                return base.Position;
            }
            set
            {
                base.Position = value;
                CalculateViewProjectionMatrix( );
            }
        }
        public new Quaternion Rotation
        {
            get
            {
                return base.Rotation;
            }
            set
            {
                base.Rotation = value;
                CalculateViewProjectionMatrix( );
            }
        }

        public Matrix4 ViewMatrix { get; private set; }
        public Matrix4 ProjectionMatrix { get; private set; }
        public Matrix4 ViewProjectionMatrix { get { return ViewMatrix * ProjectionMatrix; } }
        #endregion

        #region Public Methods

        public void Update( )
        {
            Position = track.WorldMatrix.ExtractTranslation( );
            Rotation = track.WorldMatrix.ExtractRotation( );
            if( CameraUpdated != null ) CameraUpdated( this, new CameraEventArgs( this ) );
        }

        Vector2 previousMouseCoordinate;
        public void OnMouseDown( object sender, System.Windows.Forms.MouseEventArgs e )
        {
            if( this.MouseDown != null ) this.MouseDown( this, e );
        }
        public void OnMouseUp( object sender, System.Windows.Forms.MouseEventArgs e )
        {
            if( this.MouseUp != null ) MouseUp( this, e );
        }
        public void OnMouseMove( object sender, System.Windows.Forms.MouseEventArgs e )
        {
            var mouseState = Mouse.GetState( );
            var keyboardState = Keyboard.GetState( );
            var currentMouseCoordinate = new Vector2( e.X, e.Y );
            if( keyboardState.IsKeyDown( Key.ShiftLeft ) && ( mouseState[MouseButton.Middle]
                || ( mouseState[MouseButton.Left] && keyboardState[Key.ControlLeft] ) ) )
            {
                var dd = ( this.Position - Vector3.Zero ).Length;
                var d = dd;
                var previousMouseWorldCoordinate = Maths.Project( ViewMatrix, Viewport.ProjectionMatrix, previousMouseCoordinate, (Rectangle)Viewport, Maths.ProjectionTarget.View );
                var mouseWorldCoordinate = Maths.Project( ViewMatrix, ProjectionMatrix, currentMouseCoordinate, (Rectangle)Viewport, Maths.ProjectionTarget.View );
                var delta = mouseWorldCoordinate - previousMouseWorldCoordinate;
                delta *= d;
                panTrack.Update( delta.X, delta.Y );
            }
            else if( keyboardState.IsKeyDown( Key.AltLeft ) && ( mouseState[MouseButton.Middle]
                || ( mouseState[MouseButton.Left] && keyboardState[Key.ControlLeft] ) ) )
            {
                var previousMouseWorldCoordinate = Maths.Project( ViewMatrix, Viewport.ProjectionMatrix, previousMouseCoordinate, (Rectangle)Viewport, Maths.ProjectionTarget.View );
                var mouseWorldCoordinate = Maths.Project( ViewMatrix, ProjectionMatrix, currentMouseCoordinate, (Rectangle)Viewport, Maths.ProjectionTarget.View );
                var delta = mouseWorldCoordinate - previousMouseWorldCoordinate;
                delta *= 10;
                zoomTrack.Update( delta.Y, keyboardState[Key.ControlLeft] ? 2.5f : 1.0f );
            }
            else if( mouseState[MouseButton.Middle] || ( mouseState[MouseButton.Left] && keyboardState[Key.ControlLeft] ) )
            {
                var delta = currentMouseCoordinate - previousMouseCoordinate;
                //delta *= 10;
                orbitTrack.Update( delta.X, delta.Y);
            }
            if( this.MouseMove != null ) this.MouseMove( this, new MouseEventArgs( this, new Vector2( e.X, e.Y ), default( Vector3 ), e.Button ) );
            previousMouseCoordinate = currentMouseCoordinate;
        }
        public void OnMouseCaptureChanged( object sender, EventArgs e )
        {
            if( this.MouseCaptureChanged != null ) this.MouseCaptureChanged( this, e );
        }

        #endregion

        #region Private Fields
        Vector2 MouseCoordinate;
        Viewport viewport;
        Track track;
        PanTrack panTrack;
        ZoomTrack zoomTrack;
        OrbitTrack orbitTrack;

        #endregion

        #region Private Methods

        void CalculateViewProjectionMatrix( )
        {
            var view_matrix = Matrix4.Invert( track.WorldMatrix );
            var projection_matrix = viewport.ProjectionMatrix;

            this.ViewMatrix = view_matrix;
            this.ProjectionMatrix = projection_matrix;

            Matrix4 view_projection_matrix;
            Matrix4.Mult( ref view_matrix, ref projection_matrix, out view_projection_matrix );
            OnViewProjectionMatrixChanged( new MatrixChangedEventArgs( ref view_projection_matrix ) );
            OnViewMatrixChanged( new MatrixChangedEventArgs( ref view_matrix ) );
        }

        void viewport_ProjectionChanged( object sender, MatrixChangedEventArgs e )
        {
            CalculateViewProjectionMatrix( );
        }

        void OnViewProjectionMatrixChanged( MatrixChangedEventArgs e )
        {
            if( ViewProjectionMatrixChanged != null )
                ViewProjectionMatrixChanged( this, e );
        }

        void OnViewMatrixChanged( MatrixChangedEventArgs e )
        {
            if( ViewMatrixChanged != null )
                ViewMatrixChanged( this, e );
        }

        #endregion

        #region Constructors
        public Camera( )
        {
            viewport = new Viewport( );
            track = new Track( );

            track.Parent = panTrack = new PanTrack( track );
            track.Parent.Parent = orbitTrack = new OrbitTrack( track );
            track.Parent.Parent.Parent = zoomTrack = new ZoomTrack( track );

            zoomTrack.Zoom( -5f );

            viewport.ProjectionChanged += viewport_ProjectionChanged;

            orbitTrack.Update( 70, 60 );

            this.Update( );
        }
        #endregion

        #region Events

        public event MouseMoveEventHandler MouseMove;

        public event MouseEventHandler MouseUp;

        public event MouseEventHandler MouseDown;

        public event EventHandler MouseCaptureChanged;

        public event EventHandler<CameraEventArgs> CameraUpdated;

        public event ViewMatrixChangedEventHandler ViewMatrixChanged;

        public event ViewProjectionMatrixChangedEventHandler ViewProjectionMatrixChanged;

        #endregion

        internal float CreateScale( Vector3 origin, float halfExtents, float pixelSize )
        {
            var pointA = origin;
            var pointB = origin + this.WorldMatrix.Row0.Xyz * halfExtents;
            var screenPointA = this.UnProject( pointA, Maths.ProjectionTarget.View );
            var screenPointB = this.UnProject( pointB, Maths.ProjectionTarget.View );
            var currentPixelSize = ( screenPointB - screenPointA ).Length;

            var scale = pixelSize / currentPixelSize;
            return scale;
        }
    }
    public class CameraEventArgs : EventArgs
    {
        public Camera Camera;

        public CameraEventArgs( Camera camera )
        {
            this.Camera = camera;
        }
    }

    public class Viewport
    {
        #region Constants
        const int max_width_8k = 4320;
        const int max_height_8k = 7680;
        const int default_width = 640;
        const int default_height = 480;
        #endregion

        #region Properties
        public int Width
        {
            get { return width; }
            set
            {
                if( isValidWidth( value ) )
                {
                    width = value;
                    CalculateProjectionMatrix( );
                    if( this.ViewportChanged != null ) this.ViewportChanged( this, new ViewportEventArgs( (Rectangle)this ) );
                }
            }
        }
        public int Height
        {
            get { return height; }
            set
            {
                if( isValidHeight( value ) )
                {
                    height = value;
                    CalculateProjectionMatrix( );
                    if( this.ViewportChanged != null ) this.ViewportChanged( this, new ViewportEventArgs( (Rectangle)this ) );
                }
            }
        }
        public Size Size
        {
            get { return new Size( width, height ); }
            set
            {
                if( isValidWidth( value.Width ) && isValidHeight( value.Height ) )
                {
                    width = value.Width;
                    height = value.Height;
                    CalculateProjectionMatrix( );
                    if( this.ViewportChanged != null ) this.ViewportChanged( this, new ViewportEventArgs( (Rectangle)this ) );
                }
            }
        }

        public float ZNear { get { return z_near; } }
        #endregion

        #region Internal Properties
        internal Matrix4 ProjectionMatrix { get { return projection_matrix; } }
        #endregion

        #region Private Fields
        private Matrix4 projection_matrix;
        private int width;
        private int height;
        private float z_near;
        private float z_far;
        private float field_of_view;
        #endregion

        #region Private Methods
        bool isValidWidth( int value )
        {
            return ( value > 0 && value <= max_width_8k );
        }
        bool isValidHeight( int value )
        {
            return ( value > 0 && value <= max_height_8k );
        }
        void CalculateProjectionMatrix( )
        {
            var aspect_ratio = (float)Width / (float)Height;
            Matrix4.CreatePerspectiveFieldOfView(
                field_of_view,
                aspect_ratio,
                z_near,
                z_far,
                out projection_matrix );
            OnProjectionChanged( new MatrixChangedEventArgs( ref projection_matrix ) );
        }
        void OnProjectionChanged( MatrixChangedEventArgs e )
        {
            if( ProjectionChanged != null )
                ProjectionChanged( this, e );
        }
        #endregion

        #region Constructors
        public Viewport( )
        {
            ProjectionChanged = null;
            width = default_width;
            height = default_height;
            z_near = 0.025f;
            z_far = 500.0f;
            field_of_view = (float)Math.PI / 4;
            projection_matrix = Matrix4.Identity;
            CalculateProjectionMatrix( );
        }
        #endregion

        #region Conversion Operator
        public static explicit operator Rectangle( Viewport viewport )
        {
            var rectangle = new Rectangle( 0, 0, viewport.width, viewport.height );
            return rectangle;
        }
        #endregion

        #region Events
        public event ProjectionMatrixChangedEventHandler ProjectionChanged;
        public event EventHandler<ViewportEventArgs> ViewportChanged;

        public class ViewportEventArgs : EventArgs
        {
            public Rectangle Viewport;

            public ViewportEventArgs( Rectangle viewport )
            {
                this.Viewport = viewport;
            }
        }
        #endregion
    }

    public class MatrixChangedEventArgs : EventArgs
    {
        public Matrix4 Delta;
        public Matrix4 Matrix;
        public MatrixChangedEventArgs( ref Matrix4 view_projection_matrix )
        {
            Matrix = view_projection_matrix;
        }

        public MatrixChangedEventArgs( Matrix4 beforeMatrix, Matrix4 afterMatrix )
        {
            Delta = beforeMatrix.Inverted( ) * afterMatrix;
            Matrix = afterMatrix;
        }
    }

    public delegate void ProjectionMatrixChangedEventHandler( object sender, MatrixChangedEventArgs e );

    public delegate void ViewMatrixChangedEventHandler( object sender, MatrixChangedEventArgs e );

    public delegate void ViewProjectionMatrixChangedEventHandler( object sender, MatrixChangedEventArgs e );

}
