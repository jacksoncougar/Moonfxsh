using System;
using System.Collections.Generic;
using System.IO;
using Moonfish.Guerilla;
using Moonfish.Tags;

namespace Moonfish.Cache
{
    /// <summary>
    /// Allows lookups for package data from keys 
    /// (e.g StringIdents, TagIdents, and other reference types).
    /// </summary> 
    public abstract class ManifestDictionary<TK, TV>
    {
        /// <summary>
        /// Internal identifier for Manifest items
        /// </summary>
        public struct Ident
        {
            private int value;

            public Ident(int value)
            {
                this.value = value;
            }
        };

        /// <summary>
        /// The information about a value contained in the manifest 
        /// </summary>
        public struct Info
        {
            /// <summary>
            /// The proper name of the manifest item. (should be unique to the package)
            /// </summary>
            /// <value>The name.</value>
            public string Name { get; private set; }

            /// <summary>
            /// Gets a value indicating whether this <see cref="T:Moonfish.Cache.ManifestDictionary`2.Info"/> is internal.
            /// </summary>
            /// <value><c>true</c> if internal; otherwise, <c>false</c>.</value>
            public bool Internal { get; private set; }

            /// <summary>
            /// Gets the index of the stream within the package where the value data is.
            /// </summary>
            public int Source { get; }

            /// <summary>
            /// Gets the dependancy that this item points to. (or -1 if internal)
            /// </summary>
            /// <value>The dependancy.</value>
            public int Dependancy { get; private set; }

            /// <summary>
            /// Gets or sets the user data.
            /// </summary>
            /// <value>The user data.</value>
            public object UserData { get; set; }

            public Info(string name)
            {
                Name = name;
                Internal = true;
                Source = 0;
                Dependancy = -1;
                UserData = null;
            }
        };

        /// <summary>
        /// External dependancies used by this package.
        /// </summary>
        public struct PackageDependancy
        {
            public string PackageName { get; private set; }
        };

        /// <summary>
        /// Gets the name of the package this Manifest belongs to.
        /// </summary>
        /// <value>The name of the package.</value>
        public string PackageName { get; private set; }

        /// <summary>
        /// Maps from internal package keys to manifest identifiers.
        /// </summary>
        private Dictionary<TK, Ident> keymap;

        /// <summary>
        /// Local values contained in this package.
        /// </summary>
        private Dictionary<Ident, TV> localValues;

        /// <summary>
        /// The entries in the manifest describing what the identifier refers to.
        /// </summary>
        private Dictionary<Ident, Info> entries;

        /// <summary>
        /// The external packages this package depends upon.
        /// </summary>
        private List<PackageDependancy> dependancies;

        protected ManifestDictionary()
        {

            keymap = new Dictionary<TK, Ident>();
            localValues = new Dictionary<Ident, TV>();
            entries = new Dictionary<Ident, Info>();
        }

        /// <summary>
        /// Gets the object linked to the specified key.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="key">Key.</param>
        public TV Get(TK key)
        {
            TV value;
            var identifier = keymap[key];
            var info = entries[identifier];

            if (info.Internal)
            {
                value = localValues[identifier];
            }
            else
            {
                var callback = new DereferenceCallback(identifier,
                    dependancies[info.Dependancy]);

                GetExternalReferenceEventHandler?.Invoke(this, callback);

                if (callback.Success)
                {
                    value = callback.ReturnValue;
                }
                else
                    throw new InvalidOperationException(
                        "Could not find external reference.");
            }

            return value;
        }

        public TV this[Ident key]
        {
            get { return localValues[key]; }
        }

        public event EventHandler<DereferenceCallback>
            GetExternalReferenceEventHandler;

        public event EventHandler<GenerateRepositoryIdentEventArgs>
            GetRepositoryIdentEventHandler;

        public class DereferenceCallback : EventArgs
        {
            public Ident Key { get; private set; }
            public PackageDependancy PackageDependancy { get; private set; }
            public TV ReturnValue { get; set; }
            public bool Success { get; set; } = false;

            public DereferenceCallback(Ident key,
                PackageDependancy packageDependancy)
            {
                Key = key;
                PackageDependancy = packageDependancy;
            }
        }

        public class GenerateRepositoryIdentEventArgs : EventArgs
        {
            public TK Key { get; }
            public Ident Identifier { get; set; }
            public bool Success { get; set; } = false;

            public GenerateRepositoryIdentEventArgs(TK key)
            {
                Key = key;
            }
        }

        /// <summary>
        /// Add the specified key and value as an internal manifest item.
        /// </summary>
        /// <param name="key">the key of the item to add.</param>
        /// <param name="value">the item to add.</param>
        public virtual void Add(TK key, TV value)
        {
            // TODO add code to add external references
            var identifier = GenerateIdentifier(key, value);
            var info = new Info(GetValueName(value));

            keymap.Add(key, identifier);

            localValues.Add(identifier, value);
            entries.Add(identifier, info);

            return;
        }

        /// <summary>
        /// Gets the name of the value.
        /// </summary>
        /// <returns>The value name.</returns>
        /// <param name="value">Value.</param>
        protected virtual string GetValueName(TV value)
        {
            return value.ToString();
        }

        /// <summary>
        /// Generates the identifier of a resource in this Manifest.
        /// </summary>
        /// <returns>The identifier of the resource</returns>
        protected virtual Ident GenerateIdentifier(TK key, TV value)
        {
            // TODO generate valid identifiers...
            return new Ident(key.GetHashCode());
        }

        protected virtual void OnGetRepositoryIdentEventHandler(
            GenerateRepositoryIdentEventArgs e)
        {
            GetRepositoryIdentEventHandler?.Invoke(this, e);
        }
    };

    /// <summary>
    /// Manifest of tag objects contained in this package. (GuerillaBlocks)
    /// </summary>
    public class ObjectManifest : ManifestDictionary<TagIdent, GuerillaBlock>
    {
    };

    /// <summary>
    /// Manifest of named constants contained in this package. (StringIdents)
    /// </summary>
    public class StringManifest : ManifestDictionary<StringIdent, string>
    {
    };

    /// <summary>
    /// Manifest of localizable strings contained in this package. (Unicode strings)
    /// </summary>
    public class LocalizationManifest : ManifestDictionary<StringIdent, ICollection<string>>
    {
    }

    /// <summary>
	/// The manifest of all items contained and referenced by this package.
	/// </summary>
	public class Manifest
	{
		public StringManifest Strings { get; private set; }
		public ObjectManifest Objects { get; private set; }
        public LocalizationManifest Localizations { get; private set; }

		public Manifest()
		{
			Strings = new StringManifest();
			Objects = new ObjectManifest();
            Localizations = new LocalizationManifest();
		}
	}
}