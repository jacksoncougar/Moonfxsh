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
        public  StructureBspFogPlaneBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class StructureBspFogPlaneBlockBase  : IGuerilla
    {
        internal short scenarioPlanarFogIndex;
        internal byte[] invalidName_;
        internal OpenTK.Vector4 plane;
        internal Flags flags;
        internal short priority;
        internal  StructureBspFogPlaneBlockBase(BinaryReader binaryReader)
        {
            scenarioPlanarFogIndex = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            plane = binaryReader.ReadVector4();
            flags = (Flags)binaryReader.ReadInt16();
            priority = binaryReader.ReadInt16();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(scenarioPlanarFogIndex);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(plane);
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(priority);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
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
