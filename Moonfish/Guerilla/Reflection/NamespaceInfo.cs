using System;

namespace Moonfish.Guerilla.Reflection
{
    public class NamespaceInfo : TokenInfo
    {
        public const string NamespaceBase = "Moonfish.Guerilla.Tags";

        public NamespaceInfo() : this(null)
        {
        }

        public NamespaceInfo(string namespaceString)
        {
            Value = String.Format("namespace {0}",
                string.IsNullOrWhiteSpace(namespaceString) ? NamespaceBase : $"{NamespaceBase}.{namespaceString}");
        }
    }
}