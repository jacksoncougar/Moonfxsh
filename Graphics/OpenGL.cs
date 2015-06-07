using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;

namespace Moonfish.Graphics
{
    public static class OpenGL
    {
        static OpenGL( )
        {
#if DEBUG
            timer.Interval = 5000;
            callback = Callback;
            arbCallback = Callback;
            timer.Tick += delegate
            {
                if ( messageString.Length > 0 )
                {
                    Debug.WriteLine( messageString );
                    messageString.Clear( );
                }
            };
            timer.Start( );
            GL.DebugMessageCallback( callback, IntPtr.Zero );
            GL.Khr.DebugMessageCallback( arbCallback, IntPtr.Zero );
            GL.GetError( );
#endif
        }

        private static Program activeProgram { get; set; }

        /// <summary>
        ///     Disables the OpenGL capability for the lifespan of this object then enables the capability again
        /// </summary>
        /// <param name="state">Specifies a symbolic constant indicating a GL capability.</param>
        /// <returns>Resource Handle for this capability</returns>
        public static IDisposable Disable( EnableCap state )
        {
            return new Handle( state, false );
        }

        /// <summary>
        ///     Enables the OpenGL capability for the lifespan of this object then disables the capability again
        /// </summary>
        /// <param name="state">Specifies a symbolic constant indicating a GL capability.</param>
        /// <returns>Resource Handle for this capability</returns>
        public static IDisposable Enable( EnableCap state )
        {
            return new Handle( state );
        }

        [Conditional( "DEBUG" )]
        public static void GetError( )
        {
            var errorCode = GL.GetError( );
            if ( errorCode != ErrorCode.NoError )
                throw new Exception( string.Format( "OpenGL Error: {0}", errorCode ) );
        }

        private static void Callback( DebugSource source, DebugType type, int id, DebugSeverity severity, int length,
            IntPtr message, IntPtr userParam )
        {
#if DEBUG
            var ptrToStringAnsi = Marshal.PtrToStringAnsi( message, length );
            messageString.AppendLine( ptrToStringAnsi );
            if ( messageString.Length + length > messageString.Capacity )
            {
                Debug.WriteLine( messageString );
                messageString.Clear( );
            }
            if (type == DebugType.DebugTypeError)
            {
                //throw new Exception(ptrToStringAnsi);
            }
#endif
        }

        public class Handle : IDisposable
        {
            private readonly EnableCap state;
            private readonly bool stateWasEnabled;

            public Handle( EnableCap state, bool enable = true )
            {
                var stateIsEnabled = GL.IsEnabled( state );
                //  is not enabled and we want to enable it
                if ( !stateIsEnabled && enable ) GL.Enable( state );
                // is enabled and we want to disable it
                else if ( stateIsEnabled && !enable ) GL.Disable( state );

                // store previous state
                this.state = state;
                stateWasEnabled = stateIsEnabled;
            }

            void IDisposable.Dispose( )
            {
                // return state to previous setting
                if ( stateWasEnabled ) GL.Enable( state );
                else GL.Disable( state );
            }
        }

#if DEBUG
        private static readonly DebugProc callback;
        private static readonly DebugProcKhr arbCallback;
        private static readonly StringBuilder messageString = new StringBuilder( 10000 );
        private static readonly Timer timer = new Timer( );
#endif
    }
}