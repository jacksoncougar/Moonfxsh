using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moonfish;
using Moonfish.Guerilla;
using Moonfish.Guerilla.CodeDom;
using Moonfish.Guerilla.Tags;

namespace MoonfishUnitTests
{
    [TestClass]
    public class UnitTestQueueableBlamBinaryWriterTests
    {
        [TestMethod]
        public void TestCommit()
        {
            var map = GuerillaCodeDom.GetAllMaps().First();
            Assert.IsNotNull(map);
            foreach (var datum in map)
            {
                var block = map.Deserialize(datum.Identifier);
                var writer = new QueueableBlamBinaryWriter(new TestingStream());
                writer.Write(block);
            }
        }
    }

    [TestClass]
    public class UnitTestResourceWriterTests
    {
        [TestMethod]
        public void TestWritePreservesData()
        {
            var map = GuerillaCodeDom.GetAllMaps().First();
            Assert.IsNotNull(map);
            foreach (var datum in map)
            {
                var block = map.Deserialize(datum.Identifier) as IResourceContainer<object>;
                if (block == null)
                    continue;

                foreach (IResourceBlock<object> resourceBlock in block)
                {
                    MemoryStream input;
                    try
                    {
                        input = (MemoryStream) map.GetResourceData(resourceBlock, 0);
                    }
                    catch (Exception)
                    {
                        continue;
                    }

                    var output = new VirtualStream(0);
                    var old = (resourceBlock as IResourceDescriptor<GlobalGeometryBlockResourceBlock>)?.GetDescriptors();

                    resourceBlock.WriteResource(output, 0);

                    byte[] inputBytes = ((MemoryStream)input).ToArray();
                    byte[] outputBytes = output.ToArray();

                    if (!inputBytes.SequenceEqual(outputBytes))
                    {
                        File.WriteAllBytes(Path.Combine(Local.ProjectDirectory, "debug\\input.bin"), inputBytes);
                        File.WriteAllBytes(Path.Combine(Local.ProjectDirectory, "debug\\output.bin"), outputBytes);
                        throw new Exception();
                    }
                }
            }
        }
    }

    [TestClass]
    public class StreamAddressWrapperTests
    {
        [TestMethod]
        public void TestRemoveSingleRange()
        {
            StreamAddressWrapper<MemoryStream> wrapper = new VirtualStreamWrapper<MemoryStream>(new MemoryStream());
            BinaryReader reader = new BinaryReader(wrapper);

            byte[] removeBytes = Enumerable.Repeat((byte) 255, 17).ToArray();
            wrapper.Write(new byte[10], 0, 10);
            wrapper.Write(removeBytes, 0, removeBytes.Length);
            wrapper.Write(new byte[10], 0, 10);

            wrapper.RemoveAddresses(10, removeBytes.Length);

            wrapper.Position = 0;
            
        }

        [TestMethod]
        public void TestRemoveTwoRanges()
        {
            StreamAddressWrapper<MemoryStream> wrapper = new VirtualStreamWrapper<MemoryStream>(new MemoryStream());
            byte[] removeBytes = Enumerable.Repeat((byte)255, 17).ToArray();
            wrapper.Write(new byte[10], 0, 10);
            wrapper.Write(removeBytes, 0, removeBytes.Length);
            wrapper.Write(new byte[10], 0, 10);
            wrapper.Write(removeBytes, 0, removeBytes.Length);
            wrapper.Write(new byte[10], 0, 10);

            wrapper.RemoveAddresses(10, removeBytes.Length);
            wrapper.RemoveAddresses(20, removeBytes.Length);

            wrapper.Position = 0;

            byte[] peak = new byte[1];
            while (wrapper.Position < wrapper.Length)
            {
                wrapper.Read(peak, 0, 1);
                Assert.AreEqual(0, peak[0]);
            }
        }
    }
}
