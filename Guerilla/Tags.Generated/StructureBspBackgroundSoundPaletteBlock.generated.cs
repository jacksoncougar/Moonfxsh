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
    
    public partial class StructureBspBackgroundSoundPaletteBlock : GuerillaBlock, IWriteQueueable
    {
        public Moonfish.Tags.String32 Name;
        [Moonfish.Tags.TagReferenceAttribute("lsnd")]
        public Moonfish.Tags.TagReference BackgroundSound;
        [Moonfish.Tags.TagReferenceAttribute("lsnd")]
        public Moonfish.Tags.TagReference InsideClusterSound;
        private byte[] fieldpad = new byte[20];
        public float CutoffDistance;
        public ScaleFlags StructureBspBackgroundSoundPaletteScaleFlags;
        public float InteriorScale;
        public float PortalScale;
        public float ExteriorScale;
        public float InterpolationSpeed;
        private byte[] fieldpad0 = new byte[8];
        public override int SerializedSize
        {
            get
            {
                return 100;
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
            this.Name = binaryReader.ReadString32();
            this.BackgroundSound = binaryReader.ReadTagReference();
            this.InsideClusterSound = binaryReader.ReadTagReference();
            this.fieldpad = binaryReader.ReadBytes(20);
            this.CutoffDistance = binaryReader.ReadSingle();
            this.StructureBspBackgroundSoundPaletteScaleFlags = ((ScaleFlags)(binaryReader.ReadInt32()));
            this.InteriorScale = binaryReader.ReadSingle();
            this.PortalScale = binaryReader.ReadSingle();
            this.ExteriorScale = binaryReader.ReadSingle();
            this.InterpolationSpeed = binaryReader.ReadSingle();
            this.fieldpad0 = binaryReader.ReadBytes(8);
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.Name);
            queueableBinaryWriter.Write(this.BackgroundSound);
            queueableBinaryWriter.Write(this.InsideClusterSound);
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.Write(this.CutoffDistance);
            queueableBinaryWriter.Write(((int)(this.StructureBspBackgroundSoundPaletteScaleFlags)));
            queueableBinaryWriter.Write(this.InteriorScale);
            queueableBinaryWriter.Write(this.PortalScale);
            queueableBinaryWriter.Write(this.ExteriorScale);
            queueableBinaryWriter.Write(this.InterpolationSpeed);
            queueableBinaryWriter.Write(this.fieldpad0);
        }
        [System.FlagsAttribute()]
        public enum ScaleFlags : int
        {
            None = 0,
            OverrideDefaultScale = 1,
            UseAdjacentClusterAsPortalScale = 2,
            UseAdjacentClusterAsExteriorScale = 4,
            ScaleWithWeatherIntensity = 8,
        }
    }
}
