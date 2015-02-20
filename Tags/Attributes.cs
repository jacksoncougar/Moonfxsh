using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moonfish.Tags
{
    public class LayoutAttribute : Attribute
    {
        public int Size;
        public int Alignment;
        public int MaxElements;
    }

    [AttributeUsage(AttributeTargets.Class,
        AllowMultiple = false, Inherited = false)]
    public class TagClassAttribute : System.Attribute
    {
        public TagClass TagClass { get; set; }
        public TagClassAttribute(string tagClass)
        {
            TagClass = (TagClass)tagClass;
        }
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class TagBlockFieldAttribute : TagFieldAttribute
    {
        public TagBlockFieldAttribute(int fieldOffset) : base(fieldOffset) { }
   
        public TagBlockFieldAttribute() { }
    }
    
    [AttributeUsage(AttributeTargets.Field)]
    public class TagStructFieldAttribute : TagFieldAttribute
    {
        public TagStructFieldAttribute() { }
    }

    [AttributeUsage(AttributeTargets.All)]
    public class TagFieldAttribute : Attribute
    {
        public bool UsesCustomFunction = false;
        public int Offset;
        public bool UsesFieldOffset { get { return Offset != -1; } }

        public TagFieldAttribute() : this(-1) { }
        public TagFieldAttribute(int fieldOffset) 
        {
            this.Offset = fieldOffset;
        }
    }


}
