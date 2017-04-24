﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Moonfish.Guerilla.CodeDom;
using Moonfish.Tags;
using NDesk.Options;
using OpenTK.Graphics.OpenGL;

namespace Moonfish
{
    [UsedImplicitly]
    internal class main
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        public static void Main(string[] args)
        {
            Map stream;

            var rebuild = true;
            var sign = false;
            var validate = false;
            var generate = false;

            var p = new OptionSet
            {
                {"r|rebuild=", "rebuilds the given map.", v => rebuild = v != null},
                {"s|sign=", "signs the given map", v => sign = v != null},
                {"v|validate=", "validates the given map", v => { validate = v != null; }},
                {"g|generate=", "generates C# classes from guerilla", v => { generate = v != null; }}
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
                foreach (var datum in stream)
                {
                    //validator.Validate(datum, stream);
                }
            }

            if (rebuild)
            {
                Package package = new Package(stream);
            }
            //{
            //	Console.WriteLine("Rebuilding...");
            //	CacheStream.Save(stream);
            //	Console.WriteLine("Finished...");
            //}

            if (generate)
            {
                Console.WriteLine("Generating C# classes...");

                GuerillaCodeDom.GenerateGuerillaCode(
                    GuerillaCodeDom.TagClasses.Select(x => (TagClass) x).ToArray());

                Console.WriteLine("Done...");
            }

            if (sign)
            {
                stream.Sign();
            }
        }
    }
}