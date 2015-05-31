using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Moonfish.Graphics
{
    public static class OpenGL
    {
        private static Program activeProgram { get; set; }

        /// <summary>
        /// Enables the OpenGL capability for the lifespan of this object then disables the capability again
        /// </summary>
        /// <param name="state">Specifies a symbolic constant indicating a GL capability.</param>
        /// <returns>Resource Handle for this capability</returns>
        public static IDisposable Enable(EnableCap state)
        {
            return new Handle(state);
        }

        /// <summary>
        /// Disables the OpenGL capability for the lifespan of this object then enables the capability again
        /// </summary>
        /// <param name="state">Specifies a symbolic constant indicating a GL capability.</param>
        /// <returns>Resource Handle for this capability</returns>
        public static IDisposable Disable(EnableCap state)
        {
            return new Handle(state, false);
        }

        public class Handle : IDisposable
        {
            private EnableCap state;
            private bool stateWasEnabled;

            public Handle(EnableCap state, bool enable = true)
            {
                var stateIsEnabled = GL.IsEnabled(state);
                //  is not enabled and we want to enable it
                if (!stateIsEnabled && enable) GL.Enable(state);
                // is enabled and we want to disable it
                else if (stateIsEnabled && !enable) GL.Disable(state);

                // store previous state
                this.state = state;
                this.stateWasEnabled = stateIsEnabled;
            }

            void IDisposable.Dispose()
            {
                // return state to previous setting
                if (stateWasEnabled) GL.Enable(state);
                else GL.Disable(state);
            }
        }

        private static readonly DebugProc callback;
        private static readonly DebugProcKhr arbCallback;
        private static StringBuilder messageString = new StringBuilder(1000);
        private static Timer timer = new Timer();

        [Conditional("DEBUG")]
        public static void GetError( )
        {
            var errorCode = GL.GetError();
            if (errorCode != ErrorCode.NoError) throw new Exception(string.Format( "OpenGL Error: {0}", errorCode ));
        }

        static OpenGL( )
        {
            timer.Interval = 2000;
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
            timer.Start();
            GL.DebugMessageCallback(callback, IntPtr.Zero);
            GL.Khr.DebugMessageCallback(arbCallback, IntPtr.Zero);
            GL.GetError( );
        }

        private static void Callback(DebugSource source, DebugType type, int id, DebugSeverity severity, int length, IntPtr message, IntPtr userParam)
        {
            messageString.AppendLine( System.Runtime.InteropServices.Marshal.PtrToStringAnsi( message, length ) );
            if ( messageString.Length + length > messageString.Capacity )
            {
                Debug.WriteLine(messageString);
                messageString.Clear( );
            }
        }
    }
}