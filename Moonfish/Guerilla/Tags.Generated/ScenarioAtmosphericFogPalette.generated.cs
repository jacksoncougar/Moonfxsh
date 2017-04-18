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
    
    public partial class ScenarioAtmosphericFogPalette : GuerillaBlock, IWriteQueueable
    {
        /// <summary>
        /// Editing Fog palette data will not behave as expected with split scenarios.
        /// </summary>
        public Moonfish.Tags.StringIdent Name;
        /// <summary>
        /// EMPTY STRING
        /// </summary>
        public Moonfish.Tags.ColourR8G8B8 Color;
        public float SpreadDistance;
        private byte[] fieldpad = new byte[4];
        public float MaximumDensity;
        public float StartDistance;
        public float OpaqueDistance;
        /// <summary>
        /// EMPTY STRING
        /// </summary>
        public Moonfish.Tags.ColourR8G8B8 Color0;
        private byte[] fieldpad0 = new byte[4];
        public float MaximumDensity0;
        public float StartDistance0;
        public float OpaqueDistance0;
        private byte[] fieldpad1 = new byte[4];
        /// <summary>
        /// Planar fog, if present, is interpolated toward these values.
        /// </summary>
        public Moonfish.Tags.ColourR8G8B8 PlanarColor;
        public float PlanarMaxDensity;
        public float PlanarOverrideAmount;
        public float PlanarMinDistanceBias;
        private byte[] fieldpad2 = new byte[44];
        /// <summary>
        /// EMPTY STRING
        /// </summary>
        public Moonfish.Tags.ColourR8G8B8 PatchyColor;
        private byte[] fieldpad3 = new byte[12];
        public OpenTK.Vector2 PatchyDensity;
        public Moonfish.Model.Range PatchyDistance;
        private byte[] fieldpad4 = new byte[32];
        [Moonfish.Tags.TagReferenceAttribute("fpch")]
        public Moonfish.Tags.TagReference PatchyFog;
        public ScenarioAtmosphericFogMixerBlock[] Mixers = new ScenarioAtmosphericFogMixerBlock[0];
        /// <summary>
        /// EMPTY STRING
        /// </summary>
        public float Amount;
        public float Threshold;
        public float Brightness;
        public float GammaPower;
        public CameraImmersionFlags ScenarioAtmosphericFogPaletteCameraImmersionFlags;
        private byte[] fieldpad5 = new byte[2];
        public override int SerializedSize
        {
            get
            {
                return 244;
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
            this.Name = binaryReader.ReadStringIdent();
            this.Color = binaryReader.ReadColorR8G8B8();
            this.SpreadDistance = binaryReader.ReadSingle();
            this.fieldpad = binaryReader.ReadBytes(4);
            this.MaximumDensity = binaryReader.ReadSingle();
            this.StartDistance = binaryReader.ReadSingle();
            this.OpaqueDistance = binaryReader.ReadSingle();
            this.Color0 = binaryReader.ReadColorR8G8B8();
            this.fieldpad0 = binaryReader.ReadBytes(4);
            this.MaximumDensity0 = binaryReader.ReadSingle();
            this.StartDistance0 = binaryReader.ReadSingle();
            this.OpaqueDistance0 = binaryReader.ReadSingle();
            this.fieldpad1 = binaryReader.ReadBytes(4);
            this.PlanarColor = binaryReader.ReadColorR8G8B8();
            this.PlanarMaxDensity = binaryReader.ReadSingle();
            this.PlanarOverrideAmount = binaryReader.ReadSingle();
            this.PlanarMinDistanceBias = binaryReader.ReadSingle();
            this.fieldpad2 = binaryReader.ReadBytes(44);
            this.PatchyColor = binaryReader.ReadColorR8G8B8();
            this.fieldpad3 = binaryReader.ReadBytes(12);
            this.PatchyDensity = binaryReader.ReadVector2();
            this.PatchyDistance = binaryReader.ReadRange();
            this.fieldpad4 = binaryReader.ReadBytes(32);
            this.PatchyFog = binaryReader.ReadTagReference();
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(16));
            this.Amount = binaryReader.ReadSingle();
            this.Threshold = binaryReader.ReadSingle();
            this.Brightness = binaryReader.ReadSingle();
            this.GammaPower = binaryReader.ReadSingle();
            this.ScenarioAtmosphericFogPaletteCameraImmersionFlags = ((CameraImmersionFlags)(binaryReader.ReadInt16()));
            this.fieldpad5 = binaryReader.ReadBytes(2);
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.Mixers = base.ReadBlockArrayData<ScenarioAtmosphericFogMixerBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.QueueWrites(queueableBlamBinaryWriter);
            queueableBlamBinaryWriter.QueueWrite(this.Mixers);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.Write_(queueableBlamBinaryWriter);
            queueableBlamBinaryWriter.Write(this.Name);
            queueableBlamBinaryWriter.Write(this.Color);
            queueableBlamBinaryWriter.Write(this.SpreadDistance);
            queueableBlamBinaryWriter.Write(this.fieldpad);
            queueableBlamBinaryWriter.Write(this.MaximumDensity);
            queueableBlamBinaryWriter.Write(this.StartDistance);
            queueableBlamBinaryWriter.Write(this.OpaqueDistance);
            queueableBlamBinaryWriter.Write(this.Color0);
            queueableBlamBinaryWriter.Write(this.fieldpad0);
            queueableBlamBinaryWriter.Write(this.MaximumDensity0);
            queueableBlamBinaryWriter.Write(this.StartDistance0);
            queueableBlamBinaryWriter.Write(this.OpaqueDistance0);
            queueableBlamBinaryWriter.Write(this.fieldpad1);
            queueableBlamBinaryWriter.Write(this.PlanarColor);
            queueableBlamBinaryWriter.Write(this.PlanarMaxDensity);
            queueableBlamBinaryWriter.Write(this.PlanarOverrideAmount);
            queueableBlamBinaryWriter.Write(this.PlanarMinDistanceBias);
            queueableBlamBinaryWriter.Write(this.fieldpad2);
            queueableBlamBinaryWriter.Write(this.PatchyColor);
            queueableBlamBinaryWriter.Write(this.fieldpad3);
            queueableBlamBinaryWriter.Write(this.PatchyDensity);
            queueableBlamBinaryWriter.Write(this.PatchyDistance);
            queueableBlamBinaryWriter.Write(this.fieldpad4);
            queueableBlamBinaryWriter.Write(this.PatchyFog);
            queueableBlamBinaryWriter.WritePointer(this.Mixers);
            queueableBlamBinaryWriter.Write(this.Amount);
            queueableBlamBinaryWriter.Write(this.Threshold);
            queueableBlamBinaryWriter.Write(this.Brightness);
            queueableBlamBinaryWriter.Write(this.GammaPower);
            queueableBlamBinaryWriter.Write(((short)(this.ScenarioAtmosphericFogPaletteCameraImmersionFlags)));
            queueableBlamBinaryWriter.Write(this.fieldpad5);
        }
        /// <summary>
        /// EMPTY STRING
        /// </summary>
        [System.FlagsAttribute()]
        public enum CameraImmersionFlags : short
        {
            None = 0,
            DisableAtmosphericFog = 1,
            DisableSecondaryFog = 2,
            DisablePlanarFog = 4,
            InvertPlanarFogPriorities = 8,
            DisableWater = 16,
        }
    }
}
