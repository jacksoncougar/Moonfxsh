using System;
using System.IO;

namespace Moonfish
{
    public static class StreamExtensions
    {
        public static IDisposable Pin( this Stream stream )
        {
            return new StreamPositionHandle( stream );
        }

        public class StreamPositionHandle : IDisposable
        {
            readonly long _streamPosition;
            readonly Stream _stream;
            public StreamPositionHandle( Stream stream )
            {
                _stream = stream;
                _streamPosition = stream.Position;
            }
            void IDisposable.Dispose( )
            {
                _stream.Position = _streamPosition;
            }
        }
    }
}