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
    public partial class NewHudDashlightDataStructBlock : NewHudDashlightDataStructBlockBase
    {
        public NewHudDashlightDataStructBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class NewHudDashlightDataStructBlockBase : GuerillaBlock
    {
        /// <summary>
        /// the cutoff for showing the reload dashlight
        /// </summary>
        internal short lowClipCutoff;
        /// <summary>
        /// the cutoff for showing the low ammo dashlight
        /// </summary>
        internal short lowAmmoCutoff;
        /// <summary>
        /// the ageCutoff for showing the low battery dashlight
        /// </summary>
        internal float ageCutoff;
        public override int SerializedSize { get { return 8; } }
        public override int Alignment { get { return 4; } }
        public NewHudDashlightDataStructBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            lowClipCutoff = binaryReader.ReadInt16();
            lowAmmoCutoff = binaryReader.ReadInt16();
            ageCutoff = binaryReader.ReadSingle();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(lowClipCutoff);
                binaryWriter.Write(lowAmmoCutoff);
                binaryWriter.Write(ageCutoff);
                return nextAddress;
            }
        }
    };
}
