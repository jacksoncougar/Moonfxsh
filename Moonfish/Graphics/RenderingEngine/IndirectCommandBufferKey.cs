using OpenTK.Graphics.OpenGL;

namespace Moonfish.Graphics
{
    internal class IndirectCommandBufferKey
    {
        public int BucketKey { get; }
        public int TypeKey { get; }

        public IndirectCommandBufferKey( Bucket bucket, PrimitiveType primitiveType )
        {
            BucketKey = bucket.GetHashCode( );
            TypeKey = ( short ) primitiveType;
        }

        public override int GetHashCode( )
        {
            return BucketKey << 16 | TypeKey;
        }

        public override bool Equals( object obj )
        {
            var bufferKey = obj as IndirectCommandBufferKey;
            if ( bufferKey == null ) return false;

            return bufferKey.BucketKey == BucketKey && bufferKey.TypeKey == TypeKey;
        }
    };
}