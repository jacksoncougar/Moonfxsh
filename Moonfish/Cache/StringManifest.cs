namespace Moonfish
{
    /// <summary>
    ///     A package of object data.
    /// </summary>
    public class Package
    {
        private Package()
        {
            Manifest = new Manifest();
        }

        public Package(Map map) : this()
        {
            foreach (var item in map.Strings)
            {
                Manifest.Strings.Add(item.Key, item.Value);
            }

            foreach (var item in map.Index)
            {
                var @object = map.Deserialize(item.Identifier);
                Manifest.Objects.Add(item.Identifier, @object);
            }

            foreach (var localization in map.StringLocalizations)
            {
                Manifest.Localizations.Add(localization.Key, localization.Value);
            }
        }

        public Manifest Manifest { get; }
    }

    /// <summary>
    ///     Collection of Packages (this makes a map) that may inter-reference each other.
    /// </summary>
    public class Repository
    {
        // details: the map can be recreated from a scenario tag and all referenced tags to that. 
        // As well as all the non-external raw data. Strings must be rebuilt and unicode tables.

        public void Add(Map cache)
        {
        }
    }
}