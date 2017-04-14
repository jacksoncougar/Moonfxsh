using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Moonfish.Tags;

namespace Moonfish.Cache
{
    /// <summary>
    /// Allows lookups for package data from keys 
	/// (e.g StringIdents, TagIdents, and other reference types).
    /// </summary> 
	public abstract class ManifestDictionary<K, V>
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
			/// Gets the dependancy that this item points to. (or -1 if internal)
			/// </summary>
			/// <value>The dependancy.</value>
			public int Dependancy { get; private set;}

			/// <summary>
			/// Gets or sets the user data.
			/// </summary>
			/// <value>The user data.</value>
			public object UserData { get; set; }

			public Info(string name)
			{
				Name = name;
				Internal = true;
				Dependancy = -1;
				UserData = null;
			}
		};

		/// <summary>
		/// External dependancies used by this package.
		/// </summary>
		public struct Dependancy
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
		private Dictionary<K, Ident> keymap;

		/// <summary>
		/// Local values contained in this package.
		/// </summary>
		private Dictionary<Ident, V> localValues;

		/// <summary>
		/// The entries in the manifest describing what the identifier refers to.
		/// </summary>
		private Dictionary<Ident, Info> entries;

		/// <summary>
		/// The external packages this package depends upon.
		/// </summary>
		private List<Dependancy> dependancies;


		public ManifestDictionary()
		{
			keymap = new Dictionary<K, Ident>();
			localValues = new Dictionary<Ident, V>();
			entries = new Dictionary<Ident, Info>();
		}

		/// <summary>
		/// Gets the object linked to the specified key.
		/// </summary>
		/// <returns>The get.</returns>
		/// <param name="key">Key.</param>
		public V Get(K key)
		{
			V value;
			var identifier = keymap[key];
			var info = entries[identifier];

			if (info.Internal)
			{
				value = localValues[identifier];
			}
			else
			{
				var callback = new DereferenceCallback(identifier, dependancies[info.Dependancy]);

				GetExternalReferenceEventHandler(this, callback);

				if (callback.Success)
				{
					value = callback.ReturnValue;
				}
				else throw new InvalidOperationException("Could not find external reference.");
			}

			return value;
		}

		public V this[Ident key] { get { return localValues[key]; } }

		public event EventHandler<DereferenceCallback>  GetExternalReferenceEventHandler;
		public event EventHandler<GenerateRepositoryIdentEventArgs> GetRepositoryIdentEventHandler;

		public class DereferenceCallback : EventArgs
		{
			public Ident Key { get; private set; }
			public Dependancy Dependancy { get; private set; }
			public V ReturnValue { get; set; }
			public bool Success { get; set; } = false;

			public DereferenceCallback(Ident key, Dependancy dependancy)
			{
				Key = key;
				Dependancy = dependancy;
			}
		}

		public class GenerateRepositoryIdentEventArgs : EventArgs
		{
			public K Key { get; }
			public Ident Identifier { get; set; }
			public bool Success { get; set; } = false;

			public GenerateRepositoryIdentEventArgs(K key)
			{
				Key = key;
			}
		}

		/// <summary>
		/// Add the specified key and value as an internal manifest item.
		/// </summary>
		/// <param name="key">the key of the item to add.</param>
		/// <param name="value">the item to add.</param>
		public virtual void Add(K key, V value)
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
		protected virtual string GetValueName(V value)
		{
			return value.ToString();
		}

		/// <summary>
		/// Generates the identifier of a resource in this Manifest.
		/// </summary>
		/// <returns>The identifier of the resource</returns>
		protected virtual Ident GenerateIdentifier(K key, V value)
		{
			// TODO generate valid identifiers...
			return new Ident((int)DateTime.Now.ToFileTime());
		}
	};
	              
	public class ObjectManifest : ManifestDictionary<TagIdent, TagDatum>
	{

	};

	public class StringManifest : ManifestDictionary<StringIdent, string>
	{
	};

	/// <summary>
	/// The manifest of all items contained and referenced by a package.
	/// </summary>
	public class Manifest
	{
		public StringManifest Strings { get; private set; }
		public ObjectManifest Objects { get; private set; }

		public Manifest()
		{
			Strings = new StringManifest();
			Objects = new ObjectManifest();
		}
	}
}