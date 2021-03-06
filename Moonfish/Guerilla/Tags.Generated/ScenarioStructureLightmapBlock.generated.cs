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
    
    [TagClassAttribute("ltmp")]
    public partial class ScenarioStructureLightmapBlock : GuerillaBlock, IWriteQueueable
    {
        /// <summary>
        /// The following fields control the behavior of the lightmapper
        ///
        ///RADIANCE ESTIMATE SEARCH DISTANCE UPPER BOUND: the largest distance the code will look for photons. bigger levels need a bigger search radius.  Measured, in world units, 0.0 defaults to 1.0
        ///
        ///RADIANCE ESTIMATE SEARCH DISTANCE LOWER BOUND: the smallest distance the code will look for photons. bigger levels need a bigger search radius.  Measured, in world units, 0.0 defaults to 1.0
        ///
        ///LUMINELS PER WORLD UNIT: how many lightmap pixels there should be per world unit.  0.0 defaults to 3.0
        ///
        ///OUTPUT WHITE REFERENCE: for experimentation - what wattage the lightmapper considers "white" to be for output.  0.0 defaults to 1.0
        ///
        ///OUTPUT BLACK REFERENCE: for experimentation - what wattage the lightmapper considers "black" to be for output.  0.0 defaults to 0.0
        ///
        ///OUTPUT SCHLICK PARAMETER: controls the way midtones are mapped.  0.0 defaults to 4.5
        ///
        ///DIFFUSE MAP SCALE: controls how diffuse maps are scaled.  0.0 defaults to 1.5
        ///
        ///PRT SUN SCALE: 0.0 defaults to 100.0
        ///
        ///PRT SKY SCALE: 0.0 defaults to 1.0
        ///
        ///PRT INDIRECT SCALE: 0.0 defaults to 1.0
        ///
        ///PRT SCALE: you must set this value.
        ///
        ///PRT SURFACE LIGHT SCALE: 0.0 defaults to 1.0
        ///
        ///PRT SCENARIO LIGHT SCALE: 0.0 defaults to 1.0
        ///
        ///LIGHTPROBE INTERPOLATION OVERIDE(speed): overide the default sampling behavior
        /// </summary>
        public float SearchDistanceLowerBound;
        public float SearchDistanceUpperBound;
        public float LuminelsPerWorldUnit;
        public float OutputWhiteReference;
        public float OutputBlackReference;
        public float OutputSchlickParameter;
        public float DiffuseMapScale;
        public float SunScale;
        public float SkyScale;
        public float IndirectScale;
        public float PrtScale;
        public float SurfaceLightScale;
        public float ScenarioLightScale;
        public float LightprobeInterpolationOveride;
        private byte[] fieldpad = new byte[72];
        public StructureLightmapGroupBlock[] LightmapGroups = new StructureLightmapGroupBlock[0];
        private byte[] fieldpad0 = new byte[12];
        public GlobalErrorReportCategoriesBlock[] Errors = new GlobalErrorReportCategoriesBlock[0];
        private byte[] fieldpad1 = new byte[104];
        public override int SerializedSize
        {
            get
            {
                return 260;
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
            this.SearchDistanceLowerBound = binaryReader.ReadSingle();
            this.SearchDistanceUpperBound = binaryReader.ReadSingle();
            this.LuminelsPerWorldUnit = binaryReader.ReadSingle();
            this.OutputWhiteReference = binaryReader.ReadSingle();
            this.OutputBlackReference = binaryReader.ReadSingle();
            this.OutputSchlickParameter = binaryReader.ReadSingle();
            this.DiffuseMapScale = binaryReader.ReadSingle();
            this.SunScale = binaryReader.ReadSingle();
            this.SkyScale = binaryReader.ReadSingle();
            this.IndirectScale = binaryReader.ReadSingle();
            this.PrtScale = binaryReader.ReadSingle();
            this.SurfaceLightScale = binaryReader.ReadSingle();
            this.ScenarioLightScale = binaryReader.ReadSingle();
            this.LightprobeInterpolationOveride = binaryReader.ReadSingle();
            this.fieldpad = binaryReader.ReadBytes(72);
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(104));
            this.fieldpad0 = binaryReader.ReadBytes(12);
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(676));
            this.fieldpad1 = binaryReader.ReadBytes(104);
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.LightmapGroups = base.ReadBlockArrayData<StructureLightmapGroupBlock>(binaryReader, pointerQueue.Dequeue());
            this.Errors = base.ReadBlockArrayData<GlobalErrorReportCategoriesBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            queueableBinaryWriter.QueueWrite(this.LightmapGroups);
            queueableBinaryWriter.QueueWrite(this.Errors);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.SearchDistanceLowerBound);
            queueableBinaryWriter.Write(this.SearchDistanceUpperBound);
            queueableBinaryWriter.Write(this.LuminelsPerWorldUnit);
            queueableBinaryWriter.Write(this.OutputWhiteReference);
            queueableBinaryWriter.Write(this.OutputBlackReference);
            queueableBinaryWriter.Write(this.OutputSchlickParameter);
            queueableBinaryWriter.Write(this.DiffuseMapScale);
            queueableBinaryWriter.Write(this.SunScale);
            queueableBinaryWriter.Write(this.SkyScale);
            queueableBinaryWriter.Write(this.IndirectScale);
            queueableBinaryWriter.Write(this.PrtScale);
            queueableBinaryWriter.Write(this.SurfaceLightScale);
            queueableBinaryWriter.Write(this.ScenarioLightScale);
            queueableBinaryWriter.Write(this.LightprobeInterpolationOveride);
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.WritePointer(this.LightmapGroups);
            queueableBinaryWriter.Write(this.fieldpad0);
            queueableBinaryWriter.WritePointer(this.Errors);
            queueableBinaryWriter.Write(this.fieldpad1);
        }
    }
}
namespace Moonfish.Tags
{
    
    public partial struct TagClass
    {
        public static TagClass Ltmp = ((TagClass)("ltmp"));
    }
}
