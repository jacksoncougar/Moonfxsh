namespace Moonfish.Guerilla.Reflection
{
    public class NamespaceInfo : TokenInfo
    {
        public const string NamespaceBase = "Moonfish.Guerilla.Tags";

        public NamespaceInfo():this(null)
        {
        }

        public NamespaceInfo(string namespaceString)
        {
            Value = string.Format("namespace {0}", string.IsNullOrWhiteSpace(namespaceString)
                ? NamespaceBase
                : string.Format("{0}.{1}", NamespaceBase, namespaceString));
        }
    }
}