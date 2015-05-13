using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.CSharp;

namespace Moonfish.Guerilla.CodeDom
{
    static class GuerillaCodeDom
    {
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
            return (!invalidNames.Any(value.Equals) || !string.IsNullOrWhiteSpace(value) || value.Length > 0) && !char.IsDigit(value[0]);
        }
        public static string ToPascalCase(this string value)
        {
            // If there are 0 or 1 characters, just return the string.
            if (value == null) return value;
            if (value.Length < 2) return value.ToUpper();

            // Split the string into words.
            string[] words = value.Split(
                new [] { ' ', '_' },
                StringSplitOptions.RemoveEmptyEntries);

            // Combine the words.
            string result = "";
            foreach (string word in words)
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
            string[] words = value.Split(
                new[] { ' ', '_' },
                StringSplitOptions.RemoveEmptyEntries);

            // Combine the words.
            string result = words[0].ToLower();
            for (int i = 1; i < words.Length; i++)
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

        public static string Name(this Type type)
        {
            using(CSharpCodeProvider code = new CSharpCodeProvider())
            {
                var name = Fasterflect.TypeExtensions.Name(type);
                return name;
            }
        }
        static string ValidateFieldName(string fieldName)
        {
            using (var provider = new CSharpCodeProvider())
            {
                if (!provider.IsValidIdentifier(fieldName))
                {
                    fieldName = string.Format("invalidName_{0}", fieldName);
                }
            }
            return fieldName;
        }
    }
}
