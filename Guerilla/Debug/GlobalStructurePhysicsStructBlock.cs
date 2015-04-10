// ReSharper disable All
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
        public  GlobalStructurePhysicsStructBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  GlobalStructurePhysicsStructBlockBase(System.IO.BinaryReader binaryReader)
        {
            moppCode = ReadData(binaryReader);
            invalidName_ = binaryReader.ReadBytes(4);
            moppBoundsMin = binaryReader.ReadVector3();
            moppBoundsMax = binaryReader.ReadVector3();
            breakableSurfacesMoppCode = ReadData(binaryReader);
            ReadBreakableSurfaceKeyTableBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
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
        internal  virtual BreakableSurfaceKeyTableBlock[] ReadBreakableSurfaceKeyTableBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteBreakableSurfaceKeyTableBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                WriteData(binaryWriter);
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(moppBoundsMin);
                binaryWriter.Write(moppBoundsMax);
                WriteData(binaryWriter);
                WriteBreakableSurfaceKeyTableBlockArray(binaryWriter);
            }
        }
    };
}
