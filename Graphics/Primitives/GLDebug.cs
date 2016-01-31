using System;
using System.Diagnostics;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Moonfish.Graphics.Primitives
{
    /// <summary>
    ///     Class for rendering primitive shapes in OpenGL efficiently
    /// </summary>
    public static class GLDebug
    {
        private const int MaxPoints = 100;
        private const int GlobalMaxLines = 250000;

        private static readonly VertexArrayObject PointBatch = new VertexArrayObject( );
        private static readonly VertexArrayObject LineBatch = new VertexArrayObject( );
        private static readonly VertexArrayObject TriangleBatch = new VertexArrayObject( );

        private static readonly Vector3[] PointList = new Vector3[MaxPoints];
        private static readonly Vector3[] LineList = new Vector3[GlobalMaxLines];
        private static readonly Vector3[] TriangleList = new Vector3[GlobalMaxTriangles];
        private static int lineIndex;
        private static int pointIndex;
        private static int triangleIndex;

        private static int MaxLines;
        private static readonly Vector3 DefaultColour = Color.DarkOliveGreen.ToColorF( ).RGBA.Xyz;

        private const int GlobalMaxTriangles = 300;


        static GLDebug( )
        {
#if DEBUG
            using ( PointBatch.Begin( ) )
            {
                PointBatch.BindBuffer( BufferTarget.ArrayBuffer, PointBatch.GetOrGenerateBuffer( "coordinates" ) );
                PointBatch.BufferVertexAttributeData( new Vector3[MaxPoints], BufferUsageHint.StreamDraw );
                PointBatch.VertexAttribArray( 0, 3, VertexAttribPointerType.Float, false, Vector3.SizeInBytes * 2 );
                PointBatch.VertexAttribArray( 1, 3, VertexAttribPointerType.Float, false, Vector3.SizeInBytes * 2,
                    Vector3.SizeInBytes );
            }
            using ( LineBatch.Begin( ) )
            {
                LineBatch.BindBuffer( BufferTarget.ArrayBuffer, LineBatch.GetOrGenerateBuffer( "coordinates" ) );
                LineBatch.BufferVertexAttributeData( new Vector3[GlobalMaxLines], BufferUsageHint.StreamDraw );
                LineBatch.VertexAttribArray( 0, 3, VertexAttribPointerType.Float, false, Vector3.SizeInBytes * 2 );
                LineBatch.VertexAttribArray( 1, 3, VertexAttribPointerType.Float, false, Vector3.SizeInBytes * 2,
                    Vector3.SizeInBytes );
            }
            using ( TriangleBatch.Begin( ) )
            {
                TriangleBatch.BindBuffer( BufferTarget.ArrayBuffer, TriangleBatch.GetOrGenerateBuffer( "coordinates" ) );
                TriangleBatch.BufferVertexAttributeData( new Vector3[GlobalMaxTriangles], BufferUsageHint.StreamDraw );
                TriangleBatch.VertexAttribArray( 0, 3, VertexAttribPointerType.Float, false, Vector3.SizeInBytes * 2 );
                TriangleBatch.VertexAttribArray( 1, 3, VertexAttribPointerType.Float, false, Vector3.SizeInBytes * 2,
                    Vector3.SizeInBytes );
            }
#endif
        }

        public static void Clear( )
        {
            pointIndex = 0;
            lineIndex = 0;
            triangleIndex = 0;
            Array.Clear( LineList, 0, LineList.Length );
            Array.Clear( PointList, 0, PointList.Length );
            Array.Clear( TriangleList, 0, TriangleList.Length );
        }

        /// <summary>
        ///     Draws all lines in the draw queue
        /// </summary>
        [Conditional("DEBUG")]
        public static void DrawLines()
        {
            using (LineBatch.Begin())
            {
                GL.DrawArrays(PrimitiveType.Lines, 0, MaxLines > GlobalMaxLines ? GlobalMaxLines : MaxLines);
                LineBatch.BindBuffer(BufferTarget.ArrayBuffer, LineBatch.GetOrGenerateBuffer("coordinates"));
                LineBatch.BufferVertexAttributeSubData(LineList);
                lineIndex = MaxLines = 0;
            }
        }

        /// <summary>
        ///     Draws all triangles in the draw queue
        /// </summary>
        [Conditional("DEBUG")]
        public static void DrawTriangles()
        {
            using (TriangleBatch.Begin())
            {
                GL.DrawArrays(PrimitiveType.Triangles, 0, GlobalMaxTriangles);
                TriangleBatch.BindBuffer(BufferTarget.ArrayBuffer, TriangleBatch.GetOrGenerateBuffer("coordinates"));
                TriangleBatch.BufferVertexAttributeSubData(TriangleList);
                triangleIndex = 0;
            }
        }

        /// <summary>
        ///     Draws all points in the draw queue
        /// </summary>
        [Conditional( "DEBUG" )]
        public static void DrawPoints( )
        {
            using ( PointBatch.Begin( ) )
            {
                GL.DrawArrays( PrimitiveType.Points, 0, 100 );
                PointBatch.BindBuffer( BufferTarget.ArrayBuffer, PointBatch.GetOrGenerateBuffer( "coordinates" ) );
                PointBatch.BufferVertexAttributeSubData( PointList );
                pointIndex = 0;
            }
        }

        /// <summary>
        ///     Adds a line to the draw queue
        /// </summary>
        /// <param name="from">end-point A coordinate of line</param>
        /// <param name="to">end-point B coordinate of line</param>
        [Conditional( "DEBUG" )]
        public static void QueueLineDraw( ref Vector3 from, ref Vector3 to )
        {
            QueueLineDraw( lineIndex++, from, to , DefaultColour);
        }

        /// <summary>
        ///     Adds a line to the draw queue
        /// </summary>
        /// <param name="from">end-point A coordinate of line</param>
        /// <param name="to">end-point B coordinate of line</param>
        /// <param name="red"></param>
        [Conditional("DEBUG")]
        public static void QueueLineDraw(Vector3 @from, Vector3 to)
        {
            QueueLineDraw(lineIndex++, from, to, DefaultColour);
        }

        [Conditional( "DEBUG" )]
        public static void QueueLineDraw( Vector3 @from, Vector3 to, Vector3 colour )
        {
            QueueLineDraw( lineIndex++, from, to, colour );
        }

        /// <summary>
        ///     Adds a line to the draw queue
        /// </summary>
        /// <param name="index">index into line queue to insert line data</param>
        /// <param name="from">end-point A coordinate of line</param>
        /// <param name="to">end-point B coordinate of line</param>
        [Conditional("DEBUG")]
        public static void QueueLineDraw(int index, Vector3 from, Vector3 to)
        {
            QueueLineDraw( index, @from, to, DefaultColour );
        }

        /// <summary>
        ///     Adds a line to the draw queue
        /// </summary>
        /// <param name="index">index into line queue to insert line data</param>
        /// <param name="from">end-point A coordinate of line</param>
        /// <param name="to">end-point B coordinate of line</param>
        [Conditional("DEBUG")]
        public static void QueueLineDraw(int index, Vector3 from, Vector3 to, Vector3 colour)
        {
            LineList[(index * 4 + 0) % GlobalMaxLines] = from;
            LineList[(index * 4 + 1) % GlobalMaxLines] = colour;
            LineList[(index * 4 + 2) % GlobalMaxLines] = to;
            var max = index * 4 + 3;
            MaxLines = MaxLines < max ? max : MaxLines;
            LineList[max % GlobalMaxLines] = colour;
        }

        [Conditional("DEBUG")]
        public static void QueueTriangleDraw( Vector3 vertex0, Vector3 vertex1, Vector3 vertex2)
        {
            QueueTriangleDraw( triangleIndex++, ref vertex0, ref vertex1, ref vertex2 );
        }

        [Conditional("DEBUG")]
        public static void QueueTriangleDraw(ref Vector3 vertex0, ref Vector3 vertex1, ref Vector3 vertex2)
        {
            QueueTriangleDraw(triangleIndex++, ref vertex0, ref vertex1, ref vertex2);
        }

        [Conditional("DEBUG")]
        public static void QueueTriangleDraw(int index, ref Vector3 vertex0, ref Vector3 vertex1, ref Vector3 vertex2)
        {
            TriangleList[(index * 6 + 0) % GlobalMaxTriangles] = vertex0;
            TriangleList[(index * 6 + 1) % GlobalMaxTriangles] = DefaultColour;
            TriangleList[(index * 6 + 2) % GlobalMaxTriangles] = vertex1;
            TriangleList[(index * 6 + 3) % GlobalMaxTriangles] = DefaultColour;
            TriangleList[(index * 6 + 4) % GlobalMaxTriangles] = vertex2;
            var max = index * 6 + 5;
            TriangleList[max % GlobalMaxTriangles] = DefaultColour;
        }

        /// <summary>
        ///     Adds a point to the draw queue
        /// </summary>
        /// <param name="index">index into the line queue to insert the point data</param>
        /// <param name="point">point coordinate</param>
        [Conditional( "DEBUG" )]
        public static void QueuePointDraw( int index, Vector3 point )
        {
            PointList[ index % MaxPoints ] = point;
            PointList[ index % MaxPoints ] = DefaultColour;
        }

        /// <summary>
        ///     Adds a point to the draw queue
        /// </summary>
        /// <param name="point">point coordinate</param>
        [Conditional( "DEBUG" )]
        public static void QueuePointDraw( ref Vector3 point )
        {
            PointList[ pointIndex++ % MaxPoints ] = point;
            PointList[ pointIndex++ % MaxPoints ] = DefaultColour;
        }

        /// <summary>
        ///     Adds a point to the draw queue
        /// </summary>
        /// <param name="point">point coordinate</param>
        [Conditional( "DEBUG" )]
        public static void QueuePointDraw( Vector3 point )
        {
            PointList[ pointIndex++ % MaxPoints ] = point;
            PointList[ pointIndex++ % MaxPoints ] = DefaultColour;
        }
    }
}