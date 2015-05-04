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
    public partial class RenderModelMarkerBlock : RenderModelMarkerBlockBase
    {
        public RenderModelMarkerBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 36, Alignment = 4)]
    public class RenderModelMarkerBlockBase : GuerillaBlock
    {
        internal byte regionIndex;
        internal byte permutationIndex;
        internal byte nodeIndex;
        internal byte[] invalidName_;
        internal OpenTK.Vector3 translation;
        internal OpenTK.Quaternion rotation;
        internal float scale;

        public override int SerializedSize
        {
            get { return 36; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public RenderModelMarkerBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            regionIndex = binaryReader.ReadByte();
            permutationIndex = binaryReader.ReadByte();
            nodeIndex = binaryReader.ReadByte();
            invalidName_ = binaryReader.ReadBytes(1);
            translation = binaryReader.ReadVector3();
            rotation = binaryReader.ReadQuaternion();
            scale = binaryReader.ReadSingle();
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
                binaryWriter.Write(regionIndex);
                binaryWriter.Write(permutationIndex);
                binaryWriter.Write(nodeIndex);
                binaryWriter.Write(invalidName_, 0, 1);
                binaryWriter.Write(translation);
                binaryWriter.Write(rotation);
                binaryWriter.Write(scale);
                return nextAddress;
            }
        }
    };
}