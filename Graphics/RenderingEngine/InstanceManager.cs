using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moonfish.Guerilla;
using Moonfish.Guerilla.Tags;
using OpenTK;

namespace Moonfish.Graphics.RenderingEngine
{
    
    public class InstanceManager 
    {
        private static readonly Comparer<float> Comparer = Comparer<float>.Create((a, b) => a <= b ? 1 : -1);

        private readonly Dictionary<InstanceKey, InstanceData> InstanceData =
            new Dictionary<InstanceKey, InstanceData>();

        private readonly Dictionary<GuerillaBlock, InstanceKey> InstanceKeys =
            new Dictionary<GuerillaBlock, InstanceKey>();

        private readonly Dictionary<GlobalGeometryPartBlockNew, HashSet<InstanceKey>> PartInstances =
            new Dictionary<GlobalGeometryPartBlockNew, HashSet<InstanceKey>>();

        private InstanceKey _currentInstanceKey;

        public ICollection<GlobalGeometryPartBlockNew> Parts
        {
            get { return PartInstances.Keys; }
        }

        public int GetInstanceCount( GlobalGeometryPartBlockNew part )
        {
            return PartInstances[ part ].Count;
        }

        public IEnumerable<InstanceData> GetInstancesOf( GlobalGeometryPartBlockNew part )
        {
            foreach ( var instanceData in PartInstances[ part ].Select( u => InstanceData[ u ] ) )
            {
                yield return instanceData;
            }
        }

        /// <summary>
        ///     Creates an instance object for the given part
        /// </summary>
        /// <param name="part">The part to be instanced</param>
        /// <param name="instance">The instance data</param>
        /// <remarks>
        /// i.   Every part many be instanced zero or many times
        /// ii.  Instances should refer to a collection of parts
        /// iii. Instance data is linked to a single instance
        /// </remarks>
        public void CreateInstance(GlobalGeometryPartBlockNew part, dynamic instance)
        {
            // 1. Check if the part is already in dictionary and initialize it into the dictionary if not 
            if (!PartInstances.ContainsKey(part))
            {
                // Initialize a collection of instance identifiers
                PartInstances.Add(part, new HashSet<InstanceKey>());
            }

            // 2. Check to see if this instance has already been added
            InstanceKey key;
            if (!InstanceKeys.ContainsKey(instance))
            {
                // (a) Create a key for the new instance and (b) link the key with the instance
                key = CreateInstanceKey( );
                InstanceKeys.Add(instance, key);
                // (c) Link the key with the intance data
                InstanceData.Add(key, new InstanceData(instance));
            }

            // 3. Check to see if the part is already linked with the instance
            key = InstanceKeys[instance];
            if (!PartInstances[part].Contains(key))
            {
                // Add this instance to the part's instances
                PartInstances[part].Add(key);
            }
        }

        public bool RemoveInstance( GlobalGeometryPartBlockNew part, dynamic instance )
        {
            if ( !PartInstances.ContainsKey( part ) ) return false;
            if ( !InstanceKeys.ContainsKey( instance ) ) return false;

            var key = InstanceKeys[ instance ];
            if(!PartInstances[part].Contains( key )) return false;
            PartInstances[ part ].Remove( key );
            return true;
        }

        private InstanceKey CreateInstanceKey()
        {
            return _currentInstanceKey++;
        }

        public struct InstanceKey
        {
            private int _id;

            public override int GetHashCode( )
            {
                return _id.GetHashCode( );
            }

            public static InstanceKey operator ++( InstanceKey instanceKey )
            {
                instanceKey._id++;
                return instanceKey;
            }
        };
    }
}
