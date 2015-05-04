// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Tdtl = (TagClass)"tdtl";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("tdtl")]
    public partial class LiquidBlock : LiquidBlockBase
    {
        public LiquidBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 112, Alignment = 4)]
    public class LiquidBlockBase : GuerillaBlock
    {
        internal byte[] invalidName_;
        internal Type type;
        internal Moonfish.Tags.StringIdent attachmentMarkerName;
        internal byte[] invalidName_0;
        internal float falloffDistanceFromCameraWorldUnits;
        internal float cutoffDistanceFromCameraWorldUnits;
        internal byte[] invalidName_1;
        internal LiquidArcBlock[] arcs;
        public override int SerializedSize { get { return 112; } }
        public override int Alignment { get { return 4; } }
        public LiquidBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            invalidName_ = binaryReader.ReadBytes(2);
            type = (Type)binaryReader.ReadInt16();
            attachmentMarkerName = binaryReader.ReadStringID();
            invalidName_0 = binaryReader.ReadBytes(56);
            falloffDistanceFromCameraWorldUnits = binaryReader.ReadSingle();
            cutoffDistanceFromCameraWorldUnits = binaryReader.ReadSingle();
            invalidName_1 = binaryReader.ReadBytes(32);
            blamPointers.Enqueue(ReadBlockArrayPointer<LiquidArcBlock>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            arcs = ReadBlockArrayData<LiquidArcBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
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
                return nextAddress;
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
