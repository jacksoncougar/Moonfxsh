using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moonfish.Guerilla.Reflection
{
    public class EnumInfo
    {
        public Type BaseType { get; set; }
        public List<AttributeInfo> Attributes { get; set; }
        public AccessModifiers AccessModifiers { get; set; }
        public GuerillaName Value { get; set; }
        public List<GuerillaName> ValueNames { get; set; }

        public enum Type
        {
            Byte,
            Short,
            Int,
        }

        public EnumInfo()
        {
            Attributes = new List<AttributeInfo>();
            ValueNames = new List<GuerillaName>();
        }

        public void Format()
        {
            var tokenDictionary = new TokenDictionary();
            for (int i = 0; i < ValueNames.Count; i++)
            {
                ValueNames[i] = tokenDictionary.GenerateValidToken(Guerilla.ToTypeName(ValueNames[i]));
            }
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            foreach (var attribute in Attributes)
            {
                stringBuilder.AppendLine(attribute.ToString());
            }
            stringBuilder.AppendLine(string.Format("{0} enum {1} : {2}",
                AccessModifiers.ToTokenString(), Value.Name,
                BaseType.ToString().ToLowerInvariant()).Trim());
            stringBuilder.AppendLine("{");

            var isFlags = Attributes.Any(x => x.AttributeType == typeof (FlagsAttribute));
            var value = isFlags ? 1 : 0;
            foreach (var item in ValueNames)
            {
                if (item.HasDescription) stringBuilder.AppendSummary(item.Description);
                stringBuilder.AppendLine(string.Format("{0} = {1},", Guerilla.ToTypeName(item.Name), value));
                value = isFlags ? value << 1 : ++value;
            }
            stringBuilder.AppendLine("};");
            return stringBuilder.ToString().Trim();
        }
    }
}