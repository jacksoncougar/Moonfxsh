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
    [LayoutAttribute(Size = 8)]
    public class NewHudDashlightDataStructBlockBase
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
            this.lowClipCutoff = binaryReader.ReadInt16();
            this.lowAmmoCutoff = binaryReader.ReadInt16();
            this.ageCutoff = binaryReader.ReadSingle();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
        }
    };
}
