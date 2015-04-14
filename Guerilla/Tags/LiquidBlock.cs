// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass TdtlClass = (TagClass)"tdtl";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("tdtl")]
    public  partial class LiquidBlock : LiquidBlockBase
    {
        public  LiquidBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 112, Alignment = 4)]
    public class LiquidBlockBase  : IGuerilla
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
            invalidName_ = binaryReader.ReadBytes(2);
            type = (Type)binaryReader.ReadInt16();
            attachmentMarkerName = binaryReader.ReadStringID();
            invalidName_0 = binaryReader.ReadBytes(56);
            falloffDistanceFromCameraWorldUnits = binaryReader.ReadSingle();
            cutoffDistanceFromCameraWorldUnits = binaryReader.ReadSingle();
            invalidName_1 = binaryReader.ReadBytes(32);
            arcs = Guerilla.ReadBlockArray<LiquidArcBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
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
                nextAddress = Guerilla.WriteBlockArray<LiquidArcBlock>(binaryWriter, arcs, nextAddress);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
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
