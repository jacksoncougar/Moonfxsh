using System.IO;
using System.Linq;
using Moonfish.Guerilla.Tags;

namespace Moonfish.Guerilla
{
    public static class GeometryExtensions
    {
        public static GlobalGeometrySectionStructBlock LoadSectionData(this GlobalGeometryBlockInfoStructBlock geometryInfo)
        {
            var resourceStream = Halo2.GetResourceBlock(geometryInfo);
            if (resourceStream == null) return default(GlobalGeometrySectionStructBlock);

            var sectionBlock = new GlobalGeometrySectionStructBlock();
            using (var binaryReader = new BinaryReader(resourceStream))
            {
                sectionBlock.Read(binaryReader);

                var vertexBufferResources = geometryInfo.Resources.Where(
                    x => x.Type == GlobalGeometryBlockResourceBlock.TypeEnum.VertexBuffer).ToArray();
                for (var i = 0;
                    i < sectionBlock.VertexBuffers.Length && i < vertexBufferResources.Length;
                    ++i)
                {
                    sectionBlock.VertexBuffers[i].VertexBuffer.Data =
                        resourceStream.GetResourceData(vertexBufferResources[i]);
                }
            }
            return sectionBlock;
        }
    }
}