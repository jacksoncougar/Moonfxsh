using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("tdtl")]
    public  partial class LiquidBlock : LiquidBlockBase
    {
        public  LiquidBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 112)]
    public class LiquidBlockBase
    {
        internal byte[] invalidName_;
        internal Type type;
        internal Moonfish.Tags.StringID attachmentMarkerName;
        internal byte[] invalidName_0;
        internal float falloffDistanceFromCameraWorldUnits;
        internal float cutoffDistanceFromCameraWorldUnits;
        internal byte[] invalidName_1;
        internal LiquidArcBlock[] arcs;
        internal  LiquidBlockBase(BinaryReader binaryReader)
        {
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.type = (Type)binaryReader.ReadInt16();
            this.attachmentMarkerName = binaryReader.ReadStringID();
            this.invalidName_0 = binaryReader.ReadBytes(56);
            this.falloffDistanceFromCameraWorldUnits = binaryReader.ReadSingle();
            this.cutoffDistanceFromCameraWorldUnits = binaryReader.ReadSingle();
            this.invalidName_1 = binaryReader.ReadBytes(32);
            this.arcs = ReadLiquidArcBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
        }
        internal  virtual LiquidArcBlock[] ReadLiquidArcBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(LiquidArcBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new LiquidArcBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new LiquidArcBlock(binaryReader);
                }
            }
            return array;
        }
        internal enum Type : short
        
        {
            Standard = 0,
            WeaponToProjectile = 1,
            ProjectileFromWeapon = 2,
        };
    };
}
