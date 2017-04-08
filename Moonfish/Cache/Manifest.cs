using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Cache
{
    /// <summary>
    /// Allows corresepoinding data to be dereferenced from internal reference values (e.g StringIdents, TagIdents, and other reference types).
    /// </summary> 
    public abstract class Manifest<T, P>
    {
        private List<IDictionary<T, P>> tables;

        protected Manifest(int count)
        {
            tables = new List<IDictionary<T, P>>();
        }
        public virtual List<Conflict> AddTable(
        Dictionary<T,P> table)
        {
            var invalidKeys = new List<Conflict>();

            foreach(var item in tables)
            {
                foreach(var key in item.Keys)
                {
                    var conflicts = FindConflictingKeys(table, item);
                    invalidKeys.AddRange(conflicts);
                }
            }
            tables.Add(table);

            return invalidKeys;
        }

        private List<Conflict> FindConflictingKeys(Dictionary<T, P> table, IDictionary<T, P> item)
        {
            var duplicatedKeys = item.Keys.Where(x => table.ContainsKey(x));
            List<Conflict> conflicts = new List<Conflict>(duplicatedKeys.Count());
            foreach (var conflictingKey in duplicatedKeys)
            {
                conflicts.Add(new Conflict(conflictingKey, CreateKey()));
            }

            return conflicts;
        }

        protected abstract T CreateKey();
        public bool Contains(T key)
        {
            bool contained = false;

            foreach(var item in tables)
            {
                if(item.ContainsKey(key))
                {
                    contained = true;
                    break;
                }
            }

            return contained;
        }
        public P this[T key]
        { 
            get
            {
                P item = default(P); // make compiler happy...
                bool found = false;

                foreach(var table in tables)
                {
                    if(table.TryGetValue(key, out item))
                    {
                        found = true;
                        break;
                    }
                }
                if(!found) throw new KeyNotFoundException();

                return item;
            }
        }

        public class Conflict
        {
            public readonly T Original;
            public readonly T Replacement;

            public Conflict(T original, T replacement)
            {
                Original = original;
                Replacement = replacement;
            }
        }
    };
}