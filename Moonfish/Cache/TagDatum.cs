using System;
using Moonfish.Tags;

namespace Moonfish
{
    public struct TagDatum
    {
        public TagClass Class;
        public TagIdent Identifier;
        public int VirtualAddress;
        public int Length;
        public string Path;

        public const int SizeInBytes = 16;

        public override bool Equals(object obj)
        {
            if (obj is TagDatum)
                return (TagDatum) (obj) == this;
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(TagDatum first, TagDatum second)
        {
            return first.Class == second.Class
                   && first.Identifier == second.Identifier
                   && first.Length == second.Length
                   && first.VirtualAddress == second.VirtualAddress
                   && first.Path == second.Path;
        }

        public static bool operator !=(TagDatum first, TagDatum second)
        {
            return !(first == second);
        }

        internal static bool IsNull(TagDatum data)
        {
            return
                TagClass.IsNullOrZero(data.Class) && data.Identifier == TagIdent.NullIdentifier && data.Length == 0 &&
                data.VirtualAddress == 0;
        }
    }
}