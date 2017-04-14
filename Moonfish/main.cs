using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Moonfish.Cache;
using Moonfish.Guerilla;
using Moonfish.Guerilla.Tags;
using NDesk.Options;

namespace Moonfish
{
	class main
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		public static void Main(string[] args)
		{
			Validator validator;
			Map stream;

			bool rebuild = false;
			bool sign = false;
			bool validate = false;

			var p = new OptionSet
			{
				{ "r|rebuild=", "rebuilds the given map.",
					(v) => rebuild = v != null },
				{ "s|sign=", "signs the given map",
			  		(v) => sign = v != null },
				{ "v|validate", "validates the given map",
					(v) => { validate = v != null; } },
			};

			p.WriteOptionDescriptions(Console.Out);

			List<string> extra;
			try
			{
				extra = p.Parse(args);
			}
			catch (OptionException e)
			{
				return;
			}

			if (extra.Count < 1 || !File.Exists(extra[0]))
			{
				Console.WriteLine(extra.Count);
				Console.WriteLine("Bad File Argument");
				return;
			}
			stream = new Map(extra[0]);

			if (validate)
			{
				validator = new Validator();
				foreach (TagDatum datum in stream)
				{
					//validator.Validate(datum, stream);
				}
			}

			//if (rebuild)
			//{
			//	Console.WriteLine("Rebuilding...");
			//	CacheStream.Save(stream);
			//	Console.WriteLine("Finished...");
			//}

			if (rebuild)
			{
				Console.WriteLine("Rebuilding...");

				Packager packager = new Packager();
				packager.CreatePackage(stream);

				Console.WriteLine("Done...");
			}

			if (sign)
			{
				stream.Sign();
			}
		}
	}
}