using System;
using System.Runtime.InteropServices;
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

        public short SaltedIndex
        {
            get { return (short) (Salt - SaltConstant); }
        }

        public static bool IsNull(TagIdent value)
        {
            return value.Index == -1;
        }

        public TagIdent(short index)
            : this(index, (short) (SaltConstant + index))
        {
        }

        public TagIdent(short index, short salt)
        {
            Index = index;
            Salt = salt;
        }

        public T Get<T>() where T : GuerillaBlock
        {
            return Halo2.GetReferenceObject(this);
        }
        public object Get()
        {
            return Get<GuerillaBlock>();
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
            if (other == null) return false;
            return Equals(other.Value);
        }

        public override int GetHashCode()
        {
            return SaltedIndex;
        }

        public static bool operator !=(TagIdent object1, TagIdent object2)
        {
            return !(object1 == object2);
        }

        public override string ToString()
        {
            return string.Format(@"{0}:{1} - {2}", Index, Salt, Halo2.Paths[Index]);
        }

        public static TagIdent NullIdentifier = (TagIdent) (-1);

        public bool Equals(TagIdent other)
        {
            return Index.Equals(other.Index) && Salt.Equals(other.Salt);
        }
    }
}