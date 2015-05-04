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
    public partial class EnvironmentObjectNodes : EnvironmentObjectNodesBase
    {
        public EnvironmentObjectNodes() : base()
        {
        }
    };

    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class EnvironmentObjectNodesBase : GuerillaBlock
    {
        internal short referenceFrameIndex;
        internal byte projectionAxis;
        internal ProjectionSign projectionSign;

        public override int SerializedSize
        {
            get { return 4; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public EnvironmentObjectNodesBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            referenceFrameIndex = binaryReader.ReadInt16();
            projectionAxis = binaryReader.ReadByte();
            projectionSign = (ProjectionSign) binaryReader.ReadByte();
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(referenceFrameIndex);
                binaryWriter.Write(projectionAxis);
                binaryWriter.Write((Byte) projectionSign);
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum ProjectionSign : byte
        {
            ProjectionSign = 1,
        };
    };
}