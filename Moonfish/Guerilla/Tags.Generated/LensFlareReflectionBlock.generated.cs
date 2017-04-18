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
    
    public partial class LensFlareReflectionBlock : GuerillaBlock, IWriteQueueable
    {
        public Flags LensFlareReflectionFlags;
        private byte[] fieldpad = new byte[2];
        public short BitmapIndex;
        private byte[] fieldpad0 = new byte[2];
        public float Position;
        public float RotationOffset;
        public Moonfish.Model.Range Radius;
        public OpenTK.Vector2 Brightness;
        /// <summary>
        /// Tinting and modulating are not the same; 'tinting' a reflection will color the darker regions but leave the highlights, while 'modulating' will color everything uniformly. The modulation factor controls how much the reflection is modulated as opposed to tinted (0 is tinted, 1 is modulated).
        /// </summary>
        public float ModulationFactor;
        public Moonfish.Tags.ColourR8G8B8 Color;
        public override int SerializedSize
        {
            get
            {
                return 48;
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
            this.LensFlareReflectionFlags = ((Flags)(binaryReader.ReadInt16()));
            this.fieldpad = binaryReader.ReadBytes(2);
            this.BitmapIndex = binaryReader.ReadInt16();
            this.fieldpad0 = binaryReader.ReadBytes(2);
            this.Position = binaryReader.ReadSingle();
            this.RotationOffset = binaryReader.ReadSingle();
            this.Radius = binaryReader.ReadRange();
            this.Brightness = binaryReader.ReadVector2();
            this.ModulationFactor = binaryReader.ReadSingle();
            this.Color = binaryReader.ReadColorR8G8B8();
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
            queueableBlamBinaryWriter.Write(((short)(this.LensFlareReflectionFlags)));
            queueableBlamBinaryWriter.Write(this.fieldpad);
            queueableBlamBinaryWriter.Write(this.BitmapIndex);
            queueableBlamBinaryWriter.Write(this.fieldpad0);
            queueableBlamBinaryWriter.Write(this.Position);
            queueableBlamBinaryWriter.Write(this.RotationOffset);
            queueableBlamBinaryWriter.Write(this.Radius);
            queueableBlamBinaryWriter.Write(this.Brightness);
            queueableBlamBinaryWriter.Write(this.ModulationFactor);
            queueableBlamBinaryWriter.Write(this.Color);
        }
        [System.FlagsAttribute()]
        public enum Flags : short
        {
            None = 0,
            AlignRotationWithScreenCenter = 1,
            RadiusNOTScaledByDistance = 2,
            RadiusScaledByOcclusionFactor = 4,
            OccludedBySolidObjects = 8,
            IgnoreLightColor = 16,
            NotAffectedByInnerOcclusion = 32,
        }
    }
}
