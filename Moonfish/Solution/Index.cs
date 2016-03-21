using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Moonfish.Cache;
using Moonfish.Guerilla;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;

namespace Moonfish
{
    internal struct ObjectReferenceKey
    {
        public int Index { get; }
    }

    internal struct ObjectReference
    {
        private ReferenceType Type { get; }

        public ObjectReference( ReferenceType type )
        {
            Type = type;
        }
    }

    internal enum ReferenceType : byte
    {
        Cache = 1
    }

    public struct CacheKey : IEquatable<CacheKey>
    {
        public CacheKey( short? count ) : this( )
        {
            Key = count ?? -1;
        }

        private short Key { get; }

        public static CacheKey Null => new CacheKey( null );

        public override int GetHashCode( )
        {
            return Key;
        }

        public bool Equals( CacheKey other )
        {
            return GetHashCode( ) == other.GetHashCode( );
        }

        public override bool Equals( object obj )
        {
            var isKey = obj is CacheKey;
            return isKey && GetHashCode( ) == obj.GetHashCode( );
        }

        public static bool operator ==( CacheKey firstKey, CacheKey secondKey )
        {
            return firstKey.Key == secondKey.Key;
        }

        public static bool operator !=(CacheKey firstKey, CacheKey secondKey)
        {
            return !(firstKey == secondKey);
        }

        public static CacheKey Create( ICache destination )
        {
            if ( !Solution.Index.Contains( destination ) )
                Solution.Index.AddCache( destination );

            return  Solution.Index.GetCacheKey( destination );
        }
    }

    public struct TagGlobalKey
    {
        public CacheKey CacheKey { get; private set; }
        public TagIdent TagKey { get; }

        public override int GetHashCode( )
        {
            return TagKey.Index << 16 | CacheKey.GetHashCode( ) & 0xFF;
        }

        public void SetCacheKey( CacheKey key )
        {
            CacheKey = key;
        }

        public override bool Equals( object obj )
        {
            return obj is TagGlobalKey && obj.GetHashCode( ) == GetHashCode( );
        }

        public static bool operator ==(TagGlobalKey firstKey, TagGlobalKey secondKey)
        {
            return firstKey.TagKey == secondKey.TagKey && firstKey.CacheKey == secondKey.CacheKey;
        }
        public static bool operator !=(TagGlobalKey firstKey, TagGlobalKey secondKey)
        {
            return !( firstKey == secondKey );
        }

        public TagGlobalKey( CacheKey cacheKey, TagIdent tagKey )
        {
            CacheKey = cacheKey;
            TagKey = tagKey;
        }

        public GuerillaBlock Get( )
        {
            return Get<GuerillaBlock>( );
        }

        public T Get<T>( ) where T : GuerillaBlock
        {
            return TagKey.Get<T>( CacheKey );
        }
    }

    public class Index
    {
        private Dictionary<CacheKey, ICache> CacheReferences { get; } = new Dictionary<CacheKey, ICache>( );



        private Dictionary<TagGlobalKey, GuerillaBlock> GlobalTagDictionary =
            new Dictionary<TagGlobalKey, GuerillaBlock>( );


        public Dictionary<GuerillaBlock, TagGlobalKey> Tags { get; } =
            new Dictionary<GuerillaBlock, TagGlobalKey>( );

        public IEnumerable<ICache> Caches
        {
            get
            {
                foreach ( var stream in CacheReferences.Values )
                {
                    if ( stream == null ) continue;
                    yield return stream;
                }
            }
        }

        public bool Contains( GuerillaBlock guerillaBlock )
        {
            return Tags.ContainsKey( guerillaBlock );
        }

        private int counter;
        public void AddCache( ICache cacheStream )
        {
            var cacheKey = GetCacheKey( cacheStream );
            var key = cacheKey == CacheKey.Null ? new CacheKey( ( short ) ( counter++ ) ) : cacheKey;
            CacheReferences[ key ] = cacheStream;
        }

        public CacheKey GetCacheKey( ICache cache )
        {
            var fileStream = (cache as FileStream);
            if (fileStream != null)
                foreach (var item in CacheReferences)
                {
                    var other = item.Value as FileStream;

                    if (other != null && other.Name == fileStream.Name) return item.Key;
                }
            foreach ( var item in CacheReferences )
            {
                if ( item.Value == cache ) return item.Key;
            }
            return CacheKey.Null;
        }

        public ICache this[ CacheKey cacheKey ]
        {
            get { return CacheReferences[ cacheKey ]; }
        }

        public bool Contains( ICache cache )
        {
            var fileStream = (cache as FileStream);
            if(fileStream!= null)
                foreach ( var item in CacheReferences )
                {
                    var other = item.Value as FileStream;

                    if ( other != null && other.Name == fileStream.Name ) return true;
                }
            else
            {
                foreach (var item in CacheReferences)
                {
                    if ( item.Value == cache ) return true;
                }
            }
            return false;
        }

        public void Link( GuerillaBlock guerillaBlock, ICache cache )
        {
            Tags[ guerillaBlock ] = new TagGlobalKey( CacheKey.Create( cache ),
                TagIdent.NullIdentifier );
        }
    }
}