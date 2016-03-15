        namespace Moonfish.Guerilla.Reflection
{
    public class UsingInfo : TokenInfo
    {
        public UsingInfo(string namespaceString)
        {
            Value = string.Format("using {0};", namespaceString);
        }
    }
}