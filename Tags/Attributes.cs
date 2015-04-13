using System;
using System.Diagnostics.CodeAnalysis;

namespace Moonfish.Tags
{
    [SuppressMessage( "ReSharper", "InconsistentNaming" )]
    public class LayoutAttribute : Attribute
    {
        public int Size;
        public int Alignment;
        public int MaxElements;
    }

    [AttributeUsage( AttributeTargets.Class, Inherited = false )]
    public class TagClassAttribute : System.Attribute
    {
        public TagClass TagClass { get; set; }
        public TagClassAttribute( string tagClass )
        {
            TagClass = ( TagClass )tagClass;
        }
    }

    [AttributeUsage( AttributeTargets.Field )]
    public class TagBlockFieldAttribute : TagFieldAttribute
    {
        public TagBlockFieldAttribute( int fieldOffset ) : base( fieldOffset ) { }

        public TagBlockFieldAttribute( ) { }
    }

    [AttributeUsage( AttributeTargets.Field )]
    public class TagStructFieldAttribute : TagFieldAttribute
    {
    }

    [AttributeUsage( AttributeTargets.All )]
    public class TagFieldAttribute : Attribute
    {
        public bool usesCustomFunction = false;
        public int offset;
        public bool UsesFieldOffset { get { return offset != -1; } }

        public TagFieldAttribute( ) : this( -1 ) { }
        public TagFieldAttribute( int fieldOffset )
        {
            offset = fieldOffset;
        }
    }


}
