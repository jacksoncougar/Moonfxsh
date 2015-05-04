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
    public partial class GrenadeAndPowerupStructBlock : GrenadeAndPowerupStructBlockBase
    {
        public GrenadeAndPowerupStructBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class GrenadeAndPowerupStructBlockBase : GuerillaBlock
    {
        internal GrenadeBlock[] grenades;
        internal PowerupBlock[] powerups;
        public override int SerializedSize { get { return 16; } }
        public override int Alignment { get { return 4; } }
        public GrenadeAndPowerupStructBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<GrenadeBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<PowerupBlock>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            grenades = ReadBlockArrayData<GrenadeBlock>(binaryReader, blamPointers.Dequeue());
            powerups = ReadBlockArrayData<PowerupBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<GrenadeBlock>(binaryWriter, grenades, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<PowerupBlock>(binaryWriter, powerups, nextAddress);
                return nextAddress;
            }
        }
    };
}
