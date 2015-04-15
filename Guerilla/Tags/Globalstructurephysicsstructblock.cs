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
        public  GlobalStructurePhysicsStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 52, Alignment = 4)]
    public class GlobalStructurePhysicsStructBlockBase  : IGuerilla
    {
        internal byte[] moppCode;
        internal byte[] invalidName_;
        internal OpenTK.Vector3 moppBoundsMin;
        internal OpenTK.Vector3 moppBoundsMax;
        internal byte[] breakableSurfacesMoppCode;
        internal BreakableSurfaceKeyTableBlock[] breakableSurfaceKeyTable;
        internal  GlobalStructurePhysicsStructBlockBase(BinaryReader binaryReader)
        {
            moppCode = Guerilla.ReadData(binaryReader);
            invalidName_ = binaryReader.ReadBytes(4);
            moppBoundsMin = binaryReader.ReadVector3();
            moppBoundsMax = binaryReader.ReadVector3();
            breakableSurfacesMoppCode = Guerilla.ReadData(binaryReader);
            breakableSurfaceKeyTable = Guerilla.ReadBlockArray<BreakableSurfaceKeyTableBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteData(binaryWriter, moppCode, nextAddress);
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(moppBoundsMin);
                binaryWriter.Write(moppBoundsMax);
                nextAddress = Guerilla.WriteData(binaryWriter, breakableSurfacesMoppCode, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<BreakableSurfaceKeyTableBlock>(binaryWriter, breakableSurfaceKeyTable, nextAddress);
                return nextAddress;
            }
        }
    };
}
