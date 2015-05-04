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
    public partial class UnitBoardingMeleeStructBlock : UnitBoardingMeleeStructBlockBase
    {
        public UnitBoardingMeleeStructBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 40, Alignment = 4)]
    public class UnitBoardingMeleeStructBlockBase : GuerillaBlock
    {
        [TagReference("jpt!")] internal Moonfish.Tags.TagReference boardingMeleeDamage;
        [TagReference("jpt!")] internal Moonfish.Tags.TagReference boardingMeleeResponse;
        [TagReference("jpt!")] internal Moonfish.Tags.TagReference landingMeleeDamage;
        [TagReference("jpt!")] internal Moonfish.Tags.TagReference flurryMeleeDamage;
        [TagReference("jpt!")] internal Moonfish.Tags.TagReference obstacleSmashDamage;

        public override int SerializedSize
        {
            get { return 40; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public UnitBoardingMeleeStructBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            boardingMeleeDamage = binaryReader.ReadTagReference();
            boardingMeleeResponse = binaryReader.ReadTagReference();
            landingMeleeDamage = binaryReader.ReadTagReference();
            flurryMeleeDamage = binaryReader.ReadTagReference();
            obstacleSmashDamage = binaryReader.ReadTagReference();
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
                binaryWriter.Write(boardingMeleeDamage);
                binaryWriter.Write(boardingMeleeResponse);
                binaryWriter.Write(landingMeleeDamage);
                binaryWriter.Write(flurryMeleeDamage);
                binaryWriter.Write(obstacleSmashDamage);
                return nextAddress;
            }
        }
    };
}