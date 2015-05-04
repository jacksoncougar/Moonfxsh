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
    public partial class StaticSpawnZoneBlock : StaticSpawnZoneBlockBase
    {
        public StaticSpawnZoneBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 48, Alignment = 4)]
    public class StaticSpawnZoneBlockBase : GuerillaBlock
    {
        internal StaticSpawnZoneDataStructBlock data;
        internal OpenTK.Vector3 position;
        internal float lowerHeight;
        internal float upperHeight;
        internal float innerRadius;
        internal float outerRadius;
        internal float weight;
        public override int SerializedSize { get { return 48; } }
        public override int Alignment { get { return 4; } }
        public StaticSpawnZoneBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            data = new StaticSpawnZoneDataStructBlock();
            blamPointers.Concat(data.ReadFields(binaryReader));
            position = binaryReader.ReadVector3();
            lowerHeight = binaryReader.ReadSingle();
            upperHeight = binaryReader.ReadSingle();
            innerRadius = binaryReader.ReadSingle();
            outerRadius = binaryReader.ReadSingle();
            weight = binaryReader.ReadSingle();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            data.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                data.Write(binaryWriter);
                binaryWriter.Write(position);
                binaryWriter.Write(lowerHeight);
                binaryWriter.Write(upperHeight);
                binaryWriter.Write(innerRadius);
                binaryWriter.Write(outerRadius);
                binaryWriter.Write(weight);
                return nextAddress;
            }
        }
    };
}
