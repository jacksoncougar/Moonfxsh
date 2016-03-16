using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Sunfish.Forms
{
    public static class CachePath
    {
        public static string CacheRoot = "cache:\\";

        public static string Combine( string path1, string path2 )
        {
            return path1.EndsWith( ":" ) ? $@"{path1}\{path2.TrimStart( '\\' )}" : Path.Combine( path1, path2 );
        }

        /// <summary>
        /// Enumerates each parent directory-path of <paramref name="path"/> from the root directory back to the directory of <paramref name="path"/>
        /// </summary>
        /// <param name="path">The directory path to enumerate through</param>
        /// <param name="directorySeperator">The directory seperater token</param>
        /// <returns>An enumerable of full paths, each one level closer approaching <paramref name="path"/></returns>
        /// <remarks>
        /// Given: "scenario\multi\flagbase\"
        /// Returns:    0. "scenario"
        ///             1. "scenario\multi"
        ///             2. "scenario\multi\flagbase"
        /// 
        /// Notes: Leading directory seperators are ignored, trailing directory seperators are ignored
        /// </remarks>
        public static IEnumerable<string> ForeachDirectory(string path, string directorySeperator = "\\" )
        {
            var total = path.Length;
            var startOffset = 0;
            do
            {
                var endOffset = path.IndexOf(directorySeperator, startOffset, StringComparison.Ordinal);
                if ( endOffset < 0 )
                {
                    yield return path;
                    yield break;
                }
                if (endOffset == 0 ) continue;

                var dir = path.Substring(0, endOffset);

                // Increment startOffset by 1 to move past the directorySeperator
                startOffset = endOffset + 1;
                yield return dir == string.Empty && startOffset == 0 ? CacheRoot : dir;
            } while ( startOffset < total );
        }

        public static int GetDirectoryLevelCount( string path, string directorySeperator = "\\" )
        {
            // Empty strings have no levels:
            if ( path.Length <= 0 ) return 0;
            
            var startOffset = 0;
            var count = 1;
            while(true)
            {
                var endOffset = path.IndexOf(directorySeperator, startOffset, StringComparison.Ordinal);

                // No more seperators: return level count
                if (endOffset < 0)
                {
                    return count;
                }
                // Leading seperator: do not count as a level
                if (endOffset == 0) continue;
                
                // Increment startOffset by 1 to move past the directorySeperator
                startOffset = endOffset + 1;
                count++;
            }
        }

        public static string GetDirectoryLevel( string path, int level, string directorySeperator = "\\")
        {
            return level <= 0 ? CacheRoot : ForeachDirectory( path, directorySeperator ).Skip( level - 1 ).First( );
        } 

        public static string GetDirectoryName(string path, string directorySeperator = "\\")
        {
            var offset = 0;
            while(true)
            {
                var index = path.IndexOf(directorySeperator, offset);
                if (index < 0) return offset < 0 ? path : path.Substring(0, offset - 1);
                offset = index + 1;
            }
        }
    }
}