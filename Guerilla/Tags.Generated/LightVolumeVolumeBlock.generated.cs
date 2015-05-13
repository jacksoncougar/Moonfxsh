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
    
    public partial class LightVolumeVolumeBlock : GuerillaBlock, IWriteQueueable
    {
        public Flags LightVolumeVolumeFlags;
        [Moonfish.Tags.TagReferenceAttribute("bitm")]
        public Moonfish.Tags.TagReference Bitmap;
        public int SpriteCount;
        public ScalarFunctionStructBlock OffsetFunction = new ScalarFunctionStructBlock();
        public ScalarFunctionStructBlock RadiusFunction = new ScalarFunctionStructBlock();
        public ScalarFunctionStructBlock BrightnessFunction = new ScalarFunctionStructBlock();
        public ColorFunctionStructBlock ColorFunction = new ColorFunctionStructBlock();
        public ScalarFunctionStructBlock FacingFunction = new ScalarFunctionStructBlock();
        public LightVolumeAspectBlock[] Aspect = new LightVolumeAspectBlock[0];
        /// <summary>
        /// ADVANCED STUFF!! Don't change these values!!
        /// </summary>
        public float RadiusFracMin;
        public float DEPRECATEDXstepExponent;
        public int DEPRECATEDXbufferLength;
        public int XbufferSpacing;
        public int XbufferMinIterations;
        public int XbufferMaxIterations;
        public float XdeltaMaxError;
        private byte[] fieldskip = new byte[4];
        public LightVolumeRuntimeOffsetBlock[] LightVolumeRuntimeOffsetBlock = new LightVolumeRuntimeOffsetBlock[0];
        private byte[] fieldskip0 = new byte[48];
        public override int SerializedSize
        {
            get
            {
                return 152;
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
            this.LightVolumeVolumeFlags = ((Flags)(binaryReader.ReadInt32()));
            this.Bitmap = binaryReader.ReadTagReference();
            this.SpriteCount = binaryReader.ReadInt32();
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.OffsetFunction.ReadFields(binaryReader)));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.RadiusFunction.ReadFields(binaryReader)));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.BrightnessFunction.ReadFields(binaryReader)));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.ColorFunction.ReadFields(binaryReader)));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.FacingFunction.ReadFields(binaryReader)));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(28));
            this.RadiusFracMin = binaryReader.ReadSingle();
            this.DEPRECATEDXstepExponent = binaryReader.ReadSingle();
            this.DEPRECATEDXbufferLength = binaryReader.ReadInt32();
            this.XbufferSpacing = binaryReader.ReadInt32();
            this.XbufferMinIterations = binaryReader.ReadInt32();
            this.XbufferMaxIterations = binaryReader.ReadInt32();
            this.XdeltaMaxError = binaryReader.ReadSingle();
            this.fieldskip = binaryReader.ReadBytes(4);
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(8));
            this.fieldskip0 = binaryReader.ReadBytes(48);
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.OffsetFunction.ReadInstances(binaryReader, pointerQueue);
            this.RadiusFunction.ReadInstances(binaryReader, pointerQueue);
            this.BrightnessFunction.ReadInstances(binaryReader, pointerQueue);
            this.ColorFunction.ReadInstances(binaryReader, pointerQueue);
            this.FacingFunction.ReadInstances(binaryReader, pointerQueue);
            this.Aspect = base.ReadBlockArrayData<LightVolumeAspectBlock>(binaryReader, pointerQueue.Dequeue());
            this.LightVolumeRuntimeOffsetBlock = base.ReadBlockArrayData<LightVolumeRuntimeOffsetBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            this.OffsetFunction.QueueWrites(queueableBinaryWriter);
            this.RadiusFunction.QueueWrites(queueableBinaryWriter);
            this.BrightnessFunction.QueueWrites(queueableBinaryWriter);
            this.ColorFunction.QueueWrites(queueableBinaryWriter);
            this.FacingFunction.QueueWrites(queueableBinaryWriter);
            queueableBinaryWriter.QueueWrite(this.Aspect);
            queueableBinaryWriter.QueueWrite(this.LightVolumeRuntimeOffsetBlock);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(((int)(this.LightVolumeVolumeFlags)));
            queueableBinaryWriter.Write(this.Bitmap);
            queueableBinaryWriter.Write(this.SpriteCount);
            this.OffsetFunction.Write_(queueableBinaryWriter);
            this.RadiusFunction.Write_(queueableBinaryWriter);
            this.BrightnessFunction.Write_(queueableBinaryWriter);
            this.ColorFunction.Write_(queueableBinaryWriter);
            this.FacingFunction.Write_(queueableBinaryWriter);
            queueableBinaryWriter.WritePointer(this.Aspect);
            queueableBinaryWriter.Write(this.RadiusFracMin);
            queueableBinaryWriter.Write(this.DEPRECATEDXstepExponent);
            queueableBinaryWriter.Write(this.DEPRECATEDXbufferLength);
            queueableBinaryWriter.Write(this.XbufferSpacing);
            queueableBinaryWriter.Write(this.XbufferMinIterations);
            queueableBinaryWriter.Write(this.XbufferMaxIterations);
            queueableBinaryWriter.Write(this.XdeltaMaxError);
            queueableBinaryWriter.Write(this.fieldskip);
            queueableBinaryWriter.WritePointer(this.LightVolumeRuntimeOffsetBlock);
            queueableBinaryWriter.Write(this.fieldskip0);
        }
        /// <summary>
        /// If no bitmap is selected, the default glow bitmap will be used. Sprite count controls how many sprites are used to render this volume. Using more sprites will result in a smoother and brighter effect, at a slight performance penalty. Don't touch the flags unless you know what you're doing (they should be off by default).
        ///
        ///Be careful with the 'fuzzy' flag! It should be used on very wide light volumes to make them blend smoothly into solid geometry rather than "cutting" into the zbuffer. Using this feature will make light volumes several times slower when they fill a large portion of the screen.
        /// </summary>
        [System.FlagsAttribute()]
        public enum Flags : int
        {
            None = 0,
            ForceLinearRadiusFunction = 1,
            ForceLinearOffset = 2,
            ForceDifferentialEvaluation = 4,
            Fuzzy = 8,
            NotScaledByEventDuration = 16,
            ScaledByMarker = 32,
        }
    }
}
