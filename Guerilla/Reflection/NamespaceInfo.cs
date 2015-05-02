namespace Moonfish.Guerilla.Reflection
{
    public class NamespaceInfo : TokenInfo
    {
        public const string NamespaceBase = "Moonfish.Guerilla.Tags";

        public NamespaceInfo(string namespaceString)
        {
            Value = string.Format("namespace {0}", string.IsNullOrWhiteSpace(namespaceString) ?
                namespaceString
                : string.Format("{0}.{1}", NamespaceBase, namespaceString));
        }
    }
}