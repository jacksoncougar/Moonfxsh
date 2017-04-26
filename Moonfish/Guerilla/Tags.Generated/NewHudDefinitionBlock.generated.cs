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
    [TagClassAttribute("nhdt")]
    [TagBlockOriginalNameAttribute("new_hud_definition_block")]
    public partial class NewHudDefinitionBlock : GuerillaBlock, IWriteDeferrable
    {
        [Moonfish.Tags.TagReferenceAttribute("nhdt")]
        public Moonfish.Tags.TagReference DONOTUSE;
        public HudBitmapWidgets[] BitmapWidgets = new HudBitmapWidgets[0];
        public HudTextWidgets[] TextWidgets = new HudTextWidgets[0];
        public NewHudDashlightDataStructBlock DashlightData = new NewHudDashlightDataStructBlock();
        public HudScreenEffectWidgets[] ScreenEffectWidgets = new HudScreenEffectWidgets[0];
        public override int SerializedSize
        {
            get
            {
                return 40;
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
            this.DONOTUSE = binaryReader.ReadTagReference();
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(100));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(84));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.DashlightData.ReadFields(binaryReader)));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(80));
            return pointerQueue;
        }
        public override void ReadInstances(Moonfish.Guerilla.BlamBinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.BitmapWidgets = base.ReadBlockArrayData<HudBitmapWidgets>(binaryReader, pointerQueue.Dequeue());
            this.TextWidgets = base.ReadBlockArrayData<HudTextWidgets>(binaryReader, pointerQueue.Dequeue());
            this.DashlightData.ReadInstances(binaryReader, pointerQueue);
            this.ScreenEffectWidgets = base.ReadBlockArrayData<HudScreenEffectWidgets>(binaryReader, pointerQueue.Dequeue());
        }
        public override void DeferReferences(Moonfish.Guerilla.LinearBinaryWriter queueableBinaryWriter)
        {
            base.DeferReferences(queueableBinaryWriter);
            queueableBinaryWriter.Defer(this.BitmapWidgets);
            queueableBinaryWriter.Defer(this.TextWidgets);
            this.DashlightData.DeferReferences(queueableBinaryWriter);
            queueableBinaryWriter.Defer(this.ScreenEffectWidgets);
        }
        public override void Write(Moonfish.Guerilla.LinearBinaryWriter queueableBinaryWriter)
        {
            base.Write(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.DONOTUSE);
            queueableBinaryWriter.WritePointer(this.BitmapWidgets);
            queueableBinaryWriter.WritePointer(this.TextWidgets);
            this.DashlightData.Write(queueableBinaryWriter);
            queueableBinaryWriter.WritePointer(this.ScreenEffectWidgets);
        }
    }
}
namespace Moonfish.Tags
{
    
    public partial struct TagClass
    {
        public static TagClass Nhdt = ((TagClass)("nhdt"));
    }
}
