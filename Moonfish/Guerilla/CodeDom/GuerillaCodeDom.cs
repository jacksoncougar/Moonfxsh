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
            if (classes.Length < 1)
                return;

            List<MoonfishTagGroup> tags = Guerilla.H2Tags.Select(x => new MoonfishTagGroup(x)).ToList();
            foreach (
                var blockClass in
                    tags.Where(x => classes.Any(y => y == x.Class)).Select(tag => new GuerillaBlockClass(tag, tags)))
            {
                blockClass.GenerateCSharpCode(Path.Combine(Local.ProjectDirectory, @"Guerilla\Tags.Generated\"));
                Console.WriteLine(@"Generated: {0}", blockClass.TargetClass.Name);
            }
        }

        public static readonly TagGroupLookup TagClasses = new TagGroupLookup();

        public class TagGroupLookup : IEnumerable<string>
        {
            private static readonly List<string> Classes = new List<string>
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
                get { return Classes[index]; }
            }

            #region IEnumerable Members

            IEnumerator IEnumerable.GetEnumerator()
            {
                return Classes.GetEnumerator();
            }

            #endregion

            #region IEnumerable<string> Members

            IEnumerator<string> IEnumerable<string>.GetEnumerator()
            {
                return Classes.GetEnumerator();
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