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
    
    public partial class InterfaceTagReferences : GuerillaBlock, IWriteQueueable
    {
        [Moonfish.Tags.TagReferenceAttribute("bitm")]
        public Moonfish.Tags.TagReference Obsolete1;
        [Moonfish.Tags.TagReferenceAttribute("bitm")]
        public Moonfish.Tags.TagReference Obsolete2;
        [Moonfish.Tags.TagReferenceAttribute("colo")]
        public Moonfish.Tags.TagReference ScreenColorTable;
        [Moonfish.Tags.TagReferenceAttribute("colo")]
        public Moonfish.Tags.TagReference HudColorTable;
        [Moonfish.Tags.TagReferenceAttribute("colo")]
        public Moonfish.Tags.TagReference EditorColorTable;
        [Moonfish.Tags.TagReferenceAttribute("colo")]
        public Moonfish.Tags.TagReference DialogColorTable;
        [Moonfish.Tags.TagReferenceAttribute("hudg")]
        public Moonfish.Tags.TagReference HudGlobals;
        [Moonfish.Tags.TagReferenceAttribute("bitm")]
        public Moonfish.Tags.TagReference MotionSensorSweepBitmap;
        [Moonfish.Tags.TagReferenceAttribute("bitm")]
        public Moonfish.Tags.TagReference MotionSensorSweepBitmapMask;
        [Moonfish.Tags.TagReferenceAttribute("bitm")]
        public Moonfish.Tags.TagReference MultiplayerHudBitmap;
        [Moonfish.Tags.TagReferenceAttribute("null")]
        public Moonfish.Tags.TagReference TagReference;
        [Moonfish.Tags.TagReferenceAttribute("hud#")]
        public Moonfish.Tags.TagReference HudDigitsDefinition;
        [Moonfish.Tags.TagReferenceAttribute("bitm")]
        public Moonfish.Tags.TagReference MotionSensorBlipBitmap;
        [Moonfish.Tags.TagReferenceAttribute("bitm")]
        public Moonfish.Tags.TagReference InterfaceGooMap1;
        [Moonfish.Tags.TagReferenceAttribute("bitm")]
        public Moonfish.Tags.TagReference InterfaceGooMap2;
        [Moonfish.Tags.TagReferenceAttribute("bitm")]
        public Moonfish.Tags.TagReference InterfaceGooMap3;
        [Moonfish.Tags.TagReferenceAttribute("wgtz")]
        public Moonfish.Tags.TagReference MainmenuUiGlobals;
        [Moonfish.Tags.TagReferenceAttribute("wgtz")]
        public Moonfish.Tags.TagReference SingleplayerUiGlobals;
        [Moonfish.Tags.TagReferenceAttribute("wgtz")]
        public Moonfish.Tags.TagReference MultiplayerUiGlobals;
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
            this.Obsolete1 = binaryReader.ReadTagReference();
            this.Obsolete2 = binaryReader.ReadTagReference();
            this.ScreenColorTable = binaryReader.ReadTagReference();
            this.HudColorTable = binaryReader.ReadTagReference();
            this.EditorColorTable = binaryReader.ReadTagReference();
            this.DialogColorTable = binaryReader.ReadTagReference();
            this.HudGlobals = binaryReader.ReadTagReference();
            this.MotionSensorSweepBitmap = binaryReader.ReadTagReference();
            this.MotionSensorSweepBitmapMask = binaryReader.ReadTagReference();
            this.MultiplayerHudBitmap = binaryReader.ReadTagReference();
            this.TagReference = binaryReader.ReadTagReference();
            this.HudDigitsDefinition = binaryReader.ReadTagReference();
            this.MotionSensorBlipBitmap = binaryReader.ReadTagReference();
            this.InterfaceGooMap1 = binaryReader.ReadTagReference();
            this.InterfaceGooMap2 = binaryReader.ReadTagReference();
            this.InterfaceGooMap3 = binaryReader.ReadTagReference();
            this.MainmenuUiGlobals = binaryReader.ReadTagReference();
            this.SingleplayerUiGlobals = binaryReader.ReadTagReference();
            this.MultiplayerUiGlobals = binaryReader.ReadTagReference();
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
            queueableBlamBinaryWriter.Write(this.Obsolete1);
            queueableBlamBinaryWriter.Write(this.Obsolete2);
            queueableBlamBinaryWriter.Write(this.ScreenColorTable);
            queueableBlamBinaryWriter.Write(this.HudColorTable);
            queueableBlamBinaryWriter.Write(this.EditorColorTable);
            queueableBlamBinaryWriter.Write(this.DialogColorTable);
            queueableBlamBinaryWriter.Write(this.HudGlobals);
            queueableBlamBinaryWriter.Write(this.MotionSensorSweepBitmap);
            queueableBlamBinaryWriter.Write(this.MotionSensorSweepBitmapMask);
            queueableBlamBinaryWriter.Write(this.MultiplayerHudBitmap);
            queueableBlamBinaryWriter.Write(this.TagReference);
            queueableBlamBinaryWriter.Write(this.HudDigitsDefinition);
            queueableBlamBinaryWriter.Write(this.MotionSensorBlipBitmap);
            queueableBlamBinaryWriter.Write(this.InterfaceGooMap1);
            queueableBlamBinaryWriter.Write(this.InterfaceGooMap2);
            queueableBlamBinaryWriter.Write(this.InterfaceGooMap3);
            queueableBlamBinaryWriter.Write(this.MainmenuUiGlobals);
            queueableBlamBinaryWriter.Write(this.SingleplayerUiGlobals);
            queueableBlamBinaryWriter.Write(this.MultiplayerUiGlobals);
        }
    }
}
