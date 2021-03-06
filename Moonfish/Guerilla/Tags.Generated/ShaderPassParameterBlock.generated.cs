//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Moonfish.Guerilla.Tags
{
    using Moonfish.Tags;
    using Moonfish.Model;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    
    public partial class ShaderPassParameterBlock : GuerillaBlock, IWriteQueueable
    {
        public Moonfish.Tags.StringIdent Name;
        public byte[] Explanation;
        public TypeEnum Type;
        public Flags ShaderPassParameterFlags;
        [Moonfish.Tags.TagReferenceAttribute("bitm")]
        public Moonfish.Tags.TagReference DefaultBitmap;
        public float DefaultConstValue;
        public Moonfish.Tags.ColourR8G8B8 DefaultConstColor;
        public SourceExternEnum SourceExtern;
        private byte[] fieldpad = new byte[2];
        public override int SerializedSize
        {
            get
            {
                return 44;
            }
        }
        public override int Alignment
        {
            get
            {
                return 4;
            }
        }
        public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(System.IO.BinaryReader binaryReader)
        {
            System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
            this.Name = binaryReader.ReadStringID();
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(1));
            this.Type = ((TypeEnum)(binaryReader.ReadInt16()));
            this.ShaderPassParameterFlags = ((Flags)(binaryReader.ReadInt16()));
            this.DefaultBitmap = binaryReader.ReadTagReference();
            this.DefaultConstValue = binaryReader.ReadSingle();
            this.DefaultConstColor = binaryReader.ReadColorR8G8B8();
            this.SourceExtern = ((SourceExternEnum)(binaryReader.ReadInt16()));
            this.fieldpad = binaryReader.ReadBytes(2);
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.Explanation = base.ReadDataByteArray(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            queueableBinaryWriter.QueueWrite(this.Explanation);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.Name);
            queueableBinaryWriter.WritePointer(this.Explanation);
            queueableBinaryWriter.Write(((short)(this.Type)));
            queueableBinaryWriter.Write(((short)(this.ShaderPassParameterFlags)));
            queueableBinaryWriter.Write(this.DefaultBitmap);
            queueableBinaryWriter.Write(this.DefaultConstValue);
            queueableBinaryWriter.Write(this.DefaultConstColor);
            queueableBinaryWriter.Write(((short)(this.SourceExtern)));
            queueableBinaryWriter.Write(this.fieldpad);
        }
        public enum TypeEnum : short
        {
            Bitmap = 0,
            Value = 1,
            Color = 2,
            Switch = 3,
        }
        [System.FlagsAttribute()]
        public enum Flags : short
        {
            None = 0,
            NoBitmapLOD = 1,
            RequiredParameter = 2,
        }
        public enum SourceExternEnum : short
        {
            None = 0,
            GLOBALEyeForwardVectorz = 1,
            GLOBALEyeRightVectorx = 2,
            GLOBALEyeUpVectory = 3,
            OBJECTPrimaryColor = 4,
            OBJECTSecondaryColor = 5,
            OBJECTFunctionValue = 6,
            LIGHTDiffuseColor = 7,
            LIGHTSpecularColor = 8,
            LIGHTForwardVectorz = 9,
            LIGHTRightVectorx = 10,
            LIGHTUpVectory = 11,
            LIGHTObjectRelativeForwardVectorz = 12,
            LIGHTObjectRelativeRightVectorx = 13,
            LIGHTObjectRelativeUpVectory = 14,
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
            Pad3scale = 39,
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
            FOGPatchyPlaneNxyz = 89,
            FOGPatchyPlaneDw = 90,
            HUDGlobalFade = 91,
            SCREENEFFECTPrimary = 92,
            SCREENEFFECTSecondary = 93,
        }
    }
}
