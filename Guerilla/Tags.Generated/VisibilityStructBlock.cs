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
    public partial class VisibilityStructBlock : VisibilityStructBlockBase
    {
        public VisibilityStructBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 40, Alignment = 4)]
    public class VisibilityStructBlockBase : GuerillaBlock
    {
        internal short projectionCount;
        internal short clusterCount;
        internal short volumeCount;
        internal byte[] invalidName_;
        internal byte[] projections;
        internal byte[] visibilityClusters;
        internal byte[] clusterRemapTable;
        internal byte[] visibilityVolumes;
        public override int SerializedSize { get { return 40; } }
        public override int Alignment { get { return 4; } }
        public VisibilityStructBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            projectionCount = binaryReader.ReadInt16();
            clusterCount = binaryReader.ReadInt16();
            volumeCount = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            blamPointers.Enqueue(ReadBlockArrayPointer(binaryReader, 1));
            blamPointers.Enqueue(ReadBlockArrayPointer(binaryReader, 1));
            blamPointers.Enqueue(ReadBlockArrayPointer(binaryReader, 1));
            blamPointers.Enqueue(ReadBlockArrayPointer(binaryReader, 1));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            projections = ReadDataByteArray(binaryReader, blamPointers.Dequeue());
            visibilityClusters = ReadDataByteArray(binaryReader, blamPointers.Dequeue());
            clusterRemapTable = ReadDataByteArray(binaryReader, blamPointers.Dequeue());
            visibilityVolumes = ReadDataByteArray(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(projectionCount);
                binaryWriter.Write(clusterCount);
                binaryWriter.Write(volumeCount);
                binaryWriter.Write(invalidName_, 0, 2);
                nextAddress = Guerilla.WriteData(binaryWriter, projections, nextAddress);
                nextAddress = Guerilla.WriteData(binaryWriter, visibilityClusters, nextAddress);
                nextAddress = Guerilla.WriteData(binaryWriter, clusterRemapTable, nextAddress);
                nextAddress = Guerilla.WriteData(binaryWriter, visibilityVolumes, nextAddress);
                return nextAddress;
            }
        }
    };
}
