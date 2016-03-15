using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using OpenTK.Graphics.OpenGL;

namespace Moonfish.Graphics
{
    /// <summary>
    /// Wrapper for OpenGL Vertex Array Object state
    /// </summary>
    public class VertexArrayObject : IDisposable
    {
        private readonly List<int> _buffers;

        private bool _disposed;
        private readonly Dictionary<string, int> _namedBufferIndices;



        public VertexArrayObject()
        {
            _namedBufferIndices = new Dictionary<string, int>();
            _buffers = new List<int>();
            VertexArrayObjectIdent = GL.GenVertexArray();
        }

        public int VertexArrayObjectIdent { get; }

        public List<int> BufferIdents
        {
            get { return _buffers; }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void AllocateVertexAttributeData(int dataSize,
            BufferUsageHint bufferUsageHint = BufferUsageHint.StaticDraw)
        {
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)dataSize, (IntPtr)null, bufferUsageHint);
        }

        public IDisposable Begin()
        {
            return new Handle(VertexArrayObjectIdent);
        }

        public void BindBuffer(BufferTarget target, int buffer)
        {
            GL.BindBuffer(target, buffer);
        }

        public void BufferElementArrayData(short[] indices)
        {
            GL.BufferData(BufferTarget.ElementArrayBuffer, (IntPtr)(indices.Length * sizeof(short)), indices,
                BufferUsageHint.DynamicDraw);
        }

        public void BufferElementArrayData(ushort[] indices)
        {
            GL.BufferData(BufferTarget.ElementArrayBuffer, (IntPtr)(indices.Length * sizeof(ushort)), indices,
                BufferUsageHint.DynamicDraw);
        }

        public void BufferVertexAttributeData<T>(T[] data, BufferUsageHint bufferUsageHint = BufferUsageHint.StaticDraw)
            where T : struct
        {
            var dataSize = (IntPtr)(Marshal.SizeOf(typeof(T)) * data.Length);

            GL.BufferData(BufferTarget.ArrayBuffer, dataSize, data, bufferUsageHint);
        }

        public void BufferVertexAttributeSubData<T>(T[] data, int offset = 0) where T : struct
        {
            var dataSize = (IntPtr)(Marshal.SizeOf(typeof(T)) * data.Length);
            GL.BufferSubData(BufferTarget.ArrayBuffer, (IntPtr)offset, dataSize, data);
        }

        public int GenerateBuffer()
        {
            var buffer = GL.GenBuffer();
            _buffers.Add(buffer);
            return buffer;
        }

        public int GetOrGenerateBuffer(string bufferName)
        {
            int index;
            var key = bufferName.ToLower();
            if (_namedBufferIndices.TryGetValue(key, out index))
                return _buffers[index];

            _namedBufferIndices[key] = _buffers.Count;
            return GenerateBuffer();
        }

        public void VertexAttribArray(int index, int count, VertexAttribIntegerType type, int stride = 0,
            int offset = 0)
        {
            GL.VertexAttribIPointer(index, count, type, stride, (IntPtr)offset);
            GL.EnableVertexAttribArray(index);
        }

        public void VertexAttribArray(int index, int count, VertexAttribPointerType type,
            bool normalised = false, int stride = 0, int offset = 0)
        {
            GL.VertexAttribPointer(index, count, type, normalised, stride, offset);
            GL.EnableVertexAttribArray(index);
        }

        public void VertexAttribDivisor(int index, int divisor)
        {
            GL.VertexAttribDivisor(index, divisor);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                GL.DeleteVertexArray(VertexArrayObjectIdent);
                GL.DeleteBuffers(_buffers.Count, _buffers.ToArray());
            }
            _disposed = true;
        }

        private class Handle : IDisposable
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
    }
}