using System;
using System.Diagnostics.CodeAnalysis;

namespace Moonfish.Tags
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class LayoutAttribute : Attribute
    {
        public int Size;
        public int Alignment;
        public int MaxElements;
    }
}