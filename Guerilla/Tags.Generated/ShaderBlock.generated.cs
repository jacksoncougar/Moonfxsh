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
    
    [TagClassAttribute("shad")]
    public partial class ShaderBlock : GuerillaBlock, IWriteQueueable
    {
        [Moonfish.Tags.TagReferenceAttribute("stem")]
        public Moonfish.Tags.TagReference Template;
        public Moonfish.Tags.StringIdent MaterialName;
        public ShaderPropertiesBlock[] RuntimeProperties = new ShaderPropertiesBlock[0];
        private byte[] fieldpad = new byte[2];
        public Flags ShaderFlags;
        public GlobalShaderParameterBlock[] Parameters = new GlobalShaderParameterBlock[0];
        public ShaderPostprocessDefinitionNewBlock[] PostprocessDefinition = new ShaderPostprocessDefinitionNewBlock[0];
        private byte[] fieldpad0 = new byte[4];
        public PredictedResourceBlock[] PredictedResources = new PredictedResourceBlock[0];
        [Moonfish.Tags.TagReferenceAttribute("slit")]
        public Moonfish.Tags.TagReference LightResponse;
        public ShaderLODBiasEnum ShaderLODBias;
        public SpecularTypeEnum SpecularType;
        public LightmapTypeEnum LightmapType;
        private byte[] fieldpad1 = new byte[2];
        public float LightmapSpecularBrightness;
        public float LightmapAmbientBias;
        public float AddedDepthBiasOffset;
        public float AddedDepthBiasSlopeScale;
        public override int SerializedSize
        {
            get
            {
                return 84;
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
            this.Template = binaryReader.ReadTagReference();
            this.MaterialName = binaryReader.ReadStringID();
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(80));
            this.fieldpad = binaryReader.ReadBytes(2);
            this.ShaderFlags = ((Flags)(binaryReader.ReadInt16()));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(40));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(124));
            this.fieldpad0 = binaryReader.ReadBytes(4);
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(8));
            this.LightResponse = binaryReader.ReadTagReference();
            this.ShaderLODBias = ((ShaderLODBiasEnum)(binaryReader.ReadInt16()));
            this.SpecularType = ((SpecularTypeEnum)(binaryReader.ReadInt16()));
            this.LightmapType = ((LightmapTypeEnum)(binaryReader.ReadInt16()));
            this.fieldpad1 = binaryReader.ReadBytes(2);
            this.LightmapSpecularBrightness = binaryReader.ReadSingle();
            this.LightmapAmbientBias = binaryReader.ReadSingle();
            this.AddedDepthBiasOffset = binaryReader.ReadSingle();
            this.AddedDepthBiasSlopeScale = binaryReader.ReadSingle();
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.RuntimeProperties = base.ReadBlockArrayData<ShaderPropertiesBlock>(binaryReader, pointerQueue.Dequeue());
            this.Parameters = base.ReadBlockArrayData<GlobalShaderParameterBlock>(binaryReader, pointerQueue.Dequeue());
            this.PostprocessDefinition = base.ReadBlockArrayData<ShaderPostprocessDefinitionNewBlock>(binaryReader, pointerQueue.Dequeue());
            this.PredictedResources = base.ReadBlockArrayData<PredictedResourceBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            queueableBinaryWriter.QueueWrite(this.RuntimeProperties);
            queueableBinaryWriter.QueueWrite(this.Parameters);
            queueableBinaryWriter.QueueWrite(this.PostprocessDefinition);
            queueableBinaryWriter.QueueWrite(this.PredictedResources);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.Template);
            queueableBinaryWriter.Write(this.MaterialName);
            queueableBinaryWriter.WritePointer(this.RuntimeProperties);
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.Write(((short)(this.ShaderFlags)));
            queueableBinaryWriter.WritePointer(this.Parameters);
            queueableBinaryWriter.WritePointer(this.PostprocessDefinition);
            queueableBinaryWriter.Write(this.fieldpad0);
            queueableBinaryWriter.WritePointer(this.PredictedResources);
            queueableBinaryWriter.Write(this.LightResponse);
            queueableBinaryWriter.Write(((short)(this.ShaderLODBias)));
            queueableBinaryWriter.Write(((short)(this.SpecularType)));
            queueableBinaryWriter.Write(((short)(this.LightmapType)));
            queueableBinaryWriter.Write(this.fieldpad1);
            queueableBinaryWriter.Write(this.LightmapSpecularBrightness);
            queueableBinaryWriter.Write(this.LightmapAmbientBias);
            queueableBinaryWriter.Write(this.AddedDepthBiasOffset);
            queueableBinaryWriter.Write(this.AddedDepthBiasSlopeScale);
        }
        [System.FlagsAttribute()]
        public enum Flags : short
        {
            None = 0,
            Water = 1,
            SortFirst = 2,
            NoActiveCamo = 4,
        }
        public enum ShaderLODBiasEnum : short
        {
            None = 0,
            _4xSize = 1,
            _2xSize = 2,
            _12Size = 3,
            _14Size = 4,
            Never = 5,
            Cinematic = 6,
        }
        public enum SpecularTypeEnum : short
        {
            None = 0,
            Default = 1,
            Dull = 2,
            Shiny = 3,
        }
        public enum LightmapTypeEnum : short
        {
            Diffuse = 0,
            DefaultSpecular = 1,
            DullSpecular = 2,
            ShinySpecular = 3,
        }
    }
}
namespace Moonfish.Tags
{
    
    public partial struct TagClass
    {
        public static TagClass Shad = ((TagClass)("shad"));
    }
}