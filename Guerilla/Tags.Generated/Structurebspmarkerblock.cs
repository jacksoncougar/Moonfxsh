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
    public partial class StructureBspMarkerBlock : StructureBspMarkerBlockBase
    {
        public StructureBspMarkerBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 60, Alignment = 4)]
    public class StructureBspMarkerBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.String32 name;
        internal OpenTK.Quaternion rotation;
        internal OpenTK.Vector3 position;

        public override int SerializedSize
        {
            get { return 60; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public StructureBspMarkerBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            name = binaryReader.ReadString32();
            rotation = binaryReader.ReadQuaternion();
            position = binaryReader.ReadVector3();
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
                binaryWriter.Write(name);
                binaryWriter.Write(rotation);
                binaryWriter.Write(position);
                return nextAddress;
            }
        }
    };
}