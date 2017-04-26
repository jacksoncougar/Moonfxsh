using System;
using JetBrains.Annotations;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;

namespace Moonfish.Guerilla
{
    [AttributeUsage(AttributeTargets.Field)]
    public class LayoutAttribute : Attribute
    {
        private int pack = Alignment.Default;

        /// <summary>
        /// Controls the alignment of reference fields in memory.
        /// </summary>
        /// <value>
        /// The byte alignment
        /// </value>
        /// <remarks>By default, the value is 4 (the default packing size in Blam!). 
        /// The value of Pack must be 0, 1, 2, 4, 8, 16, 32, 64, or 128:</remarks>
        public int Pack
        {
            get { return pack; }
            set { pack = value; }
        }

        public LayoutAttribute()
        {
            Pack = pack;
        }
    }
}