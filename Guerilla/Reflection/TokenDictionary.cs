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
                var validToken = "";
                var salt = 0;
                do
                {
                    validToken = Tokens.Contains(token)
                        ? string.Format("{0}{1}", token, salt)
                        : code.CreateEscapedIdentifier(token);
                    salt++;
                } while (Tokens.Contains(validToken));
                Tokens.Add(validToken);
                return validToken;
            }
        }
    }
}