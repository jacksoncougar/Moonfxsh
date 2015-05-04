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
    public partial class UserHintBlock : UserHintBlockBase
    {
        public UserHintBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 72, Alignment = 4)]
    public class UserHintBlockBase : GuerillaBlock
    {
        internal UserHintPointBlock[] pointGeometry;
        internal UserHintRayBlock[] rayGeometry;
        internal UserHintLineSegmentBlock[] lineSegmentGeometry;
        internal UserHintParallelogramBlock[] parallelogramGeometry;
        internal UserHintPolygonBlock[] polygonGeometry;
        internal UserHintJumpBlock[] jumpHints;
        internal UserHintClimbBlock[] climbHints;
        internal UserHintWellBlock[] wellHints;
        internal UserHintFlightBlock[] flightHints;

        public override int SerializedSize
        {
            get { return 72; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public UserHintBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<UserHintPointBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<UserHintRayBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<UserHintLineSegmentBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<UserHintParallelogramBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<UserHintPolygonBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<UserHintJumpBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<UserHintClimbBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<UserHintWellBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<UserHintFlightBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            pointGeometry = ReadBlockArrayData<UserHintPointBlock>(binaryReader, blamPointers.Dequeue());
            rayGeometry = ReadBlockArrayData<UserHintRayBlock>(binaryReader, blamPointers.Dequeue());
            lineSegmentGeometry = ReadBlockArrayData<UserHintLineSegmentBlock>(binaryReader, blamPointers.Dequeue());
            parallelogramGeometry = ReadBlockArrayData<UserHintParallelogramBlock>(binaryReader, blamPointers.Dequeue());
            polygonGeometry = ReadBlockArrayData<UserHintPolygonBlock>(binaryReader, blamPointers.Dequeue());
            jumpHints = ReadBlockArrayData<UserHintJumpBlock>(binaryReader, blamPointers.Dequeue());
            climbHints = ReadBlockArrayData<UserHintClimbBlock>(binaryReader, blamPointers.Dequeue());
            wellHints = ReadBlockArrayData<UserHintWellBlock>(binaryReader, blamPointers.Dequeue());
            flightHints = ReadBlockArrayData<UserHintFlightBlock>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<UserHintPointBlock>(binaryWriter, pointGeometry, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<UserHintRayBlock>(binaryWriter, rayGeometry, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<UserHintLineSegmentBlock>(binaryWriter, lineSegmentGeometry,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<UserHintParallelogramBlock>(binaryWriter, parallelogramGeometry,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<UserHintPolygonBlock>(binaryWriter, polygonGeometry, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<UserHintJumpBlock>(binaryWriter, jumpHints, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<UserHintClimbBlock>(binaryWriter, climbHints, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<UserHintWellBlock>(binaryWriter, wellHints, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<UserHintFlightBlock>(binaryWriter, flightHints, nextAddress);
                return nextAddress;
            }
        }
    };
}