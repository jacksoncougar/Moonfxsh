using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GlobalStructurePhysicsStructBlock : GlobalStructurePhysicsStructBlockBase
    {
        public  GlobalStructurePhysicsStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 52)]
    public class GlobalStructurePhysicsStructBlockBase
    {
        internal byte[] moppCode;
        internal byte[] invalidName_;
        internal OpenTK.Vector3 moppBoundsMin;
        internal OpenTK.Vector3 moppBoundsMax;
        internal byte[] breakableSurfacesMoppCode;
        internal BreakableSurfaceKeyTableBlock[] breakableSurfaceKeyTable;
        internal  GlobalStructurePhysicsStructBlockBase(BinaryReader binaryReader)
        {
            this.moppCode = ReadData(binaryReader);
            this.invalidName_ = binaryReader.ReadBytes(4);
            this.moppBoundsMin = binaryReader.ReadVector3();
            this.moppBoundsMax = binaryReader.ReadVector3();
            this.breakableSurfacesMoppCode = ReadData(binaryReader);
            this.breakableSurfaceKeyTable = ReadBreakableSurfaceKeyTableBlockArray(binaryReader);
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
        internal  virtual BreakableSurfaceKeyTableBlock[] ReadBreakableSurfaceKeyTableBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(BreakableSurfaceKeyTableBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new BreakableSurfaceKeyTableBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new BreakableSurfaceKeyTableBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
