using System;
using System.Drawing;
using OpenTK;

namespace Moonfish.Graphics
{
    public class Viewport
    {
        #region Constructors

        public Viewport()
        {
            ProjectionChanged = null;
            _width = DefaultWidth;
            _height = DefaultHeight;
            ZNear = 0.025f;
            _zFar = 1500.0f;
            _fieldOfView = (float) Math.PI/4;
            _projectionMatrix = Matrix4.Identity;
            CalculateProjectionMatrix();
        }

        #endregion

        #region Internal Properties

        internal Matrix4 ProjectionMatrix
        {
            get { return _projectionMatrix; }
        }

        #endregion

        #region Conversion Operator

        public static explicit operator Rectangle(Viewport viewport)
        {
            var rectangle = new Rectangle(0, 0, viewport._width, viewport._height);
            return rectangle;
        }

        #endregion

        #region Constants

        private const int MaxWidth_8K = 4320;
        private const int MaxHeight_8K = 7680;
        private const int DefaultWidth = 640;
        private const int DefaultHeight = 480;

        #endregion

        #region Properties

        public int Width
        {
            get { return _width; }
            set
            {
                if (!IsValidWidth(value)) return;
                _width = value;
                CalculateProjectionMatrix();
                if (ViewportChanged != null) ViewportChanged(this, new ViewportEventArgs((Rectangle) this));
            }
        }

        public int Height
        {
            get { return _height; }
            set
            {
                if (!IsValidHeight(value)) return;
                _height = value;
                CalculateProjectionMatrix();
                if (ViewportChanged != null) ViewportChanged(this, new ViewportEventArgs((Rectangle) this));
            }
        }

        public Size Size
        {
            get { return new Size(_width, _height); }
            set
            {
                if (!IsValidWidth(value.Width) || !IsValidHeight(value.Height)) return;
                _width = value.Width;
                _height = value.Height;
                CalculateProjectionMatrix();
                if (ViewportChanged != null) ViewportChanged(this, new ViewportEventArgs((Rectangle) this));
            }
        }

        public float ZNear { get; private set; }

        #endregion

        #region Private Fields

        private Matrix4 _projectionMatrix;
        private int _width;
        private int _height;
        private readonly float _zFar;
        private readonly float _fieldOfView;

        #endregion

        #region Private Methods

        private static bool IsValidWidth(int value)
        {
            return (value > 0 && value <= MaxWidth_8K);
        }

        private static bool IsValidHeight(int value)
        {
            return (value > 0 && value <= MaxHeight_8K);
        }

        private void CalculateProjectionMatrix()
        {
            var aspectRatio = Width/(float) Height;
            Matrix4.CreatePerspectiveFieldOfView(
                _fieldOfView,
                aspectRatio,
                ZNear,
                _zFar,
                out _projectionMatrix);
            OnProjectionChanged(new MatrixChangedEventArgs(ref _projectionMatrix));
        }

        private void OnProjectionChanged(MatrixChangedEventArgs e)
        {
            if (ProjectionChanged != null)
                ProjectionChanged(this, e);
        }

        #endregion

        #region Events

        public event ProjectionMatrixChangedEventHandler ProjectionChanged;
        public event EventHandler<ViewportEventArgs> ViewportChanged;

        public class ViewportEventArgs : EventArgs
        {
            public Rectangle Viewport;

            public ViewportEventArgs(Rectangle viewport)
            {
                Viewport = viewport;
            }
        }

        #endregion
    }
}