// ReSharper disable All

using Moonfish.Model;

using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Item = (TagClass) "item";
    };
} ;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("item")]
    public partial class ItemBlock : ItemBlockBase
    {
        public ItemBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 112, Alignment = 4)]
    public class ItemBlockBase : ObjectBlock
    {
        internal Flags flags;
        internal short oLDMessageIndex;
        internal short sortOrder;
        internal float multiplayerOnGroundScale;
        internal float campaignOnGroundScale;
        internal Moonfish.Tags.StringIdent pickupMessage;
        internal Moonfish.Tags.StringIdent swapMessage;
        internal Moonfish.Tags.StringIdent pickupOrDualMsg;
        internal Moonfish.Tags.StringIdent swapOrDualMsg;
        internal Moonfish.Tags.StringIdent dualOnlyMsg;
        internal Moonfish.Tags.StringIdent pickedUpMsg;
        internal Moonfish.Tags.StringIdent singluarQuantityMsg;
        internal Moonfish.Tags.StringIdent pluralQuantityMsg;
        internal Moonfish.Tags.StringIdent switchToMsg;
        internal Moonfish.Tags.StringIdent switchToFromAiMsg;
        [TagReference("foot")] internal Moonfish.Tags.TagReference uNUSED;
        [TagReference("snd!")] internal Moonfish.Tags.TagReference collisionSound;
        internal PredictedBitmapsBlock[] predictedBitmaps;
        [TagReference("jpt!")] internal Moonfish.Tags.TagReference detonationDamageEffect;
        internal Moonfish.Model.Range detonationDelaySeconds;
        [TagReference("effe")] internal Moonfish.Tags.TagReference detonatingEffect;
        [TagReference("effe")] internal Moonfish.Tags.TagReference detonationEffect;

        public override int SerializedSize
        {
            get { return 300; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ItemBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            flags = (Flags) binaryReader.ReadInt32();
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
            blamPointers.Enqueue(ReadBlockArrayPointer<PredictedBitmapsBlock>(binaryReader));
            detonationDamageEffect = binaryReader.ReadTagReference();
            detonationDelaySeconds = binaryReader.ReadRange();
            detonatingEffect = binaryReader.ReadTagReference();
            detonationEffect = binaryReader.ReadTagReference();
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            predictedBitmaps = ReadBlockArrayData<PredictedBitmapsBlock>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32) flags);
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
                nextAddress = Guerilla.WriteBlockArray<PredictedBitmapsBlock>(binaryWriter, predictedBitmaps,
                    nextAddress);
                binaryWriter.Write(detonationDamageEffect);
                binaryWriter.Write(detonationDelaySeconds);
                binaryWriter.Write(detonatingEffect);
                binaryWriter.Write(detonationEffect);
                return nextAddress;
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