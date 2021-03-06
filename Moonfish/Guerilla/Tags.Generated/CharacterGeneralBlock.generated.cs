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
    
    public partial class CharacterGeneralBlock : GuerillaBlock, IWriteQueueable
    {
        public GeneralFlags CharacterGeneralGeneralFlags;
        public TypeEnum Type;
        private byte[] fieldpad = new byte[2];
        public float Scariness;
        public override int SerializedSize
        {
            get
            {
                return 12;
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
            this.CharacterGeneralGeneralFlags = ((GeneralFlags)(binaryReader.ReadInt32()));
            this.Type = ((TypeEnum)(binaryReader.ReadInt16()));
            this.fieldpad = binaryReader.ReadBytes(2);
            this.Scariness = binaryReader.ReadSingle();
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
            queueableBinaryWriter.Write(((int)(this.CharacterGeneralGeneralFlags)));
            queueableBinaryWriter.Write(((short)(this.Type)));
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.Write(this.Scariness);
        }
        [System.FlagsAttribute()]
        public enum GeneralFlags : int
        {
            None = 0,
            Swarm = 1,
            Flying = 2,
            DualWields = 4,
            UsesGravemind = 8,
        }
        public enum TypeEnum : short
        {
            Elite = 0,
            Jackal = 1,
            Grunt = 2,
            Hunter = 3,
            Engineer = 4,
            Assassin = 5,
            Player = 6,
            Marine = 7,
            Crew = 8,
            CombatForm = 9,
            InfectionForm = 10,
            CarrierForm = 11,
            Monitor = 12,
            Sentinel = 13,
            None = 14,
            MountedWeapon = 15,
            Brute = 16,
            Prophet = 17,
            Bugger = 18,
            Juggernaut = 19,
        }
    }
}
