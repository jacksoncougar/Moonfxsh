using System;
using System.Collections.Generic;
using System.Linq;
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

    public class TriangleBatch : IDisposable
    {
        public int InstanceCount { get; set; }

        public int VertexArrayObjectIdent
        {
            get { return _vao; }
        }

        public IList<int> BufferDictionaryIdents
        {
            get { return _bufferDictionary.Select( x => x.Value ).ToList( ); }
        }

        private bool _disposed;

        private readonly int _vao;
        private readonly Dictionary<string, int> _bufferDictionary;
        
        public TriangleBatch()
        {
            _bufferDictionary = new Dictionary<string, int>();
            _vao = GL.GenVertexArray();
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

        public IDisposable Begin()
        {
            return new Handle(VertexArrayObjectIdent);
        }

        public void VertexAttribArray(int index, int count, VertexAttribIntegerType type, int stride = 0,
            int offset = 0)
        {
            GL.VertexAttribIPointer(index, count, type, stride, (IntPtr) offset);
            GL.EnableVertexAttribArray(index);
        }

        public void VertexAttribArray(int index, int count, VertexAttribPointerType type,
            bool normalised = false, int stride = 0, int offset = 0)
        {
            GL.VertexAttribPointer(index, count, type, normalised, stride, offset);
            GL.EnableVertexAttribArray(index);
        }

        public int GenerateBuffer(string bufferName)
        {
            var buffer = GL.GenBuffer();
            _bufferDictionary.Add(bufferName.ToLower(), buffer);
            return buffer;
        }

        public void BindBuffer(BufferTarget target, int buffer)
        {
            GL.BindBuffer(target, buffer);
        }

        public void VertexAttribDivisor( int index, int divisor )
        {
            GL.VertexAttribDivisor( index, divisor );
        }

        public void BufferVertexAttributeData<T>(T[] data) where T : struct
        {
            var dataSize = (IntPtr) (Marshal.SizeOf(typeof (T))*data.Length);
            GL.BufferData(BufferTarget.ArrayBuffer, dataSize, data, BufferUsageHint.StaticDraw);
        }

        public void BufferVertexAttributeSubData<T>(T[] data, int offset = 0) where T : struct
        {
            var dataSize = (IntPtr) (Marshal.SizeOf(typeof (T))*data.Length);
            GL.BufferSubData(BufferTarget.ArrayBuffer, (IntPtr) offset, dataSize, data);
        }

        public void BufferElementArrayData(short[] indices)
        {
            GL.BufferData(BufferTarget.ElementArrayBuffer, (IntPtr) (indices.Length*sizeof (short)), indices,
                BufferUsageHint.DynamicDraw);
        }

        public void BufferElementArrayData(ushort[] indices)
        {
            GL.BufferData(BufferTarget.ElementArrayBuffer, (IntPtr) (indices.Length*sizeof (ushort)), indices,
                BufferUsageHint.DynamicDraw);
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
                GL.DeleteBuffers(_bufferDictionary.Count, _bufferDictionary.Select( x=>x.Value ).ToArray());
            }
            _disposed = true;
        }

        internal int GetOrGenerateBuffer(string bufferName)
        {
            int value;
            return _bufferDictionary.TryGetValue( bufferName.ToLower(), out value ) ? value : GenerateBuffer( bufferName );
        }
    }

    class InstanceBatch : TriangleBatch
    {
    }
}