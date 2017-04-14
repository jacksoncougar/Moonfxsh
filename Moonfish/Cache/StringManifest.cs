using System.Collections.Generic;
using System.IO;
using Moonfish.Guerilla;
using Moonfish.Tags;
using Moonfish.Cache;
using System;

namespace Moonfish.Cache
{
	/// <summary>
	/// Creates a Package from a map file
	/// </summary>
	public class Packager
	{
		public Package CreatePackage(Map map)
		{
			Package package = new Package();

			foreach (var item in map.Strings)
			{
				package.Manifest.Strings.Add(item.Key, item.Value);
			}

			foreach (var item in map.Index)
			{
				package.Manifest.Objects.Add(item.Identifier, item);
			}

			return null;
		}
	};

	/// <summary>
	/// A package of object data
	/// </summary>
	public class Package
	{
		List<Stream> DataStreams;
		public Manifest Manifest { get; private set; }

		public Package()
		{
			DataStreams = new List<Stream>();
			Manifest = new Manifest();
		}
	};

    /// <summary>
	/// Collection of Packages (this makes a map) that may inter-reference each other.
    /// </summary>
    public class Repository
    {
        // details: the map can be recreated from a scenario tag and all referenced tags to that. 
		// As well as all the non-external raw data. Strings must be rebuilt and unicode tables.

		public Repository()
		{
		}

		public void Add(Map cache)
        {
        }
    };

    
}