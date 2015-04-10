using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moonfish.Guerilla
{
    public static class ParameterModifierExtensions
    {
        public static string GetSignatureModifier(this ParameterModifier modifier)
        {
            switch (modifier)
            {
                    case ParameterModifier.None:
                    return "";
                    case ParameterModifier.Out:
                    return "out";
                    case ParameterModifier.Ref:
                    return "ref";
                default:
                    return "";
            }
        }
    }

    public class ParameterInfo
    {
        public Type ParameterType { get; private set; }
        public string Name { get; private set; }

        public ParameterModifier Modifier { get; set; }

        public ParameterInfo(Type parameterType)
        {
            Modifier = ParameterModifier.None;
            ParameterType = parameterType;
            var type = parameterType.Name;
            Name = Guerilla.ToMemberName(type);
        }

        public ParameterInfo(Type parameterType, string argumentName)
        {
            Modifier = ParameterModifier.None;
            ParameterType = parameterType;
            Name = argumentName;
        }
    }

    public enum  ParameterModifier 
    {
        None,
        Out,
        Ref,
    }
}