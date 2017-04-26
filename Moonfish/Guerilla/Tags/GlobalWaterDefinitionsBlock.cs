using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class GlobalWaterDefinitionsBlock : IResourceBlock<WaterGeometrySectionBlock>, IResourceDescriptor<GlobalGeometryBlockResourceBlock>
    {
        public ResourcePointer GetResourcePointer(int index = 0)
        {
            return GeometryBlockInfo.BlockOffset;
        }

        public int GetResourceLength(int index = 0)
        {
            return GeometryBlockInfo.BlockSize;
        }

        public void SetResourcePointer(ResourcePointer pointer, int index = 0)
        {
            GeometryBlockInfo.BlockOffset = pointer;
        }

        public void SetResourceLength(int length, int index = 0)
        {
            GeometryBlockInfo.BlockSize = length;
        }

        /// <summary>Returns the resource object contained by this block if it is loaded.</summary>
        /// <param name="index">resource index</param>
        /// <returns></returns>
        WaterGeometrySectionBlock IResourceBlock<WaterGeometrySectionBlock>.GetResource(int index)
        {
            return Section[index];
        }

        /// <summary>Loads this resource block from the given delegate return value.</summary>
        /// <remarks>
        ///     Internally the implementation will call the delegate passing itself and the
        ///     resource index as arguments. When the delegate returns it is expected to
        ///     contain a stream containing the resource data at the given index.
        /// </remarks>
        /// <param name="delegate"></param>
        /// <param name="index"></param>
        void IResourceBlock<WaterGeometrySectionBlock>.ReadResource(Func<IResourceBlock, int, Stream> @delegate,
            int index)
        {
            Section = new[]
            {
                ResourceLinker.ReadResource<GlobalWaterDefinitionsBlock, WaterGeometrySectionBlock>(this, @delegate,
                    GeometryBlockInfo)
            };
        }

        /// <summary>
        /// Writes the resource to the given stream.
        /// </summary>
        /// <param name="output">The stream to write the resource to.</param>
        /// <param name="index"></param>
        void IResourceBlock<WaterGeometrySectionBlock>.WriteResource(Stream output, int index)
        {
            ResourceLinker.WriteResource(this, output);
        }

        /// <summary>
        /// Gets the resource descriptors.
        /// </summary>
        /// <returns>Returns an array of <see cref="T"/> resource descriptors.</returns>
        GlobalGeometryBlockResourceBlock[] IResourceDescriptor<GlobalGeometryBlockResourceBlock>.GetDescriptors()
        {
            return GeometryBlockInfo.Resources;
        }

        /// <summary>
        /// Sets the resource descriptors.
        /// </summary>
        /// <param name="descriptors">The objects to set as the resource descriptors.</param>
        void IResourceDescriptor<GlobalGeometryBlockResourceBlock>.SetDescriptors(GlobalGeometryBlockResourceBlock[] descriptors)
        {
            GeometryBlockInfo.Resources = descriptors;
        }
    }
}
