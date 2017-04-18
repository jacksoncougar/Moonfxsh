using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Moonfish.Tags;

namespace Moonfish.Guerilla.CodeDom
{
    public static class GuerillaCodeDom
    {
        public static void PrintByteFrequencies()
        {
            long[] frequency = new long[256];

            byte[] buffer = new byte[0x2000];
            var blockLength = 8;
            foreach (var cacheStream in GetAllMaps())
            {
                int length = 0;
                while ((length = cacheStream.BaseStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    var blockCount = length / blockLength;
                    var remainder = length % blockLength;
                    for (var index = 0; index < blockCount; ++index)
                    {
                        frequency[buffer[index + 0]]++;
                        frequency[buffer[index + 1]]++;
                        frequency[buffer[index + 2]]++;
                        frequency[buffer[index + 3]]++;
                        frequency[buffer[index + 4]]++;
                        frequency[buffer[index + 5]]++;
                        frequency[buffer[index + 6]]++;
                        frequency[buffer[index + 7]]++;
                    }
                    for (var index = 0; index < remainder; ++index)
                    {
                        frequency[buffer[index + 0]]++;
                    }
                }
                Console.WriteLine(cacheStream.Header.Scenario);
            }
            var values = frequency.Select((i, j) => new { i, j }).ToDictionary(x => x.j, x => x.i);
            var greatest = values.Aggregate((i, j) => i.Value > j.Value ? i : j);
            var fewest = values.Aggregate((i, j) => i.Value < j.Value ? i : j);
            var frequencies = values.Values.ToList();
            var totalHits = frequencies.Sum();
            frequencies.Sort();
            foreach (var l in frequencies)
            {
                var item = values.First(x => x.Value == l);
                Console.WriteLine(@"{0}:({2}){1}", item.Key, item.Value, (float)item.Value / (float)totalHits);
            }
        }

        public static void GenerateGuerillaCode()
        {
            var tags = Guerilla.H2Tags.Select(x => new MoonfishTagGroup(x)).ToList();
            foreach (var blockClass in tags.Select(tag => new GuerillaBlockClass(tag, tags)))
            {
                blockClass.GenerateCSharpCode(Path.Combine(Local.ProjectDirectory, @"Guerilla\Tags.Generated\"));
                Console.WriteLine(@"Generated: {0}", blockClass.TargetClass.Name);
            }
        }

        public static bool IsValidIdentifier(this string value)
        {
            string[] invalidNames =
            {
                "EMPTY_STRING",
                "EMPTYSTRING",
                "",
                "YOUR MOM",
                "..."
            };
            return (!invalidNames.Any(value.Equals) || !string.IsNullOrWhiteSpace(value) || value.Length > 0) &&
                   !char.IsDigit(value[0]);
        }

        public static string ToPascalCase(this string value)
        {
            // If there are 0 or 1 characters, just return the string.
            if (value == null) return value;
            if (value.Length < 2) return value.ToUpper();

            // Split the string into words.
            var words = value.Split(
                new[] {' ', '_'},
                StringSplitOptions.RemoveEmptyEntries);

            // Combine the words.
            var result = "";
            foreach (var word in words)
            {
                result +=
                    word.Substring(0, 1).ToUpper() +
                    word.Substring(1);
            }

            return result;
        }

        public static string ToCamelCase(this string value)
        {
            // If there are 0 or 1 characters, just return the string.
            if (value == null || value.Length < 2)
                return value;

            // Split the string into words.
            var words = value.Split(
                new[] {' ', '_'},
                StringSplitOptions.RemoveEmptyEntries);

            // Combine the words.
            var result = words[0].ToLower();
            for (var i = 1; i < words.Length; i++)
            {
                result +=
                    words[i].Substring(0, 1).ToUpper() +
                    words[i].Substring(1);
            }

            return result;
        }

        public static string ToAlphaNumericToken(this string value)
        {
            value = new string(value.Where(char.IsLetterOrDigit).ToArray());
            if (string.IsNullOrWhiteSpace(value)) return value;
            return char.IsDigit(value[0]) ? "_" + value : value;
        }

        public static void GenerateGuerillaCode(params TagClass[] classes)
        {
            var tags = Guerilla.H2Tags.Select(x => new MoonfishTagGroup(x)).ToList();
            foreach (
                var blockClass in
                    tags.Where(x => classes.Any(y => y == x.Class)).Select(tag => new GuerillaBlockClass(tag, tags)))
            {
                blockClass.GenerateCSharpCode(Path.Combine(Local.ProjectDirectory, @"Guerilla\Tags.Generated\"));
                Console.WriteLine(@"Generated: {0}", blockClass.TargetClass.Name);
            }
        }

        public static TagGroupLookup TagClasses = new TagGroupLookup();

        public class TagGroupLookup : IEnumerable, IEnumerable<string>
        {
            private static readonly List<string> classes = new List<string>
            {
                #region Class Strings
                "$#!+",
                "*cen",
                "*eap",
                "*ehi",
                "*igh",
                "*ipd",
                "*qip",
                "*rea",
                "*sce",
                "/**/",
                "<fx>",
                "BooM",
                "DECP",
                "DECR",
                "MGS2",
                "PRTM",
                "adlg",
                "ai**",
                "ant!",
                "bipd",
                "bitm",
                "bloc",
                "bsdt",
                "char",
                "cin*",
                "clu*",
                "clwd",
                "coll",
                "coln",
                "colo",
                "cont",
                "crea",
                "ctrl",
                "dc*s",
                "dec*",
                "deca",
                "devi",
                "devo",
                "dgr*",
                "dobc",
                "effe",
                "egor",
                "eqip",
                "fog ",
                "foot",
                "fpch",
                "garb",
                "gldf",
                "goof",
                "grhi",
                "hlmt",
                "hmt ",
                "hsc*",
                "hud#",
                "hudg",
                "item",
                "itmc",
                "jmad",
                "jpt!",
                "lens",
                "lifi",
                "ligh",
                "lsnd",
                "ltmp",
                "mach",
                "matg",
                "mdlg",
                "metr",
                "mode",
                "mpdt",
                "mply",
                "mulg",
                "nhdt",
                "obje",
                "phmo",
                "phys",
                "pmov",
                "pphy",
                "proj",
                "prt3",
                "sbsp",
                "scen",
                "scnr",
                "sfx+",
                "shad",
                "sily",
                "skin",
                "sky ",
                "slit",
                "sncl",
                "snd!",
                "snde",
                "snmx",
                "spas",
                "spk!",
                "ssce",
                "sslt",
                "stem",
                "styl",
                "tdtl",
                "trak",
                "trg*",
                "udlg",
                "ugh!",
                "unhi",
                "unic",
                "unit",
                "vehc",
                "vehi",
                "vrtx",
                "weap",
                "weat",
                "wgit",
                "wgtz",
                "whip",
                "wigl",
                "wind",
                "wphi"

                #endregion
            };

            public string this[int index]
            {
                get { return classes[index]; }
            }

            #region IEnumerable Members

            IEnumerator IEnumerable.GetEnumerator()
            {
                return classes.GetEnumerator();
            }

            #endregion

            #region IEnumerable<string> Members

            IEnumerator<string> IEnumerable<string>.GetEnumerator()
            {
                return classes.GetEnumerator();
            }

            #endregion
        }

        public static IEnumerable<Map> GetAllMaps()
        {
            var filenames = Directory.GetFiles(Local.MapsDirectory, "*.map", SearchOption.AllDirectories);
            foreach (var filename in filenames)
            {
                Map testmap = null;
                try
                {
                    testmap = new Map(filename);
                }
                catch (InvalidDataException)
                {
                    continue;
                }
                using (testmap)
                {
                    yield return testmap;
                }
            }
        }
    }
}