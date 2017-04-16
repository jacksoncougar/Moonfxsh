using System;
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using Moonfish.Guerilla;

namespace Moonfish.Tags
{
    [GuerillaType(MoonfishFieldType.FieldTagReference)]
    [StructLayout(LayoutKind.Sequential, Size = 8)]
    public struct TagReference
    {
        public TagClass Class;
        public TagIdent Ident;

        public TagReference(TagClass tagClass, TagIdent tagID)
        {
            Class = tagClass;
            Ident = tagID;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}", Class, Ident);
        }

        public T Get<T>() where T : GuerillaBlock
        {
            throw new NotImplementedException();
        }

        public object Get()
        {
            throw new NotImplementedException();
        }

        public static explicit operator TagReference( GuerillaBlock block )
        {
            throw new NotImplementedException();
        }
    }
}