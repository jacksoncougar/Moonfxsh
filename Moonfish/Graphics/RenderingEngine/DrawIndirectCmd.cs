using System;
using System.IO;

namespace Moonfish.Graphics
{
    public interface IBuffer
    {
        IDisposable Bind( );
        
        IDisposable Create( );
    }

    struct DrawIndirectCmd
    {
        public DrawIndirectCmd( int count, int instanceCount, int firstIndex, int baseVertex, int baseInstance )
        {
            Count = count;
            InstanceCount = instanceCount;
            BaseInstance = baseInstance;
            FirstIndex = firstIndex;
            BaseVertex = baseVertex;
        }

        public int Count { get; }
        public int InstanceCount { get; }
        public int FirstIndex { get; }
        public int BaseVertex { get; }
        public int BaseInstance { get; }

        public void Write( BinaryWriter binaryWriter )
        {
            binaryWriter.Write(Count);
            binaryWriter.Write(InstanceCount);
            binaryWriter.Write(FirstIndex);
            binaryWriter.Write(BaseVertex);
            binaryWriter.Write(BaseInstance);
        }

        public const int CmdSize = sizeof ( int ) * 5;
    }
}