using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;

namespace Moonfish
{
    partial class CacheStream
    {
        public void SaveTo(Stream outputStream)
        {
            StaticBenchmark.Begin();
            //  bring all the tags into the cache
            foreach (var tagData in Index)
            {
                Deserialize(tagData.Identifier);
            }

            //  reserve 2048 bytes for the header
            //  the header is already there so ignore this and move to offset 2048

            Seek(2048, SeekOrigin.Begin);
            outputStream.Seek(2048, SeekOrigin.Begin);

            //  process the sound resources

            CopySoundResources(outputStream);

            //  process the model resources 

            CopyModelResources(outputStream);

            //  process ltmp & sbsp resources

            CopyStructureResources(outputStream);
            StaticBenchmark.Sample();
            StaticBenchmark.Clear();
        }

        private void CopyStructureResources(Stream outputStream)
        {
            var scnrBlock = (ScenarioBlock)Deserialize(Index.ScenarioIdent);
            foreach (var scenarioStructureBspReferenceBlock in scnrBlock.StructureBSPs)
            {
                var sbspReference = scenarioStructureBspReferenceBlock.StructureBSP;
                var ltmpReference = scenarioStructureBspReferenceBlock.StructureLightmap;

                var sbspBlock = (ScenarioStructureBspBlock)Deserialize(sbspReference.Ident);
                foreach (var structureBspClusterBlock in sbspBlock.Clusters)
                {
                    CopyResource(outputStream, structureBspClusterBlock);
                }
                foreach (var structureBspInstancedGeometryDefinitionBlock in sbspBlock.InstancedGeometriesDefinitions)
                {
                    CopyResource(outputStream, structureBspInstancedGeometryDefinitionBlock.RenderInfo);
                }
                if (!TagIdent.IsNull(ltmpReference.Ident))
                {
                    var ltmpBlock = (ScenarioStructureLightmapBlock) Deserialize(ltmpReference.Ident);
                    foreach (var result in ltmpBlock.LightmapGroups.SelectMany(x=>x.GeometryBuckets))
                    {
                        CopyResource(outputStream, result);
                    }
                }
                foreach (var result in sbspBlock.Decorators0.SelectMany(x => x.CacheBlocks))
                {
                    CopyResource(outputStream, result);
                }
                foreach (var globalWaterDefinitionsBlock in sbspBlock.WaterDefinitions)
                {
                    CopyResource(outputStream, globalWaterDefinitionsBlock);
                }
            }
        }

        private void CopyModelResources(Stream outputStream)
        {
            foreach (
                var renderModelBlock in
                    Index.Where(x => x.Class == TagClass.Mode)
                        .Select(tagData => (RenderModelBlock) Deserialize(tagData.Identifier)))
            {
                foreach (var renderModelSectionBlock in renderModelBlock.Sections)
                {
                    CopyResource(outputStream, renderModelSectionBlock);
                }
                foreach (var prtInfoBlock in renderModelBlock.PRTInfo)
                {
                    CopyResource(outputStream, prtInfoBlock);
                }
            }
        }

        private void CopySoundResources(Stream outputStream)
        {
            
            var ughData = Index.First(x => x.Class == TagClass.Ugh);
            var ughBlock = (SoundCacheFileGestaltBlock) Deserialize(ughData.Identifier);
            foreach (var soundPermutationChunkBlock in ughBlock.Chunks)
            {
                CopyResource(outputStream, soundPermutationChunkBlock);
            }
        }

        private void CopyResource(Stream outputStream, IResourceBlock resourceBlock)
        {
            var address = resourceBlock.GetResourcePointer();
            var length = resourceBlock.GetResourceLength();
            if (address.Source == Halo2.ResourceSource.Local)
            {
                //  the resource has already been copied
                if (address < GetFilePosition()) return;

                if(address % 512 != 0)
                {

                }
                if (address > GetFilePosition() )
                {
                }
                var size = Padding.Pad(length, 512);
                this.BufferedCopyBytesTo(size, outputStream);
            }
        }
    }
}
