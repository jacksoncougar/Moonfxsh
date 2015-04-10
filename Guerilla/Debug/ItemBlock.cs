// ReSharper disable All
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
        public  ItemBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  ItemBlockBase(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt32();
            oLDMessageIndex = binaryReader.ReadInt16();
            sortOrder = binaryReader.ReadInt16();
            multiplayerOnGroundScale = binaryReader.ReadSingle();
            campaignOnGroundScale = binaryReader.ReadSingle();
            pickupMessage = binaryReader.ReadStringID();
            swapMessage = binaryReader.ReadStringID();
            pickupOrDualMsg = binaryReader.ReadStringID();
            swapOrDualMsg = binaryReader.ReadStringID();
            dualOnlyMsg = binaryReader.ReadStringID();
            pickedUpMsg = binaryReader.ReadStringID();
            singluarQuantityMsg = binaryReader.ReadStringID();
            pluralQuantityMsg = binaryReader.ReadStringID();
            switchToMsg = binaryReader.ReadStringID();
            switchToFromAiMsg = binaryReader.ReadStringID();
            uNUSED = binaryReader.ReadTagReference();
            collisionSound = binaryReader.ReadTagReference();
            ReadPredictedBitmapsBlockArray(binaryReader);
            detonationDamageEffect = binaryReader.ReadTagReference();
            detonationDelaySeconds = binaryReader.ReadRange();
            detonatingEffect = binaryReader.ReadTagReference();
            detonationEffect = binaryReader.ReadTagReference();
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
        internal  virtual PredictedBitmapsBlock[] ReadPredictedBitmapsBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WritePredictedBitmapsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write(oLDMessageIndex);
                binaryWriter.Write(sortOrder);
                binaryWriter.Write(multiplayerOnGroundScale);
                binaryWriter.Write(campaignOnGroundScale);
                binaryWriter.Write(pickupMessage);
                binaryWriter.Write(swapMessage);
                binaryWriter.Write(pickupOrDualMsg);
                binaryWriter.Write(swapOrDualMsg);
                binaryWriter.Write(dualOnlyMsg);
                binaryWriter.Write(pickedUpMsg);
                binaryWriter.Write(singluarQuantityMsg);
                binaryWriter.Write(pluralQuantityMsg);
                binaryWriter.Write(switchToMsg);
                binaryWriter.Write(switchToFromAiMsg);
                binaryWriter.Write(uNUSED);
                binaryWriter.Write(collisionSound);
                WritePredictedBitmapsBlockArray(binaryWriter);
                binaryWriter.Write(detonationDamageEffect);
                binaryWriter.Write(detonationDelaySeconds);
                binaryWriter.Write(detonatingEffect);
                binaryWriter.Write(detonationEffect);
            }
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
