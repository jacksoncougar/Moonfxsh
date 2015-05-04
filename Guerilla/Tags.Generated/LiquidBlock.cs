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
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
            invalidName_[1].ReadPointers(binaryReader, blamPointers);
            invalidName_0[0].ReadPointers(binaryReader, blamPointers);
            invalidName_0[1].ReadPointers(binaryReader, blamPointers);
            invalidName_0[2].ReadPointers(binaryReader, blamPointers);
            invalidName_0[3].ReadPointers(binaryReader, blamPointers);
            invalidName_0[4].ReadPointers(binaryReader, blamPointers);
            invalidName_0[5].ReadPointers(binaryReader, blamPointers);
            invalidName_0[6].ReadPointers(binaryReader, blamPointers);
            invalidName_0[7].ReadPointers(binaryReader, blamPointers);
            invalidName_0[8].ReadPointers(binaryReader, blamPointers);
            invalidName_0[9].ReadPointers(binaryReader, blamPointers);
            invalidName_0[10].ReadPointers(binaryReader, blamPointers);
            invalidName_0[11].ReadPointers(binaryReader, blamPointers);
            invalidName_0[12].ReadPointers(binaryReader, blamPointers);
            invalidName_0[13].ReadPointers(binaryReader, blamPointers);
            invalidName_0[14].ReadPointers(binaryReader, blamPointers);
            invalidName_0[15].ReadPointers(binaryReader, blamPointers);
            invalidName_0[16].ReadPointers(binaryReader, blamPointers);
            invalidName_0[17].ReadPointers(binaryReader, blamPointers);
            invalidName_0[18].ReadPointers(binaryReader, blamPointers);
            invalidName_0[19].ReadPointers(binaryReader, blamPointers);
            invalidName_0[20].ReadPointers(binaryReader, blamPointers);
            invalidName_0[21].ReadPointers(binaryReader, blamPointers);
            invalidName_0[22].ReadPointers(binaryReader, blamPointers);
            invalidName_0[23].ReadPointers(binaryReader, blamPointers);
            invalidName_0[24].ReadPointers(binaryReader, blamPointers);
            invalidName_0[25].ReadPointers(binaryReader, blamPointers);
            invalidName_0[26].ReadPointers(binaryReader, blamPointers);
            invalidName_0[27].ReadPointers(binaryReader, blamPointers);
            invalidName_0[28].ReadPointers(binaryReader, blamPointers);
            invalidName_0[29].ReadPointers(binaryReader, blamPointers);
            invalidName_0[30].ReadPointers(binaryReader, blamPointers);
            invalidName_0[31].ReadPointers(binaryReader, blamPointers);
            invalidName_0[32].ReadPointers(binaryReader, blamPointers);
            invalidName_0[33].ReadPointers(binaryReader, blamPointers);
            invalidName_0[34].ReadPointers(binaryReader, blamPointers);
            invalidName_0[35].ReadPointers(binaryReader, blamPointers);
            invalidName_0[36].ReadPointers(binaryReader, blamPointers);
            invalidName_0[37].ReadPointers(binaryReader, blamPointers);
            invalidName_0[38].ReadPointers(binaryReader, blamPointers);
            invalidName_0[39].ReadPointers(binaryReader, blamPointers);
            invalidName_0[40].ReadPointers(binaryReader, blamPointers);
            invalidName_0[41].ReadPointers(binaryReader, blamPointers);
            invalidName_0[42].ReadPointers(binaryReader, blamPointers);
            invalidName_0[43].ReadPointers(binaryReader, blamPointers);
            invalidName_0[44].ReadPointers(binaryReader, blamPointers);
            invalidName_0[45].ReadPointers(binaryReader, blamPointers);
            invalidName_0[46].ReadPointers(binaryReader, blamPointers);
            invalidName_0[47].ReadPointers(binaryReader, blamPointers);
            invalidName_0[48].ReadPointers(binaryReader, blamPointers);
            invalidName_0[49].ReadPointers(binaryReader, blamPointers);
            invalidName_0[50].ReadPointers(binaryReader, blamPointers);
            invalidName_0[51].ReadPointers(binaryReader, blamPointers);
            invalidName_0[52].ReadPointers(binaryReader, blamPointers);
            invalidName_0[53].ReadPointers(binaryReader, blamPointers);
            invalidName_0[54].ReadPointers(binaryReader, blamPointers);
            invalidName_0[55].ReadPointers(binaryReader, blamPointers);
            invalidName_1[0].ReadPointers(binaryReader, blamPointers);
            invalidName_1[1].ReadPointers(binaryReader, blamPointers);
            invalidName_1[2].ReadPointers(binaryReader, blamPointers);
            invalidName_1[3].ReadPointers(binaryReader, blamPointers);
            invalidName_1[4].ReadPointers(binaryReader, blamPointers);
            invalidName_1[5].ReadPointers(binaryReader, blamPointers);
            invalidName_1[6].ReadPointers(binaryReader, blamPointers);
            invalidName_1[7].ReadPointers(binaryReader, blamPointers);
            invalidName_1[8].ReadPointers(binaryReader, blamPointers);
            invalidName_1[9].ReadPointers(binaryReader, blamPointers);
            invalidName_1[10].ReadPointers(binaryReader, blamPointers);
            invalidName_1[11].ReadPointers(binaryReader, blamPointers);
            invalidName_1[12].ReadPointers(binaryReader, blamPointers);
            invalidName_1[13].ReadPointers(binaryReader, blamPointers);
            invalidName_1[14].ReadPointers(binaryReader, blamPointers);
            invalidName_1[15].ReadPointers(binaryReader, blamPointers);
            invalidName_1[16].ReadPointers(binaryReader, blamPointers);
            invalidName_1[17].ReadPointers(binaryReader, blamPointers);
            invalidName_1[18].ReadPointers(binaryReader, blamPointers);
            invalidName_1[19].ReadPointers(binaryReader, blamPointers);
            invalidName_1[20].ReadPointers(binaryReader, blamPointers);
            invalidName_1[21].ReadPointers(binaryReader, blamPointers);
            invalidName_1[22].ReadPointers(binaryReader, blamPointers);
            invalidName_1[23].ReadPointers(binaryReader, blamPointers);
            invalidName_1[24].ReadPointers(binaryReader, blamPointers);
            invalidName_1[25].ReadPointers(binaryReader, blamPointers);
            invalidName_1[26].ReadPointers(binaryReader, blamPointers);
            invalidName_1[27].ReadPointers(binaryReader, blamPointers);
            invalidName_1[28].ReadPointers(binaryReader, blamPointers);
            invalidName_1[29].ReadPointers(binaryReader, blamPointers);
            invalidName_1[30].ReadPointers(binaryReader, blamPointers);
            invalidName_1[31].ReadPointers(binaryReader, blamPointers);
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
