using System;
using System.Collections.Generic;
using System.IO;
using Moonfish.Guerilla.Tags;
using OpenTK.Graphics.OpenGL;

namespace Moonfish.Graphics
{
    public class IndirectDrawCommandBuffer
    {
        public Bucket SourceBucket { get; private set; }

        public IndirectDrawCommandBuffer( PrimitiveType primitiveType, Bucket sourceBucket )
        {
            PrimitiveType = primitiveType;
            SourceBucket = sourceBucket;
        }

        public PrimitiveType PrimitiveType { get; }
        public int BufferId { get; } = GL.GenBuffer( );
        private List<DrawIndirectCmd> CommandBuffers { get; }=new List<DrawIndirectCmd>();
        public byte[] CommandData { get; set; }
        public int Count { get; set; }

        public IDisposable Bind( )
        {
            return new BindHandle(this);
        }

        public void Clear( )
        {
            CommandBuffers.Clear(  );
        }

        public bool AddDrawCommand( GlobalGeometryPartBlockNew part, Bucket sourceBucket, InstanceInfo instanceInfo )
        {
            var primitiveType =
                part.GlobalGeometryPartNewFlags.HasFlag(
                    GlobalGeometryPartBlockNew.Flags.OverrideTriangleList)
                    ? PrimitiveType.Triangles
                    : PrimitiveType.TriangleStrip;

            if (primitiveType != PrimitiveType) return false;
            if (sourceBucket != SourceBucket) return false;

            var locations = sourceBucket[ part ];
            var command = new DrawIndirectCmd(
                part.StripLength,
                instanceInfo.Count,
                // Divide by two because this is an offset and we need an index
                locations.IndexBaseOffset / sizeof ( ushort ) + part.StripStartIndex,
                locations.VertexBaseOffset,
                instanceInfo.BaseInstance );
            
            CommandBuffers.Add( command );
            return true;
        }

        public void CreateCommandBuffer()
        {
            GL.BindBuffer(BufferTarget.DrawIndirectBuffer, BufferId);
            Count = CommandBuffers.Count;
            CommandData = new byte[DrawIndirectCmd.CmdSize * CommandBuffers.Count];
            using(var binaryWriter = new BinaryWriter(new MemoryStream(CommandData)))
                foreach ( var buffer in CommandBuffers )
                {
                    buffer.Write( binaryWriter );
                }
            GL.BufferData( BufferTarget.DrawIndirectBuffer, ( IntPtr ) CommandData.Length, CommandData,
                BufferUsageHint.StreamDraw );
        }

        private class BindHandle : IDisposable
        {
            public BindHandle(IndirectDrawCommandBuffer indirectDrawCommandBuffer)
            {
                GL.BindBuffer( BufferTarget.DrawIndirectBuffer, indirectDrawCommandBuffer.BufferId );
            }

            public void Dispose( )
            {

            }
        }
    }
}