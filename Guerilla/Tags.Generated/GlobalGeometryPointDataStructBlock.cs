// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class GlobalGeometryPointDataStructBlock : GlobalGeometryPointDataStructBlockBase
    {
        public GlobalGeometryPointDataStructBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 32, Alignment = 4)]
    public class GlobalGeometryPointDataStructBlockBase : GuerillaBlock
    {
        internal GlobalGeometryRawPointBlock[] rawPoints;
        internal byte[] runtimePointData;
        internal GlobalGeometryRigidPointGroupBlock[] rigidPointGroups;
        internal GlobalGeometryPointDataIndexBlock[] vertexPointIndices;

        public override int SerializedSize
        {
            get { return 32; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public GlobalGeometryPointDataStructBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<GlobalGeometryRawPointBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer(binaryReader, 1));
            blamPointers.Enqueue(ReadBlockArrayPointer<GlobalGeometryRigidPointGroupBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<GlobalGeometryPointDataIndexBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            rawPoints = ReadBlockArrayData<GlobalGeometryRawPointBlock>(binaryReader, blamPointers.Dequeue());
            runtimePointData = ReadDataByteArray(binaryReader, blamPointers.Dequeue());
            rigidPointGroups = ReadBlockArrayData<GlobalGeometryRigidPointGroupBlock>(binaryReader,
                blamPointers.Dequeue());
            vertexPointIndices = ReadBlockArrayData<GlobalGeometryPointDataIndexBlock>(binaryReader,
                blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<GlobalGeometryRawPointBlock>(binaryWriter, rawPoints, nextAddress);
                nextAddress = Guerilla.WriteData(binaryWriter, runtimePointData, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GlobalGeometryRigidPointGroupBlock>(binaryWriter,
                    rigidPointGroups, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GlobalGeometryPointDataIndexBlock>(binaryWriter,
                    vertexPointIndices, nextAddress);
                return nextAddress;
            }
        }
    };
}