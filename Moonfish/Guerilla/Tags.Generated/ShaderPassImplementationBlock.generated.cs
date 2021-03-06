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
    
    public partial class ShaderPassImplementationBlock : GuerillaBlock, IWriteQueueable
    {
        public Flags ShaderPassImplementationFlags;
        private byte[] fieldpad = new byte[2];
        public ShaderPassTextureBlock[] Textures = new ShaderPassTextureBlock[0];
        /// <summary>
        /// EMPTY STRING
        /// </summary>
        [Moonfish.Tags.TagReferenceAttribute("vrtx")]
        public Moonfish.Tags.TagReference VertexShader;
        public ShaderPassVertexShaderConstantBlock[] VsConstants = new ShaderPassVertexShaderConstantBlock[0];
        public byte[] PixelShaderCodeNOLONGERUSED;
        public ChannelsEnum Channels;
        public AlphablendEnum Alphablend;
        public DepthEnum Depth;
        private byte[] fieldpad0 = new byte[2];
        public ShaderStateChannelsStateBlock[] ChannelState = new ShaderStateChannelsStateBlock[0];
        public ShaderStateAlphaBlendStateBlock[] AlphablendState = new ShaderStateAlphaBlendStateBlock[0];
        public ShaderStateAlphaTestStateBlock[] AlphatestState = new ShaderStateAlphaTestStateBlock[0];
        public ShaderStateDepthStateBlock[] DepthState = new ShaderStateDepthStateBlock[0];
        public ShaderStateCullStateBlock[] CullState = new ShaderStateCullStateBlock[0];
        public ShaderStateFillStateBlock[] FillState = new ShaderStateFillStateBlock[0];
        public ShaderStateMiscStateBlock[] MiscState = new ShaderStateMiscStateBlock[0];
        public ShaderStateConstantBlock[] Constants = new ShaderStateConstantBlock[0];
        [Moonfish.Tags.TagReferenceAttribute("pixl")]
        public Moonfish.Tags.TagReference PixelShader;
        public override int SerializedSize
        {
            get
            {
                return 116;
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
            this.ShaderPassImplementationFlags = ((Flags)(binaryReader.ReadInt16()));
            this.fieldpad = binaryReader.ReadBytes(2);
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(60));
            this.VertexShader = binaryReader.ReadTagReference();
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(12));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(1));
            this.Channels = ((ChannelsEnum)(binaryReader.ReadInt16()));
            this.Alphablend = ((AlphablendEnum)(binaryReader.ReadInt16()));
            this.Depth = ((DepthEnum)(binaryReader.ReadInt16()));
            this.fieldpad0 = binaryReader.ReadBytes(2);
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(4));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(16));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(8));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(16));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(4));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(12));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(7));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(8));
            this.PixelShader = binaryReader.ReadTagReference();
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.Textures = base.ReadBlockArrayData<ShaderPassTextureBlock>(binaryReader, pointerQueue.Dequeue());
            this.VsConstants = base.ReadBlockArrayData<ShaderPassVertexShaderConstantBlock>(binaryReader, pointerQueue.Dequeue());
            this.PixelShaderCodeNOLONGERUSED = base.ReadDataByteArray(binaryReader, pointerQueue.Dequeue());
            this.ChannelState = base.ReadBlockArrayData<ShaderStateChannelsStateBlock>(binaryReader, pointerQueue.Dequeue());
            this.AlphablendState = base.ReadBlockArrayData<ShaderStateAlphaBlendStateBlock>(binaryReader, pointerQueue.Dequeue());
            this.AlphatestState = base.ReadBlockArrayData<ShaderStateAlphaTestStateBlock>(binaryReader, pointerQueue.Dequeue());
            this.DepthState = base.ReadBlockArrayData<ShaderStateDepthStateBlock>(binaryReader, pointerQueue.Dequeue());
            this.CullState = base.ReadBlockArrayData<ShaderStateCullStateBlock>(binaryReader, pointerQueue.Dequeue());
            this.FillState = base.ReadBlockArrayData<ShaderStateFillStateBlock>(binaryReader, pointerQueue.Dequeue());
            this.MiscState = base.ReadBlockArrayData<ShaderStateMiscStateBlock>(binaryReader, pointerQueue.Dequeue());
            this.Constants = base.ReadBlockArrayData<ShaderStateConstantBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            queueableBinaryWriter.QueueWrite(this.Textures);
            queueableBinaryWriter.QueueWrite(this.VsConstants);
            queueableBinaryWriter.QueueWrite(this.PixelShaderCodeNOLONGERUSED);
            queueableBinaryWriter.QueueWrite(this.ChannelState);
            queueableBinaryWriter.QueueWrite(this.AlphablendState);
            queueableBinaryWriter.QueueWrite(this.AlphatestState);
            queueableBinaryWriter.QueueWrite(this.DepthState);
            queueableBinaryWriter.QueueWrite(this.CullState);
            queueableBinaryWriter.QueueWrite(this.FillState);
            queueableBinaryWriter.QueueWrite(this.MiscState);
            queueableBinaryWriter.QueueWrite(this.Constants);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(((short)(this.ShaderPassImplementationFlags)));
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.WritePointer(this.Textures);
            queueableBinaryWriter.Write(this.VertexShader);
            queueableBinaryWriter.WritePointer(this.VsConstants);
            queueableBinaryWriter.WritePointer(this.PixelShaderCodeNOLONGERUSED);
            queueableBinaryWriter.Write(((short)(this.Channels)));
            queueableBinaryWriter.Write(((short)(this.Alphablend)));
            queueableBinaryWriter.Write(((short)(this.Depth)));
            queueableBinaryWriter.Write(this.fieldpad0);
            queueableBinaryWriter.WritePointer(this.ChannelState);
            queueableBinaryWriter.WritePointer(this.AlphablendState);
            queueableBinaryWriter.WritePointer(this.AlphatestState);
            queueableBinaryWriter.WritePointer(this.DepthState);
            queueableBinaryWriter.WritePointer(this.CullState);
            queueableBinaryWriter.WritePointer(this.FillState);
            queueableBinaryWriter.WritePointer(this.MiscState);
            queueableBinaryWriter.WritePointer(this.Constants);
            queueableBinaryWriter.Write(this.PixelShader);
        }
        [System.FlagsAttribute()]
        public enum Flags : short
        {
            None = 0,
            DeleteFromCacheFile = 1,
            Critical = 2,
        }
        /// <summary>
        /// EMPTY STRING
        /// </summary>
        public enum ChannelsEnum : short
        {
            All = 0,
            ColorOnly = 1,
            AlphaOnly = 2,
            Custom = 3,
        }
        public enum AlphablendEnum : short
        {
            Disabled = 0,
            Add = 1,
            Multiply = 2,
            AddSrcTimesDstalpha = 3,
            AddSrcTimesSrcalpha = 4,
            AddDstTimesSrcalphaInverse = 5,
            AlphaBlend = 6,
            Custom = 7,
        }
        public enum DepthEnum : short
        {
            Disabled = 0,
            DefaultOpaque = 1,
            DefaultOpaqueWrite = 2,
            DefaultTransparent = 3,
            Custom = 4,
        }
    }
}
