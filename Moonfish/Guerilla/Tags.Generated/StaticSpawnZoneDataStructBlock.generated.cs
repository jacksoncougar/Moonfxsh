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
    [TagBlockOriginalNameAttribute("static_spawn_zone_data_struct_block")]
    public partial class StaticSpawnZoneDataStructBlock : GuerillaBlock, IWriteDeferrable
    {
        /// <summary>
        /// Lower and upper heights can be left at 0, in which case they use defaults.  Leaving relevant teams empty means all teams; leaving all games empty means all games.
        /// </summary>
        public Moonfish.Tags.StringIdent Name;
        public RelevantTeam StaticSpawnZoneDataStructRelevantTeam;
        public RelevantGames StaticSpawnZoneDataStructRelevantGames;
        public Flags StaticSpawnZoneDataStructFlags;
        public override int SerializedSize
        {
            get
            {
                return 16;
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
            this.Name = binaryReader.ReadStringIdent();
            this.StaticSpawnZoneDataStructRelevantTeam = ((RelevantTeam)(binaryReader.ReadInt32()));
            this.StaticSpawnZoneDataStructRelevantGames = ((RelevantGames)(binaryReader.ReadInt32()));
            this.StaticSpawnZoneDataStructFlags = ((Flags)(binaryReader.ReadInt32()));
            return pointerQueue;
        }
        public override void ReadInstances(Moonfish.Guerilla.BlamBinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
        }
        public override void DeferReferences(Moonfish.Guerilla.LinearBinaryWriter queueableBinaryWriter)
        {
            base.DeferReferences(queueableBinaryWriter);
        }
        public override void Write(Moonfish.Guerilla.LinearBinaryWriter queueableBinaryWriter)
        {
            base.Write(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.Name);
            queueableBinaryWriter.Write(((int)(this.StaticSpawnZoneDataStructRelevantTeam)));
            queueableBinaryWriter.Write(((int)(this.StaticSpawnZoneDataStructRelevantGames)));
            queueableBinaryWriter.Write(((int)(this.StaticSpawnZoneDataStructFlags)));
        }
        [System.FlagsAttribute()]
        public enum RelevantTeam : int
        {
            None = 0,
            RedAlpha = 1,
            BlueBravo = 2,
            YellowCharlie = 4,
            GreenDelta = 8,
            PurpleEcho = 16,
            OrangeFoxtrot = 32,
            BrownGolf = 64,
            PinkHotel = 128,
            NEUTRAL = 256,
        }
        [System.FlagsAttribute()]
        public enum RelevantGames : int
        {
            None = 0,
            Slayer = 1,
            Oddball = 2,
            KingOfTheHill = 4,
            CaptureTheFlag = 8,
            Race = 16,
            Headhunter = 32,
            Juggernaut = 64,
            Territories = 128,
        }
        [System.FlagsAttribute()]
        public enum Flags : int
        {
            None = 0,
            DisabledIfFlagHome = 1,
            DisabledIfFlagAway = 2,
            DisabledIfBombHome = 4,
            DisabledIfBombAway = 8,
        }
    }
}
