using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class AiGlobalsBlock : AiGlobalsBlockBase
    {
        public  AiGlobalsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 360)]
    public class AiGlobalsBlockBase
    {
        internal float dangerBroadlyFacing;
        internal byte[] invalidName_;
        internal float dangerShootingNear;
        internal byte[] invalidName_0;
        internal float dangerShootingAt;
        internal byte[] invalidName_1;
        internal float dangerExtremelyClose;
        internal byte[] invalidName_2;
        internal float dangerShieldDamage;
        internal float dangerExetendedShieldDamage;
        internal float dangerBodyDamage;
        internal float dangerExtendedBodyDamage;
        internal byte[] invalidName_3;
        [TagReference("adlg")]
        internal Moonfish.Tags.TagReference globalDialogueTag;
        internal Moonfish.Tags.StringID defaultMissionDialogueSoundEffect;
        internal byte[] invalidName_4;
        internal float jumpDownWuTick;
        internal float jumpStepWuTick;
        internal float jumpCrouchWuTick;
        internal float jumpStandWuTick;
        internal float jumpStoreyWuTick;
        internal float jumpTowerWuTick;
        internal float maxJumpDownHeightDownWu;
        internal float maxJumpDownHeightStepWu;
        internal float maxJumpDownHeightCrouchWu;
        internal float maxJumpDownHeightStandWu;
        internal float maxJumpDownHeightStoreyWu;
        internal float maxJumpDownHeightTowerWu;
        internal Moonfish.Model.Range hoistStepWus;
        internal Moonfish.Model.Range hoistCrouchWus;
        internal Moonfish.Model.Range hoistStandWus;
        internal byte[] invalidName_5;
        internal Moonfish.Model.Range vaultStepWus;
        internal Moonfish.Model.Range vaultCrouchWus;
        internal byte[] invalidName_6;
        internal AiGlobalsGravemindBlock[] gravemindProperties;
        internal byte[] invalidName_7;
        /// <summary>
        /// A target of this scariness is offically considered scary (by combat dialogue, etc.)
        /// </summary>
        internal float scaryTargetThrehold;
        /// <summary>
        /// A weapon of this scariness is offically considered scary (by combat dialogue, etc.)
        /// </summary>
        internal float scaryWeaponThrehold;
        internal float playerScariness;
        internal float berserkingActorScariness;
        internal  AiGlobalsBlockBase(BinaryReader binaryReader)
        {
            this.dangerBroadlyFacing = binaryReader.ReadSingle();
            this.invalidName_ = binaryReader.ReadBytes(4);
            this.dangerShootingNear = binaryReader.ReadSingle();
            this.invalidName_0 = binaryReader.ReadBytes(4);
            this.dangerShootingAt = binaryReader.ReadSingle();
            this.invalidName_1 = binaryReader.ReadBytes(4);
            this.dangerExtremelyClose = binaryReader.ReadSingle();
            this.invalidName_2 = binaryReader.ReadBytes(4);
            this.dangerShieldDamage = binaryReader.ReadSingle();
            this.dangerExetendedShieldDamage = binaryReader.ReadSingle();
            this.dangerBodyDamage = binaryReader.ReadSingle();
            this.dangerExtendedBodyDamage = binaryReader.ReadSingle();
            this.invalidName_3 = binaryReader.ReadBytes(48);
            this.globalDialogueTag = binaryReader.ReadTagReference();
            this.defaultMissionDialogueSoundEffect = binaryReader.ReadStringID();
            this.invalidName_4 = binaryReader.ReadBytes(20);
            this.jumpDownWuTick = binaryReader.ReadSingle();
            this.jumpStepWuTick = binaryReader.ReadSingle();
            this.jumpCrouchWuTick = binaryReader.ReadSingle();
            this.jumpStandWuTick = binaryReader.ReadSingle();
            this.jumpStoreyWuTick = binaryReader.ReadSingle();
            this.jumpTowerWuTick = binaryReader.ReadSingle();
            this.maxJumpDownHeightDownWu = binaryReader.ReadSingle();
            this.maxJumpDownHeightStepWu = binaryReader.ReadSingle();
            this.maxJumpDownHeightCrouchWu = binaryReader.ReadSingle();
            this.maxJumpDownHeightStandWu = binaryReader.ReadSingle();
            this.maxJumpDownHeightStoreyWu = binaryReader.ReadSingle();
            this.maxJumpDownHeightTowerWu = binaryReader.ReadSingle();
            this.hoistStepWus = binaryReader.ReadRange();
            this.hoistCrouchWus = binaryReader.ReadRange();
            this.hoistStandWus = binaryReader.ReadRange();
            this.invalidName_5 = binaryReader.ReadBytes(24);
            this.vaultStepWus = binaryReader.ReadRange();
            this.vaultCrouchWus = binaryReader.ReadRange();
            this.invalidName_6 = binaryReader.ReadBytes(48);
            this.gravemindProperties = ReadAiGlobalsGravemindBlockArray(binaryReader);
            this.invalidName_7 = binaryReader.ReadBytes(48);
            this.scaryTargetThrehold = binaryReader.ReadSingle();
            this.scaryWeaponThrehold = binaryReader.ReadSingle();
            this.playerScariness = binaryReader.ReadSingle();
            this.berserkingActorScariness = binaryReader.ReadSingle();
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
        internal  virtual AiGlobalsGravemindBlock[] ReadAiGlobalsGravemindBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(AiGlobalsGravemindBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new AiGlobalsGravemindBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new AiGlobalsGravemindBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
