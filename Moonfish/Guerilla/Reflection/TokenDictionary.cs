using System.Collections.Generic;
using Microsoft.CSharp;

namespace Moonfish.Guerilla.Reflection
{
    public class TokenDictionary
    {
        public TokenDictionary(TokenDictionary other)
        {
            Tokens = new HashSet<string>(other.Tokens);
        }

        public TokenDictionary()
        {
            Tokens = new HashSet<string>();
        }

        private HashSet<string> Tokens { get; set; }

        public static string GenerateValidIdentifier(string token)
        {
            using (var code = new CSharpCodeProvider())
            {
                return code.CreateValidIdentifier(token);
            }
        }

        public string GenerateValidToken(string token)
        {
            using (var code = new CSharpCodeProvider())
            {
                token = code.CreateEscapedIdentifier(token);
                var validToken = token;
                var salt = 0;
                do
                {
                    validToken = Tokens.Contains(validToken)
                        ? $"{token}{salt}"
                        : token;
                    salt++;
                } while (!string.IsNullOrWhiteSpace(validToken) && Tokens.Contains(validToken));
                Tokens.Add(validToken);
                return validToken;
            }
        }

        internal bool Contains(string token)
        {
            return Tokens.Contains(token);
        }

        internal void Add(string token)
        {
            Tokens.Add(token);
        }
    }
}