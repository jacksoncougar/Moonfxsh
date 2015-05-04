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
    public partial class DeviceGroupBlock : DeviceGroupBlockBase
    {
        public DeviceGroupBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 40, Alignment = 4)]
    public class DeviceGroupBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.String32 name;
        internal float initialValue01;
        internal Flags flags;

        public override int SerializedSize
        {
            get { return 40; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public DeviceGroupBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            name = binaryReader.ReadString32();
            initialValue01 = binaryReader.ReadSingle();
            flags = (Flags) binaryReader.ReadInt32();
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
                binaryWriter.Write(initialValue01);
                binaryWriter.Write((Int32) flags);
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum Flags : int
        {
            CanChangeOnlyOnce = 1,
        };
    };
}