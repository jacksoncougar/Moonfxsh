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
        public static readonly TagClass Ltmp = (TagClass)"ltmp";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("ltmp")]
    public partial class ScenarioStructureLightmapBlock : ScenarioStructureLightmapBlockBase
    {
        public ScenarioStructureLightmapBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 260, Alignment = 4)]
    public class ScenarioStructureLightmapBlockBase : GuerillaBlock
    {
        internal float searchDistanceLowerBound;
        internal float searchDistanceUpperBound;
        internal float luminelsPerWorldUnit;
        internal float outputWhiteReference;
        internal float outputBlackReference;
        internal float outputSchlickParameter;
        internal float diffuseMapScale;
        internal float sunScale;
        internal float skyScale;
        internal float indirectScale;
        internal float prtScale;
        internal float surfaceLightScale;
        internal float scenarioLightScale;
        internal float lightprobeInterpolationOveride;
        internal byte[] invalidName_;
        internal StructureLightmapGroupBlock[] lightmapGroups;
        internal byte[] invalidName_0;
        internal GlobalErrorReportCategoriesBlock[] errors;
        internal byte[] invalidName_1;
        public override int SerializedSize { get { return 260; } }
        public override int Alignment { get { return 4; } }
        public ScenarioStructureLightmapBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            searchDistanceLowerBound = binaryReader.ReadSingle();
            searchDistanceUpperBound = binaryReader.ReadSingle();
            luminelsPerWorldUnit = binaryReader.ReadSingle();
            outputWhiteReference = binaryReader.ReadSingle();
            outputBlackReference = binaryReader.ReadSingle();
            outputSchlickParameter = binaryReader.ReadSingle();
            diffuseMapScale = binaryReader.ReadSingle();
            sunScale = binaryReader.ReadSingle();
            skyScale = binaryReader.ReadSingle();
            indirectScale = binaryReader.ReadSingle();
            prtScale = binaryReader.ReadSingle();
            surfaceLightScale = binaryReader.ReadSingle();
            scenarioLightScale = binaryReader.ReadSingle();
            lightprobeInterpolationOveride = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(72);
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureLightmapGroupBlock>(binaryReader));
            invalidName_0 = binaryReader.ReadBytes(12);
            blamPointers.Enqueue(ReadBlockArrayPointer<GlobalErrorReportCategoriesBlock>(binaryReader));
            invalidName_1 = binaryReader.ReadBytes(104);
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
            invalidName_[1].ReadPointers(binaryReader, blamPointers);
            invalidName_[2].ReadPointers(binaryReader, blamPointers);
            invalidName_[3].ReadPointers(binaryReader, blamPointers);
            invalidName_[4].ReadPointers(binaryReader, blamPointers);
            invalidName_[5].ReadPointers(binaryReader, blamPointers);
            invalidName_[6].ReadPointers(binaryReader, blamPointers);
            invalidName_[7].ReadPointers(binaryReader, blamPointers);
            invalidName_[8].ReadPointers(binaryReader, blamPointers);
            invalidName_[9].ReadPointers(binaryReader, blamPointers);
            invalidName_[10].ReadPointers(binaryReader, blamPointers);
            invalidName_[11].ReadPointers(binaryReader, blamPointers);
            invalidName_[12].ReadPointers(binaryReader, blamPointers);
            invalidName_[13].ReadPointers(binaryReader, blamPointers);
            invalidName_[14].ReadPointers(binaryReader, blamPointers);
            invalidName_[15].ReadPointers(binaryReader, blamPointers);
            invalidName_[16].ReadPointers(binaryReader, blamPointers);
            invalidName_[17].ReadPointers(binaryReader, blamPointers);
            invalidName_[18].ReadPointers(binaryReader, blamPointers);
            invalidName_[19].ReadPointers(binaryReader, blamPointers);
            invalidName_[20].ReadPointers(binaryReader, blamPointers);
            invalidName_[21].ReadPointers(binaryReader, blamPointers);
            invalidName_[22].ReadPointers(binaryReader, blamPointers);
            invalidName_[23].ReadPointers(binaryReader, blamPointers);
            invalidName_[24].ReadPointers(binaryReader, blamPointers);
            invalidName_[25].ReadPointers(binaryReader, blamPointers);
            invalidName_[26].ReadPointers(binaryReader, blamPointers);
            invalidName_[27].ReadPointers(binaryReader, blamPointers);
            invalidName_[28].ReadPointers(binaryReader, blamPointers);
            invalidName_[29].ReadPointers(binaryReader, blamPointers);
            invalidName_[30].ReadPointers(binaryReader, blamPointers);
            invalidName_[31].ReadPointers(binaryReader, blamPointers);
            invalidName_[32].ReadPointers(binaryReader, blamPointers);
            invalidName_[33].ReadPointers(binaryReader, blamPointers);
            invalidName_[34].ReadPointers(binaryReader, blamPointers);
            invalidName_[35].ReadPointers(binaryReader, blamPointers);
            invalidName_[36].ReadPointers(binaryReader, blamPointers);
            invalidName_[37].ReadPointers(binaryReader, blamPointers);
            invalidName_[38].ReadPointers(binaryReader, blamPointers);
            invalidName_[39].ReadPointers(binaryReader, blamPointers);
            invalidName_[40].ReadPointers(binaryReader, blamPointers);
            invalidName_[41].ReadPointers(binaryReader, blamPointers);
            invalidName_[42].ReadPointers(binaryReader, blamPointers);
            invalidName_[43].ReadPointers(binaryReader, blamPointers);
            invalidName_[44].ReadPointers(binaryReader, blamPointers);
            invalidName_[45].ReadPointers(binaryReader, blamPointers);
            invalidName_[46].ReadPointers(binaryReader, blamPointers);
            invalidName_[47].ReadPointers(binaryReader, blamPointers);
            invalidName_[48].ReadPointers(binaryReader, blamPointers);
            invalidName_[49].ReadPointers(binaryReader, blamPointers);
            invalidName_[50].ReadPointers(binaryReader, blamPointers);
            invalidName_[51].ReadPointers(binaryReader, blamPointers);
            invalidName_[52].ReadPointers(binaryReader, blamPointers);
            invalidName_[53].ReadPointers(binaryReader, blamPointers);
            invalidName_[54].ReadPointers(binaryReader, blamPointers);
            invalidName_[55].ReadPointers(binaryReader, blamPointers);
            invalidName_[56].ReadPointers(binaryReader, blamPointers);
            invalidName_[57].ReadPointers(binaryReader, blamPointers);
            invalidName_[58].ReadPointers(binaryReader, blamPointers);
            invalidName_[59].ReadPointers(binaryReader, blamPointers);
            invalidName_[60].ReadPointers(binaryReader, blamPointers);
            invalidName_[61].ReadPointers(binaryReader, blamPointers);
            invalidName_[62].ReadPointers(binaryReader, blamPointers);
            invalidName_[63].ReadPointers(binaryReader, blamPointers);
            invalidName_[64].ReadPointers(binaryReader, blamPointers);
            invalidName_[65].ReadPointers(binaryReader, blamPointers);
            invalidName_[66].ReadPointers(binaryReader, blamPointers);
            invalidName_[67].ReadPointers(binaryReader, blamPointers);
            invalidName_[68].ReadPointers(binaryReader, blamPointers);
            invalidName_[69].ReadPointers(binaryReader, blamPointers);
            invalidName_[70].ReadPointers(binaryReader, blamPointers);
            invalidName_[71].ReadPointers(binaryReader, blamPointers);
            lightmapGroups = ReadBlockArrayData<StructureLightmapGroupBlock>(binaryReader, blamPointers.Dequeue());
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
            errors = ReadBlockArrayData<GlobalErrorReportCategoriesBlock>(binaryReader, blamPointers.Dequeue());
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
            invalidName_1[32].ReadPointers(binaryReader, blamPointers);
            invalidName_1[33].ReadPointers(binaryReader, blamPointers);
            invalidName_1[34].ReadPointers(binaryReader, blamPointers);
            invalidName_1[35].ReadPointers(binaryReader, blamPointers);
            invalidName_1[36].ReadPointers(binaryReader, blamPointers);
            invalidName_1[37].ReadPointers(binaryReader, blamPointers);
            invalidName_1[38].ReadPointers(binaryReader, blamPointers);
            invalidName_1[39].ReadPointers(binaryReader, blamPointers);
            invalidName_1[40].ReadPointers(binaryReader, blamPointers);
            invalidName_1[41].ReadPointers(binaryReader, blamPointers);
            invalidName_1[42].ReadPointers(binaryReader, blamPointers);
            invalidName_1[43].ReadPointers(binaryReader, blamPointers);
            invalidName_1[44].ReadPointers(binaryReader, blamPointers);
            invalidName_1[45].ReadPointers(binaryReader, blamPointers);
            invalidName_1[46].ReadPointers(binaryReader, blamPointers);
            invalidName_1[47].ReadPointers(binaryReader, blamPointers);
            invalidName_1[48].ReadPointers(binaryReader, blamPointers);
            invalidName_1[49].ReadPointers(binaryReader, blamPointers);
            invalidName_1[50].ReadPointers(binaryReader, blamPointers);
            invalidName_1[51].ReadPointers(binaryReader, blamPointers);
            invalidName_1[52].ReadPointers(binaryReader, blamPointers);
            invalidName_1[53].ReadPointers(binaryReader, blamPointers);
            invalidName_1[54].ReadPointers(binaryReader, blamPointers);
            invalidName_1[55].ReadPointers(binaryReader, blamPointers);
            invalidName_1[56].ReadPointers(binaryReader, blamPointers);
            invalidName_1[57].ReadPointers(binaryReader, blamPointers);
            invalidName_1[58].ReadPointers(binaryReader, blamPointers);
            invalidName_1[59].ReadPointers(binaryReader, blamPointers);
            invalidName_1[60].ReadPointers(binaryReader, blamPointers);
            invalidName_1[61].ReadPointers(binaryReader, blamPointers);
            invalidName_1[62].ReadPointers(binaryReader, blamPointers);
            invalidName_1[63].ReadPointers(binaryReader, blamPointers);
            invalidName_1[64].ReadPointers(binaryReader, blamPointers);
            invalidName_1[65].ReadPointers(binaryReader, blamPointers);
            invalidName_1[66].ReadPointers(binaryReader, blamPointers);
            invalidName_1[67].ReadPointers(binaryReader, blamPointers);
            invalidName_1[68].ReadPointers(binaryReader, blamPointers);
            invalidName_1[69].ReadPointers(binaryReader, blamPointers);
            invalidName_1[70].ReadPointers(binaryReader, blamPointers);
            invalidName_1[71].ReadPointers(binaryReader, blamPointers);
            invalidName_1[72].ReadPointers(binaryReader, blamPointers);
            invalidName_1[73].ReadPointers(binaryReader, blamPointers);
            invalidName_1[74].ReadPointers(binaryReader, blamPointers);
            invalidName_1[75].ReadPointers(binaryReader, blamPointers);
            invalidName_1[76].ReadPointers(binaryReader, blamPointers);
            invalidName_1[77].ReadPointers(binaryReader, blamPointers);
            invalidName_1[78].ReadPointers(binaryReader, blamPointers);
            invalidName_1[79].ReadPointers(binaryReader, blamPointers);
            invalidName_1[80].ReadPointers(binaryReader, blamPointers);
            invalidName_1[81].ReadPointers(binaryReader, blamPointers);
            invalidName_1[82].ReadPointers(binaryReader, blamPointers);
            invalidName_1[83].ReadPointers(binaryReader, blamPointers);
            invalidName_1[84].ReadPointers(binaryReader, blamPointers);
            invalidName_1[85].ReadPointers(binaryReader, blamPointers);
            invalidName_1[86].ReadPointers(binaryReader, blamPointers);
            invalidName_1[87].ReadPointers(binaryReader, blamPointers);
            invalidName_1[88].ReadPointers(binaryReader, blamPointers);
            invalidName_1[89].ReadPointers(binaryReader, blamPointers);
            invalidName_1[90].ReadPointers(binaryReader, blamPointers);
            invalidName_1[91].ReadPointers(binaryReader, blamPointers);
            invalidName_1[92].ReadPointers(binaryReader, blamPointers);
            invalidName_1[93].ReadPointers(binaryReader, blamPointers);
            invalidName_1[94].ReadPointers(binaryReader, blamPointers);
            invalidName_1[95].ReadPointers(binaryReader, blamPointers);
            invalidName_1[96].ReadPointers(binaryReader, blamPointers);
            invalidName_1[97].ReadPointers(binaryReader, blamPointers);
            invalidName_1[98].ReadPointers(binaryReader, blamPointers);
            invalidName_1[99].ReadPointers(binaryReader, blamPointers);
            invalidName_1[100].ReadPointers(binaryReader, blamPointers);
            invalidName_1[101].ReadPointers(binaryReader, blamPointers);
            invalidName_1[102].ReadPointers(binaryReader, blamPointers);
            invalidName_1[103].ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(searchDistanceLowerBound);
                binaryWriter.Write(searchDistanceUpperBound);
                binaryWriter.Write(luminelsPerWorldUnit);
                binaryWriter.Write(outputWhiteReference);
                binaryWriter.Write(outputBlackReference);
                binaryWriter.Write(outputSchlickParameter);
                binaryWriter.Write(diffuseMapScale);
                binaryWriter.Write(sunScale);
                binaryWriter.Write(skyScale);
                binaryWriter.Write(indirectScale);
                binaryWriter.Write(prtScale);
                binaryWriter.Write(surfaceLightScale);
                binaryWriter.Write(scenarioLightScale);
                binaryWriter.Write(lightprobeInterpolationOveride);
                binaryWriter.Write(invalidName_, 0, 72);
                nextAddress = Guerilla.WriteBlockArray<StructureLightmapGroupBlock>(binaryWriter, lightmapGroups, nextAddress);
                binaryWriter.Write(invalidName_0, 0, 12);
                nextAddress = Guerilla.WriteBlockArray<GlobalErrorReportCategoriesBlock>(binaryWriter, errors, nextAddress);
                binaryWriter.Write(invalidName_1, 0, 104);
                return nextAddress;
            }
        }
    };
}
