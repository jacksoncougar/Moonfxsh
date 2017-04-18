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
    
    public partial class ScreenFlashDefinitionStructBlock : GuerillaBlock, IWriteQueueable
    {
        public TypeEnum Type;
        public PriorityEnum Priority;
        public float Duration;
        public FadeFunctionEnum FadeFunction;
        private byte[] fieldpad = new byte[2];
        public float MaximumIntensity;
        public OpenTK.Vector4 Color;
        public override int SerializedSize
        {
            get
            {
                return 32;
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
            this.Type = ((TypeEnum)(binaryReader.ReadInt16()));
            this.Priority = ((PriorityEnum)(binaryReader.ReadInt16()));
            this.Duration = binaryReader.ReadSingle();
            this.FadeFunction = ((FadeFunctionEnum)(binaryReader.ReadInt16()));
            this.fieldpad = binaryReader.ReadBytes(2);
            this.MaximumIntensity = binaryReader.ReadSingle();
            this.Color = binaryReader.ReadVector4();
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.QueueWrites(queueableBlamBinaryWriter);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.Write_(queueableBlamBinaryWriter);
            queueableBlamBinaryWriter.Write(((short)(this.Type)));
            queueableBlamBinaryWriter.Write(((short)(this.Priority)));
            queueableBlamBinaryWriter.Write(this.Duration);
            queueableBlamBinaryWriter.Write(((short)(this.FadeFunction)));
            queueableBlamBinaryWriter.Write(this.fieldpad);
            queueableBlamBinaryWriter.Write(this.MaximumIntensity);
            queueableBlamBinaryWriter.Write(this.Color);
        }
        /// <summary>
        /// There are seven screen flash types:
        ///
        ///NONE: DST'= DST
        ///LIGHTEN: DST'= DST(1 - A) + C
        ///DARKEN: DST'= DST(1 - A) - C
        ///MAX: DST'= MAX[DST(1 - C), (C - A)(1-DST)]
        ///MIN: DST'= MIN[DST(1 - C), (C + A)(1-DST)]
        ///TINT: DST'= DST(1 - C) + (A
        /// </summary>
        public enum TypeEnum : short
        {
            /// <summary>
            /// PIN[2C - 1, 0, 1] + A)(1-DST)
            /// INVERT: DST'= DST(1 - C) + A)
            /// 
            /// In the above equations C and A represent the color and alpha of the screen flash, DST represents the color in the framebuffer before the screen flash is applied, and DST' represents the color after the screen flash is applied.
            /// </summary>
            None = 0,
            Lighten = 1,
            Darken = 2,
            Max = 3,
            Min = 4,
            Invert = 5,
            Tint = 6,
        }
        public enum PriorityEnum : short
        {
            Low = 0,
            Medium = 1,
            High = 2,
        }
        public enum FadeFunctionEnum : short
        {
            Linear = 0,
            Late = 1,
            VeryLate = 2,
            Early = 3,
            VeryEarly = 4,
            Cosine = 5,
            Zero = 6,
            One = 7,
        }
    }
}
