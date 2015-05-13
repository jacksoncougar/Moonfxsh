using System;
using System.Collections.Generic;
using System.Linq;
using Moonfish.Tags;

namespace Moonfish.Guerilla.CodeDom
{
    internal static class GuerillaCodeDom
    {
        public static void GenerateGuerillaCode()
        {
            var tags = Guerilla.h2Tags.Select(x => new MoonfishTagGroup(x)).ToList();
            foreach (var blockClass in tags.Select(tag => new GuerillaBlockClass(tag, tags)))
            {
                blockClass.GenerateCSharpCode();
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
    }
}