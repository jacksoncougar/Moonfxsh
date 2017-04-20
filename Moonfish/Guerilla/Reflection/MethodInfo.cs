using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fasterflect;

namespace Moonfish.Guerilla.Reflection
{
    public class MethodInfo
    {
        public MethodInfo()
        {
            Arguments = new List<ParameterInfo>();
        }

        public AccessModifiers AccessModifiers { get; set; }
        public string ClassName { get; set; }
        public List<ParameterInfo> Arguments { get; set; }
        public string Body { get; set; }
        public string Returns { get; set; }
        public bool Wrapper { get; set; }

        public string GetMethodCallSignature()
        {
            return GetMethodCallSignatureFormat("", GetArguments(Arguments));
        }

        public string GetMethodSignature()
        {
            return GetMethodSignatureFormat("");
        }

        private string GetMethodSignatureFormat(string methodName)
        {
            return GetMethodCallSignatureFormat(methodName, GetSignature(Arguments));
        }

        private string GetMethodCallSignatureFormat(string methodName, StringBuilder argumentString)
        {
            return $"{String.Format(ClassName, methodName)}{string.Format($"({argumentString})", argumentString)}";
        }

        private static StringBuilder GetSignature(IList<ParameterInfo> arguments)
        {
            var argumentStringBuilder = new StringBuilder();
            if (arguments.Any())
            {
                arguments.TakeWhile(x => x != arguments.Last())
                    .ToList()
                    .ForEach(
                        x =>
                            argumentStringBuilder.AppendFormat("{0} {1}, ", x.ParameterType.Name(), x.Name));
                var arg = arguments.Last();
                argumentStringBuilder.Append(
                    $"{arg.Modifier.GetSignatureModifier()} {arg.ParameterType.Name()} {arg.Name}".TrimStart());
            }
            return argumentStringBuilder;
        }

        private static StringBuilder GetArguments(IList<ParameterInfo> arguments)
        {
            var argumentStringBuilder = new StringBuilder();
            if (arguments.Any())
            {
                arguments.TakeWhile(x => x != arguments.Last())
                    .ToList()
                    .ForEach(x => argumentStringBuilder.AppendFormat("{0}, ", x.Name));
                var arg = arguments.Last();
                argumentStringBuilder.AppendFormat("{0}", arg.Name);
            }
            return argumentStringBuilder;
        }

        public MethodInfo MakeFromTemplate(params string[] args)
        {
            return new MethodInfo()
            {
                Arguments = Arguments,
                AccessModifiers = AccessModifiers,
                ClassName = string.Format(ClassName, args),
                Body = string.Format(Body, args),
                Returns = string.Format(Returns, args),
            };
        }

        public override string ToString()
        {
            var methodStringBuilder = new StringBuilder();
            var modifiersString = AccessModifiers.ToTokenString();
            methodStringBuilder.AppendFormat("{0}{3}{1}{4}{2}", modifiersString, Returns, GetMethodSignature(),
                string.IsNullOrWhiteSpace(modifiersString) ? "" : " ",
                string.IsNullOrWhiteSpace(Returns) ? "" : " ");
            if (Wrapper)
            {
                methodStringBuilder.AppendFormat(" : base({0})", GetArguments(Arguments));
            }
            methodStringBuilder.AppendLine();
            methodStringBuilder.AppendLine("{");
            if (!string.IsNullOrWhiteSpace(Body)) methodStringBuilder.AppendLine(Body);
            methodStringBuilder.AppendLine("}");
            return methodStringBuilder.ToString().Trim();
        }

        internal MethodInfo MakeWrapper(string className)
        {
            return new MethodInfo
            {
                Arguments = Arguments,
                AccessModifiers = AccessModifiers.Public,
                Wrapper = true,
                ClassName = className,
                Body = "",
                Returns = Returns,
            };
        }
    }
}