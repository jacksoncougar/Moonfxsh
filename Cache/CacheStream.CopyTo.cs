using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Moonfish.Guerilla;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;

namespace Moonfish.Cache
{
    partial class CacheStream
    {
        private static readonly Dictionary<ResourcePointer, ResourcePointer> ShiftData =
            new Dictionary<ResourcePointer, ResourcePointer>(1000);

        public void SaveTo(Stream outputStream)
        {
            StaticBenchmark.Begin();

            //  bring all the tags into the cache

            foreach (var tagData in Index)
            {
                Deserialize(tagData.Identifier);
            }

            //  reserve 2048 bytes for the header

            Seek(2048, SeekOrigin.Begin);
            outputStream.Seek(2048, SeekOrigin.Begin);

            //  process sound resources

            CopySoundResources(outputStream);

            //  process model resources 

            CopyModelResources(outputStream);

            //  process ltmp & sbsp resources

            CopyStructureResources(outputStream);

            //  process DECR resources

            CopyDecoratorResources(outputStream);

            //  process PRTM resources

            CopyParticleModelResources(outputStream);

            //  process Lipsync resources

            CopyLipsyncResources(outputStream);

            //  process animation resources

            CopyAnimationResources(outputStream);

            //  process sbsp & ltmp meta

            //CopyStructureMeta(outputStream);

            //  process string128 table

            //  process stringID index & table

            //  process path table & index

            //  process unicode index & table

            //  process 'crazy' data

            //  process bitmap resources

            //  process index

            //  process meta table


            StaticBenchmark.Sample();
            StaticBenchmark.Clear();
        }

        private void CopyStructureMeta(Stream outputStream)
        {
            var scnrBlock = (ScenarioBlock)Deserialize(Index.ScenarioIdent);
            foreach (var scenarioStructureBspReferenceBlock in scnrBlock.StructureBSPs)
            {
                var virtualMemoryStream = new VirtualStream(-2146516992);

                var sbspReference = scenarioStructureBspReferenceBlock.StructureBSP;
                var ltmpReference = scenarioStructureBspReferenceBlock.StructureLightmap;

                //  only copy valid references
                
                if (TagIdent.IsNull(sbspReference.Ident)) continue;
                var sbspBlock = (ScenarioStructureBspBlock)Deserialize(sbspReference.Ident);
                virtualMemoryStream.Write(sbspBlock);

                //  only copy valid references

                if (TagIdent.IsNull(ltmpReference.Ident)) continue;
                var ltmpBlock = (ScenarioStructureLightmapBlock)Deserialize(ltmpReference.Ident);
                virtualMemoryStream.Write(ltmpBlock);

                virtualMemoryStream.BufferedCopyBytesTo((int) virtualMemoryStream.Length, outputStream);
            }
        }

        private void CopyAnimationResources(Stream outputStream)
        {
            foreach (var moonfishXboxAnimationRawBlock in Index.Where(x => x.Class == TagClass.Jmad)
                .Select(x => (ModelAnimationGraphBlock) Deserialize(x.Identifier))
                .SelectMany(jmadBlock => jmadBlock.XboxAnimationDataBlock))
            {
                CopyResource(outputStream, moonfishXboxAnimationRawBlock);
            }
        }

        private void CopyLipsyncResources(Stream outputStream)
        {
            var ughData = Index.First(x => x.Class == TagClass.Ugh);
            var ughBlock = (SoundCacheFileGestaltBlock)Deserialize(ughData.Identifier);
            foreach (var soundGestaltExtraInfoBlock in ughBlock.ExtraInfos)
            {
                CopyResource(outputStream, soundGestaltExtraInfoBlock);
            }
        }

        private void CopyParticleModelResources(Stream outputStream)
        {
            foreach (var prtmBlock  in Index.Where(x => x.Class == TagClass.PRTM)
                .Select(x => (ParticleModelBlock) Deserialize(x.Identifier)))
            {
                CopyResource(outputStream, prtmBlock);
            }
        }

        private void CopyDecoratorResources(Stream outputStream)
        {
            foreach (var decrBlock  in Index.Where(x => x.Class == TagClass.DECR)
                .Select(x => (DecoratorSetBlock)Deserialize(x.Identifier)))
            {
                CopyResource(outputStream, decrBlock);
            }
        }

        private void CopyStructureResources(Stream outputStream)
        {
            var scnrBlock = (ScenarioBlock) Deserialize(Index.ScenarioIdent);
            foreach (var scenarioStructureBspReferenceBlock in scnrBlock.StructureBSPs)
            {
                var sbspReference = scenarioStructureBspReferenceBlock.StructureBSP;
                var ltmpReference = scenarioStructureBspReferenceBlock.StructureLightmap;

                var sbspBlock = (ScenarioStructureBspBlock) Deserialize(sbspReference.Ident);
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
                    foreach (var result in ltmpBlock.LightmapGroups.SelectMany(x => x.GeometryBuckets))
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
            switch (address.Source)
            {
                case Halo2.ResourceSource.Local:
                    CopyLocalResource(outputStream, resourceBlock, address, length);
                    break;
                case Halo2.ResourceSource.Tag:
                    throw new NotImplementedException();
                    break;
                default:
                    //  we don't need to do anything with external resources
                    return;
            }
        }

        private void CopyLocalResource(Stream outputStream, IResourceBlock resourceBlock, ResourcePointer address,
            int length)
        {
            //  the resource has already been copied
            if (address < GetFilePosition())
            {
                //  if this is true then we've already handled this resource so use the 
                //  new address
                ResourcePointer newAddress;
                if (ShiftData.TryGetValue(address, out newAddress))
                {
                    resourceBlock.SetResourcePointer(newAddress);
                    return;
                }
                //  has the resource already been copied? Has it been moved?
                //  well, shit.
                throw new InvalidDataException();
            }
            //  this is not strictly an error but it should be treated as such
            if (address > GetFilePosition())
            {
                Debug.WriteLineIf(address > GetFilePosition(), "Warning: address > GetFilePosition()");
                this.Seek(address);
            }
            Debug.WriteLineIf(address%512 != 0, "Warning: address % 512 != 0");

            var position = outputStream.Position;
            ShiftData[address] = (int) position;
            resourceBlock.SetResourcePointer((int) position);

            var size = Padding.Pad(length, 512);
            this.BufferedCopyBytesTo(size, outputStream);
        }
    }
}