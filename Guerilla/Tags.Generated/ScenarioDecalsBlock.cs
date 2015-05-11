// ReSharper disable All

using Moonfish.Model;

using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioDecalsBlock : ScenarioDecalsBlockBase
    {
        public ScenarioDecalsBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class ScenarioDecalsBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.ShortBlockIndex1 decalType;
        internal byte yaw127127;
        internal byte pitch127127;
        internal OpenTK.Vector3 position;

        public override int SerializedSize
        {
            get { return 16; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ScenarioDecalsBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            decalType = binaryReader.ReadShortBlockIndex1();
            yaw127127 = binaryReader.ReadByte();
            pitch127127 = binaryReader.ReadByte();
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
                binaryWriter.Write(decalType);
                binaryWriter.Write(yaw127127);
                binaryWriter.Write(pitch127127);
                binaryWriter.Write(position);
                return nextAddress;
            }
        }
    };
}