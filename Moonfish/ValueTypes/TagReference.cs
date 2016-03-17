using System.Runtime.InteropServices;
using JetBrains.Annotations;
using Moonfish.Guerilla;

namespace Moonfish.Tags
{
    [GuerillaType(MoonfishFieldType.FieldTagReference)]
    [StructLayout(LayoutKind.Sequential, Size = 8)]
    public struct TagReference
    {
        public readonly TagClass Class;
        public readonly TagIdent Ident;

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
            return Halo2.GetReferenceObject(this);
        }
        public object Get()
        {
            return Get<GuerillaBlock>();
        }

        public static explicit operator TagReference( GuerillaBlock block )
        {
            var cache = Halo2.ActiveMap;
            var datum = cache.Add( block, string.Empty );
            return  new TagReference(datum.Class, datum.Identifier);
        }
    }
}