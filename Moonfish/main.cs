using System;
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

			if (validate)
			{
				validator = new Validator();
				foreach (TagDatum datum in stream)
				{
					validator.Validate(datum, stream);
				}
			}

			if (rebuild)
			{
				Console.WriteLine("Rebuilding...");
				CacheStream.Save(stream);
				Console.WriteLine("Finished...");
			}

			if (false)
			{
				Console.WriteLine("Rebuilding...");
				int count = stream.Index.Count;
				for (int i = 1; i < count && i < stream.Index.Count; ++i)
				{
					var current = stream.Index[i];
					//current.Identifier = new Tags.TagIdent((short)i);

					if (current.Class == Tags.TagClass.Sbsp || current.Class == Tags.TagClass.Ltmp)
					{
						stream.UpdateBinding(stream.Index[i].Identifier, current.Identifier);
					}
					var tag = stream.Deserialize(current.Identifier);

					if (current.Class == Tags.TagClass.Scnr)
					{
						var scenario = new Guerilla.Tags.ScenarioBlock();
						scenario.EditorScenarioData = new byte[0];
						scenario.ScriptSyntaxData = new byte[0];
						scenario.ScriptStringData = new byte[0];
						for (int s = 0; s < scenario.ObjectSalts00.Count(); ++s)
						{
							scenario.ObjectSalts00[s] = new Guerilla.Tags.ScenarioBlock.ObjectSaltsBlock();
						}
						tag = scenario;
					}
					else if (current.Class == Tags.TagClass.Ugh)
					{
						var structure = new Guerilla.Tags.SoundCacheFileGestaltBlock();
						tag = structure;
					}
					else if (current.Class == Tags.TagClass.Sbsp)
					{
						var structure = new Guerilla.Tags.ScenarioStructureBspBlock();
						tag = structure;
					}
					else
					{
						tag = ((GuerillaBlock)Activator.CreateInstance(Halo2.GetTypeOf(current.Class)));
						tag.Read(new BinaryReader(new MemoryStream(new byte[tag.SerializedSize])));
					}
					stream.UpdateCache(current.Identifier, tag);
					stream.Index.Update(current.Identifier, current);
				}
				stream.Index.ScenarioIdent = stream.Index.First(x => x.Class == Tags.TagClass.Scnr).Identifier;
				using(var file = File.Create("output.map"))
					stream.SaveTo(file);
				stream.Close();

				stream = CacheStream.Open("output.map");
				Console.WriteLine("Done...");
			}

			if (sign)
			{
				stream.Sign();
			}
		}
	}
}