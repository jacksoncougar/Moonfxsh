using System;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Forms
{
    public static class CachePath
    {
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
                yield return dir == string.Empty ? "cache:\\" : dir;
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
            return level <= 0 ? "cache:" : ForeachDirectory( path, directorySeperator ).Skip( level - 1 ).First( );
        }
    }
}