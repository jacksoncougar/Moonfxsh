using System;

namespace Moonfish.Tags
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class TagClassAttribute : System.Attribute
    {
        public TagClass TagClass { get; set; }

        public TagClassAttribute(string tagClass)
        {
            TagClass = (TagClass)tagClass;
        }
    }

    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class TagBlockOriginalNameAttribute : System.Attribute
    {
        public string OriginalName { get; set; }

        public TagBlockOriginalNameAttribute(string originalName)
        {
            OriginalName = originalName;
        }
    }
}