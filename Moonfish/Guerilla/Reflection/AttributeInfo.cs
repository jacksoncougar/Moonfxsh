using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moonfish.Guerilla.Reflection
{
    public class AttributeInfo
    {
        public AttributeInfo(Type attributeType, params object[] namedParameters)
        {
            var count = namedParameters.Length%2 == 0
                ? namedParameters.Length/2
                : (namedParameters.Length - 1)/2;
            NamedParameters = new List<Tuple<string, string>>(count);
            Parameters = new List<string>(count);
            for (int i = 0; i < count*2; i += 2)
            {
                if (namedParameters[i] == null)
                    Parameters.Add(namedParameters[i + 1].ToString());
                else
                    NamedParameters.Add(new Tuple<string, string>(namedParameters[i].ToString(),
                        namedParameters[i + 1].ToString()));
            }
            AttributeType = attributeType;
        }

        public Type AttributeType { get; set; }
        public List<Tuple<string, string>> NamedParameters { get; set; }
        public List<string> Parameters { get; set; }

        public override string ToString()
        {
            using (var code = new Microsoft.CSharp.CSharpCodeProvider())
            {
                var hasParameters = NamedParameters.Count > 0 || Parameters.Count > 0;
                var parametersString = new StringBuilder();
                if (hasParameters && Parameters.Count > 0)
                {
                    Parameters.TakeWhile(x => Parameters.Last() != x)
                        .ToList()
                        .ForEach(x => parametersString.Append($"{x}, "));
                    parametersString.Append(Parameters.Last());
                }
                if (hasParameters && NamedParameters.Count > 0)
                {
                    NamedParameters.TakeWhile(x => NamedParameters.Last() != x)
                        .ToList()
                        .ForEach(x => parametersString.Append($"{x.Item1} = {x.Item2}, "));
                    parametersString.Append($"{NamedParameters.Last().Item1} = {NamedParameters.Last().Item2}");
                }

                var retval = $"[{AttributeType.Name}{(hasParameters ? $"({parametersString})" : "")}]";
                return retval;
            }
        }
    }
}