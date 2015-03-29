using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;

namespace Moonfish.Graphics
{
    public class TriangleBatch : IDisposable
    {
        public int VertexArrayObjectIdent
        {
            get { return _vao; }
        }

        public IList<int> BufferIdents
        {
            get { return _buffers; }
        }

        private bool _disposed;

        private readonly int _vao;
        private readonly List<int> _buffers;

        public TriangleBatch(int vertexArrayObjectident, IEnumerable<int> buffers)
        {
            _vao = vertexArrayObjectident;
            _buffers = new List<int>(buffers);
        }

        public TriangleBatch()
        {
            _buffers = new List<int>();
            _vao = GL.GenVertexArray();
        }

        public class Handle : IDisposable
        {
            private const int Default = 0;

            public Handle(int ident)
            {
                GL.BindVertexArray(ident);
            }

            public void Dispose()
            {
                GL.BindVertexArray(Default);
            }
        }

        public IDisposable Begin()
        {
            return new Handle(VertexArrayObjectIdent);
        }

        public void VertexAttribArray(int index, int count, VertexAttribIntegerType type, int stride = 0, int offset = 0)
        {
            GL.VertexAttribIPointer(index, count, type, stride, (IntPtr)offset);
            GL.EnableVertexAttribArray(index);
#if DEBUG
            OpenGL.ReportError();
#endif
        }

        public void VertexAttribArray(int index, int count, VertexAttribPointerType type,
            bool normalised = false, int stride = 0, int offset = 0)
        {
            GL.VertexAttribPointer(index, count, type, normalised, stride, offset);
            GL.EnableVertexAttribArray(index);
#if DEBUG
            OpenGL.ReportError();
#endif
        }

        public int GenerateBuffer()
        {
            var buffer = GL.GenBuffer();
#if DEBUG
            OpenGL.ReportError();
#endif
            _buffers.Add(buffer);
            return buffer;
        }

        public void BindBuffer(BufferTarget target, int buffer)
        {
            GL.BindBuffer(target, buffer);
#if DEBUG
            OpenGL.ReportError();
#endif
        }

        public void BufferVertexAttributeData<T>(T[] data) where T : struct
        {
            var dataSize = (IntPtr)(System.Runtime.InteropServices.Marshal.SizeOf(typeof(T)) * data.Length);
            GL.BufferData<T>(BufferTarget.ArrayBuffer, dataSize, data, BufferUsageHint.DynamicDraw);

#if DEBUG
            OpenGL.ReportError();
#endif
        }

        public void BufferVertexAttributeSubData<T>(T[] data, int offset = 0) where T : struct
        {
            var dataSize = (IntPtr)(System.Runtime.InteropServices.Marshal.SizeOf(typeof(T)) * data.Length);
            GL.BufferSubData<T>(BufferTarget.ArrayBuffer, (IntPtr)offset, dataSize, data);

#if DEBUG
            OpenGL.ReportError();
#endif
        }

        public void BufferElementArrayData(short[] indices)
        {
            GL.BufferData(BufferTarget.ElementArrayBuffer, (IntPtr)(indices.Length * sizeof(short)), indices,
                BufferUsageHint.DynamicDraw);

#if DEBUG
            OpenGL.ReportError();
#endif
        }

        public void BufferElementArrayData(ushort[] indices)
        {
            GL.BufferData(BufferTarget.ElementArrayBuffer, (IntPtr)(indices.Length * sizeof(ushort)), indices,
                BufferUsageHint.DynamicDraw);

#if DEBUG
            OpenGL.ReportError();
#endif
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                GL.DeleteVertexArray(_vao);
                GL.DeleteBuffers(_buffers.Count, _buffers.ToArray());
#if DEBUG
                OpenGL.ReportError();
#endif
            }
            _disposed = true;
        }
    }
}