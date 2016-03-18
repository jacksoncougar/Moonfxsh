using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Fasterflect;
using Moonfish.Guerilla;
using Moonfish.Tags;

namespace Moonfish.Cache
{
    public interface ICache:  IReadOnlyList<TagDatum>
    {
        TagDatum Add<T>( T item, string tagName ) where T : GuerillaBlock;
        bool Contains<T>( T item ) where T : GuerillaBlock;
        T Deserialize<T>( TagIdent ident ) where T: GuerillaBlock;
    };

    public class TagCache : MemoryStream , ICache
    {
        Dictionary<TagIdent, GuerillaBlock> items = new Dictionary<TagIdent, GuerillaBlock>();
        private List<TagDatum> tagDatums = new List<TagDatum>( );

        public TagDatum Add<T>( T item, string tagName ) where T : GuerillaBlock
        {
            var attribute = (TagClassAttribute)item.GetType().Attribute(typeof(TagClassAttribute)) ??
                            (TagClassAttribute)
                                item.GetType().BaseType?.GetCustomAttributes(typeof(TagClassAttribute)).FirstOrDefault();

            var tagDatum = new TagDatum
            {
                Class = attribute?.TagClass ?? TagClass.Empty,
                Identifier = new TagIdent( ( short ) Count, ( short ) ~Count ),
                Length = 0,
                Path = tagName,
                VirtualAddress = 0
            };
            tagDatums.Add( tagDatum );
            items[tagDatum.Identifier] = item;

            return tagDatum;
        }


        public bool Contains<T>( T item ) where T : GuerillaBlock
        {
            foreach ( var block in items.Values )
            {
                if ( block.Equals( item )) return true;
                foreach ( var child in block.Children(  ) )
                {
                    if ( child.Equals( block ) ) return true;
                }
            }
            return false;
        }

        public T Deserialize<T>( TagIdent ident ) where T : GuerillaBlock
        {
            return ( T ) items[ ident ];
        }

        public IEnumerator<TagDatum> GetEnumerator( )
        {
            return tagDatums.GetEnumerator( );
        }

        IEnumerator IEnumerable.GetEnumerator( )
        {
            return tagDatums.GetEnumerator();
        }

        public int Count
        {
            get { return tagDatums.Count; }
        }

        public TagDatum this[ int index ]
        {
            get { return tagDatums[ index ]; }
        }
    }
}