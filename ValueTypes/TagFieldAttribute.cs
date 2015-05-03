using System;

namespace Moonfish.Tags
{
    [AttributeUsage( AttributeTargets.All )]
    public class TagFieldAttribute : Attribute
    {
        public bool usesCustomFunction = false;
        public int offset;

        public bool UsesFieldOffset
        {
            get { return offset != -1; }
        }

        public TagFieldAttribute( ) : this( -1 )
        {
        }

        public TagFieldAttribute( int fieldOffset )
        {
            offset = fieldOffset;
        }
    }
}