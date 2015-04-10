using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class CharacterLookBlock : CharacterLookBlockBase
    {
        public  CharacterLookBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 80)]
    public class CharacterLookBlockBase
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
        internal  CharacterLookBlockBase(BinaryReader binaryReader)
        {
            this.maximumAimingDeviationDegrees = binaryReader.ReadVector2();
            this.maximumLookingDeviationDegrees = binaryReader.ReadVector2();
            this.invalidName_ = binaryReader.ReadBytes(16);
            this.noncombatLookDeltaLDegrees = binaryReader.ReadSingle();
            this.noncombatLookDeltaRDegrees = binaryReader.ReadSingle();
            this.combatLookDeltaLDegrees = binaryReader.ReadSingle();
            this.combatLookDeltaRDegrees = binaryReader.ReadSingle();
            this.noncombatIdleLookingSeconds = binaryReader.ReadRange();
            this.noncombatIdleAimingSeconds = binaryReader.ReadRange();
            this.combatIdleLookingSeconds = binaryReader.ReadRange();
            this.combatIdleAimingSeconds = binaryReader.ReadRange();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
    };
}
