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
    
    public partial class LightingVariablesBlock : GuerillaBlock, IWriteQueueable
    {
        public ObjectAffected LightingVariablesObjectAffected;
        /// <summary>
        /// EMPTY STRING
        /// </summary>
        public float LightmapBrightnessOffset;
        public PrimaryLightStructBlock PrimaryLight = new PrimaryLightStructBlock();
        public SecondaryLightStructBlock SecondaryLight = new SecondaryLightStructBlock();
        public AmbientLightStructBlock AmbientLight = new AmbientLightStructBlock();
        public LightmapShadowsStructBlock LightmapShadows = new LightmapShadowsStructBlock();
        public override int SerializedSize
        {
            get
            {
                return 144;
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
            this.LightingVariablesObjectAffected = ((ObjectAffected)(binaryReader.ReadInt32()));
            this.LightmapBrightnessOffset = binaryReader.ReadSingle();
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.PrimaryLight.ReadFields(binaryReader)));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.SecondaryLight.ReadFields(binaryReader)));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.AmbientLight.ReadFields(binaryReader)));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.LightmapShadows.ReadFields(binaryReader)));
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.PrimaryLight.ReadInstances(binaryReader, pointerQueue);
            this.SecondaryLight.ReadInstances(binaryReader, pointerQueue);
            this.AmbientLight.ReadInstances(binaryReader, pointerQueue);
            this.LightmapShadows.ReadInstances(binaryReader, pointerQueue);
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.QueueWrites(queueableBlamBinaryWriter);
            this.PrimaryLight.QueueWrites(queueableBlamBinaryWriter);
            this.SecondaryLight.QueueWrites(queueableBlamBinaryWriter);
            this.AmbientLight.QueueWrites(queueableBlamBinaryWriter);
            this.LightmapShadows.QueueWrites(queueableBlamBinaryWriter);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.Write_(queueableBlamBinaryWriter);
            queueableBlamBinaryWriter.Write(((int)(this.LightingVariablesObjectAffected)));
            queueableBlamBinaryWriter.Write(this.LightmapBrightnessOffset);
            this.PrimaryLight.Write_(queueableBlamBinaryWriter);
            this.SecondaryLight.Write_(queueableBlamBinaryWriter);
            this.AmbientLight.Write_(queueableBlamBinaryWriter);
            this.LightmapShadows.Write_(queueableBlamBinaryWriter);
        }
        [System.FlagsAttribute()]
        public enum ObjectAffected : int
        {
            None = 0,
            All = 1,
            Biped = 2,
            Vehicle = 4,
            Weapon = 8,
            Equipment = 16,
            Garbage = 32,
            Projectile = 64,
            Scenery = 128,
            Machine = 256,
            Control = 512,
            LightFixture = 1024,
            SoundScenery = 2048,
            Crate = 4096,
            Creature = 8192,
        }
    }
}
