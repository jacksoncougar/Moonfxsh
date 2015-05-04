// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class UiCampaignBlock : UiCampaignBlockBase
    {
        public UiCampaignBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 2884, Alignment = 4)]
    public class UiCampaignBlockBase : GuerillaBlock
    {
        internal int campaignID;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;

        public override int SerializedSize
        {
            get { return 2884; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public UiCampaignBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            campaignID = binaryReader.ReadInt32();
            invalidName_ = binaryReader.ReadBytes(576);
            invalidName_0 = binaryReader.ReadBytes(2304);
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(campaignID);
                binaryWriter.Write(invalidName_, 0, 576);
                binaryWriter.Write(invalidName_0, 0, 2304);
                return nextAddress;
            }
        }
    };
}