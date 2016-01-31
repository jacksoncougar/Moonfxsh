using System;
using System.Runtime.InteropServices;
using OpenTK.Graphics.OpenGL;

namespace Moonfish.Graphics
{
    public class UniformBuffer : IDisposable
    {
        private bool _disposed;
        private int handle;

        public void SetUniforms(Program program, string name, object value)
        {
            var location = program.GetUniformLocation(name);
            var offset = program.GetUniformOffsets(new[] {location});
        }

        public object GetUniforms(string name)
        {
            throw new NotImplementedException();
        }

        public UniformBuffer()
        {
            handle = GL.GenBuffer();
        }

        public void BufferData<T>(string value, T[] data) where T : struct
        {
            var dataSize = (IntPtr) (Marshal.SizeOf(typeof (T))*data.Length);
            GL.BufferData(BufferTarget.ArrayBuffer, dataSize, data, BufferUsageHint.DynamicDraw);

#if DEBUG
#endif
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                // dispose of IDisposible objects here   
            }
            //dispose of unmanaged objects here
            GL.DeleteBuffer(handle);
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}