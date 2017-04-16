using System;
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
            var tags = Guerilla.h2Tags.Select(x => new MoonfishTagGroup(x)).ToList();
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
            var tags = Guerilla.h2Tags.Select(x => new MoonfishTagGroup(x)).ToList();
            foreach (
                var blockClass in
                    tags.Where(x => classes.Any(y => y == x.Class)).Select(tag => new GuerillaBlockClass(tag, tags)))
            {
                blockClass.GenerateCSharpCode(Path.Combine(Local.ProjectDirectory, @"Guerilla\Tags.Generated\"));
                Console.WriteLine(@"Generated: {0}", blockClass.TargetClass.Name);
            }
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