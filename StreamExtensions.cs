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
            private readonly long _streamPosition;
            private readonly Stream _stream;

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