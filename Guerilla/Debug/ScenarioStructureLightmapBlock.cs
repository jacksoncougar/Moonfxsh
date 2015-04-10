// ReSharper disable All
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
        public  ScenarioStructureLightmapBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  ScenarioStructureLightmapBlockBase(System.IO.BinaryReader binaryReader)
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
            ReadStructureLightmapGroupBlockArray(binaryReader);
            invalidName_0 = binaryReader.ReadBytes(12);
            ReadGlobalErrorReportCategoriesBlockArray(binaryReader);
            invalidName_1 = binaryReader.ReadBytes(104);
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
        internal  virtual StructureLightmapGroupBlock[] ReadStructureLightmapGroupBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureLightmapGroupBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureLightmapGroupBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureLightmapGroupBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GlobalErrorReportCategoriesBlock[] ReadGlobalErrorReportCategoriesBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalErrorReportCategoriesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalErrorReportCategoriesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalErrorReportCategoriesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteStructureLightmapGroupBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGlobalErrorReportCategoriesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
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
                WriteStructureLightmapGroupBlockArray(binaryWriter);
                binaryWriter.Write(invalidName_0, 0, 12);
                WriteGlobalErrorReportCategoriesBlockArray(binaryWriter);
                binaryWriter.Write(invalidName_1, 0, 104);
            }
        }
    };
}
