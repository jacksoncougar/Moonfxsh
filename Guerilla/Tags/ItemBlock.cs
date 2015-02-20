using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("item")]
    public  partial class ItemBlock : ItemBlockBase
    {
        public  ItemBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 112)]
    public class ItemBlockBase : ObjectBlock
    {
        internal Flags flags;
        internal short oLDMessageIndex;
        internal short sortOrder;
        internal float multiplayerOnGroundScale;
        internal float campaignOnGroundScale;
        internal Moonfish.Tags.StringID pickupMessage;
        internal Moonfish.Tags.StringID swapMessage;
        internal Moonfish.Tags.StringID pickupOrDualMsg;
        internal Moonfish.Tags.StringID swapOrDualMsg;
        internal Moonfish.Tags.StringID dualOnlyMsg;
        internal Moonfish.Tags.StringID pickedUpMsg;
        internal Moonfish.Tags.StringID singluarQuantityMsg;
        internal Moonfish.Tags.StringID pluralQuantityMsg;
        internal Moonfish.Tags.StringID switchToMsg;
        internal Moonfish.Tags.StringID switchToFromAiMsg;
        [TagReference("foot")]
        internal Moonfish.Tags.TagReference uNUSED;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference collisionSound;
        internal PredictedBitmapsBlock[] predictedBitmaps;
        [TagReference("jpt!")]
        internal Moonfish.Tags.TagReference detonationDamageEffect;
        internal Moonfish.Model.Range detonationDelaySeconds;
        [TagReference("effe")]
        internal Moonfish.Tags.TagReference detonatingEffect;
        [TagReference("effe")]
        internal Moonfish.Tags.TagReference detonationEffect;
        internal  ItemBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt32();
            this.oLDMessageIndex = binaryReader.ReadInt16();
            this.sortOrder = binaryReader.ReadInt16();
            this.multiplayerOnGroundScale = binaryReader.ReadSingle();
            this.campaignOnGroundScale = binaryReader.ReadSingle();
            this.pickupMessage = binaryReader.ReadStringID();
            this.swapMessage = binaryReader.ReadStringID();
            this.pickupOrDualMsg = binaryReader.ReadStringID();
            this.swapOrDualMsg = binaryReader.ReadStringID();
            this.dualOnlyMsg = binaryReader.ReadStringID();
            this.pickedUpMsg = binaryReader.ReadStringID();
            this.singluarQuantityMsg = binaryReader.ReadStringID();
            this.pluralQuantityMsg = binaryReader.ReadStringID();
            this.switchToMsg = binaryReader.ReadStringID();
            this.switchToFromAiMsg = binaryReader.ReadStringID();
            this.uNUSED = binaryReader.ReadTagReference();
            this.collisionSound = binaryReader.ReadTagReference();
            this.predictedBitmaps = ReadPredictedBitmapsBlockArray(binaryReader);
            this.detonationDamageEffect = binaryReader.ReadTagReference();
            this.detonationDelaySeconds = binaryReader.ReadRange();
            this.detonatingEffect = binaryReader.ReadTagReference();
            this.detonationEffect = binaryReader.ReadTagReference();
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
        internal  virtual PredictedBitmapsBlock[] ReadPredictedBitmapsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PredictedBitmapsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PredictedBitmapsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PredictedBitmapsBlock(binaryReader);
                }
            }
            return array;
        }
        [FlagsAttribute]
        internal enum Flags : int
        
        {
            AlwaysMaintainsZUp = 1,
            DestroyedByExplosions = 2,
            UnaffectedByGravity = 4,
        };
    };
}
