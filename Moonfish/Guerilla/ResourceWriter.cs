using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using Moonfish.Graphics;
using Moonfish.Guerilla;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;

namespace Moonfish.Guerilla.Tags
{

    public static class Extension
    {
        public struct VertexBufferArg
        {
            public VertexBuffer VertexBuffer;
            public BlamPointer Pointer;

            public VertexBufferArg(BlamPointer pointer, VertexBuffer vertexBuffer)
            {
                Pointer = pointer;
                VertexBuffer = vertexBuffer;
            }
        };

        public static event EventHandler<VertexBufferArg> OnVertexBufferWriteEvent;

        public static void Write(this QueueableBinaryWriter writer, VertexBuffer buffer)
        {
            writer.QueueWrite(buffer.Data);

            OnVertexBufferWriteEvent?.Invoke(buffer,
                new VertexBufferArg((writer as ResourceWriter)?.Last().Pointer ?? BlamPointer.Null, buffer));

            writer.Write((int) buffer.Type);
            writer.Write(new byte[28]);
        }
    }

}

namespace Moonfish.Guerilla
{
    public static class ResourceLinker
    {
        public static void WriteResource<T>(T resourceBlock, Stream output, int index = 0)
            where T : GuerillaBlock, IResourceBlock<GuerillaBlock>
        {
            var startAddress = output.Position;
            long endAddress;
            long length;
            var resourceObject = resourceBlock.GetResource(index);

            var writer = new ResourceWriter(output, resourceObject.SerializedSize);

            var argList = new List<ResourceWriter.PointerEventArg>();
            var vertexBuffers = new List<Extension.VertexBufferArg>();

            writer.OnWritePointerEvent += (sender, arg) => { argList.Add(arg); };
            Tags.Extension.OnVertexBufferWriteEvent += (sender, arg) => { vertexBuffers.Add(arg); };
            
            resourceObject.QueueWrites(writer);
            resourceObject.Write_(writer);
            writer.WriteQueue();

            var resourceBlocks =
                argList.Where(arg => !BlamPointer.IsNull(arg.Pointer))
                    .Select(
                        item =>
                            new GlobalGeometryBlockResourceBlock
                            {
                                PrimaryLocator = (short) item.Position,
                                SecondaryLocator = (short) item.Pointer.ElementSize,
                                Type = GlobalGeometryBlockResourceBlock.TypeEnum.TagBlock,
                                ResourceDataOffset = item.Pointer.StartAddress,
                                ResourceDataSize = item.Pointer.PointedSize,
                            })
                    .ToList();

            var ident = 0;
            resourceBlocks.InsertRange(resourceBlocks.IndexOf(resourceBlocks.First(x => x.PrimaryLocator == 56)),
                vertexBuffers.Select(
                    buffer =>
                        new GlobalGeometryBlockResourceBlock
                        {
                            Type = GlobalGeometryBlockResourceBlock.TypeEnum.VertexBuffer,
                            PrimaryLocator = 56,
                            ResourceDataOffset = buffer.Pointer.StartAddress,
                            SecondaryLocator = (short) ident++,
                            ResourceDataSize = buffer.Pointer.PointedSize
                        }));

            endAddress = output.Position;
            length = endAddress - startAddress;

            resourceBlock.SetResourceLength((int) length);
            resourceBlock.SetResourcePointer((int) startAddress);
        }
    }
    public class ResourceWriter : QueueableBinaryWriter, IEnumerable<QueueItem>
    {
        /// <summary>
        /// Event fired before a pointer is written to the output stream.
        /// </summary>
        public event EventHandler<PointerEventArg> OnWritePointerEvent;

        public struct PointerEventArg
        {
            public readonly long Position;
            public readonly BlamPointer Pointer;

            public PointerEventArg(long position, BlamPointer pointer)
            {
                Position = position;
                Pointer = pointer;
            }
        }

        public ResourceWriter(Stream output, int serializedSize) : base(output, serializedSize)
        {

        }

        IEnumerator<QueueItem> IEnumerable<QueueItem>.GetEnumerator()
        {
            return Queue.Cast<QueueItem>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Queue.GetEnumerator();
        }
       
        public override void WritePointer(object instanceFIeld)
        {
            OnWritePointer(BaseStream.Position, GetItemPointer(instanceFIeld));
            base.WritePointer(instanceFIeld);
        }

        private void OnWritePointer(long position, BlamPointer pointer)
        {
            OnWritePointerEvent?.Invoke(this, new PointerEventArg(position, pointer));
        }
    }
}