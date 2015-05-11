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
    public partial class ScenarioMachineStructV3Block : ScenarioMachineStructV3BlockBase
    {
        public ScenarioMachineStructV3Block() : base()
        {
        }
    };

    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class ScenarioMachineStructV3BlockBase : GuerillaBlock
    {
        internal Flags flags;
        internal PathfindingObjectIndexListBlock[] pathfindingReferences;

        public override int SerializedSize
        {
            get { return 12; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ScenarioMachineStructV3BlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            flags = (Flags) binaryReader.ReadInt32();
            blamPointers.Enqueue(ReadBlockArrayPointer<PathfindingObjectIndexListBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            pathfindingReferences = ReadBlockArrayData<PathfindingObjectIndexListBlock>(binaryReader,
                blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32) flags);
                nextAddress = Guerilla.WriteBlockArray<PathfindingObjectIndexListBlock>(binaryWriter,
                    pathfindingReferences, nextAddress);
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum Flags : int
        {
            DoesNotOperateAutomatically = 1,
            OneSided = 2,
            NeverAppearsLocked = 4,
            OpenedByMeleeAttack = 8,
            OneSidedForPlayer = 16,
            DoesNotCloseAutomatically = 32,
        };
    };
}