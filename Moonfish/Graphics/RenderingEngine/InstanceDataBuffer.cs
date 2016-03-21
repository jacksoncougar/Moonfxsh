using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Moonfish.Guerilla.Tags;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Moonfish.Graphics
{
    public struct InstanceInfo
    {
        public int Count { get; set; }
        public int BaseInstance { get; set; }
    }

    public class InstanceDataBuffer : IDisposable
    {
        public int InstanceCount { get; private set; }

        public Dictionary<GlobalGeometryPartBlockNew, List<Matrix4>> Instances { get; } =
            new Dictionary<GlobalGeometryPartBlockNew, List<Matrix4>>( );

        public Dictionary<GlobalGeometryPartBlockNew, InstanceInfo> InstanceInfos { get; }
            = new Dictionary<GlobalGeometryPartBlockNew, InstanceInfo>( );

        public void AddInstances( GlobalGeometryPartBlockNew part, IEnumerable<Matrix4> instanceWorldMatrices )
        {
            if ( !Instances.ContainsKey( part ) )
            {
                Instances[ part ] = new List<Matrix4>( instanceWorldMatrices );
                return;
            }
            Instances[ part ].AddRange( instanceWorldMatrices );
        }

        private void BufferInstanceData( )
        {
            var count = Instances.Sum( u => u.Value.Count );
            var stride = Vector4.SizeInBytes * 4;
            var instanceDataSize = count * stride;
            var currentInstance = 0;

            var buffer = new byte[instanceDataSize];
            using ( var binaryWriter = new BinaryWriter( new MemoryStream( buffer ) ) )
            {
                foreach ( var item in Instances )
                {
                    InstanceInfos[ item.Key ] = new InstanceInfo( )
                    {
                        Count = item.Value.Count,
                        BaseInstance = currentInstance
                    };
                    for ( int index = 0; index < item.Value.Count; index++ )
                    {
                        var matrix4 = item.Value[ index ];
                        currentInstance++;
                        // Write Row-Major
                        binaryWriter.Write( ref matrix4 );
                    }
                }
            }

            GL.BindBuffer( BufferTarget.ArrayBuffer, BufferId );
            GL.BufferData( BufferTarget.ArrayBuffer, ( IntPtr ) instanceDataSize, buffer,
                BufferUsageHint.DynamicDraw );
        }

        private int BufferId { get; } = GL.GenBuffer( );

        private class Handle : IDisposable
        {
            private InstanceDataBuffer target { get; }

            public Handle( InstanceDataBuffer instanceDataBuffer )
            {
                target = instanceDataBuffer;
                target.Instances.Clear( );
            }

            public void Dispose( )
            {
                target.BufferInstanceData( );
            }
        };

        private class BindHandle : IDisposable
        {
            public BindHandle( InstanceDataBuffer instanceDataBuffer )
            {
                GL.BindVertexBuffer( 7, instanceDataBuffer.BufferId, ( IntPtr ) 0, Vector4.SizeInBytes * 4 );
            }

            public void Dispose( )
            {
            }
        };

        public IDisposable Create( )
        {
            return new Handle( this );
        }

        public IDisposable Bind( )
        {
            return new BindHandle( this );
        }

        ~InstanceDataBuffer()
        {
            // Finalizer calls Dispose(false)
            Dispose(false);
        }

        private void Dispose( bool disposing )
        {
            if (disposing)
            {
                // free managed resources
                GL.DeleteBuffer(BufferId);
            }
            // free unmanaged resources
        }

        public void Dispose( )
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public InstanceInfo this[ GlobalGeometryPartBlockNew key ]
        {
            get { return InstanceInfos[ key ]; }
        }
    }
}