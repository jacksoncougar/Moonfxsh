using System;

namespace Moonfish.Tags
{
    [AttributeUsage(AttributeTargets.Field)]
    public class TagBlockFieldAttribute : TagFieldAttribute
    {
        public TagBlockFieldAttribute(int fieldOffset) : base(fieldOffset)
        {
        }

        public TagBlockFieldAttribute()
        {
        }
    }
}