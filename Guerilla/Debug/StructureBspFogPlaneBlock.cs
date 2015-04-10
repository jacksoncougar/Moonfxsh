// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class StructureBspFogPlaneBlock : StructureBspFogPlaneBlockBase
    {
        public  StructureBspFogPlaneBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 24)]
    public class StructureBspFogPlaneBlockBase
    {
        internal short scenarioPlanarFogIndex;
        internal byte[] invalidName_;
        internal OpenTK.Vector4 plane;
        internal Flags flags;
        internal short priority;
        internal  StructureBspFogPlaneBlockBase(System.IO.BinaryReader binaryReader)
        {
            scenarioPlanarFogIndex = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            plane = binaryReader.ReadVector4();
            flags = (Flags)binaryReader.ReadInt16();
            priority = binaryReader.ReadInt16();
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(scenarioPlanarFogIndex);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(plane);
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(priority);
            }
        }
        [FlagsAttribute]
        internal enum Flags : short
        
        {
            ExtendInfinitelyWhileVisible = 1,
            DoNotFloodfill = 2,
            AggressiveFloodfill = 4,
        };
    };
}
