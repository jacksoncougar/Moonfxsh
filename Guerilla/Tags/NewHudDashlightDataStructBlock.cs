// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class NewHudDashlightDataStructBlock : NewHudDashlightDataStructBlockBase
    {
        public  NewHudDashlightDataStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class NewHudDashlightDataStructBlockBase  : IGuerilla
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
        internal  NewHudDashlightDataStructBlockBase(BinaryReader binaryReader)
        {
            lowClipCutoff = binaryReader.ReadInt16();
            lowAmmoCutoff = binaryReader.ReadInt16();
            ageCutoff = binaryReader.ReadSingle();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(lowClipCutoff);
                binaryWriter.Write(lowAmmoCutoff);
                binaryWriter.Write(ageCutoff);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
