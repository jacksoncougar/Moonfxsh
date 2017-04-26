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
    [TagBlockOriginalNameAttribute("variant_setting_edit_reference_block")]
    public partial class VariantSettingEditReferenceBlock : GuerillaBlock, IWriteDeferrable
    {
        public SettingCategoryEnum SettingCategory;
        private byte[] fieldpad = new byte[4];
        public TextValuePairBlock[] Options = new TextValuePairBlock[0];
        public NullBlock[] NullBlock = new NullBlock[0];
        public override int SerializedSize
        {
            get
            {
                return 24;
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
            this.SettingCategory = ((SettingCategoryEnum)(binaryReader.ReadInt32()));
            this.fieldpad = binaryReader.ReadBytes(4);
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(8));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(0));
            return pointerQueue;
        }
        public override void ReadInstances(Moonfish.Guerilla.BlamBinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.Options = base.ReadBlockArrayData<TextValuePairBlock>(binaryReader, pointerQueue.Dequeue());
            this.NullBlock = base.ReadBlockArrayData<NullBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void DeferReferences(Moonfish.Guerilla.LinearBinaryWriter queueableBinaryWriter)
        {
            base.DeferReferences(queueableBinaryWriter);
            queueableBinaryWriter.Defer(this.Options);
            queueableBinaryWriter.Defer(this.NullBlock);
        }
        public override void Write(Moonfish.Guerilla.LinearBinaryWriter queueableBinaryWriter)
        {
            base.Write(queueableBinaryWriter);
            queueableBinaryWriter.Write(((int)(this.SettingCategory)));
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.WritePointer(this.Options);
            queueableBinaryWriter.WritePointer(this.NullBlock);
        }
        public enum SettingCategoryEnum : int
        {
            Matchctf = 0,
            Matchslayer = 1,
            Matchoddball = 2,
            Matchking = 3,
            Matchrace = 4,
            Matchheadhunter = 5,
            Matchjuggernaut = 6,
            Matchterritories = 7,
            Matchassault = 8,
            Players = 9,
            OBSOLETE = 10,
            Vehicles = 11,
            Equipment = 12,
            Gamectf = 13,
            Gameslayer = 14,
            Gameoddball = 15,
            Gameking = 16,
            Gamerace = 17,
            Gameheadhunter = 18,
            Gamejuggernaut = 19,
            Gameterritories = 20,
            Gameassault = 21,
            QuickOptionsctf = 22,
            QuickOptionsslayer = 23,
            QuickOptionsoddball = 24,
            QuickOptionsking = 25,
            QuickOptionsrace = 26,
            QuickOptionsheadhunter = 27,
            QuickOptionsjuggernaut = 28,
            QuickOptionsterritories = 29,
            QuickOptionsassault = 30,
            Teamctf = 31,
            Teamslayer = 32,
            Teamoddball = 33,
            Teamking = 34,
            Teamrace = 35,
            Teamheadhunter = 36,
            Teamjuggernaut = 37,
            Teamterritories = 38,
            Teamassault = 39,
        }
    }
}
