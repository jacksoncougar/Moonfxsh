namespace Moonfish.Guerilla.Reflection
{
    public abstract class TokenInfo
    {
        protected string Value;

        public static implicit operator string(TokenInfo usingInfo)
        {
            return usingInfo.ToString();
        }

        public override string ToString()
        {
            return Value;
        }
    }
}