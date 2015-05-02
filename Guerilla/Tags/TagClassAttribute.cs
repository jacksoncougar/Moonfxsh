using System;

namespace Moonfish.Tags
{
    [AttributeUsage( AttributeTargets.Class, Inherited = false )]
    public class TagClassAttribute : System.Attribute
    {
        public TagClass TagClass { get; set; }

        public TagClassAttribute( string tagClass )
        {
            TagClass = ( TagClass ) tagClass;
        }
    }
}