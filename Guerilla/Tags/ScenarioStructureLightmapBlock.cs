using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("ltmp")]
    public  partial class ScenarioStructureLightmapBlock : ScenarioStructureLightmapBlockBase
    {
        public  ScenarioStructureLightmapBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 260)]
    public class ScenarioStructureLightmapBlockBase
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
        internal  ScenarioStructureLightmapBlockBase(BinaryReader binaryReader)
        {
            this.searchDistanceLowerBound = binaryReader.ReadSingle();
            this.searchDistanceUpperBound = binaryReader.ReadSingle();
            this.luminelsPerWorldUnit = binaryReader.ReadSingle();
            this.outputWhiteReference = binaryReader.ReadSingle();
            this.outputBlackReference = binaryReader.ReadSingle();
            this.outputSchlickParameter = binaryReader.ReadSingle();
            this.diffuseMapScale = binaryReader.ReadSingle();
            this.sunScale = binaryReader.ReadSingle();
            this.skyScale = binaryReader.ReadSingle();
            this.indirectScale = binaryReader.ReadSingle();
            this.prtScale = binaryReader.ReadSingle();
            this.surfaceLightScale = binaryReader.ReadSingle();
            this.scenarioLightScale = binaryReader.ReadSingle();
            this.lightprobeInterpolationOveride = binaryReader.ReadSingle();
            this.invalidName_ = binaryReader.ReadBytes(72);
            this.lightmapGroups = ReadStructureLightmapGroupBlockArray(binaryReader);
            this.invalidName_0 = binaryReader.ReadBytes(12);
            this.errors = ReadGlobalErrorReportCategoriesBlockArray(binaryReader);
            this.invalidName_1 = binaryReader.ReadBytes(104);
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
        internal  virtual StructureLightmapGroupBlock[] ReadStructureLightmapGroupBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureLightmapGroupBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureLightmapGroupBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureLightmapGroupBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GlobalErrorReportCategoriesBlock[] ReadGlobalErrorReportCategoriesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalErrorReportCategoriesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalErrorReportCategoriesBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalErrorReportCategoriesBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
