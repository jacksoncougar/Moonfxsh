using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Moonfish.Guerilla;

namespace Moonfish.Tags
{
    [GuerillaType(MoonfishFieldType.FieldTag)]
    [StructLayout(LayoutKind.Sequential, Size = 4)]
    public partial struct TagClass : IEquatable<TagClass>, IEquatable<string>
    {
        private static readonly Dictionary<TagClass, Type> classTypes;

        private readonly byte a;
        private readonly byte b;
        private readonly byte c;
        private readonly byte d;

        public TagClass(params byte[] bytes)
        {
            a = default(byte);
            b = default(byte);
            c = default(byte);
            d = default(byte);
            switch (bytes.Length)
            {
                case 4:
                    d = bytes[3];
                    goto case 3;
                case 3:
                    c = bytes[2];
                    goto case 2;
                case 2:
                    b = bytes[1];
                    goto case 1;
                case 1:
                    a = bytes[0];
                    break;
                case 0: // Check if there are no bytes passed
                    break;
                default: // The defualt case is now byte.Length > 4 so goto case 4 and truncate
                    goto case 4;
            }
        }

        public TagClass(int value) : this(BitConverter.GetBytes(value))
        {
        }

        public TagClass(string value)
        {
            this = (TagClass) value;
        }

        static TagClass()
        {
            Type[] types;
            var assembly = typeof (TagClass).Assembly;

            try
            {
                types = assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                types = e.Types.Where(t => t != null).ToArray();
            }

            classTypes = new Dictionary<TagClass, Type>(types.Length);

            foreach (var type in types.Where(x => x.IsDefined(typeof (TagClassAttribute), false)))
            {
                AddClassType(type);
            }
        }

        public static readonly TagClass Rsrc = (TagClass) "rsrc";
        public static readonly TagClass Blkf = (TagClass) "blkf";
        public static readonly TagClass Blkh = (TagClass) "blkh";

        private static void AddClassType(Type type)
        {
            var attribute =
                type.GetCustomAttributes(typeof (TagClassAttribute), false).FirstOrDefault() as TagClassAttribute;

            if (attribute != null)
            {
                classTypes.Add(attribute.TagClass, type);
            }
        }

        public static explicit operator TagClass(string str)
        {
            return new TagClass(Encoding.UTF8.GetBytes(new string(str.ToCharArray().Reverse().ToArray())));
        }

        public static explicit operator string(TagClass tagclass)
        {
            return tagclass.ToString();
        }

        public static explicit operator TagClass(int integer)
        {
            return new TagClass(integer);
        }

        public static explicit operator int(TagClass type)
        {
            return BitConverter.ToInt32(new[] {type.a, type.b, type.c, type.d}, 0);
        }

        public static bool operator ==(TagClass object1, TagClass object2)
        {
            return (int) object1 == (int) object2;
        }

        public static bool operator !=(TagClass object1, TagClass object2)
        {
            return (int) object1 != (int) object2;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is TagClass))
                return false;
            return this == (TagClass) obj;
        }

        public override int GetHashCode()
        {
            return (int) this;
        }

        public override string ToString()
        {
            if (a == 0xFF && b == 0xFF && c == 0xFF && d == 0xFF)
                return "null";
            return Encoding.UTF8.GetString(new[] {d, c, b, a});
        }

        bool IEquatable<TagClass>.Equals(TagClass other)
        {
            return this == other;
        }

        bool IEquatable<string>.Equals(string other)
        {
            return this == (TagClass) other;
        }

        /// <summary>Gets the System.Type of the corresponding GuerillaBlock class.</summary>
        /// <returns>the System.Type type</returns>
        public Type GetClassType()
        {
            var type = classTypes[this];

            return type;
        }

        public string ToTokenString()
        {
            var value = ToString();
            switch (value)
            {
                case "$#!+":
                    return "shit";
                case "/**/":
                    return "cmnt";
            }

            char[] chars = value.Where(char.IsLetterOrDigit).ToArray();
            return new string(chars);
        }

        public static readonly TagClass Null = new TagClass(0xFF, 0xFF, 0xFF, 0xFF);
        public static readonly TagClass Empty = new TagClass(0x00, 0x00, 0x00, 0x00);

        public static bool IsNullOrZero(TagClass @class)
        {
            return @class == Null || (int) @class == 0;
        }
    }
}