using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioStructureBspBlock : IResourceContainer<StructureBspClusterDataBlockNew>
    {
        IEnumerator<IResourceBlock<StructureBspClusterDataBlockNew>> IEnumerable<IResourceBlock<StructureBspClusterDataBlockNew>>.GetEnumerator()
        {
            return Clusters.Cast<IResourceBlock<StructureBspClusterDataBlockNew>>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return Clusters.GetEnumerator();
        }
    }
}