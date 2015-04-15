// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderPassParameterBlock : ShaderPassParameterBlockBase
    {
        public  ShaderPassParameterBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 44, Alignment = 4)]
    public class ShaderPassParameterBlockBase  : IGuerilla
    {
        internal Moonfish.Tags.StringID name;
        internal byte[] explanation;
        internal Type type;
        internal Flags flags;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference defaultBitmap;
        internal float defaultConstValue;
        internal Moonfish.Tags.ColorR8G8B8 defaultConstColor;
        internal SourceExtern sourceExtern;
        internal byte[] invalidName_;
        internal  ShaderPassParameterBlockBase(BinaryReader binaryReader)
        {
            name = binaryReader.ReadStringID();
            explanation = Guerilla.ReadData(binaryReader);
            type = (Type)binaryReader.ReadInt16();
            flags = (Flags)binaryReader.ReadInt16();
            defaultBitmap = binaryReader.ReadTagReference();
            defaultConstValue = binaryReader.ReadSingle();
            defaultConstColor = binaryReader.ReadColorR8G8B8();
            sourceExtern = (SourceExtern)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                nextAddress = Guerilla.WriteData(binaryWriter, explanation, nextAddress);
                binaryWriter.Write((Int16)type);
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(defaultBitmap);
                binaryWriter.Write(defaultConstValue);
                binaryWriter.Write(defaultConstColor);
                binaryWriter.Write((Int16)sourceExtern);
                binaryWriter.Write(invalidName_, 0, 2);
                return nextAddress;
            }
        }
        internal enum Type : short
        {
            Bitmap = 0,
            Value = 1,
            Color = 2,
            Switch = 3,
        };
        [FlagsAttribute]
        internal enum Flags : short
        {
            NoBitmapLOD = 1,
            RequiredParameter = 2,
        };
        internal enum SourceExtern : short
        {
            None = 0,
            GLOBALEyeForwardVectorZ = 1,
            GLOBALEyeRightVectorX = 2,
            GLOBALEyeUpVectorY = 3,
            OBJECTPrimaryColor = 4,
            OBJECTSecondaryColor = 5,
            OBJECTFunctionValue = 6,
            LIGHTDiffuseColor = 7,
            LIGHTSpecularColor = 8,
            LIGHTForwardVectorZ = 9,
            LIGHTRightVectorX = 10,
            LIGHTUpVectorY = 11,
            LIGHTObjectRelativeForwardVectorZ = 12,
            LIGHTObjectRelativeRightVectorX = 13,
            LIGHTObjectRelativeUpVectorY = 14,
            LIGHTObjectFalloffValue = 15,
            LIGHTObjectGelColor = 16,
            LIGHTMAPObjectAmbientFactor = 17,
            LIGHTMAPObjectDirectVector = 18,
            LIGHTMAPObjectDirectColor = 19,
            LIGHTMAPObjectIndirectVector = 20,
            LIGHTMAPObjectIndirectColor = 21,
            OLDFOGAtmosphericColor = 22,
            OLDFOGAtmosphericMaxDensity = 23,
            OLDFOGPlanarColor = 24,
            OLDFOGPlanarMaxDensity = 25,
            OLDFOGAtmosphericPlanarBlendValue = 26,
            OLDFOGObjectAtmosphericDensity = 27,
            OLDFOGObjectPlanarDensity = 28,
            OLDFOGObjectColor = 29,
            OLDFOGObjectDensity = 30,
            OBJECTModelAlpha = 31,
            OBJECTShadowAlpha = 32,
            LIGHTOverbrightenDiffuseShift = 33,
            LIGHTOverbrightenSpecularShift = 34,
            LIGHTDiffuseContrast = 35,
            LIGHTSpecularGel = 36,
            SHADERSpecularType = 37,
            Pad3 = 38,
            Pad3Scale = 39,
            PadThai = 40,
            TacoSalad = 41,
            AnisotropicBinormal = 42,
            OBJECTLIGHTShadowFade = 43,
            LIGHTShadowFade = 44,
            OLDFOGAtmosphericDensity = 45,
            OLDFOGPlanarDensity = 46,
            OLDFOGPlanarDensityInvert = 47,
            OBJECTChangeColorTertiary = 48,
            OBJECTChangeColorQuaternary = 49,
            LIGHTMAPObjectSpecularColor = 50,
            SHADERLightmapType = 51,
            LIGHTMAPObjectAmbientColor = 52,
            SHADERLightmapSpecularBrightness = 53,
            GLOBALLightmapShadowDarkening = 54,
            LIGHTMAPObjectEnvBrightness = 55,
            FOGAtmosphericMaxDensity = 56,
            FOGAtmosphericColor = 57,
            FOGAtmosphericColorAdj = 58,
            FOGAtmosphericPlanarBlend = 59,
            FOGAtmosphericPlanarBlendAdjInv = 60,
            FOGAtmosphericPlanarBlendAdj = 61,
            FOGSecondaryMaxDensity = 62,
            FOGSecondaryColor = 63,
            FOGSecondaryColorAdj = 64,
            FOGAtmosphericSecondaryBlend = 65,
            FOGAtmosphericSecondaryBlendAdjInv = 66,
            FOGAtmosphericSecondaryBlendAdj = 67,
            FOGSkyDensity = 68,
            FOGSkyColor = 69,
            FOGSkyColorAdj = 70,
            FOGPlanarMaxDensity = 71,
            FOGPlanarColor = 72,
            FOGPlanarColorAdj = 73,
            FOGPlanarEyeDensity = 74,
            FOGPlanarEyeDensityAdjInv = 75,
            FOGPlanarEyeDensityAdj = 76,
            HUDWaypointPrimaryColor = 77,
            HUDWaypointSecondaryColor = 78,
            LIGHTMAPObjectSpecularColorTimesOneHalf = 79,
            LIGHTSpecularEnabled = 80,
            LIGHTDefinitionSpecularEnabled = 81,
            OBJECTActiveCamoAmount = 82,
            OBJECTSuperCamoAmount = 83,
            HUDCustomColor1 = 84,
            HUDCustomColor2 = 85,
            HUDCustomColor3 = 86,
            HUDCustomColor4 = 87,
            OBJECTActiveCamoRGB = 88,
            FOGPatchyPlaneNXyz = 89,
            FOGPatchyPlaneDW = 90,
            HUDGlobalFade = 91,
            SCREENEFFECTPrimary = 92,
            SCREENEFFECTSecondary = 93,
        };
    };
}
