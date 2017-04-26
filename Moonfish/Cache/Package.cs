using System.Collections.Generic;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;

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

        /// <summary>
        /// Intializes new package from an existing map,
        /// </summary>
        /// <param name="map">The map to initialize the package from.</param>
        public Package(Map map) : this()
        {
            foreach (KeyValuePair<StringIdent, string> item in map.Strings)
            {
                Manifest.Strings.Add(item.Key, item.Value);
            }

            foreach (var item in map.Index)
            {
                var @object = map.Deserialize(item.Identifier);
                Manifest.Objects.Add(item.Identifier, @object);

                var resourceBlocks = @object as IResourceContainer<object>;
                if (resourceBlocks != null)
                    foreach (IResourceBlock<object> resourceBlock in resourceBlocks)
                    {
                        var pointer = resourceBlock.GetResourcePointer();

                        if(pointer.Location > 0)
                            continue;
                        if (Manifest.Resources.Contains(pointer))
                            continue;

                        var stream = new VirtualStream(pointer.Address);
                        resourceBlock.WriteResource(stream);

                        Manifest.Resources.Add(pointer, stream);
                    }
            }

            foreach (KeyValuePair<StringIdent, ICollection<string>> localization in map.StringLocalizations)
            {
                Manifest.Localizations.Add(localization.Key, localization.Value);
            }
        }

        public Manifest Manifest { get; }
    }
}