using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioStructureBspBlock : IResourceContainer<StructureBspClusterDataBlockNew>
    {
        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        IEnumerator<IResourceBlock<StructureBspClusterDataBlockNew>> IEnumerable<IResourceBlock<StructureBspClusterDataBlockNew>>.GetEnumerator()
        {
            foreach (var cluster in Clusters)
            {
                yield return cluster;
            }
            foreach (var instance in InstancedGeometriesDefinitions)
            {
                yield return instance.RenderInfo;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return Clusters.GetEnumerator();
        }
    }
}