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
        public static readonly TagClass Ltmp = (TagClass)"ltmp";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("ltmp")]
    public partial class ScenarioStructureLightmapBlock : ScenarioStructureLightmapBlockBase
    {
        public  ScenarioStructureLightmapBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ScenarioStructureLightmapBlock(): base()
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
        
        public override int SerializedSize{get { return 260; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ScenarioStructureLightmapBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
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
            lightmapGroups = Guerilla.ReadBlockArray<StructureLightmapGroupBlock>(binaryReader);
            invalidName_0 = binaryReader.ReadBytes(12);
            errors = Guerilla.ReadBlockArray<GlobalErrorReportCategoriesBlock>(binaryReader);
            invalidName_1 = binaryReader.ReadBytes(104);
        }
        public  ScenarioStructureLightmapBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
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
