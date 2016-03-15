namespace Moonfish.Graphics
{
    public class ShaderReference
    {
        public enum ReferenceType
        {
            Halo2,
            System
        }

        public int Ident;

        public ShaderReference( ReferenceType type, int ident )
        {
            Type = type;
            Ident = ident;
        }

        public ReferenceType Type { get; set; }
    }
}