using System.Collections.Generic;
using System.IO;
using Moonfish.Guerilla;
using Moonfish.Tags;
using Moonfish.Cache;

namespace Moonfish.Cache
{
    public abstract class TestRepo
    {
        Repository repo;
    };

    /// <summary>
    /// Creates a map file from a Repository
    /// </summary>
    public abstract class Packager
    {
        Repository Repository { get; }

        public Map CreatePackage(Repository repository)
        {
            return null;
        }
    };

    /// <summary>
    /// Collection of Object Data required to build an output map.
    /// </summary>
    public abstract class Repository
    {
        // details: the map can be recreated from a scenario tag and all referenced tags to that. As well as all the non-external raw data. Strings must be rebuilt and unicode tables.
        public StringManifest Strings { get; }
        public ObjectManifest Objects { get; }

        public UnicodeManifest Unicode { get; }

        public void Add(Map cache)
        {
            {
            var invalids = Strings.AddTable(cache);
            }
        }
    };

    public enum Language
    {
        English,
    };

    /// <summary>
    /// Collection of localized unicode values 
    /// </summary>
    public class UnicodeLocals
    {
        Dictionary<Language, string> Values;
    };
    public abstract class StringManifest : Manifest<StringIdent, string>
    {
        public StringManifest(int count) : base(count)
        {
        }
    };

    public abstract class UnicodeManifest : Manifest<StringIdent, UnicodeLocals>
    {
        public UnicodeManifest(int count) : base(count)
        {
        }
    }

    public abstract class ObjectManifest : Manifest<TagIdent, GuerillaBlock>
    {
        public ObjectManifest(int count) : base(count)
        {
        }
    };
}