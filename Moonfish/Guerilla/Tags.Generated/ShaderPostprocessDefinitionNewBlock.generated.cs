//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Moonfish.Guerilla.Tags
{
    using JetBrains.Annotations;
    using Moonfish.Tags;
    using Moonfish.Model;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    
    [JetBrains.Annotations.UsedImplicitlyAttribute(ImplicitUseTargetFlags.WithMembers)]
    [TagBlockOriginalNameAttribute("shader_postprocess_definition_new_block")]
    public partial class ShaderPostprocessDefinitionNewBlock : GuerillaBlock, IWriteQueueable
    {
        public int ShaderTemplateIndex;
        public ShaderPostprocessBitmapNewBlock[] Bitmaps = new ShaderPostprocessBitmapNewBlock[0];
        public Pixel32Block[] PixelConstants = new Pixel32Block[0];
        public RealVector4dBlock[] VertexConstants = new RealVector4dBlock[0];
        public ShaderPostprocessLevelOfDetailNewBlock[] LevelsOfDetail = new ShaderPostprocessLevelOfDetailNewBlock[0];
        public TagBlockIndexBlock[] Layers = new TagBlockIndexBlock[0];
        public TagBlockIndexBlock[] Passes = new TagBlockIndexBlock[0];
        public ShaderPostprocessImplementationNewBlock[] Implementations = new ShaderPostprocessImplementationNewBlock[0];
        public ShaderPostprocessOverlayNewBlock[] Overlays = new ShaderPostprocessOverlayNewBlock[0];
        public ShaderPostprocessOverlayReferenceNewBlock[] OverlayReferences = new ShaderPostprocessOverlayReferenceNewBlock[0];
        public ShaderPostprocessAnimatedParameterNewBlock[] AnimatedParameters = new ShaderPostprocessAnimatedParameterNewBlock[0];
        public ShaderPostprocessAnimatedParameterReferenceNewBlock[] AnimatedParameterReferences = new ShaderPostprocessAnimatedParameterReferenceNewBlock[0];
        public ShaderPostprocessBitmapPropertyBlock[] BitmapProperties = new ShaderPostprocessBitmapPropertyBlock[0];
        public ShaderPostprocessColorPropertyBlock[] ColorProperties = new ShaderPostprocessColorPropertyBlock[0];
        public ShaderPostprocessValuePropertyBlock[] ValueProperties = new ShaderPostprocessValuePropertyBlock[0];
        public ShaderPostprocessLevelOfDetailBlock[] OldLevelsOfDetail = new ShaderPostprocessLevelOfDetailBlock[0];
        public override int SerializedSize
        {
            get
            {
                return 124;
            }
        }
        public override int Alignment
        {
            get
            {
                return 4;
            }
        }
        public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(Moonfish.Guerilla.BlamBinaryReader binaryReader)
        {
            System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
            this.ShaderTemplateIndex = binaryReader.ReadInt32();
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(12));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(4));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(16));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(6));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(2));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(2));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(10));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(20));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(4));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(2));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(4));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(4));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(12));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(4));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(152));
            return pointerQueue;
        }
        public override void ReadInstances(Moonfish.Guerilla.BlamBinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.Bitmaps = base.ReadBlockArrayData<ShaderPostprocessBitmapNewBlock>(binaryReader, pointerQueue.Dequeue());
            this.PixelConstants = base.ReadBlockArrayData<Pixel32Block>(binaryReader, pointerQueue.Dequeue());
            this.VertexConstants = base.ReadBlockArrayData<RealVector4dBlock>(binaryReader, pointerQueue.Dequeue());
            this.LevelsOfDetail = base.ReadBlockArrayData<ShaderPostprocessLevelOfDetailNewBlock>(binaryReader, pointerQueue.Dequeue());
            this.Layers = base.ReadBlockArrayData<TagBlockIndexBlock>(binaryReader, pointerQueue.Dequeue());
            this.Passes = base.ReadBlockArrayData<TagBlockIndexBlock>(binaryReader, pointerQueue.Dequeue());
            this.Implementations = base.ReadBlockArrayData<ShaderPostprocessImplementationNewBlock>(binaryReader, pointerQueue.Dequeue());
            this.Overlays = base.ReadBlockArrayData<ShaderPostprocessOverlayNewBlock>(binaryReader, pointerQueue.Dequeue());
            this.OverlayReferences = base.ReadBlockArrayData<ShaderPostprocessOverlayReferenceNewBlock>(binaryReader, pointerQueue.Dequeue());
            this.AnimatedParameters = base.ReadBlockArrayData<ShaderPostprocessAnimatedParameterNewBlock>(binaryReader, pointerQueue.Dequeue());
            this.AnimatedParameterReferences = base.ReadBlockArrayData<ShaderPostprocessAnimatedParameterReferenceNewBlock>(binaryReader, pointerQueue.Dequeue());
            this.BitmapProperties = base.ReadBlockArrayData<ShaderPostprocessBitmapPropertyBlock>(binaryReader, pointerQueue.Dequeue());
            this.ColorProperties = base.ReadBlockArrayData<ShaderPostprocessColorPropertyBlock>(binaryReader, pointerQueue.Dequeue());
            this.ValueProperties = base.ReadBlockArrayData<ShaderPostprocessValuePropertyBlock>(binaryReader, pointerQueue.Dequeue());
            this.OldLevelsOfDetail = base.ReadBlockArrayData<ShaderPostprocessLevelOfDetailBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            queueableBinaryWriter.QueueWrite(this.Bitmaps);
            queueableBinaryWriter.QueueWrite(this.PixelConstants);
            queueableBinaryWriter.QueueWrite(this.VertexConstants);
            queueableBinaryWriter.QueueWrite(this.LevelsOfDetail);
            queueableBinaryWriter.QueueWrite(this.Layers);
            queueableBinaryWriter.QueueWrite(this.Passes);
            queueableBinaryWriter.QueueWrite(this.Implementations);
            queueableBinaryWriter.QueueWrite(this.Overlays);
            queueableBinaryWriter.QueueWrite(this.OverlayReferences);
            queueableBinaryWriter.QueueWrite(this.AnimatedParameters);
            queueableBinaryWriter.QueueWrite(this.AnimatedParameterReferences);
            queueableBinaryWriter.QueueWrite(this.BitmapProperties);
            queueableBinaryWriter.QueueWrite(this.ColorProperties);
            queueableBinaryWriter.QueueWrite(this.ValueProperties);
            queueableBinaryWriter.QueueWrite(this.OldLevelsOfDetail);
        }
        public override void Write(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBinaryWriter)
        {
            base.Write(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.ShaderTemplateIndex);
            queueableBinaryWriter.WritePointer(this.Bitmaps);
            queueableBinaryWriter.WritePointer(this.PixelConstants);
            queueableBinaryWriter.WritePointer(this.VertexConstants);
            queueableBinaryWriter.WritePointer(this.LevelsOfDetail);
            queueableBinaryWriter.WritePointer(this.Layers);
            queueableBinaryWriter.WritePointer(this.Passes);
            queueableBinaryWriter.WritePointer(this.Implementations);
            queueableBinaryWriter.WritePointer(this.Overlays);
            queueableBinaryWriter.WritePointer(this.OverlayReferences);
            queueableBinaryWriter.WritePointer(this.AnimatedParameters);
            queueableBinaryWriter.WritePointer(this.AnimatedParameterReferences);
            queueableBinaryWriter.WritePointer(this.BitmapProperties);
            queueableBinaryWriter.WritePointer(this.ColorProperties);
            queueableBinaryWriter.WritePointer(this.ValueProperties);
            queueableBinaryWriter.WritePointer(this.OldLevelsOfDetail);
        }
    }
}
