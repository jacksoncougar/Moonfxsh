using Moonfish.Tags;

namespace Moonfish.Cache
{
    public struct TagClassHeirarchy
    {
        public readonly TagClass Root;
        public readonly TagClass Parent;
        public readonly TagClass Class;

        public TagClassHeirarchy(TagClass @class, TagClass parent, TagClass root)
        {
            Root = root;
            Parent = parent;
            Class = @class;
        }
    }
}