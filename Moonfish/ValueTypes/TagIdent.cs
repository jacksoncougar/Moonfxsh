using System;
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using Moonfish.Guerilla;

namespace Moonfish.Tags
{
    [StructLayout(LayoutKind.Sequential, Size = 4)]
    [GuerillaType(MoonfishFieldType.FieldMoonfishIdent)]
    public struct TagIdent : IEquatable<TagIdent>
    {
        private const short SaltConstant = -7820;

        public readonly short Index;
        public readonly short Salt;

        public short SaltedIndex => (short) (Salt - SaltConstant);

        public static bool IsNull(TagIdent value)
        {
            return value.Index == -1;
        }

        public TagIdent(short index = -1, short salt = -1)
        {
            Index = index;
            Salt = salt;
        }

        public T Get<T>(CacheKey key) where T : GuerillaBlock
        {
            return this.GetFromCache<T>(key );
        }

        public object Get(CacheKey key)
        {
            return this.GetFromCache(key);
        }

        public static explicit operator int(TagIdent item)
        {
            return (item.Salt << 16) | (ushort) item.Index;
        }

        public static explicit operator TagIdent(int i)
        {
            return new TagIdent((short) (i & 0x0000FFFF), (short) ((i & 0xFFFF0000) >> 16));
        }

        public static TagIdent operator ++(TagIdent object1)
        {
            return new TagIdent((short) (object1.Index + 1), (short) (object1.Salt + 1));
        }

        public static TagIdent operator --(TagIdent object1)
        {
            return new TagIdent((short) (object1.Index - 1), (short) (object1.Salt - 1));
        }

        public static bool operator ==(TagIdent object1, TagIdent object2)
        {
            return object1.Equals(object2);
        }

        public override bool Equals(object obj)
        {
            var other = obj as TagIdent?;
            return other != null && Equals(other.Value);
        }

        public override int GetHashCode()
        {
            return (int)this;
        }

        public static bool operator !=(TagIdent object1, TagIdent object2)
        {
            return !(object1 == object2);
        }

        public override string ToString()
        {
            return $@"{Index},{Salt}";
        }

        public static TagIdent NullIdentifier = (TagIdent) (-1);

        public bool Equals(TagIdent other)
        {
            return Index.Equals(other.Index) && Salt.Equals(other.Salt);
        }

        [Pure]
        public string GetPath( CacheKey key )
        {
            return Solution.Index[ key ][ Index ].Path;
        }
    }
}