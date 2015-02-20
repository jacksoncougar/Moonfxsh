using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class PathfindingHintsBlock : PathfindingHintsBlockBase
    {
        public  PathfindingHintsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20)]
    public class PathfindingHintsBlockBase
    {
        internal HintType hintType;
        internal short nextHintIndex;
        internal short hintData0;
        internal short hintData1;
        internal short hintData2;
        internal short hintData3;
        internal short hintData4;
        internal short hintData5;
        internal short hintData6;
        internal short hintData7;
        internal  PathfindingHintsBlockBase(BinaryReader binaryReader)
        {
            this.hintType = (HintType)binaryReader.ReadInt16();
            this.nextHintIndex = binaryReader.ReadInt16();
            this.hintData0 = binaryReader.ReadInt16();
            this.hintData1 = binaryReader.ReadInt16();
            this.hintData2 = binaryReader.ReadInt16();
            this.hintData3 = binaryReader.ReadInt16();
            this.hintData4 = binaryReader.ReadInt16();
            this.hintData5 = binaryReader.ReadInt16();
            this.hintData6 = binaryReader.ReadInt16();
            this.hintData7 = binaryReader.ReadInt16();
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
        internal enum HintType : short
        
        {
            IntersectionLink = 0,
            JumpLink = 1,
            ClimbLink = 2,
            VaultLink = 3,
            MountLink = 4,
            HoistLink = 5,
            WallJumpLink = 6,
            BreakableFloor = 7,
        };
    };
}
