// ReSharper disable All
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
        public  CharacterLookBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  CharacterLookBlockBase(System.IO.BinaryReader binaryReader)
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
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
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
            }
        }
    };
}
