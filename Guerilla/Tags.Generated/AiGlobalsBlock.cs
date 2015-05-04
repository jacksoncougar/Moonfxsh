// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class AiGlobalsBlock : AiGlobalsBlockBase
    {
        public  AiGlobalsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  AiGlobalsBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 360, Alignment = 4)]
    public class AiGlobalsBlockBase : GuerillaBlock
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
        internal Moonfish.Tags.StringIdent defaultMissionDialogueSoundEffect;
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
        
        public override int SerializedSize{get { return 360; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  AiGlobalsBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            dangerBroadlyFacing = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(4);
            dangerShootingNear = binaryReader.ReadSingle();
            invalidName_0 = binaryReader.ReadBytes(4);
            dangerShootingAt = binaryReader.ReadSingle();
            invalidName_1 = binaryReader.ReadBytes(4);
            dangerExtremelyClose = binaryReader.ReadSingle();
            invalidName_2 = binaryReader.ReadBytes(4);
            dangerShieldDamage = binaryReader.ReadSingle();
            dangerExetendedShieldDamage = binaryReader.ReadSingle();
            dangerBodyDamage = binaryReader.ReadSingle();
            dangerExtendedBodyDamage = binaryReader.ReadSingle();
            invalidName_3 = binaryReader.ReadBytes(48);
            globalDialogueTag = binaryReader.ReadTagReference();
            defaultMissionDialogueSoundEffect = binaryReader.ReadStringID();
            invalidName_4 = binaryReader.ReadBytes(20);
            jumpDownWuTick = binaryReader.ReadSingle();
            jumpStepWuTick = binaryReader.ReadSingle();
            jumpCrouchWuTick = binaryReader.ReadSingle();
            jumpStandWuTick = binaryReader.ReadSingle();
            jumpStoreyWuTick = binaryReader.ReadSingle();
            jumpTowerWuTick = binaryReader.ReadSingle();
            maxJumpDownHeightDownWu = binaryReader.ReadSingle();
            maxJumpDownHeightStepWu = binaryReader.ReadSingle();
            maxJumpDownHeightCrouchWu = binaryReader.ReadSingle();
            maxJumpDownHeightStandWu = binaryReader.ReadSingle();
            maxJumpDownHeightStoreyWu = binaryReader.ReadSingle();
            maxJumpDownHeightTowerWu = binaryReader.ReadSingle();
            hoistStepWus = binaryReader.ReadRange();
            hoistCrouchWus = binaryReader.ReadRange();
            hoistStandWus = binaryReader.ReadRange();
            invalidName_5 = binaryReader.ReadBytes(24);
            vaultStepWus = binaryReader.ReadRange();
            vaultCrouchWus = binaryReader.ReadRange();
            invalidName_6 = binaryReader.ReadBytes(48);
            gravemindProperties = Guerilla.ReadBlockArray<AiGlobalsGravemindBlock>(binaryReader);
            invalidName_7 = binaryReader.ReadBytes(48);
            scaryTargetThrehold = binaryReader.ReadSingle();
            scaryWeaponThrehold = binaryReader.ReadSingle();
            playerScariness = binaryReader.ReadSingle();
            berserkingActorScariness = binaryReader.ReadSingle();
        }
        public  AiGlobalsBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            dangerBroadlyFacing = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(4);
            dangerShootingNear = binaryReader.ReadSingle();
            invalidName_0 = binaryReader.ReadBytes(4);
            dangerShootingAt = binaryReader.ReadSingle();
            invalidName_1 = binaryReader.ReadBytes(4);
            dangerExtremelyClose = binaryReader.ReadSingle();
            invalidName_2 = binaryReader.ReadBytes(4);
            dangerShieldDamage = binaryReader.ReadSingle();
            dangerExetendedShieldDamage = binaryReader.ReadSingle();
            dangerBodyDamage = binaryReader.ReadSingle();
            dangerExtendedBodyDamage = binaryReader.ReadSingle();
            invalidName_3 = binaryReader.ReadBytes(48);
            globalDialogueTag = binaryReader.ReadTagReference();
            defaultMissionDialogueSoundEffect = binaryReader.ReadStringID();
            invalidName_4 = binaryReader.ReadBytes(20);
            jumpDownWuTick = binaryReader.ReadSingle();
            jumpStepWuTick = binaryReader.ReadSingle();
            jumpCrouchWuTick = binaryReader.ReadSingle();
            jumpStandWuTick = binaryReader.ReadSingle();
            jumpStoreyWuTick = binaryReader.ReadSingle();
            jumpTowerWuTick = binaryReader.ReadSingle();
            maxJumpDownHeightDownWu = binaryReader.ReadSingle();
            maxJumpDownHeightStepWu = binaryReader.ReadSingle();
            maxJumpDownHeightCrouchWu = binaryReader.ReadSingle();
            maxJumpDownHeightStandWu = binaryReader.ReadSingle();
            maxJumpDownHeightStoreyWu = binaryReader.ReadSingle();
            maxJumpDownHeightTowerWu = binaryReader.ReadSingle();
            hoistStepWus = binaryReader.ReadRange();
            hoistCrouchWus = binaryReader.ReadRange();
            hoistStandWus = binaryReader.ReadRange();
            invalidName_5 = binaryReader.ReadBytes(24);
            vaultStepWus = binaryReader.ReadRange();
            vaultCrouchWus = binaryReader.ReadRange();
            invalidName_6 = binaryReader.ReadBytes(48);
            gravemindProperties = Guerilla.ReadBlockArray<AiGlobalsGravemindBlock>(binaryReader);
            invalidName_7 = binaryReader.ReadBytes(48);
            scaryTargetThrehold = binaryReader.ReadSingle();
            scaryWeaponThrehold = binaryReader.ReadSingle();
            playerScariness = binaryReader.ReadSingle();
            berserkingActorScariness = binaryReader.ReadSingle();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(dangerBroadlyFacing);
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(dangerShootingNear);
                binaryWriter.Write(invalidName_0, 0, 4);
                binaryWriter.Write(dangerShootingAt);
                binaryWriter.Write(invalidName_1, 0, 4);
                binaryWriter.Write(dangerExtremelyClose);
                binaryWriter.Write(invalidName_2, 0, 4);
                binaryWriter.Write(dangerShieldDamage);
                binaryWriter.Write(dangerExetendedShieldDamage);
                binaryWriter.Write(dangerBodyDamage);
                binaryWriter.Write(dangerExtendedBodyDamage);
                binaryWriter.Write(invalidName_3, 0, 48);
                binaryWriter.Write(globalDialogueTag);
                binaryWriter.Write(defaultMissionDialogueSoundEffect);
                binaryWriter.Write(invalidName_4, 0, 20);
                binaryWriter.Write(jumpDownWuTick);
                binaryWriter.Write(jumpStepWuTick);
                binaryWriter.Write(jumpCrouchWuTick);
                binaryWriter.Write(jumpStandWuTick);
                binaryWriter.Write(jumpStoreyWuTick);
                binaryWriter.Write(jumpTowerWuTick);
                binaryWriter.Write(maxJumpDownHeightDownWu);
                binaryWriter.Write(maxJumpDownHeightStepWu);
                binaryWriter.Write(maxJumpDownHeightCrouchWu);
                binaryWriter.Write(maxJumpDownHeightStandWu);
                binaryWriter.Write(maxJumpDownHeightStoreyWu);
                binaryWriter.Write(maxJumpDownHeightTowerWu);
                binaryWriter.Write(hoistStepWus);
                binaryWriter.Write(hoistCrouchWus);
                binaryWriter.Write(hoistStandWus);
                binaryWriter.Write(invalidName_5, 0, 24);
                binaryWriter.Write(vaultStepWus);
                binaryWriter.Write(vaultCrouchWus);
                binaryWriter.Write(invalidName_6, 0, 48);
                nextAddress = Guerilla.WriteBlockArray<AiGlobalsGravemindBlock>(binaryWriter, gravemindProperties, nextAddress);
                binaryWriter.Write(invalidName_7, 0, 48);
                binaryWriter.Write(scaryTargetThrehold);
                binaryWriter.Write(scaryWeaponThrehold);
                binaryWriter.Write(playerScariness);
                binaryWriter.Write(berserkingActorScariness);
                return nextAddress;
            }
        }
    };
}
