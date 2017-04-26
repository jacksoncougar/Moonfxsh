using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioStructureBspBlock : IResourceContainer<StructureBspClusterDataBlockNew>, 
        IResourceContainer<WaterGeometrySectionBlock>, IResourceContainer<DecoratorCacheBlockDataBlock>, IResourceContainer<object>

    {
        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<IResourceBlock<object>> GetEnumerator()
        {
            return
                Clusters.Cast<IResourceBlock<object>>()
                    .Concat(InstancedGeometriesDefinitions.Select(item=>item.RenderInfo).Cast<IResourceBlock<object>>())
                    .Concat(WaterDefinitions.Cast<IResourceBlock<object>>())
                    .Concat(Decorators0.SelectMany(item=>item.CacheBlocks).Cast<IResourceBlock<object>>())
                    .GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        IEnumerator<IResourceBlock<DecoratorCacheBlockDataBlock>> IEnumerable<IResourceBlock<DecoratorCacheBlockDataBlock>>.GetEnumerator()
        {
            return Decorators0.SelectMany(item => item.CacheBlocks).GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        IEnumerator<IResourceBlock<WaterGeometrySectionBlock>> IEnumerable<IResourceBlock<WaterGeometrySectionBlock>>.GetEnumerator()
        {
            return WaterDefinitions.Cast<IResourceBlock<WaterGeometrySectionBlock>>().GetEnumerator();
        }

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
            yield return InstancedGeometriesDefinitions.GetEnumerator();
            yield return WaterDefinitions.GetEnumerator();
            yield return Decorators0.SelectMany(item => item.CacheBlocks).GetEnumerator();
        }
    }
}