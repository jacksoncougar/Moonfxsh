// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class CharacterLookBlock : CharacterLookBlockBase
    {
        public  CharacterLookBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  CharacterLookBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 80, Alignment = 4)]
    public class CharacterLookBlockBase : GuerillaBlock
    {
        /// <summary>
        /// how far we can turn our weapon
        /// </summary>
        internal OpenTK.Vector2 maximumAimingDeviationDegrees;
        /// <summary>
        /// how far we can turn our head
        /// </summary>
        internal OpenTK.Vector2 maximumLookingDeviationDegrees;
        internal byte[] invalidName_;
        /// <summary>
        /// how far we can turn our head left away from our aiming vector when not in combat
        /// </summary>
        internal float noncombatLookDeltaLDegrees;
        /// <summary>
        /// how far we can turn our head right away from our aiming vector when not in combat
        /// </summary>
        internal float noncombatLookDeltaRDegrees;
        /// <summary>
        /// how far we can turn our head left away from our aiming vector when in combat
        /// </summary>
        internal float combatLookDeltaLDegrees;
        /// <summary>
        /// how far we can turn our head right away from our aiming vector when in combat
        /// </summary>
        internal float combatLookDeltaRDegrees;
        /// <summary>
        /// rate at which we change look around randomly when not in combat
        /// </summary>
        internal Moonfish.Model.Range noncombatIdleLookingSeconds;
        /// <summary>
        /// rate at which we change aiming directions when looking around randomly when not in combat
        /// </summary>
        internal Moonfish.Model.Range noncombatIdleAimingSeconds;
        /// <summary>
        /// rate at which we change look around randomly when searching or in combat
        /// </summary>
        internal Moonfish.Model.Range combatIdleLookingSeconds;
        /// <summary>
        /// rate at which we change aiming directions when looking around randomly when searching or in combat
        /// </summary>
        internal Moonfish.Model.Range combatIdleAimingSeconds;
        
        public override int SerializedSize{get { return 80; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  CharacterLookBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            maximumAimingDeviationDegrees = binaryReader.ReadVector2();
            maximumLookingDeviationDegrees = binaryReader.ReadVector2();
            invalidName_ = binaryReader.ReadBytes(16);
            noncombatLookDeltaLDegrees = binaryReader.ReadSingle();
            noncombatLookDeltaRDegrees = binaryReader.ReadSingle();
            combatLookDeltaLDegrees = binaryReader.ReadSingle();
            combatLookDeltaRDegrees = binaryReader.ReadSingle();
            noncombatIdleLookingSeconds = binaryReader.ReadRange();
            noncombatIdleAimingSeconds = binaryReader.ReadRange();
            combatIdleLookingSeconds = binaryReader.ReadRange();
            combatIdleAimingSeconds = binaryReader.ReadRange();
        }
        public  CharacterLookBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            maximumAimingDeviationDegrees = binaryReader.ReadVector2();
            maximumLookingDeviationDegrees = binaryReader.ReadVector2();
            invalidName_ = binaryReader.ReadBytes(16);
            noncombatLookDeltaLDegrees = binaryReader.ReadSingle();
            noncombatLookDeltaRDegrees = binaryReader.ReadSingle();
            combatLookDeltaLDegrees = binaryReader.ReadSingle();
            combatLookDeltaRDegrees = binaryReader.ReadSingle();
            noncombatIdleLookingSeconds = binaryReader.ReadRange();
            noncombatIdleAimingSeconds = binaryReader.ReadRange();
            combatIdleLookingSeconds = binaryReader.ReadRange();
            combatIdleAimingSeconds = binaryReader.ReadRange();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(maximumAimingDeviationDegrees);
                binaryWriter.Write(maximumLookingDeviationDegrees);
                binaryWriter.Write(invalidName_, 0, 16);
                binaryWriter.Write(noncombatLookDeltaLDegrees);
                binaryWriter.Write(noncombatLookDeltaRDegrees);
                binaryWriter.Write(combatLookDeltaLDegrees);
                binaryWriter.Write(combatLookDeltaRDegrees);
                binaryWriter.Write(noncombatIdleLookingSeconds);
                binaryWriter.Write(noncombatIdleAimingSeconds);
                binaryWriter.Write(combatIdleLookingSeconds);
                binaryWriter.Write(combatIdleAimingSeconds);
                return nextAddress;
            }
        }
    };
}
