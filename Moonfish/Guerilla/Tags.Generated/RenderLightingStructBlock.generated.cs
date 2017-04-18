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
    
    public partial class RenderLightingStructBlock : GuerillaBlock, IWriteQueueable
    {
        public Moonfish.Tags.ColourR8G8B8 Ambient;
        public OpenTK.Vector3 ShadowDirection;
        public float LightingAccuracy;
        public float ShadowOpacity;
        public Moonfish.Tags.ColourR8G8B8 PrimaryDirectionColor;
        public OpenTK.Vector3 PrimaryDirection;
        public Moonfish.Tags.ColourR8G8B8 SecondaryDirectionColor;
        public OpenTK.Vector3 SecondaryDirection;
        public short ShIndex;
        private byte[] fieldpad = new byte[2];
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
            this.Ambient = binaryReader.ReadColorR8G8B8();
            this.ShadowDirection = binaryReader.ReadVector3();
            this.LightingAccuracy = binaryReader.ReadSingle();
            this.ShadowOpacity = binaryReader.ReadSingle();
            this.PrimaryDirectionColor = binaryReader.ReadColorR8G8B8();
            this.PrimaryDirection = binaryReader.ReadVector3();
            this.SecondaryDirectionColor = binaryReader.ReadColorR8G8B8();
            this.SecondaryDirection = binaryReader.ReadVector3();
            this.ShIndex = binaryReader.ReadInt16();
            this.fieldpad = binaryReader.ReadBytes(2);
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
            queueableBlamBinaryWriter.Write(this.Ambient);
            queueableBlamBinaryWriter.Write(this.ShadowDirection);
            queueableBlamBinaryWriter.Write(this.LightingAccuracy);
            queueableBlamBinaryWriter.Write(this.ShadowOpacity);
            queueableBlamBinaryWriter.Write(this.PrimaryDirectionColor);
            queueableBlamBinaryWriter.Write(this.PrimaryDirection);
            queueableBlamBinaryWriter.Write(this.SecondaryDirectionColor);
            queueableBlamBinaryWriter.Write(this.SecondaryDirection);
            queueableBlamBinaryWriter.Write(this.ShIndex);
            queueableBlamBinaryWriter.Write(this.fieldpad);
        }
    }
}
