        namespace Moonfish.Guerilla.Reflection
{
    public class UsingInfo : TokenInfo
    {
        public UsingInfo(string namespaceString)
        {
            Value = $"using {namespaceString};";
        }
    }
}