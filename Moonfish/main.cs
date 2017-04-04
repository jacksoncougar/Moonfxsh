﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Moonfish.Cache;
using Moonfish.Guerilla;
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
			CacheStream stream;

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
			stream = CacheStream.Open(extra[0]);
			stream.Seek(stream[3].Identifier);
			var test = stream.Position;
			stream.Position = test;

			if (validate)
			{
				validator = new Validator();
				foreach (TagDatum datum in stream)
				{
					validator.Validate(datum, stream);
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

				Console.WriteLine("Done...");
			}

			if (sign)
			{
				stream.Sign();
			}
		}
	}
}