using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ScenarioMachineStructV3Block : ScenarioMachineStructV3BlockBase
    {
        public  ScenarioMachineStructV3Block(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12)]
    public class ScenarioMachineStructV3BlockBase
    {
        internal Flags flags;
        internal PathfindingObjectIndexListBlock[] pathfindingReferences;
        internal  ScenarioMachineStructV3BlockBase(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt32();
            this.pathfindingReferences = ReadPathfindingObjectIndexListBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
        internal  virtual PathfindingObjectIndexListBlock[] ReadPathfindingObjectIndexListBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PathfindingObjectIndexListBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PathfindingObjectIndexListBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PathfindingObjectIndexListBlock(binaryReader);
                }
            }
            return array;
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
