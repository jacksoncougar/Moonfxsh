// ReSharper disable All
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
        public  LiquidBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  LiquidBlockBase(System.IO.BinaryReader binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(2);
            type = (Type)binaryReader.ReadInt16();
            attachmentMarkerName = binaryReader.ReadStringID();
            invalidName_0 = binaryReader.ReadBytes(56);
            falloffDistanceFromCameraWorldUnits = binaryReader.ReadSingle();
            cutoffDistanceFromCameraWorldUnits = binaryReader.ReadSingle();
            invalidName_1 = binaryReader.ReadBytes(32);
            ReadLiquidArcBlockArray(binaryReader);
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
        internal  virtual LiquidArcBlock[] ReadLiquidArcBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(LiquidArcBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new LiquidArcBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new LiquidArcBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteLiquidArcBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write((Int16)type);
                binaryWriter.Write(attachmentMarkerName);
                binaryWriter.Write(invalidName_0, 0, 56);
                binaryWriter.Write(falloffDistanceFromCameraWorldUnits);
                binaryWriter.Write(cutoffDistanceFromCameraWorldUnits);
                binaryWriter.Write(invalidName_1, 0, 32);
                WriteLiquidArcBlockArray(binaryWriter);
            }
        }
        internal enum Type : short
        
        {
            Standard = 0,
            WeaponToProjectile = 1,
            ProjectileFromWeapon = 2,
        };
    };
}
