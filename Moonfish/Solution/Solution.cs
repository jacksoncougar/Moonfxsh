using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ICSharpCode.TextEditor.Actions;
using Moonfish.Cache;
using Moonfish.Guerilla;
using Moonfish.Guerilla.Tags;
using Moonfish.ResourceManagement;
using Moonfish.Tags;

namespace Moonfish
{
    public static class Solution
    {
        private static ICache ActiveCache { get; set; }

        /// <summary>
        /// The root directory of the solution
        /// </summary>
        private static string Directory { get; }

        /// <summary>
        /// Database of Key linked resources
        /// </summary>
        private static Dictionary<string, Resource> Resources { get; } = new Dictionary<string, Resource>( );

        /// <summary>
        /// Solution filesystem index
        /// </summary>
        public static Index Index { get; } = new Index( );

        public static ScenarioBlock Scenario{ get; private set; }

        public static void SetScenario( ScenarioBlock scenario )
        {
            Scenario = scenario;
        }

        public static GuerillaBlock GetFromCache( this TagReference tagReference, CacheKey cacheKey, bool skipCache = false )
        {
            return GetFromCache<GuerillaBlock>( tagReference.Ident, cacheKey, skipCache );
        }

        public static GuerillaBlock GetFromCache( this TagIdent identifier, CacheKey cacheKey, bool skipCache = false )
        {
            return GetFromCache<GuerillaBlock>( identifier, cacheKey, skipCache );
        }

        public static T GetFromCache<T>( this TagIdent identifier, CacheKey cacheKey, bool skipCache = false ) where T : GuerillaBlock
        {
            ActiveCache = Index[ cacheKey ];
            var item = ActiveCache.Deserialize<T>( identifier );
            return item;
        }

        public static ResourceStream GetResourceFromCache( this GlobalGeometryBlockInfoStructBlock blockInfo )
        {
            var ResourceLocation = blockInfo.ResourceLocation;
            Stream source = null;
            if ( ResourceLocation == Halo2.ResourceSource.Local )
                source = ActiveCache as CacheStream;
            if ( ResourceLocation == Halo2.ResourceSource.Shared )
                source = ( Stream ) Index.Caches.FirstOrDefault( IsCacheCalled( "shared" ) );
            if ( ResourceLocation == Halo2.ResourceSource.SinglePlayerShared )
                source = ( Stream ) Index.Caches.FirstOrDefault( IsCacheCalled( "single_player_shared" ) );
            if ( ResourceLocation == Halo2.ResourceSource.MainMenu )
                source = ( Stream ) Index.Caches.FirstOrDefault( IsCacheCalled( "mainmenu" ) );

            if ( source == null ) return null;

            source.Position = blockInfo.ResourceOffset + 8;
            var buffer = new byte[blockInfo.BlockSize - 8];
            source.Read( buffer, 0, blockInfo.BlockSize - 8 );
            return new ResourceStream( buffer, blockInfo );
        }

        private static Func<ICache, bool> IsCacheCalled( string name )
        {
            return u =>
            {
                var cache = u as CacheStream;
                return cache != null && cache.Header.Name == name;
            };
        }

        public static byte[] GetResourceFromCache( this IResourceBlock blockInfo, int index = 0 )
        {
            Stream source = null;
            var resourcePointer = blockInfo.GetResourcePointer( index );
            var resourceLength = blockInfo.GetResourceLength( index );

            if ( resourcePointer.Source == Halo2.ResourceSource.Local )
                source = ActiveCache as CacheStream;
            if (resourcePointer.Source == Halo2.ResourceSource.Shared)
                source = (Stream)Index.Caches.FirstOrDefault(IsCacheCalled("shared"));
            if (resourcePointer.Source == Halo2.ResourceSource.SinglePlayerShared)
                source = (Stream)Index.Caches.FirstOrDefault(IsCacheCalled("single_player_shared"));
            if (resourcePointer.Source == Halo2.ResourceSource.MainMenu)
                source = (Stream)Index.Caches.FirstOrDefault(IsCacheCalled("mainmenu"));

            if ( source == null )
                return null;

            source.Position = resourcePointer.Address;
            var buffer = new byte[resourceLength];
            source.Read( buffer, 0, resourceLength );
            return buffer;
        }
        
        public static bool TryGetCacheKey(this GuerillaBlock guerillaBlock, out CacheKey key )
        {
            if ( Index.Tags.ContainsKey( guerillaBlock ) )
            {
                key = Index.Tags[ guerillaBlock ].CacheKey;
                return true;
            }

            foreach ( var cacheStream in Index.Caches )
            {
                if ( !cacheStream.Contains( guerillaBlock ) ) continue;

                key = CacheKey.Create( cacheStream );
                Index.Tags.Add( guerillaBlock, new TagGlobalKey( key, TagIdent.NullIdentifier ) );
                return true;
            }
            key = CacheKey.Null;
            return false;
        }

        public static void CreateLink( GuerillaBlock guerillaBlock, ICache cache )
        {
            if ( guerillaBlock == null || cache == null ) return;
            Index.Link( guerillaBlock, cache );
        }
    };
}
